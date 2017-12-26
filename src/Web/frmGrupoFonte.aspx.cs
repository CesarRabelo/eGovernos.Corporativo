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
    public partial class GrupoFonte : PaginaCadastroBase
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.TituloPagina = "Grupo de Fonte";
                this.Controladora = new ManterGrupoFonte();
                ddlGrupoPai.DataBind(new Listas().GrupoFonte);
                this.grdListagem.SortColumnName = "Codigo";
                base.Page_Load(sender, e);
            }
            FocoInicial = txtCodigo;
        }

        protected override void btnNovo_Click(object sender, EventArgs e)
        {
            base.btnNovo_Click(sender, e);
            ddlGrupoPai.SelectedIndex = -1;
            ddlGrupoPai.Items.Clear();
            ddlGrupoPai.DataBind(new Listas().GrupoFonte);
            chkAtivo.Checked = true;
        }

        protected override void btnSalvar_Click(object sender, EventArgs e)
        {
            base.btnSalvar_Click(sender, e);
            ddlGrupoPai.SelectedIndex = -1;
            ddlGrupoPai.Items.Clear();
            ddlGrupoPai.DataBind(new Listas().GrupoFonte);
            chkAtivo.Checked = true;
        }
    }
}