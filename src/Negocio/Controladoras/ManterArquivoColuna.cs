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
    public class ManterArquivoColuna:IManter
    {
        
        #region Variáveis e Propriedades

        private ArquivoColuna oArquivoColuna;
        private Dao oDao;

        #endregion

        #region Construtores

        public ManterArquivoColuna()
		{
            oDao = new Dao();
		}

        public ManterArquivoColuna(string connectionString, DataBaseTypes dataBaseType)
        {
            oDao = new Dao(connectionString, dataBaseType);
        }

	    #endregion 
    
        #region Métodos

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao, string colunaSort)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(ArquivoColuna));
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

            return this.oDao.Select(lstParametros, "platinium", "tb_arquivo_coluna_arco", dicionario);

        }

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(ArquivoColuna));
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
            return this.oDao.Select(lstParametros, "platinium", "tb_arquivo_coluna_arco", dicionario);
        }

        public void PrepararInclusao()
        {
            oArquivoColuna = new ArquivoColuna(oDao);
        }

        public Dictionary<string, object> Selecionar(int id)
        {
            oArquivoColuna = new ArquivoColuna(id, oDao);
            return ClassFunctions.GetProperties(oArquivoColuna);
        }

        public CrudActionTypes Salvar(Dictionary<string, object> valores)
        {
            ClassFunctions.SetProperties(oArquivoColuna, valores);
            return oArquivoColuna.Salvar();
        }

        public CrudActionTypes Excluir()
        {
            return oArquivoColuna.Excluir();
        }
        #endregion
    }
}
