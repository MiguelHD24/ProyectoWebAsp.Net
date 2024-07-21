using BL;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilidades;
using static EL.Enum;

namespace ProjectoWeb
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidarSesion();
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
                Mensaje("Inicie Sesión Nuevamente", eMessage.Info, "Datos de Sesión Incompletos", false, true, true, "/Login.aspx", false);
            }
        }
        private void VerificarPermisosFormularios(List<RolFormularios> RolFormularios)
        {
            
            lnkVentas.Visible = false;
            lnkIngreso.Visible = false;
            lnkCliente.Visible = false;
            lnkAdministracionUsuarios.Visible = false;

            foreach (var RolFormulario in RolFormularios)
            {
                if (RolFormulario.IdFormulario == (int)eFormulario.AdministracionUsuarios)
                {
                    lnkAdministracionUsuarios.Visible = true;
                }
                if (RolFormulario.IdFormulario == (int)eFormulario.Formulario_1)
                {
                    lnkVentas.Visible = true;
                }
                if (RolFormulario.IdFormulario == (int)eFormulario.Formulario_2)
                {
                    lnkIngreso.Visible = true;
                }
                if (RolFormulario.IdFormulario == (int)eFormulario.Formulario_3)
                {
                    lnkCliente.Visible = true;
                }
            }

        }

        private bool ValidarSesion()
        {
            try
            {
                List<RolFormularios> FormulariosUser = (List<RolFormularios>)Session["RolFormulariosGl"];

                if (FormulariosUser == null)
                {
                    AbandonarSesion(false);
                    return false;
                }

                if (!(FormulariosUser.Count > 0))
                {
                    AbandonarSesion();
                    return false;
                }

                VerificarPermisosFormularios(FormulariosUser);
                return true;
            }
            catch
            {
                AbandonarSesion();
                return false;
            }
        }
        #endregion
        #region Eventos de los Controles

    

        protected void lnkNombreSitio_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Principal.aspx");
        }

        protected void lnkInicio_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Principal.aspx");
        }
        protected void lnkVentas_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Ventas.aspx");
        }

        protected void lnkIngreso_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Ingreso.aspx");
        }

        protected void lnkCliente_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Clientes.aspx");
        }

        protected void lnkAdministracionUsuarios_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdministracionUsuarios.aspx");
        }
        #endregion
        protected void lnkSalir_Click(object sender, EventArgs e)
        {
            AbandonarSesion(false);
            Response.Redirect("~/Acceso.aspx");
        }

       
    }
}