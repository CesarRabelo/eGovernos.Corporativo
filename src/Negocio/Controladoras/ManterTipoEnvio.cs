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
    public class ManterTipoEnvio:IManter
    {
        
        #region Variáveis e Propriedades

        private TipoEnvio oTipoEnvio;
        private Dao oDao;

        #endregion

        #region Construtores

        public ManterTipoEnvio()
		{
            oDao = new Dao();
		}

        public ManterTipoEnvio(string connectionString, DataBaseTypes dataBaseType)
        {
            oDao = new Dao(connectionString, dataBaseType);
        }

	    #endregion 
    
        #region Métodos

        public void PrepararInclusao()
        {
            oTipoEnvio = new TipoEnvio(oDao);
        }

        public Dictionary<string, object> Selecionar(int id)
        {
            oTipoEnvio = new TipoEnvio(id, oDao);
            return ClassFunctions.GetProperties(oTipoEnvio);
        }

        public CrudActionTypes Salvar(Dictionary<string, object> valores)
        {
            ClassFunctions.SetProperties(oTipoEnvio, valores);
            return oTipoEnvio.Salvar();
        }

        public CrudActionTypes Excluir()
        {
            return oTipoEnvio.Excluir();
        }

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao, string colunaSort)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(TipoEnvio));

            List<Parameter> lstParametros = new List<Parameter>();
            foreach (KeyValuePair<string, object> item in filtros)
            {
                lstParametros.Add(new Parameter(item.Key, item.Value, OperationTypes.Like));
            }
            lstParametros.Add(new Parameter(colunaSort, null, OperationTypes.Null, direcao));

            return this.oDao.Select(lstParametros, "platinium", "TB_TIPO_ENVIO_TIEN", dicionario);

        }

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(TipoEnvio));

            List<Parameter> lstParametros = new List<Parameter>();
            foreach (KeyValuePair<string, object> item in filtros)
            {
                lstParametros.Add(new Parameter(item.Key, item.Value, OperationTypes.Like, direcao));
            }
            return this.oDao.Select(lstParametros, "platinium", "TB_TIPO_ENVIO_TIEN", dicionario);
        }

        #endregion
    }
}
