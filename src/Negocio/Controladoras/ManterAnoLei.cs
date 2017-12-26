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
    public class ManterAnoLei:IManter
    {
        
        #region Variáveis e Propriedades

        private AnoLei oAnoLei;
        private Dao oDao;

        #endregion

        #region Construtores

        public ManterAnoLei()
		{
            oDao = new Dao();
		}

        public ManterAnoLei(string connectionString, DataBaseTypes dataBaseType)
        {
            oDao = new Dao(connectionString, dataBaseType);
        }

	    #endregion 
    
        #region Métodos

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao, string colunaSort)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(AnoLei));

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

            return this.oDao.Select(lstParametros, "platinium", "TB_ANO_LEI_ANLE", dicionario);

        }

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(AnoLei));

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
            return this.oDao.Select(lstParametros, "platinium", "TB_ANO_LEI_ANLE", dicionario);
        }

        public void PrepararInclusao()
        {
            oAnoLei = new AnoLei(oDao);
        }

        public Dictionary<string, object> Selecionar(int id)
        {
            oAnoLei = new AnoLei(id, oDao);
            return ClassFunctions.GetProperties(oAnoLei);
        }

        public CrudActionTypes Salvar(Dictionary<string, object> valores)
        {
            ClassFunctions.SetProperties(oAnoLei, valores);
            return oAnoLei.Salvar();
        }

        public CrudActionTypes Excluir()
        {
            return oAnoLei.Excluir();
        }
        #endregion
    }
}
