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
    public class ManterTipoPrograma:IManter
    {
        
        #region Variáveis e Propriedades

        private TipoPrograma oTipoPrograma;
        private Dao oDao;

        #endregion

        #region Construtores

        public ManterTipoPrograma()
		{
            oDao = new Dao();
		}

        public ManterTipoPrograma(string connectionString, DataBaseTypes dataBaseType)
        {
            oDao = new Dao(connectionString, dataBaseType);
        }

	    #endregion 
    
        #region Métodos

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao, string colunaSort)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(TipoPrograma));
            dicionario.Add("dsc_ativo", "DscAtivo");

            List<Parameter> lstParametros = new List<Parameter>();
            foreach (KeyValuePair<string, object> item in filtros)
            {
                lstParametros.Add(new Parameter(item.Key, item.Value, OperationTypes.Like));
            }
            lstParametros.Add(new Parameter(colunaSort, null, OperationTypes.Null, direcao));

            return this.oDao.Select(lstParametros, "platinium", "VI_TIPO_PROGRAMA_TIPR", dicionario);

        }

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(TipoPrograma));
            dicionario.Add("dsc_ativo", "DscAtivo");

            List<Parameter> lstParametros = new List<Parameter>();
            foreach (KeyValuePair<string, object> item in filtros)
            {
                lstParametros.Add(new Parameter(item.Key, item.Value, OperationTypes.Like, direcao));
            }
            return this.oDao.Select(lstParametros, "platinium", "VI_TIPO_PROGRAMA_TIPR", dicionario);
        }

        public void PrepararInclusao()
        {
            oTipoPrograma = new TipoPrograma(oDao);
        }

        public Dictionary<string, object> Selecionar(int id)
        {
            oTipoPrograma = new TipoPrograma(id, oDao);
            return ClassFunctions.GetProperties(oTipoPrograma);
        }

        public CrudActionTypes Salvar(Dictionary<string, object> valores)
        {
            ClassFunctions.SetProperties(oTipoPrograma, valores);
            return oTipoPrograma.Salvar();
        }

        public CrudActionTypes Excluir()
        {
            return oTipoPrograma.Excluir();
        }

        

        #endregion
    }
}
