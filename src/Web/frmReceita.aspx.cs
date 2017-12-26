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
    public partial class Receita : PaginaCadastroBase
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.TituloPagina = "Natureza da Receita";
                this.Controladora = new ManterReceita();
                this.grdListagem.SortColumnName = "Codigo";
                ddlCategoriaEconomica.DataBind(new Listas().CatEconomicaReceita);
                ddlBuscaCategoriaEconomica.DataBind(new Listas().CatEconomicaReceita);
                //ddlBuscaEspecie.DataBind(new Listas().Especie);
                //ddlBuscaRubrica.DataBind(new Listas().Rubrica);
                //ddlBuscaOrigem.DataBind(new Listas().OrigemReceita);
                //ddlEspecie.DataBind(new Listas().Especie);
                //ddlRubrica.DataBind(new Listas().Rubrica);
                //ddlOrigemReceita.DataBind(new Listas().OrigemReceita);
                base.Page_Load(sender, e);
            }
            FocoInicial = txtCodigo;
        }

        #region Botões

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
                ddlRubrica.SelectedIndex = -1;
                ddlRubrica.Items.Clear();
            }
        }

        protected override void btnNovo_Click(object sender, EventArgs e)
        {
            base.btnNovo_Click(sender, e);
            chkAtivo.Checked = true;
            PopularCodigosDesabilitados();
        }

        protected void btrPreencherCombos_Click(object sender, EventArgs e)
        {
            txtCod1.Text = txtCod1.Text.ToUpper();
            txtCod2.Text = txtCod2.Text.ToUpper();
            txtCod3.Text = txtCod3.Text.ToUpper();
            txtCod4.Text = txtCod4.Text.ToUpper();
            txtCod5.Text = txtCod5.Text.ToUpper();

            string codigo = txtCod1.Text + "0000000";
            string codigo2 = txtCod1.Text + txtCod2.Text + "000000";
            string codigo3 = txtCod1.Text + txtCod2.Text + txtCod3.Text + "00000";
            string codigo4 = txtCod1.Text + txtCod2.Text + txtCod3.Text + txtCod4.Text + "0000";

            try
            {
                ddlCategoriaEconomica.SelectedIndex = -1;
                ddlCategoriaEconomica.Items.FindByValue(new Listas().CategoriaEconomicabyCodigo(codigo)).Selected = true;
            }
            catch
            {
                ExibirAlerta(TiposMensagem.Alerta, "Categoria Econômica.", string.Format("Categoria Econômica não localizada com o código [{0}].", codigo));
            }
            try
            {
                OrigemByIdCategoria();
                ddlOrigemReceita.SelectedIndex = -1;
                ddlOrigemReceita.Items.FindByValue(new Listas().OrigemReceitabyCodigo(codigo2)).Selected = true;
            }
            catch
            {
                ExibirAlerta(TiposMensagem.Alerta, "Origem Receita.", string.Format("Origem receita não localizada com o código [{0}].", codigo2));
            }
            try
            {
                EspecieByIdOrigem();
                ddlEspecie.SelectedIndex = -1;
                ddlEspecie.Items.FindByValue(new Listas().EspeciebyCodigo(codigo3, codigo2)).Selected = true;
            }
            catch
            {
                ExibirAlerta(TiposMensagem.Alerta, "Espécie.", string.Format("Espécie não localizada com o código [{0}].", codigo3));
            }
            try
            {
                RubricaByIdEspecie();
                ddlRubrica.SelectedIndex = -1;
                ddlRubrica.Items.FindByValue(new Listas().RubricabyCodigo(codigo4, codigo3, codigo2)).Selected = true;
            }
            catch
            {
                ExibirAlerta(TiposMensagem.Alerta, "Rubrica.", string.Format("Rubrica não localizada com o código [{0}].", codigo4));
            }
        }

        #endregion

        #region OnSelectedIndexChanged

        protected void ddlCategoriaEconomica_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            ddlOrigemReceita.SelectedIndex = -1;
            ddlOrigemReceita.Items.Clear();
            ddlEspecie.SelectedIndex = -1;
            ddlEspecie.Items.Clear();
            ddlRubrica.SelectedIndex = -1;
            ddlRubrica.Items.Clear();
            OrigemByIdCategoria();
            if (ddlCategoriaEconomica.SelectedIndex != 0)
            {
                txtCod1.Text = ((ManterReceita)Controladora).GetCodCategoriaEconomica(Convert.ToInt32(ddlCategoriaEconomica.SelectedValue));
                txtCod2.Text = "";
                txtCod3.Text = "";
                txtCod4.Text = "";
            }
            else
            {
                txtCod1.Text = "";
                txtCod2.Text = "";
                txtCod3.Text = "";
                txtCod4.Text = "";
            }
        }

        protected void ddlBuscaCategoriaEconomica_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            ddlBuscaOrigem.SelectedIndex = -1;
            ddlBuscaOrigem.Items.Clear();
            ddlBuscaEspecie.SelectedIndex = -1;
            ddlBuscaEspecie.Items.Clear();
            ddlBuscaRubrica.SelectedIndex = -1;
            ddlBuscaRubrica.Items.Clear();

            if (!string.IsNullOrEmpty(ddlBuscaCategoriaEconomica.SelectedItem.Value))
            {
                ddlBuscaOrigem.DataBind(new Listas().OrigemByIdCategoriaEconomica(ddlBuscaCategoriaEconomica.SelectedItem.Value));
            }
        }

        protected void ddlOrigemReceita_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            ddlEspecie.SelectedIndex = -1;
            ddlEspecie.Items.Clear();
            ddlRubrica.SelectedIndex = -1;
            ddlRubrica.Items.Clear();
            EspecieByIdOrigem();
            if (ddlOrigemReceita.SelectedIndex != 0)
            {
                txtCod2.Text = ((ManterReceita)Controladora).GetCodOrigemReceita(Convert.ToInt32(ddlOrigemReceita.SelectedValue));
                txtCod3.Text = "";
                txtCod4.Text = "";
            }
            else
            {
                txtCod2.Text = "";
                txtCod3.Text = "";
                txtCod4.Text = "";
            }
        }

        protected void ddlBuscaOrigem_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            ddlBuscaEspecie.SelectedIndex = -1;
            ddlBuscaEspecie.Items.Clear();
            ddlBuscaRubrica.SelectedIndex = -1;
            ddlBuscaRubrica.Items.Clear();

            if (!string.IsNullOrEmpty(ddlBuscaOrigem.SelectedItem.Value))
            {
                ddlBuscaEspecie.DataBind(new Listas().EspecieByIdOrigemReceita(ddlBuscaOrigem.SelectedItem.Value));
            }
        }

        protected void ddlEspecie_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            ddlRubrica.SelectedIndex = -1;
            ddlRubrica.Items.Clear();
            RubricaByIdEspecie();
            if (ddlEspecie.SelectedIndex != 0)
            {
                txtCod3.Text = ((ManterReceita)Controladora).GetCodEspecie(Convert.ToInt32(ddlEspecie.SelectedValue));
                txtCod4.Text = "";
            }
            else
            {
                txtCod3.Text = "";
                txtCod4.Text = "";
            }
        }

        protected void ddlBuscaEspecie_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            ddlBuscaRubrica.SelectedIndex = -1;
            ddlBuscaRubrica.Items.Clear();

            if (!string.IsNullOrEmpty(ddlBuscaEspecie.SelectedItem.Value))
            {
                ddlBuscaRubrica.DataBind(new Listas().RubricaByIdEspecie(ddlBuscaEspecie.SelectedItem.Value));
            }
        }

        protected void ddlRubrica_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlRubrica.SelectedIndex != 0)
                txtCod4.Text = ((ManterReceita)Controladora).GetCodEspecie(Convert.ToInt32(ddlRubrica.SelectedValue));
            else
                txtCod4.Text = "";
        }

        #endregion

        #region Métodos

        private void PopularCodigosDesabilitados()
        {
            txtCod6.Text = "00";
        }

        protected override void Selecionar(int id)
        {
            base.Selecionar(id);
            int CategoriaEconomicaID = ((ManterReceita)Controladora).CategoriaEconomicaID;
            int OrigemReceitaID = ((ManterReceita)Controladora).OrigemReceitaID;
            int EspecieID = ((ManterReceita)Controladora).EspecieID;
            int RubricaID = ((ManterReceita)Controladora).RubricaID;

            ddlOrigemReceita.DataBind(new Listas().OrigemByIdCategoriaEconomica(ddlCategoriaEconomica.SelectedItem.Value));
            ddlOrigemReceita.Items.FindByValue(OrigemReceitaID.ToString()).Selected = true;

            ddlEspecie.DataBind(new Listas().EspecieByIdOrigemReceita(ddlOrigemReceita.SelectedItem.Value));
            ddlEspecie.Items.FindByValue(EspecieID.ToString()).Selected = true;

            ddlRubrica.DataBind(new Listas().RubricaByIdEspecie(ddlEspecie.SelectedItem.Value));
            ddlRubrica.Items.FindByValue(RubricaID.ToString()).Selected = true;


            txtCod1.Text = txtCodigo.Text.Substring(0, 1);
            txtCod2.Text = txtCodigo.Text.Substring(1, 1);
            txtCod3.Text = txtCodigo.Text.Substring(2, 1);
            txtCod4.Text = txtCodigo.Text.Substring(3, 1);
            txtCod5.Text = txtCodigo.Text.Substring(4, 2);
            PopularCodigosDesabilitados();
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

        private void RubricaByIdEspecie()
        {
            ddlRubrica.SelectedIndex = -1;
            if (!string.IsNullOrEmpty(ddlEspecie.SelectedItem.Value))
            {
                ddlRubrica.DataBind(new Listas().RubricaByIdEspecie(ddlEspecie.SelectedItem.Value));
            }
        }

        #endregion
    }
}