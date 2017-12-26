using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using Platinium.Entidade;
using Pro.Utils;
using Pro.Dal;


namespace Platinium.Entidade
{
    [ClassAttribute(Schema = "plutonium", Table = "TB_ITEM_REMUNERATORIO_ITRE")]
    public class ItemRemuneratorio
    {

        #region Variáveis e Propriedades

        private Dao oDao;

        private int iID = 0;
        private DateTime? dDataAmparoLegal;
        private DateTime? dDataAmparoPublicacao;
        private DateTime? dDataNormaLegal;
        private DateTime? dDataNormaPublicacao;
        private DateTime? dDataCriado;
        private DateTime? dDataDesativado;
        private DateTime? dDataAmparoLegalExtincao;
        private DateTime? dDataAmparoExtincaoPublicacao;
        private DateTime? dDataNormaLegalExtincao;
        private DateTime? dDataNormaExtincaoPublicacao;
        private bool bAtivo;
        private int? iIdTipoItem;
        private TipoItem oTipoItem;
        private int? iIdAmparoLegal;
        private TipoAmparo oAmparoLegal;
        private int? iIdClassificacaoItem;
        private ClassificacaoItem oClassificacaoItem;
        private int? iIdAmparoLegalExtincao;
        private TipoAmparo oAmparoLegalExtincao;

        [PropertyAttribute(Field = "ID_ITEM_REMUNERATORIO", AllowNull = false, PropertyType = PropertyCategories.PrimaryKey, Variable = "iID")]
        public int ID
        {
            get { return iID; }
        }

        [PropertyAttribute(Field = "COD_ITEM_REMUNERATORIO", Description = "Código", AllowNull = false, PropertyType = PropertyCategories.Field, Size = 4)]
        public string Codigo
        {
            get;
            set;
        }

        [PropertyAttribute(Field = "DSC_ITEM_REMUNERATORIO", Description = "Descrição", AllowNull = false, PropertyType = PropertyCategories.Field, Size = 150)]
        public string Descricao
        {
            get;
            set;
        }

        [PropertyAttribute(Field = "NUM_AMPARO_LEGAL_ORIGINOU", Description = "Número do Amparo Legal", AllowNull = false, PropertyType = PropertyCategories.Field, Size = 10)]
        public string NumeroAmparo
        {
            get;
            set;
        }

        [PropertyAttribute(Field = "DAT_AMPARO_LEGAL_ORIGINOU", Description = "Data do Amparo Legal", AllowNull = false, PropertyType = PropertyCategories.Field)]
        public DateTime? DataAmparoLegal
        {
            get { return dDataAmparoLegal; }
            set { dDataAmparoLegal = value; }
        }

        [PropertyAttribute(Field = "DAT_AMPARO_LEGAL_ORIGINOU_PUBLICACAO", AllowNull = true, PropertyType = PropertyCategories.Field)]
        public DateTime? DataAmparoPublicacao
        {
            get { return dDataAmparoPublicacao; }
            set { dDataAmparoPublicacao = value; }
        }


        [PropertyAttribute(Field = "NUM_NORMA_LEGAL", Description = "Número da Norma Legal", AllowNull = true, PropertyType = PropertyCategories.Field, Size = 10)]
        public string NumeroNormaLegal
        {
            get;
            set;
        }

        [PropertyAttribute(Field = "DAT_NORMA_LEGAL", Description = "Data da Norma Legal", AllowNull = true, PropertyType = PropertyCategories.Field)]
        public DateTime? DataNormaLegal
        {
            get { return dDataNormaLegal; }
            set { dDataNormaLegal = value; }
        }

        [PropertyAttribute(Field = "DAT_NORMA_LEGAL_PUBLICACAO", AllowNull = true, PropertyType = PropertyCategories.Field)]
        public DateTime? DataNormaPublicacao
        {
            get { return dDataNormaPublicacao; }
            set { dDataNormaPublicacao = value; }
        }

        [PropertyAttribute(Field = "DAT_CRIADO", Description = "Data de Criação", AllowNull = false, PropertyType = PropertyCategories.Field)]
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

        [PropertyAttribute(Field = "FLG_ATIVO", AllowNull = false, PropertyType = PropertyCategories.Field, DataType = DataTypes.Char)]
        public bool Ativo
        {
            get { return bAtivo; }
            set { bAtivo = value; }
        }

        [PropertyAttribute(Field = "NUM_AMPARO_LEGAL_EXTINSAO", Description = "Número do Amparo Legal Extinção", AllowNull = true, PropertyType = PropertyCategories.Field, Size = 10)]
        public string NumeroAmparoExtincao
        {
            get;
            set;
        }

        [PropertyAttribute(Field = "DAT_AMPARO_LEGAL_EXTINSAO", Description = "Data do Amparo Legal Extinção", AllowNull = true, PropertyType = PropertyCategories.Field)]
        public DateTime? DataAmparoLegalExtincao
        {
            get { return dDataAmparoLegalExtincao; }
            set { dDataAmparoLegalExtincao = value; }
        }

        [PropertyAttribute(Field = "DAT_AMPARO_LEGAL_EXTINSAO_PUBLICACAO", AllowNull = true, PropertyType = PropertyCategories.Field)]
        public DateTime? DataAmparoExtincaoPublicacao
        {
            get { return dDataAmparoExtincaoPublicacao; }
            set { dDataAmparoExtincaoPublicacao = value; }
        }


        [PropertyAttribute(Field = "NUM_NORMA_LEGAL_EXTINSAO", Description = "Número da Norma Legal Extinção", AllowNull = true, PropertyType = PropertyCategories.Field, Size = 10)]
        public string NumeroNormaLegalExtincao
        {
            get;
            set;
        }

        [PropertyAttribute(Field = "DAT_NORMA_LEGAL_EXTINSAO", Description = "Data da Norma Legal Extinção", AllowNull = true, PropertyType = PropertyCategories.Field)]
        public DateTime? DataNormaLegalExtincao
        {
            get { return dDataNormaLegalExtincao; }
            set { dDataNormaLegalExtincao = value; }
        }

        [PropertyAttribute(Field = "DAT_NORMA_LEGAL_EXTINSAO_PUBLICACAO", AllowNull = true, PropertyType = PropertyCategories.Field)]
        public DateTime? DataNormaExtincaoPublicacao
        {
            get { return dDataNormaExtincaoPublicacao; }
            set { dDataNormaExtincaoPublicacao = value; }
        }

        [PropertyAttribute(Field = "FK_TIPO_ITEM", AllowNull = false, Description = "Tipos de Items", PropertyType = PropertyCategories.ForeignKey, Variable = "iIdTipoItem")]
        public TipoItem TipoItem
        {
            get
            {
                if (oTipoItem == null && iIdTipoItem != null)
                    oTipoItem = new TipoItem((int)iIdTipoItem, oDao);
                return oTipoItem;
            }
            set
            {
                oTipoItem = value;
                iIdTipoItem = oTipoItem.ID;
            }
        }

        [PropertyAttribute(Field = "FK_AMPARO_LEGAL_ORIGINOU", AllowNull = false, Description = "Amparo Legal", PropertyType = PropertyCategories.ForeignKey, Variable = "iIdAmparoLegal")]
        public TipoAmparo AmparoLegal
        {
            get
            {
                if (oAmparoLegal == null && iIdAmparoLegal != null)
                    oAmparoLegal = new TipoAmparo((int)iIdAmparoLegal, oDao);
                return oAmparoLegal;
            }
            set
            {
                oAmparoLegal = value;
                iIdAmparoLegal = oAmparoLegal.ID;
            }
        }


        [PropertyAttribute(Field = "FK_CLASSIFICACAO_ITEM", AllowNull = false, Description = "Classificação de Item", PropertyType = PropertyCategories.ForeignKey, Variable = "iIdClassificacaoItem")]
        public ClassificacaoItem ClassificacaoItem
        {
            get
            {
                if (oClassificacaoItem == null && iIdClassificacaoItem != null)
                    oClassificacaoItem = new ClassificacaoItem((int)iIdClassificacaoItem, oDao);
                return oClassificacaoItem;
            }
            set
            {
                oClassificacaoItem = value;
                iIdClassificacaoItem = oClassificacaoItem.ID;
            }
        }

        [PropertyAttribute(Field = "FK_AMPARO_LEGAL_EXTINSAO", AllowNull = true, Description = "Amparo Legao Extinção", PropertyType = PropertyCategories.ForeignKey, Variable = "iIdAmparoLegalExtincao")]
        public TipoAmparo AmparoLegalExtincao
        {
            get
            {
                if (oAmparoLegalExtincao == null && iIdAmparoLegalExtincao != null)
                    oAmparoLegalExtincao = new TipoAmparo((int)iIdAmparoLegalExtincao, oDao);
                return oAmparoLegalExtincao;
            }
            set
            {
                oAmparoLegalExtincao = value;
                iIdAmparoLegalExtincao = oAmparoLegalExtincao.ID;
            }
        }

        #endregion

        #region Construtores
        public ItemRemuneratorio() { }
        public ItemRemuneratorio(Dao dao)
        {
            oDao = dao;
        }

        public ItemRemuneratorio(int id, Dao dao)
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

            if (!this.Ativo) this.DataDesativado = DateTime.Now;
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

        #endregion

    }

}

