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
using Negocio;

namespace Web
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {                
                //ManterContratoLocacao cl = new ManterContratoLocacao();
                //DataTable dt = cl.ListaImoveisReajuste();
                //if (dt.Rows.Count > 0)
                //{
                //    pnlListagem.Visible = true;
                //    grdListagem.DataSource = dt;
                //    grdListagem.DataBind();
                //}
                //else
                //    pnlListagem.Visible = false;
            }
        }

        protected void grdListagem_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int dias = Convert.ToInt32(e.Row.Cells[4].Text);
                if (dias < 0)
                {
                    e.Row.Cells[0].ForeColor = System.Drawing.Color.Red;
                    e.Row.Cells[1].ForeColor = System.Drawing.Color.Red;
                    e.Row.Cells[2].ForeColor = System.Drawing.Color.Red;
                    e.Row.Cells[3].ForeColor = System.Drawing.Color.Red;
                    e.Row.Cells[4].ForeColor = System.Drawing.Color.Red;
                }
            }
            else if (e.Row.RowType == DataControlRowType.Pager)
            {
                e.Row.Style.Add("PagerStyle", "obj_Grid_Pager");
            }

        }
        protected void grdListagem_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //grdListagem.PageIndex = e.NewPageIndex;
            //ManterContratoLocacao cl = new ManterContratoLocacao();
            //grdListagem.DataBind(cl.ListaImoveisReajuste());
        }
    }
}
