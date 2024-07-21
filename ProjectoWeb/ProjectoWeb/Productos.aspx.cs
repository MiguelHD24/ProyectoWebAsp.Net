using BL;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static EL.Enum;
using Utilidades;

namespace ProjectoWeb
{
    public partial class Productos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidarSesion();
            if (!IsPostBack)
            {
                cargarGrid();
                cargarDDLCategoria();
                cargarDDLPresentacion();

            }

        }

        protected void gridArticulo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gridArticulo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

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
                gridArticulo.PageIndex = 0;
            }
            gridArticulo.DataSource = BL_Articulo.ListarArticulosGV();
            gridArticulo.DataBind();

        }
        private void cargarDDLCategoria()
        {
            try
            {
                ddlCategoria.Items.Clear();
                ddlCategoria.Items.Insert(0, new ListItem("--Seleccione--"));
                ddlCategoria.DataSource = BL_Categoria.Mostrar();
                ddlCategoria.DataValueField = "idcategoria";
                ddlCategoria.DataTextField = "nom_categoria";
                ddlCategoria.DataBind();
            }
            catch
            {
                Mensaje("Error al cargar las Categorias", eMessage.Error);
            }
        }
        private void cargarDDLPresentacion()
        {
            try
            {
                ddlPresentacion.Items.Clear();
                ddlPresentacion.Items.Insert(0, new ListItem("--Seleccione--"));
                ddlPresentacion.DataSource = BL_Presentacion.Mostrar();
                ddlPresentacion.DataValueField = "idpresentacion";
                ddlPresentacion.DataTextField = "nom_presentacion";
                ddlPresentacion.DataBind();
            }
            catch
            {
                Mensaje("Error al cargar las Presentacion", eMessage.Error);
            }
        }
        private void ResetControles()
        {
            txtProducto.Text = string.Empty;
            txtCodigo.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            ddlCategoria.SelectedIndex = 0;
            ddlPresentacion.SelectedIndex = 0;
            HF_IdArticulo.Value = "0";
            lnkBloqueo.Text = "Bloqueo";
        }

        protected void lnkVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Principal.aspx");
        }

        protected void lnkLimpiar_Click(object sender, EventArgs e)
        {

        }


        protected void lnkGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                int IdUsuarioSistema = (int)General.ValidarEnteros(Session["IdUsuarioGl"]);

                if (!(IdUsuarioSistema > 0))
                {
                    Mensaje("Datos del Usuario de sistema no encontrados", eMessage.Alerta);
                    return;
                }

                int IdRegistro = (int)General.ValidarEnteros(HF_IdArticulo.Value);
                articulo Articulo = new articulo();
                if (IdRegistro > 0)
                {
                    //Actualizando
                    if (validarActualizar(IdRegistro))
                    {

                        Articulo.idarticulo = IdRegistro;
                        Articulo.codigo = txtCodigo.Text;
                        Articulo.nom_articulo = txtProducto.Text;
                        Articulo.descripcion = txtDescripcion.Text;
                        Articulo.idcategoria = (int)General.ValidarEnteros(ddlCategoria.SelectedValue);
                        Articulo.idpresentacion = (int)General.ValidarEnteros(ddlPresentacion.SelectedValue);
                        if (BL_Articulo.UpdateArticulo(Articulo)==true)
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
                else if (validarInsertar())
                {
                    
                    Articulo.codigo = txtCodigo.Text;
                    Articulo.nom_articulo = txtProducto.Text;
                    Articulo.descripcion = txtDescripcion.Text;
                     
                    Articulo.idcategoria = (int)General.ValidarEnteros(ddlCategoria.SelectedValue);
                    Articulo.idpresentacion = (int)General.ValidarEnteros(ddlPresentacion.SelectedValue);

                    if (BL_Articulo.InsertArticuloEF(Articulo)>0)
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
        private bool validarInsertar()
        {
            if (string.IsNullOrEmpty(txtCodigo.Text) || string.IsNullOrWhiteSpace(txtCodigo.Text))
            {
                Mensaje("Ingrese el Codigo del producto", eMessage.Alerta);
                return false;
            }
            if (string.IsNullOrEmpty(txtProducto.Text) || string.IsNullOrWhiteSpace(txtProducto.Text))
            {
                Mensaje("Ingrese el nombre del Articulo", eMessage.Alerta);
                return false;
            }
            if (ddlCategoria.SelectedIndex == 0)
            {
                Mensaje("Seleccione selecciones la categoria del Articulo", eMessage.Alerta);
                return false;
            }
            if (ddlPresentacion.SelectedIndex == 0)
            {
                Mensaje("Seleccione la presentacion del articulo", eMessage.Alerta);
                return false;
            }



            return true;
        }
        private bool validarActualizar(int IdRegistro)
        {
            if (string.IsNullOrEmpty(txtCodigo.Text) || string.IsNullOrWhiteSpace(txtCodigo.Text))
            {
                Mensaje("Ingrese el Codigo del producto", eMessage.Alerta);
                return false;
            }
            if (string.IsNullOrEmpty(txtProducto.Text) || string.IsNullOrWhiteSpace(txtProducto.Text))
            {
                Mensaje("Ingrese el nombre del Articulo", eMessage.Alerta);
                return false;
            }
            if (ddlCategoria.SelectedIndex == 0)
            {
                Mensaje("Seleccione selecciones la categoria del Articulo", eMessage.Alerta);
                return false;
            }
            if (ddlPresentacion.SelectedIndex == 0)
            {
                Mensaje("Seleccione la presentacion del articulo", eMessage.Alerta);
                return false;
            }
            
            

            return true;
        }
        protected void lnkAnular_Click(object sender, EventArgs e)
        {
            //Anular();
        }

        protected void lnkBloqueo_Click(object sender, EventArgs e)
        {

        }
    }
}