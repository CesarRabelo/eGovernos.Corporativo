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
    public partial class ucArquivoResponsavel: UserControlPopupCadastroBase
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.PaginaSegura = false;
                this.lblTitulo.Text = "Responsável de Envio";
                this.Controladora = new ManterArquivoResponsavel();
                ddlResponsavelEnvio.DataBind(new Listas().ResponsavelEnvio);
                base.Page_Load(sender, e);
            }
        }
    }
}