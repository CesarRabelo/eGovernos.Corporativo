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

using Pro.Utils;
using Negocio;
using Platinium.Comum;
using Platinium.Negocio;
using Atom.ClientWeb;
using System.IO;

namespace Web.Arquivos
{
    public partial class ArquivosGeral : ArquivoBase
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Controladora = new ExibirArquivo();
                this.TituloPagina = "Arquivos: Todos os Arquivos";
                ddlArquivo.DataBind(new Listas().Arquivos);
                txtMes.TypedValue = DateTime.Now;
            }
            base.Page_Load(sender, e);
        }
        protected void btnDetalhes_Click(object sender, EventArgs e)
        {
            DataTable dtCols = ((ExibirArquivo)Controladora).DadosColunas(ddlArquivo.SelectedValue);
            grdListagem.DataBind(dtCols);
        }
        protected override void btnGerar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(ddlArquivo.SelectedValue))
                    throw new Exception("É necessário selecionar um arquivo.");

                Arquivo oArquivo = new Arquivo();
                oArquivo.Nome = ((ExibirArquivo)Controladora).NomeArquivo(ddlArquivo.SelectedValue, Convert.ToDateTime(txtMes.TypedValue));
                verificarExistenciaArquivo(oArquivo.Nome);
                oArquivo.DataSet.Tables.Add(((ExibirArquivo)Controladora).DadosArquivo(ddlArquivo.SelectedValue));
                DataTable dtCols = ((ExibirArquivo)Controladora).DadosColunas(ddlArquivo.SelectedValue);

                foreach (DataRow linha in dtCols.Rows)
                {
                    oArquivo.Colunas.Add(new Coluna()
                    {
                        Sequencia = Convert.ToInt32(linha["Sequencia"].ToString()),
                        Posicoes = Convert.ToInt32(linha["Posicoes"].ToString()),
                        Tipo = linha["Tipo"].ToString(),
                        TipoPreencimento = ((MetodoPreenchimento)Convert.ToInt32(linha["MetodoComplemento"].ToString()))
                    });
                }
                oArquivo.RemoverEspeciais = chkRemoverEspeciais.Checked;
                oArquivo.SepararVirgula = chkSepararVirgula.Checked;
                oArquivo.TrocarPonto = chkTrocarPonto.Checked;
                oArquivo.AspasDuplas = chkAspasDuplas.Checked;
                oArquivo.RemoverPontoVirgula = chkRemoverPontoVirgula.Checked;
                Session[oArquivo.Nome] = oArquivo;
                ExibirArquivo(oArquivo.Nome);

                //base.btnGerar_Click(sender, e);
            }
            catch (Exception ex)
            {
                ExibirAlerta(TiposMensagem.Alerta, "Arquivo não gerado.", ex.Message);
            }
        }

        private void verificarExistenciaArquivo(string file)
        {
            if (File.Exists(Server.MapPath("Arquivos/" + file)))
                System.IO.File.Delete(Server.MapPath("Arquivos/" + file));
        }

        #region Relatórios

        protected void btnVisualizarArquivo_Click(object sender, EventArgs e)
        {

            try
            {
                Relatorio oRelatorio = new Relatorio();
                ExibirRelatorio oExibirRelatorio = new ExibirRelatorio();                
                oRelatorio.DataSet.Tables.Add(oExibirRelatorio.VisualizarArquivo(ddlArquivo.SelectedValue));                
                oRelatorio.Arquivo = "VisualizarArquivo.rpt";
                oRelatorio.SetarFormatoArquivo("PDF");
                Session["VisualizarArquivo"] = oRelatorio;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "VisualizarArquivo", "window.open('Relatorios/frmGerarRelatorio.aspx?rpt=VisualizarArquivo','VisualizarArquivo','location=0,status=1,resizable=1,scrollbars=1,width=800,height=600,top=10,left=10');", true);
            }
            catch (Exception ex)
            {
                ExibirAlerta(TiposMensagem.Alerta, "Erro na visualização do arquivo.", ex.Message);
            }
        }

        #endregion
    }
}
