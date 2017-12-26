using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

using Pro.Utils;
using Pro.Dal;
using Platinium.Entidade;
using Neonium.Entidade;

using Negocio;

namespace Platinium.Negocio
{
    public class ManterConcessaoItem : IManter
    {

        #region Variáveis e Propriedades

        private AgenteItem oConcessaoItemPessoa;
        private Dao oDao;

        #endregion

        #region Construtores

        public ManterConcessaoItem()
        {
            oDao = new Dao();
        }

        public ManterConcessaoItem(string connectionString, DataBaseTypes dataBaseType)
        {
            oDao = new Dao(connectionString, dataBaseType);
        }

        #endregion

        #region Métodos

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao, string colunaSort)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(AgenteItem));
            dicionario.Add("ID_AGENTE_PUBLICO", "CodAgente");
            dicionario.Add("DSC_NOME", "DscNome");
            dicionario.Add("DSC_SIGLA", "DscSigla");
            dicionario.Add("DAT_EXPEDIENTE_CONCESSAO", "DscData");
            dicionario.Add("DSC_ITEM_REMUNERATORIO", "DscItem");
            dicionario.Add("COD_UNIDADE_ORCAMENTARIA", "CodUnidadeOrcamentaria");

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

            return this.oDao.Select(lstParametros, "plutonium", "VI_CONCESSAO_ITEM", dicionario);

        }

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(AgenteItem));
            dicionario.Add("ID_AGENTE_PUBLICO", "CodAgente");
            dicionario.Add("DSC_NOME", "DscNome");
            dicionario.Add("DSC_SIGLA", "DscSigla");
            dicionario.Add("DAT_EXPEDIENTE_CONCESSAO", "DscData");
            dicionario.Add("DSC_ITEM_REMUNERATORIO", "DscItem");
            dicionario.Add("COD_UNIDADE_ORCAMENTARIA", "CodUnidadeOrcamentaria");


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
            return this.oDao.Select(lstParametros, "plutonium", "VI_CONCESSAO_ITEM", dicionario);
        }

        public void PrepararInclusao()
        {
            oConcessaoItemPessoa = new AgenteItem(oDao);
        }

        public Dictionary<string, object> Selecionar(int id)
        {
            oConcessaoItemPessoa = new AgenteItem(id, oDao);
            return ClassFunctions.GetProperties(oConcessaoItemPessoa);
        }

        public CrudActionTypes Salvar(Dictionary<string, object> valores)
        {
            ClassFunctions.SetProperties(oConcessaoItemPessoa, valores);
            return oConcessaoItemPessoa.Salvar();
        }

        public CrudActionTypes Excluir()
        {
            return oConcessaoItemPessoa.Excluir();
        }
        #endregion

        #region Filtragem de acordo com o agente selecionado

        public DataTable getDadosAgentes(Dictionary<string, object> filtros, string direcao, string colunaSort)
        {
            DataTable dtAgentes = new DataTable();
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(AgenteItem));

            List<Parameter> lstParametros = new List<Parameter>();
            dicionario.Add("ID_AGENTE_PUBLICO", "Id");
            dicionario.Add("DSC_NOME", "DscNome");
            dicionario.Add("NUM_CPF", "DscCpf");
            dicionario.Add("ID_UNIDADE_ORCAMENTARIA", "UnidadeOrcamentaria");
            dicionario.Add("FK_ORGAO", "Orgao");

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

            //if (!string.IsNullOrEmpty(IdUnidadeOrcamentaria))
            //    lstParametros.Add(new Parameter("IdUnidadeOrcamentaria", Convert.ToInt32(IdUnidadeOrcamentaria), OperationTypes.EqualsTo));

            dtAgentes = oDao.Select(lstParametros, "plutonium", "vi_agentes_ativos", dicionario);
            return dtAgentes;
        }

        public DataTable getDadosdtAgenteItens(string idItem, string IdUnidadeOrcamentaria)
        {
            DataTable dtAgenteItens = new DataTable();
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(AgenteItem));

            List<Parameter> lstParametros = new List<Parameter>();
            dicionario.Add("ID_AGENTE_PUBLICO", "Id");
            dicionario.Add("ID_AGENTE_ITEM_REMUNERATORIO", "IdAgenteItemRemuneratorio");
            dicionario.Add("DSC_NOME", "DscNome");
            dicionario.Add("NUM_CPF", "DscCpf");

            lstParametros.Add(new Parameter("ItemRemuneratorio", Convert.ToInt32(idItem), OperationTypes.EqualsTo));

            dtAgenteItens = oDao.Select(lstParametros, "plutonium", "VI_AGENTE_CONCESSAO_ITEM", dicionario);
            return dtAgenteItens;
        }

        public DataTable getDadosAgentesItens(DataTable dtAgentes, DataTable dtAgenteItens)
        {
            DataTable dt = new DataTable();
            string ids = string.Empty;
            DataView dv = dtAgentes.DefaultView;


            foreach (DataRow row in dtAgenteItens.Rows)
                ids += row["Id"].ToString() + ",";
            if (dtAgenteItens.Rows.Count > 0)
            {
                ids = ids.Substring(0, ids.Length - 1);
                dv.RowFilter = string.Format("Id not in ({0})", ids);
            }
            return dv.ToTable();
        }

        public void SalvarItens(List<string> ListaIds, Dictionary<string, object> dictionary)
        {
            foreach (string id in ListaIds)
            {
                AgenteItem oAgenteItem = new AgenteItem(oDao);
                ClassFunctions.SetProperties(oAgenteItem, dictionary);
                oAgenteItem.AgentePublico = new AgentePublico(Convert.ToInt32(id), oDao);
                oAgenteItem.Salvar();
            }
        }

        #endregion

        #region Suspenção de Itens

        public void SalvarComUc(Dictionary<string, object> valoresUC, List<string> ListaIdSelecionados)
        {
            try
            {
                oDao.StartTransactionMode();

                foreach (string id in ListaIdSelecionados)
                {
                    AgenteItem oAgenteItem = new AgenteItem(Convert.ToInt32(id), oDao);
                    ClassFunctions.SetProperties(oAgenteItem, valoresUC);
                    oAgenteItem.Salvar();
                }

                oDao.Commit();
            }
            catch
            {
                oDao.RollBack();
                throw;
            }
        }

        #endregion
    }
}
