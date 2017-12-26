using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.Drawing;
using System.Text;

using Negocio;
using Web;
using Titanium.Web;
using Platinium.Negocio;
using Atom.ClientWeb;

namespace Titanium.Web
{
    public partial class frmMapa : PaginaBase
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    if (Request.QueryString["idEndereco"] != null)
                    {
                        this.Controladora = new ManterEndereco();
                        string coordenadas = ((ManterEndereco)this.Controladora).Coordenadas(int.Parse(Request.QueryString["idEndereco"]));

                        if (coordenadas != null)
                        {
                            Response.Redirect("frmMapa.aspx?coordenadas=" + coordenadas);
                        }
                        else
                        {
                            string sEnderecoCompleto = ((ManterEndereco)this.Controladora).EnderecoCompletoExibicao(int.Parse(Request.QueryString["idEndereco"]));
                            sEnderecoCompleto = normatizarString(sEnderecoCompleto);
                            Response.Redirect("frmMapa.aspx?logradouro=" + sEnderecoCompleto);
                        }
                    }
                }
                catch (Exception ex)
                {
                    ExibirExcecao(ex);
                }
            }                        
        }

        public string normatizarString(string str)
        {
            return str.Replace(" ", "%20").Replace(".", "%2E").Replace(",", "%20").Replace(",", "%20").Replace("À", "%C0").Replace("Á", "%C1").Replace("Â", "%C2").Replace("Ã", "%C3")
                .Replace("Ç", "%C7").Replace("É", "%C9").Replace("Ê", "%CA").Replace("Í", "%CD").Replace("Ó", "%D3").Replace("Ô", "%D4").Replace("Õ", "%D6").Replace("Ú", "%DA")
                .Replace("à", "%E0").Replace("á", "%E1").Replace("â", "%E2").Replace("ã", "%E3").Replace("ç", "%E7").Replace("é", "%E9").Replace("ê", "%EA").Replace("í", "%ED")
                .Replace("ó", "%F3").Replace("ô", "%F4").Replace("õ", "%F5").Replace("ú", "%FA").Replace("-", "%2D");
        }
    }
}