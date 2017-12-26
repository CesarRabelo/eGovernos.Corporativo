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
    public class ManterUnidadeOrcamentaria:IManter
    {
        
        #region Variáveis e Propriedades

        private UnidadeOrcamentaria oUnidadeOrcamentaria;
        private Dao oDao;

        #endregion

        #region Construtores

        public ManterUnidadeOrcamentaria()
		{
            oDao = new Dao();
		}

        public ManterUnidadeOrcamentaria(string connectionString, DataBaseTypes dataBaseType)
        {
            oDao = new Dao(connectionString, dataBaseType);
        }

	    #endregion 
    
        #region Métodos

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao, string colunaSort)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(UnidadeOrcamentaria));
            dicionario.Add("DSC_SECRETARIA_SIGLA", "DscSecretariaSigla");
            dicionario.Add("COD_ORGAO", "codOrgao");
            dicionario.Add("DSC_ORGAO_SIGLA", "dscOrgaoSigla");
            dicionario.Add("DSC_PODER", "dscPoder");
            dicionario.Add("COD_PODER", "codPoder");
            dicionario.Add("COD_TIPO_ENTIDADE", "codTipoEntidade");
            dicionario.Add("DSC_TIPO_ENTIDADE", "dscTipoEntidade");
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

            return this.oDao.Select(lstParametros, "platinium", "VI_UNIDADE_ORCAMENTARIA", dicionario);

        }

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(UnidadeOrcamentaria));
            dicionario.Add("DSC_SECRETARIA_SIGLA", "DscSecretariaSigla");
            dicionario.Add("COD_ORGAO", "codOrgao");
            dicionario.Add("DSC_ORGAO_SIGLA", "dscOrgaoSigla");
            dicionario.Add("DSC_PODER", "dscPoder");
            dicionario.Add("COD_PODER", "codPoder");
            dicionario.Add("COD_TIPO_ENTIDADE", "codTipoEntidade");
            dicionario.Add("DSC_TIPO_ENTIDADE", "dscTipoEntidade");
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
            return this.oDao.Select(lstParametros, "platinium", "VI_UNIDADE_ORCAMENTARIA", dicionario);
        }

        public void PrepararInclusao()
        {
            oUnidadeOrcamentaria = new UnidadeOrcamentaria(oDao);
        }

        public Dictionary<string, object> Selecionar(int id)
        {
            oUnidadeOrcamentaria = new UnidadeOrcamentaria(id, oDao);
            return ClassFunctions.GetProperties(oUnidadeOrcamentaria);
        }

        public CrudActionTypes Salvar(Dictionary<string, object> valores)
        {
            ClassFunctions.SetProperties(oUnidadeOrcamentaria, valores);
            return oUnidadeOrcamentaria.Salvar();
        }

        public CrudActionTypes Excluir()
        {
            return oUnidadeOrcamentaria.Excluir();
        }

        public int SecretariaID(int id)
        {
            UnidadeOrcamentaria oUnidadeOrcamentaria = new UnidadeOrcamentaria(id, oDao);
            return oUnidadeOrcamentaria.Secretaria.ID;
        }
        public int OrgaoID(int id)
        {
            UnidadeOrcamentaria oUnidadeOrcamentaria = new UnidadeOrcamentaria(id, oDao);
            return oUnidadeOrcamentaria.Orgao.ID;
        }
        public int SalvarRetornandoId(Dictionary<string, object> valores)
        {
            ClassFunctions.SetProperties(oUnidadeOrcamentaria, valores);
            oUnidadeOrcamentaria.Salvar();
            return oUnidadeOrcamentaria.ID;
        }
        #endregion
    }
}
