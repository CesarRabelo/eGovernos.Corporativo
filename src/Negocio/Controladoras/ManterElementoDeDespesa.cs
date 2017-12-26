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
    public class ManterElementoDeDespesa:IManter
    {
        
        #region Variáveis e Propriedades

        private ElementoDeDespesa oElementoDeDespesa;
        private Dao oDao;

        #endregion

        #region Construtores

        public ManterElementoDeDespesa()
		{
            oDao = new Dao();
		}

        public ManterElementoDeDespesa(string connectionString, DataBaseTypes dataBaseType)
        {
            oDao = new Dao(connectionString, dataBaseType);
        }

	    #endregion 
    
        #region Métodos

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao, string colunaSort)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(ElementoDeDespesa));
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

            return this.oDao.Select(lstParametros, "platinium", "VI_ELEMENTO_DESPESA_ELDE", dicionario);

        }

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(ElementoDeDespesa));
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
            return this.oDao.Select(lstParametros, "platinium", "VI_ELEMENTO_DESPESA_ELDE", dicionario);
        }

        public void PrepararInclusao()
        {
            oElementoDeDespesa = new ElementoDeDespesa(oDao);
        }

        public Dictionary<string, object> Selecionar(int id)
        {
            oElementoDeDespesa = new ElementoDeDespesa(id, oDao);
            return ClassFunctions.GetProperties(oElementoDeDespesa);
        }

        public CrudActionTypes Salvar(Dictionary<string, object> valores)
        {
            ClassFunctions.SetProperties(oElementoDeDespesa, valores);
            return oElementoDeDespesa.Salvar();
        }

        public CrudActionTypes Excluir()
        {
            return oElementoDeDespesa.Excluir();
        }
        #endregion
    }
}
