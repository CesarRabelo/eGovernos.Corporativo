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
    public partial class frmFolhaPagamento : PaginaCadastroBase
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.TituloPagina = "Folha de Pagamento";
                this.Controladora = new ManterFolhaPagamento();
                this.grdListagem.SortColumnName = "DscOrgao";
                ddlUnidadeOrcamentaria.DataBind(Listas.UnidadeOrcamentaria);
                this.PaginaSegura = false;
                ddlOrgao.DataBind(Listas.Orgao);
                ddlTipoFolha.DataBind(Listas.TipoFolhaPagamento);
                base.Page_Load(sender, e);
            }
            FocoInicial = ddlUnidadeOrcamentaria;
        }

        protected void ddlOrgao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ddlOrgao.SelectedItem.Value))
                ddlUnidadeOrcamentaria.DataBind(Listas.UnidadeOrcamentariaByIdOrgao(ddlOrgao.SelectedItem.Value));
        }
    }
}