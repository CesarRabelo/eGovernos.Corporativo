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
    public class ManterTipoAdministracao:IManter
    {
        
        #region Variáveis e Propriedades

        private TipoAdministracao oTipoAdministracao;
        private Dao oDao;

        #endregion

        #region Construtores

        public ManterTipoAdministracao()
		{
            oDao = new Dao();
		}

        public ManterTipoAdministracao(string connectionString, DataBaseTypes dataBaseType)
        {
            oDao = new Dao(connectionString, dataBaseType);
        }

	    #endregion 
    
        #region Métodos

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao, string colunaSort)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(TipoAdministracao));
            dicionario.Add("DSC_ATIVO", "DscAtivo");

            List<Parameter> lstParametros = new List<Parameter>();
            foreach (KeyValuePair<string, object> item in filtros)
            {
                lstParametros.Add(new Parameter(item.Key, item.Value, OperationTypes.Like));
            }
            lstParametros.Add(new Parameter(colunaSort, null, OperationTypes.Null, direcao));

            return this.oDao.Select(lstParametros, "platinium", "VI_TIPO_ADMINISTRACAO_TIAD", dicionario);

        }

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(TipoAdministracao));
            dicionario.Add("DSC_ATIVO", "DscAtivo");

            List<Parameter> lstParametros = new List<Parameter>();
            foreach (KeyValuePair<string, object> item in filtros)
            {
                lstParametros.Add(new Parameter(item.Key, item.Value, OperationTypes.Like, direcao));
            }
            return this.oDao.Select(lstParametros, "platinium", "VI_TIPO_ADMINISTRACAO_TIAD", dicionario);
        }

        public void PrepararInclusao()
        {
            oTipoAdministracao = new TipoAdministracao(oDao);
        }

        public Dictionary<string, object> Selecionar(int id)
        {
            oTipoAdministracao = new TipoAdministracao(id, oDao);
            return ClassFunctions.GetProperties(oTipoAdministracao);
        }

        public CrudActionTypes Salvar(Dictionary<string, object> valores)
        {
            ClassFunctions.SetProperties(oTipoAdministracao, valores);
            return oTipoAdministracao.Salvar();
        }

        public CrudActionTypes Excluir()
        {
            return oTipoAdministracao.Excluir();
        }

        

        #endregion
    }
}
