using System;
using System.IO;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Platinium.Comum;

namespace Web.Relatorios
{
    public partial class frmGerarRelatorio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //try
            //{
                //if (Request.QueryString["rpt"] != null && Pro.Utils.Container.ObjectBox[Request.QueryString["rpt"]] != null)
                if (Request.QueryString["rpt"] != null && Session[Request.QueryString["rpt"]] != null)
                {
                    //Relatorio oRelatorio = (Relatorio)Pro.Utils.Container.ObjectBox[Request.QueryString["rpt"]];
                    Relatorio oRelatorio = (Relatorio)Session[Request.QueryString["rpt"]];
                    ReportDocument oReportDocument = new ReportDocument();
                    oReportDocument.Load(Server.MapPath(oRelatorio.Arquivo));

                    //if(!oRelatorio.DataSet.Tables.Contains("CABECALHO"))
                    //    oRelatorio.DataSet.Tables.Add(DadosCabecalho.Copy());

                    for(int i = 0; i< oReportDocument.Subreports.Count; i++)
                        oReportDocument.Subreports[i].SetDataSource(oRelatorio.DataSet);

                    oReportDocument.SetDataSource(oRelatorio.DataSet);
                    AdicionarParametros(ref oRelatorio, ref oReportDocument);

                    Stream oStream = oReportDocument.ExportToStream(oRelatorio.Formato);
                    BinaryReader oBinaryReader = new BinaryReader(oStream);
                    byte[] vetor = new byte[oStream.Length];
                    for (int i = 0; i < oStream.Length; ++i)
                        vetor[i] = oBinaryReader.ReadByte();

                    

                    Response.ClearContent();
                    Response.ClearHeaders();
                    if (oRelatorio.Formato == ExportFormatType.PortableDocFormat)
                        Response.ContentType = oRelatorio.ContentType;
                    else
                        Response.AddHeader("Content-Disposition", "attachment;filename=" + Request.QueryString["rpt"] + "." + oRelatorio.FormatoArquivo);
                    Response.BinaryWrite(vetor);
                    Response.Flush();
                    Response.Close();
                }
            //}
            //catch (Exception ex)
            //{
            //    lblErro.Text = "Falha ao gerar relatório.";
            //}
        }

        private void AdicionarParametros(ref Relatorio oRelatorio, ref ReportDocument oReportDocument)
        {
            if (oRelatorio.Parametros.Count > 0)
                foreach (ParameterField parametro in oRelatorio.Parametros)
                {
                    oReportDocument.SetParameterValue(parametro.Name, parametro.CurrentValues[0]);
                }
        }


        private DataTable DadosCabecalho
        {
            get
            {
                if (Application["$CabecalhoRelatorio$"] == null)
                {
                    ExibirRelatorio oExibirRelatorio = new ExibirRelatorio();
                    Application["$CabecalhoRelatorio$"] = oExibirRelatorio.ListarCabecalho();
                }
                return (DataTable)Application["$CabecalhoRelatorio$"];
            }
        }
    }
}
