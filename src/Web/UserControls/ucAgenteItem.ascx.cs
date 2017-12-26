using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Web;
using Platinium.Web;
using Platinium.Negocio;
using System.Data;
using Pro.Utils;
using Atom.ClientWeb;

namespace Platinium.Web
{
    public partial class ucAgenteItem : UserControlPopupCadastroBase
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.lblTitulo.Text = "Concessão de Item por Agente.";
                this.Controladora = new ManterAgenteItem();
                this.grdListagemUC.SortColumnName = "ItemRemuneratorio";
                ddlItemRemuneratorio.DataBind(Listas.ItemRemuneratorio);
                ddlTipoExpediente.DataBind(Listas.TipoExpediente);
                ddlTipoExpedienteSuspensao.DataBind(Listas.TipoExpediente);
                base.Page_Load(sender, e);
            }
        }

        protected override void btnNovo_Click(object sender, EventArgs e)
        {
            base.btnNovo_Click(sender, e);
            grdListagemItens.Visible = false;
            ddlItemRemuneratorio.Visible = true;
        }

        protected void btnNovoUCItens_Click(object sender, EventArgs e)
        {
            mpeUC.Show();
            grdListagemItens.Visible = true;
            ddlItemRemuneratorio.Visible = false;
            ddlItemRemuneratorio.SelectedIndex = -1;
            PopularGrid();
        }

        private void PopularGrid()
        {
            DataTable dt = ((ManterAgenteItem)Controladora).getDadosItens();
            grdListagemItens.DataBind(dt);

        }

        protected override void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(ddlItemRemuneratorio.SelectedValue))
                {
                    ((ManterAgenteItem)Controladora).ValidacaoExistente(ddlItemRemuneratorio.SelectedItem.Value);
                    base.btnSalvar_Click(sender, e);
                }
                if (ddlItemRemuneratorio.Visible == true)
                    ((ManterAgenteItem)Controladora).ValidarEntidade(IdPai.Value);

                List<string> ListaIds = new List<string>();
                foreach (int id in grdListagemItens.SelectedRows)
                {
                    ListaIds.Add(grdListagemItens.DataKeys[id].Value.ToString());
                }
                if (ListaIds.Count > 0)
                {
                    ((ManterAgenteItem)Controladora).SalvarItens(ListaIds, pnlManutencaoUC.GetFormData(), txtIdPaiConsulta.Text);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "QuickMessage", "ExibirMensagem('Ítem(ns) <b>concedido(s)</b> com sucesso.');", true);
                    PopularGridView();
                }
                else
                {
                    CampoNuloOuInvalidoException ex = ValidarCamposItens();
                    if (ex.Mensagens.Count > 0)
                        throw ex;
                }
            }
            catch (Exception ex)
            {
                this.ExibirExcecao(ex);
            }
        }

        public void HabilitarMultiplosItens()
        {
            btnNovoUCItens.Enabled = true;
        }

        public void DesailitarMultiplosItens()
        {
            btnNovoUCItens.Enabled = false;
        }

        public CampoNuloOuInvalidoException ValidarCamposItens()
        {
            CampoNuloOuInvalidoException ex = new CampoNuloOuInvalidoException();


            if (String.IsNullOrEmpty(txtNumeroExpediente.Text))
                ex.Mensagens.Add("NumeroExpediente", "O campo <b>Número do Expediente</b> é de preenchimento obrigatório.");

            if (ddlTipoExpediente.SelectedIndex == 0)
                ex.Mensagens.Add("TipoExpediente", "O campo <b>Tipo Expediente</b> é de preenchimento obrigatório.");

            if (String.IsNullOrEmpty(txtDataExpedienteConcessao.Text))
                ex.Mensagens.Add("DataExpedienteConcessao", "O campo <b>Data do Expediente</b> é de preenchimento obrigatório.");

            if (String.IsNullOrEmpty(txtDataExpedienteConcessaoPublicacao.Text))
                ex.Mensagens.Add("DataExpedienteConcessaoPublicacao", "O campo <b>Data de Publicação do Expediente</b> é de preenchimento obrigatório.");

            return ex;
        }

        #region Suspensão de itens

        protected void btnCancelarSuspensao_OnClick(Object sender, EventArgs e)
        {
            mpeSuspensaoItem.Hide();
        }

        protected void btnSuspenderItensSelecionados_OnClick(Object sender, EventArgs e)
        {
            int i = 0;
            foreach (int id in grdListagemUC.SelectedRows)
            {
                i = i + 1;
            }
            if (i > 0)
            {
                LimparSuspensao();
                mpeSuspensaoItem.Show();
            }
            else
            {
                this.ExibirAlerta(TiposMensagem.Alerta, "Atenção!", "É necessário selecionar um item para a suspensão!");
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
            foreach (int id in grdListagemUC.SelectedRows)
            {
                ListaIdSelecionados.Add(grdListagemUC.DataKeys[id].Value.ToString());
            }
            try
            {
                CampoNuloOuInvalidoException ex = ValidarSuspensao();
                if (ex.Mensagens.Count > 0)
                    throw ex;
                else
                {
                    ((ManterAgenteItem)Controladora).SalvarComUc(pnlManutencaoUCSuspensao.GetFormData(), ListaIdSelecionados);
                    mpeSuspensaoItem.Hide();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "QuickMessage", "ExibirMensage'Suspensão <b>efetuada</b> com sucesso.');", true);
                    this.PopularGridView();
                }
            }
            catch (Exception ex)
            {
                this.ExibirExcecao(ex);
                mpeSuspensaoItem.Show();
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

        #endregion
    }
}
