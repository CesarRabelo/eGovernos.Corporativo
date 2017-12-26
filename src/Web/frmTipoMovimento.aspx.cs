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
using Web;
using Platinium.Web;
using Platinium.Negocio;
using System.Drawing;
using System.Text;
using Atom.ClientWeb;

namespace Platinium.Web
{
    public partial class TipoMovimento : PaginaCadastroBase
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.PaginaSegura = false;
                this.TituloPagina = "Tipo de Movimento";
                this.Controladora = new ManterTipoMovimento();
                this.grdListagem.SortColumnName = "Codigo";
                base.Page_Load(sender, e);
            }
            FocoInicial = txtCodigo;

        }

        protected override void btnNovo_Click(object sender, EventArgs e)
        {
            base.btnNovo_Click(sender, e);
            chkAtivo.Checked = true;
        }
    }
}