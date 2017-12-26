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
using Negocio;
using Pro.Utils;
using Platinium.Negocio;

namespace Web
{
    /// <summary>
    /// Classe base para as p�ginas de cadastro
    /// </summary>
    public class PaginaCadastroBase : PaginaListagemBase
    {
        #region Propriedades

        /// <summary>
        /// Esse controle receber� o focus logo ao entrar na parte de inser��o e edi��o.
        /// </summary>
        protected Control FocoInicial
        {
            get
            {
                if (ViewState["$FocusInicial$"] != null)
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
        /// Seta os m�todos dos bot�es e controles da p�gina de cadastro
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void Page_Init(object sender, EventArgs e)
        {
            try
            {
                Button btnExcluir = (Button)this.LocalizarControle("btnExcluir", this.Controls);
                if (btnExcluir != null)
                {
                    btnExcluir.OnClientClick = "messageBox(this,'PERGUNTA','SIMNAO','Confirma��o de exclus�o','Deseja realmente excluir este item ?',''); return false;";
                    btnExcluir.Click += new EventHandler(btnExcluir_Click);
                }

                Button btnSalvar = (Button)this.LocalizarControle("btnSalvar", this.Controls);
                if (btnSalvar != null)
                    btnSalvar.Click += new EventHandler(btnSalvar_Click);

                Button btnListagem = (Button)this.LocalizarControle("btnListagem", this.Controls);
                btnListagem.Click += new EventHandler(btnListagem_Click);

                Button btnNovo = (Button)this.LocalizarControle("btnNovo", this.Controls);
                if (btnNovo != null)
                    btnNovo.Click += new EventHandler(btnNovo_Click);

                Button btnNovoCadastro = (Button)this.LocalizarControle("btnNovoCadastro", this.Controls);
                if (btnNovoCadastro != null)
                    btnNovoCadastro.Click += new EventHandler(btnNovo_Click);

                Button btnBuscar = (Button)this.LocalizarControle("btnBuscar", this.Controls);
                if (btnBuscar != null)
                    btnBuscar.Click += new EventHandler(btnBuscar_Click);

                ProTextBox txtBusca = (ProTextBox)this.LocalizarControle("txtBusca", this.Controls);
                if (txtBusca != null)
                    txtBusca.Attributes.Add("onkeypress", "if(event.which || event.keyCode){if((event.which == 13) || (event.keyCode == 13)){event.keyCode=0; document.getElementById('" + btnBuscar.ClientID + "').click();return false;}else{return true;}}");

                Button btnLimpar = (Button)this.LocalizarControle("btnLimpar", this.Controls);
                if (btnLimpar != null)
                    btnLimpar.Click += new EventHandler(btnLimpar_Click);

                ProGridView grdListagem = (ProGridView)this.LocalizarControle("grdListagem", this.Controls);
                grdListagem.SelectedIndexChanged += new EventHandler(grdListagem_SelectedIndexChanged);
                grdListagem.PageIndexChanging += new GridViewPageEventHandler(grdListagem_PageIndexChanging);
                grdListagem.RowEditing += new GridViewEditEventHandler(grdListagem_RowEditing);
                grdListagem.RowCommand += new GridViewCommandEventHandler(grdListagem_RowCommand);
                grdListagem.RowDeleting += new GridViewDeleteEventHandler(grdListagem_RowDeleting);
                grdListagem.Sorting += new GridViewSortEventHandler(grdListagem_Sorting);

                ProPanel pnlManutencao = (ProPanel)this.LocalizarControle("pnlManutencao", this.Controls);
                if (pnlManutencao != null)
                    pnlManutencao.DefaultButton = "btnSalvar";

                ProPanel pnlConsulta = (ProPanel)this.LocalizarControle("pnlConsulta", this.Controls);
                if (pnlConsulta != null)
                    pnlConsulta.DefaultButton = "btnBuscar";

            }
            catch (Exception ex)
            {
                ExibirExcecao(ex);
            }
        }

        public virtual void grdListagem_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        public virtual void grdListagem_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                ProGridView grdListagem = (ProGridView)this.LocalizarControle("grdListagem", this.Controls);
                if (e.CommandName.ToUpper() == "DELETE")
                {
                    if (!Contexto.Seguranca.Deletar(this.GetType().BaseType.Name))
                        throw new ViolacaoRegraException("Usu�rio n�o tem permiss�o para <b>excluir</b> registro.");

                    int index;
                    //Se estiver usando ImageButton
                    try { index = ((GridViewRow)((ImageButton)e.CommandSource).Parent.Parent).RowIndex; }
                    //Se estiver usando ButtonField
                    catch { index = Convert.ToInt32(e.CommandArgument); }
                    this.Controladora.Selecionar(Convert.ToInt32(grdListagem.DataKeys[index].Value));
                    this.Controladora.Excluir();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "QuickMessage", "ExibirMensagem('Registro <b>exclu�do</b> com sucesso.');", true);
                    this.SetarModoPagina(ModosPagina.Listar);
                }
            }
            catch (Exception ex)
            {
                this.ExibirExcecao(ex);
            }
        }

        protected override void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (this.PaginaSegura)
                    {
                        if ((Contexto.Seguranca == null) || (!Contexto.Seguranca.Ler(Page.GetType().BaseType.Name)))
                            Response.Redirect("AcessoNegado.aspx");
                    }
                    //PopularGridView();
                    SetarModoPagina(ModosPagina.Listar);
                    DefinirCamposBusca();
                    ProTextBox txtBusca = (ProTextBox)this.LocalizarControle("txtBusca", this.Controls);
                    Focus(txtBusca);
                    //base.Page_Load(sender, e);
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

        protected virtual void grdListagem_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected virtual void grdListagem_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                ProGridView grdListagem = (ProGridView)this.LocalizarControle("grdListagem", this.Controls);
                grdListagem.SelectedIndex = e.NewEditIndex;
                this.grdListagem_SelectedIndexChanged(sender, EventArgs.Empty);
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
                if (PaginaSegura)
                {
                    if (!Contexto.Seguranca.Deletar(this.GetType().BaseType.Name))
                        throw new ViolacaoRegraException("Usu�rio n�o tem permiss�o para <b>excluir</b> registro.");
                }
                this.Controladora.Excluir();
                ProPanel pnlManutencao = (ProPanel)this.LocalizarControle("pnlManutencao", this.Controls);
                pnlManutencao.Clear();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "QuickMessage", "ExibirMensagem('Registro <b>exclu�do</b> com sucesso.');", true);
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
                if (PaginaSegura)
                {
                    if (ModoPagina == ModosPagina.Inserir)
                    {
                        if (!Contexto.Seguranca.Inserir(this.GetType().BaseType.Name))
                            throw new ViolacaoRegraException("Usu�rio n�o tem permiss�o para <b>inserir</b> registro.");
                    }
                    else if (ModoPagina == ModosPagina.Alterar)
                    {
                        if (!Contexto.Seguranca.Atualizar(this.GetType().BaseType.Name))
                            throw new ViolacaoRegraException("Usu�rio n�o tem permiss�o para <b>alterar</b> registro.");
                    }
                }
                ProPanel pnlManutencao = (ProPanel)this.LocalizarControle("pnlManutencao", this.Controls);
                if (this.Controladora.Salvar(pnlManutencao.GetFormData()) == Pro.Dal.CrudActionTypes.Insert)
                {
                    pnlManutencao.Clear();
                    this.Controladora.PrepararInclusao();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "QuickMessage", "ExibirMensagem('Registro <b>inserido</b> com sucesso.');", true);
                }
                else
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "QuickMessage", "ExibirMensagem('Registro <b>atualizado</b> com sucesso.');", true);
            }
            catch (Exception ex)
            {
                this.ExibirExcecao(ex);
            }
        }
        #endregion

        #region M�todos
        /// <summary>
        /// Seta o foco no controle informado.
        /// </summary>
        /// <param name="control"></param>
        protected override void Focus(Control control)
        {
            ScriptManager.GetCurrent(this).SetFocus(control);
        }
        protected virtual void Selecionar(int id)
        {
            try
            {
                ProPanel pnlManutencao = (ProPanel)this.LocalizarControle("pnlManutencao", this.Controls);
                //ProGridView grdListagem = (ProGridView)this.LocalizarControle("grdListagem", this.Controls);

                SetarModoPagina(ModosPagina.Alterar);
                pnlManutencao.SetFormData(this.Controladora.Selecionar(id));
                //grdListagem.SelectedIndex = -1;
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
                MultiView mtvPrincipal = (MultiView)this.LocalizarControle("mtvPrincipal", this.Controls);
                Button btnExcluir = (Button)this.LocalizarControle("btnExcluir", this.Controls);
                Button btnSalvar = (Button)this.LocalizarControle("btnSalvar", this.Controls);
                Button btnListagem = (Button)this.LocalizarControle("btnListagem", this.Controls);
                Label lblTitulo = (Label)this.LocalizarControle("lblTitulo", this.Controls);
                ProPanel pnlManutencao = (ProPanel)this.LocalizarControle("pnlManutencao", this.Controls);
                ProPanel pnlConsulta = (ProPanel)this.LocalizarControle("pnlConsulta", this.Controls);
                ProGridView grdListagem = (ProGridView)this.LocalizarControle("grdListagem", this.Controls);

                btnSalvar.Visible = true;
                btnListagem.Visible = true;
                switch (modo)
                {
                    case ModosPagina.Listar:
                        PopularGridView();
                        lblTitulo.Text = "<b>" + this.TituloPagina + ":</b> Consulta";
                        pnlConsulta.Visible = true;
                        mtvPrincipal.ActiveViewIndex = 0;
                        btnExcluir.Visible = false;
                        btnSalvar.Visible = false;
                        btnListagem.Visible = false;
                        break;
                    case ModosPagina.Inserir:
                        lblTitulo.Text = "<b>" + this.TituloPagina + ":</b> Inclus�o";
                        pnlManutencao.Clear();
                        mtvPrincipal.ActiveViewIndex = 1;
                        btnExcluir.Visible = false;
                        pnlConsulta.Visible = false;
                        grdListagem.SelectedIndex = -1;
                        this.grdListagem_SelectedIndexChanged(this, EventArgs.Empty);
                        if (FocoInicial != null) Focus(FocoInicial);
                        break;
                    case ModosPagina.Alterar:
                        lblTitulo.Text = "<b>" + this.TituloPagina + ":</b> Altera��o";
                        mtvPrincipal.ActiveViewIndex = 1;
                        btnExcluir.Visible = true;
                        pnlConsulta.Visible = false;
                        if (FocoInicial != null) Focus(FocoInicial);
                        break;
                }
                VerificarPermissoes();
            }
            catch (Exception ex)
            {
                this.ExibirExcecao(ex);
            }
        }
        private void VerificarPermissoes()
        {
            if (PaginaSegura)
            {
                if (!Contexto.Seguranca.Inserir(this.GetType().BaseType.Name))
                {
                    Button btnNovo = (Button)Page.Form.FindControl("cphPadrao").FindControl("mtvPrincipal").Controls[0].FindControl("btnNovo");
                    if (btnNovo != null)
                        btnNovo.Visible = false;

                    Button btnNovoCadastro = (Button)Page.Form.FindControl("cphPadrao").FindControl("btnNovoCadastro");
                    if (btnNovoCadastro != null)
                        btnNovoCadastro.Visible = false;
                }
                else
                {
                    if (ModoPagina == ModosPagina.Inserir)
                    {
                        Button btnSalvar = (Button)Page.Form.FindControl("cphPadrao").FindControl("btnSalvar");
                        if (btnSalvar != null)
                            btnSalvar.Visible = true;
                    }
                }

                if (!Contexto.Seguranca.Atualizar(this.GetType().BaseType.Name))
                {
                    if (ModoPagina == ModosPagina.Alterar)
                    {
                        Button btnSalvar = (Button)Page.Form.FindControl("cphPadrao").FindControl("btnSalvar");
                        if (btnSalvar != null)
                            btnSalvar.Visible = false;
                    }
                }

                if (!Contexto.Seguranca.Deletar(this.GetType().BaseType.Name))
                {
                    Button btnExcluir = (Button)Page.Form.FindControl("cphPadrao").FindControl("btnExcluir");
                    if (btnExcluir != null)
                        btnExcluir.Visible = false;
                }
            }
        }
        #endregion
    }
}
