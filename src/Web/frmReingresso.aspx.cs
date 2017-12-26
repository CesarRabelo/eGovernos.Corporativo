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
    public partial class frmReingresso : PaginaCadastroBase
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.TituloPagina = "Reingresso dos Agentes Públicos";
                this.Controladora = new ManterReingresso();
                this.grdListagem.SortColumnName = "DscPessoal";
                this.PaginaSegura = false;
                base.Page_Load(sender, e);
                btnNovo.Visible = false;
                ddlTipoExpedienteReingresso.DataBind(Listas.TipoExpediente);
                ddlTipoReingresso.DataBind(Listas.TipoReingresso);
                ddlTipoAmparo.DataBind(Listas.TipoAmparoLegal);
            }
            FocoInicial = txtID;

        }

        protected override void btnNovo_Click(object sender, EventArgs e)
        {
            base.btnNovo_Click(sender, e);
        }

        #region UserControls

        protected override void btnSalvar_Click(object sender, EventArgs e)
        {
            base.btnSalvar_Click(sender, e);
        }

        protected override void Selecionar(int id)
        {
            base.Selecionar(id);
            txtIDLista.Text = Convert.ToString(id);
        }

        protected override void btnListagem_Click(object sender, EventArgs e)
        {
            base.btnListagem_Click(sender, e);
        }

        public CampoNuloOuInvalidoException ValidarReingresso()
        {
            CampoNuloOuInvalidoException ex = new CampoNuloOuInvalidoException();

            if (ddlTipoReingresso.SelectedIndex == 0)
                ex.Mensagens.Add("TipoReingresso", "O campo <b>Tipo de Reingresso</b> é de preenchimento obrigatório.");

            if (ddlTipoExpedienteReingresso.SelectedIndex == 0)
                ex.Mensagens.Add("TipoExpedienteReingresso", "O campo <b>Tipo de Expediente</b> é de preenchimento obrigatório.");

            if (String.IsNullOrEmpty(txtNumExpedienteReingresso.Text))
                ex.Mensagens.Add("NumExpedienteReingresso", "O campo <b>Número do Expediente</b> é de preenchimento obrigatório.");

            if (String.IsNullOrEmpty(txtDataExpedienteReingresso.Text))
                ex.Mensagens.Add("DataExpedienteReingresso", "O campo <b>Data do Expediente</b> é de preenchimento obrigatório.");

            if (String.IsNullOrEmpty(txtDataPublicacaoReingresso.Text))
                ex.Mensagens.Add("DataPublicacaoReingresso", "O campo <b>Data de Publicação do Expediente</b> é de preenchimento obrigatório.");

            if (ddlTipoAmparo.SelectedIndex == 0)
                ex.Mensagens.Add("TipoAmparo", "O campo <b>Tipo de Amparo</b> é de preenchimento obrigatório.");

            if (String.IsNullOrEmpty(txtNumeroAmparoLegal.Text))
                ex.Mensagens.Add("NumeroAmparoLegal", "O campo <b>Número do Amparo Legal</b> é de preenchimento obrigatório.");

            if (String.IsNullOrEmpty(txtDataPublicacaoAmparoLegal.Text))
                ex.Mensagens.Add("DataPublicacaoAmparoLegal", "O campo <b>Data de Publicação do Amparo Legal</b> é de preenchimento obrigatório.");

            if (String.IsNullOrEmpty(txtData.Text))
                ex.Mensagens.Add("DataAmparo", "O campo <b>Data do Amparo Legal</b> é de preenchimento obrigatório.");

            return ex;
        }

        protected void btnSavarReingressoLista_OnClick(Object sender, EventArgs e)
        {
            try
            {
                CampoNuloOuInvalidoException ex = ValidarReingresso();
                if (ex.Mensagens.Count > 0)
                {
                    throw ex;
                }
                else
                {
                    ((ManterReingresso)Controladora).SalvarComUc(pnlManutencaoUCReingresso.GetFormData(), Convert.ToInt32(txtIDLista.Text));
                    SetarModoPagina(ModosPagina.Listar);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "QuickMessage", "ExibirMensagem('Reingresso <b>efetuado</b> com sucesso.');", true);
                }
            }
            catch (Exception ex)
            {
                this.ExibirExcecao(ex);
                mpeReingressoAgentes.Show();
            }
        }

        public override void grdListagem_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int ID;
            int index;

            base.grdListagem_RowCommand(sender, e);
            if (e.CommandName.ToUpper() == "REINGRESSO")
            {
                index = ((GridViewRow)((ImageButton)e.CommandSource).Parent.Parent).RowIndex;
                ID = Convert.ToInt32(grdListagem.DataKeys[index].Value);
                txtIDLista.Text = Convert.ToString(ID);
            }
        }

        public void LimparReingresso()
        {
            ddlTipoReingresso.SelectedIndex = 0;
            ddlTipoExpedienteReingresso.SelectedIndex = 0;
            txtNumExpedienteReingresso.Text = "";
            txtDataExpedienteReingresso.Text = "";
            txtDataPublicacaoReingresso.Text = "";
            ddlTipoAmparo.SelectedIndex = 0;
            txtNumeroAmparoLegal.Text = "";
            txtDataPublicacaoAmparoLegal.Text = "";
            txtData.Text = "";
        }

        protected void imgReingresso_OnClick(Object sender, EventArgs e)
        {
            LimparReingresso();
            mpeReingressoAgentes.Show();
        }

        #endregion

    }
}