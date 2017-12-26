using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Pro.Controls;
using Pro.Utils;
using Negocio;

namespace Web
{
    /// <summary>
    /// Classe base para as demais páginas do sistema.
    /// </summary>
    public class PaginaBase : System.Web.UI.Page
    {
        #region Propriedades

        /// <summary>
        /// Essa variável indica se a página irá utilizar controle de acesso para validar sua visualização.
        /// </summary>
        public bool PaginaSegura
        {
            get { return ViewState["$AtomSeguranca$"] == null ? true : (bool)ViewState["$AtomSeguranca$"]; }
            set { ViewState["$AtomSeguranca$"] = value; }
        }

        protected object Controladora
        {
            get
            {
                if (ViewState["$Controladora$"] == null)
                    throw new Exception("Controladora não encontrada.");
                if (Cache[ViewState["$Controladora$"].ToString()] == null)
                    throw new Exception("Controladora não encontrada.");
                return Cache[ViewState["$Controladora$"].ToString()];
            }
            set
            {
                if (ViewState["$Controladora$"] == null)
                {
                    ViewState["$Controladora$"] = Session.SessionID + Guid.NewGuid().ToString();
                }
                Cache.Insert(ViewState["$Controladora$"].ToString(), value, null, System.Web.Caching.Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes(20), System.Web.Caching.CacheItemPriority.NotRemovable, null);

            }
        }

        protected string TituloPagina
        {
            get { return ViewState["$TituloPagina$"] == null ? "" : ViewState["$TituloPagina$"].ToString(); }
            set { ViewState["$TituloPagina$"] = value; }
        }

        #endregion

        #region Eventos
        protected virtual void Page_Init(object sender, EventArgs e)
        {
            Response.AddHeader("Content-Type", "text/html; charset=utf-8");
        }

        protected virtual void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    ProLabel lblTitulo = (ProLabel)Page.Form.FindControl("cphPadrao").FindControl("lblTitulo");
                    if (lblTitulo != null)
                        lblTitulo.Text = this.TituloPagina;

                    //if (this.Seguranca)
                    //{
                    //    if ((Contexto.Seguranca == null) || (!Contexto.Seguranca.Ler(Page.GetType().BaseType.Name)))
                    //        Response.Redirect("AcessoNegado.aspx");
                    //}

                }
                catch { }
            }
        }
        #endregion

        #region Métodos
        public virtual void MensagemConfirmacao(string mensagem)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "QuickMessage", string.Format("ExibirMensagem('{0}');", mensagem), true);
        }

        public virtual void ExibirExcecao(Exception excecao)
        {
            System.Text.StringBuilder sMensagens = new System.Text.StringBuilder();

            switch (excecao.GetType().Name)
            {
                case "RegraNegocioException":
                    sMensagens.Append(excecao.Message);
                    this.ExibirAlerta(TiposMensagem.Erro, "Erro no processo", sMensagens.ToString());
                    break;
                case "CampoNuloOuInvalidoException":
                    foreach (string key in ((CampoNuloOuInvalidoException)excecao).Mensagens.Keys)
                        sMensagens.Append("<li> " + ((CampoNuloOuInvalidoException)excecao).Mensagens[key].Replace("'", "") + "<br>");

                    this.ExibirAlerta(TiposMensagem.Alerta, "Campo inválido", sMensagens.ToString());
                    break;
                case "ExecucaoException":
                    string sExecucaoException = string.Empty;
                    if (excecao.Message.IndexOf("#") > 0)
                    {
                        string[] aMensagens = excecao.Message.Split(Convert.ToChar("#"));
                        sExecucaoException = aMensagens[0];
                    }
                    else
                        sExecucaoException = excecao.Message.Replace("'", "").Replace("\"", "").Replace("\n", "").Replace("\r", "");

                    this.ExibirAlerta(TiposMensagem.Erro, "Erro na execução", sExecucaoException);
                    break;
                case "ViolacaoRegraException":
                    this.ExibirAlerta(TiposMensagem.Alerta, "Operação inválida", excecao.Message);
                    break;

                case "TargetInvocationException":
                    if (excecao.InnerException != null)
                        ExibirExcecao(excecao.InnerException);
                    break;
                case "NaoAutorizadoException":
                case "NotAutorizedException":
                    string sMsg = excecao.Message.Replace("'", "\"");
                    if (sMsg.IndexOf("<b>Consultar</b>") != -1)
                    {
                        View vwListagem = (View)Page.Form.FindControl("cphPadrao").FindControl("vwListagem");
                        if (vwListagem != null)
                            foreach (Control ctrl in vwListagem.Controls)
                                ctrl.Visible = false;

                        ProPanel pnlConsulta = (ProPanel)Page.Form.FindControl("cphPadrao").FindControl("pnlConsulta");
                        if (pnlConsulta != null)
                            pnlConsulta.Enabled = false;

                    }
                    this.ExibirAlerta(TiposMensagem.Alerta, "Operação não autorizada", sMsg);
                    break;
                case "NaoAutenticadoException":
                    HttpContext.Current.Items.Add("NaoAutenticado", excecao.Message);
                    Server.Transfer("frmLogin.aspx");
                    break;
                case "GenericaException":
                    string sMensagem = string.Empty;
                    sMensagem = excecao.Message.Replace("'", "").Replace("\"", "").Replace("\n", "").Replace("\r", "");

                    this.ExibirAlerta(TiposMensagem.Erro, "Erro na execução", sMensagem);
                    break;
                default:
                    GenericaException ex = new GenericaException(excecao.Message, excecao);
                    this.ExibirAlerta(TiposMensagem.Erro, "Erro na execução", "(" + ex.IdExcecao + "): Erro não identificado durante a execução da operação.");
                    break;
            }
        }

        protected virtual void ExibirAlerta(TiposMensagem tipo, string titulo, string mensagem)
        {
            mensagem = mensagem.Replace("'", "").Replace("\"", "").Replace("\n", "").Replace("\r", "");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Mensagem", "ExibirAlerta('" + tipo + "','" + titulo + "','" + mensagem + "');", true);
        }
        /// <summary>
        /// Seta o foco no controle informado.
        /// </summary>
        /// <param name="control"></param>
        protected virtual void Focus(Control control)
        {
            ScriptManager.GetCurrent(this).SetFocus(control);
        }

        protected Control LocalizarControle(string controlID, ControlCollection colecao)
        {
            Control meucontrole = null;
            foreach (Control ctrl in colecao)
            {
                if (ctrl.ID != null && ctrl.ID.ToUpper() == controlID.ToUpper())
                {
                    meucontrole = ctrl;
                    break;
                }

                if (ctrl.HasControls())
                {
                    meucontrole = LocalizarControle(controlID, ctrl.Controls);
                    if (meucontrole != null)
                        break;
                }
            }
            return meucontrole;
        }

        static public void Redirect(string url, System.Web.UI.Page Page)
        {
            System.Text.StringBuilder oStringBuilder = new System.Text.StringBuilder();
            oStringBuilder.Append("var a = document.createElement('a');");
            oStringBuilder.Append("a.href = '");
            oStringBuilder.Append(url);
            oStringBuilder.Append("';document.body.appendChild(a);a.click();");
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", oStringBuilder.ToString(), true);
        }
        #endregion
    }
}