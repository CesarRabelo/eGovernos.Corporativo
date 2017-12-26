using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Web;
using Platinium.Negocio;
using Platinium.Web;
using Atom.ClientWeb;

namespace Platinium.Web
{
    public partial class ucArquivoColuna: UserControlPopupCadastroBase
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.PaginaSegura = false;
                this.lblTitulo.Text = "Coluna";
                this.Controladora = new ManterArquivoColuna();
                this.grdListagemUC.SortColumnName = "Sequencia";
                this.ddlMetodoComplemento.DataBind(new Listas().MetodoComplemento);
                this.ddlTipo.DataBind(new Listas().Tipo);
                base.Page_Load(sender, e);
            }
        }
    }
}