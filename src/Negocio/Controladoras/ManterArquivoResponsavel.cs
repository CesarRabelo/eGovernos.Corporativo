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
    public class ManterArquivoResponsavel : IManter
    {

        #region Variáveis e Propriedades

        private ArquivoResponsavel oArquivoResponsavel;
        private Dao oDao;

        #endregion

        #region Construtores

        public ManterArquivoResponsavel()
        {
            oDao = new Dao();
        }

        public ManterArquivoResponsavel(string connectionString, DataBaseTypes dataBaseType)
        {
            oDao = new Dao(connectionString, dataBaseType);
        }

        #endregion

        #region Métodos

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao, string colunaSort)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(ArquivoResponsavel));
            dicionario.Add("DSC_RESPONSAVEL_ENVIO", "DscResponsavel");

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
            //lstParametros.Add(new Parameter(colunaSort, null, OperationTypes.Null, direcao));

            return this.oDao.Select(lstParametros, "platinium", "VI_ARQUIVO_RESPONSAVEL_ENVIO", dicionario);

        }

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(ArquivoResponsavel));
            dicionario.Add("DSC_RESPONSAVEL_ENVIO", "DscResponsavel");

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
            return this.oDao.Select(lstParametros, "platinium", "VI_ARQUIVO_RESPONSAVEL_ENVIO", dicionario);
        }

        public void PrepararInclusao()
        {
            oArquivoResponsavel = new ArquivoResponsavel(oDao);
        }

        public Dictionary<string, object> Selecionar(int id)
        {
            oArquivoResponsavel = new ArquivoResponsavel(id, oDao);
            return ClassFunctions.GetProperties(oArquivoResponsavel);
        }

        public CrudActionTypes Salvar(Dictionary<string, object> valores)
        {
            ClassFunctions.SetProperties(oArquivoResponsavel, valores);
            return oArquivoResponsavel.Salvar();
        }

        public CrudActionTypes Excluir()
        {
            return oArquivoResponsavel.Excluir();
        }
        #endregion
    }
}
