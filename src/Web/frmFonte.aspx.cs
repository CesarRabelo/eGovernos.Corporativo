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
    public partial class Fonte : PaginaCadastroBase
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.TituloPagina = "Fonte";
                this.Controladora = new ManterFonte();
                this.grdListagem.SortColumnName = "CodGrpFonte";
                ddlBuscaGrupo.DataBind(new Listas().GrupoFonte);
                ddlGrpFonte.DataBind(new Listas().GrupoFonte);
                base.Page_Load(sender, e);
            }
            FocoInicial = txtCodigo;

        }

        private void PopularGridIduso(int id)
        {
            if (id > 0)
                ucFonteIduso1.IdPai = id;
            else
                ucFonteIduso1.IdPai = null;

            ucFonteIduso1.PopularGridView();
        }

        protected override void Selecionar(int id)
        {
            base.Selecionar(id);
            PopularGridIduso(id);
            txtDataCriado.Visible = true;
            txtDataDesativado.Visible = true;
        }
        protected override void SetarModoPagina(PaginaCadastroBase.ModosPagina modo)
        {
            base.SetarModoPagina(modo);
            if (modo == ModosPagina.Inserir)
            {
                PopularGridIduso(0);
            }
        }

        protected override void btnNovo_Click(object sender, EventArgs e)
        {
            base.btnNovo_Click(sender, e);
            chkAtivo.Checked = true;
            txtDataCriado.Visible = false;
            ddlGrpFonte.DataBind(new Listas().GrupoFonte);
            txtDataDesativado.Visible = false;
        }

        protected override void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = ((ManterFonte)Controladora).SalvarRetornandoId(pnlManutencao.GetFormData());
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

    }
}