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
    public class ManterTipoReingresso:IManter
    {
        
        #region Variáveis e Propriedades

        private TipoReingresso oTipoReingresso;
        private Dao oDao;

        #endregion

        #region Construtores

        public ManterTipoReingresso()
		{
            oDao = new Dao();
		}

        public ManterTipoReingresso(string connectionString, DataBaseTypes dataBaseType)
        {
            oDao = new Dao(connectionString, dataBaseType);
        }

	    #endregion 
        
        #region Métodos

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao, string colunaSort)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(TipoReingresso));
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

            return this.oDao.Select(lstParametros, "plutonium", "VI_TIPO_REINGRESSO_TIRE", dicionario);

        }

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(TipoReingresso));
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
            return this.oDao.Select(lstParametros, "plutonium", "VI_TIPO_REINGRESSO_TIRE", dicionario);
        }

        public void PrepararInclusao()
        {
            oTipoReingresso = new TipoReingresso(oDao);
        }

        public Dictionary<string, object> Selecionar(int id)
        {
            oTipoReingresso = new TipoReingresso(id, oDao);
            return ClassFunctions.GetProperties(oTipoReingresso);
        }

        public CrudActionTypes Salvar(Dictionary<string, object> valores)
        {
            ClassFunctions.SetProperties(oTipoReingresso, valores);
            return oTipoReingresso.Salvar();
        }

        public CrudActionTypes Excluir()
        {
            return oTipoReingresso.Excluir();
        }
        #endregion

    }
}
