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
    public partial class Regiao : PaginaCadastroBase
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.TituloPagina = "Região";
                this.Controladora = new ManterRegiao();
                this.grdListagem.SortColumnName = "Codigo";
                base.Page_Load(sender, e);
            }
            FocoInicial = txtCodigo;
        }

        protected override void btnNovo_Click(object sender, EventArgs e)
        {
            base.btnNovo_Click(sender, e);
            chkAtivo.Checked = true;
            txtDataCriado.Visible = false;
            txtDataDesativado.Visible = false;
        }

        protected override void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = ((ManterRegiao)Controladora).SalvarRetornandoId(pnlManutencao.GetFormData());
                if (ModoPagina == ModosPagina.Inserir)
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "QuickMessage", "ExibirMensagem('Registro <b>inserido</b> com sucesso.');", true);
                else
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "QuickMessage", "ExibirMensagem('Registro <b>atualizado</b> com sucesso.');", true);
                this.Selecionar(id);
                base.btnSalvar_Click(sender, e);
                chkAtivo.Checked = true;
            }
            catch (Exception ex)
            {
                this.ExibirExcecao(ex);
            }
            
        }

        protected override void Selecionar(int id)
        {
            base.Selecionar(id);
            txtDataCriado.Visible = true;
            txtDataDesativado.Visible = true;
        }
    }
}