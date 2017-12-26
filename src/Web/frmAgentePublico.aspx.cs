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
    public partial class frmAgentePublico : PaginaCadastroBase
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.TituloPagina = "Agentes Públicos";
                this.Controladora = new ManterAgentePublico();
                ddlCargo.DataBind(Listas.Cargo);
                ddlUnidadeOrcamentaria.DataBind(Listas.UnidadeOrcamentaria);
                ddlPessoal.DataBind(Listas.Pessoal);
                ddlFormaIngresso.DataBind(Listas.FormaIngresso);
                ddlRegimeJuridico.DataBind(Listas.RegimeJuridico);
                ddlRegimePrevidenciario.DataBind(Listas.RegimePrevidenciario);
                ddlSituacaoFuncional.DataBind(Listas.SituacaoFuncional);
                ddlTipoAmparo.DataBind(Listas.TipoAmparoLegal);
                ddlTipoExpediente.DataBind(Listas.TipoExpediente);
                ddlTipoRelacao.DataBind(Listas.TipoRelacao);
                this.grdListagem.SortColumnName = "ExpedienteNomeacao";
                btnDesligamento.Visible = false;
                base.Page_Load(sender, e);
                ddlTipoExpedienteDesligamento.DataBind(Listas.TipoExpediente);
                ddlTipoDesligamento.DataBind(Listas.TipoDesligamento);
            }
            FocoInicial = ddlUnidadeOrcamentaria;

        }

        protected override void btnNovo_Click(object sender, EventArgs e)
        {
            base.btnNovo_Click(sender, e);
            btnDesligamento.Visible = false;
            chkAtivo.Checked = true;
        }


        #region UserControls

        private void PopularGridAgenteItem(int id)
        {
            if (id > 0)
                ucAgenteItem1.IdPai = id;
            else
                ucAgenteItem1.IdPai = null;

            ucAgenteItem1.PopularGridView();
        }

        protected override void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = ((ManterAgentePublico)Controladora).SalvarRetornandoId(pnlManutencao.GetFormData());
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

        protected void ddlTipoDesligamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlTipoDesligamento.SelectedItem.Text.ToUpper().Equals("MORTE"))
            {
                ddlPensionista.Visible = true;
                mpeDesligamentoAgentes.Show();
            }
            else
            {
                ddlPensionista.Visible = false;
                mpeDesligamentoAgentes.Show();
            }
        }

        protected override void Selecionar(int id)
        {
            base.Selecionar(id);
            btnDesligamento.Visible = true;
            PopularGridAgenteItem(id);
            txtIDLista.Text = Convert.ToString(id);
        }

        protected override void btnListagem_Click(object sender, EventArgs e)
        {
            base.btnListagem_Click(sender, e);
            btnDesligamento.Visible = false;
        }

        protected override void SetarModoPagina(PaginaCadastroBase.ModosPagina modo)
        {
            base.SetarModoPagina(modo);
            if (modo == ModosPagina.Inserir)
            {
                PopularGridAgenteItem(0);
                ucAgenteItem1.DesailitarMultiplosItens();
            }
            if (modo == ModosPagina.Listar || modo == ModosPagina.Inserir)
            {
                btnDesligamento.Visible = false;
            }
            if (modo == ModosPagina.Alterar)
            {
                btnDesligamento.Visible = true;
                btnSalvarDesligamento.Visible = true;
                btnSavarDesligamentoLista.Visible = false;
                ucAgenteItem1.HabilitarMultiplosItens();
            }
            if (modo == ModosPagina.Listar)
            {
                btnSavarDesligamentoLista.Visible = true;
                btnSalvarDesligamento.Visible = false;
            }
        }

        public void LimparDesligamento()
        {
            ddlTipoDesligamento.SelectedIndex = 0;
            ddlTipoExpedienteDesligamento.SelectedIndex = 0;
            txtNumExpedienteDesligamento.Text = "";
            txtDataExpedienteDesligamento.Text = "";
            txtDataPublicacaoDesligamento.Text = "";
            ddlPensionista.SelectedIndex = 0;
            ddlPensionista.Visible = false;
        }

        protected void btnDesligamento_OnClick(Object sender, EventArgs e)
        {
            LimparDesligamento();
            lblAgentePublico.Visible = false;
            mpeDesligamentoAgentes.Show();
        }

        public CampoNuloOuInvalidoException ValidarDesligamento()
        {
            CampoNuloOuInvalidoException ex = new CampoNuloOuInvalidoException();

            if (ddlTipoDesligamento.SelectedIndex == 0)
                ex.Mensagens.Add("TipoDesligamento", "O campo <b>Tipo</b> é de preenchimento obrigatório.");

            if (ddlTipoExpedienteDesligamento.SelectedIndex == 0)
                ex.Mensagens.Add("TipoExpedienteDesligamento", "O campo <b>Tipo de Expediente</b> é de preenchimento obrigatório.");

            if (String.IsNullOrEmpty(txtNumExpedienteDesligamento.Text))
                ex.Mensagens.Add("NumExpedienteDesligamento", "O campo <b>Número do Expediente</b> é de preenchimento obrigatório.");

            if (String.IsNullOrEmpty(txtDataExpedienteDesligamento.Text))
                ex.Mensagens.Add("DataExpedienteDesligamento", "O campo <b>Data do Expediente</b> é de preenchimento obrigatório.");

            if (String.IsNullOrEmpty(txtDataPublicacaoDesligamento.Text))
                ex.Mensagens.Add("DataPublicacaoDesligamento", "O campo <b>Data de Publicação do Expediente</b> é de preenchimento obrigatório.");

            if (ddlTipoDesligamento.SelectedItem.Text.ToUpper().Equals("MORTE"))
            {
                if (ddlPensionista.SelectedIndex == 0)
                    ex.Mensagens.Add("Pensionista", "O campo <b>Pensionista</b> é de preenchimento obrigatório.");
            }


            return ex;
        }

        protected void btnSavarDesligamentoLista_OnClick(Object sender, EventArgs e)
        {
            try
            {
                CampoNuloOuInvalidoException ex = ValidarDesligamento();
                if (ex.Mensagens.Count > 0)
                    throw ex;
                else
                {
                    ((ManterAgentePublico)Controladora).SalvarComUc(pnlManutencaoUCDesligamento.GetFormData(), Convert.ToInt32(txtIDLista.Text));
                    SetarModoPagina(ModosPagina.Listar);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "QuickMessage", "ExibirMensagem('Desligamento <b>efetuado</b> com sucesso.');", true);
                }
            }
            catch (Exception ex)
            {
                this.ExibirExcecao(ex);
                mpeDesligamentoAgentes.Show();
            }
        }

        public override void grdListagem_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int ID;
            int index;

            base.grdListagem_RowCommand(sender, e);
            if (e.CommandName.ToUpper() == "DESLIGAMENTO")
            {
                index = ((GridViewRow)((ImageButton)e.CommandSource).Parent.Parent).RowIndex;
                ID = Convert.ToInt32(grdListagem.DataKeys[index].Value);
                txtIDLista.Text = Convert.ToString(ID);
                ddlPensionista.DataBind(Listas.AgentesPublicosPensionista(txtIDLista.Text));
                imgDesligamento_OnClick(sender, null);
            }
        }

        protected void btnSalvarDesligamento_OnClick(Object sender, EventArgs e)
        {
            ((ManterAgentePublico)Controladora).SalvarComUc(pnlManutencaoUCDesligamento.GetFormData(), Convert.ToInt32(txtIDLista.Text));
            SetarModoPagina(ModosPagina.Listar);
        }

        protected void imgDesligamento_OnClick(Object sender, EventArgs e)
        {
            lblAgentePublico.Text = ((ManterAgentePublico)Controladora).GetNomeAgentePublico(Convert.ToInt32(txtIDLista.Text));
            ddlPensionista.DataBind(Listas.AgentesPublicos);
            btnDesligamento_OnClick(sender, e);
            lblAgentePublico.Visible = true;
        }

        #endregion

    }
}