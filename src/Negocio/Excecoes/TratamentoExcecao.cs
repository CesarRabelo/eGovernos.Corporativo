using System;
using System.Collections.Generic;
using System.Text;
using Pro.Utils;

namespace iLoan.Negocio.Excecoes
{
    public static class TratamentoExcecao
    {
        public static void Tratar(Exception excecao, string mensagem)
        {
            switch (excecao.GetType().Name)
            { 
                case "ComandoSqlException":
                    throw new ExecucaoException(mensagem + "#" + excecao.Message);
                    break;
                case "ConexaoException":
                    break;
                case "FactoryException":
                    break;
                default:
                    throw new GenericaException(mensagem);

            
            }
        }
    }
}
