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
    public partial class frmTipoReingresso : PaginaCadastroBase
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.TituloPagina = "Tipo de Desligamento";
                this.Controladora = new ManterTipoReingresso();
                this.grdListagem.SortColumnName = "Codigo";
                base.Page_Load(sender, e);
            }
            FocoInicial = txtCodigo;

        }
   
    }
}