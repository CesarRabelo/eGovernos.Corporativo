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
    public partial class Produto : PaginaCadastroBase
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.TituloPagina = "Produto";
                this.Controladora = new ManterProduto();
                this.grdListagem.SortColumnName = "Codigo";
                ddlUnidade.DataBind(new Listas().Unidade);
                ddlBuscaUnidade.DataBind(new Listas().Unidade);
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