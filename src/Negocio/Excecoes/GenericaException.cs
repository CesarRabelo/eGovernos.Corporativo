using System;
using System.Collections.Generic;
using System.Text;

using Pro.Utils;

namespace iLoan.Negocio.Excecoes
{
    public class GenericaException:Exception
    {

        private string stIdExcecao = string.Empty;

        public GenericaException(string menssagem): base(menssagem)
        {
            stIdExcecao =  Pro.Utils.Log.WriteLog(this, null);
        }

        public GenericaException(string menssagem, Exception excecaoOrigem)
            : base(menssagem)
        {
            stIdExcecao = Pro.Utils.Log.WriteLog(this, excecaoOrigem);
        }

        public string IdExcecao
        {
            get { return stIdExcecao; }
        }

        public override string Message
        {
            get
            {
                string stMensagem = stIdExcecao == string.Empty ? base.Message : "(" + stIdExcecao + ") :" + base.Message;
                return stMensagem;
            }
        }
    }
}
