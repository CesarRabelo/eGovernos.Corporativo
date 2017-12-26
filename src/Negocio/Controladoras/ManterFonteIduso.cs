using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

using Pro.Utils;
using Pro.Dal;
using Negocio;
using Platinium.Entidade;


namespace Platinium.Negocio
{
    public class ManterFonteIduso:IManter
    {        
        #region Variáveis e Propriedades

        private FonteIduso oFonteIduso;
        private Dao oDao;

        #endregion

        #region Construtores

        public ManterFonteIduso()
		{
            oDao = new Dao();
		}

        public ManterFonteIduso(string connectionString, DataBaseTypes dataBaseType)
        {
            oDao = new Dao(connectionString, dataBaseType);
        }

	    #endregion 
    
        #region Métodos

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao, string colunaSort)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(FonteIduso));
            dicionario.Add("DSC_IDUSO", "DscIduso");
            dicionario.Add("COD_IDUSO", "CodIduso");

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

            return this.oDao.Select(lstParametros, "platinium", "VI_FONTE_IDUSO", dicionario);

        }

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(FonteIduso));
            dicionario.Add("DSC_IDUSO", "DscIduso");
            dicionario.Add("COD_IDUSO", "CodIduso");

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
            return this.oDao.Select(lstParametros, "platinium", "VI_FONTE_IDUSO", dicionario);
        }

        public void PrepararInclusao()
        {
            oFonteIduso = new FonteIduso(oDao);
        }

        public Dictionary<string, object> Selecionar(int id)
        {
            oFonteIduso = new FonteIduso(id, oDao);
            return ClassFunctions.GetProperties(oFonteIduso);
        }

        public CrudActionTypes Salvar(Dictionary<string, object> valores)
        {
            ClassFunctions.SetProperties(oFonteIduso, valores);
            return oFonteIduso.Salvar();
        }

        public CrudActionTypes Excluir()
        {
            return oFonteIduso.Excluir();
        }
        #endregion
    }
}
