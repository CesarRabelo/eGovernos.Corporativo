using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

using Pro.Utils;
using Pro.Dal;
using Platinium.Negocio;
using Platinium.Entidade;
using Negocio;

namespace Platinium.Negocio
{
    public class ManterAgenteItem : IManter
    {

        #region Variáveis e Propriedades

        private AgenteItem oAgenteItem;
        private Dao oDao;

        #endregion

        #region Construtores

        public ManterAgenteItem()
        {
            oDao = new Dao();
        }

        public ManterAgenteItem(string connectionString, DataBaseTypes dataBaseType)
        {
            oDao = new Dao(connectionString, dataBaseType);
        }

        #endregion

        #region Métodos

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao, string colunaSort)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(AgenteItem));
            dicionario.Add("DSC_ITEM_REMUNERATORIO", "DscItem");
            dicionario.Add("DSC_TIPO_EXPEDIENTE", "DscTipoExpediente");
            dicionario.Add("DSC_TIPO_ITEM_REMUNERATORIO", "DscTipoItem");

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

            return this.oDao.Select(lstParametros, "plutonium", "VI_AGENTE_ITEM_REMUNERATORIO_AGIR", dicionario);

        }

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(AgenteItem));
            dicionario.Add("DSC_ITEM_REMUNERATORIO", "DscItem");
            dicionario.Add("DSC_TIPO_EXPEDIENTE", "DscTipoExpediente");
            dicionario.Add("DSC_TIPO_ITEM_REMUNERATORIO", "DscTipoItem");

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
            return this.oDao.Select(lstParametros, "plutonium", "VI_AGENTE_ITEM_REMUNERATORIO_AGIR", dicionario);
        }

        public void PrepararInclusao()
        {
            oAgenteItem = new AgenteItem(oDao);
        }

        public Dictionary<string, object> Selecionar(int id)
        {
            oAgenteItem = new AgenteItem(id, oDao);
            return ClassFunctions.GetProperties(oAgenteItem);
        }

        public CrudActionTypes Salvar(Dictionary<string, object> valores)
        {
            ClassFunctions.SetProperties(oAgenteItem, valores);
            return oAgenteItem.Salvar();
        }

        public CrudActionTypes Excluir()
        {
            return oAgenteItem.Excluir();
        }
        #endregion

        public DataTable getDadosItens()
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(AgenteItem));

            List<Parameter> lstParametros = new List<Parameter>();
            dicionario.Add("ID_ITEM_REMUNERATORIO", "Id");
            dicionario.Add("COD_ITEM_REMUNERATORIO", "CodItem");
            dicionario.Add("DSC_ITEM_REMUNERATORIO", "DscItens");

            return this.oDao.Select(lstParametros, "plutonium", "VI_ITEM_REMUNERATORIO_ITRE", dicionario);
        }

        public void SalvarItens(List<string> ListaIds, Dictionary<string, object> dictionary, string AgentePublico)
        {
            CampoNuloOuInvalidoException ex = new CampoNuloOuInvalidoException();
            AgenteItem oAgenteItem = new AgenteItem(oDao);
            oAgenteItem.Ativo = oAgenteItem.DataExpedienteSuspensao == null;
            foreach (string id in ListaIds)
            {
                ClassFunctions.SetProperties(oAgenteItem, dictionary);
                oAgenteItem.AgentePublico = new AgentePublico(Convert.ToInt32(AgentePublico), oDao);
                oAgenteItem.ItemRemuneratorio = new ItemRemuneratorio(Convert.ToInt32(id), oDao);
                if (oAgenteItem.ValidarItensCadastrados("S"))
                    ex.Mensagens.Add(oAgenteItem.ItemRemuneratorio.Descricao, oAgenteItem.ItemRemuneratorio.Descricao + " , já cadastrado para este agente!");
            }
            if (ex.Mensagens.Count > 0)
            {
                throw ex;
            }
            else
            {
                foreach (string id in ListaIds)
                {
                    ClassFunctions.SetProperties(oAgenteItem, dictionary);
                    oAgenteItem.AgentePublico = new AgentePublico(Convert.ToInt32(AgentePublico), oDao);
                    oAgenteItem.ItemRemuneratorio = new ItemRemuneratorio(Convert.ToInt32(id), oDao);
                    oAgenteItem.Salvar();
                }
                oAgenteItem.ValidarExterno();
            }
        }

        public void ValidacaoExistente(string IdItem)
        {
            try
            {
                Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(AgenteItem));
                List<Parameter> lstParametros = new List<Parameter>();
                lstParametros.Add(new Parameter("ItemRemuneratorio", Convert.ToInt32(IdItem), OperationTypes.EqualsTo));
                DataTable dt = this.oDao.Select(lstParametros, "plutonium", "VI_AGENTE_ITEM_REMUNERATORIO_AGIR", dicionario);

                if (dt.Rows.Count > 0)
                    throw new ViolacaoRegraException("Este agente já possui o ítem remuneratório selecionado!");

            }
            catch (Exception)
            {
                throw;
            }

        }

        public void ValidarEntidade(int id)
        {
            AgentePublico oAgentePublico = new AgentePublico(id, oDao);
            oAgenteItem.AgentePublico = oAgentePublico;
            oAgenteItem.Salvar();
        }

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
