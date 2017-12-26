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
    public class ManterAreaAtuacao:IManter
    {
        
        #region Variáveis e Propriedades

        private AreaAtuacao oAreaAtuacao;
        private Dao oDao;

        #endregion

        #region Construtores

        public ManterAreaAtuacao()
		{
            oDao = new Dao();
		}

        public ManterAreaAtuacao(string connectionString, DataBaseTypes dataBaseType)
        {
            oDao = new Dao(connectionString, dataBaseType);
        }

	    #endregion 
    
        #region Métodos

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao, string colunaSort)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(AreaAtuacao));
            dicionario.Add("DSC_EIXO", "DscEixo");
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

            return this.oDao.Select(lstParametros, "platinium", "VI_AREA_ATUACAO_ARAT", dicionario);

        }

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(AreaAtuacao));
            dicionario.Add("DSC_EIXO", "DscEixo");
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
            return this.oDao.Select(lstParametros, "platinium", "VI_AREA_ATUACAO_ARAT", dicionario);
        }

        public void PrepararInclusao()
        {
            oAreaAtuacao = new AreaAtuacao(oDao);
        }

        public Dictionary<string, object> Selecionar(int id)
        {
            oAreaAtuacao = new AreaAtuacao(id, oDao);
            return ClassFunctions.GetProperties(oAreaAtuacao);
        }

        public CrudActionTypes Salvar(Dictionary<string, object> valores)
        {
            ClassFunctions.SetProperties(oAreaAtuacao, valores);
            return oAreaAtuacao.Salvar();
        }

        public CrudActionTypes Excluir()
        {
            return oAreaAtuacao.Excluir();
        }
        #endregion
    }
}
