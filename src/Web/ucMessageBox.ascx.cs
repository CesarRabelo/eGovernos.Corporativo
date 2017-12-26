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

using Platinium.Negocio;
using Pro.Utils;
using Web;
using Atom.ClientWeb;
using Atom.ClientNegocio;

namespace Platinium.Web.Msg
{
    public partial class ucMessageBox : System.Web.UI.UserControl
    {
		protected string LinkName = string.Empty;
		

        protected void Page_Load(object sender, EventArgs e)
        {
			LinkName = lbtReportarErro.ClientID;
			if (!IsPostBack)
				btnEnviar.OnClientClick = "document.getElementById('" + LinkName + "').click();";
        }

		protected void btnEnviar_Click(object sender, EventArgs e)
		{
			try
			{
				Cryptography oCryptography = new Cryptography(System.Configuration.ConfigurationManager.AppSettings["MailCredentials"]);
				string sEmail = oCryptography["Email"];
                if (!string.IsNullOrEmpty(Sessao.EmailUsuario))
                    sEmail = Sessao.EmailUsuario;

				string sMensagem = "<b>IP:</b> : " + Request.ServerVariables["REMOTE_ADDR"] + "<br>";
				sMensagem += "<b>Usuário:</b> : " + Sessao.NomeUsuario + "<br>";
				sMensagem += "<b>Página:</b> : " + this.Page.Request.PhysicalPath + "<br>";
				sMensagem += "<br><br><b>Mensagem:</b> : <br><br>" + txtMensagem.Text;
				Email.SendReport(sEmail, "miguelvander@gmail.com", "Reporte Imobium", sMensagem);
				this.cpeMensagem.Collapsed = true;
				ExibirAlerta(TiposMensagem.Informacao, "Envio de Reporte", "Reporte enviado com sucesso!");
			}
			catch 
			{
				this.cpeMensagem.Collapsed = true;
				this.ExibirAlerta(TiposMensagem.Erro, "Envio de Reporte", "Ocorreram problemas que inviabilizaram o envio do seu reporte.");
			}
		}

		protected virtual void ExibirAlerta(TiposMensagem tipo, string titulo, string mensagem)
		{
			ScriptManager.RegisterStartupScript(this, this.GetType(), "Mensagem", "ExibirAlerta('" + tipo + "','" + titulo + "','" + mensagem + "');", true);
		}
    }
}