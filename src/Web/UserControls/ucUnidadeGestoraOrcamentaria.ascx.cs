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
    public partial class ucUnidadeGestoraOrcamentaria: UserControlPopupCadastroBase
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                this.lblTitulo.Text = "Unidade Orçamentária";
                this.Controladora = new ManterUnidadeGestoraOrcamentaria();
                //ddlUnidadeOrcamentaria.DataBind(new Listas().UnidadeOrcamentaria);
                base.Page_Load(sender, e);
            }
        }

        protected override void btnNovo_Click(object sender, EventArgs e)
        {
            base.btnNovo_Click(sender, e);
            int idOrgao = ((ManterUnidadeGestoraOrcamentaria)Controladora).getIdOrgao(Convert.ToInt32(txtIdPaiManutencao.Text));
            ddlUnidadeOrcamentaria.SelectedIndex = -1;
            ddlUnidadeOrcamentaria.DataBind(new Listas().UnidadeOrcamentariaByIdOrgao(Convert.ToString(idOrgao)));
            chkAtivo.Checked = true;
        }

        protected override void Selecionar(int id)
        {

            int idOrgao = ((ManterUnidadeGestoraOrcamentaria)Controladora).getIdOrgao(Convert.ToInt32(txtIdPaiConsulta.Text));
            ddlUnidadeOrcamentaria.SelectedIndex = -1;
            ddlUnidadeOrcamentaria.DataBind(new Listas().UnidadeOrcamentariaByIdOrgao(Convert.ToString(idOrgao)));
            base.Selecionar(id);
        }

        protected override void btnSalvar_Click(object sender, EventArgs e)
        {
            base.btnSalvar_Click(sender, e);
        }
    }
}