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
    public class ManterTipoEntidade:IManter
    {
        
        #region Variáveis e Propriedades

        private TipoEntidade oTipoEntidade;
        private Dao oDao;

        #endregion

        #region Construtores

        public ManterTipoEntidade()
		{
            oDao = new Dao();
		}

        public ManterTipoEntidade(string connectionString, DataBaseTypes dataBaseType)
        {
            oDao = new Dao(connectionString, dataBaseType);
        }

	    #endregion 
    
        #region Métodos

        public void PrepararInclusao()
        {
            oTipoEntidade = new TipoEntidade(oDao);
        }

        public Dictionary<string, object> Selecionar(int id)
        {
            oTipoEntidade = new TipoEntidade(id, oDao);
            return ClassFunctions.GetProperties(oTipoEntidade);
        }

        public CrudActionTypes Salvar(Dictionary<string, object> valores)
        {
            ClassFunctions.SetProperties(oTipoEntidade, valores);
            return oTipoEntidade.Salvar();
        }

        public CrudActionTypes Excluir()
        {
            return oTipoEntidade.Excluir();
        }

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao, string colunaSort)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(TipoEntidade));
            dicionario.Add("DSC_ATIVO", "DscAtivo");

            List<Parameter> lstParametros = new List<Parameter>();
            foreach (KeyValuePair<string, object> item in filtros)
            {
                lstParametros.Add(new Parameter(item.Key, item.Value, OperationTypes.Like));
            }
            lstParametros.Add(new Parameter(colunaSort, null, OperationTypes.Null, direcao));

            return this.oDao.Select(lstParametros, "platinium", "VI_TIPO_ENTIDADE_TIEN", dicionario);

        }

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(TipoEntidade));
            dicionario.Add("DSC_ATIVO", "DscAtivo");

            List<Parameter> lstParametros = new List<Parameter>();
            foreach (KeyValuePair<string, object> item in filtros)
            {
                lstParametros.Add(new Parameter(item.Key, item.Value, OperationTypes.Like, direcao));
            }
            return this.oDao.Select(lstParametros, "platinium", "VI_TIPO_ENTIDADE_TIEN", dicionario);
        }

        #endregion
    }
}
