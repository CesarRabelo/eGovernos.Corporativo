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
    public class ManterEntidadeLei:IManter
    {

    #region Variáveis e Propriedades

        private EntidadeLei oEntidadeLei;
        private Dao oDao;

    #endregion

	#region Construtores

        public ManterEntidadeLei()
		{
            oDao = new Dao();
		}

	#endregion

    #region Métodos
        public DataTable Consultar(Dictionary<string, object> filtros, string direcao, string colunaSort)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(EntidadeLei));

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

            return this.oDao.Select(lstParametros, "platinium", "TB_ENTIDADE_LEI_ENLE", dicionario);
        }

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(EntidadeLei));

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
            return this.oDao.Select(lstParametros, "platinium", "TB_ENTIDADE_LEI_ENLE", dicionario);
        }

        public Dictionary<string, object> Selecionar(int id)
        {
            oEntidadeLei = new EntidadeLei(id, oDao);
            return ClassFunctions.GetProperties(oEntidadeLei);
        }

        public void PrepararInclusao()
        {
            oEntidadeLei = new EntidadeLei(oDao);
        }

        public CrudActionTypes Salvar(Dictionary<string, object> valores)
        {
            ClassFunctions.SetProperties(oEntidadeLei, valores);
            return oEntidadeLei.Salvar();
        }

        public int SalvarRetornandoId(Dictionary<string, object> valores)
        {
            ClassFunctions.SetProperties(oEntidadeLei, valores);
            oEntidadeLei.Salvar();
            return oEntidadeLei.ID;
        }

        public CrudActionTypes Excluir()
        {
            return oEntidadeLei.Excluir();
        }

    #endregion

    }
}
