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

using Pro.Utils;
using Negocio;

namespace Web
{
    public partial class frmInicializarSistema : PaginaBase
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.Controladora = new InicializarSistema();
                ((MasterPage)Master).FindControl("ibtSair").Visible = false;
                ((MasterPage)Master).FindControl("ibtNotificacao").Visible = false;
                ((MasterPage)Master).FindControl("UcToolBar1").Visible = false;
                ((MasterPage)Master).FindControl("lblUsuario").Visible = false;
                ((MasterPage)Master).FindControl("imgUsuario").Visible = false;

                if (!((InicializarSistema)this.Controladora).ExistemUsuarios)
                    mtvInicializar.ActiveViewIndex = 0;
                txtEmail.Attributes.Add("onkeypress", "if(event.which || event.keyCode){if((event.which == 13) || (event.keyCode == 13)){event.keyCode=0; document.getElementById('" + btnCadastrarUsuario.ClientID + "').click();return false;}else{return true;}}");
                txtLogin.Attributes.Add("onkeypress", "if(event.which || event.keyCode){if((event.which == 13) || (event.keyCode == 13)){event.keyCode=0; document.getElementById('" + btnCadastrarUsuario.ClientID + "').click();return false;}else{return true;}}");
                txtNome.Attributes.Add("onkeypress", "if(event.which || event.keyCode){if((event.which == 13) || (event.keyCode == 13)){event.keyCode=0; document.getElementById('" + btnCadastrarUsuario.ClientID + "').click();return false;}else{return true;}}");
                txtSenha.Attributes.Add("onkeypress", "if(event.which || event.keyCode){if((event.which == 13) || (event.keyCode == 13)){event.keyCode=0; document.getElementById('" + btnCadastrarUsuario.ClientID + "').click();return false;}else{return true;}}");

                Focus(txtNome);
            }
        }

        protected void btnCadastrarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                ((InicializarSistema)this.Controladora).CadastrarUsuarioInicial(pnlDadosUsuario.GetFormData());
                Response.Redirect("frmLogin.aspx");
            }
            catch (Exception ex)
            {
                ExibirExcecao(ex);
            }
        }
    }
}
