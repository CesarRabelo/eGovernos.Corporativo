using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using Poa.Entidade;
using Pro.Utils;
using Pro.Dal;
using Platinium.Entidade;

using Negocio;

namespace Platinium.Negocio
{
    public class ManterDespesa : IManter
    {

        #region Variáveis e Propriedades

        private Despesa oDespesa;
        private Dao oDao;

        #endregion

        #region Construtores

        public ManterDespesa()
        {
            oDao = new Dao();
        }

        public ManterDespesa(string connectionString, DataBaseTypes dataBaseType)
        {
            oDao = new Dao(connectionString, dataBaseType);
        }

        #endregion

        #region Métodos

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao, string colunaSort)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(Despesa));
            dicionario.Add("dsc_ativo", "DscAtivo");
            dicionario.Add("COD_COMPLETO_DESPESA", "CodDespesa");

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

            return this.oDao.Select(lstParametros, "platinium", "VI_DESPESA_DESP", dicionario);

        }

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(Despesa));
            dicionario.Add("dsc_ativo", "DscAtivo");
            dicionario.Add("COD_COMPLETO_DESPESA", "CodDespesa");

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
            return this.oDao.Select(lstParametros, "platinium", "VI_DESPESA_DESP", dicionario);
        }

        public void PrepararInclusao()
        {
            oDespesa = new Despesa(oDao);
        }

        public Dictionary<string, object> Selecionar(int id)
        {
            oDespesa = new Despesa(id, oDao);
            return ClassFunctions.GetProperties(oDespesa);
        }

        public CrudActionTypes Salvar(Dictionary<string, object> valores)
        {
            ClassFunctions.SetProperties(oDespesa, valores);
            if (oDespesa.Codigo.Length >= 5)
            {
                EconomicaDeDespesa oEconomicaDeDespesa = new EconomicaDeDespesa(oDespesa.Codigo.Substring(0, 1), oDao);
                GrupoDespesa oGrupoDespesa = new GrupoDespesa(oDespesa.Codigo.Substring(1, 1), oDao);
                ModalidadeAplicacao oModalidadeAplicacao = new ModalidadeAplicacao(oDespesa.Codigo.Substring(2, 2), oDao);
                ElementoDeDespesa oElementoDeDespesa = new ElementoDeDespesa(oDespesa.Codigo.Substring(4, 2), oDao);

                oDespesa.CatEconomica = oEconomicaDeDespesa;
                oDespesa.GrupoDespesa = oGrupoDespesa;
                oDespesa.ModalidadeAplicacao = oModalidadeAplicacao;
                oDespesa.ElementoDespesa = oElementoDeDespesa;


                try
                {
                    if (oDespesa.Codigo.Substring(6, 2).Equals("00") && oDespesa.Descricao == null)
                        oDespesa.Descricao = oElementoDeDespesa.Descricao;
                }
                catch
                {
                    return oDespesa.Salvar();
                }
            }

            return oDespesa.Salvar();
        }

        public CrudActionTypes Excluir()
        {
            return oDespesa.Excluir();
        }

        public string GetCodCatEconomica(string id)
        {
            EconomicaDeDespesa oEconomicaDeDespesa = new EconomicaDeDespesa(Convert.ToInt32(id), oDao);
            string codigo = oEconomicaDeDespesa.Codigo;
            return codigo;
        }
        public string GetCodGrupoDespesa(string id)
        {
            GrupoDespesa oGrupoDespesa = new GrupoDespesa(Convert.ToInt32(id), oDao);
            string codigo = oGrupoDespesa.Codigo;
            return codigo;
        }
        public string GetCodModAplicacao(string id)
        {
            ModalidadeAplicacao oModalidadeAplicacao = new ModalidadeAplicacao(Convert.ToInt32(id), oDao);
            string codigo = oModalidadeAplicacao.Codigo;
            return codigo;
        }
        public string GetCodElementoDespesa(string id)
        {
            ElementoDeDespesa oElementoDeDespesa = new ElementoDeDespesa(Convert.ToInt32(id), oDao);
            string codigo = oElementoDeDespesa.Codigo;
            return codigo;
        }
        #endregion

        public void Validar(System.Collections.Generic.List<string> msg)
        {
            //oDespesa.validar2(msg);
            CampoNuloOuInvalidoException ex = new CampoNuloOuInvalidoException();
            int aux = msg.Count;
            for (int i = 0; i < msg.Count; i++)
                ex.Mensagens.Add(Convert.ToString(i), msg[i]);

            if (ex.Mensagens.Count > 0)
                throw ex;
        }

        /// <summary>
        /// Esse método retorna todos os ítens referente a despesa.
        /// </summary>
        /// <returns></returns>
        public DataTable getItensPorDespesa(string idDespesa)
        {
            DataTable dtDespesaItens = new DataTable();
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(Despesa));

            List<Parameter> lstParametros = new List<Parameter>();
            dicionario.Add("ID_DESPESA_ITEM", "Id");
            dicionario.Add("ID_ITEM", "CodItem");
            dicionario.Add("ID_DESPESA_DESP", "CodDespesa");
            dicionario.Add("DSC_ITEM", "DscItem");
            dicionario.Add("COD_DESPESA_ITEM", "CodDespesaItem");

            lstParametros.Add(new Parameter("CodDespesa", Convert.ToInt32(idDespesa), OperationTypes.EqualsTo));

            dtDespesaItens = oDao.Select(lstParametros, "platinium", "VI_DESPESA_ITEM_DEIT", dicionario);
            return dtDespesaItens;
        }

        /// <summary>
        /// Esse método retorno todos os ítens.
        /// </summary>
        /// <returns></returns>
        public DataTable getItens(Dictionary<string, object> filtros)
        {
            DataTable dtDespesaItens = new DataTable();
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(Despesa));

            List<Parameter> lstParametros = new List<Parameter>();
            dicionario.Add("ID_ITEM", "Id");
            dicionario.Add("COD_ITEM", "CodItem");
            dicionario.Add("DSC_ITEM", "DscItem");

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

            dtDespesaItens = oDao.Select(lstParametros, "platinium", "VI_ITEM", dicionario);
            return dtDespesaItens;
        }


        /// <summary>
        /// Esse método retorno todos os ítens que existe naquela despesa.
        /// </summary>
        /// <returns></returns>
        public DataTable getItensDoAgente(string idDespesaSelecionada)
        {
            DataTable dtDespesaItens = new DataTable();
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(Despesa));

            List<Parameter> lstParametros = new List<Parameter>();
            dicionario.Add("ID_ITEM", "Id");
            dicionario.Add("COD_ITEM", "CodItem");
            dicionario.Add("DSC_ITEM", "DscItem");
            dicionario.Add("COD_DESPESA_ITEM", "DespesaItem");

            lstParametros.Add(new Parameter("DespesaItem", Convert.ToInt32(idDespesaSelecionada), OperationTypes.EqualsTo));

            dtDespesaItens = oDao.Select(lstParametros, "platinium", "VI_ITEM_DESPESA", dicionario);
            return dtDespesaItens;
        }

        public DataTable getItensSemAgente(DataTable dtItens, DataTable dtItensDoAgente)
        {
            DataTable dt = new DataTable();
            string ids = string.Empty;
            DataView dv = dtItens.DefaultView;


            foreach (DataRow row in dtItensDoAgente.Rows)
                ids += row["Id"].ToString() + ",";
            if (dtItensDoAgente.Rows.Count > 0)
            {
                ids = ids.Substring(0, ids.Length - 1);
                dv.RowFilter = string.Format("Id not in ({0})", ids);
            }
            return dv.ToTable();
        }

        public void SalvarItensDespesa(List<string> ListaIds, string CodDespesaItem, string IdDespesa)
        {
            CampoNuloOuInvalidoException ex = new CampoNuloOuInvalidoException();
            foreach (string id in ListaIds)
            {
                Item oItem = new Item(Convert.ToInt32(id), oDao);

                DespesaItem oDespesaItem = new DespesaItem(oDao);
                oDespesaItem.Codigo = CodDespesaItem.Substring(0,6) + oItem.Codigo;
                oDespesaItem.Descricao = oItem.Descricao;
                oDespesaItem.Item = oItem;
                oDespesaItem.Despesa = new Despesa(Convert.ToInt32(IdDespesa), oDao);
                oDespesaItem.EAtivo = true;
                if (oDespesaItem.ValidarItensCadastrados() == true)
                    ex.Mensagens.Add(oDespesaItem.Item.Descricao, oDespesaItem.Item.Descricao + " , já cadastrado para esta despesa!");
                if (ex.Mensagens.Count == 0)
                    oDespesaItem.Salvar();
            }
            if (ex.Mensagens.Count > 0)
            {
                throw ex;
            }
        }

        public void excluirItem(string idDespesaItem)
        {
            DespesaItem oDespesaItem = new DespesaItem(Convert.ToInt32(idDespesaItem), oDao);
            oDespesaItem.Excluir();
        }
    }
}
