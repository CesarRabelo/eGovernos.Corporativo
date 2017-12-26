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
    public partial class ucArquivoTipoEnvio: UserControlPopupCadastroBase
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.PaginaSegura = false;
                this.lblTitulo.Text = "Tipo de Envio";
                this.Controladora = new ManterArquivoTipoEnvio();
                this.grdListagemUC.SortColumnName = "TipoEnvio";
                ddlTipoEnvio.DataBind(new Listas().TipoEnvio);
                base.Page_Load(sender, e);
            }
        }
    }
}