using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using Poa.Entidade;
using Pro.Utils;
using Pro.Dal;

namespace Platinium.Entidade
{
    [ClassAttribute(Schema = "platinium", Table = "TB_DESPESA_ITEM_DEIT")]
    public class DespesaItem
    {

        #region Variáveis e Propriedades

        private Dao oDao;

        private int iID = 0;
        private DateTime? dDataCriado;
        private int? iIdItem;
        private Item oItem;
        private int? iIdDespesa;
        private Despesa oDespesa;
        private DateTime? dDataDesativado;
        private bool sAtivo;

        [PropertyAttribute(Field = "ID_DESPESA_ITEM", AllowNull = false, PropertyType = PropertyCategories.PrimaryKey, Variable = "iID")]
        public int ID
        {
            get { return iID; }
        }

        [PropertyAttribute(Field = "DAT_CRIADO", AllowNull = false, PropertyType = PropertyCategories.Field)]
        public DateTime? DataCriado
        {
            get { return dDataCriado; }
            set { dDataCriado = value; }
        }

        [PropertyAttribute(Field = "DAT_DESATIVADO", AllowNull = true, PropertyType = PropertyCategories.Field)]
        public DateTime? DataDesativado
        {
            get { return dDataDesativado; }
            set { dDataDesativado = value; }
        }
        [PropertyAttribute(Field = "COD_DESPESA_ITEM", AllowNull = false, PropertyType = PropertyCategories.Field)]
        public String Codigo
        {
            get;
            set;
        }

        [PropertyAttribute(Field = "DSC_DESPESA_ITEM", Description = "Descrição", AllowNull = false, PropertyType = PropertyCategories.Field, Size = 255)]
        public string Descricao
        {
            get;
            set;
        }

        [PropertyAttribute(Field = "FK_ITEM", AllowNull = false, Description = "Ítem", PropertyType = PropertyCategories.ForeignKey, Variable = "iIdItem")]
        public Item Item
        {
            get
            {
                if (oItem == null && iIdItem != null)
                    oItem = new Item((int)iIdItem, oDao);
                return oItem;
            }
            set
            {
                oItem = value;
                iIdItem = oItem.ID;
            }
        }

        [PropertyAttribute(Field = "FK_DESPESA", AllowNull = false, Description = "Despesa", PropertyType = PropertyCategories.ForeignKey, Variable = "iIdDespesa")]
        public Despesa Despesa
        {
            get
            {
                if (oDespesa == null && iIdDespesa != null)
                    oDespesa = new Despesa((int)iIdDespesa, oDao);
                return oDespesa;
            }
            set
            {
                oDespesa = value;
                iIdDespesa = oDespesa.ID;
            }
        }

        [PropertyAttribute(Field = "FLG_ATIVO", AllowNull = false, PropertyType = PropertyCategories.Field, DataType = DataTypes.Char)]
        public bool EAtivo
        {
            get { return sAtivo; }
            set { sAtivo = value; }
        }

        #endregion

        #region Construtores
        public DespesaItem() { }
        public DespesaItem(Dao dao)
        {
            oDao = dao;
        }

        public DespesaItem(int id, Dao dao)
        {
            List<Parameter> parametro = new List<Parameter>();
            parametro.Add(new Parameter("ID", id, ParameterTypes.Filter));
            oDao = dao;
            oDao.Load(this, parametro);
        }

        #endregion

        #region Métodos

        public CrudActionTypes Salvar()
        {
            ManipularDatas();

            Validar();
            if (iID == 0) return oDao.Insert(this);
            else return oDao.Update(this);
        }

        private void ManipularDatas()
        {
            if (iID == 0)
                this.DataCriado = DateTime.Now;

            this.DataDesativado = null;

            if (!this.EAtivo)
                this.DataDesativado = DateTime.Now;
        }

        public CrudActionTypes Excluir()
        {
            try
            {
                return oDao.Delete(this);
            }
            catch
            {
                throw new ViolacaoRegraException("Registro não pode ser excluido !");
            }
        }

        private void Validar()
        {
            CampoNuloOuInvalidoException ex = new CampoNuloOuInvalidoException();
            ex.Mensagens = Pro.Utils.ClassFunctions.ValidateRules(this);
            if (ex.Mensagens.Count > 0)
                throw ex;
        }

        public bool ValidarItensCadastrados()
        {
            List<Parameter> parametro = new List<Parameter>();

            parametro.Add(new Parameter("Item", this.Item.ID, OperationTypes.EqualsTo));
            parametro.Add(new Parameter("Despesa", this.Despesa.ID, OperationTypes.EqualsTo));

            DataTable dt = oDao.Select(parametro, "platinium", "TB_DESPESA_ITEM_DEIT", typeof(DespesaItem));
            if (dt.Rows.Count != 0)
                return true;
            return false;
        }

        #endregion

    }

}

