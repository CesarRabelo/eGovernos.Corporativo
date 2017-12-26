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
    public class ManterTipoPisPasep:IManter
    {
        
        #region Variáveis e Propriedades

        private TipoPisPasep oTipoPisPasep;
        private Dao oDao;

        #endregion

        #region Construtores

        public ManterTipoPisPasep()
		{
            oDao = new Dao();
		}

        public ManterTipoPisPasep(string connectionString, DataBaseTypes dataBaseType)
        {
            oDao = new Dao(connectionString, dataBaseType);
        }

	    #endregion 
    
        #region Métodos

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao, string colunaSort)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(TipoPisPasep));


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

            return this.oDao.Select(lstParametros, "plutonium", "TB_TIPO_PIS_PASEP_TIPP", dicionario);

        }

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(TipoPisPasep));

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
            return this.oDao.Select(lstParametros, "plutonium", "TB_TIPO_PIS_PASEP_TIPP", dicionario);
        }

        public void PrepararInclusao()
        {
            oTipoPisPasep = new TipoPisPasep(oDao);
        }

        public Dictionary<string, object> Selecionar(int id)
        {
            oTipoPisPasep = new TipoPisPasep(id, oDao);
            return ClassFunctions.GetProperties(oTipoPisPasep);
        }

        public CrudActionTypes Salvar(Dictionary<string, object> valores)
        {
            ClassFunctions.SetProperties(oTipoPisPasep, valores);
            return oTipoPisPasep.Salvar();
        }

        public CrudActionTypes Excluir()
        {
            return oTipoPisPasep.Excluir();
        }
        #endregion
    }
}
