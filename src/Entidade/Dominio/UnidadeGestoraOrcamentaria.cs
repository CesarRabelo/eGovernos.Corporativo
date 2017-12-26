using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

using Pro.Utils;
using Pro.Dal;


namespace Platinium.Entidade
{
    [ClassAttribute(Schema = "platinium", Table = "TB_UNIDADE_GESTORA_ORCAMENTARIA_UNGO")]
    public class UnidadeGestoraOrcamentaria
    {
        #region Variáveis e Propriedades

        private Dao oDao;

        private int iID = 0;
        private DateTime? dDataCriado;
        private DateTime? dDataDesativado;
        private DateTime? dDataInicio;
        private DateTime? dDataFim;
        private bool bAtivo;
        private int? iIdUnidadeGestora;
        private UnidadeGestora oUnidadeGestora;
        private int? iIdUnidadeOrcamentaria;
        private UnidadeOrcamentaria oUnidadeOrcamentaria;

        [PropertyAttribute(Field = "ID_UNIDADE_GESTORA_ORCAMENTARIA", AllowNull = false, PropertyType = PropertyCategories.PrimaryKey, Variable = "iID")]
        public int ID
        {
            get { return iID; }
        }

        [PropertyAttribute(Field = "FK_UNIDADE_GESTORA", AllowNull = false, Description = "Unidade Gestora", PropertyType = PropertyCategories.ForeignKey, Variable = "iIdUnidadeGestora")]
        public UnidadeGestora UnidadeGestora
        {
            get
            {
                if (oUnidadeGestora == null && iIdUnidadeGestora != null)
                    oUnidadeGestora = new UnidadeGestora((int)iIdUnidadeGestora, oDao);
                return oUnidadeGestora;
            }
            set
            {
                oUnidadeGestora = value;
                iIdUnidadeGestora = oUnidadeGestora.ID;
            }
        }

        [PropertyAttribute(Field = "FK_UNIDADE_ORCAMENTARIA", AllowNull = false, Description = "Unidade Orçamentária", PropertyType = PropertyCategories.ForeignKey, Variable = "iIdUnidadeOrcamentaria")]
        public UnidadeOrcamentaria UnidadeOrcamentaria
        {
            get
            {
                if (oUnidadeOrcamentaria == null && iIdUnidadeOrcamentaria != null)
                    oUnidadeOrcamentaria = new UnidadeOrcamentaria((int)iIdUnidadeOrcamentaria, oDao);
                return oUnidadeOrcamentaria;
            }
            set
            {
                oUnidadeOrcamentaria = value;
                iIdUnidadeOrcamentaria = oUnidadeOrcamentaria.ID;
            }
        }

        [PropertyAttribute(Field = "DAT_INICIO", Description = "Data Inicial", AllowNull = false, PropertyType = PropertyCategories.Field)]
        public DateTime? DataInicio
        {
            get { return dDataInicio; }
            set { dDataInicio = value; }
        }

        [PropertyAttribute(Field = "DAT_FIM", Description = "Data Final", AllowNull = true, PropertyType = PropertyCategories.Field)]
        public DateTime? DataFim
        {
            get { return dDataFim; }
            set { dDataFim = value; }
        }

        [PropertyAttribute(Field = "DAT_CRIADO", Description = "Data de criação", AllowNull = false, PropertyType = PropertyCategories.Field)]
        public DateTime? DataCriado
        {
            get { return dDataCriado; }
            set { dDataCriado = value; }
        }

        [PropertyAttribute(Field = "DAT_DESATIVADO", Description = "Data de desativação",AllowNull = true, PropertyType = PropertyCategories.Field)]
        public DateTime? DataDesativado
        {
            get { return dDataDesativado; }
            set { dDataDesativado = value; }
        }

        [PropertyAttribute(Field = "FLG_ATIVO", AllowNull = false, PropertyType = PropertyCategories.Field, DataType = DataTypes.Char, Size = 1)]
        public bool Ativo
        {
            get { return bAtivo; }
            set { bAtivo = value; }
        }

        #endregion

        #region Construtores
        public UnidadeGestoraOrcamentaria() { }
		public UnidadeGestoraOrcamentaria(Dao dao)
		{
			oDao = dao;
		}

        public UnidadeGestoraOrcamentaria(int id, Dao dao)
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
            //ValidarUnidadeOrcamentariaCadastrado();

            if (iID == 0)
            {
                ValidarUnidadeOrcamentariaCadastrado();
                return oDao.Insert(this);
            }
            else
                return oDao.Update(this);
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

        private void ValidarUnidadeOrcamentariaCadastrado()
        {
            List<Parameter> parametro = new List<Parameter>();
            parametro.Add(new Parameter("UnidadeOrcamentaria", this.UnidadeOrcamentaria.ID, OperationTypes.EqualsTo));
            parametro.Add(new Parameter("UnidadeGestora", this.UnidadeGestora.ID, OperationTypes.EqualsTo));

            if (oDao.Select(parametro, "platinium", "TB_UNIDADE_GESTORA_ORCAMENTARIA_UNGO", typeof(UnidadeGestoraOrcamentaria)).Rows.Count != 0)
                throw new ViolacaoRegraException("Unidade Orçamentaria já cadastrada.");
        }

        #endregion
    }
}
