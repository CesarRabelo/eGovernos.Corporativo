
using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using Platinium.Entidade;
using Pro.Utils;
using Pro.Dal;
using Neonium.Entidade;
using Platinium.Entidade;


namespace Platinium.Entidade 
{
    [ClassAttribute(Schema = "plutonium", Table = "TB_AGENTE_PUBLICO_AGPU")]
    public class AgentePublico
    {

        #region Variáveis e Propriedades

        private Dao oDao;

        private int iID = 0;
        private DateTime? dDataPublicacaoNomeacao;
        private bool bAtivo;
        private DateTime? dDataAmparoLegal;
        private DateTime? dDataPosse;
        private DateTime? dDataCriado;
        private DateTime? dDataDesativado;
        private DateTime? dDataNomeacao;
        private int? iIdUnidadeOrcamentaria;
        private UnidadeOrcamentaria oUnidadeOrcamentaria;
        private int? iIdPessoal;
        private Pessoal oPessoal;
        private int? iIdFormaIngresso;
        private FormaIngresso oFormaIngresso;
        private int? iIdTipoRelacao;
        private TipoRelacao oTipoRelacao;
        private int? iIdTipoExpediente;
        private TipoExpediente oTipoExpediente;
        private int? iIdTipoAmparo;
        private TipoAmparo oTipoAmparo;
        private int? iIdSituacaoFuncional;
        private SituacaoFuncional oSituacaoFuncional;
        private int? iIdRegimeJuridico;
        private RegimeJuridico oRegimeJuridico;
        private int? iIdRegimePrevidenciario;
        private RegimePrevidenciario oRegimePrevidenciario;
        private int? iIdCargo;
        private Cargo oCargo;
        

        [PropertyAttribute(Field = "ID_AGENTE_PUBLICO", AllowNull = false, PropertyType = PropertyCategories.PrimaryKey, Variable = "iID")]
        public int ID
        {
            get { return iID; }
        }

        [PropertyAttribute(Field = "FK_UNIDADE_ORCAMENTARIA", AllowNull = false, Description = "Unidade Orçamentaria", PropertyType = PropertyCategories.ForeignKey, Variable = "iIdUnidadeOrcamentaria")]
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

        [PropertyAttribute(Field = "FK_PESSOAL", AllowNull = false, Description = "Pessoal", PropertyType = PropertyCategories.ForeignKey, Variable = "iIdPessoal")]
        public Pessoal Pessoal
        {
            get
            {
                if (oPessoal == null && iIdPessoal != null)
                    oPessoal = new Pessoal((int)iIdPessoal, oDao);
                return oPessoal;
            }
            set
            {
                oPessoal = value;
                iIdPessoal = oPessoal.ID;
            }
        }

        [PropertyAttribute(Field = "NUM_EXPEDIENTE_NOMEACAO", Description = "Expediente Nomeação", AllowNull = true, PropertyType = PropertyCategories.Field)]
        public string ExpedienteNomeacao
        {
            get;
            set;
        }

        [PropertyAttribute(Field = "FK_FORMA_INGRESSO", AllowNull = false, Description = "Forma de ingresso", PropertyType = PropertyCategories.ForeignKey, Variable = "iIdFormaIngresso")]
        public FormaIngresso FormaIngresso
        {
            get
            {
                if (oFormaIngresso == null && iIdFormaIngresso != null)
                    oFormaIngresso = new FormaIngresso((int)iIdFormaIngresso, oDao);
                return oFormaIngresso;
            }
            set
            {
                oFormaIngresso = value;
                iIdFormaIngresso = oFormaIngresso.ID;
            }
        }

        [PropertyAttribute(Field = "FK_TIPO_RELACAO", AllowNull = true, Description = "Tipo de Relação", PropertyType = PropertyCategories.ForeignKey, Variable = "iIdTipoRelacao")]
        public TipoRelacao TipoRelacao
        {
            get
            {
                if (oTipoRelacao == null && iIdTipoRelacao != null)
                    oTipoRelacao = new TipoRelacao((int)iIdTipoRelacao, oDao);
                return oTipoRelacao;
            }
            set
            {
                oTipoRelacao = value;
                iIdTipoRelacao = oTipoRelacao.ID;
            }
        }

        [PropertyAttribute(Field = "FK_TIPO_EXPEDIENTE", AllowNull = false, Description = "Tipo de Nomeação", PropertyType = PropertyCategories.ForeignKey, Variable = "iIdTipoExpediente")]
        public TipoExpediente TipoExpediente
        {
            get
            {
                if (oTipoExpediente == null && iIdTipoExpediente != null)
                    oTipoExpediente = new TipoExpediente((int)iIdTipoExpediente, oDao);
                return oTipoExpediente;
            }
            set
            {
                oTipoExpediente = value;
                iIdTipoExpediente = oTipoRelacao.ID;
            }
        }

        [PropertyAttribute(Field = "DAT_NOMEACAO", Description = "Data de nomeação", AllowNull = true, PropertyType = PropertyCategories.Field)]
        public DateTime? DataNomeacao
        {
            get { return dDataNomeacao; }
            set { dDataNomeacao = value; }
        }

        [PropertyAttribute(Field = "FK_TIPO_AMPARO_LEGAL", AllowNull = true, Description = "Tipo de amparo legal", PropertyType = PropertyCategories.ForeignKey, Variable = "iIdTipoAmparo")]
        public TipoAmparo TipoAmparo
        {
            get
            {
                if (oTipoAmparo == null && iIdTipoAmparo != null)
                    oTipoAmparo = new TipoAmparo((int)iIdTipoAmparo, oDao);
                return oTipoAmparo;
            }
            set
            {
                oTipoAmparo = value;
                iIdTipoAmparo = oTipoAmparo.ID;
            }
        }

        [PropertyAttribute(Field = "NUM_AMPARO_LEGAL", Description = "Número Amparo Legal", AllowNull = true, PropertyType = PropertyCategories.Field)]
        public string NumAmparoLegal
        {
            get;
            set;
        }

        [PropertyAttribute(Field = "DAT_AMPARO_LEGAL", Description = "Data Amparo Legal", AllowNull = true, PropertyType = PropertyCategories.Field)]
        public DateTime? DataAmparoLegal
        {
            get { return dDataAmparoLegal; }
            set { dDataAmparoLegal = value; }
        }

        [PropertyAttribute(Field = "DAT_PUBLICACAO_NOMEACAO", Description = "Data de publicação da nomeação", AllowNull = false, PropertyType = PropertyCategories.Field)]
        public DateTime? DataPublicacaoNomeacao
        {
            get { return dDataPublicacaoNomeacao; }
            set { dDataPublicacaoNomeacao = value; }
        }

        [PropertyAttribute(Field = "DAT_POSSE", Description = "Data da posse", AllowNull = true, PropertyType = PropertyCategories.Field)]
        public DateTime? DataPosse
        {
            get { return dDataPosse; }
            set { dDataPosse = value; }
        }

        [PropertyAttribute(Field = "NUM_MATRICULA_MUNICIPAL", Description = "Número da matrícula municipal", AllowNull = true, PropertyType = PropertyCategories.Field)]
        public string NumMatriculaMunicipal
        {
            get;
            set;
        }

        [PropertyAttribute(Field = "FK_SITUACAO_FUNCIONAL", AllowNull = true, Description = "Situação Funcional", PropertyType = PropertyCategories.ForeignKey, Variable = "iIdSituacaoFuncional")]
        public SituacaoFuncional SituacaoFuncional
        {
            get
            {
                if (oSituacaoFuncional == null && iIdSituacaoFuncional != null)
                    oSituacaoFuncional = new SituacaoFuncional((int)iIdSituacaoFuncional, oDao);
                return oSituacaoFuncional;
            }
            set
            {
                oSituacaoFuncional = value;
                iIdSituacaoFuncional = oSituacaoFuncional.ID;
            }
        }

        [PropertyAttribute(Field = "FK_REGIME_JURIDICO", AllowNull = true, Description = "Regime Jurídico", PropertyType = PropertyCategories.ForeignKey, Variable = "iIdRegimeJuridico")]
        public RegimeJuridico RegimeJuridico
        {
            get
            {
                if (oRegimeJuridico == null && iIdRegimeJuridico != null)
                    oRegimeJuridico = new RegimeJuridico((int)iIdRegimeJuridico, oDao);
                return oRegimeJuridico;
            }
            set
            {
                oRegimeJuridico = value;
                iIdRegimeJuridico = oRegimeJuridico.ID;
            }
        }

        [PropertyAttribute(Field = "FK_REGIME_PREVIDENCIARIO", AllowNull = true, Description = "Regime Previdenciario", PropertyType = PropertyCategories.ForeignKey, Variable = "iIdRegimePrevidenciario")]
        public RegimePrevidenciario RegimePrevidenciario
        {
            get
            {
                if (oRegimePrevidenciario == null && iIdRegimePrevidenciario != null)
                    oRegimePrevidenciario = new RegimePrevidenciario((int)iIdRegimePrevidenciario, oDao);
                return oRegimePrevidenciario;
            }
            set
            {
                oRegimePrevidenciario = value;
                iIdRegimePrevidenciario = oRegimePrevidenciario.ID;
            }
        }

        [PropertyAttribute(Field = "FK_CARGO", AllowNull = true, Description = "Cargo", PropertyType = PropertyCategories.ForeignKey, Variable = "iIdCargo")]
        public Cargo Cargo
        {
            get
            {
                if (oCargo == null && iIdCargo != null)
                    oCargo = new Cargo((int)iIdCargo, oDao);
                return oCargo;
            }
            set
            {
                oCargo = value;
                iIdCargo = oCargo.ID;
            }
        }

        [PropertyAttribute(Field = "NUM_CARGA_HORARIA_SEMANAL", Description = "Carga Horária semanal", AllowNull = true, PropertyType = PropertyCategories.Field)]
        public int NumCargaHorariaSemanal
        {
            get;
            set;
        }

        [PropertyAttribute(Field = "FLG_ATIVO", AllowNull = true, PropertyType = PropertyCategories.Field, DataType = DataTypes.Char)]
        public bool Ativo
        {
            get { return bAtivo; }
            set { bAtivo = value; }
        }

        [PropertyAttribute(Field = "DAT_CRIADO", Description = "Data de criação", AllowNull = true, PropertyType = PropertyCategories.Field)]
        public DateTime? DataCriado
        {
            get { return dDataCriado; }
            set { dDataCriado = value; }
        }

        [PropertyAttribute(Field = "DAT_DESATIVADO", Description = "Data de desativação", AllowNull = true, PropertyType = PropertyCategories.Field)]
        public DateTime? DataDesativado
        {
            get { return dDataDesativado; }
            set { dDataDesativado = value; }
        }

        #endregion

        #region Construtores
        public AgentePublico() { }
        public AgentePublico(Dao dao)
        {
            oDao = dao;
        }

        public AgentePublico(int id, Dao dao)
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

        public CampoNuloOuInvalidoException ValidarExterno()
        {
            CampoNuloOuInvalidoException ex = new CampoNuloOuInvalidoException();
            ex.Mensagens = Pro.Utils.ClassFunctions.ValidateRules(this);

            return ex;
        }

        #endregion

    }

}

