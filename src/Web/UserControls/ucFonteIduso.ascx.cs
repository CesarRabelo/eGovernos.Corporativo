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
    public partial class ucFonteIduso: UserControlPopupCadastroBase
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.lblTitulo.Text = "Identificador de uso";
                this.Controladora = new ManterFonteIduso();
                this.grdListagemUC.SortColumnName = "Iduso";
                ddlIduso.DataBind(new Listas().Iduso);
                base.Page_Load(sender, e);
            }
        }
    }
}