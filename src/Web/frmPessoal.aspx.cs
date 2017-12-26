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
using System.Collections.Generic;
using Pro.Utils;
using Atom.ClientWeb;

namespace Platinium.Web
{
    public partial class frmPessoal : PaginaCadastroBase
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.TituloPagina = "Pessoal";
                this.Controladora = new ManterPessoal();
                ddlSexo.DataBind(Listas.Sexo);
                ddlEstadoCivil.DataBind(Listas.EstadoCivil);
                ddlGrauInstrucao.DataBind(Listas.GrauInstrucao);
                ddlTipoPrograma.DataBind(Listas.TipoPisPasep);
                this.grdListagem.SortColumnName = "DescricaoNome";
                base.Page_Load(sender, e);
            }
            FocoInicial = txtNome;

        }

        protected override void Selecionar(int id)
        {
            base.Selecionar(id);
            ucEndereco1.Novo();

            if (((ManterPessoal)Controladora).PossuiEndereco())
            {
                int idEndereco = ((ManterPessoal)Controladora).GetEnderecoID;
                ucEndereco1.Carregar(idEndereco);
            }
        }

        protected override void SetarModoPagina(PaginaCadastroBase.ModosPagina modo)
        {
            base.SetarModoPagina(modo);
            if (modo == ModosPagina.Inserir)
            {
                ucEndereco1.Novo();
            }
        }

        protected override void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                Dictionary<string, object> dicionarioEndereco = ucEndereco1.RetornarDicionario();
                Dictionary<string, object> dicionario = pnlManutencao.GetFormData();
                int cont = 0;
                foreach (KeyValuePair<string, object> aux in dicionarioEndereco)
                {
                    if ((aux.Value == null) && (aux.Key != "Complemento"))
                    {
                        cont++;
                    }
                }
                if (cont == 0)
                {
                    CampoNuloOuInvalidoException ex = ((ManterPessoal)Controladora).ValidarCampos(dicionario);
                    if (ex.Mensagens.Count > 0)
                        throw ex;
                    int idEndereco = ucEndereco1.SalvarRetornandoID();
                    dicionario.Add("Endereco", idEndereco);
                }
                else if ((cont <= dicionarioEndereco.Count - 1) && (cont > 0))
                {
                    CampoNuloOuInvalidoException ex = ((ManterPessoal)Controladora).ValidarCampos(dicionario);
                    ucEndereco1.ValidarCampos(ex);
                    if (ex.Mensagens.Count > 0)
                        throw ex;
                }

                int id = ((ManterPessoal)Controladora).SalvarRetornandoIdPessoal(dicionario);

                if (ModoPagina == ModosPagina.Inserir)
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "QuickMessage", "ExibirMensagem('Registro <b>inserido</b> com sucesso.');", true);
                else
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "QuickMessage", "ExibirMensagem('Registro <b>atualizado</b> com sucesso.');", true);
                this.Selecionar(id);
            }
            catch (Exception ex)
            {
                this.ExibirExcecao(ex);
            }
        }

        protected override void btnNovo_Click(object sender, EventArgs e)
        {
            base.btnNovo_Click(sender, e);
        }

    }
}