﻿using System;
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
using Atom.ClientWeb;

namespace Platinium.Web
{
    public partial class Orgao : PaginaCadastroBase
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.TituloPagina = "Órgão"; 
                this.Controladora = new ManterOrgao();
                ddlSecretaria.DataBind(new Listas().Secretaria);
                ddlBuscaSecretaria.DataBind(new Listas().Secretaria);
                ddlPoder.DataBind(new Listas().Poder);
                ddlBuscaPoder.DataBind(new Listas().Poder);
                ddlTipoEntidade.DataBind(new Listas().TipoEntidade);
                ddlBuscaTipo.DataBind(new Listas().TipoEntidade);
                this.grdListagem.SortColumnName = "CodEntidade";
                base.Page_Load(sender, e);
            }
            FocoInicial = txtCodigo;
            pnlEndereco.Visible = false;
        }

        protected override void btnLimpar_Click(object sender, EventArgs e)
        {
            base.btnLimpar_Click(sender, e);
        }

        protected override void Selecionar(int id)
        {
            base.Selecionar(id);
            ucEndereco1.Novo();
            PopularGridLei(id);
            txtDataCriado.Visible = true;
            txtDataDesativado.Visible = true;
            if (((ManterOrgao)Controladora).PossuiEndereco())
            {
                int idEndereco = ((ManterOrgao)Controladora).GetEnderecoID;
                ucEndereco1.Carregar(idEndereco);
            }
        }

        protected override void SetarModoPagina(PaginaCadastroBase.ModosPagina modo)
        {
            base.SetarModoPagina(modo);
            if (modo == ModosPagina.Inserir)
            {
                ucEndereco1.Novo();
                PopularGridLei(0);
            }
        }

        protected override void btnNovo_Click(object sender, EventArgs e)
        {
            base.btnNovo_Click(sender, e);
            pnlEndereco.Visible = false;
            chkAtivo.Checked = true;
            txtDataCriado.Visible = false;
            txtDataDesativado.Visible = false;
        }

        protected override void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                //Dictionary<string, object> dicionarioEndereco = ucEndereco1.RetornarDicionario();
                Dictionary<string, object> dicionario = pnlManutencao.GetFormData();
                /*ucEndereco1.CssNaoObrigatorio();
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
                    int idEndereco = ucEndereco1.SalvarRetornandoID();
                    dicionario.Add("Endereco", idEndereco);
                }
                else if ((cont < dicionarioEndereco.Count - 1) && (cont > 0))
                {
                    ExibirExcecao(ucEndereco1.ValidarCampos());
                }*/

                int id = ((ManterOrgao)Controladora).SalvarRetornandoIdOrgao(dicionario);
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

        private void PopularGridLei(int id)
        {
            if (id > 0)
                ucEntidadeLei1.IdPai = id;
            else
                ucEntidadeLei1.IdPai = null;

            ucEntidadeLei1.PopularGridView();
        }
    }
}
