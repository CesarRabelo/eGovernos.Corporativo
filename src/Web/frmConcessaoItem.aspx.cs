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
using Web;
using Platinium.Web;
using Platinium.Negocio;
using System.Collections.Generic;
using Pro.Utils;
using Atom.ClientWeb;

namespace Platinium.Web
{
    public partial class frmConcessaoItem : PaginaCadastroBase
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.TituloPagina = "Concessão de Itens";
                this.Controladora = new ManterConcessaoItem();
                this.PaginaSegura = false;
                ddlItemRemuneratorio.DataBind(Listas.ItemRemuneratorio);
                ddlBuscaItemRemuneratorio.DataBind(Listas.ItemRemuneratorio);
                ddlTipoExpediente.DataBind(Listas.TipoExpediente);
                ddlTipoExpedienteSuspensao.DataBind(Listas.TipoExpediente);
                ddlBuscarOrgao.DataBind(Listas.Orgao);
                ddlBuscarUnidadeOrcamentaria.DataBind(Listas.UnidadeOrcamentaria);
                ddlBuscarOrgao2.DataBind(Listas.Orgao);
                ddlBuscarUnidadeOrcamentaria2.DataBind(Listas.UnidadeOrcamentaria);
                this.grdListagem.SortColumnName = "ItemRemuneratorio";
                this.grdListagemUC.SortColumnName = "DscNome";
                base.Page_Load(sender, e);
            }
            FocoInicial = ddlItemRemuneratorio;

        }

        protected override void btnNovo_Click(object sender, EventArgs e)
        {
            base.btnNovo_Click(sender, e);
            DataTable dt = null;
            grdListagemUC.DataBind(dt);
        }

        protected void btnFiltrar_OnClick(object sender, EventArgs e)
        {
            PopularGrid();
        }

        private void PopularGrid()
        {
            if (!string.IsNullOrEmpty(ddlItemRemuneratorio.SelectedItem.Value))
            {
                DataTable dtAgentes = ((ManterConcessaoItem)Controladora).getDadosAgentes(pnlConsultaUC.GetFormData(), grdListagemUC.SortByDirection.ToString(), grdListagemUC.SortColumnName);
                DataTable dtAgenteItens = ((ManterConcessaoItem)Controladora).getDadosdtAgenteItens(ddlItemRemuneratorio.SelectedItem.Value, ddlBuscarUnidadeOrcamentaria.SelectedItem.Value);
                DataTable dt = ((ManterConcessaoItem)Controladora).getDadosAgentesItens(dtAgentes, dtAgenteItens);
                grdListagemUC.DataBind(dt);
            }
            else
            {
                this.ExibirAlerta(TiposMensagem.Alerta, "Atenção!", "É necessário selecionar um item para a filtragem!");
            }
        }

        protected void btnProcessarSelecionados_OnClick(object sender, EventArgs e)
        {
            int item = -1;
            List<string> ListaIds = new List<string>();
            foreach (int id in grdListagemUC.SelectedRows)
            {
                ListaIds.Add(grdListagemUC.DataKeys[id].Value.ToString());
            }
            ((ManterConcessaoItem)Controladora).SalvarItens(ListaIds, pnlManutencao.GetFormData());
            ScriptManager.RegisterStartupScript(this, this.GetType(), "QuickMessage", "ExibirMensagem('Ítem(ns) <b>concedido(s)</b> com sucesso.');", true);
            PopularGrid();
            ddlItemRemuneratorio.SelectedIndex = item;
            pnlManutencao.Clear();
        }

        protected override void SetarModoPagina(PaginaCadastroBase.ModosPagina modo)
        {
            base.SetarModoPagina(modo);
            if (modo == ModosPagina.Inserir)
            {
                btnSalvar.Visible = false;
                btnProcessarSelecionados.Visible = true;
            }
            if (modo == ModosPagina.Listar)
            {
                btnProcessarSelecionados.Visible = false;
            }

        }

        protected void ddlBuscaOrgao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ddlBuscarOrgao.SelectedItem.Value))
                ddlBuscarUnidadeOrcamentaria.DataBind(Listas.UnidadeOrcamentariaByIdOrgao(ddlBuscarOrgao.SelectedItem.Value));
            else
                ddlBuscarUnidadeOrcamentaria.DataBind(Listas.UnidadeOrcamentaria);
        }

        protected void ddlBuscaOrgao_SelectedIndexChanged2(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ddlBuscarOrgao2.SelectedItem.Value))
                ddlBuscarUnidadeOrcamentaria2.DataBind(Listas.UnidadeOrcamentariaByIdOrgao(ddlBuscarOrgao2.SelectedItem.Value));
            else
                ddlBuscarUnidadeOrcamentaria.DataBind(Listas.UnidadeOrcamentaria);
        }

        #region Suspenção de Itens


        protected void btnSuspenderSelecionados_OnClick(Object sender, EventArgs e)
        {
            int i = 0;
            foreach (int id in grdListagem.SelectedRows)
            {
                i = i + 1;
            }
            if (i > 0)
            {
                LimparSuspensao();
                mpeSuspensao.Show();
            }
            else
            {
                this.ExibirAlerta(TiposMensagem.Alerta, "Atenção!", "É necessário selecionar um item para a suspenção!");
            }
        }


        public void LimparSuspensao()
        {
            txtDataExpedienteSuspensao.Text = "";
            txtDataPublicacaoSuspensao.Text = "";
            ddlTipoExpedienteSuspensao.SelectedIndex = -1;
            txtNumExpedienteSuspensao.Text = "";
        }

        protected void btnSalvarSuspensao_OnClick(Object sender, EventArgs e)
        {
            List<string> ListaIdSelecionados = new List<string>();
            foreach (int id in grdListagem.SelectedRows)
            {
                ListaIdSelecionados.Add(grdListagem.DataKeys[id].Value.ToString());
            }
            try
            {
                CampoNuloOuInvalidoException ex = ValidarSuspensao();
                if (ex.Mensagens.Count > 0)
                    throw ex;
                else
                {
                    ((ManterConcessaoItem)Controladora).SalvarComUc(pnlManutencaoUCSuspensao.GetFormData(), ListaIdSelecionados);
                    SetarModoPagina(ModosPagina.Listar);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "QuickMessage", "ExibirMensage'Suspensão <b>efetuada</b> com sucesso.');", true);
                }
            }
            catch (Exception ex)
            {
                this.ExibirExcecao(ex);
                mpeSuspensao.Show();
            }
        }

        public CampoNuloOuInvalidoException ValidarSuspensao()
        {
            CampoNuloOuInvalidoException ex = new CampoNuloOuInvalidoException();

            if (ddlTipoExpedienteSuspensao.SelectedIndex == 0)
                ex.Mensagens.Add("TipoExpedienteSuspensao", "O campo <b>Tipo Expediente</b> é de preenchimento obrigatório.");

            if (String.IsNullOrEmpty(txtNumExpedienteSuspensao.Text))
                ex.Mensagens.Add("NumeroExpedienteSuspensao", "O campo <b>Número do Expediente</b> é de preenchimento obrigatório.");

            if (String.IsNullOrEmpty(txtDataExpedienteSuspensao.Text))
                ex.Mensagens.Add("DataExpedienteSuspensao", "O campo <b>Data do Expediente</b> é de preenchimento obrigatório.");

            if (String.IsNullOrEmpty(txtDataPublicacaoSuspensao.Text))
                ex.Mensagens.Add("DataExpedienteSuspensaoPublicacao", "O campo <b>Data de Publicação do Expediente</b> é de preenchimento obrigatório.");

            return ex;
        }

        protected void grdListagemUC_Sorting(object sender, GridViewSortEventArgs e)
        {

        }
        #endregion

        #region UserControls

        //private void PopularGridAgenteItem(int id)
        //{
        //    if (id > 0)
        //        ucAgenteItem1.IdPai = id;
        //    else
        //        ucAgenteItem1.IdPai = null;

        //    ucAgenteItem1.PopularGridView();
        //}

        //protected override void Selecionar(int id)
        //{
        //    base.Selecionar(id);
        //    PopularGridAgenteItem(id);
        //}

        //protected override void SetarModoPagina(PaginaCadastroBase.ModosPagina modo)
        //{
        //    base.SetarModoPagina(modo);
        //    if (modo == ModosPagina.Inserir)
        //    {
        //        PopularGridAgenteItem(0);
        //    }
        //}

        #endregion

    }
}