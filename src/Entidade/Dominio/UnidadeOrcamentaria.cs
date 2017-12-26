using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

using Pro.Utils;
using Pro.Dal;
  


namespace Platinium.Entidade
{
    [ClassAttribute(Schema = "platinium", Table = "TB_ENTIDADE_ENTI")]
    public class UnidadeOrcamentaria
    {

    #region Variáveis e Propriedades

        private Dao oDao;

        private int iID = 0;
        private DateTime? dDataCriado;
        private DateTime? dDataDesativado;
        private int? iIdTipoEntidade;
        private TipoEntidade oTipoEntidade;
        private int? iIdTipoAdministracao;
        private TipoAdministracao oTipoAdministracao;
        private int? iIdPoder;
        private Poder oPoder;
        private int? iIdOrgao;
        private Orgao oOrgao;
        private int? iIdSecretaria;
        private Secretaria oSecretaria;
        private bool bAtivo;

        [PropertyAttribute(Field = "ID_ENTIDADE_ENTI", AllowNull = false, PropertyType = PropertyCategories.PrimaryKey, Variable = "iID")]
        public int ID
        {
            get { return iID; }
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
        [PropertyAttribute(Field = "COD_ENTIDADE", Description = "Código", AllowNull = false, PropertyType = PropertyCategories.Field)]
        public string CodEntidade
        {
            get;
            set;
        }

        [PropertyAttribute(Field = "COD_ABREV", AllowNull = true, PropertyType = PropertyCategories.Field)]
        public string CodAbrev
        {
            get;
            set;
        }

        [PropertyAttribute(Field = "COD_GESTORA", Description="Código Gestora", AllowNull = false, PropertyType = PropertyCategories.Field)]
        public string CodGestora
        {
            get;
            set;
        }
        [PropertyAttribute(Field = "DSC_ENTIDADE", Description = "Descrição", AllowNull = false, PropertyType = PropertyCategories.Field)]
        public string Descricao
        {
            get;
            set;
        }

        [PropertyAttribute(Field = "DSC_SIGLA", AllowNull = true, PropertyType = PropertyCategories.Field)]
        public string Sigla
        {
            get;
            set;
        }


        [PropertyAttribute(Field = "FK_TIPO_ENTIDADE_TIEN", AllowNull = false, Description = "Tipo Entidade", PropertyType = PropertyCategories.ForeignKey, Variable = "iIdTipoEntidade")]
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

        [PropertyAttribute(Field = "FK_TIPO_ADMINISTRACAO_TIAD", AllowNull = false, Description = "Tipo de Administração", PropertyType = PropertyCategories.ForeignKey, Variable = "iIdTipoAdministracao")]
        public TipoAdministracao TipoAdministracao
        {
            get
            {
                if (oTipoAdministracao == null && iIdTipoAdministracao != null)
                    oTipoAdministracao = new TipoAdministracao((int)iIdTipoAdministracao, oDao);
                return oTipoAdministracao;
            }
            set
            {
                oTipoAdministracao = value;
                iIdTipoAdministracao = oTipoAdministracao.ID;
            }
        }

        [PropertyAttribute(Field = "FK_ORGAO", AllowNull = false, Description = "Órgão", PropertyType = PropertyCategories.ForeignKey, Variable = "iIdOrgao")]
        public Orgao Orgao
        {
            get
            {
                if (oOrgao == null && iIdOrgao != null)
                    oOrgao = new Orgao((int)iIdOrgao, oDao);
                return oOrgao;
            }
            set
            {
                oOrgao = value;
                iIdOrgao = oOrgao.ID;
            }
        }
        [PropertyAttribute(Field = "FK_SECRETARIA", AllowNull = false, Description = "Secretaria", PropertyType = PropertyCategories.ForeignKey, Variable = "iIdSecretaria")]
        public Secretaria Secretaria
        {
            get
            {
                if (oSecretaria == null && iIdSecretaria != null)
                    oSecretaria = new Secretaria((int)iIdSecretaria, oDao);
                return oSecretaria;
            }
            set
            {
                oSecretaria = value;
                iIdSecretaria = oSecretaria.ID;
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




        [PropertyAttribute(Field = "FLG_ATIVO", AllowNull = true, PropertyType = PropertyCategories.Field, DataType = DataTypes.Char)]
        public bool Ativo
        {
            get { return bAtivo; }
            set { bAtivo = value; }
        }

        [PropertyAttribute(Field = "NOM_RESPONSAVEL", AllowNull = true, PropertyType = PropertyCategories.Field)]
        public string Responsavel
        {
            get;
            set;
        }

        [PropertyAttribute(Field = "DSC_EMAIL_RESPONSAVEL", AllowNull = true, PropertyType = PropertyCategories.Field)]
        public string EmailResponsavel
        {
            get;
            set;
        }

        [PropertyAttribute(Field = "DSC_TRATAMENTO_RESPONSAVEL", AllowNull = true, PropertyType = PropertyCategories.Field)]
        public string TratamentoResponsavel
        {
            get;
            set;
        }

        [PropertyAttribute(Field = "NUM_TELEFONE_RESPONSAVEL", AllowNull = true, PropertyType = PropertyCategories.Field)]
        public string TelefoneResponsavel
        {
            get;
            set;
        }

    #endregion

    #region Construtores
        public UnidadeOrcamentaria() { }
		public UnidadeOrcamentaria(Dao dao)
		{
			oDao = dao;
		}

        public UnidadeOrcamentaria(int id, Dao dao)
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
            //ValidarDuplicidade();

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
            ValidarCodEntidadeCadastrada();
            ValidarDescricaoCadastrada();
            ValidarCodAbrevCadastrada();
            ValidarCodGestoraCadastrada();

        }

        private void ValidarCodEntidadeCadastrada()
        {
            List<Parameter> parametro = new List<Parameter>();
            parametro.Add(new Parameter("CodEntidade", this.CodEntidade.ToUpper(), ParameterTypes.Filter));
            parametro.Add(new Parameter("ID", this.ID, OperationTypes.NotIn));

            if (oDao.Select(parametro, "platinium", "VI_UNIDADE_ORCAMENTARIA_UNOR", typeof(UnidadeOrcamentaria)).Rows.Count != 0)
                throw new RegraNegocioException("Unidade Orçamentaria já cadastrada com o código informado!");
        }

        private void ValidarCodAbrevCadastrada()
        {
            List<Parameter> parametro = new List<Parameter>();
            parametro.Add(new Parameter("CodAbrev", this.CodAbrev.ToUpper(), ParameterTypes.Filter));
            parametro.Add(new Parameter("ID", this.ID, OperationTypes.NotIn));

            if (oDao.Select(parametro, "platinium", "VI_UNIDADE_ORCAMENTARIA_UNOR", typeof(UnidadeOrcamentaria)).Rows.Count != 0)
                throw new RegraNegocioException("Unidade Orçamentaria já cadastrada com o código informado!");
        }

        private void ValidarCodGestoraCadastrada()
        {
            List<Parameter> parametro = new List<Parameter>();
            parametro.Add(new Parameter("CodGestora", this.CodGestora.ToUpper(), ParameterTypes.Filter));
            parametro.Add(new Parameter("ID", this.ID, OperationTypes.NotIn));

            if (oDao.Select(parametro, "platinium", "VI_UNIDADE_ORCAMENTARIA_UNOR", typeof(UnidadeOrcamentaria)).Rows.Count != 0)
                throw new RegraNegocioException("Unidade Orçamentaria já cadastrada com o código informado!");
        }

        private void ValidarDescricaoCadastrada()
        {
            List<Parameter> parametro = new List<Parameter>();
            parametro.Add(new Parameter("Descricao", this.Descricao.ToUpper(), ParameterTypes.Filter));
            parametro.Add(new Parameter("ID", this.ID, OperationTypes.NotIn));

            if (oDao.Select(parametro, "platinium", "VI_UNIDADE_ORCAMENTARIA_UNOR", typeof(UnidadeOrcamentaria)).Rows.Count != 0)
                throw new RegraNegocioException("Unidade Orçamentaria já cadastrada com a descrição informada!");
        }

	#endregion

    }

}

