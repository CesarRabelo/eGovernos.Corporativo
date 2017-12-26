using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Configuration;
using System.Web;
using System.Text;
using Platinium.Negocio;
using Atom.Client.Classes;
using Atom.ClientNegocio;

namespace Platinium.Negocio
{

    public static class Memory
    {
        public enum TipoDeEntidade { Secretaria, Orgao, UnidadeOrcamentaria }

        private static string sConfiguracoes = "$nvcReferenciaConfiguracoes$";

        public static void SetarEntidadeLimite(int id)
        {
            HttpContext.Current.Session[sConfiguracoes] = (TipoDeEntidade)id;
        }

        public static TipoDeEntidade EntidadeLimite
        {
            get {
                if (HttpContext.Current.Session[sConfiguracoes] == null)
                    return TipoDeEntidade.Orgao;
                else
                    return (TipoDeEntidade)HttpContext.Current.Session[sConfiguracoes]; 
            }
        }

    }
}
