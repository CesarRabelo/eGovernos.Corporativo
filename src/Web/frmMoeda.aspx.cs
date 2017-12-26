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
    public partial class Moeda : PaginaCadastroBase
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PaginaSegura = false;
                this.TituloPagina = "Moeda";
                this.Controladora = new ManterMoeda();
                this.grdListagem.SortColumnName = "DescricaoCifra";
                base.Page_Load(sender, e);
            }
            FocoInicial = txtDescricaoCifra;
        }
    }
}