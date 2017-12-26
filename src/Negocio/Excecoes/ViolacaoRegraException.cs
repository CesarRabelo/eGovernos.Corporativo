using System;
using System.Collections.Generic;
using System.Text;

namespace Imobium.Negocio.Excecoes
{
    public class ViolacaoRegraException:Exception
    {
        public ViolacaoRegraException(string menssagem)
            : base(menssagem)
        {
        }
    }
}
