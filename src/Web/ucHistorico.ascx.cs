using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Imobium.Negocio;
using Pro.Controls;

namespace Imobium.Web
{
	public partial class ucHistorico : UserControlCadastroBase
	{
		#region Propriedades

		public Dictionary<string, int> Filtros
		{
			get
			{
				if (ViewState["$Filtros$"] == null)
					ViewState["$Filtros$"] = new Dictionary<string, int>();

				return (Dictionary<string, int>)ViewState["$Filtros$"];
			}
		}

		public OrigemHistorico Origem
		{
			get
			{
				if (ViewState["$OrigemHistorico$"] == null)
					return OrigemHistorico.Cliente;

				return (OrigemHistorico)ViewState["$OrigemHistorico$"];
			}
			set { ViewState["$OrigemHistorico$"] = value; }
		}

		public string Cliente
		{
			get
			{
				return ViewState["$OrigemCliente$"] == null ? string.Empty : ViewState["$OrigemCliente$"].ToString();
			}
			set { ViewState["$OrigemCliente$"] = value; }
		}

		public string Condominio
		{
			get
			{
				return ViewState["$OrigemCondominio$"] == null ? string.Empty : ViewState["$OrigemCondominio$"].ToString();
			}
			set { ViewState["$OrigemCondominio$"] = value; }
		}

		public string ContratoAdministracao
		{
			get
			{
				return ViewState["$OrigemContratoAdministracao$"] == null ? string.Empty : ViewState["$OrigemContratoAdministracao$"].ToString();
			}
			set { ViewState["$OrigemContratoAdministracao$"] = value; }
		}

		public string ContratoLocacao
		{
			get
			{
				return ViewState["$OrigemContratoLocacao$"] == null ? string.Empty : ViewState["$OrigemContratoLocacao$"].ToString();
			}
			set { ViewState["$OrigemContratoLocacao$"] = value; }
		}

		public string Imovel
		{
			get
			{
				return ViewState["$OrigemImovel$"] == null ? string.Empty : ViewState["$OrigemImovel$"].ToString();
			}
			set { ViewState["$OrigemImovel$"] = value; }
		}

		public string Titulo
		{
			get
			{
				return this.TituloPagina;
			}
			set { this.TituloPagina = value; }
		}

		#endregion

		protected override void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				this.lblTitulo.Text = this.Titulo;
				this.Controladora = new ManterHistorico(this.Origem);
				this.grdListagem.SortColumnName = "DataOcorrencia";
				this.grdListagem.SortByDirection = Pro.Controls.ProGridViewDirectionModes.Desc;
				this.ddlUsuario.DataBind(((ManterHistorico)this.Controladora).ListarUsuarios());
				this.ddlOrigem.DataBind(((ManterHistorico)this.Controladora).ListarOrigens());
				base.Page_Load(sender, e);
			}
			FocoInicial = txtAssunto;
		}
		protected override void SetarModoPagina(UserControlCadastroBase.ModosPagina modo)
		{
			base.SetarModoPagina(modo);
			if (modo == ModosPagina.Inserir)
			{
				SetarDados();
			}
		}

		protected override void btnSalvar_Click(object sender, EventArgs e)
		{
			base.btnSalvar_Click(sender, e);
			if (txtData.Text.Length == 0)
				SetarDados();
		}

		private void SetarDados()
		{
			txtData.TypedValue = DateTime.Now;
			try
			{
				ddlUsuario.SelectedIndex = -1;
				ddlUsuario.Items.FindByValue(Sessao.IdUsuario.ToString()).Selected = true;
			}
			catch { }

			try
			{
				ddlOrigem.SelectedIndex = -1;
				ddlOrigem.Items.FindByValue(((int)this.Origem).ToString()).Selected = true;
			}
			catch { }

			txtIdCondominio.Text = this.Condominio;
			txtCliente.Text = this.Cliente;
			txtCA.Text = this.ContratoAdministracao;
			txtCL.Text = this.ContratoLocacao;
			txtImovel.Text = this.Imovel;
		}

		protected override void PopularGridView()
        {
            try
            {
				Label lblBusca = (Label)this.LocalizarControle("lblBusca", this.Controls);
				ProTextBox txtBusca = (ProTextBox)this.LocalizarControle("txtBusca", this.Controls);
				ProPanel pnlConsulta = (ProPanel)this.LocalizarControle("pnlConsulta", this.Controls);
                ProGridView grdListagem = (ProGridView)this.LocalizarControle("grdListagem",this.Controls);
                grdListagem.SelectedIndex = -1;
                lblBusca.Text = grdListagem.Columns[grdListagem.SortColumnIndex].HeaderText + " : ";
                txtBusca.DataField = grdListagem.SortColumnName;
				Dictionary<string,object> dct = pnlConsulta.GetFormData();
				foreach(KeyValuePair<string,int> kvp in this.Filtros)
				{
					dct.Add(kvp.Key,kvp.Value);
				}
                grdListagem.DataBind(this.Controladora.Consultar(dct, grdListagem.SortByDirection.ToString()));
            }
            catch (Exception ex)
            {
                ExibirExcecao(ex);
            }
        }
	}
}