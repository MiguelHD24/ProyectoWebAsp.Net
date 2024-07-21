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
    public partial class Acceso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
        private bool ValidarAcceso()
        {
            if (string.IsNullOrEmpty(txtUsuario.Text) || string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                Mensaje("Ingrese el usuario", eMessage.Alerta);
                return false;
            }

            if (string.IsNullOrEmpty(txtPassword.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                Mensaje("Ingrese la contraseña", eMessage.Alerta);
                return false;
            }
            if (!BL_Usuarios.ExisteUserName(txtUsuario.Text))
            {
                Mensaje("Credenciales incorrectas", eMessage.Alerta);
                return false;
            }
            if (BL_Usuarios.VerificarCuentaBloqueada(txtUsuario.Text))
            {
                Mensaje("Su cuenta ha sido bloqueada por multiples intentos fallidos de iniciar sesión", eMessage.Error);
                return false;
            }
            byte[] Password = BL_Usuarios.Encrypt(txtPassword.Text);
            if (!BL_Usuarios.ValidarCredenciales(txtUsuario.Text, Password))
            {
                Usuarios User = BL_Usuarios.ExisteUsuario_x_UserName(txtUsuario.Text);
                if (BL_Usuarios.CatidadIntentosFallidos(txtUsuario.Text) >= 2)
                {
                    BL_Usuarios.BloquearCuentaUsuario(User.IdUsuario, true, User.IdUsuario);
                    Mensaje(Justify("La cuenta fue bloqueada por multiples intentos fallidos de iniciar sesión. Por favor comuniquese con un administrador del sistema."), eMessage.Error, "", true);
                }
                if (User != null)
                {
                    BL_Usuarios.SumarIntentosFallido(User.IdUsuario);
                }
                Mensaje(Justify("Credenciales incorrectas, si supera 3 intentos fallidos de inicio de sesión, su cuenta será bloqueada"), eMessage.Alerta, "", true);
                return false;
            }

            Usuarios UsuarioAutenticado = BL_Usuarios.ExisteUsuario_x_UserName(txtUsuario.Text);
            if (UsuarioAutenticado != null)
            {
                if (UsuarioAutenticado.IntentosFallidos > 0)
                {
                    BL_Usuarios.RestablecerIntentosFallido(UsuarioAutenticado.IdUsuario, UsuarioAutenticado.IdUsuario);
                }

                if (!(UsuarioAutenticado.IdRol > 0))
                {
                    Mensaje("Estimado usuario usted no tiene ul rol asignado en el sistema, por favor comuniquese con un administrador.", eMessage.Error);
                    return false;
                }

                Session["IdUsuarioGl"] = UsuarioAutenticado.IdUsuario;
                Session["IdRolGl"] = UsuarioAutenticado.IdRol;
                //Redireccionar
                Response.Redirect("~/Principal.aspx");
            }
            return true;
        }
        #endregion

        #region Evento de los Controles
        protected void BtnIngresar_Click(object sender, EventArgs e)
        {
            if (ValidarAcceso())
            {

            }
        }
        #endregion
    }
}
    
