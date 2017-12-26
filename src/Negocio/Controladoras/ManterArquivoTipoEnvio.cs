using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

using Pro.Utils;
using Pro.Dal;
using Platinium.Entidade;
  
using Negocio;

namespace Platinium.Negocio
{
    public class ManterArquivoTipoEnvio:IManter
    {
        
        #region Variáveis e Propriedades

        private ArquivoTipoEnvio oArquivoTipoEnvio;
        private Dao oDao;

        #endregion

        #region Construtores

        public ManterArquivoTipoEnvio()
		{
            oDao = new Dao();
		}

        public ManterArquivoTipoEnvio(string connectionString, DataBaseTypes dataBaseType)
        {
            oDao = new Dao(connectionString, dataBaseType);
        }

	    #endregion 
    
        #region Métodos

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao, string colunaSort)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(ArquivoTipoEnvio));
            dicionario.Add("DSC_TIPO_ENVIO", "DscTipoEnvio");
            List<Parameter> lstParametros = new List<Parameter>();
            foreach (KeyValuePair<string, object> item in filtros)
            {
                if (item.Value != null)
                {
                    if (item.Value.GetType() == typeof(Int32))
                        lstParametros.Add(new Parameter(item.Key, item.Value, OperationTypes.EqualsTo));
                    else
                        lstParametros.Add(new Parameter(item.Key, item.Value, OperationTypes.Like));
                }
            }
            lstParametros.Add(new Parameter(colunaSort, null, OperationTypes.Null, direcao));

            return this.oDao.Select(lstParametros, "platinium", "VI_ARQUIVO_TIPO_ENVIO", dicionario);

        }

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(ArquivoTipoEnvio));
            dicionario.Add("DSC_TIPO_ENVIO", "DscTipoEnvio");
            List<Parameter> lstParametros = new List<Parameter>();
            foreach (KeyValuePair<string, object> item in filtros)
            {
                if (item.Value != null)
                {
                    if (item.Value.GetType() == typeof(Int32))
                        lstParametros.Add(new Parameter(item.Key, item.Value, OperationTypes.EqualsTo));
                    else
                        lstParametros.Add(new Parameter(item.Key, item.Value, OperationTypes.Like));
                }
            }
            return this.oDao.Select(lstParametros, "platinium", "VI_ARQUIVO_TIPO_ENVIO", dicionario);
        }

        public void PrepararInclusao()
        {
            oArquivoTipoEnvio = new ArquivoTipoEnvio(oDao);
        }

        public Dictionary<string, object> Selecionar(int id)
        {
            oArquivoTipoEnvio = new ArquivoTipoEnvio(id, oDao);
            return ClassFunctions.GetProperties(oArquivoTipoEnvio);
        }

        public CrudActionTypes Salvar(Dictionary<string, object> valores)
        {
            ClassFunctions.SetProperties(oArquivoTipoEnvio, valores);
            return oArquivoTipoEnvio.Salvar();
        }

        public CrudActionTypes Excluir()
        {
            return oArquivoTipoEnvio.Excluir();
        }
        #endregion
    }
}
