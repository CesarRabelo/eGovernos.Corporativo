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
    public class ManterArquivo:IManter
    {
        
        #region Variáveis e Propriedades

        private Arquivo oArquivo;
        private Dao oDao;

        #endregion

        #region Construtores

        public ManterArquivo()
		{
            oDao = new Dao();
		}

        public ManterArquivo(string connectionString, DataBaseTypes dataBaseType)
        {
            oDao = new Dao(connectionString, dataBaseType);
        }

	    #endregion 
    
        #region Métodos

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao, string colunaSort)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(Arquivo));
            dicionario.Add("DSC_TIPO_ENVIO", "DscTipoEnvio");
            dicionario.Add("DSC_RESPONSAVEL_ENVIO", "DscResponsavelEnvio");

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

            return this.oDao.Select(lstParametros, "platinium", "VI_ARQUIVO_ARQU", dicionario);

        }

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(Arquivo));
            dicionario.Add("DSC_TIPO_ENVIO", "DscTipoEnvio");
            dicionario.Add("DSC_RESPONSAVEL_ENVIO", "DscResponsavelEnvio");

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
            return this.oDao.Select(lstParametros, "platinium", "VI_ARQUIVO_ARQU", dicionario);
        }

        public void PrepararInclusao()
        {
            oArquivo = new Arquivo(oDao);
        }

        public Dictionary<string, object> Selecionar(int id)
        {
            oArquivo = new Arquivo(id, oDao);
            return ClassFunctions.GetProperties(oArquivo);
        }

        public CrudActionTypes Salvar(Dictionary<string, object> valores)
        {
            ClassFunctions.SetProperties(oArquivo, valores);
            return oArquivo.Salvar();
        }

        public int SalvarRetornandoId(Dictionary<string, object>valores)
        {
            ClassFunctions.SetProperties(oArquivo, valores);
            oArquivo.Salvar();
            return oArquivo.ID;
        }

        public CrudActionTypes Excluir()
        {
            return oArquivo.Excluir();
        }
        #endregion
    }
}
