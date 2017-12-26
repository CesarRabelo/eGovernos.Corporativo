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

using Pro.Controls;
using System.Drawing;
using System.Drawing.Text;
using System.Drawing.Imaging;
using System.Collections;
using System.IO;
using iLoan.Negocio;

namespace Web
{
    /// <summary>
    /// Classe base para as páginas de galeria
    /// </summary>
    public class PaginaGaleriaBase : System.Web.UI.Page
    {
        #region Atributos
        System.Drawing.Image imgOriginal, imgThumbnail;
        public Dao oDao = new Dao();
        #endregion

        #region Propriedades
        public int paginaAtual
        {
            get
            {
                object o = this.ViewState["_CurrentPageProdutos"];
                if (o == null || (int)o < 0)
                    return 0;
                else
                    return (int)o;
            }
            set
            {
                this.ViewState["_CurrentPageProdutos"] = value;
            }
        }

        #endregion

        #region Eventos

        #endregion

        #region Métodos
        /// <summary>
        /// Retorna um objeto do tipo size ao receber, largura, altura e baseTamanho do thumbnail
        /// </summary>
        /// <param name="largura">Largura atual da imagem</param>
        /// <param name="altura">Altura atual da imagem</param>
        /// <param name="tamanhoBase">Será usado como base para gerar novo tamanho.</param>
        /// <returns></returns>
        protected Size NovoTamanho(decimal largura, decimal altura, decimal tamanhoBase)
        {
            Size novoTamanho = new Size();
            //Só muda se largura ou altura for maior que tamanhoBase
            if (largura > tamanhoBase || altura > tamanhoBase)
            {
                decimal tempPercentual;
                //Imagem tipo paisagem
                if (largura > altura)
                    tempPercentual = Convert.ToDecimal(tamanhoBase / largura);
                else
                    tempPercentual = Convert.ToDecimal(tamanhoBase / altura);
                //Largura e altura originais multiplicado pelo percentual sobre o tamanhoBase.
                novoTamanho = new Size(Convert.ToInt32(largura * tempPercentual), Convert.ToInt32(altura * tempPercentual));
            } //Tamanho recebe atuais 
            else { novoTamanho = new Size((int)largura, (int)altura); }
            return novoTamanho;
        }
        /// <summary>
        /// Salva a imagem fisicamente no caminho informado.
        /// </summary>
        /// <param name="arquivo"></param>
        /// <param name="destino"></param>
        /// <param name="tamanho"></param>
        protected void SalvarImagemRedimencionada(HttpPostedFile arquivo, string destino, int tamanho)
        {
            try
            {
                //Imagem enviada via HttpPostedFile e carregada via stream
                imgOriginal = System.Drawing.Image.FromStream(arquivo.InputStream);
                //Tamanho que ficará o thumbnail.
                Size tamanhoThumb = NovoTamanho(imgOriginal.Width, imgOriginal.Height, tamanho);
                //Thumbnail gerado a partir do original.
                imgThumbnail = new System.Drawing.Bitmap(imgOriginal, tamanhoThumb);
                //Salvando imagem no destino.
                imgThumbnail.Save(destino, imgOriginal.RawFormat);
            }
            catch (Exception ex) { throw ex; }
            finally
            {
                //Liberando espaço utilizado pelas variáveis.
                imgOriginal.Dispose();
                imgThumbnail.Dispose();
            }
        }
        /// <summary>
        /// Redimenciona em tempo de execução para o tamanho informado.
        /// </summary>
        /// <param name="arquivo"></param>
        /// <param name="tamanho"></param>
        protected void VisualizarImagemRedimencionada(string arquivo, int tamanho)
        {
            try
            {
                //Imagem enviada via HttpPostedFile e carregada via stream
                imgOriginal = System.Drawing.Image.FromFile(arquivo);
                //Tamanho que ficará o thumbnail.
                Size tamanhoThumb = NovoTamanho(imgOriginal.Width, imgOriginal.Height, tamanho);
                //Thumbnail gerado a partir do original.
                imgThumbnail = new System.Drawing.Bitmap(imgOriginal, tamanhoThumb);
                //Salvando imagem no destino.
                imgThumbnail.Save(Response.OutputStream, imgOriginal.RawFormat);
            }
            catch (Exception ex) { throw ex; }
            finally
            {
                //Liberando espaço utilizado pelas variáveis.
                imgOriginal.Dispose();
                imgThumbnail.Dispose();
            }
        }
        /// <summary>
        /// Redimenciona em tempo de execução para o tamanho informado.
        /// </summary>
        /// <param name="arquivo"></param>
        /// <param name="tamanho"></param>
        protected void VisualizarImagemTexto(string arquivo, int tamanho, string texto)
        {
            try
            {
                //Imagem enviada via HttpPostedFile e carregada via stream
                imgOriginal = System.Drawing.Image.FromFile(arquivo);
                //Tamanho que ficará o thumbnail.
                Size tamanhoThumb = NovoTamanho(imgOriginal.Width, imgOriginal.Height, tamanho);
                //Thumbnail gerado a partir do original.
                System.Drawing.Bitmap thumb = new Bitmap(tamanhoThumb.Width, tamanhoThumb.Height + 18);
                System.Drawing.Graphics grafico = Graphics.FromImage(thumb);
                imgThumbnail = new System.Drawing.Bitmap(imgOriginal, tamanhoThumb);
                grafico.DrawImage(imgThumbnail, new Point(0, 18));
                grafico.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                //grafico.FillRectangle(Brushes.Orange, 0, 0, imgThumbnail.Width, 18);
                grafico.FillRectangle(Brushes.Orange, 0, 0, imgThumbnail.Width, 18);
                grafico.FillRectangle(Brushes.White, 1, 1, imgThumbnail.Width - 2 , 18);
                grafico.DrawString(texto, new Font("Verdana", 10, FontStyle.Regular), Brushes.Black, 10, 2);
                //Criar Gráfico
                //Salvando imagem no destino.
                thumb.Save(Response.OutputStream, imgOriginal.RawFormat);
            }
            catch (Exception ex) { throw ex; }
            finally
            {
                //Liberando espaço utilizado pelas variáveis.
                imgOriginal.Dispose();
                imgThumbnail.Dispose();
            }
        }
        /// <summary>
        /// Devolve um pagedDataSouce paginado.
        /// </summary>
        /// <param name="dataSource"></param>
        /// <param name="pagina"></param>
        /// <param name="tamanhoPagina"></param>
        /// <returns></returns>
        protected PagedDataSource PaginarDataSource(IEnumerable dataSource, int pagina, int tamanhoPagina)
        {
            //Objeto responsável pela paginação
            PagedDataSource paginar = new PagedDataSource();
            //Objeto será paginado = true
            paginar.AllowPaging = true;
            //Objeto recebe o array
            paginar.DataSource = dataSource;
            //Objeto recebe a qtd de registro por página
            paginar.PageSize = tamanhoPagina;
            //Objeto paginar recebe a pagina que deve mostrar
            paginar.CurrentPageIndex = pagina;
            //Pagina Atual recebe a página informada.
            paginaAtual = pagina;
            //Devolve o Paged DataSource
            return paginar;
        }
        /// <summary>
        /// Retorna a pasta onde as imagens do imóvel estão.
        /// </summary>
        /// <param name="idImagem"></param>
        /// <returns></returns>
        protected string pastaImagens(int idImovel)
        {
            int pasta = (idImovel / 1000) + 1;
            string sPasta = Zeros(pasta.ToString(), 6);
            return sPasta;
        }
        /// <summary>
        /// Pega o texto e preenche com a qtd de zeros necessário.
        /// </summary>
        /// <param name="numero"></param>
        /// <param name="zeros"></param>
        /// <returns></returns>
        protected string Zeros(string numero, int zeros)
        {
            int qtd = (zeros - numero.Length);
            for (int i = 0; i < qtd; i++)
                numero = "0" + numero;
            return numero;
        }

        protected DirectoryInfo CriarDiretorio(string caminho, bool criar)
        {
            DirectoryInfo diretorio = new DirectoryInfo(Server.MapPath(caminho));
            if (!diretorio.Exists && criar) diretorio.Create();
            return diretorio;
        }

        protected string CaminhoImagem(string idImovel, string idImagem, string extensao)
        {
            return pastaImagens(Convert.ToInt32(idImovel)) + "\\"
                    + Zeros(idImovel, 6) + "_" + idImagem + extensao.Trim();
        }
        #endregion
    }
}
