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
    public class ManterEconomicaDeDespesa:IManter
    {
        
        #region Variáveis e Propriedades

        private EconomicaDeDespesa oEconomicaDeDespesa;
        private Dao oDao;

        #endregion

        #region Construtores

        public ManterEconomicaDeDespesa()
		{
            oDao = new Dao();
		}

        public ManterEconomicaDeDespesa(string connectionString, DataBaseTypes dataBaseType)
        {
            oDao = new Dao(connectionString, dataBaseType);
        }

	    #endregion 
    
        #region Métodos

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao, string colunaSort)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(EconomicaDeDespesa));
            dicionario.Add("dsc_ativo", "DscAtivo");


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

            return this.oDao.Select(lstParametros, "platinium", "VI_CAT_ECONOMICA_DESPESA_CAED", dicionario);

        }

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(EconomicaDeDespesa));
            dicionario.Add("dsc_ativo", "DscAtivo");

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
            return this.oDao.Select(lstParametros, "platinium", "VI_CAT_ECONOMICA_DESPESA_CAED", dicionario);
        }

        public void PrepararInclusao()
        {
            oEconomicaDeDespesa = new EconomicaDeDespesa(oDao);
        }

        public Dictionary<string, object> Selecionar(int id)
        {
            oEconomicaDeDespesa = new EconomicaDeDespesa(id, oDao);
            return ClassFunctions.GetProperties(oEconomicaDeDespesa);
        }

        public CrudActionTypes Salvar(Dictionary<string, object> valores)
        {
            ClassFunctions.SetProperties(oEconomicaDeDespesa, valores);
            return oEconomicaDeDespesa.Salvar();
        }

        public CrudActionTypes Excluir()
        {
            return oEconomicaDeDespesa.Excluir();
        }
        #endregion
    }
}
