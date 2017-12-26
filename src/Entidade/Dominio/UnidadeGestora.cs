using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

using Pro.Utils;
using Pro.Dal;
using Neonium.Entidade;
  


namespace Platinium.Entidade
{
    [ClassAttribute(Schema = "platinium", Table = "TB_UNIDADE_GESTORA_UNGE")]
    public class UnidadeGestora
    {

    #region Variáveis e Propriedades

        private Dao oDao;

        private int iID = 0;
        private DateTime? dDataCriado;
        private DateTime? dDataCriacao;
        private DateTime? dDataExtinsao;
        private int? iIdEntidade;
        private Entidade oEntidade;
        private DateTime? dDataDesativado;
        private bool bAtivo;

        [PropertyAttribute(Field = "ID_UNIDADE_GESTORA", AllowNull = false, PropertyType = PropertyCategories.PrimaryKey, Variable = "iID")]
        public int ID
        {
            get { return iID; }
        }

        [PropertyAttribute(Field = "DAT_CRIADO", Description = "Data de criação", AllowNull = false, PropertyType = PropertyCategories.Field)]
        public DateTime? DataCriado
        {
            get { return dDataCriado; }
            set { dDataCriado = value; }
        }

        [PropertyAttribute(Field = "DAT_CRIACAO", Description = "Data de criação", AllowNull = false, PropertyType = PropertyCategories.Field)]
        public DateTime? DataCriacao
        {
            get { return dDataCriacao; }
            set { dDataCriacao = value; }
        }
                
        [PropertyAttribute(Field = "DAT_EXTINCAO", Description = "Data de extinção", AllowNull = true, PropertyType = PropertyCategories.Field)]
        public DateTime? DataExtincao
        {
            get { return dDataExtinsao; }
            set { dDataExtinsao = value; }
        }

        [PropertyAttribute(Field = "DAT_DESATIVADO", AllowNull = true, PropertyType = PropertyCategories.Field)]
        public DateTime? DataDesativado
        {
            get { return dDataDesativado; }
            set { dDataDesativado = value; }
        }

        [PropertyAttribute(Field = "COD_UNIDADE_GESTORA", Description = "Código", AllowNull = false, PropertyType = PropertyCategories.Field, Size = 8)]
        public string Codigo
        {
            get;
            set;
        }
        
        [PropertyAttribute(Field = "FK_ENTIDADE", AllowNull = false, Description = "Órgão", PropertyType = PropertyCategories.ForeignKey, Variable = "iIdEntidade")]
        public Entidade Entidade
        {
            get
            {
                if (oEntidade == null && iIdEntidade != null)
                    oEntidade = new Entidade((int)iIdEntidade, oDao);
                return oEntidade;
            }
            set
            {
                oEntidade = value;
                iIdEntidade = oEntidade.ID;
            }
        }

        [PropertyAttribute(Field = "DSC_UNIDADE_GESTORA", Description = "Descrição", AllowNull = false, PropertyType = PropertyCategories.Field, Size = 255)]
        public string Descricao
        {
            get;
            set;
        }

        [PropertyAttribute(Field = "NUM_LEI_CRIACAO", Description = "Lei de Criação", AllowNull = true, PropertyType = PropertyCategories.Field, Size = 10)]
        public string NumLei
        {
            get;
            set;
        }

        [PropertyAttribute(Field = "FLG_ATIVO", AllowNull = false, PropertyType = PropertyCategories.Field, DataType = DataTypes.Char)]
        public bool Ativo
        {
            get { return bAtivo; }
            set { bAtivo = value; }
        }


    #endregion

    #region Construtores
        public UnidadeGestora() { }
		public UnidadeGestora(Dao dao)
		{
			oDao = dao;
		}

        public UnidadeGestora(int id, Dao dao)
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

