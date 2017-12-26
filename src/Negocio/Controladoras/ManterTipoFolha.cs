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
    public class ManterTipoFolha:IManter
    {
        
        #region Variáveis e Propriedades

        private TipoFolha oTipoFolha;
        private Dao oDao;

        #endregion

        #region Construtores

        public ManterTipoFolha()
		{
            oDao = new Dao();
		}

        public ManterTipoFolha(string connectionString, DataBaseTypes dataBaseType)
        {
            oDao = new Dao(connectionString, dataBaseType);
        }

	    #endregion 
    
        #region Métodos

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao, string colunaSort)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(TipoFolha));
            dicionario.Add("DSC_ATIVO", "DscAtivo");


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

            return this.oDao.Select(lstParametros, "plutonium", "VI_TIPO_FOLHA_PAGAMENTO_TIFP", dicionario);

        }

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(TipoFolha));
            dicionario.Add("DSC_ATIVO", "DscAtivo");

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
            return this.oDao.Select(lstParametros, "plutonium", "VI_TIPO_FOLHA_PAGAMENTO_TIFP", dicionario);
        }

        public void PrepararInclusao()
        {
            oTipoFolha = new TipoFolha(oDao);
        }

        public Dictionary<string, object> Selecionar(int id)
        {
            oTipoFolha = new TipoFolha(id, oDao);
            return ClassFunctions.GetProperties(oTipoFolha);
        }

        public CrudActionTypes Salvar(Dictionary<string, object> valores)
        {
            ClassFunctions.SetProperties(oTipoFolha, valores);
            return oTipoFolha.Salvar();
        }

        public CrudActionTypes Excluir()
        {
            return oTipoFolha.Excluir();
        }
        #endregion
    
    }
}
