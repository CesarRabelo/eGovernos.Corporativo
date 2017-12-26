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
using Negocio;
using Platinium.Negocio;
using Platinium.Web;
using Web;
using Atom.ClientWeb;

namespace Platinium.Web
{
    public partial class UnidadeGestoraGestor : PaginaCadastroBase
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.TituloPagina = "Gestores";
                this.Controladora = new ManterUnidadeGestoraGestor();
                this.grdListagem.SortColumnName = "DscNome";
                PaginaSegura = false;
                ddlUnidadeGestora.DataBind(new Listas().UnidadeGestora);
                ddlGestor.DataBind(new Listas().Pessoal);
                ddlBuscaOrgao.DataBind(new Listas().Orgao);
                ddlBuscaUnidadeGestora.DataBind(new Listas().UnidadeGestora);
                base.Page_Load(sender, e);
            }
            FocoInicial = ddlUnidadeGestora;
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