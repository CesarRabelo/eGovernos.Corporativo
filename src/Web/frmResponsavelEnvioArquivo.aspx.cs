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
    public partial class ResponsavelEnvioArquivo : PaginaCadastroBase
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.TituloPagina = "Responsável de Envio";
                this.Controladora = new ManterResponsavelEnvioArquivo();
                this.grdListagem.SortColumnName = "DscNomeGestor";
                this.PaginaSegura = false;
                this.ddlCargo.DataBind(new Listas().Cargo);
                base.Page_Load(sender, e);
            }
            FocoInicial = txtNomeGestor;
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