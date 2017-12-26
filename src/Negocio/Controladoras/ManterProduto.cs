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
    public class ManterProduto:IManter
    {
        
        #region Variáveis e Propriedades

        private Produto oProduto;
        private Dao oDao;

        #endregion

        #region Construtores

        public ManterProduto()
		{
            oDao = new Dao();
		}

        public ManterProduto(string connectionString, DataBaseTypes dataBaseType)
        {
            oDao = new Dao(connectionString, dataBaseType);
        }

	    #endregion 
    
        #region Métodos

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao, string colunaSort)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(Produto));
            dicionario.Add("DSC_UNIDADE", "DscUnidade");
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

            return this.oDao.Select(lstParametros, "platinium", "VI_PRODUTO_PROD", dicionario);

        }

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(Produto));
            dicionario.Add("DSC_UNIDADE", "DscUnidade");
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
            return this.oDao.Select(lstParametros, "platinium", "VI_PRODUTO_PROD", dicionario);
        }

        public void PrepararInclusao()
        {
            oProduto = new Produto(oDao);
        }

        public Dictionary<string, object> Selecionar(int id)
        {
            oProduto = new Produto(id, oDao);
            return ClassFunctions.GetProperties(oProduto);
        }

        public CrudActionTypes Salvar(Dictionary<string, object> valores)
        {
            ClassFunctions.SetProperties(oProduto, valores);
            return oProduto.Salvar();
        }

        public CrudActionTypes Excluir()
        {
            return oProduto.Excluir();
        }
        #endregion
    }
}
