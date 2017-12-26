using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

using Pro.Utils;
using Pro.Dal;
using Neonium.Entidade;
  


namespace Platinium.Entidade
{
    [ClassAttribute(Schema = "platinium", Table = "TB_ENTIDADE_ENTI")]
    public class Secretaria
    {

    #region Variáveis e Propriedades

        private Dao oDao;

        private int iID = 0;
        private DateTime? dDataCriado;
        private int? iIdEndereco;
        private Endereco oEndereco;
        private int? iIdTipoEntidade;
        private TipoEntidade oTipoEntidade;
        private int? iIdPoder;
        private Poder oPoder;
        private DateTime? dDataDesativado;
        private bool bAtivo;

        [PropertyAttribute(Field = "ID_ENTIDADE_ENTI", AllowNull = false, PropertyType = PropertyCategories.PrimaryKey, Variable = "iID")]
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

        [PropertyAttribute(Field = "DAT_DESATIVADO", AllowNull = true, PropertyType = PropertyCategories.Field)]
        public DateTime? DataDesativado
        {
            get { return dDataDesativado; }
            set { dDataDesativado = value; }
        }

        [PropertyAttribute(Field = "FK_ENDERECO", AllowNull = true, Description = "Endereço", PropertyType = PropertyCategories.ForeignKey, Variable = "iIdEndereco")]
        public Endereco Endereco
        {
            get
            {
                if (oEndereco == null && iIdEndereco != null)
                    oEndereco = new Endereco((int)iIdEndereco, oDao);
                return oEndereco;
            }
            set
            {
                oEndereco = value;
                iIdEndereco = oEndereco.ID;
            }
        }

        [PropertyAttribute(Field = "FK_TIPO_ENTIDADE_TIEN", AllowNull = false, Description = "Tipo de entidade", PropertyType = PropertyCategories.ForeignKey, Variable = "iIdTipoEntidade")]
        public TipoEntidade TipoEntidade
        {
            get
            {
                if (oTipoEntidade == null && iIdTipoEntidade != null)
                    oTipoEntidade = new TipoEntidade((int)iIdTipoEntidade, oDao);
                return oTipoEntidade;
            }
            set
            {
                oTipoEntidade = value;
                iIdTipoEntidade = oTipoEntidade.ID;
            }
        }

        [PropertyAttribute(Field = "FK_PODER_PODE", AllowNull = false, Description = "Poder", PropertyType = PropertyCategories.ForeignKey, Variable = "iIdPoder")]
        public Poder Poder
        {
            get
            {
                if (oPoder == null && iIdPoder != null)
                    oPoder = new Poder((int)iIdPoder, oDao);
                return oPoder;
            }
            set
            {
                oPoder = value;
                iIdPoder = oPoder.ID;
            }
        }

        [PropertyAttribute(Field = "COD_ENTIDADE", Description = "Código", AllowNull = false, PropertyType = PropertyCategories.Field, Size = 8)]
        public string CodEntidade
        {
            get;
            set;
        }

        [PropertyAttribute(Field = "COD_ABREV", AllowNull = true, PropertyType = PropertyCategories.Field, Size = 2)]
        public string CodAbrev
        {
            get;
            set;
        }

        [PropertyAttribute(Field = "COD_GESTORA", Description = "Código gestora", AllowNull = false, PropertyType = PropertyCategories.Field, Size = 6)]
        public string CodGestora
        {
            get;
            set;
        }

        [PropertyAttribute(Field = "DSC_ENTIDADE", Description = "Descrição", AllowNull = false, PropertyType = PropertyCategories.Field, Size = 255)]
        public string Descricao
        {
            get;
            set;
        }

        [PropertyAttribute(Field = "DSC_SIGLA", AllowNull = false, PropertyType = PropertyCategories.Field, Size = 10)]
        public string Sigla
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

        [PropertyAttribute(Field = "NOM_RESPONSAVEL", AllowNull = true, PropertyType = PropertyCategories.Field, Size = 150)]
        public string Responsavel
        {
            get;
            set;
        }

        [PropertyAttribute(Field = "DSC_EMAIL_RESPONSAVEL", AllowNull = true, PropertyType = PropertyCategories.Field, Size = 100)]
        public string EmailResponsavel
        {
            get;
            set;
        }

        [PropertyAttribute(Field = "DSC_TRATAMENTO_RESPONSAVEL", AllowNull = true, PropertyType = PropertyCategories.Field, Size = 15)]
        public string TratamentoResponsavel
        {
            get;
            set;
        }

        [PropertyAttribute(Field = "NUM_TELEFONE_RESPONSAVEL", AllowNull = true, PropertyType = PropertyCategories.Field, Size = 20)]
        public string TelefoneResponsavel
        {
            get;
            set;
        }

        [PropertyAttribute(Field = "NUM_CNPJ", Description = "Cnpj", AllowNull = true, PropertyType = PropertyCategories.Field, Size = 18)]
        public string CNPJ
        {
            get;
            set;
        }

        [PropertyAttribute(Field = "NUM_TELEFONE", Description = "Telefone", AllowNull = true, PropertyType = PropertyCategories.Field, Size = 20)]
        public string Telefone
        {
            get;
            set;
        }

        [PropertyAttribute(Field = "NUM_FAX", Description = "Fax", AllowNull = true, PropertyType = PropertyCategories.Field, Size = 20)]
        public string Fax
        {
            get;
            set;
        }

        [PropertyAttribute(Field = "DSC_EMAIL", Description = "Email", AllowNull = true, PropertyType = PropertyCategories.Field, Size = 100)]
        public string Email
        {
            get;
            set;
        }

    #endregion

    #region Construtores
        public Secretaria() { }
		public Secretaria(Dao dao)
		{
			oDao = dao;
		}

        public Secretaria(int id, Dao dao)
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
            ValidarDuplicidade();

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

        private void ValidarDuplicidade()
        {

            ValidarDescricaoCadastrada();

            ValidarCodEntidadeCadastrada();
        }

        private void ValidarCodEntidadeCadastrada()
        {
            List<Parameter> parametro = new List<Parameter>();
            parametro.Add(new Parameter("CodEntidade", this.CodEntidade.ToUpper(), ParameterTypes.Filter));
            parametro.Add(new Parameter("ID", this.ID, OperationTypes.NotIn));

            if (oDao.Select(parametro, "platinium", "VI_SECRETARIA_SECR", typeof(Secretaria)).Rows.Count != 0)
                throw new RegraNegocioException("Secretária já cadastrada com o código informado.");
        }

        private void ValidarDescricaoCadastrada()
        {
            List<Parameter> parametro = new List<Parameter>();
            parametro.Add(new Parameter("Descricao", this.Descricao.ToUpper(), ParameterTypes.Filter));
            parametro.Add(new Parameter("ID", this.ID, OperationTypes.NotIn));

            if (oDao.Select(parametro, "platinium", "VI_SECRETARIA_SECR", typeof(Secretaria)).Rows.Count != 0)
                throw new RegraNegocioException("Secretária já cadastrada com a descrição informada.");
        }

	#endregion

    }

}

