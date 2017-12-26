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
using Platinium.Web;
using Platinium.Negocio;
using Web;
using Atom.ClientNegocio;

namespace Platinium.Web
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        public bool AcessoLiberado
        {
            get { return ViewState["$AcessoLiberado$"] == null ? false : true; }
            set { ViewState["$AcessoLiberado$"] = value; }
        }

        protected string VersionInfo
        {
            get
            {
                return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        protected string Descricao
        { get {
            string titulo = ".:: SGP :: Corporativo ::. " + VersionInfo;

            if (ConfigurationManager.AppSettings["Licenciada"] != null)
                titulo += " || " + ConfigurationManager.AppSettings["Licenciada"] + " || ";

            return titulo;
        } }
         
        public bool MostrarToolbar
        {
            get
            {
                return true;
                //UcToolBar1.Visible; 
            }
            //set { UcToolBar1.Visible = value; }
        }

        public bool MostrarDadosUsuarioLogado
        {
            set
            {
                //ibtSair.Visible = value;
                //ibtNotificacao.Visible = value;
                //lblUsuario.Visible = value;
                //imgUsuario.Visible = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ((Session["Exception"] != null) && (this.Page.GetType().BaseType.Name != "Default"))
                    Response.Redirect("Default.aspx", false);
                else if (Contexto.Seguranca == null) //Se não estiver logado redireciona para login
                    RedirecionarLogin();
                else
                {
                    //if ((this.Page.GetType().BaseType.Name != "AcessoNegado"))
                    //{
                    //    if (((PaginaBase)Parent).PaginaSegura)
                    //        Response.Redirect("AcessoNegado.aspx", false);
                    //}

                    //lblSecretaria.Text = Contexto.ContextoSistema.GrupoNome;
                    lblUsuario.Text = Contexto.Seguranca.UsuarioNome + " (" + Application["num_usuarios"] + " usuários online)";
                    lblGrupo.Text = Contexto.Seguranca.GrupoNome;
                    AcessoLiberado = true;
                }
            }
            //lblRodape.Text = this.Descricao;
            //lblVersao.Text = "Copyright 2010 - Todos os direitos reservados a Íon TI - Versão: " + VersionInfo;

            this.Page.Title = this.Descricao;
            Context.Request.Browser.Adapters.Clear();
        }
        private void RedirecionarLogin()
        {
            if (ConfigurationManager.AppSettings["Atom"] != null)
                Response.Redirect(ConfigurationManager.AppSettings["Atom"], false);
        }
        #region Métodos
        public void Focus(string clientId)
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Focus", "try{document.getElementById('" + clientId + "').focus();}catch(err){}", false);
        }
        //public void CarregarFiltros(params TipoFiltro[] filtros)
        //{
        //    this.ucFiltros.CarregarFiltros(filtros);
        //}
        #endregion

        protected void ibtLogo_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Default.aspx", false);
        }

        protected void tmrSessao_Tick(object sender, EventArgs e)
        {
            Sessao.LogOff();
            if(ConfigurationManager.AppSettings["Atom"] != null)
                Response.Redirect(ConfigurationManager.AppSettings["Atom"], false);
        }

        protected void ibtNotificacao_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("frmNotificacao.aspx", false);
        }

        protected void ibtExit_Click(object sender, EventArgs e)
        {
            if (ConfigurationManager.AppSettings["Atom"] != null)
            {
                Sessao.LogOff();
                Response.Redirect(ConfigurationManager.AppSettings["Atom"], false);
            }
        }


    }
}
