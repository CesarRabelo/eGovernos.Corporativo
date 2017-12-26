using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;
using System.Text;
using Platinium.Negocio;
using Platinium.Web;
using Negocio;
using Web;
using Atom.ClientWeb;

namespace Platinium.Web
{
    public partial class AnoLei : PaginaCadastroBase
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.TituloPagina = "Leis por Ano Elaboração";
                this.Controladora = new ManterAnoLei();
                this.grdListagem.SortColumnName = "AnoElaboracao";
                base.Page_Load(sender, e);
            }
            FocoInicial = txtAnoElaboracao;
        }
    }
}