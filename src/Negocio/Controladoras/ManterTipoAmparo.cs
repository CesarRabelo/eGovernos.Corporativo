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
    public class ManterTipoAmparo : IManter
    {

        #region Variáveis e Propriedades

        private TipoAmparo oTipoAmparo;
        private Dao oDao;

        #endregion

        #region Construtores

        public ManterTipoAmparo()
        {
            oDao = new Dao();
        }

        public ManterTipoAmparo(string connectionString, DataBaseTypes dataBaseType)
        {
            oDao = new Dao(connectionString, dataBaseType);
        }

        #endregion

        #region Métodos

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao, string colunaSort)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(TipoAmparo));
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

            return this.oDao.Select(lstParametros, "platinium", "VI_TIPO_AMPARO_LEGAL_TIAL", dicionario);

        }

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(TipoAmparo));
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
            return this.oDao.Select(lstParametros, "platinium", "VI_TIPO_AMPARO_LEGAL_TIAL", dicionario);
        }

        public void PrepararInclusao()
        {
            oTipoAmparo = new TipoAmparo(oDao);
        }

        public Dictionary<string, object> Selecionar(int id)
        {
            oTipoAmparo = new TipoAmparo(id, oDao);
            return ClassFunctions.GetProperties(oTipoAmparo);
        }

        public CrudActionTypes Salvar(Dictionary<string, object> valores)
        {
            ClassFunctions.SetProperties(oTipoAmparo, valores);
            return oTipoAmparo.Salvar();
        }

        public CrudActionTypes Excluir()
        {
            return oTipoAmparo.Excluir();
        }
        #endregion
    }
}
