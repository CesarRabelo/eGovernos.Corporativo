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
    public partial class UnidadeGestora : PaginaCadastroBase
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.TituloPagina = "Unidade Gestora";
                this.Controladora = new ManterUnidadeGestora();
                this.grdListagem.SortColumnName = "Codigo";
                ddlOrgao.DataBind(new Listas().Orgao);
                ddlBuscaOrgao.DataBind(new Listas().Orgao);
                PaginaSegura = false;
                base.Page_Load(sender, e);
            }
            FocoInicial = txtCodigo;
        }

        private void PopularGridUnidadeOrcamentaria(int id)
        {
            if (id > 0)
                ucUnidadeGestoraOrcamentaria1.IdPai = id;
            else
                ucUnidadeGestoraOrcamentaria1.IdPai = null;

            ucUnidadeGestoraOrcamentaria1.PopularGridView();
        }

        protected override void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = ((ManterUnidadeGestora)Controladora).SalvarRetornandoId(pnlManutencao.GetFormData());
                if (ModoPagina == ModosPagina.Inserir)
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "QuickMessage", "ExibirMensagem('Registro <b>inserido</b> com sucesso.');", true);
                else
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "QuickMessage", "ExibirMensagem('Registro <b>atualizado</b> com sucesso.');", true);
                this.Selecionar(id);
                base.btnSalvar_Click(sender, e);
                chkAtivo.Checked = true;
            }
            catch (Exception ex)
            {
                this.ExibirExcecao(ex);
            }
        }

        protected override void SetarModoPagina(PaginaCadastroBase.ModosPagina modo)
        {
            base.SetarModoPagina(modo);
            if (modo == ModosPagina.Inserir)
            {
                PopularGridUnidadeOrcamentaria(0);
            }
        }

        protected override void Selecionar(int id)
        {
            base.Selecionar(id);
            PopularGridUnidadeOrcamentaria(id);
        }

        protected override void btnNovo_Click(object sender, EventArgs e)
        {

            base.btnNovo_Click(sender, e);
            chkAtivo.Checked = true;
        }

    }
}