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
    public class ManterGrauInstrucao:IManter
    {
        
        #region Variáveis e Propriedades

        private GrauInstrucao oGrauInstrucao;
        private Dao oDao;

        #endregion

        #region Construtores

        public ManterGrauInstrucao()
		{
            oDao = new Dao();
		}

        public ManterGrauInstrucao(string connectionString, DataBaseTypes dataBaseType)
        {
            oDao = new Dao(connectionString, dataBaseType);
        }

	    #endregion 
    
        #region Métodos

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao, string colunaSort)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(GrauInstrucao));


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

            return this.oDao.Select(lstParametros, "plutonium", "TB_GRAU_INSTRUCAO_GRIN", dicionario);

        }

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(GrauInstrucao));

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
            return this.oDao.Select(lstParametros, "plutonium", "TB_GRAU_INSTRUCAO_GRIN", dicionario);
        }

        public void PrepararInclusao()
        {
            oGrauInstrucao = new GrauInstrucao(oDao);
        }

        public Dictionary<string, object> Selecionar(int id)
        {
            oGrauInstrucao = new GrauInstrucao(id, oDao);
            return ClassFunctions.GetProperties(oGrauInstrucao);
        }

        public CrudActionTypes Salvar(Dictionary<string, object> valores)
        {
            ClassFunctions.SetProperties(oGrauInstrucao, valores);
            return oGrauInstrucao.Salvar();
        }

        public CrudActionTypes Excluir()
        {
            return oGrauInstrucao.Excluir();
        }
        #endregion
    }
}
