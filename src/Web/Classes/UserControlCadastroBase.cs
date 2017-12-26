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

namespace Web
{
    /// <summary>
    /// Classe base para as páginas de cadastro
    /// </summary>
    public class UserControlCadastroBase : UserControlListagemBase
    {
        #region Propriedades
        /// <summary>
        /// Esse controle receberá o focus logo ao entrar na parte de inserção e edição.
        /// </summary>
        protected Control FocoInicial
        {
            get { 
                if(ViewState["$FocusInicial$"] != null)
					return this.LocalizarControle(ViewState["$FocusInicial$"].ToString(), this.Controls);
                
                return null;
                }
            set { ViewState["$FocusInicial$"] = value.ID; }
        }

        public enum ModosPagina { Listar, Inserir, Alterar }

        protected ModosPagina ModoPagina
        {
            get { return ViewState["$ModoPagina$"] == null ? ModosPagina.Listar : (ModosPagina)ViewState["$ModoPagina$"]; }
            set { ViewState["$ModoPagina$"] = value; }
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
                Button btnExcluir = (Button)this.LocalizarControle("btnExcluir",this.Controls);
                btnExcluir.OnClientClick = "messageBox(this,'PERGUNTA','SIMNAO','Confirmação de exclusão','Deseja realmente excluir este item ?',''); return false;";
                btnExcluir.Click += new EventHandler(btnExcluir_Click);

				Button btnSalvar = (Button)this.LocalizarControle("btnSalvar", this.Controls);
                btnSalvar.Click += new EventHandler(btnSalvar_Click);

				Button btnListagem = (Button)this.LocalizarControle("btnListagem", this.Controls);
                btnListagem.Click += new EventHandler(btnListagem_Click);

				Button btnNovo = (Button)this.LocalizarControle("btnNovo", this.Controls);
                btnNovo.Click += new EventHandler(btnNovo_Click);

                Button btnNovoCadastro = (Button)this.LocalizarControle("btnNovoCadastro",this.Controls);
                if (btnNovoCadastro != null)
                    btnNovoCadastro.Click += new EventHandler(btnNovo_Click);

				Button btnBuscar = (Button)this.LocalizarControle("btnBuscar",this.Controls);
                btnBuscar.Click += new EventHandler(btnBuscar_Click);

				ProTextBox txtBusca = (ProTextBox)this.LocalizarControle("txtBusca", this.Controls);
                txtBusca.Attributes.Add("onkeypress", "if(event.which || event.keyCode){if((event.which == 13) || (event.keyCode == 13)){event.keyCode=0; document.getElementById('" + btnBuscar.ClientID + "').click();return false;}else{return true;}}");

				ProGridView grdListagem = (ProGridView)this.LocalizarControle("grdListagem", this.Controls);
                grdListagem.SelectedIndexChanged += new EventHandler(grdListagem_SelectedIndexChanged);
                grdListagem.PageIndexChanging += new GridViewPageEventHandler(grdListagem_PageIndexChanging);
                grdListagem.RowEditing += new GridViewEditEventHandler(grdListagem_RowEditing);
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
				ProGridView grdListagem = (ProGridView)this.LocalizarControle("grdListagem", this.Controls);
				grdListagem.SelectedIndex = e.NewEditIndex;
                Selecionar(Convert.ToInt32(grdListagem.DataKeys[e.NewEditIndex].Value));
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
                this.Controladora.Excluir();
				ProPanel pnlManutencao = (ProPanel)this.LocalizarControle("pnlManutencao", this.Controls);
                pnlManutencao.Clear();
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "QuickMessage", "ShowQuickMessage('Registro excluído com sucesso.');", true);
                SetarModoPagina(ModosPagina.Listar);
            }
            catch (Exception ex)
            {
                this.ExibirExcecao(ex);
            }
        }

        protected virtual void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
				ProPanel pnlManutencao = (ProPanel)this.LocalizarControle("pnlManutencao", this.Controls);
                if (this.Controladora.Salvar(pnlManutencao.GetFormData()) == Pro.Dal.CrudActionTypes.Insert)
                {
                    pnlManutencao.Clear();
                    this.Controladora.PrepararInclusao();
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "QuickMessage", "ShowQuickMessage('Registro inserido com sucesso.');", true);
                }
                //else
                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "QuickMessage", "ShowQuickMessage('<br>Registro atualizado com sucesso.');", true);
                    //Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "QuickMessage", "ShowQuickMessage('Registro atualizado com sucesso.');");
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "QuickMessage", "ShowQuickMessage('Registro atualizado com sucesso.');",true);

            }
            catch (Exception ex)
            {
                this.ExibirExcecao(ex);
            }
        }
        #endregion

        #region Métodos
        protected virtual void Selecionar(int id)
        {
            try
            {
				ProPanel pnlManutencao = (ProPanel)this.LocalizarControle("pnlManutencao", this.Controls);
				ProGridView grdListagem = (ProGridView)this.LocalizarControle("grdListagem", this.Controls);

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

        protected virtual void SetarModoPagina(ModosPagina modo)
        {
            try
            {
                this.ModoPagina = modo;
                MultiView mtvPrincipal = (MultiView)this.LocalizarControle("mtvPrincipal",this.Controls);
				Button btnExcluir = (Button)this.LocalizarControle("btnExcluir", this.Controls);
				Button btnNovoCadastro = (Button)this.LocalizarControle("btnNovoCadastro", this.Controls);
				ProPanel pnlManutencao = (ProPanel)this.LocalizarControle("pnlManutencao", this.Controls);
                ProPanel pnlConsulta = (ProPanel)this.LocalizarControle("pnlConsulta",this.Controls);
				ProGridView grdListagem = (ProGridView)this.LocalizarControle("grdListagem", this.Controls);

                switch (modo)
                {
                    case ModosPagina.Listar:
                        PopularGridView();
                        pnlConsulta.Visible = true;
                        mtvPrincipal.ActiveViewIndex = 0;
                        break;
                    case ModosPagina.Inserir:
                        pnlManutencao.Clear();
                        mtvPrincipal.ActiveViewIndex = 1;
                        btnExcluir.Visible = false;
                        btnNovoCadastro.Visible = false;
                        pnlConsulta.Visible = false;
                        grdListagem.SelectedIndex = -1;
                        this.grdListagem_SelectedIndexChanged(this, EventArgs.Empty);
                        if (FocoInicial != null) Focus(FocoInicial);
                        break;
                    case ModosPagina.Alterar:
                        mtvPrincipal.ActiveViewIndex = 1;
                        btnExcluir.Visible = true;
                        btnNovoCadastro.Visible = true;
                        pnlConsulta.Visible = false;
                        if (FocoInicial != null) Focus(FocoInicial);
                        break;
                }
            }
            catch (Exception ex)
            {
                this.ExibirExcecao(ex);
            }
        }

        #endregion
    }
}
