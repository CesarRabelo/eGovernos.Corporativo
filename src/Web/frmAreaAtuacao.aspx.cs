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
using Platinium.Negocio;
using Platinium.Web;
using Web;
using Atom.ClientWeb;

namespace Platinium.Web
{
    public partial class AreaAtuacao : PaginaCadastroBase
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.TituloPagina = "Área de atuação";
                this.Controladora = new ManterAreaAtuacao();
                this.grdListagem.SortColumnName = "Codigo";
                ddlEixo.DataBind(new Listas().Eixos);
                ddlBuscaEixo.DataBind(new Listas().Eixos);
                base.Page_Load(sender, e);
            }
            FocoInicial = txtCodigo;
        }

        protected override void btnNovo_Click(object sender, EventArgs e)
        {

            base.btnNovo_Click(sender, e);
            chkAtivo.Checked = true;
        }

        protected override void btnSalvar_Click(object sender, EventArgs e)
        {

            base.btnSalvar_Click(sender, e);
            chkAtivo.Checked = true;
        }

    }
}