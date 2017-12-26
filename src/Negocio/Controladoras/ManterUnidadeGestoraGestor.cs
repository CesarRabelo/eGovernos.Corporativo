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
    public class ManterUnidadeGestoraGestor : IManter
    {

        #region Variáveis e Propriedades

        private UnidadeGestoraGestor oUnidadeGestoraGestor;
        private Dao oDao;

        #endregion

        #region Construtores

        public ManterUnidadeGestoraGestor()
        {
            oDao = new Dao();
        }

        public ManterUnidadeGestoraGestor(string connectionString, DataBaseTypes dataBaseType)
        {
            oDao = new Dao(connectionString, dataBaseType);
        }

        #endregion

        #region Métodos

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao, string colunaSort)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(UnidadeGestoraGestor));
            dicionario.Add("DSC_NOME", "DscNome");
            dicionario.Add("NUM_CPF", "DscCpf");
            dicionario.Add("COD_UNIDADE_GESTORA", "DscCodigo");
            dicionario.Add("DSC_UNIDADE_GESTORA", "DscGestora");
            dicionario.Add("DSC_SIGLA", "DscOrgao");
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

            return this.oDao.Select(lstParametros, "platinium", "VI_UNIDADE_GESTORA_GESTOR_UNGG", dicionario);

        }

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(UnidadeGestoraGestor));
            dicionario.Add("DSC_NOME", "DscNome");
            dicionario.Add("NUM_CPF", "DscCpf");
            dicionario.Add("COD_UNIDADE_GESTORA", "DscCodigo");
            dicionario.Add("DSC_UNIDADE_GESTORA", "DscGestora");
            dicionario.Add("DSC_SIGLA", "DscOrgao");
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
            return this.oDao.Select(lstParametros, "platinium", "VI_UNIDADE_GESTORA_GESTOR_UNGG", dicionario);
        }

        public void PrepararInclusao()
        {
            oUnidadeGestoraGestor = new UnidadeGestoraGestor(oDao);
        }

        public Dictionary<string, object> Selecionar(int id)
        {
            oUnidadeGestoraGestor = new UnidadeGestoraGestor(id, oDao);
            return ClassFunctions.GetProperties(oUnidadeGestoraGestor);
        }

        public CrudActionTypes Salvar(Dictionary<string, object> valores)
        {
            ClassFunctions.SetProperties(oUnidadeGestoraGestor, valores);
            return oUnidadeGestoraGestor.Salvar();
        }

        public CrudActionTypes Excluir()
        {
            return oUnidadeGestoraGestor.Excluir();
        }
        #endregion
    }
}
