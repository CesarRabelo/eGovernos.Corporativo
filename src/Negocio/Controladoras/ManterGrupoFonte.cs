
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
    public class ManterGrupoFonte:IManter
    {
        
        #region Variáveis e Propriedades

        private GrupoFonte oGrupoFonte;
        private Dao oDao;

        #endregion

        #region Construtores

        public ManterGrupoFonte()
		{
            oDao = new Dao();
		}

        public ManterGrupoFonte(string connectionString, DataBaseTypes dataBaseType)
        {
            oDao = new Dao(connectionString, dataBaseType);
        }

	    #endregion 
    
        #region Métodos

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao, string colunaSort)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(GrupoFonte));
            dicionario.Add("DSC_PAI", "DscPai");

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

            return this.oDao.Select(lstParametros, "platinium", "VI_GRUPO_FONTE_GRFO", dicionario);

        }

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(GrupoFonte));
            dicionario.Add("DSC_PAI", "DscPai");

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
            return this.oDao.Select(lstParametros, "platinium", "VI_GRUPO_FONTE_GRFO", dicionario);
        }

        public void PrepararInclusao()
        {
            oGrupoFonte = new GrupoFonte(oDao);
        }

        public Dictionary<string, object> Selecionar(int id)
        {
            oGrupoFonte = new GrupoFonte(id, oDao);
            return ClassFunctions.GetProperties(oGrupoFonte);
        }

        public CrudActionTypes Salvar(Dictionary<string, object> valores)
        {
            ClassFunctions.SetProperties(oGrupoFonte, valores);
            return oGrupoFonte.Salvar();
        }

        public CrudActionTypes Excluir()
        {
            return oGrupoFonte.Excluir();
        }
        #endregion
    }
}
