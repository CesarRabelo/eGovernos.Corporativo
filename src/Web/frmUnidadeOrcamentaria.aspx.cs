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
using Web;
using Atom.ClientWeb;

namespace Platinium.Web
{
    public partial class UnidadeOrcamentaria : PaginaCadastroBase
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.PaginaSegura = false;
                this.TituloPagina = "Unidade Orçamentária";
                this.Controladora = new ManterUnidadeOrcamentaria();
                this.grdListagem.SortColumnName = "CodEntidade";
                ddlSecretaria.DataBind(new Listas().Secretaria);
                ddlPoder.DataBind(new Listas().Poder);
                ddlTipo.DataBind(new Listas().TipoEntidade);
                ddlTipoAdministracao.DataBind(new Listas().TipoAdministracao);
                ddlBuscaOrgao.DataBind(new Listas().Orgao);
                ddlBuscaPoder.DataBind(new Listas().Poder);
                ddlBuscaSecretaria.DataBind(new Listas().Secretaria);
                ddlBuscaTipo.DataBind(new Listas().TipoEntidade2); 
                base.Page_Load(sender, e);
            }
            FocoInicial = txtCodigo;
        }

        protected override void btnNovo_Click(object sender, EventArgs e)
        {
            ddlOrgao.Items.Clear();
            base.btnNovo_Click(sender, e);
            PopularGridLei(0);
            chkAtivo.Checked = true;
            txtDataCriado.Visible = false;
            txtDataDesativado.Visible = false;
        }

        protected override void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = ((ManterUnidadeOrcamentaria)Controladora).SalvarRetornandoId(pnlManutencao.GetFormData());
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

            base.btnSalvar_Click(sender, e);
            chkAtivo.Checked = true;
        }

        protected void ddlSecretaria_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlPoder.SelectedIndex = -1;
            ddlOrgao.SelectedIndex = -1;
            if (!string.IsNullOrEmpty(ddlSecretaria.SelectedItem.Value))
            {
                ddlPoder.Items.FindByValue(new Listas().LocalizarPoderByIdSecretaria(ddlSecretaria.SelectedItem.Value)).Selected = true;
                ddlOrgao.DataBind(new Listas().OrgaosByIdSecretaria(ddlSecretaria.SelectedItem.Value));
            }

        }

        protected override void Selecionar(int id)
        {
            base.Selecionar(id);
            Limpar();
            PopularGridLei(id);
            txtDataCriado.Visible = true;
            txtDataDesativado.Visible = true;
            SetaSecretaria(((ManterUnidadeOrcamentaria)Controladora).SecretariaID(id));
            ddlOrgao.Items.FindByValue(Convert.ToString(((ManterUnidadeOrcamentaria)Controladora).OrgaoID(id))).Selected = true;
            ddlOrgao_SelectedIndexChanged(null, null);
        }

        private void SetaSecretaria(int ID)
        {
            ddlSecretaria.SelectedIndex = -1;
            ddlSecretaria.DataBind(new Listas().Secretaria);
            ddlSecretaria.Items.FindByValue(Convert.ToString(ID)).Selected = true;
            ddlSecretaria_SelectedIndexChanged(null, null);
            //ddlOrgao_SelectedIndexChanged(null, null);
        }

        private void Limpar()
        {
            ddlOrgao.Items.Clear();
            ddlSecretaria.Items.Clear();

        }
        
                
        protected void ddlOrgao_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlTipo.SelectedIndex = -1;

            if (!string.IsNullOrEmpty(ddlOrgao.SelectedItem.Value))
            {
                ddlTipo.Items.FindByValue(new Listas().LocalizarTipoByIdOrgao(ddlOrgao.SelectedItem.Value)).Selected = true;
            }
        }

        protected void ddlBuscaOrgao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ddlBuscaOrgao.SelectedItem.Value))
            {
                base.btnBuscar_Click(sender, e);
            }
        }
        private void PopularGridLei(int id)
        {
            if (id > 0)
                ucEntidadeLei1.IdPai = id;
            else
                ucEntidadeLei1.IdPai = null;

            ucEntidadeLei1.PopularGridView();
        }
    }
}