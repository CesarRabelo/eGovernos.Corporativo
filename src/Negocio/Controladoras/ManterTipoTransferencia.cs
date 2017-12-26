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
    public class ManterTipoTransferencia : IManter
    {

        #region Variáveis e Propriedades

        private TipoTransferencia oTipoTransferencia;
        private Dao oDao;

        #endregion

        #region Construtores

        public ManterTipoTransferencia()
        {
            oDao = new Dao();
        }

        public ManterTipoTransferencia(string connectionString, DataBaseTypes dataBaseType)
        {
            oDao = new Dao(connectionString, dataBaseType);
        }

        #endregion

        #region Métodos

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao, string colunaSort)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(TipoTransferencia));
            
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

            return this.oDao.Select(lstParametros, "platinium", "TB_TIPO_TRANSFERENCIA_TITR", dicionario);

        }

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(TipoTransferencia));
            
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
            return this.oDao.Select(lstParametros, "platinium", "TB_TIPO_TRANSFERENCIA_TITR", dicionario);
        }

        public void PrepararInclusao()
        {
            oTipoTransferencia = new TipoTransferencia(oDao);
        }

        public Dictionary<string, object> Selecionar(int id)
        {
            oTipoTransferencia = new TipoTransferencia(id, oDao);
            return ClassFunctions.GetProperties(oTipoTransferencia);
        }

        public CrudActionTypes Salvar(Dictionary<string, object> valores)
        {
            ClassFunctions.SetProperties(oTipoTransferencia, valores);
            return oTipoTransferencia.Salvar();
        }

        public CrudActionTypes Excluir()
        {
            return oTipoTransferencia.Excluir();
        }
        #endregion
    }
}
