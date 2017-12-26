using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace Imobium.Negocio.Excecoes
{
    public class CampoInvalidoException : Exception
    {
        private string stNomeCampo;
        private Dictionary<string, string> dctMensagens = new Dictionary<string, string>(StringComparer.CurrentCultureIgnoreCase);
                
        public CampoInvalidoException(): base("Campo nulo ou inv�lido.")
        {

        }

        public CampoInvalidoException(string mensagem): base("Campo nulo ou inv�lido.")
        {
            Mensagens.Add("excecao", mensagem);
        }

        public CampoInvalidoException(string nomeCampo, string menssagem)
            : base("Campo nulo ou inv�lido.")
        {
            this.stNomeCampo = nomeCampo;  
            dctMensagens.Add(nomeCampo,menssagem);
        }    

        public string NomeCampo
        {
            get { return stNomeCampo; }
            set { stNomeCampo = value; }
        }

        public Dictionary<string,string> Mensagens
        {
            get { return dctMensagens; }
            set { dctMensagens = value; }
        }
   
    }
}
