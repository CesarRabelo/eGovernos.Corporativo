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
using Atom.ClientWeb;

namespace Platinium.Web
{
    public partial class RubricaReceita : PaginaCadastroBase
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.TituloPagina = "Rúbrica Receita";
                this.Controladora = new ManterRubricaReceita();
                ddlCategoriaEconomica.DataBind(new Listas().CatEconomicaReceita);
                //ddlBuscaOrigemReceita.DataBind(new Listas().OrigemReceita);
                //ddlEspecie.DataBind(new Listas().Especie);
                //ddlBuscaEspecie.DataBind(new Listas().Especie);
                //ddlOrigemReceita.DataBind(new Listas().OrigemReceita);
                ddlBuscaCategoria.DataBind(new Listas().CatEconomicaReceita);
                this.grdListagem.SortColumnName = "Codigo";
                base.Page_Load(sender, e);
            }
            FocoInicial = txtCodigo;
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
                ddlEspecie.SelectedIndex = -1;
                ddlEspecie.Items.Clear();
            }
        }

        protected override void btnNovo_Click(object sender, EventArgs e)
        {
            base.btnNovo_Click(sender, e);
            PopularCodigosDesabilitados();
            chkAtivo.Checked = true;
        }

        private void PopularCodigosDesabilitados()
        {
            txtCod5.Text = "00";
            txtCod6.Text = "00";
        }

        protected override void Selecionar(int id)
        {
            base.Selecionar(id);
            int CategoriaEconomicaID = ((ManterRubricaReceita)Controladora).CategoriaEconomicaID;
            int OrigemReceitaID = ((ManterRubricaReceita)Controladora).OrigemReceitaID;
            int EspecieID = ((ManterRubricaReceita)Controladora).EspecieID;

            ddlOrigemReceita.DataBind(new Listas().OrigemByIdCategoriaEconomica(ddlCategoriaEconomica.SelectedItem.Value));
            ddlOrigemReceita.Items.FindByValue(OrigemReceitaID.ToString()).Selected = true;

            ddlEspecie.DataBind(new Listas().EspecieByIdOrigemReceita(ddlOrigemReceita.SelectedItem.Value));
            ddlEspecie.Items.FindByValue(EspecieID.ToString()).Selected = true;

            txtCod1.Text = txtCodigo.Text.Substring(0, 1);
            txtCod2.Text = txtCodigo.Text.Substring(1, 1);
            txtCod3.Text = txtCodigo.Text.Substring(2, 1);
            txtCod4.Text = txtCodigo.Text.Substring(3, 1);

            PopularCodigosDesabilitados();
        }

        protected void btrPreencherCombos_Click(object sender, EventArgs e)
        {
            txtCod1.Text = txtCod1.Text.ToUpper();
            txtCod2.Text = txtCod2.Text.ToUpper();
            txtCod3.Text = txtCod3.Text.ToUpper();
            txtCod4.Text = txtCod4.Text.ToUpper();

            string codigo = txtCod1.Text + "0000000";
            string codigo2 = txtCod1.Text + txtCod2.Text + "000000";
            string codigo3 = txtCod1.Text + txtCod2.Text + txtCod3.Text + "00000";
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
                ExibirAlerta(TiposMensagem.Alerta, "Origem Receita inválida.", string.Format("Origem receita não localizada com o código [{0}].", codigo2));
            }

            try
            {
                EspecieByIdOrigem();
                ddlEspecie.SelectedIndex = -1;
                ddlEspecie.Items.FindByValue(new Listas().EspeciebyCodigo(codigo3, codigo2)).Selected = true;
            }
            catch
            {
                ExibirAlerta(TiposMensagem.Alerta, "Espécie inválida.", string.Format("Espécie não localizada com o código [{0}].", codigo3));
            }
        }

        protected void ddlCategoriaEconomica_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            ddlOrigemReceita.SelectedIndex = -1;
            ddlOrigemReceita.Items.Clear();
            ddlEspecie.SelectedIndex = -1;
            ddlEspecie.Items.Clear();
            OrigemByIdCategoria();
            if (ddlCategoriaEconomica.SelectedIndex != 0)
            {
                txtCod1.Text = ((ManterRubricaReceita)Controladora).GetCodCategoriaEconomica(Convert.ToInt32(ddlCategoriaEconomica.SelectedValue));
                txtCod2.Text = "";
                txtCod3.Text = "";
            }
            else
            {
                txtCod1.Text = "";
                txtCod2.Text = "";
                txtCod3.Text = "";
            }

        }

        protected void ddlBuscaCategoriaEconomica_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            ddlBuscaOrigemReceita.SelectedIndex = -1;
            ddlBuscaOrigemReceita.Items.Clear();
            ddlBuscaEspecie.SelectedIndex = -1;
            ddlBuscaEspecie.Items.Clear();

            if (!string.IsNullOrEmpty(ddlBuscaCategoria.SelectedItem.Value))
            {
                ddlBuscaOrigemReceita.DataBind(new Listas().OrigemByIdCategoriaEconomica(ddlBuscaCategoria.SelectedItem.Value));
            }
        }

        protected void ddlOrigemReceita_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            ddlEspecie.SelectedIndex = -1;
            ddlEspecie.Items.Clear();
            EspecieByIdOrigem();
            if (ddlOrigemReceita.SelectedIndex != 0)
            {
                txtCod2.Text = ((ManterRubricaReceita)Controladora).GetCodOrigemReceita(Convert.ToInt32(ddlOrigemReceita.SelectedValue));
                txtCod3.Text = "";
            }
            else
            {
                txtCod2.Text = "";
                txtCod3.Text = "";
            }
        }

        protected void ddlBuscaOrigem_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            ddlBuscaEspecie.SelectedIndex = -1;
            ddlBuscaEspecie.Items.Clear();

            if (!string.IsNullOrEmpty(ddlBuscaOrigemReceita.SelectedItem.Value))
            {
                ddlBuscaEspecie.DataBind(new Listas().EspecieByIdOrigemReceita(ddlBuscaOrigemReceita.SelectedItem.Value));
            }
        }

        protected void ddlEspecie_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlEspecie.SelectedIndex != 0)
                txtCod3.Text = ((ManterRubricaReceita)Controladora).GetCodEspecie(Convert.ToInt32(ddlEspecie.SelectedValue));
            else
                txtCod3.Text = "";   
        }

        private void OrigemByIdCategoria()
        {
            ddlOrigemReceita.SelectedIndex = -1;
            if (!string.IsNullOrEmpty(ddlCategoriaEconomica.SelectedItem.Value))
            {
                ddlOrigemReceita.DataBind(new Listas().OrigemByIdCategoriaEconomica(ddlCategoriaEconomica.SelectedItem.Value));
            }
        }

        private void EspecieByIdOrigem()
        {
            ddlEspecie.SelectedIndex = -1;
            if (!string.IsNullOrEmpty(ddlOrigemReceita.SelectedItem.Value))
            {
                ddlEspecie.DataBind(new Listas().EspecieByIdOrigemReceita(ddlOrigemReceita.SelectedItem.Value));
            }
        }
        
    }
}