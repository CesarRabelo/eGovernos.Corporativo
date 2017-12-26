using System;
using System.Collections.Generic;
using System.Text;

namespace iLoan.Negocio.Excecoes
{
    public class NaoAutorizadoException:Exception
    {
        public NaoAutorizadoException(string menssagem): base(menssagem)
        {
        }
    }
}
