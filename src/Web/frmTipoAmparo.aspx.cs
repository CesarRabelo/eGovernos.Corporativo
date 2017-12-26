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
using Platinium.Negocio;
using System.Drawing;
using System.Text;
using Web;
using Atom.ClientWeb;

namespace Platinium.Web
{
    public partial class frmTipoAmparo : PaginaCadastroBase
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PaginaSegura = false;
                this.TituloPagina = "Tipo de Amparo";
                this.Controladora = new ManterTipoAmparo();
                this.grdListagem.SortColumnName = "Codigo";
                this.PaginaSegura = false;
                base.Page_Load(sender, e);
            }
            FocoInicial = txtCodigo;
        }

        protected override void btnNovo_Click(object sender, EventArgs e)
        {
            base.btnNovo_Click(sender, e);
            chkAtivo.Checked = true;
        }

        protected override void btnSalvar_Click(object sender, EventArgs e)
        {

            base.btnSalvar_Click(sender, e);
            chkAtivo.Checked = true;
        }

    }
}