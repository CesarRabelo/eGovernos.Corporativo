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
    public partial class Arquivo : PaginaCadastroBase
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.PaginaSegura = false;
                this.TituloPagina = "Arquivo";
                this.Controladora = new ManterArquivo();
                this.grdListagem.SortColumnName = "Codigo";
                ddlGrupoArquivo.DataBind(new Listas().GrupoArquivo);
                base.Page_Load(sender, e);
            }
            FocoInicial = txtCodigo;

        }

        private void PopularGridArquivoColuna(int id)
        {
            if (id > 0)
                ucArquivoColuna1.IdPai = id;
            else
                ucArquivoColuna1.IdPai = null;

            ucArquivoColuna1.PopularGridView();
        }

        private void PopularGridArquivoResponsavel(int id)
        {
            if (id > 0)
                ucArquivoResponsavel1.IdPai = id;
            else
                ucArquivoResponsavel1.IdPai = null;

            ucArquivoResponsavel1.PopularGridView();
        }

        private void PopularGridArquivoTipoEnvio(int id)
        {
            if (id > 0)
                ucArquivoTipoEnvio1.IdPai = id;
            else
                ucArquivoTipoEnvio1.IdPai = null;

            ucArquivoTipoEnvio1.PopularGridView();
        }

        protected override void Selecionar(int id)
        {
            base.Selecionar(id);
            PopularGridArquivoColuna(id);
            PopularGridArquivoTipoEnvio(id);
            PopularGridArquivoResponsavel(id);
        }

        protected override void SetarModoPagina(PaginaCadastroBase.ModosPagina modo)
        {
            base.SetarModoPagina(modo);
            if (modo == ModosPagina.Inserir)
            {
                PopularGridArquivoColuna(0);
                PopularGridArquivoTipoEnvio(0);
                PopularGridArquivoResponsavel(0);
            }
        }

        protected override void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = ((ManterArquivo)Controladora).SalvarRetornandoId(pnlManutencao.GetFormData());
                if (ModoPagina == ModosPagina.Inserir)
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "QuickMessage", "ExibirMensagem('Registro <b>inserido</b> com sucesso.');", true);
                else
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "QuickMessage", "ExibirMensagem('Registro <b>atualizado</b> com sucesso.');", true);
                this.Selecionar(id);
                base.btnSalvar_Click(sender, e);
            }
            catch (Exception ex)
            {
                this.ExibirExcecao(ex);
            }
        }

    }
}