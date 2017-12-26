using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Pro.Controls;
using Negocio;


namespace Web
{
    /// <summary>
    /// Classe base para as páginas de cadastro
    /// </summary>
    public class UserControlListagemBase : UserControlBase
    {
        #region Propriedades
        new protected IManter Controladora
        {
            get
            {
                if (ViewState["$Controladora$"] == null)
                    throw new Exception("Controladora não encontrada.");
                if (Cache[ViewState["$Controladora$"].ToString()] == null)
                    throw new Exception("Controladora não encontrada.");

                return (IManter)Cache[ViewState["$Controladora$"].ToString()];
            }
            set
            {
                if (ViewState["$Controladora$"] == null)
                {
                    ViewState["$Controladora$"] = Session.SessionID + Guid.NewGuid().ToString();
                }
                Cache.Insert(ViewState["$Controladora$"].ToString(), value, null, System.Web.Caching.Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes(30), System.Web.Caching.CacheItemPriority.NotRemovable, null);

            }
        }

        #endregion

        #region Eventos
        /// <summary>
        /// Seta os métodos dos botões e controles da página de listagem
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void Page_Init(object sender, EventArgs e)
        {
            try
            {
                Response.AddHeader("Content-Type", "text/html; charset=utf-8");
                Button btnBuscar = (Button)this.LocalizarControle("mtvPrincipal",this.Controls).Controls[0].FindControl("btnBuscar");
                btnBuscar.Click += new EventHandler(btnBuscar_Click);

				ProGridView grdListagem = (ProGridView)this.LocalizarControle("grdListagem", this.Controls);
                grdListagem.PageIndexChanging += new GridViewPageEventHandler(grdListagem_PageIndexChanging);
            }
            catch (Exception ex)
            {
                ExibirExcecao(ex);
            }
        }

        protected override void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
					ProGridView grdListagem = (ProGridView)this.LocalizarControle("grdListagem", this.Controls);
					ProLabel lblTitulo = (ProLabel)this.LocalizarControle("lblTitulo", this.Controls);

                    lblTitulo.Text = this.TituloPagina + ": Consulta";
                    grdListagem.SortColumnStyle = grdListagem.HeaderStyle;
                    PopularGridView();
                }
            }
            catch (Exception ex)
            {
                ExibirExcecao(ex);
            }
        }
        protected virtual void grdListagem_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
				ProGridView grdListagem = (ProGridView)this.LocalizarControle("grdListagem", this.Controls);
                grdListagem.PageIndex = e.NewPageIndex;
                grdListagem.SelectedIndex = -1;
                PopularGridView();
            }
            catch (Exception ex)
            {
                ExibirExcecao(ex);
            }
        }

        protected virtual void grdListagem_Sorting(object sender, GridViewSortEventArgs e)
        {
            PopularGridView();
        }

        protected virtual void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
				ProGridView grdListagem = (ProGridView)this.LocalizarControle("grdListagem", this.Controls);
                grdListagem.SelectedIndex = -1;
                PopularGridView();
            }
            catch (Exception ex)
            {
                ExibirExcecao(ex);
            }
        }
        #endregion

        #region Métodos

        protected virtual void PopularGridView()
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
                grdListagem.DataBind(this.Controladora.Consultar(pnlConsulta.GetFormData(), grdListagem.SortByDirection.ToString()));
            }
            catch (Exception ex)
            {
                ExibirExcecao(ex);
            }
        }

        protected virtual void AlterarSelecao(int idItem)
        {
        }
        #endregion
    }
}
