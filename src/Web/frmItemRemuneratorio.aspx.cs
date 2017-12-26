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
using Pro.Utils;
using Atom.ClientWeb;

namespace Platinium.Web
{
    public partial class frmItemRemuneratorio : PaginaCadastroBase
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.TituloPagina = "Item Remuneratório";
                this.Controladora = new ManterItemRemuneratorio();
                this.grdListagem.SortColumnName = "Codigo";
                this.PaginaSegura = false;
                ddlTipoItem.DataBind(Listas.TipoItemRemuneratorio);
                ddlClassificacaoItem.DataBind(Listas.ClassificacaoItemRemuneratorio);
                ddlAmparo.DataBind(Listas.TipoAmparo);
                ddlBuscaTipoItem.DataBind(Listas.TipoItemRemuneratorio);
                ddlAmparoExtincao.DataBind(Listas.TipoAmparo);
                base.Page_Load(sender, e);
            }
            FocoInicial = ddlTipoItem;

        }
        /// <summary>
        /// Metodo que atribui o valor 1 ou 2 para o campo Digito dependendo do valor do campo rblUtilizado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rblUtilizado_OnSelectedIndexChanged(Object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(rblUtilizado.SelectedItem.Value) && rblUtilizado.SelectedItem.Value.Equals("E"))
            {
                txtDigito.Text = "1";
            }
            else if (!string.IsNullOrEmpty(rblUtilizado.SelectedItem.Value) && rblUtilizado.SelectedItem.Value.Equals("L"))
            {
                txtDigito.Text = "2";
            }
        }

        protected override void Selecionar(int id)
        {
            base.Selecionar(id);

            string[] codigo = ((ManterItemRemuneratorio)Controladora).GetCodigo(id);
            txtDigito.Text = codigo[0];
            txtCodigo.Text = codigo[1];
            if (codigo[0] == "1")
            {
                rblUtilizado.SelectedValue = "E";
            }
            if (codigo[0] == "2")
            {
                rblUtilizado.SelectedValue = "L";
            }

        }
        protected override void SetarModoPagina(PaginaCadastroBase.ModosPagina modo)
        {
            base.SetarModoPagina(modo);
            if (modo == ModosPagina.Listar || modo == ModosPagina.Inserir)
            {
                btnExtincao.Visible = false;
            }
            if (modo == ModosPagina.Alterar)
            {
                btnExtincao.Visible = true;
                btnSalvarExtincao.Visible = true;
                btnSavarExtincaoLista.Visible = false;
            }
            if (modo == ModosPagina.Listar)
            {
                btnSavarExtincaoLista.Visible = true;
                btnSalvarExtincao.Visible = false;
            }

        }
        /// <summary>
        /// Metodo que salva o dados da extinção na página de inserção
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSalvarExtincao_OnClick(Object sender, EventArgs e)
        {

            try
            {

                int aux = ((ManterItemRemuneratorio)Controladora).Verificação();
                if (aux > 0)
                {
                    
                    mpeExtincaoItemsRemuneratorios.Show();
                    MostrarPergunta(sender, e);
                    lblPergunta.Text = "Esse item remuneratório esta sendo usado em " + aux + " agente(s) </br> Deseja realmente extinguí-lo?";

                }
                else
                {
                    
                    mpeExtincaoItemsRemuneratorios.Show();
                    MostrarPergunta(sender, e);
                    lblPergunta.Text = "Esse item remuneratório não esta sendo usado em nenhum agente.</br>Deseja realmente extinguí-lo?";

                }

            }
            catch (Exception ex)
            {

                this.ExibirExcecao(ex);
            }
        }


        public override void grdListagem_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int ID;
            int index;

            base.grdListagem_RowCommand(sender, e);
            if (e.CommandName.ToUpper() == "EXTINGUIR")
            {
                index = ((GridViewRow)((ImageButton)e.CommandSource).Parent.Parent).RowIndex;
                ID = Convert.ToInt32(grdListagem.DataKeys[index].Value);
                txtIDLista.Text = Convert.ToString(ID);
            }
        }

        /// <summary>
        /// Metodo que Preenche a msg do popap Pergunta
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSavarExtincaoLista_OnClick(Object sender, EventArgs e)
        {
            try
            {

                int aux = ((ManterItemRemuneratorio)Controladora).Verificação(Convert.ToInt32(txtIDLista.Text));
                if (aux > 0)
                {
                   
                    mpeExtincaoItemsRemuneratorios.Show();
                    MostrarPergunta(sender, e);
                    lblPergunta.Text = "Esse item remuneratório está sendo usado em " + aux + " agente(s) </br> Deseja realmente extinguí-lo?";

                }
                else
                {
                    
                    mpeExtincaoItemsRemuneratorios.Show();
                    MostrarPergunta(sender, e);
                    lblPergunta.Text = "Esse item remuneratório não está sendo usado em nenhum agente.</br>Deseja realmente extinguí-lo?";

                }

            }
            catch (Exception ex)
            {

                this.ExibirExcecao(ex);
            }

        }

        #region Metodos do Popap de Pergunta

        /// <summary>
        /// Metodo que mostra o popap de confirmação
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void MostrarPergunta(Object sender, EventArgs e)
        {

            pnlManutencaoUCPergunta.Visible = true;
            mpePergunta.Show();
        }
        /// <summary>
        /// Metodo do botão Não
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnNao_OnClick(Object sender, EventArgs e)
        {
            SetarModoPagina(ModosPagina.Listar);
        }
        /// <summary>
        /// Metodo do Botão Sim
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSim_OnClick(Object sender, EventArgs e)
        {
            try
            {
                if (ModosPagina.Listar == ModoPagina)
                {
                    ((ManterItemRemuneratorio)Controladora).SalvarComUcListagem(pnlManutencaoUC.GetFormData(), Convert.ToInt32(txtIDLista.Text));
                    SetarModoPagina(ModosPagina.Listar);
                }
                else
                {
                    ((ManterItemRemuneratorio)Controladora).SalvarComUc(pnlManutencaoUC.GetFormData());
                    SetarModoPagina(ModosPagina.Listar);
                }
            }
            catch (Exception ex)
            {

                this.ExibirExcecao(ex);
                mpeExtincaoItemsRemuneratorios.Show();
            }



        }

        #endregion

        /// <summary>
        /// Metodo do botão extiguir da grid de listagem.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgExtinguir_OnClick(Object sender, EventArgs e)
        {
            LimparCamposUc();
            MostrarExtinsao(sender, e);
        }
        /// <summary>
        /// Matodo que mostra o popap
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void MostrarExtinsao(Object sender, EventArgs e)
        {
            mpeExtincaoItemsRemuneratorios.Show();
            LimparCamposUc();
        }


        /// <summary>
        /// Metodo que limpa os campos do Popap
        /// </summary>
        protected void LimparCamposUc()
        {
            txtDataExtincao.Text = "";
            txtDataNormaPublicacaoextincao.Text = "";
            txtDataPublicacaoExtincao.Text = "";
            txtNormaDataExtincao.Text = "";
            txtNormaExtincao.Text = "";
            txtNumeroExtincao.Text = "";
            ddlAmparoExtincao.Items.Clear();
            ddlAmparoExtincao.DataBind(Listas.TipoAmparo);

        }

    }
}