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
    public class ManterAmortizacao : IManter
    {

        #region Variáveis e Propriedades

        private Amortizacao oAmortizacao;
        private Dao oDao;

        #endregion

        #region Construtores

        public ManterAmortizacao()
        {
            oDao = new Dao();
        }

        public ManterAmortizacao(string connectionString, DataBaseTypes dataBaseType)
        {
            oDao = new Dao(connectionString, dataBaseType);
        }

        #endregion

        #region Métodos

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao, string colunaSort)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(Amortizacao));
            
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

            return this.oDao.Select(lstParametros, "platinium", "TB_AMORTIZACAO_AMOR", dicionario);

        }

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(Amortizacao));
            
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
            return this.oDao.Select(lstParametros, "platinium", "TB_AMORTIZACAO_AMOR", dicionario);
        }

        public void PrepararInclusao()
        {
            oAmortizacao = new Amortizacao(oDao);
        }

        public Dictionary<string, object> Selecionar(int id)
        {
            oAmortizacao = new Amortizacao(id, oDao);
            return ClassFunctions.GetProperties(oAmortizacao);
        }

        public CrudActionTypes Salvar(Dictionary<string, object> valores)
        {
            ClassFunctions.SetProperties(oAmortizacao, valores);
            return oAmortizacao.Salvar();
        }

        public CrudActionTypes Excluir()
        {
            return oAmortizacao.Excluir();
        }
        #endregion
    }
}
