using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;

namespace Web
{
    public class Relatorio
    {
        private ParameterFields _parametros = new ParameterFields();
        /// <summary>
        /// Lista os parâmetros adicionados.
        /// </summary>
        public ParameterFields Parametros
        {
            get { return _parametros; }
        }
        DataSet dts = new DataSet();
        string sArquivo = string.Empty;
        CrystalDecisions.Shared.ExportFormatType eFormato = CrystalDecisions.Shared.ExportFormatType.PortableDocFormat;

        public DataSet DataSet
        {
            get { return dts; }
            set { dts = value; }
        }
        

        public string Arquivo
        {
            get { return sArquivo; }
            set { sArquivo = value; }
        }
        public string FormatoArquivo
        {
            get;
            set;
        }
        public string ContentType
        {
            get
            {
                switch (this.Formato)
                {
                    case CrystalDecisions.Shared.ExportFormatType.WordForWindows:
                        return "application/msword";
                    case CrystalDecisions.Shared.ExportFormatType.HTML40:
                        return "text/html";
                    case CrystalDecisions.Shared.ExportFormatType.PortableDocFormat:
                        return "application/pdf";
                    case CrystalDecisions.Shared.ExportFormatType.RichText:
                        return "application/rtf";
                    case CrystalDecisions.Shared.ExportFormatType.ExcelRecord:
                        return "application/ms-excel";
                    default:
                        return "application/pdf";
                }
            }
        }

        public CrystalDecisions.Shared.ExportFormatType Formato
        {
            get{ return eFormato; }
            set { eFormato = value; }
        }


        public void SetarFormatoArquivo(string formato)
        {
            FormatoArquivo = formato;
            switch (formato)
            {
                case "DOC":
                    eFormato = CrystalDecisions.Shared.ExportFormatType.WordForWindows;
                    break;
                case "HTML":
                    eFormato = CrystalDecisions.Shared.ExportFormatType.HTML40;
                    break;
                case "PDF":
                    eFormato = CrystalDecisions.Shared.ExportFormatType.PortableDocFormat;
                    break;
                case "RTF":
                    eFormato = CrystalDecisions.Shared.ExportFormatType.RichText;
                    break;
                case "XLS":
                    eFormato = CrystalDecisions.Shared.ExportFormatType.ExcelRecord;
                    break;
                default:
                    eFormato = CrystalDecisions.Shared.ExportFormatType.PortableDocFormat;
                    break;
            }
        }

        public void AdicionarParametro(string nome, object valor)
        {
            ParameterField field = new ParameterField();
            field.Name = nome;

            ParameterDiscreteValue discretValor = new ParameterDiscreteValue();
            ParameterValues valores = new ParameterValues();
            
            discretValor.Value = valor;
            valores.Add(discretValor);

            field.CurrentValues = valores;
            _parametros.Add(field);
        }
    }
}
