using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Atom.Client.Classes;
using System.Configuration;
using Platinium.Negocio;
using Atom.ClientNegocio;

namespace Titanium.Web
{
    public partial class Principal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    Sistema oSistema = null;
                    string urlService = string.Empty;

                    if (ConfigurationManager.AppSettings["AtomService"] != null)
                        urlService = ConfigurationManager.AppSettings["AtomService"];

                    if (Request.QueryString["p"] != null)
                    {
                        oSistema = new Sistema(Request.QueryString["p"], urlService);
                        Contexto.SetarSeguranca(oSistema);

                        Pro.Dal.Session.SetUserAccess(Contexto.Seguranca.UsuarioID, null);
                        Response.Redirect("Default.aspx", false);
                    }
                }
                catch (Exception ex)
                {
                    Session["Exception"] = ex;
                    //Response.Redirect("Index.aspx", false);
                }
                //ManterContratoLocacao cl = new ManterContratoLocacao();
                //DataTable dt = cl.ListaImoveisReajuste();
                //if (dt.Rows.Count > 0)
                //{
                //    pnlListagem.Visible = true;
                //    grdListagem.DataSource = dt;
                //    grdListagem.DataBind();
                //}
                //else
                //    pnlListagem.Visible = false;
            }
        }
    }
}