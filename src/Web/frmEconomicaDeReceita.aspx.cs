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

using Negocio;
using Web;
using Platinium.Web;
using Platinium.Negocio;
using System.Drawing;
using System.Text;
using Atom.ClientWeb;

namespace Platinium.Web
{
    public partial class EconomicaDeReceita : PaginaCadastroBase
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.TituloPagina = "Categoria Econômica da Receita";
                this.Controladora = new ManterEconomicaDeReceita();
                this.grdListagem.SortColumnName = "Codigo";
                base.Page_Load(sender, e);
            }
            FocoInicial = txtCodigo;

        }
        protected override void btnSalvar_Click(object sender, EventArgs e)
        {
            txtCodigo.Text = txtCod1.Text.ToUpper() + txtCod2.Text + txtCod3.Text + txtCod4.Text + txtCod5.Text + txtCod6.Text;
            base.btnSalvar_Click(sender, e);
            chkAtivo.Checked = true;
            PopularCodigosDesabilitados();
        }

        protected override void btnNovo_Click(object sender, EventArgs e)
        {
            base.btnNovo_Click(sender, e);
            chkAtivo.Checked = true;
            PopularCodigosDesabilitados();
        }

        private void PopularCodigosDesabilitados()
        {
            txtCod2.Text = "0";
            txtCod3.Text = "0";
            txtCod4.Text = "0";
            txtCod5.Text = "00";
            txtCod6.Text = "00";
        }

        protected override void Selecionar(int id)
        {
            base.Selecionar(id);
            txtCod1.Text = txtCodigo.Text.Substring(0, 1);

            PopularCodigosDesabilitados();
        }
    }
}