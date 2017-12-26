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
    public class ManterTipoDesligamento:IManter
    {
        
        #region Variáveis e Propriedades

        private TipoDesligamento oTipoDesligamento;
        private Dao oDao;

        #endregion

        #region Construtores

        public ManterTipoDesligamento()
		{
            oDao = new Dao();
		}

        public ManterTipoDesligamento(string connectionString, DataBaseTypes dataBaseType)
        {
            oDao = new Dao(connectionString, dataBaseType);
        }

	    #endregion 
        
        #region Métodos

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao, string colunaSort)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(TipoDesligamento));
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

            return this.oDao.Select(lstParametros, "plutonium", "VI_TIPO_DESLIGAMENTO_TIDE", dicionario);

        }

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(TipoDesligamento));
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
            return this.oDao.Select(lstParametros, "plutonium", "VI_TIPO_DESLIGAMENTO_TIDE", dicionario);
        }

        public void PrepararInclusao()
        {
            oTipoDesligamento = new TipoDesligamento(oDao);
        }

        public Dictionary<string, object> Selecionar(int id)
        {
            oTipoDesligamento = new TipoDesligamento(id, oDao);
            return ClassFunctions.GetProperties(oTipoDesligamento);
        }

        public CrudActionTypes Salvar(Dictionary<string, object> valores)
        {
            ClassFunctions.SetProperties(oTipoDesligamento, valores);
            return oTipoDesligamento.Salvar();
        }

        public CrudActionTypes Excluir()
        {
            return oTipoDesligamento.Excluir();
        }
        #endregion

    }
}
