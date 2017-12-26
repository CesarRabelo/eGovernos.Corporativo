using System;
using System.Collections.Generic;
using System.Text;

namespace iLoan.Negocio.Excecoes
{
    public class RegraNegocioException : Exception
    {
        public RegraNegocioException(string mensagem) : base(mensagem)
        {

        }

    }
}
