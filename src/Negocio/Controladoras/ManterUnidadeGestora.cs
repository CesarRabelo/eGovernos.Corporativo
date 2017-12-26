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
    public class ManterUnidadeGestora:IManter
    {

    #region Variáveis e Propriedades

        private UnidadeGestora oUnidadeGestora;
        private Dao oDao;

    #endregion

	#region Construtores

        public ManterUnidadeGestora()
		{
            oDao = new Dao();
		}

	#endregion

    #region Métodos
        public DataTable Consultar(Dictionary<string, object> filtros, string direcao, string colunaSort)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(UnidadeGestora));
            dicionario.Add("DSC_SIGLA", "DscSigla");
            dicionario.Add("DSC_Ativo", "DscAtivo");

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

            return this.oDao.Select(lstParametros, "platinium", "VI_UNIDADE_GESTORA_UNGE", dicionario);

        }
        public DataTable Consultar(Dictionary<string, object> filtros, string direcao)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(UnidadeGestora));
            dicionario.Add("DSC_SIGLA", "DscSigla");
            dicionario.Add("DSC_Ativo", "DscAtivo");

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
            return this.oDao.Select(lstParametros, "platinium", "VI_UNIDADE_GESTORA_UNGE", dicionario);
        }

        public Dictionary<string, object> Selecionar(int id)
        {
            oUnidadeGestora = new UnidadeGestora(id, oDao);
            return ClassFunctions.GetProperties(oUnidadeGestora);
        }

        public void PrepararInclusao()
        {
            oUnidadeGestora = new UnidadeGestora(oDao);
        }

        public CrudActionTypes Salvar(Dictionary<string, object> valores)
        {
            ClassFunctions.SetProperties(oUnidadeGestora, valores);
            return oUnidadeGestora.Salvar();
        }

        public int SalvarRetornandoId(Dictionary<string, object> valores)
        {
            ClassFunctions.SetProperties(oUnidadeGestora, valores);
            oUnidadeGestora.Salvar();
            return oUnidadeGestora.ID;
        }

        public CrudActionTypes Excluir()
        {
            return oUnidadeGestora.Excluir();
        }

    #endregion

    }
}
