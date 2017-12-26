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

namespace Web
{
    /// <summary>
    /// Classe base para as demais páginas do sistema.
    /// </summary>
    public class UserControlBase : System.Web.UI.UserControl
    {
        #region Propriedades
        /// <summary>
        /// Essa variável indica se a página irá utilizar controle de acesso para validar sua visualização.
        /// </summary>
        public bool PaginaSegura
        {
            get { return ViewState["$AtomSeguranca$"] == null ? false : (bool)ViewState["$AtomSeguranca$"]; }
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
                Cache.Insert(ViewState["$Controladora$"].ToString(), value, null, System.Web.Caching.Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes(20),System.Web.Caching.CacheItemPriority.NotRemovable,null);
                
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
                ProLabel lblTitulo = (ProLabel)Page.Form.FindControl("cphPadrao").FindControl("lblTitulo");
                lblTitulo.Text = this.TituloPagina;
            }
        }
        #endregion

        #region Métodos
        protected virtual void ExibirExcecao(Exception excecao)
        {
            System.Text.StringBuilder sMensagens = new System.Text.StringBuilder();

            switch (excecao.GetType().Name)
            {
                case "CampoNuloOuInvalidoException":
                    foreach (string key in ((CampoNuloOuInvalidoException)excecao).Mensagens.Keys)
                        sMensagens.Append("<li> " + ((CampoNuloOuInvalidoException)excecao).Mensagens[key].Replace("'", "") + "<br />");

                    this.ExibirAlerta(TiposMensagem.Alerta,"Campo inválido", sMensagens.ToString());
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

                    this.ExibirAlerta(TiposMensagem.Erro,"Erro na execução", sExecucaoException);
                    break;
                case "ViolacaoRegraException":
                    this.ExibirAlerta(TiposMensagem.Alerta,"Operação inválida", excecao.Message);
                    break;
                case "NotAutorizedException":
                    string sMsg = excecao.Message.Replace("'", "\"");
                    if (sMsg.IndexOf("<b>Consultar</b>") != -1)
                    {
                        View vwListagem = (View)Page.Form.FindControl("cphPadrao").FindControl("vwListagem");
                        if (vwListagem != null)
                            foreach(Control ctrl in vwListagem.Controls)
                                ctrl.Visible = false;

                        ProPanel pnlConsulta = (ProPanel)Page.Form.FindControl("cphPadrao").FindControl("pnlConsulta");
                        if (pnlConsulta != null)
                            pnlConsulta.Enabled = false;

                    }
                    this.ExibirAlerta(TiposMensagem.Alerta,"Operação não autorizada", sMsg);
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

        protected virtual void ExibirAlerta(TiposMensagem tipo,string titulo, string mensagem)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Mensagem", "ExibirAlerta('" + tipo + "','" + titulo + "','" + mensagem + "');", true);
        }
        /// <summary>
        /// Seta o foco no controle informado.
        /// </summary>
        /// <param name="control"></param>
        protected virtual void Focus(Control control)
        {
            ScriptManager.GetCurrent(this.Page).SetFocus(control);
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
        #endregion
    }
}