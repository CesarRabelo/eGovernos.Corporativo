using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Platinium.Web
{
    public partial class ucToolBar : System.Web.UI.UserControl
    {
        #region Variáveis e Propriedades
        //Dictionary<Botao, ImageButton> dctBotoes;
        #endregion

        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            Context.Request.Browser.Adapters.Clear(); 
        }

        protected void Icone_Click(object sender, ImageClickEventArgs e)
        {
            switch (((ImageButton)sender).CommandName)
            {
                case "Cliente":
                    Response.Redirect("frmCliente.aspx",false);
                    break;
                case "Condominio":
					Response.Redirect("frmCondominio.aspx", false);
                    break;
				case "Boletos":
					Response.Redirect("frmListarBoletos.aspx", false);
                    break;
				case "BaixaBoleto":
					Response.Redirect("frmBaixaBoleto.aspx", false);
					break;
                case "Imovel":
					Response.Redirect("frmImovel.aspx", false);
                    break;
                case "ContratoAdministracao":
					Response.Redirect("frmContratoAdministracao.aspx", false);
                    break;
                case "ContratoLocacao":
					Response.Redirect("frmContratoLocacao.aspx", false);
                    break;
                case "Senha":
					Response.Redirect("frmMudarSenha.aspx", false);
                    break;
                case "Usuario":
					Response.Redirect("frmUsuario.aspx", false);
                    break;
                case "Perfil":
					Response.Redirect("frmPerfil.aspx", false);
                    break;
                case "Repasse":
                    Response.Redirect("frmListarRepasses.aspx", false);
                    break;

            }
            
        }

       #endregion

        #region Métodos
        //public void Inicializar()
        //{
        //    dctBotoes = new Dictionary<Botao, ImageButton>();
        //    //dctBotoes.Add(Botao.Clientes, this.ibtClientes);
        //    //dctBotoes.Add(Botao.ContratoAdm, this.ibtContratoAdm);
        //    //dctBotoes.Add(Botao.ContratoLocacao, this.ibtContratoLocacao);
        //    //dctBotoes.Add(Botao.Imovel, this.ibtImovel);
        //    //dctBotoes.Add(Botao.Condominio, this.ibtCondominio);

        //    foreach (KeyValuePair<Botao, ImageButton> kvp in dctBotoes)
        //    {
        //        kvp.Value.Enabled = false;
        //        kvp.Value.ImageUrl = kvp.Value.ImageUrl.Replace("On.gif", "Off.gif");
        //    }
        //}
        //public void CarregarBotoes(params Botao[] botoes)
        //{
        //    Inicializar();
        //    foreach (Botao key in botoes)
        //    {
        //        dctBotoes[key].Enabled = true;
        //        dctBotoes[key].ImageUrl = dctBotoes[key].ImageUrl.Replace("Off.gif", "On.gif");
        //    }
        //    dctBotoes[Botao.Clientes].Enabled = true;
        //    dctBotoes[Botao.Clientes].ImageUrl = dctBotoes[Botao.Clientes].ImageUrl.Replace("Off.gif", "On.gif");

        //    dctBotoes[Botao.Imovel].Enabled = true;
        //    dctBotoes[Botao.Imovel].ImageUrl = dctBotoes[Botao.Imovel].ImageUrl.Replace("Off.gif", "On.gif");

        //    dctBotoes[Botao.ContratoAdm].Enabled = true;
        //    dctBotoes[Botao.ContratoAdm].ImageUrl = dctBotoes[Botao.ContratoAdm].ImageUrl.Replace("Off.gif", "On.gif");

        //    dctBotoes[Botao.ContratoLocacao].Enabled = true;
        //    dctBotoes[Botao.ContratoLocacao].ImageUrl = dctBotoes[Botao.ContratoLocacao].ImageUrl.Replace("Off.gif", "On.gif");

        //    dctBotoes[Botao.Condominio].Enabled = true;
        //    dctBotoes[Botao.Condominio].ImageUrl = dctBotoes[Botao.Condominio].ImageUrl.Replace("Off.gif", "On.gif");

        //}
        #endregion



    }
}