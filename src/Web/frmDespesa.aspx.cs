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
using System.Collections.Generic;
using Negocio;
using Web;
using Platinium.Web;
using Platinium.Negocio;
using Pro.Utils;
using Atom.ClientWeb;

namespace Platinium.Web
{
    public partial class Despesa : PaginaCadastroBase
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.TituloPagina = "Natureza da Despesa";
                this.Controladora = new ManterDespesa();
                this.grdListagem.SortColumnName = "Codigo";
                ddlCatEconomica.DataBind(new Listas().CatEconomicaDespesa);
                ddlGrupoDespesa.DataBind(new Listas().GrupoDespesa);
                ddlBuscaCategoria.DataBind(new Listas().CatEconomicaDespesa);
                ddlBuscaGrupoDespesa.DataBind(new Listas().GrupoDespesa);
                ddlBuscaModalidade.DataBind(new Listas().ModalidadeAplicacao);
                ddlElementoDespesa.DataBind(new Listas().ElementoDespesa);
                ddlModalidadeAplicacao.DataBind(new Listas().ModalidadeAplicacao);
                base.Page_Load(sender, e);
            }
            FocoInicial = txtCodigo;

        }
        protected override void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCod1.Text != "")
                    txtCodigo.Text = txtCod1.Text + txtCod2.Text + txtCod3.Text + txtCod4.Text + txtCod5.Text;
                else
                    txtCodigo.Text = 0 + txtCod2.Text + txtCod3.Text + txtCod4.Text + txtCod5.Text;

                base.btnSalvar_Click(sender, e);
                chkAtivo.Checked = true;
            }
            catch (Exception ex)
            {
                ExibirExcecao(ex);
            }
        }

        protected override void btnNovo_Click(object sender, EventArgs e)
        {
            base.btnNovo_Click(sender, e);
            chkAtivo.Checked = true;
        }

        protected override void SetarModoPagina(PaginaCadastroBase.ModosPagina modo)
        {
            base.SetarModoPagina(modo);
            if (modo == ModosPagina.Inserir)
            {
                PopularGridListagemItensNovo();
                btnAdicionar.Enabled = false;
            }
            if (modo == ModosPagina.Alterar)
            {
                btnAdicionar.Enabled = true;
            }
        }

        protected override void Selecionar(int id)
        {
            base.Selecionar(id);
            txtCod1.Text = txtCodigo.Text.Substring(0, 1);
            txtCod2.Text = txtCodigo.Text.Substring(1, 1);
            txtCod3.Text = txtCodigo.Text.Substring(2, 2);
            txtCod4.Text = txtCodigo.Text.Substring(4, 2);
            txtCod5.Text = txtCodigo.Text.Substring(6, 2);
            txtID.Text = txtCod1.Text + txtCod2.Text + txtCod3.Text + txtCod4.Text + txtCod5.Text;
            txtIdDespesaSelecionada.Text = Convert.ToString(id);
            PopularGridListagemItens();
        }

        protected void ddlCatEconomica_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            txtCod1.Text = "";
            if (ddlCatEconomica.SelectedIndex != 0)
            {
                string cod = ((ManterDespesa)Controladora).GetCodCatEconomica(ddlCatEconomica.SelectedValue);
                txtCod1.Text = cod;
            }
        }

        protected void ddlGrupoDespesa_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            txtCod2.Text = "";
            if (ddlGrupoDespesa.SelectedIndex != 0)
            {
                string cod = ((ManterDespesa)Controladora).GetCodGrupoDespesa(ddlGrupoDespesa.SelectedValue);
                txtCod2.Text = cod;
            }
        }

        protected void ddlModalidadeAplicacao_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            txtCod3.Text = "";
            if (ddlModalidadeAplicacao.SelectedIndex != 0)
            {
                string cod = ((ManterDespesa)Controladora).GetCodModAplicacao(ddlModalidadeAplicacao.SelectedValue);
                txtCod3.Text = cod;
            }
        }

        protected void ddlElementoDespesa_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            txtCod4.Text = "";
            txtDescricao.Text = "";
            if (ddlElementoDespesa.SelectedIndex != 0)
            {
                txtDescricao.Text = ddlElementoDespesa.SelectedItem.Text;
                string cod = ((ManterDespesa)Controladora).GetCodElementoDespesa(ddlElementoDespesa.SelectedValue);
                txtCod4.Text = cod;
            }
        }

        protected void btrPreencherCombos_Click(object sender, EventArgs e)
        {
            string codigo = txtCod1.Text;
            string codigo2 = txtCod2.Text;
            string codigo3 = txtCod3.Text;
            string codigo4 = txtCod4.Text;
            List<string> msg = new List<string>();

            CampoNuloOuInvalidoException ex = new CampoNuloOuInvalidoException();
            ddlCatEconomica.SelectedIndex = -1;
            string cod1 = new Listas().CategoriaEconomicaDespesabyCodigo(codigo);
            if (cod1 != "0")
                ddlCatEconomica.Items.FindByValue(cod1).Selected = true;
            else
                ex.Mensagens.Add("codigo1", string.Format("<b>Categoria Econômica de Despesa</b> não localizada com o código [{0}].", codigo));

            ddlGrupoDespesa.SelectedIndex = -1;
            string cod2 = new Listas().GrupoDespesabyCodigo(codigo2);
            if (cod2 != "0")
                ddlGrupoDespesa.Items.FindByValue(cod2).Selected = true;
            else
                ex.Mensagens.Add("codigo2", string.Format("<b>Grupo de Despesa</b> não localizado com o código [{0}].", codigo2));

            ddlModalidadeAplicacao.SelectedIndex = -1;
            string cod3 = new Listas().ModalidadebyCodigo(codigo3);
            if (cod3 != "0")
                ddlModalidadeAplicacao.Items.FindByValue(cod3).Selected = true;
            else
                ex.Mensagens.Add("codigo3", string.Format("<b>Modalidade de aplicação</b> não localizada com o código [{0}].", codigo3));

            ddlElementoDespesa.SelectedIndex = -1;
            string cod4 = new Listas().ElementoDespesabyCodigo(codigo4);
            if (cod4 != "0")
            {
                ddlElementoDespesa.Items.FindByValue(cod4).Selected = true;
                txtDescricao.Text = ddlElementoDespesa.SelectedItem.Text;
            }
            else
                ex.Mensagens.Add("codigo4", string.Format("<b>Elemento de Despesa</b> não localizado com o código [{0}].", codigo4));

            if (ex.Mensagens.Count > 0)
                ExibirExcecao(ex);
        }

        private void PopularGridListagemItensNovo()
        {
            DataTable dt = null;
            grdListagemItens.DataBind(dt);
        }

        private void PopularGridListagemItens()
        {
            DataTable dt = ((ManterDespesa)Controladora).getItensPorDespesa(txtIdDespesaSelecionada.Text);
            grdListagemItens.DataBind(dt);
        }

        private void PopularGridCadastroItens(Dictionary<string, object> filtros)
        {
            DataTable dtItens = ((ManterDespesa)Controladora).getItens(filtros);
            DataTable dtItensDoAgente = ((ManterDespesa)Controladora).getItensDoAgente(txtIdDespesaSelecionada.Text);
            DataTable dtItensSemAgente = ((ManterDespesa)Controladora).getItensSemAgente(dtItens, dtItensDoAgente);

            grdCadastroItens.DataBind(dtItensSemAgente);
        }

        protected void btnAdicionar_OnClick(object sender, EventArgs e)
        {
            pnlConsultaCadastroItens.Clear();
            txtBuscaCodigo.Text = "";
            txtBuscaDescricao.Text = "";
            foreach (int id in grdCadastroItens.SelectedRows)
            {
                grdCadastroItens.SelectedIndex = -1;
            }
            mpeAdicionarItem.Show();
            PopularGridCadastroItens(pnlConsultaCadastroItens.GetFormData());
        }

        public void btnExcluir_OnClick(object sender, EventArgs e)
        {
            ((ManterDespesa)Controladora).excluirItem(txtIdExclusao.Text);
        }

        public void grdListagemItens_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index;

            if (e.CommandName.ToUpper() == "EXCLUIRITEM")
            {
                index = ((GridViewRow)((ImageButton)e.CommandSource).Parent.Parent).RowIndex;
                txtIdExclusao.Text = grdListagemItens.DataKeys[index].Value.ToString();
                btnExcluir_OnClick(null, null);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "QuickMessage", "ExibirMensagem('Ítem <b>excluído</b> com sucesso.');", true);
                PopularGridListagemItens();
            }
        }

        protected void btnSalvarItens_OnClick(Object sender, EventArgs e)
        {
            try
            {
                List<string> ListaIds = new List<string>();
                foreach (int id in grdCadastroItens.SelectedRows)
                {
                    ListaIds.Add(grdCadastroItens.DataKeys[id].Value.ToString());
                }
                if (ListaIds.Count > 0)
                {
                    ((ManterDespesa)Controladora).SalvarItensDespesa(ListaIds, txtID.Text, txtIdDespesaSelecionada.Text);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "QuickMessage", "ExibirMensagem('Ítem(ns) <b>inserido(s)</b> com sucesso.');", true);
                    PopularGridListagemItens();
                }
                if (ListaIds.Count == 0)
                {
                    ExibirAlerta(TiposMensagem.Alerta, "Atenção", "É necessário selecionar um ítem para salvar!");
                    mpeAdicionarItem.Show();
                }
            }
            catch (Exception ex)
            {
                this.ExibirExcecao(ex);
                mpeAdicionarItem.Show();
            }
        }

        protected void btnFiltrar_OnClick(object sender, EventArgs e)
        {
            PopularGridCadastroItens(pnlConsultaCadastroItens.GetFormData());
            mpeAdicionarItem.Show();
        }

        protected void grdListagemUC_Sorting(object sender, GridViewSortEventArgs e)
        {
        }
    }
}