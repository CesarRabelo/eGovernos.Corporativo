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
    public class ManterSituacao:IManter
    {
        
        #region Variáveis e Propriedades

        private Situacao oSituacao;
        private Dao oDao;

        #endregion

        #region Construtores

        public ManterSituacao()
		{
            oDao = new Dao();
		}

        public ManterSituacao(string connectionString, DataBaseTypes dataBaseType)
        {
            oDao = new Dao(connectionString, dataBaseType);
        }

	    #endregion 
    
        #region Métodos

        public void PrepararInclusao()
        {
            oSituacao = new Situacao(oDao);
        }

        public Dictionary<string, object> Selecionar(int id)
        {
            oSituacao = new Situacao(id, oDao);
            return ClassFunctions.GetProperties(oSituacao);
        }

        public CrudActionTypes Salvar(Dictionary<string, object> valores)
        {
            ClassFunctions.SetProperties(oSituacao, valores);
            return oSituacao.Salvar();
        }

        public CrudActionTypes Excluir()
        {
            return oSituacao.Excluir();
        }

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao, string colunaSort)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(Situacao));
            dicionario.Add("dsc_ativo", "DscAtivo");

            List<Parameter> lstParametros = new List<Parameter>();
            foreach (KeyValuePair<string, object> item in filtros)
            {
                lstParametros.Add(new Parameter(item.Key, item.Value, OperationTypes.Like));
            }
            lstParametros.Add(new Parameter(colunaSort, null, OperationTypes.Null, direcao));

            return this.oDao.Select(lstParametros, "platinium", "VI_SITUACAO_SITU", dicionario);

        }

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(Situacao));
            dicionario.Add("dsc_ativo", "DscAtivo");

            List<Parameter> lstParametros = new List<Parameter>();
            foreach (KeyValuePair<string, object> item in filtros)
            {
                lstParametros.Add(new Parameter(item.Key, item.Value, OperationTypes.Like, direcao));
            }
            return this.oDao.Select(lstParametros, "platinium", "VI_SITUACAO_SITU", dicionario);
        }

        #endregion
    }
}
