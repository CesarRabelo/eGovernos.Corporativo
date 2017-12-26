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
    public partial class frmGrauInstrucao : PaginaCadastroBase
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.TituloPagina = "Grau de instrução";
                this.Controladora = new ManterGrauInstrucao();
                this.grdListagem.SortColumnName = "Codigo";
                this.PaginaSegura = false;
                base.Page_Load(sender, e);
            }
            FocoInicial = txtCodigo;

        }
   
    }
}