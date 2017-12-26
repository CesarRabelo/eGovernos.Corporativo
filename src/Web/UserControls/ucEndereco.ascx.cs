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
using Pro.Utils;
using Web;
using Atom.ClientWeb;
using Platinium.Negocio;

namespace Platinium.Web
{
    public partial class ucEndereco : System.Web.UI.UserControl
    {

        #region Propriedades e métodos
        private int iIdEndereco;
        private bool bFocus;

        public int IdEndereco
        {
            get { return iIdEndereco; }
        }

        public string CEP
        {
            get { return txtCep.Text; }
            set { txtCep.Text = value; }
        }

        public string Numero
        {
            get { return txtNumero.Text; }
            set { txtNumero.Text = value; }
        }
        public string Complemento
        {
            get { return txtComplemento.Text; }
            set { txtComplemento.Text = value; }
        }
        protected ManterEndereco Controladora
        {
            get { return Session["$ControladoraUC$"] == null ? null : (ManterEndereco)Session["$ControladoraUC$"]; }
            set { Session["$ControladoraUC$"] = value; }
        }
        #endregion

        #region Eventos
        public void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!this.IsPostBack)
                {
                    this.Controladora = new ManterEndereco();

                    txtCep.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if((event.which == 13) || (event.keyCode == 13)){event.keyCode=0; document.getElementById('" + btnBuscaCep.ClientID + "').click();return false;}else{return true;}}");
                    ddlEstado.DataSource = new Listas().Estado;
                    ddlEstado.DataBind();
                    ddlEstado.Items.Insert(0, new ListItem());
                    aceLogradouro.OnClientItemSelected = aceLogradouro.ClientID + "_OnItemSelected";


                    string sScript = "function " + aceLogradouro.ClientID + "_OnItemSelected(obj,arg){" +
                    " var Itens = arg._text.split(' | '); " +
                    " document.getElementById('" + txtCep.ClientID + "').value = Itens[0]; " +
                    " document.getElementById('" + txtLogradouro.ClientID + "').value = Itens[1]; " +
                    " document.getElementById('" + ddlBairro.ClientID + "').value = Itens[3]; " +
                    "document.getElementById('" + txtNumero.ClientID + "').focus();}";
                    Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "Endereco", sScript, true);
                }
            }
            catch (Exception ex)
            {
                this.ExibirExcecao(ex);
            }
        }
        public void btnBuscaCep_Click(object sender, EventArgs e)
        {
            if (txtCep.Text.Length != 10 && txtCep.Text.Length != 9)
                this.ExibirAlerta(TiposMensagem.Alerta, "CEP", "Preencha todos os números do CEP para efetuar Isento busca.<br> Ex.: 60000-000");
            else
                BuscarEndereco(this.txtCep.Text.Replace(".", ""));
        }
        protected void ddlEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlEstado.SelectedValue != "")
                {
                    ddlLocalidade.Enabled = true;
                    ddlLocalidade.DataBind(new Listas().LocalidadeEnd(ddlEstado.SelectedValue));
                    this.Focus(ddlLocalidade);
                }
                else
                {
                    ddlLocalidade.SelectedIndex = -1;
                    ddlLocalidade.Enabled = false;
                    ddlBairro.SelectedIndex = -1;
                    ddlBairro.Enabled = false;
                    aceLogradouro.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                this.ExibirExcecao(ex);
            }
        }
        protected void ddlMunicipio_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlLocalidade.SelectedValue != "")
                {
                    ddlBairro.Enabled = true;
                    ddlBairro.DataSource = new Listas().Bairro(ddlEstado.SelectedValue, ddlLocalidade.SelectedValue);
                    ddlBairro.DataBind();
                    ddlBairro.Items.Insert(0, new ListItem());
                    this.Focus(txtLogradouro);
                    aceLogradouro.Enabled = true;
                    aceLogradouro.ContextKey = txtCep.Text + "|" + ddlEstado.SelectedItem.Text + "|" + ddlLocalidade.SelectedItem.Text;
                }
                else
                {
                    ddlBairro.SelectedIndex = -1;
                    ddlBairro.Enabled = false;
                    aceLogradouro.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                this.ExibirExcecao(ex);
            }
        }

        public void btnShowMap_Click(object sender, EventArgs e)
        {
            string end = txtLogradouro.Text + " " + txtNumero.Text + " " + ddlBairro.Text + " " + ddlLocalidade.Text + " " + ddlEstado.Text;
            end = normatizarString(end);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), end, "window.open('../frmMapa.aspx?logradouro=" + end + "','location=0,status=1,resizable=1,scrollbars=1,width=800,height=600,top=10,left=10');", true);
        }

        public string normatizarString(string str)
        {
            return str.Replace(" ", "%20").Replace(".", "%2E").Replace(",", "%20").Replace(",", "%20").Replace("À", "%C0").Replace("Á", "%C1").Replace("Â", "%C2").Replace("Ã", "%C3")
                .Replace("Ç", "%C7").Replace("É", "%C9").Replace("Ê", "%CA").Replace("Í", "%CD").Replace("Ó", "%D3").Replace("Ô", "%D4").Replace("Õ", "%D6").Replace("Ú", "%DA")
                .Replace("à", "%E0").Replace("á", "%E1").Replace("â", "%E2").Replace("ã", "%E3").Replace("ç", "%E7").Replace("é", "%E9").Replace("ê", "%EA").Replace("í", "%ED")
                .Replace("ó", "%F3").Replace("ô", "%F4").Replace("õ", "%F5").Replace("ú", "%FA").Replace("-", "%2D");
        }



        #endregion

        #region Métodos
        protected void Focus(Control control)
        {
            ScriptManager.GetCurrent(this.Page).SetFocus(control.ClientID);
        }

        public CampoNuloOuInvalidoException ValidarCampos(CampoNuloOuInvalidoException ex)
        {
            if (String.IsNullOrEmpty(txtCep.Text))
                ex.Mensagens.Add("CEP", "O campo <b>CEP</b> é de preenchimento obrigatório.");

            if (ddlEstado.SelectedIndex == 0)
                ex.Mensagens.Add("Estado", "O campo <b>Estado</b> é de preenchimento obrigatório.");

            if (ddlLocalidade.SelectedIndex == -1 || ddlLocalidade.SelectedIndex == 0)
                ex.Mensagens.Add("Localidade", "O campo <b>Localidade</b> é de preenchimento obrigatório.");

            if (ddlBairro.SelectedIndex == -1 || ddlBairro.SelectedIndex == 0)
                ex.Mensagens.Add("Bairro", "O campo <b>Bairro</b> é de preenchimento obrigatório.");

            if (String.IsNullOrEmpty(txtLogradouro.Text))
                ex.Mensagens.Add("Logradouro", "O campo <b>Logradouro</b> é de preenchimento obrigatório.");

            if (String.IsNullOrEmpty(txtNumero.Text))
                ex.Mensagens.Add("Numero", "O campo <b>Número</b> é de preenchimento obrigatório.");

            if (ex.Mensagens.Count > 0)
                return ex;

            return null;
        }

        public void Focus(string control)
        {
            try
            {
                ScriptManager.GetCurrent(this.Page).SetFocus(this.FindControl(control).ClientID);
            }
            catch { }
        }

        protected virtual void ExibirAlerta(TiposMensagem tipo, string titulo, string mensagem)
        {
            mensagem = mensagem.Replace("'", "").Replace("\"", "").Replace("\n", "").Replace("\r", "");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Mensagem", "ExibirAlerta('" + tipo + "','" + titulo + "','" + mensagem + "');", true);
        }

        protected void BuscarEndereco(string cep)
        {
            Limpar();
            Dictionary<string, object> Valores = new Dictionary<string, object>();
            bool carregou = false;
            Valores = new Listas().BuscarEndereco(cep);
            if (Valores != null && Valores.Count >= 5)
            {
                this.CarregarCampos(Valores);
                carregou = true;
            }

            this.txtCep.Text = cep;

            if (carregou)
            {
                Focus(txtNumero);
            }
            else
            {
                if (!string.IsNullOrEmpty(txtCep.Text))
                {
                    this.ExibirAlerta(TiposMensagem.Alerta, "CEP", "Nenhum endereço encontrado com o CEP <b>" + cep.Substring(0, 2) + "." + cep.Substring(2) + "</b>.");
                    Focus(txtCep);
                }
                else
                {
                    this.ExibirAlerta(TiposMensagem.Alerta, "CEP", "Preencha o CEP para a busca.");
                    Focus(txtCep);
                }


            }

        }
        private bool CarregarCampos(Dictionary<string, object> atributos)
        {
            if (atributos != null)
            {
                try
                {
                    this.pnlEndereco.Clear();
                    this.txtCep.Text = atributos.ContainsKey("Cep") ? (string)atributos["Cep"] : this.txtCep.Text;
                    this.txtLogradouro.Text = atributos.ContainsKey("Logradouro") ? (string)atributos["Logradouro"] : this.txtLogradouro.Text;
                    if (atributos.ContainsKey("SiglaEstado"))
                    {
                        this.ddlEstado.Items.FindByValue(atributos["SiglaEstado"].ToString()).Selected = true;
                        this.ddlEstado_SelectedIndexChanged(this, EventArgs.Empty);
                    }
                    if (atributos.ContainsKey("Localidade"))
                    {
                        this.ddlLocalidade.Items.FindByValue(atributos["Localidade"].ToString()).Selected = true;
                        this.ddlMunicipio_SelectedIndexChanged(this, EventArgs.Empty);
                    }
                    if (atributos.ContainsKey("Bairro"))
                        this.ddlBairro.Items.FindByValue(atributos["Bairro"].ToString()).Selected = true;

                    txtNumero.Text = atributos.ContainsKey("Numero") ? (string)atributos["Numero"] : this.txtNumero.Text;
                    txtComplemento.Text = atributos.ContainsKey("Complemento") ? (string)atributos["Complemento"] : this.txtComplemento.Text;
                    return true;
                }
                catch { return false; }
            }
            else
                return false;
        }
        private void CarregarEndereco(Dictionary<string, object> atributos)
        {
            if (atributos != null)
            {
                try
                {
                    this.Focus(txtCep);
                    this.pnlEndereco.Clear();
                    this.txtCep.Text = atributos.ContainsKey("Cep") ? (string)atributos["Cep"] : this.txtCep.Text;
                    this.txtLogradouro.Text = atributos.ContainsKey("Logradouro") ? (string)atributos["Logradouro"] : this.txtLogradouro.Text;
                    if (atributos.ContainsKey("SiglaEstado"))
                    {
                        this.ddlEstado.Items.FindByValue(atributos["SiglaEstado"].ToString()).Selected = true;
                        this.ddlEstado_SelectedIndexChanged(this, EventArgs.Empty);
                    }
                    if (atributos.ContainsKey("Localidade"))
                    {
                        this.ddlLocalidade.Items.FindByValue(atributos["Localidade"].ToString()).Selected = true;
                        this.ddlMunicipio_SelectedIndexChanged(this, EventArgs.Empty);
                    }
                    if (atributos.ContainsKey("Bairro"))
                        this.ddlBairro.Items.FindByValue(atributos["Bairro"].ToString()).Selected = true;
                }
                catch { }
                txtNumero.Text = atributos.ContainsKey("Numero") ? (string)atributos["Numero"] : this.txtNumero.Text;
                txtComplemento.Text = atributos.ContainsKey("Complemento") ? (string)atributos["Complemento"] : this.txtComplemento.Text;
            }

        }
        public Dictionary<string, object> ObterAtributos()
        {
            return this.Controladora.ObterAtributos();
        }
        public void Novo()
        {
            this.Controladora.PrepararInclusao();
            this.pnlEndereco.Clear();
        }
        public void Salvar()
        {
            this.iIdEndereco = this.Controladora.SalvarRetornandoId(this.pnlEndereco.GetFormData());
        }

        public void SetarID(int id)
        {
            Controladora.SetarID(id);
            this.iIdEndereco = id;
        }

        public void Excluir()
        {
            this.Controladora.Excluir();
            this.pnlEndereco.Clear();
        }
        public void Carregar(int idEndereco)
        {
            this.CarregarCampos(this.Controladora.Selecionar(idEndereco));
        }
        public void Selecionar(int idEndereco)
        {
            this.CarregarEndereco(this.Controladora.Selecionar(idEndereco));
        }

        public void PrepararInclusao()
        {
            Controladora.PrepararInclusao();
        }
        public void Limpar()
        {
            pnlEndereco.Clear();
        }
        protected virtual void ExibirExcecao(Exception excessao)
        {
            System.Text.StringBuilder sMensagens = new System.Text.StringBuilder();
            string sMensagem = string.Empty;
            switch (excessao.GetType().Name)
            {
                case "CampoInvalidoException":
                    foreach (string key in ((CampoInvalidoException)excessao).Mensagens.Keys)
                        sMensagens.Append("<li> " + ((CampoInvalidoException)excessao).Mensagens[key].Replace("'", "") + "<br>");

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Mensagem", "ExibirAlerta('" + TiposMensagem.Alerta + "','" + excessao.Message + "','" + sMensagens.ToString() + "');", false);
                    break;
                default:
                    sMensagem = excessao.Message;
                    sMensagem = sMensagem.Replace("'", "");
                    sMensagem = sMensagem.Replace("\"", "");
                    sMensagem = sMensagem.Replace("\n", "");
                    sMensagem = sMensagem.Replace("\r", "");
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Mensagem", "ExibirAlerta('" + TiposMensagem.Erro + "','','" + sMensagem + "');", false);
                    break;
            }
        }

        #endregion
        public CampoNuloOuInvalidoException ValidarCampos()
        {
            CssObrigatorio();
            CampoNuloOuInvalidoException ex = new CampoNuloOuInvalidoException();
            if (String.IsNullOrEmpty(txtCep.Text))
                ex.Mensagens.Add("CEP", "O campo <b>CEP</b> é de preenchimento obrigatório.");

            if (ddlEstado.SelectedIndex == 0)
                ex.Mensagens.Add("Estado", "O campo <b>Estado</b> é de preenchimento obrigatório.");

            if (ddlLocalidade.SelectedIndex == -1 || ddlLocalidade.SelectedIndex == 0)
                ex.Mensagens.Add("Localidade", "O campo <b>Localidade</b> é de preenchimento obrigatório.");

            if (ddlBairro.SelectedIndex == -1 || ddlBairro.SelectedIndex == 0)
                ex.Mensagens.Add("Bairro", "O campo <b>Bairro</b> é de preenchimento obrigatório.");

            if (String.IsNullOrEmpty(txtLogradouro.Text))
                ex.Mensagens.Add("Logradouro", "O campo <b>Logradouro</b> é de preenchimento obrigatório.");

            if (String.IsNullOrEmpty(txtNumero.Text))
                ex.Mensagens.Add("Numero", "O campo <b>Número</b> é de preenchimento obrigatório.");

            if (ex.Mensagens.Count > 0)
                return ex;

            return null;
        }
        protected void CssObrigatorio()
        {
            txtCep.CssClass = "obj_Controle_Obrigatorio_P";
            txtCep.CssClassFocus = "obj_Controle_Obrigatorio_Focus_P";

            txtNumero.CssClass = "obj_Controle_Obrigatorio_P";
            txtNumero.CssClassFocus = "obj_Controle_Obrigatorio_Focus_P";

            txtLogradouro.CssClass = "obj_Controle_Obrigatorio_G";
            txtLogradouro.CssClassFocus = "obj_Controle_Obrigatorio_Focus_G";

            ddlLocalidade.CssClass = "obj_Controle_Obrigatorio_P";
            ddlLocalidade.CssClassFocus = "obj_Controle_Obrigatorio_Focus_P";

            ddlEstado.CssClass = "obj_Controle_Obrigatorio_P";
            ddlEstado.CssClassFocus = "obj_Controle_Obrigatorio_Focus_P";

            ddlBairro.CssClass = "obj_Controle_Obrigatorio_P";
            ddlBairro.CssClassFocus = "obj_Controle_Obrigatorio_Focus_P";
        }
        public void CssNaoObrigatorio()
        {
            txtCep.CssClass = "obj_Controle_P";
            txtCep.CssClassFocus = "obj_Controle_Focus_P";

            txtNumero.CssClass = "obj_Controle_P";
            txtNumero.CssClassFocus = "obj_Controle_Focus_P";

            txtLogradouro.CssClass = "obj_Controle_G";
            txtLogradouro.CssClassFocus = "obj_Controle_Focus_G";

            ddlLocalidade.CssClass = "obj_Controle_P";
            ddlLocalidade.CssClassFocus = "obj_Controle_Focus_P";

            ddlEstado.CssClass = "obj_Controle_P";
            ddlEstado.CssClassFocus = "obj_Controle_Focus_P";

            ddlBairro.CssClass = "obj_Controle_P";
            ddlBairro.CssClassFocus = "obj_Controle_Focus_P";
        }
        internal int SalvarRetornandoID()
        {
            this.iIdEndereco = this.Controladora.SalvarRetornandoId(this.pnlEndereco.GetFormData());
            return this.iIdEndereco;

        }

        public Dictionary<string, object> RetornarDicionario()
        {
            Dictionary<string, object> dicionario = this.pnlEndereco.GetFormData();
            return dicionario;
        }
    }
}