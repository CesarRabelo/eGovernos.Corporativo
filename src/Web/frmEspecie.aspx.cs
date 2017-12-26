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

using Negocio;
using Web;
using Platinium.Web;
using Platinium.Negocio;
using Atom.ClientWeb;

namespace Platinium.Web
{
    public partial class Especie : PaginaCadastroBase
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.TituloPagina = "Espécie";
                this.Controladora = new ManterEspecie();
                ddlCategoriaEconomica.DataBind(new Listas().CatEconomicaReceita);
                ddlBuscaCategoria.DataBind(new Listas().CatEconomicaReceita);
                this.grdListagem.SortColumnName = "Codigo";
                base.Page_Load(sender, e);
            }
            FocoInicial = txtCodigo;

        }

        protected void ddlCategoriaEconomica_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            ddlOrigemReceita.SelectedIndex = -1;
            ddlOrigemReceita.Items.Clear();
            OrigemByIdCategoria();
            if (ddlCategoriaEconomica.SelectedIndex != 0)
            {
                txtCod1.Text = ((ManterEspecie)Controladora).GetCodCategoriaEconomica(Convert.ToInt32(ddlCategoriaEconomica.SelectedValue));
                txtCod2.Text = "";
            }
            else
            {
                txtCod1.Text = "";
                txtCod2.Text = "";
            }
            
        }

        protected void ddlOrigemReceita_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlOrigemReceita.SelectedIndex != 0)
                txtCod2.Text = ((ManterEspecie)Controladora).GetCodOrigemReceita(Convert.ToInt32(ddlOrigemReceita.SelectedValue));
            else
                txtCod2.Text = "";            
        }

        private void OrigemByIdCategoria()
        {
            ddlOrigemReceita.SelectedIndex = -1;
            if (!string.IsNullOrEmpty(ddlCategoriaEconomica.SelectedItem.Value))
            {
                ddlOrigemReceita.DataBind(new Listas().OrigemByIdCategoriaEconomica(ddlCategoriaEconomica.SelectedItem.Value));
            }
        }

        protected override void btnSalvar_Click(object sender, EventArgs e)
        {            
            btrPreencherCombos_Click(sender, e);
            txtCodigo.Text = txtCod1.Text + txtCod2.Text + txtCod3.Text + txtCod4.Text + txtCod5.Text + txtCod6.Text;
            base.btnSalvar_Click(sender, e);
            PopularCodigosDesabilitados();
            chkAtivo.Checked = true;
            if (this.ModoPagina == ModosPagina.Inserir)
            {
                ddlOrigemReceita.SelectedIndex = -1;
                ddlOrigemReceita.Items.Clear();
            }
        }

        protected override void btnNovo_Click(object sender, EventArgs e)
        {
            base.btnNovo_Click(sender, e);
            chkAtivo.Checked = true;
            PopularCodigosDesabilitados();
        }

        private void PopularCodigosDesabilitados()
        {
            
            txtCod4.Text = "0";
            txtCod5.Text = "00";
            txtCod6.Text = "00";
        }

        protected override void Selecionar(int id)
        {

            base.Selecionar(id);
            int CategoriaEconomicaID = ((ManterEspecie)Controladora).CategoriaEconomicaID;
            int OrigemReceitaID = ((ManterEspecie)Controladora).OrigemReceitaID;


            ddlOrigemReceita.DataBind(new Listas().OrigemByIdCategoriaEconomica(ddlCategoriaEconomica.SelectedItem.Value));
            ddlOrigemReceita.Items.FindByValue(OrigemReceitaID.ToString()).Selected = true;
           
            txtCod1.Text = txtCodigo.Text.Substring(0, 1);
            txtCod2.Text = txtCodigo.Text.Substring(1, 1);
            txtCod3.Text = txtCodigo.Text.Substring(2, 1);
            PopularCodigosDesabilitados();

        }

        protected void btrPreencherCombos_Click(object sender, EventArgs e)
        {
            txtCod1.Text = txtCod1.Text.ToUpper();
            txtCod2.Text = txtCod2.Text.ToUpper();
            txtCod3.Text = txtCod3.Text.ToUpper();

            string codigo = txtCod1.Text + "0000000";
            string codigo2 = txtCod1.Text + txtCod2.Text + "000000";
            try
            {
                ddlCategoriaEconomica.SelectedIndex = -1;
                ddlCategoriaEconomica.Items.FindByValue(new Listas().CategoriaEconomicabyCodigo(codigo)).Selected = true;
            }
            catch
            {
                ExibirAlerta(TiposMensagem.Alerta, "Categoria inválida.", string.Format("Categoria econômica não localizada com o código [{0}].", codigo));
            }
            try
            {
                OrigemByIdCategoria();
                ddlOrigemReceita.SelectedIndex = -1;
                ddlOrigemReceita.Items.FindByValue(new Listas().OrigemReceitabyCodigo(codigo2)).Selected = true;
            }
            catch
            {
                ExibirAlerta(TiposMensagem.Alerta, "Origem Receita.",  string.Format("Origem Receita não localizada com o código [{0}].",codigo2));
            }
        }



    }
}