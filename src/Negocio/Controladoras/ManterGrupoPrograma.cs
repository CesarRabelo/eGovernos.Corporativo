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
    public class ManterGrupoPrograma:IManter
    {
        
        #region Variáveis e Propriedades

        private GrupoPrograma oGrupoPrograma;
        private Dao oDao;

        #endregion

        #region Construtores

        public ManterGrupoPrograma()
		{
            oDao = new Dao();
		}

        public ManterGrupoPrograma(string connectionString, DataBaseTypes dataBaseType)
        {
            oDao = new Dao(connectionString, dataBaseType);
        }

	    #endregion 
    
        #region Métodos

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao, string colunaSort)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(GrupoPrograma));
            dicionario.Add("DSC_ATIVO", "DscAtivo");
            dicionario.Add("DSC_TIPO_PROGRAMA", "descricaoPrograma");

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

            return this.oDao.Select(lstParametros, "platinium", "VI_GRUPO_PROGRAMA_GRPR", dicionario);

        }

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(GrupoPrograma));
            dicionario.Add("dsc_ativo", "DscAtivo");
            dicionario.Add("dsc_tipo_programa", "descricaoPrograma");

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
            return this.oDao.Select(lstParametros, "platinium", "VI_GRUPO_PROGRAMA_GRPR", dicionario);
        }

        public void PrepararInclusao()
        {
            oGrupoPrograma = new GrupoPrograma(oDao);
        }

        public Dictionary<string, object> Selecionar(int id)
        {
            oGrupoPrograma = new GrupoPrograma(id, oDao);
            return ClassFunctions.GetProperties(oGrupoPrograma);
        }

        public CrudActionTypes Salvar(Dictionary<string, object> valores)
        {
            ClassFunctions.SetProperties(oGrupoPrograma, valores);
            return oGrupoPrograma.Salvar();
        }

        public CrudActionTypes Excluir()
        {
            return oGrupoPrograma.Excluir();
        }

        

        #endregion
    }
}
