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
    public class ManterRegiao:IManter
    {
        
        #region Variáveis e Propriedades

        private Regiao oRegiao;
        private Dao oDao;

        #endregion

        #region Construtores

        public ManterRegiao()
		{
            oDao = new Dao();
		}

        public ManterRegiao(string connectionString, DataBaseTypes dataBaseType)
        {
            oDao = new Dao(connectionString, dataBaseType);
        }

	    #endregion 
    
        #region Métodos

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao, string colunaSort)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(Regiao));
            dicionario.Add("dsc_ativo", "dscAtivo");

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

            return this.oDao.Select(lstParametros, "platinium", "vi_regiao_regi", dicionario);

        }

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(Regiao));
            dicionario.Add("dsc_ativo", "dscAtivo");

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
            return this.oDao.Select(lstParametros, "platinium", "vi_regiao_regi", dicionario);
        }

        public void PrepararInclusao()
        {
            oRegiao = new Regiao(oDao);
        }

        public Dictionary<string, object> Selecionar(int id)
        {
            oRegiao = new Regiao(id, oDao);
            return ClassFunctions.GetProperties(oRegiao);
        }

        public CrudActionTypes Salvar(Dictionary<string, object> valores)
        {
            ClassFunctions.SetProperties(oRegiao, valores);
            return oRegiao.Salvar();
        }

        public int SalvarRetornandoId(Dictionary<string, object> valores)
        {
            ClassFunctions.SetProperties(oRegiao, valores);
            oRegiao.Salvar();
            return oRegiao.ID;
        }

        public CrudActionTypes Excluir()
        {
            return oRegiao.Excluir();
        }
        #endregion
    }
}
