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
    public class ManterEsfera:IManter
    {
        
        #region Variáveis e Propriedades

        private Esfera oEsfera;
        private Dao oDao;

        #endregion

        #region Construtores

        public ManterEsfera()
		{
            oDao = new Dao();
		}

        public ManterEsfera(string connectionString, DataBaseTypes dataBaseType)
        {
            oDao = new Dao(connectionString, dataBaseType);
        }

	    #endregion 
    
        #region Métodos

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao, string colunaSort)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(Esfera));
            dicionario.Add("dsc_ativo", "dscAtivo");

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

            return this.oDao.Select(lstParametros, "platinium", "vi_esfera_esfe", dicionario);

        }

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(Esfera));
            dicionario.Add("dsc_ativo", "dscAtivo");

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
            return this.oDao.Select(lstParametros, "platinium", "vi_esfera_esfe ", dicionario);
        }

        public void PrepararInclusao()
        {
            oEsfera = new Esfera(oDao);
        }

        public Dictionary<string, object> Selecionar(int id)
        {
            oEsfera = new Esfera(id, oDao);
            return ClassFunctions.GetProperties(oEsfera);
        }

        public CrudActionTypes Salvar(Dictionary<string, object> valores)
        {
            ClassFunctions.SetProperties(oEsfera, valores);
            return oEsfera.Salvar();
        }

        public CrudActionTypes Excluir()
        {
            return oEsfera.Excluir();
        }
        #endregion
    }
}
