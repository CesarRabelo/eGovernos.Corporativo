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
    public class PaginaListagemBase : PaginaBase
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
                Button btnBuscar = (Button)this.LocalizarControle("btnBuscar", this.Controls);
                btnBuscar.Click += new EventHandler(btnBuscar_Click);

                ProGridView grdListagem = (ProGridView)this.LocalizarControle("grdListagem", this.Controls);
                grdListagem.PageIndexChanging += new GridViewPageEventHandler(grdListagem_PageIndexChanging);

                Button btnLimpar = (Button)this.LocalizarControle("btnLimpar", this.Controls);
                if(btnLimpar != null)
                    btnLimpar.Click += new EventHandler(btnLimpar_Click);
            }
            catch (Exception ex)
            {
                ExibirExcecao(ex);
            }
        }

        protected virtual void btnLimpar_Click(object sender, EventArgs e)
        {
            try
            {
                ProPanel pnlConsulta = (ProPanel)this.LocalizarControle("pnlConsulta", this.Controls);
                pnlConsulta.Clear();
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
                    DefinirCamposBusca();
                    //base.Page_Load(sender, e);
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
            ProGridView grdListagem = (ProGridView)this.LocalizarControle("grdListagem", this.Controls);
            grdListagem.SortColumnName = e.SortExpression;
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
                ProGridView grdListagem = (ProGridView)this.LocalizarControle("grdListagem", this.Controls);
                ProDropDownList ddlCampoBusca;
                grdListagem.SelectedIndex = -1;
                if (this.LocalizarControle("ddlCampoBusca", this.Controls) != null)
                {
                    ddlCampoBusca = (ProDropDownList)this.LocalizarControle("ddlCampoBusca", this.Controls);
                    if ((ddlCampoBusca.SelectedIndex != -1) && (ddlCampoBusca.Visible))
                        txtBusca.DataField = ddlCampoBusca.SelectedItem.Value;
                }
                else
                {
                    lblBusca.Text = grdListagem.Columns[grdListagem.SortColumnIndex].HeaderText + " : ";
                    txtBusca.DataField = grdListagem.SortColumnName;
                }
                grdListagem.DataBind(this.Controladora.Consultar(pnlConsulta.GetFormData(), grdListagem.SortByDirection.ToString(), grdListagem.SortColumnName));
            }
            catch (Exception ex)
            {
                ExibirExcecao(ex);
            }
        }

        protected virtual void DefinirCamposBusca()
        {
            ProDropDownList ddlCampoBusca = (ProDropDownList)this.LocalizarControle("ddlCampoBusca", this.Controls);
            if (ddlCampoBusca != null)
            {
                ddlCampoBusca.Items.Clear();
                string columnText = "";
                string columnValue = "";
                bool boundedField = false;
                ProGridView grdListagem = (ProGridView)this.LocalizarControle("grdListagem", this.Controls);
                foreach (DataControlField dcfg in grdListagem.Columns)
                {
                    if (dcfg.Visible)
                    {
                        boundedField = false;
                        if (dcfg is ButtonField)
                        {
                            columnText = ((ButtonField)dcfg).HeaderText;
                            columnValue = ((ButtonField)dcfg).DataTextField;
                            boundedField = true;
                        }
                        else if (dcfg is BoundField)
                        {
                            columnText = ((BoundField)dcfg).HeaderText;
                            columnValue = ((BoundField)dcfg).DataField;
                            boundedField = true;
                        }

                        if (boundedField && columnValue.ToLower() != "pk" && columnText != "" && columnValue != "")
                            ddlCampoBusca.Items.Add(new ListItem(columnText, columnValue));
                    }
                }
            }
        }

        protected virtual void AlterarSelecao(int idItem)
        {
        }
        #endregion
    }
}
