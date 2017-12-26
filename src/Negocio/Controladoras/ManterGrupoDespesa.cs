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
    public class ManterGrupoDespesa:IManter
    {

    #region Variáveis e Propriedades

        private GrupoDespesa oGrupoDespesa;
        private Dao oDao;

    #endregion

	#region Construtores

        public ManterGrupoDespesa()
		{
            oDao = new Dao();
		}

	#endregion

    #region Métodos
        public DataTable Consultar(Dictionary<string, object> filtros, string direcao, string colunaSort)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(GrupoDespesa));
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

            return this.oDao.Select(lstParametros, "platinium", "VI_GRUPO_DESPESA_GRDE", dicionario);

        }
        public DataTable Consultar(Dictionary<string, object> filtros, string direcao)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(GrupoDespesa));
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
            return this.oDao.Select(lstParametros, "platinium", "VI_GRUPO_DESPESA_GRDE", dicionario);
        }

        public Dictionary<string, object> Selecionar(int id)
        {
            oGrupoDespesa = new GrupoDespesa(id, oDao);
            return ClassFunctions.GetProperties(oGrupoDespesa);
        }

        public void PrepararInclusao()
        {
            oGrupoDespesa = new GrupoDespesa(oDao);
        }

        public CrudActionTypes Salvar(Dictionary<string, object> valores)
        {
            ClassFunctions.SetProperties(oGrupoDespesa, valores);
            return oGrupoDespesa.Salvar();
        }

        public CrudActionTypes Excluir()
        {
            return oGrupoDespesa.Excluir();
        }

    #endregion

    }
}
