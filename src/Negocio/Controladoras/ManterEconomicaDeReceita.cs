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
    public class ManterEconomicaDeReceita:IManter
    {
        
        #region Variáveis e Propriedades

        private EconomicaDeReceita oEconomicaDeReceita;
        private Dao oDao;

        #endregion

        #region Construtores

        public ManterEconomicaDeReceita()
		{
            oDao = new Dao();
		}

        public ManterEconomicaDeReceita(string connectionString, DataBaseTypes dataBaseType)
        {
            oDao = new Dao(connectionString, dataBaseType);
        }

	    #endregion 
    
        #region Métodos

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao, string colunaSort)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(EconomicaDeReceita));
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

            return this.oDao.Select(lstParametros, "platinium", "VI_CAT_ECONOMICA_RECE", dicionario);

        }

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(EconomicaDeReceita));
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
            return this.oDao.Select(lstParametros, "platinium", "VI_CAT_ECONOMICA_RECE", dicionario);
        }

        public void PrepararInclusao()
        {
            oEconomicaDeReceita = new EconomicaDeReceita(oDao);
        }

        public Dictionary<string, object> Selecionar(int id)
        {
            oEconomicaDeReceita = new EconomicaDeReceita(id, oDao);
            return ClassFunctions.GetProperties(oEconomicaDeReceita);
        }

        public CrudActionTypes Salvar(Dictionary<string, object> valores)
        {
            ClassFunctions.SetProperties(oEconomicaDeReceita, valores);
            return oEconomicaDeReceita.Salvar();
        }

        public CrudActionTypes Excluir()
        {
            return oEconomicaDeReceita.Excluir();
        }
        #endregion
    }
}
