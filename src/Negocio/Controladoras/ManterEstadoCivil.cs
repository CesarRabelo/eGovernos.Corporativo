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
    public class ManterEstadoCivil:IManter
    {
        
        #region Variáveis e Propriedades

        private EstadoCivil oEstadoCivil;
        private Dao oDao;

        #endregion

        #region Construtores

        public ManterEstadoCivil()
		{
            oDao = new Dao();
		}

        public ManterEstadoCivil(string connectionString, DataBaseTypes dataBaseType)
        {
            oDao = new Dao(connectionString, dataBaseType);
        }

	    #endregion 
    
        #region Métodos

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao, string colunaSort)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(EstadoCivil));


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

            return this.oDao.Select(lstParametros, "plutonium", "TB_ESTADO_CIVIL_ESCI", dicionario);

        }

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(EstadoCivil));

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
            return this.oDao.Select(lstParametros, "plutonium", "TB_ESTADO_CIVIL_ESCI", dicionario);
        }

        public void PrepararInclusao()
        {
            oEstadoCivil = new EstadoCivil(oDao);
        }

        public Dictionary<string, object> Selecionar(int id)
        {
            oEstadoCivil = new EstadoCivil(id, oDao);
            return ClassFunctions.GetProperties(oEstadoCivil);
        }

        public CrudActionTypes Salvar(Dictionary<string, object> valores)
        {
            ClassFunctions.SetProperties(oEstadoCivil, valores);
            return oEstadoCivil.Salvar();
        }

        public CrudActionTypes Excluir()
        {
            return oEstadoCivil.Excluir();
        }
        #endregion
    }
}
