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
using System.Drawing;
using System.Text;
using Platinium.Negocio;
using Platinium.Web;
using Negocio;
using Web;
using System.Collections.Generic;
using Atom.ClientWeb;

namespace Platinium.Web
{
    public partial class Licenciada : PaginaBase
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.TituloPagina = "Dados da Licenciada";
                this.Controladora = new ManterLicenciada();
                base.Page_Load(sender, e);
                pnlManutencao.SetFormData(((ManterLicenciada)this.Controladora).Selecionar());
                //ucEndereco1.Novo();
                //try
                //{
                //    ucEndereco1.Carregar(((ManterLicenciada)this.Controladora).GetEnderecoIDStatic);
                //}
                //catch
                //{
                //    ucEndereco1.Limpar();
                //    ucEndereco1.PrepararInclusao();
                //}
                //Focus(txtRazaoSocial);
            }
            //FocoInicial = txtAnoElaboracao;
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                ((ManterLicenciada)this.Controladora).Salvar(pnlManutencao.GetFormData());
                ScriptManager.RegisterStartupScript(this, this.GetType(), "QuickMessage", "ExibirMensagem('Registro <b>atualizado</b> com sucesso.');", true);
            }
            catch (Exception ex)
            {
                ExibirExcecao(ex);
            }
            //try
            //{
            //    Dictionary<string, object> dicionarioEndereco = ucEndereco1.RetornarDicionario();
            //    Dictionary<string, object> dicionario = pnlManutencao.GetFormData();
            //    ucEndereco1.CssNaoObrigatorio();
            //    int cont = 0;
            //    foreach (KeyValuePair<string, object> aux in dicionarioEndereco)
            //    {
            //        if ((aux.Value == null) && (aux.Key != "Complemento"))
            //        {
            //            cont++;
            //        }
            //    }
            //    if (cont == 0)
            //    {
            //        int idEndereco = ucEndereco1.SalvarRetornandoID();
            //        dicionario.Add("Endereco", idEndereco);
            //    }
            //    else if ((cont < dicionarioEndereco.Count - 1) && (cont > 0))
            //    {
            //        ExibirExcecao(ucEndereco1.ValidarCampos());
            //    }

            //    int id = ((ManterLicenciada)Controladora).SalvarRetornandoId(dicionario);
            //    base.Page_Load(sender, e);
            //}
            //catch (Exception ex)
            //{
            //    this.ExibirExcecao(ex);
            //}
        }
    }
}