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
    public class ManterFuncao:IManter
    {
        
        #region Variáveis e Propriedades

        private Funcao oFuncao;
        private Dao oDao;

        #endregion

        #region Construtores

        public ManterFuncao()
		{
            oDao = new Dao();
		}

        public ManterFuncao(string connectionString, DataBaseTypes dataBaseType)
        {
            oDao = new Dao(connectionString, dataBaseType);
        }

	    #endregion 
    
        #region Métodos

        public void PrepararInclusao()
        {
            oFuncao = new Funcao(oDao);
        }

        public Dictionary<string, object> Selecionar(int id)
        {
            oFuncao = new Funcao(id, oDao);
            return ClassFunctions.GetProperties(oFuncao);
        }

        public CrudActionTypes Salvar(Dictionary<string, object> valores)
        {
            ClassFunctions.SetProperties(oFuncao, valores);
            return oFuncao.Salvar();
        }

        public CrudActionTypes Excluir()
        {
            return oFuncao.Excluir();
        }

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao, string colunaSort)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(Funcao));
            dicionario.Add("DSC_ATIVO", "DscAtivo");

            List<Parameter> lstParametros = new List<Parameter>();
            foreach (KeyValuePair<string, object> item in filtros)
            {
                lstParametros.Add(new Parameter(item.Key, item.Value, OperationTypes.Like));
            }
            lstParametros.Add(new Parameter(colunaSort, null, OperationTypes.Null, direcao));

            return this.oDao.Select(lstParametros, "platinium", "VI_FUNCAO_FUNC", dicionario);

        }

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(Funcao));
            dicionario.Add("DSC_ATIVO", "DscAtivo");

            List<Parameter> lstParametros = new List<Parameter>();
            foreach (KeyValuePair<string, object> item in filtros)
            {
                lstParametros.Add(new Parameter(item.Key, item.Value, OperationTypes.Like, direcao));
            }
            return this.oDao.Select(lstParametros, "platinium", "VI_FUNCAO_FUNC", dicionario);
        }

        #endregion
    }
}
