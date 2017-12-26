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
    public class ManterItemRemuneratorio : IManter
    {
          
        #region Variáveis e Propriedades

        private ItemRemuneratorio oItemRemuneratorio;
        private Dao oDao;

        #endregion

        #region Construtores

        public ManterItemRemuneratorio()
        {
            oDao = new Dao();
        }

        public ManterItemRemuneratorio(string connectionString, DataBaseTypes dataBaseType)
        {
            oDao = new Dao(connectionString, dataBaseType);
        }

        #endregion

        #region Métodos

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao, string colunaSort)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(ItemRemuneratorio));
            dicionario.Add("COD_ITEM_REMUNERATORIO", "CodigoItemremuneratorio");
            dicionario.Add("DSC_ITEM_REMUNERATORIO", "DscItemRemuneratorio");
            dicionario.Add("NUM_AMPARO_LEGAL_ORIGINOU", "NumAmparoLegal");
            dicionario.Add("DSC_TIPO_ITEM_REMUNERATORIO", "DscTipoItem");
            dicionario.Add("DAT_AMPARO_LEGAL_ORIGINOU", "DataAmparoLegal");
            dicionario.Add("DSC_TIPO_AMPARO_LEGAL", "DscTipoAmparo");

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

            return this.oDao.Select(lstParametros, "plutonium", "VI_ITEM_REMUNERATORIO_ITRE", dicionario);

        }

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(ItemRemuneratorio));
            dicionario.Add("COD_ITEM_REMUNERATORIO", "CodigoItemremuneratorio");
            dicionario.Add("DSC_ITEM_REMUNERATORIO", "DscItemRemuneratorio");
            dicionario.Add("NUM_AMPARO_LEGAL_ORIGINOU", "NumAmparoLegal");
            dicionario.Add("DSC_TIPO_ITEM_REMUNERATORIO", "DscTipoItem");
            dicionario.Add("DAT_AMPARO_LEGAL_ORIGINOU", "DataAmparoLegal");
            dicionario.Add("DSC_TIPO_AMPARO_LEGAL", "DscTipoAmparo");

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
            return this.oDao.Select(lstParametros, "plutonium", "VI_ITEM_REMUNERATORIO_ITRE", dicionario);
        }

        public void PrepararInclusao()
        {
            oItemRemuneratorio = new ItemRemuneratorio(oDao);
        }

        public Dictionary<string, object> Selecionar(int id)
        {
            oItemRemuneratorio = new ItemRemuneratorio(id, oDao);
            return ClassFunctions.GetProperties(oItemRemuneratorio);
        }

        public CrudActionTypes Salvar(Dictionary<string, object> valores)
        {
            ClassFunctions.SetProperties(oItemRemuneratorio, valores);
    
            //Abaixo os campos digito esta se juntando com o código completando o ultimo digito do código.
           if (valores["Digito"] != null && valores["Codigo"] != null)
                oItemRemuneratorio.Codigo = valores["Digito"].ToString() + valores["Codigo"].ToString();

            return oItemRemuneratorio.Salvar();
        }
        /// <summary>
        /// Metodo de salvar a extinção da inserção
        /// </summary>
        /// <param name="valoresUC"></param>
        /// <returns></returns>
        public CrudActionTypes SalvarComUc(Dictionary<string, object> valoresUC)
        {
            try
            {
                ClassFunctions.SetProperties(oItemRemuneratorio, valoresUC);
                ValidarDadosUc(oItemRemuneratorio);
                return oItemRemuneratorio.Salvar();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
          
        }
        /// <summary>
        /// Metodo que salva os campos do popap com o item remuneratorio equivalente.
        /// </summary>
        /// <param name="Valores"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        public CrudActionTypes SalvarComUcListagem(Dictionary<string, object> Valores, int ID)
        {
            try
            {
                ItemRemuneratorio oItemRemuneratorio = new ItemRemuneratorio(ID, oDao);
                ClassFunctions.SetProperties(oItemRemuneratorio, Valores);
                ValidarDadosUc(oItemRemuneratorio);
                return oItemRemuneratorio.Salvar();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
           

        }
        /// <summary>
        /// Validação dos Items do Popap
        /// </summary>
        /// <param name="oItemRemuneratorio"></param>
        private void ValidarDadosUc(ItemRemuneratorio oItemRemuneratorio)
        {
            CampoNuloOuInvalidoException ex = new CampoNuloOuInvalidoException();
            if (string.IsNullOrEmpty(oItemRemuneratorio.NumeroAmparoExtincao))
            {
                ex.Mensagens.Add("NumeroAmparoExtincao", "<b>Número do Amparo Legal Extinção:</b> é de preenchimento obrigatorio.");
            }
            if (string.IsNullOrEmpty(Convert.ToString(oItemRemuneratorio.AmparoLegalExtincao)))
            {
                ex.Mensagens.Add("AmparoLegalExtincao", "<b>Amparo Legal da Extinção:</b> é de preenchimento obrigatório.");
            }
            if (string.IsNullOrEmpty(Convert.ToString(oItemRemuneratorio.DataAmparoLegalExtincao)))
            {
                ex.Mensagens.Add("DataAmparoLegalExtincao", "<b>Data do Amparo Legal Extinção:</b> é de preenchimento obrigatório.");
            }
            if (string.IsNullOrEmpty(Convert.ToString(oItemRemuneratorio.NumeroNormaLegalExtincao)))
            {
                ex.Mensagens.Add("NumeroNormaLegalExtincao", "<b>Número da Norma Legal Extinção:</b> é de preenchimento obrigatório.");
            }
            if (string.IsNullOrEmpty(Convert.ToString(oItemRemuneratorio.DataNormaLegalExtincao)))
            {
                ex.Mensagens.Add("DataNormaLegalExtincao", "<b>Data da Norma Legal Extinção:</b> é de preenchimento obrigatório.");
            }

            if (ex.Mensagens.Count > 0)
                throw ex;
        }

        public CrudActionTypes Excluir()
        {
            return oItemRemuneratorio.Excluir();
        }
        /// <summary>
        /// Metodo que separa o código removendo o primeiro campo e os outros 3 digitos para atribuição na alteração do cadastro.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string[] GetCodigo(int id)
        {
            string[] codigo = new string[2];
            ItemRemuneratorio oItemRemuneratorio = new ItemRemuneratorio(id, oDao);
            string aux = oItemRemuneratorio.Codigo;

            codigo[0] = aux.Substring(0, 1);
            aux = oItemRemuneratorio.Codigo;

            codigo[1] = aux.Substring(1, 3);

            return codigo;
        }

        public int Verificação(int IdItemRemuneratorio)
        {
            
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(AgenteItem));
            List<Parameter> lstParametros = new List<Parameter>();
            lstParametros.Add(new Parameter("ItemRemuneratorio", IdItemRemuneratorio, OperationTypes.EqualsTo));
            
            DataTable dt = this.oDao.Select(lstParametros, "plutonium", "TB_AGENTE_ITEM_REMUNERATORIO_AGIR", dicionario);
            return dt.Rows.Count;
            
        }
        public int Verificação()
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(AgenteItem));
            List<Parameter> lstParametros = new List<Parameter>();
            lstParametros.Add(new Parameter("ItemRemuneratorio", oItemRemuneratorio.ID, OperationTypes.EqualsTo));

            DataTable dt = this.oDao.Select(lstParametros, "plutonium", "TB_AGENTE_ITEM_REMUNERATORIO_AGIR", dicionario);
            return dt.Rows.Count;
        }
        #endregion








       
    }
}
