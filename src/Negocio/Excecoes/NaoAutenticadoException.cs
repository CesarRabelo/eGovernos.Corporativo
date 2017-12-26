using System;
using System.Collections.Generic;
using System.Text;

namespace iLoan.Negocio.Excecoes
{
    public class NaoAutenticadoException:Exception
    {
        public NaoAutenticadoException()
            : base("Usuário não autenticado.")
        {
        }
    }
}
