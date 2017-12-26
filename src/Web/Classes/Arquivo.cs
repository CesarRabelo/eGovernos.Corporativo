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
using System.Text;
using System.Globalization;

namespace Web
{
    public class Arquivo
    {
        DataSet dts = new DataSet();
        List<Coluna> oColunas = new List<Coluna>();
        public List<Coluna> Colunas { get { return oColunas; } set { oColunas = value; } }

        string sNome = string.Empty;

        bool separarVirgula = false;
        bool aspasDuplas;
        bool trocarPonto;
        bool removerEspeciais;
        bool removerPontoVirgula;

        public DataSet DataSet
        {
            get { return dts; }
            set { dts = value; }
        }

        public string Nome
        {
            get { return sNome; }
            set { sNome = value; }
        }

        public string Extensao
        {
            get;
            set;
        }

        public bool SepararVirgula
        {
            get { return separarVirgula; }
            set { separarVirgula = value; }
        }

        public bool AspasDuplas
        {
            get { return aspasDuplas; }
            set { aspasDuplas = value; }
        }

        public bool TrocarPonto
        {
            get { return trocarPonto; }
            set { trocarPonto = value; }
        }

        public bool RemoverEspeciais
        {
            get { return removerEspeciais; }
            set { removerEspeciais = value; }
        }

        public bool RemoverPontoVirgula
        {
            get { return removerPontoVirgula; }
            set { removerPontoVirgula = value; }
        }

        protected string CompletaEspacoDireita(string texto, int tamanhoMax)
        {
            string textoBase;
            string espacos;
            ComplementaEspaco(texto, tamanhoMax, out textoBase, out espacos);
            return textoBase + espacos;
        }
        protected string CompletaEspacoEsquerda(string texto, int tamanhoMax)
        {
            string textoBase;
            string espacos;
            ComplementaEspaco(texto, tamanhoMax, out textoBase, out espacos);
            return espacos + textoBase;
        }
        private static void ComplementaEspaco(string texto, int tamanhoMax, out string textoBase, out string espacos)
        {
            textoBase = texto;//.Substring(0, tamanhoMax);
            espacos = string.Empty;
            if (textoBase.Length < tamanhoMax)
                for (int i = 0; i < tamanhoMax - textoBase.Length; i++)
                    espacos += " ";
        }

        protected string CompletaZerosDireita(string texto, int tamanhoMax)
        {
            string textoBase;
            string zeros;
            ComplementaZero(texto, tamanhoMax, out textoBase, out zeros);
            return textoBase + zeros;
        }
        protected string CompletaZerosEsquerda(string texto, int tamanhoMax)
        {
            string textoBase;
            string zeros;
            ComplementaZero(texto, tamanhoMax, out textoBase, out zeros);
            return zeros + textoBase;
        }
        private static void ComplementaZero(string texto, int tamanhoMax, out string textoBase, out string zeros)
        {
            textoBase = texto;//.Substring(0, tamanhoMax);
            zeros = string.Empty;
            if (textoBase.Length < tamanhoMax)
                for (int i = 0; i < tamanhoMax - textoBase.Length; i++)
                    zeros += "0";
        }

        public DataTable Linhas
        {
            get
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("linha", typeof(string));

                string sLinha = string.Empty;

                foreach (DataRow linha in DataSet.Tables[0].Rows)
                {
                    sLinha = string.Empty;

                    foreach (DataColumn coluna in DataSet.Tables[0].Columns)
                    {
                        if (SepararVirgula)
                            sLinha += ValorColuna(linha, coluna) + ",";
                        else
                            sLinha += ValorColuna(linha, coluna);
                    }
                    if (SepararVirgula)
                        dt.Rows.Add(sLinha.Substring(0, sLinha.Length - 1));
                    else
                        dt.Rows.Add(sLinha);
                }

                return dt;
            }
        }

        private string ValorColuna(DataRow linha, DataColumn coluna)
        {
            foreach (Coluna col in Colunas)
            {
                if (col.Sequencia == coluna.Ordinal + 1)
                {
                    string valor = linha[coluna.Ordinal].ToString();
                    valor = PreencherColuna(valor, col.TipoPreencimento, col.Posicoes);

                    if (valor.Length > col.Posicoes)
                        valor = valor.Substring(0, col.Posicoes);

                    if (RemoverEspeciais)
                    {
                        if (col.Tipo.ToLower() == "string")
                            valor = RemoveCaracteresEspeciais(valor);
                    }

                    if (AspasDuplas)
                    {
                        if (col.Tipo.ToLower() == "string")
                            valor =  "\"" + valor +"\"";
                    }                                       

                    if (TrocarPonto)
                    {
                        if (col.Tipo.ToLower() == "number" || col.Tipo.ToLower() == "decimal")
                            valor = TrocarPontoPorVirgula(valor);
                    }

                    if (RemoverPontoVirgula)
                    {
                        if (col.Tipo.ToLower() == "number" || col.Tipo.ToLower() == "decimal")
                            valor = RetirarPontoVirgula(valor);
                    }

                    return valor;
                }
            }
            return string.Empty;
        }

        private string PreencherColuna(string valor, MetodoPreenchimento metodoPreenchimento, int posicoes)
        {
            switch (metodoPreenchimento)
            {
                case MetodoPreenchimento.EspacosDireita:
                    valor = CompletaEspacoDireita(valor, posicoes);
                    break;
                case MetodoPreenchimento.EspacosEsquerda:
                    valor = CompletaEspacoEsquerda(valor, posicoes);
                    break;
                case MetodoPreenchimento.ZerosDireita:
                    valor = CompletaZerosDireita(valor, posicoes);
                    break;
                case MetodoPreenchimento.ZerosEsquerda:
                    valor = CompletaZerosEsquerda(valor, posicoes);
                    break;
            }
            return valor;
        }

        private string TrocarPontoPorVirgula(string valor)
        {
            valor = valor.Replace(".", "");
            valor = valor.Replace(",", ".");
            return valor;
        }

        private string RetirarPontoVirgula(string valor)
        {
            valor = valor.Replace(".", "");
            valor = valor.Replace(",", "");
            return valor;
        }

        private string RemoveCaracteresEspeciais(string texto)
        {
            Char aux;
            texto = texto.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();
            foreach (char c in texto.ToCharArray())
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                {
                    aux = c;
                    if (c.Equals('ª'))
                        aux = 'a';
                    if (c.Equals('º'))
                        aux = '.';
                    if (c.Equals('°'))
                        aux = '.';
                    sb.Append(aux);
                }
            return sb.ToString();
        }
    }

    public class Coluna
    {
        public int Sequencia { get; set; }
        public string Tipo { get; set; }
        public int Posicoes { get; set; }
        public MetodoPreenchimento TipoPreencimento { get; set; }
    }

    public enum MetodoPreenchimento
    {
        EspacosDireita = 1,
        EspacosEsquerda = 2,
        ZerosDireita = 3,
        ZerosEsquerda = 4
    }

   
}
