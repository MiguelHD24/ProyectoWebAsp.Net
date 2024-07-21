using BL;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilidades;
using static EL.Enum;


namespace ProjectoWeb
{
    public partial class AdministracionUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidarSesion();
            if (!IsPostBack)
            {
                cargarGrid();
                cargarDDLRoles();
            }
        }

        #region Metodos y Funciones
        private void Mensaje(string Message, eMessage tipoMensaje, string Encabezado = "", bool Html = false, bool Fondo = false, bool returnLogin = false, string UrlReturn = "", bool CerrarClick = true)
        {
            //icon -->      success,warning, error,  info
            //btnColor -->  #32A525,#E38618,#F27474,#3FC3EE

            //Parametros que recibe el metodo
            //function Mensaje(title, mensaje, icon = 'success', btnConfirmText = 'Aceptar', btnConfirmColor = '#32A525', html = false, fondo = false, ReturnLogin = false, UrlReturn)

            switch (tipoMensaje)
            {
                case eMessage.Exito:
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SweetAlert Exito", "Mensaje('" + Encabezado + "', '" + Message + "','success','Aceptar','#32A525'," + Html.ToString().ToLower() + "," + Fondo.ToString().ToLower() + "," + returnLogin.ToString().ToLower() + ",'" + UrlReturn.ToString().ToLower() + "'," + CerrarClick.ToString().ToLower() + ");", true);
                    break;
                case eMessage.Alerta:
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SweetAlert Alerta", "Mensaje('" + Encabezado + "', '" + Message + "','warning','Aceptar','#E38618'," + Html.ToString().ToLower() + "," + Fondo.ToString().ToLower() + "," + returnLogin.ToString().ToLower() + ",'" + UrlReturn.ToString().ToLower() + "'," + CerrarClick.ToString().ToLower() + ");", true);
                    break;
                case eMessage.Error:
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SweetAlert Error", "Mensaje('" + Encabezado + "', '" + Message + "','error','Aceptar','#F27474'," + Html.ToString().ToLower() + "," + Fondo.ToString().ToLower() + "," + returnLogin.ToString().ToLower() + ",'" + UrlReturn.ToString().ToLower() + "'," + CerrarClick.ToString().ToLower() + ");", true);
                    break;
                case eMessage.Info:
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SweetAlert Info", "Mensaje('" + Encabezado + "', '" + Message + "','info','Aceptar','#3FC3EE'," + Html.ToString().ToLower() + "," + Fondo.ToString().ToLower() + "," + returnLogin.ToString().ToLower() + ",'" + UrlReturn.ToString().ToLower() + "'," + CerrarClick.ToString().ToLower() + ");", true);
                    break;
            }
        }
        private string Justify(string msj)
        {
            string Html = "<div style = text-align:justify> " + msj + " </div>";
            return Html;
        }
        private void AbandonarSesion(bool MostrarMensaje = true)
        {
            Session.Abandon();
            Session.RemoveAll();
            HttpCookie CookieSesion = new HttpCookie("ASP.NET_SessionId", "");
            Response.Cookies.Add(CookieSesion);
            if (MostrarMensaje)
            {
                Mensaje("Inicie Sesión Nuevamente", eMessage.Info, "Datos de Sesión Incompletos", false, true, true, "/Acceso.aspx", false);
            }
        }
        private bool ValidarSesion()
        {
            try
            {
                int IdUsuarioGl = (int)General.ValidarEnteros(Session["IdUsuarioGl"]);
                int IdRolGl = (int)General.ValidarEnteros(Session["IdRolGl"]);
                if (!(IdUsuarioGl > 0))
                {
                    AbandonarSesion();
                    return false;
                }

                if (!(IdRolGl > 0))
                {
                    AbandonarSesion();
                    return false;
                }

                Usuarios User = BL_Usuarios.Registro(IdUsuarioGl);
                if (User == null)
                {
                    AbandonarSesion();
                    return false;
                }

                if (User.IdRol != IdRolGl)
                {
                    AbandonarSesion();
                    return false;
                }

                List<RolFormularios> FormulariosUser = BL_RolFormulario.List(IdRolGl);
                if (!(FormulariosUser.Count > 0))
                {
                    AbandonarSesion(false);
                    Mensaje("Estimado usuario, no cuenta con permisos necesarios para ingresar a ningún formulario", eMessage.Info, "", false, true, true, "/Login.aspx", false);
                    return false;
                }
                Session["RolFormulariosGl"] = FormulariosUser;

                List<RolPermisos> PersmisosUser = BL_RolPermisos.List(IdRolGl);
                panelBtnLimpiar.Visible = true;
                panelBtnGuardar.Visible = false;
                panelBtnAnular.Visible = false;
                panelBtnBloqueo.Visible = false;

                if (PersmisosUser.Count > 0)
                {
                    foreach (var PermisoUser in PersmisosUser)
                    {
                        if (PermisoUser.IdPermiso == (int)ePermisos.Escritura)
                        {
                            panelBtnGuardar.Visible = true;
                        }
                        if (PermisoUser.IdPermiso == (int)ePermisos.Anular)
                        {
                            panelBtnAnular.Visible = true;
                        }
                        if (PermisoUser.IdPermiso == (int)ePermisos.Bloqueo)
                        {
                            panelBtnBloqueo.Visible = true;
                        }
                    }
                }
                return true;
            }
            catch
            {
                AbandonarSesion();
                return false;
            }
        }
        private void cargarGrid(bool ResetPage = false)
        {
            if (ResetPage)
            {
                gridUsuarios.PageIndex = 0;
            }
            gridUsuarios.DataSource = BL_Usuarios.vUsuarios();
            gridUsuarios.DataBind();

        }
        private void cargarDDLRoles()
        {
            try
            {
                ddlRol.Items.Clear();
                ddlRol.Items.Insert(0, new ListItem("--Seleccione--"));
                ddlRol.DataSource = BL_Roles.List();
                ddlRol.DataValueField = "IdRol";
                ddlRol.DataTextField = "Rol";
                ddlRol.DataBind();
            }
            catch
            {
                Mensaje("Error al cargar los roles", eMessage.Error);
            }
        }
        private void ResetControles()
        {
            txtNombreCompleto.Text = string.Empty;
            txtCorreo.Text = string.Empty;
            txtLogin.Text = string.Empty;
            txtContraseña.Text = string.Empty;
            ddlRol.SelectedIndex = 0;
            HF_IdUsuario.Value = "0";
            lnkBloqueo.Text = "Bloqueo";
        }
        private bool validarInsertar()
        {
            if (string.IsNullOrEmpty(txtNombreCompleto.Text) || string.IsNullOrWhiteSpace(txtNombreCompleto.Text))
            {
                Mensaje("Ingrese el nombre completo del usuario", eMessage.Alerta);
                return false;
            }
            if (string.IsNullOrEmpty(txtCorreo.Text) || string.IsNullOrWhiteSpace(txtCorreo.Text))
            {
                Mensaje("Ingrese el correo del usuario", eMessage.Alerta);
                return false;
            }
            if (!General.CorreoEsValido(txtCorreo.Text))
            {
                Mensaje("Ingrese un correo válido", eMessage.Alerta);
                return false;
            }
            if (string.IsNullOrEmpty(txtLogin.Text) || string.IsNullOrWhiteSpace(txtLogin.Text))
            {
                Mensaje("Ingrese el login del usuario", eMessage.Alerta);
                return false;
            }
            if (BL_Usuarios.ExisteUserName(txtLogin.Text))
            {
                Mensaje("El Login ya existe en el sistema.", eMessage.Alerta);
                return false;
            }
            if (string.IsNullOrEmpty(txtContraseña.Text) || string.IsNullOrWhiteSpace(txtContraseña.Text))
            {
                Mensaje("Ingrese la contraseña del usuario", eMessage.Alerta);
                return false;
            }
            if (!General.validarComplejidadPassword(txtContraseña.Text))
            {
                Mensaje(Justify("La contraseña debe cumplir con los siguientes requerimientos mínimos: <ul> <li>Longitud Mínima: 8 caracteres</li> <li> Una letra Mayúscula</li> <li> Una letra Minúscula</li> <li> Un número</li></ul>"), eMessage.Alerta, "", true);
                return false;
            }
            if (ddlRol.SelectedIndex == 0)
            {
                Mensaje("Seleccione el Rol del usuario", eMessage.Alerta);
                return false;
            }

            return true;
        }
        private bool validarActualizar(int IdRegistro)
        {
            if (string.IsNullOrEmpty(txtNombreCompleto.Text) || string.IsNullOrWhiteSpace(txtNombreCompleto.Text))
            {
                Mensaje("Ingrese el nombre completo del usuario", eMessage.Alerta);
                return false;
            }
            if (string.IsNullOrEmpty(txtCorreo.Text) || string.IsNullOrWhiteSpace(txtCorreo.Text))
            {
                Mensaje("Ingrese el correo del usuario", eMessage.Alerta);
                return false;
            }
            if (!General.CorreoEsValido(txtCorreo.Text))
            {
                Mensaje("Ingrese un correo válido", eMessage.Alerta);
                return false;
            }
            if (string.IsNullOrEmpty(txtLogin.Text) || string.IsNullOrWhiteSpace(txtLogin.Text))
            {
                Mensaje("Ingrese el login del usuario", eMessage.Alerta);
                return false;
            }

            if (BL_Usuarios.ExisteUserNameUpdate(txtLogin.Text, IdRegistro))
            {
                Mensaje("El Login ya existe en el sistema.", eMessage.Alerta);
                return false;
            }
            if (!(string.IsNullOrEmpty(txtContraseña.Text) || string.IsNullOrWhiteSpace(txtContraseña.Text)))
            {
                if (!General.validarComplejidadPassword(txtContraseña.Text))
                {
                    Mensaje(Justify("La contraseña debe cumplir con los siguientes requerimientos mínimos: <ul> <li>Longitud Mínima: 8 caracteres</li> <li> Una letra Mayúscula</li> <li> Una letra Minúscula</li> <li> Un número</li></ul>"), eMessage.Alerta, "", true);
                    return false;
                }
            }
            if (ddlRol.SelectedIndex == 0)
            {
                Mensaje("Seleccione el Rol del usuario", eMessage.Alerta);
                return false;
            }

            return true;
        }
        private void Guardar()
        {
            try
            {
                int IdUsuarioSistema = (int)General.ValidarEnteros(Session["IdUsuarioGl"]); 

                if (!(IdUsuarioSistema > 0))
                {
                    Mensaje("Datos del Usuario de sistema no encontrados", eMessage.Alerta);
                    return;
                }

                int IdRegistro = (int)General.ValidarEnteros(HF_IdUsuario.Value);
                Usuarios User = new Usuarios();
                if (IdRegistro > 0)
                {
                    //Actualizando
                    if (validarActualizar(IdRegistro))
                    {
                        bool UpdatePassword = false;
                        User.IdUsuario = IdRegistro;
                        User.NombreCompleto = txtNombreCompleto.Text;
                        User.Correo = txtCorreo.Text;
                        User.UserName = txtLogin.Text;
                        if (!(string.IsNullOrEmpty(txtContraseña.Text) || string.IsNullOrWhiteSpace(txtContraseña.Text)))
                        {
                            User.Password = BL_Usuarios.Encrypt(txtContraseña.Text);
                            UpdatePassword = true;
                        }
                        User.IdRol = (int)General.ValidarEnteros(ddlRol.SelectedValue);
                        User.IdUsuarioActualiza = IdUsuarioSistema;
                        if (BL_Usuarios.Update(User, UpdatePassword))
                        {
                            ResetControles();
                            cargarGrid(true);
                            Mensaje("Registro Actualizado Correctamente", eMessage.Exito);
                            return;
                        }
                        Mensaje("El Registro no se Actualizo Correctamente", eMessage.Error);
                        return;
                    }
                    return;
                }
                //Insertar
                if (validarInsertar())
                {
                    User.NombreCompleto = txtNombreCompleto.Text;
                    User.Correo = txtCorreo.Text;
                    User.UserName = txtLogin.Text;
                    User.Password = BL_Usuarios.Encrypt(txtContraseña.Text);
                    User.IdRol = (int)General.ValidarEnteros(ddlRol.SelectedValue);
                    User.IdUsuarioRegistra = IdUsuarioSistema;

                    if (BL_Usuarios.Insert(User).IdUsuario > 0)
                    {
                        ResetControles();
                        cargarGrid(true);
                        Mensaje("Registro Guardardo Correctamente", eMessage.Exito);
                        return;
                    }
                    Mensaje("El Registro no se guardo Correctamente", eMessage.Error);
                    return;
                }
                //Mandar Mesaje operacion no realizada
                //Mensaje("No se realizó ninguna operación", eMessage.Error);
            }
            catch
            {
                Mensaje("Error al guardar el registro", eMessage.Error);
            }

        }
        private void Anular()
        {
            try
            {
                int IdUsuarioSistema = (int)General.ValidarEnteros(Session["IdUsuarioGl"]);

                if (!(IdUsuarioSistema > 0))
                {
                    Mensaje("Datos del Usuario de sistema no encontrados", eMessage.Alerta);
                    return;
                }

                int IdRegistro = (int)General.ValidarEnteros(HF_IdUsuario.Value);
                Usuarios User = new Usuarios();

                if (IdRegistro > 0)
                {
                    User.IdUsuario = IdRegistro;
                    User.IdUsuarioActualiza = IdUsuarioSistema;
                    if (BL_Usuarios.Delete(User))
                    {
                        ResetControles();
                        cargarGrid(true);
                        Mensaje("Registro anulado Correctamente", eMessage.Exito);
                        return;
                    }
                    Mensaje("Error al anular el registro", eMessage.Error);
                    return;
                }
                Mensaje("Asegurese de seleccionar un registro para anular", eMessage.Alerta);
            }
            catch
            {
                Mensaje("Error al anular el registro", eMessage.Error);
            }
        }
        private void Bloqueo()
        {
            try
            {
                int IdUsuarioSistema = (int)General.ValidarEnteros(Session["IdUsuarioGl"]);

                if (!(IdUsuarioSistema > 0))
                {
                    Mensaje("Datos del Usuario de sistema no encontrados", eMessage.Alerta);
                    return;
                }
                int IdRegistro = (int)General.ValidarEnteros(HF_IdUsuario.Value);
                bool Bloqueo = (lnkBloqueo.Text == "Desbloquear") ? false : true;

                if (BL_Usuarios.BloquearCuentaUsuario(IdRegistro, Bloqueo, IdUsuarioSistema))
                {
                    string Operacion = (Bloqueo) ? "Bloqueado" : "Desbloqueado";
                    cargarGrid();
                    ResetControles();
                    Mensaje($"Registro {Operacion} Correctamente", eMessage.Exito);
                    return;
                }
                Mensaje("Error al realizar la operación en el registro", eMessage.Error);
            }
            catch
            {
                Mensaje("Error al realizar la operación en el registro", eMessage.Error);
            }
        }
        private void cargarControles(int IdRegistro)
        {
            try
            {
                vUsuarios vUsuario = BL_Usuarios.vUsuario(IdRegistro);
                if (vUsuario == null)
                {
                    Mensaje("No se encontraron datos para el registro seleccionado", eMessage.Error);
                    return;
                }
                HF_IdUsuario.Value = vUsuario.IdUsuario.ToString();
                txtNombreCompleto.Text = vUsuario.NombreCompleto;
                txtCorreo.Text = vUsuario.Correo;
                txtLogin.Text = vUsuario.UserName;
                txtContraseña.Text = string.Empty;
                ddlRol.SelectedValue = vUsuario.IdRol.ToString();
                lnkBloqueo.Text = (vUsuario.Bloqueado) ? "Desbloquear" : "Bloquear";
            }
            catch
            {
                Mensaje("Error al Cargar los datos del registro", eMessage.Error);
            }
        }
        #endregion

        #region Evento de los Controles
        protected void lnkMostrarPassword_Click(object sender, EventArgs e)
        {
            if (txtContraseña.TextMode == TextBoxMode.SingleLine)
            {
                txtContraseña.TextMode = TextBoxMode.Password;
                iconoVerPassword.Attributes.Remove("fas fa-eye-slash");
                iconoVerPassword.Attributes.Add("class", "fas fa-eye");
                return;
            }
            txtContraseña.TextMode = TextBoxMode.SingleLine;
            iconoVerPassword.Attributes.Remove("fas fa-eye");
            iconoVerPassword.Attributes.Add("class", "fas fa-eye-slash");

        }
        protected void lnkVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Principal.aspx");
        }
        protected void lnkLimpiar_Click(object sender, EventArgs e)
        {
            ResetControles();
        }
        protected void lnkGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }
        protected void lnkAnular_Click(object sender, EventArgs e)
        {
            Anular();
        }
        protected void gridUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int RowIndex = gridUsuarios.SelectedRow.RowIndex;
                int IdRegistro = (int)General.ValidarEnteros(gridUsuarios.DataKeys[RowIndex]["IdUsuario"].ToString());
                if (!(IdRegistro > 0))
                {
                    Mensaje("El ID del registro seleccionado fue cero", eMessage.Error);
                    return;
                }
                HF_IdUsuario.Value = IdRegistro.ToString();
                cargarControles(IdRegistro);

            }
            catch
            {
                Mensaje("Error al seleccionar el registro", eMessage.Error);
            }
        }
        protected void gridUsuarios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridUsuarios.PageIndex = e.NewPageIndex;
            cargarGrid();
            ResetControles();
        }
        protected void lnkBloqueo_Click(object sender, EventArgs e)
        {
            Bloqueo();
        }
        #endregion


    }
}