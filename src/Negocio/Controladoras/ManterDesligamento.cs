using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

using Pro.Utils;
using Pro.Dal;
using Platinium.Negocio;
using Platinium.Entidade;
using Negocio;

namespace Platinium.Negocio
{
    public class ManterDesligamento:IManter
    {
        
        #region Variáveis e Propriedades

        private Desligamento oDesligamento;
        private Dao oDao;

        #endregion

        #region Construtores

        public ManterDesligamento()
		{
            oDao = new Dao();
		}

        public ManterDesligamento(string connectionString, DataBaseTypes dataBaseType)
        {
            oDao = new Dao(connectionString, dataBaseType);
        }

	    #endregion 
        
        #region Métodos

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao, string colunaSort)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(Desligamento));

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

            return this.oDao.Select(lstParametros, "plutonium", "TB_DESLIGAMENTO_AGENTE_PUBLICO_DEAP", dicionario);

        }

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(Desligamento));

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
            return this.oDao.Select(lstParametros, "plutonium", "TB_DESLIGAMENTO_AGENTE_PUBLICO_DEAP", dicionario);
        }

        public void PrepararInclusao()
        {
            oDesligamento = new Desligamento(oDao);
        }

        public Dictionary<string, object> Selecionar(int id)
        {
            oDesligamento = new Desligamento(id, oDao);
            return ClassFunctions.GetProperties(oDesligamento);
        }

        public CrudActionTypes Salvar(Dictionary<string, object> valores)
        {
            ClassFunctions.SetProperties(oDesligamento, valores);
            return oDesligamento.Salvar();
        }

        public CrudActionTypes Excluir()
        {
            return oDesligamento.Excluir();
        }
        #endregion

    }
}
