using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Web;
using Platinium.Negocio;
using Atom.ClientWeb;

namespace Platinium.Web
{
    public partial class ucEntidadeLei: UserControlPopupCadastroBase
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.lblTitulo.Text = "Base Legal";
                this.Controladora = new ManterEntidadeLei();
                this.grdListagemUC.SortColumnName = "DataInicio";
                base.Page_Load(sender, e);
            }
        }
    }
}