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
    public class ManterSubFuncao:IManter
    {
        
        #region Variáveis e Propriedades

        private SubFuncao oSubFuncao;
        private Dao oDao;

        #endregion

        #region Construtores

        public ManterSubFuncao()
		{
            oDao = new Dao();
		}

        public ManterSubFuncao(string connectionString, DataBaseTypes dataBaseType)
        {
            oDao = new Dao(connectionString, dataBaseType);
        }

	    #endregion 
    
        #region Métodos

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao, string colunaSort)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(SubFuncao));
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

            return this.oDao.Select(lstParametros, "platinium", "VI_SUBFUNCAO_SUBF", dicionario);

        }

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(SubFuncao));
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
            return this.oDao.Select(lstParametros, "platinium", "VI_SUBFUNCAO_SUBF ", dicionario);
        }

        public void PrepararInclusao()
        {
            oSubFuncao = new SubFuncao(oDao);
        }

        public Dictionary<string, object> Selecionar(int id)
        {
            oSubFuncao = new SubFuncao(id, oDao);
            return ClassFunctions.GetProperties(oSubFuncao);
        }

        public CrudActionTypes Salvar(Dictionary<string, object> valores)
        {
            ClassFunctions.SetProperties(oSubFuncao, valores);
            return oSubFuncao.Salvar();
        }

        public CrudActionTypes Excluir()
        {
            return oSubFuncao.Excluir();
        }
        #endregion
    }
}
