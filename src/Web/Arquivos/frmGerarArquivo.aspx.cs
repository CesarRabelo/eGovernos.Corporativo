using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;

namespace Web
{
    public partial class frmGerarArquivo : System.Web.UI.Page
    {
        protected string NomeArquivo{ get;set; }
        protected string LocalGravacao{ get;set; }
        protected string Arquivo { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["arq"] != null && Session[Request.QueryString["arq"]] != null)
            {
                NomeArquivo = Request.QueryString["arq"];
                Arquivo oArquivo = (Arquivo)Session[NomeArquivo];
                
                //System.IO.Stream oStream;
                System.IO.StreamWriter oStreamWriter = new StreamWriter(Server.MapPath(NomeArquivo), true);
                

                //System.IO.StreamWriter FileTexto = FileTexto = System.IO.File.CreateText(Server.MapPath(NomeArquivo));
                string sLinha = string.Empty;

                foreach (DataRow linha in oArquivo.Linhas.Rows)
                {
                    sLinha = linha[0].ToString();
                    //FileTexto.WriteLine(sLinha);
                    oStreamWriter.WriteLine(sLinha);
                }
                oStreamWriter.Close();
                FileStream oFileStream = new FileStream(Server.MapPath(NomeArquivo), FileMode.Open);
                
                //Stream oStream = FileTexto.BaseStream;

                
                BinaryReader oBinaryReader = new BinaryReader(oFileStream);
                byte[] vetor = new byte[oFileStream.Length];
                for (int i = 0; i < oFileStream.Length; ++i)
                    vetor[i] = oBinaryReader.ReadByte();

                Response.ClearContent();
                Response.ClearHeaders();
                Response.AddHeader("Content-Disposition", "attachment;filename=" + NomeArquivo);// Request.QueryString["rpt"]);
                //FileTexto.Close();
                
                oFileStream.Close();
                Response.BinaryWrite(vetor);
                Response.Flush();
                Response.Close();
            }
        }
        protected void btnGerar_OnClick(object sender, EventArgs e)
        {
            GerarArquivo();
        }
        /// <summary>
        /// Definição do nome do arquivo
        /// </summary>
        /// <param name="prefixo"></param>
        /// <param name="mascara"></param>
        /// <param name="sufixo"></param>
        /// <returns></returns>
        public void SetarNomeArquivo(string prefixo, string mascara, string sufixo)
        {
            NomeArquivo = string.Format("{0}{1}{2}", prefixo, mascara, sufixo);
        }

        public void SetarLocalGravacao(string destino)
        {
            LocalGravacao = Request.PhysicalApplicationPath + @"\"+destino;
        }

        public string GerarArquivo()
        {
            // Criação do arquivo em disco
            System.IO.StreamWriter FileTexto = FileTexto = System.IO.File.CreateText(LocalGravacao + NomeArquivo);
            string linha = string.Empty;
            FileTexto.WriteLine(linha);
            FileTexto.Close();
            //HyperLink1.NavigateUrl = "/transportes/transmissao/" + Ambiente.FileName;
            //HyperLink1.Target = "_blank";
            //HyperLink1.Text = "Arquivo gerado com sucesso, click aqui para visualizar";
            return Arquivo;
        }

        
    }
}