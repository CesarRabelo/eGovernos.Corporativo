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
    public class ManterFolhaPagamento:IManter
    {
        
        #region Variáveis e Propriedades

        private FolhaPagamento oFolhaPagamento;
        private Dao oDao;

        #endregion

        #region Construtores

        public ManterFolhaPagamento()
		{
            oDao = new Dao();
		}

        public ManterFolhaPagamento(string connectionString, DataBaseTypes dataBaseType)
        {
            oDao = new Dao(connectionString, dataBaseType);
        }

	    #endregion 
    
        #region Métodos

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao, string colunaSort)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(FolhaPagamento));
            dicionario.Add("DSC_UNIDADE_ORCAMENTARIA", "DscUnidadeOrcamentaria");
            dicionario.Add("DSC_ORGAO", "DscOrgao");
            dicionario.Add("DSC_TIPO_FOLHA_PAGAMENTO", "DscTipoFolha");

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

            return this.oDao.Select(lstParametros, "plutonium", "VI_FOLHA_PAGAMENTO_FOPA", dicionario);

        }

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(FolhaPagamento));
            dicionario.Add("DSC_UNIDADE_ORCAMENTARIA", "DscUnidadeOrcamentaria");
            dicionario.Add("DSC_ORGAO", "DscOrgao");
            dicionario.Add("DSC_TIPO_FOLHA_PAGAMENTO", "DscTipoFolha");

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
            return this.oDao.Select(lstParametros, "plutonium", "VI_FOLHA_PAGAMENTO_FOPA", dicionario);
        }

        public void PrepararInclusao()
        {
            oFolhaPagamento = new FolhaPagamento(oDao);
        }

        public Dictionary<string, object> Selecionar(int id)
        {
            oFolhaPagamento = new FolhaPagamento(id, oDao);
            return ClassFunctions.GetProperties(oFolhaPagamento);
        }

        public CrudActionTypes Salvar(Dictionary<string, object> valores)
        {
            ClassFunctions.SetProperties(oFolhaPagamento, valores);
            return oFolhaPagamento.Salvar();
        }

        public CrudActionTypes Excluir()
        {
            return oFolhaPagamento.Excluir();
        }
        #endregion
    }
}
