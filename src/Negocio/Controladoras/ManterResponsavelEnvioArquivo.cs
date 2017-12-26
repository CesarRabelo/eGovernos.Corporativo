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
    public class ManterResponsavelEnvioArquivo : IManter
    {

        #region Variáveis e Propriedades

        private ResponsavelEnvioArquivo oResponsavelEnvioArquivo;
        private Dao oDao;

        #endregion

        #region Construtores

        public ManterResponsavelEnvioArquivo()
        {
            oDao = new Dao();
        }

        public ManterResponsavelEnvioArquivo(string connectionString, DataBaseTypes dataBaseType)
        {
            oDao = new Dao(connectionString, dataBaseType);
        }

        #endregion

        #region Métodos

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao, string colunaSort)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(ResponsavelEnvioArquivo));
            dicionario.Add("DSC_ATIVO", "DscAtivo");


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

            return this.oDao.Select(lstParametros, "platinium", "VI_RESPONSAVEL_ENVIO_ARQUIVO", dicionario);

        }

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(ResponsavelEnvioArquivo));
            dicionario.Add("DSC_ATIVO", "DscAtivo");

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
            return this.oDao.Select(lstParametros, "platinium", "VI_RESPONSAVEL_ENVIO_ARQUIVO", dicionario);
        }

        public void PrepararInclusao()
        {
            oResponsavelEnvioArquivo = new ResponsavelEnvioArquivo(oDao);
        }

        public Dictionary<string, object> Selecionar(int id)
        {
            oResponsavelEnvioArquivo = new ResponsavelEnvioArquivo(id, oDao);
            return ClassFunctions.GetProperties(oResponsavelEnvioArquivo);
        }

        public CrudActionTypes Salvar(Dictionary<string, object> valores)
        {
            ClassFunctions.SetProperties(oResponsavelEnvioArquivo, valores);
            return oResponsavelEnvioArquivo.Salvar();
        }

        public CrudActionTypes Excluir()
        {
            return oResponsavelEnvioArquivo.Excluir();
        }
        #endregion
    }
}
