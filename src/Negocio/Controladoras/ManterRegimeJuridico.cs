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
    public class ManterRegimeJuridico : IManter
    {

        #region Variáveis e Propriedades

        private RegimeJuridico oRegimeJuridico;
        private Dao oDao;

        #endregion

        #region Construtores

        public ManterRegimeJuridico()
        {
            oDao = new Dao();
        }

        public ManterRegimeJuridico(string connectionString, DataBaseTypes dataBaseType)
        {
            oDao = new Dao(connectionString, dataBaseType);
        }

        #endregion

        #region Métodos

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao, string colunaSort)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(RegimeJuridico));
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

            return this.oDao.Select(lstParametros, "platinium", "VI_REGIME_JURIDICO_REJU", dicionario);

        }

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(RegimeJuridico));
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
            return this.oDao.Select(lstParametros, "platinium", "VI_REGIME_JURIDICO_REJU", dicionario);
        }

        public void PrepararInclusao()
        {
            oRegimeJuridico = new RegimeJuridico(oDao);
        }

        public Dictionary<string, object> Selecionar(int id)
        {
            oRegimeJuridico = new RegimeJuridico(id, oDao);
            return ClassFunctions.GetProperties(oRegimeJuridico);
        }

        public CrudActionTypes Salvar(Dictionary<string, object> valores)
        {
            ClassFunctions.SetProperties(oRegimeJuridico, valores);
            return oRegimeJuridico.Salvar();
        }

        public CrudActionTypes Excluir()
        {
            return oRegimeJuridico.Excluir();
        }
        #endregion
    }
}
