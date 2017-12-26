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
    public class ManterSituacaoFuncional : IManter
    {

        #region Variáveis e Propriedades

        private SituacaoFuncional oSituacaoFuncional;
        private Dao oDao;

        #endregion

        #region Construtores

        public ManterSituacaoFuncional()
        {
            oDao = new Dao();
        }

        public ManterSituacaoFuncional(string connectionString, DataBaseTypes dataBaseType)
        {
            oDao = new Dao(connectionString, dataBaseType);
        }

        #endregion

        #region Métodos

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao, string colunaSort)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(SituacaoFuncional));
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

            return this.oDao.Select(lstParametros, "platinium", "VI_SITUACAO_FUNCIONAL_SIFU", dicionario);

        }

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(SituacaoFuncional));
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
            return this.oDao.Select(lstParametros, "platinium", "VI_SITUACAO_FUNCIONAL_SIFU", dicionario);
        }

        public void PrepararInclusao()
        {
            oSituacaoFuncional = new SituacaoFuncional(oDao);
        }

        public Dictionary<string, object> Selecionar(int id)
        {
            oSituacaoFuncional = new SituacaoFuncional(id, oDao);
            return ClassFunctions.GetProperties(oSituacaoFuncional);
        }

        public CrudActionTypes Salvar(Dictionary<string, object> valores)
        {
            ClassFunctions.SetProperties(oSituacaoFuncional, valores);
            return oSituacaoFuncional.Salvar();
        }

        public CrudActionTypes Excluir()
        {
            return oSituacaoFuncional.Excluir();
        }
        #endregion
    }
}
