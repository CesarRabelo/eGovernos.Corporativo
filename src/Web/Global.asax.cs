using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

using Negocio;

namespace Web
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            Application["num_usuarios"] = 0;
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Application["num_usuarios"] = Convert.ToInt32(Application["num_usuarios"]) + 1;
            //Sistema oSistema = new Sistema(Request.QueryString["p"]);
            //Geral.RegisterLogin(oSistema.UsuarioGuardiao.Id.ToString());
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {
            Application["num_usuarios"] = Convert.ToInt32(Application["num_usuarios"]) - 1;
            //Geral.RegisterLogout(Convert.ToString(Session["isn_usuario"]));
            //Response.Redirect(System.Configuration.ConfigurationManager.AppSettings["Guardiao"].ToString());
        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}