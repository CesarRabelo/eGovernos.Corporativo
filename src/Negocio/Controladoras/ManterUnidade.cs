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
    public class ManterUnidade:IManter
    {
        
        #region Variáveis e Propriedades

        private Unidade oUnidade;
        private Dao oDao;

        #endregion

        #region Construtores

        public ManterUnidade()
		{
            oDao = new Dao();
		}

        public ManterUnidade(string connectionString, DataBaseTypes dataBaseType)
        {
            oDao = new Dao(connectionString, dataBaseType);
        }

	    #endregion 
    
        #region Métodos

        public void PrepararInclusao()
        {
            oUnidade = new Unidade(oDao);
        }

        public Dictionary<string, object> Selecionar(int id)
        {
            oUnidade = new Unidade(id, oDao);
            return ClassFunctions.GetProperties(oUnidade);
        }

        public CrudActionTypes Salvar(Dictionary<string, object> valores)
        {
            ClassFunctions.SetProperties(oUnidade, valores);
            return oUnidade.Salvar();
        }

        public CrudActionTypes Excluir()
        {
            return oUnidade.Excluir();
        }

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao, string colunaSort)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(Unidade));
           dicionario.Add("DSC_ATIVO" , "dscAtivo");

            List<Parameter> lstParametros = new List<Parameter>();
            foreach (KeyValuePair<string, object> item in filtros)
            {
                lstParametros.Add(new Parameter(item.Key, item.Value, OperationTypes.Like));
            }
            lstParametros.Add(new Parameter(colunaSort, null, OperationTypes.Null, direcao));

            return this.oDao.Select(lstParametros, "platinium", "VI_UNIDADE_UNID", dicionario);

        }

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(Unidade));
            dicionario.Add("DSC_ATIVO", "dscAtivo");

            List<Parameter> lstParametros = new List<Parameter>();
            foreach (KeyValuePair<string, object> item in filtros)
            {
                lstParametros.Add(new Parameter(item.Key, item.Value, OperationTypes.Like, direcao));
            }
            return this.oDao.Select(lstParametros, "platinium", "VI_UNIDADE_UNID", dicionario);
        }

        #endregion
    }
}
