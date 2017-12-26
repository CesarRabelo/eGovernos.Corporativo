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
    public class ManterModalidadeAplicacao:IManter
    {

    #region Variáveis e Propriedades

        private ModalidadeAplicacao oModalidadeAplicacao;
        private Dao oDao;

    #endregion

	#region Construtores

        public ManterModalidadeAplicacao()
		{
            oDao = new Dao();
		}

	#endregion

    #region Métodos
        public DataTable Consultar(Dictionary<string, object> filtros, string direcao, string colunaSort)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(ModalidadeAplicacao));
            dicionario.Add("dsc_ativo", "DscAtivo");

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

            return this.oDao.Select(lstParametros, "platinium", "VI_MODALIDADE_APLICACAO_MOAP", dicionario);

        }
        public DataTable Consultar(Dictionary<string, object> filtros, string direcao)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(ModalidadeAplicacao));
            dicionario.Add("dsc_ativo", "DscAtivo");

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
            return this.oDao.Select(lstParametros, "platinium", "VI_MODALIDADE_APLICACAO_MOAP", dicionario);
        }

        public Dictionary<string, object> Selecionar(int id)
        {
            oModalidadeAplicacao = new ModalidadeAplicacao(id, oDao);
            return ClassFunctions.GetProperties(oModalidadeAplicacao);
        }

        public void PrepararInclusao()
        {
            oModalidadeAplicacao = new ModalidadeAplicacao(oDao);
        }

        public CrudActionTypes Salvar(Dictionary<string, object> valores)
        {
            ClassFunctions.SetProperties(oModalidadeAplicacao, valores);
            return oModalidadeAplicacao.Salvar();
        }

        public CrudActionTypes Excluir()
        {
            return oModalidadeAplicacao.Excluir();
        }

    #endregion

    }
}
