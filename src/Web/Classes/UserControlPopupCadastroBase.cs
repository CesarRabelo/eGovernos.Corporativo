using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;

using Pro.Controls;
using AjaxControlToolkit;
using Platinium.Negocio;
using Pro.Utils;

namespace Web
{
    /// <summary>
    /// Classe base para as páginas de cadastro
    /// </summary>
    public class UserControlPopupCadastroBase : UserControlPopupListagemBase
    {
        #region Propriedades
        protected Control FocoInicial
        {
            get { 
                if(ViewState["$FocusInicialPopup$"] != null)
                    return this.LocalizarControle(ViewState["$FocusInicialPopup$"].ToString(), this.Controls);
                
                return null;
                }
            set { ViewState["$FocusInicialPopup$"] = value.ID; }
        }

        public enum ModosPagina { Listar, Inserir, Alterar }

        protected ModosPagina ModoPagina
        {
            get { return ViewState["$ModoPaginaPopup$"] == null ? ModosPagina.Listar : (ModosPagina)ViewState["$ModoPaginaPopup$"]; }
            set { ViewState["$ModoPaginaPopup$"] = value; }
        }

        #endregion

        #region Eventos
        /// <summary>
        /// Seta os métodos dos botões e controles da página de cadastro
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void Page_Init(object sender, EventArgs e)
        {
            try
            {
                Button btnExcluir = (Button)this.LocalizarControle("btnExcluirUC",this.Controls);
                btnExcluir.OnClientClick = "messageBox(this,'PERGUNTA','SIMNAO','Confirmação de exclusão','Deseja realmente excluir este item ?',''); return false;";
                btnExcluir.Click += new EventHandler(btnExcluir_Click);

				Button btnSalvar = (Button)this.LocalizarControle("btnSalvarUC", this.Controls);
                btnSalvar.Click += new EventHandler(btnSalvar_Click);

				Button btnListagem = (Button)this.LocalizarControle("btnListagemUC", this.Controls);
                if (btnListagem != null)
                    btnListagem.Click += new EventHandler(btnListagem_Click);

				Button btnNovo = (Button)this.LocalizarControle("btnNovoUC", this.Controls);
                btnNovo.Click += new EventHandler(btnNovo_Click);

                Button btnNovoCadastro = (Button)this.LocalizarControle("btnNovoCadastroUC",this.Controls);
                if (btnNovoCadastro != null)
                    btnNovoCadastro.Click += new EventHandler(btnNovo_Click);

				Button btnBuscar = (Button)this.LocalizarControle("btnBuscarUC",this.Controls);
                if (btnBuscar != null)
                    btnBuscar.Click += new EventHandler(btnBuscar_Click);

				ProTextBox txtBusca = (ProTextBox)this.LocalizarControle("txtBuscaUC", this.Controls);
                if (txtBusca != null)
                    txtBusca.Attributes.Add("onkeypress", "if(event.which || event.keyCode){if((event.which == 13) || (event.keyCode == 13)){event.keyCode=0; document.getElementById('" + btnBuscar.ClientID + "').click();return false;}else{return true;}}");

				ProGridView grdListagem = (ProGridView)this.LocalizarControle("grdListagemUC", this.Controls);
                grdListagem.SelectedIndexChanged += new EventHandler(grdListagem_SelectedIndexChanged);
                grdListagem.PageIndexChanging += new GridViewPageEventHandler(grdListagem_PageIndexChanging);
                grdListagem.RowEditing += new GridViewEditEventHandler(grdListagem_RowEditing);
                grdListagem.RowCommand += new GridViewCommandEventHandler(grdListagem_RowCommand);
                grdListagem.RowDeleting += new GridViewDeleteEventHandler(grdListagem_RowDeleting);
                grdListagem.Sorting += new GridViewSortEventHandler(grdListagem_Sorting);
            }
            catch (Exception ex)
            {
                ExibirExcecao(ex);
            }
        }

        protected override void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (PaginaSegura)
                    {
                        if (!Contexto.Seguranca.Ler(this.GetType().BaseType.Name))
                        {
                            ProPanel pnlConsulta = (ProPanel)this.LocalizarControle("pnlConsultaUC", this.Controls);
                            if (pnlConsulta != null)
                                pnlConsulta.Visible = false;
                            return;
                        }
                    }
                    PopularGridView();
                    SetarModoPagina(ModosPagina.Listar);
					ProTextBox txtBusca = (ProTextBox)this.LocalizarControle("txtBusca", this.Controls);
					if(txtBusca != null)
						Focus(txtBusca);
                }
            }
            catch (Exception ex)
            {
                ExibirExcecao(ex);
            }
        }

        protected virtual void grdListagem_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected virtual void grdListagem_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
				ProGridView grdListagem = (ProGridView)this.LocalizarControle("grdListagemUC", this.Controls);
				grdListagem.SelectedIndex = e.NewEditIndex;
                Selecionar(Convert.ToInt32(grdListagem.DataKeys[e.NewEditIndex].Value));
            }
            catch (Exception ex)
            {
                this.ExibirExcecao(ex);
            }
         }

        public virtual void grdListagem_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        public virtual void grdListagem_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                ProGridView grdListagem = (ProGridView)this.LocalizarControle("grdListagemUC", this.Controls);
                if (e.CommandName.ToUpper() == "DELETE")
                {
                    if (!Contexto.Seguranca.Deletar(this.GetType().BaseType.Name))
                        throw new ViolacaoRegraException("Usuário não tem permissão para <b>excluir</b> registro.");

                    int index;
                    //Se estiver usando ImageButton
                    try { index = ((GridViewRow)((ImageButton)e.CommandSource).Parent.Parent).RowIndex; }
                    //Se estiver usando ButtonField
                    catch { index = Convert.ToInt32(e.CommandArgument); }
                    this.Controladora.Selecionar(Convert.ToInt32(grdListagem.DataKeys[index].Value));
                    this.Controladora.Excluir();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "QuickMessage", "ExibirMensagem('Registro <b>excluído</b> com sucesso.');", true);
                    this.SetarModoPagina(ModosPagina.Listar);
                }
            }
            catch (Exception ex)
            {
                this.ExibirExcecao(ex);
            }
        }

        protected virtual void btnNovo_Click(object sender, EventArgs e)
        {
            try
            {
                this.Controladora.PrepararInclusao();
                SetarModoPagina(ModosPagina.Inserir);
            }
            catch (Exception ex)
            {
                this.ExibirExcecao(ex);
            }
        }

        protected virtual void btnListagem_Click(object sender, EventArgs e)
        {
            try
            {
                this.SetarModoPagina(ModosPagina.Listar);
            }
            catch (Exception ex)
            {
                this.ExibirExcecao(ex);
            }
        }

        protected virtual void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Contexto.Seguranca.Deletar(this.GetType().BaseType.Name))
                    throw new ViolacaoRegraException("Usuário não tem permissão para <b>excluir</b> registro.");

                this.Controladora.Excluir();
				ProPanel pnlManutencao = (ProPanel)this.LocalizarControle("pnlManutencaoUC", this.Controls);
                pnlManutencao.Clear();
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "QuickMessage", "ShowQuickMessage('Registro excluído com sucesso.');", true);
                SetarModoPagina(ModosPagina.Listar);
            }
            catch (Exception ex)
            {
                this.ExibirExcecao(ex);
            }
        }

        private void ExibirExcecaoBase(Exception ex)
        {
            ShowPopup();
            this.ExibirExcecao(ex);
        }

        private void ShowPopup()
        {
            ModalPopupExtender mpeUC = (ModalPopupExtender)this.LocalizarControle("mpeUC", this.Controls);
            if ((mpeUC != null) && (ModoPagina != ModosPagina.Listar))
                mpeUC.Show();
        }

        protected virtual void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ModoPagina == ModosPagina.Inserir)
                {
                    if (!Contexto.Seguranca.Inserir(this.GetType().BaseType.Name))
                        throw new ViolacaoRegraException("Usuário não tem permissão para <b>inserir</b> registro.");
                }
                else if (ModoPagina == ModosPagina.Alterar)
                {
                    if (!Contexto.Seguranca.Atualizar(this.GetType().BaseType.Name))
                        throw new ViolacaoRegraException("Usuário não tem permissão para <b>alterar</b> registro.");
                }
				ProPanel pnlManutencao = (ProPanel)this.LocalizarControle("pnlManutencaoUC", this.Controls);

                if (this.Controladora.Salvar(pnlManutencao.GetFormData()) == Pro.Dal.CrudActionTypes.Insert)
                {
                    pnlManutencao.Clear();
                    this.Controladora.PrepararInclusao();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "QuickMessage", "ExibirMensagem('Registro <b>inserido</b> com sucesso.');", true);
                }
                else
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "QuickMessage", "ExibirMensagem('Registro <b>atualizado</b> com sucesso.');", true);

                PopularGridView();
            }
            catch (Exception ex)
            {
                this.ExibirExcecaoBase(ex);
            }
        }
        #endregion

        #region Métodos
        private void VerificarPermissoes()
        {
            if (PaginaSegura)
            {
                if (!Contexto.Seguranca.Inserir(this.GetType().BaseType.Name))
                {
                    Button btnNovo = (Button)this.LocalizarControle("btnNovoUC", this.Controls);
                    if (btnNovo != null)
                        btnNovo.Visible = false;
                }
                else
                {
                    if (ModoPagina == ModosPagina.Inserir)
                    {
                        Button btnSalvar = (Button)this.LocalizarControle("btnSalvarUC", this.Controls);
                        if (btnSalvar != null)
                            btnSalvar.Visible = true;
                    }
                }

                if (!Contexto.Seguranca.Atualizar(this.GetType().BaseType.Name))
                {
                    if (ModoPagina == ModosPagina.Alterar)
                    {
                        Button btnSalvar = (Button)this.LocalizarControle("btnSalvarUC", this.Controls);
                        if (btnSalvar != null)
                            btnSalvar.Visible = false;
                    }
                }
                if (!Contexto.Seguranca.Deletar(this.GetType().BaseType.Name))
                {
                    Button btnExcluir = (Button)this.LocalizarControle("btnExcluirUC", this.Controls);
                    if (btnExcluir != null)
                        btnExcluir.Visible = false;
                }
            }
        }
        /// <summary>
        /// Seta o foco no controle informado.
        /// </summary>
        /// <param name="control"></param>
        protected override void Focus(Control control)
        {
            ScriptManager.GetCurrent(this.Page).SetFocus(control);
        }

        protected virtual void Selecionar(int id)
        {
            try
            {
				ProPanel pnlManutencao = (ProPanel)this.LocalizarControle("pnlManutencaoUC", this.Controls);
				ProGridView grdListagem = (ProGridView)this.LocalizarControle("grdListagemUC", this.Controls);

                SetarModoPagina(ModosPagina.Alterar);
                pnlManutencao.SetFormData(this.Controladora.Selecionar(id));
                grdListagem.SelectedIndex = -1;
            }
            catch (Pro.Dal.Exceptions.NotAutorizedException ex)
            {
                SetarModoPagina(ModosPagina.Listar);
                this.ExibirExcecao(ex);
            }
            catch (Exception ex)
            {
                this.ExibirExcecao(ex);
            }
        }
        protected void PreencherIdPaiManutencao()
        {
            ProTextBox txtIdPaiManutencao = (ProTextBox)this.LocalizarControle("txtIdPaiManutencao", this.Controls);

            if ((txtIdPaiManutencao != null) && (IdPai != null))
                txtIdPaiManutencao.Text = this.IdPai.ToString();
            else
                txtIdPaiManutencao.Text = string.Empty;
        }

        protected virtual void SetarModoPagina(ModosPagina modo)
        {
            try
            {
                this.ModoPagina = modo;
				Button btnExcluir = (Button)this.LocalizarControle("btnExcluirUC", this.Controls);
				//Button btnNovoCadastro = (Button)this.LocalizarControle("btnNovoCadastroUC", this.Controls);
				ProPanel pnlManutencao = (ProPanel)this.LocalizarControle("pnlManutencaoUC", this.Controls);
                //ProPanel pnlConsulta = (ProPanel)this.LocalizarControle("pnlConsultaUC",this.Controls);
				ProGridView grdListagem = (ProGridView)this.LocalizarControle("grdListagemUC", this.Controls);
                ModalPopupExtender mpeUC = (ModalPopupExtender)this.LocalizarControle("mpeUC", this.Controls);
                
                switch (modo)
                {
                    case ModosPagina.Listar:
                        PopularGridView();                        
                        mpeUC.Hide();
                        break;
                    case ModosPagina.Inserir:
                        pnlManutencao.Clear();
                        mpeUC.Show();
                        btnExcluir.Visible = false;
                        //btnNovoCadastro.Visible = false;
                        //pnlConsulta.Visible = false;
                        grdListagem.SelectedIndex = -1;
                        this.grdListagem_SelectedIndexChanged(this, EventArgs.Empty);
                        if (FocoInicial != null) Focus(FocoInicial);
                        break;
                    case ModosPagina.Alterar:
                        mpeUC.Show();
                        btnExcluir.Visible = true;
                        //btnNovoCadastro.Visible = true;
                        //pnlConsulta.Visible = false;
                        if (FocoInicial != null) Focus(FocoInicial);
                        break;
                }
                PreencherIdPaiManutencao();
                BotaoNovoAtivo();
                VerificarPermissoes();
            }
            catch (Exception ex)
            {
                this.ExibirExcecao(ex);
            }
        }

        #endregion
    }
}
