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
    public class ManterMoeda:IManter
    {
        
        #region Variáveis e Propriedades

        private Moeda oMoeda;
        private Dao oDao;

        #endregion

        #region Construtores

        public ManterMoeda()
		{
            oDao = new Dao();
		}

        public ManterMoeda(string connectionString, DataBaseTypes dataBaseType)
        {
            oDao = new Dao(connectionString, dataBaseType);
        }

	    #endregion 
    
        #region Métodos

        public void PrepararInclusao()
        {
            oMoeda = new Moeda(oDao);
        }

        public Dictionary<string, object> Selecionar(int id)
        {
            oMoeda = new Moeda(id, oDao);
            return ClassFunctions.GetProperties(oMoeda);
        }

        public CrudActionTypes Salvar(Dictionary<string, object> valores)
        {
            ClassFunctions.SetProperties(oMoeda, valores);
            return oMoeda.Salvar();
        }

        public CrudActionTypes Excluir()
        {
            return oMoeda.Excluir();
        }

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao, string colunaSort)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(Moeda));

            List<Parameter> lstParametros = new List<Parameter>();
            foreach (KeyValuePair<string, object> item in filtros)
            {
                lstParametros.Add(new Parameter(item.Key, item.Value, OperationTypes.Like));
            }
            lstParametros.Add(new Parameter(colunaSort, null, OperationTypes.Null, direcao));

            return this.oDao.Select(lstParametros, "platinium", "TB_MOEDA_MOED", dicionario);

        }

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(Moeda));

            List<Parameter> lstParametros = new List<Parameter>();
            foreach (KeyValuePair<string, object> item in filtros)
            {
                lstParametros.Add(new Parameter(item.Key, item.Value, OperationTypes.Like, direcao));
            }
            return this.oDao.Select(lstParametros, "platinium", "TB_MOEDA_MOED", dicionario);
        }

        #endregion
    }
}
