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

namespace Web
{
    /// <summary>
    /// Classe base para as demais páginas do sistema.
    /// </summary>
    public class RelatorioBase : PaginaBase
    {
        #region Propriedades
        public NameValueCollection TiposExportacao
        {
            get
            {
                NameValueCollection nvc = new NameValueCollection();
                nvc.Add("DOC","DOC");
                //nvc.Add("HTML","HTML");
                nvc.Add("PDF","PDF");
                //nvc.Add("RTF","RTF");
                nvc.Add("XLS","XLS");
                return nvc;
            }

        }

        #endregion

        #region Eventos
        protected override void Page_Init(object sender, EventArgs e)
        {
            base.Page_Init(sender, e);
            Button btnVisualizar = (Button)Page.Form.FindControl("cphPadrao").FindControl("btnVisualizar");
            if(btnVisualizar != null)
            btnVisualizar.Click +=new EventHandler(btnVisualizar_Click);
        }

        protected override void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Pro.Controls.ProRadioButtonList rblFormatoExportacao = (Pro.Controls.ProRadioButtonList)Page.Form.FindControl("cphPadrao").FindControl("rblFormatoExportacao");
                ProLabel lblTitulo = (ProLabel)Page.Form.FindControl("cphPadrao").FindControl("lblTitulo");
                if (lblTitulo != null)
                    lblTitulo.Text = this.TituloPagina;

                if (rblFormatoExportacao != null)
                {
                    rblFormatoExportacao.DataSource = TiposExportacao;
                    rblFormatoExportacao.DataBind();
                    rblFormatoExportacao.SelectedIndex = 1;
                }
            }
        }
        protected virtual void btnVisualizar_Click(object sender, EventArgs e)
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

        public void ExibirRelatorio(string nome)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), nome, "window.open('Relatorios/frmGerarRelatorio.aspx?rpt=" + nome + "','" + nome + "','location=0,status=1,resizable=1,scrollbars=1,width=800,height=600,top=10,left=10');", true); 
        }
        #endregion
    }
}