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
    public class ManterModalidadePagamento : IManter
    {

        #region Variáveis e Propriedades

        private ModalidadePagamento oModalidadePagamento;
        private Dao oDao;

        #endregion

        #region Construtores

        public ManterModalidadePagamento()
        {
            oDao = new Dao();
        }

        public ManterModalidadePagamento(string connectionString, DataBaseTypes dataBaseType)
        {
            oDao = new Dao(connectionString, dataBaseType);
        }

        #endregion

        #region Métodos

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao, string colunaSort)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(ModalidadePagamento));
            dicionario.Add("DSC_ATIVO", "DscAtivo");
            dicionario.Add("DAT_DESATIVADO", "DatDesativacao");
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

            return this.oDao.Select(lstParametros, "platinium", "VI_MODALIDADE_PAGAMENTO_MOPA", dicionario);

        }

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(ModalidadePagamento));
            dicionario.Add("DSC_ATIVO", "DscAtivo");
            dicionario.Add("DAT_DESATIVADO", "DatDesativacao");
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
            return this.oDao.Select(lstParametros, "platinium", "VI_MODALIDADE_PAGAMENTO_MOPA", dicionario);
        }

        public void PrepararInclusao()
        {
            oModalidadePagamento = new ModalidadePagamento(oDao);
        }

        public Dictionary<string, object> Selecionar(int id)
        {
            oModalidadePagamento = new ModalidadePagamento(id, oDao);
            return ClassFunctions.GetProperties(oModalidadePagamento);
        }

        public CrudActionTypes Salvar(Dictionary<string, object> valores)
        {
            ClassFunctions.SetProperties(oModalidadePagamento, valores);
            return oModalidadePagamento.Salvar();
        }

        public CrudActionTypes Excluir()
        {
            return oModalidadePagamento.Excluir();
        }
        #endregion
    }
}
