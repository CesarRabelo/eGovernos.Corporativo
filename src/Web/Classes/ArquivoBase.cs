using System;
using System.Collections.Specialized;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Pro.Controls;
using Atom.ClientWeb;

namespace Web
{
    /// <summary>
    /// Classe base para as demais páginas do sistema.
    /// </summary>
    public class ArquivoBase : PaginaBase
    {
        #region Propriedades
        #endregion

        #region Eventos
        protected override void Page_Init(object sender, EventArgs e)
        {
            base.Page_Init(sender, e);
            Button btnGerar = (Button)Page.Form.FindControl("cphPadrao").FindControl("btnGerar");
            if (btnGerar != null)
                btnGerar.Click += new EventHandler(btnGerar_Click);
        }
        protected override void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ProLabel lblTitulo = (ProLabel)Page.Form.FindControl("cphPadrao").FindControl("lblTitulo");
                if (lblTitulo != null)
                    lblTitulo.Text = this.TituloPagina;
            }
        }
        protected virtual void btnGerar_Click(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                this.ExibirExcecao(ex);
            }
        }
        #endregion

        #region Métodos

        public void ExibirArquivo(string nome)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), nome, "window.open('Arquivos/frmGerarArquivo.aspx?arq=" + nome + "','" + nome + "','location=0,status=1,resizable=1,scrollbars=1,width=800,height=600,top=10,left=10');", true); 
        }
        #endregion
    }
}