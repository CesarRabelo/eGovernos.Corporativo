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
    public class ManterUnidadeGestoraOrcamentaria : IManter
    {

        #region Variáveis e Propriedades

        private UnidadeGestoraOrcamentaria oUnidadeGestoraOrcamentaria;
        private Dao oDao;

        #endregion

        #region Construtores

        public ManterUnidadeGestoraOrcamentaria()
        {
            oDao = new Dao();
        }

        public ManterUnidadeGestoraOrcamentaria(string connectionString, DataBaseTypes dataBaseType)
        {
            oDao = new Dao(connectionString, dataBaseType);
        }

        #endregion

        #region Métodos

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao, string colunaSort)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(UnidadeGestoraOrcamentaria));
            dicionario.Add("dsc_entidade", "DscUnidadeOrcamentaria");

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
            
            return this.oDao.Select(lstParametros, "platinium", "VI_UNIDADE_GESTORA_ORCAMENTARIA_UNGO", dicionario);

        }

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(UnidadeGestoraOrcamentaria));
            dicionario.Add("dsc_entidade", "DscUnidadeOrcamentaria");

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
            return this.oDao.Select(lstParametros, "platinium", "VI_UNIDADE_GESTORA_ORCAMENTARIA_UNGO", dicionario);
        }

        public void PrepararInclusao()
        {
            oUnidadeGestoraOrcamentaria = new UnidadeGestoraOrcamentaria(oDao);
        }

        public Dictionary<string, object> Selecionar(int id)
        {
            oUnidadeGestoraOrcamentaria = new UnidadeGestoraOrcamentaria(id, oDao);
            return ClassFunctions.GetProperties(oUnidadeGestoraOrcamentaria);
        }

        public CrudActionTypes Salvar(Dictionary<string, object> valores)
        {
            ClassFunctions.SetProperties(oUnidadeGestoraOrcamentaria, valores);
            return oUnidadeGestoraOrcamentaria.Salvar();
        }

        public CrudActionTypes Excluir()
        {
            return oUnidadeGestoraOrcamentaria.Excluir();
        }
        public int getIdOrgao(int IdUnidadeGestora)
        {
            UnidadeGestora oUnidadeGestora = new UnidadeGestora(IdUnidadeGestora,oDao);
            return oUnidadeGestora.Entidade.ID;
        }
        #endregion

       
    }
}
