﻿using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

using Pro.Utils;
using Pro.Dal;

using Platinium.Entidade;
using Negocio;

namespace Platinium.Negocio
{
    public class ManterResponsavelEnvio:IManter
    {
        
        #region Variáveis e Propriedades

        private ResponsavelEnvio oResponsavelEnvio;
        private Dao oDao;

        #endregion

        #region Construtores

        public ManterResponsavelEnvio()
		{
            oDao = new Dao();
		}

        public ManterResponsavelEnvio(string connectionString, DataBaseTypes dataBaseType)
        {
            oDao = new Dao(connectionString, dataBaseType);
        }

	    #endregion 
    
        #region Métodos

        public void PrepararInclusao()
        {
            oResponsavelEnvio = new ResponsavelEnvio(oDao);
        }

        public Dictionary<string, object> Selecionar(int id)
        {
            oResponsavelEnvio = new ResponsavelEnvio(id, oDao);
            return ClassFunctions.GetProperties(oResponsavelEnvio);
        }

        public CrudActionTypes Salvar(Dictionary<string, object> valores)
        {
            ClassFunctions.SetProperties(oResponsavelEnvio, valores);
            return oResponsavelEnvio.Salvar();
        }

        public CrudActionTypes Excluir()
        {
            return oResponsavelEnvio.Excluir();
        }

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao, string colunaSort)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(ResponsavelEnvio));

            List<Parameter> lstParametros = new List<Parameter>();
            foreach (KeyValuePair<string, object> item in filtros)
            {
                lstParametros.Add(new Parameter(item.Key, item.Value, OperationTypes.Like));
            }
            lstParametros.Add(new Parameter(colunaSort, null, OperationTypes.Null, direcao));

            return this.oDao.Select(lstParametros, "platinium", "TB_RESPONSAVEL_ENVIO_REEN", dicionario);

        }

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(ResponsavelEnvio));

            List<Parameter> lstParametros = new List<Parameter>();
            foreach (KeyValuePair<string, object> item in filtros)
            {
                lstParametros.Add(new Parameter(item.Key, item.Value, OperationTypes.Like, direcao));
            }
            return this.oDao.Select(lstParametros, "platinium", "TB_RESPONSAVEL_ENVIO_REEN", dicionario);
        }

        #endregion
    }
}
