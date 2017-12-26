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

using Negocio;
using Platinium.Web;
using Platinium.Negocio;
using System.Drawing;
using System.Text;
using Web;
using Atom.ClientWeb;

namespace Platinium.Web
{
    public partial class Amortizacao : PaginaCadastroBase
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.PaginaSegura = false;
                this.TituloPagina = "Amortização";
                this.Controladora = new ManterAmortizacao();
                this.grdListagem.SortColumnName = "Codigo";
                base.Page_Load(sender, e);
            }
            FocoInicial = txtCodigo;
        }

    }
}