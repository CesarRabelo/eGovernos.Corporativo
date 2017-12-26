using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using Platinium.Entidade;
using Pro.Utils;
using Pro.Dal;
using Neonium.Entidade;


namespace Platinium.Entidade 
{
    [ClassAttribute(Schema = "plutonium", Table = "TB_PESSOAL_PESS")]
    public class Pessoal
    {

        #region Variáveis e Propriedades

        private Dao oDao;

        private int iID = 0;
        private DateTime? dDataCriado;
        private DateTime? dDataDesativado;
        private DateTime? dDataNascimento;
        private DateTime? dDataIdentidadeExpedicao;
        private bool bAtivo;
        private int? iIdCargo;
        private Cargo oCargo;
        private int? iIdTipoPisPasep;
        private TipoPisPasep oTipoPisPasep;
        private int? iIdEstadoCivil;
        private EstadoCivil oEstadoCivil;
        private int? iIdGrauInstrucao;
        private GrauInstrucao oGrauInstrucao;
        private int? iIdSexo;
        private Sexo oSexo;
        private int? iIdEndereco;
        private Endereco oEndereco;

        [PropertyAttribute(Field = "ID_PESSOAL", AllowNull = false, PropertyType = PropertyCategories.PrimaryKey, Variable = "iID")]
        public int ID
        {
            get { return iID; }
        }
        
        [PropertyAttribute(Field = "DSC_NOME", Description = "Nome", AllowNull = false, PropertyType = PropertyCategories.Field)]
        public string DescricaoNome
        {
            get;
            set;
        }

        [PropertyAttribute(Field = "DAT_NASCIMENTO", Description = "Data de nascimento", AllowNull = false, PropertyType = PropertyCategories.Field)]
        public DateTime? DataNascimento
        {
            get { return dDataNascimento; }
            set { dDataNascimento = value; }
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
        
        [PropertyAttribute(Field = "DAT_CRIADO", Description = "Data de criação", AllowNull = false, PropertyType = PropertyCategories.Field)]
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

        [PropertyAttribute(Field = "FLG_ATIVO", AllowNull = true, PropertyType = PropertyCategories.Field, DataType = DataTypes.Char)]
        public bool Ativo
        {
            get { return bAtivo; }
            set { bAtivo = value; }
        }

        [PropertyAttribute(Field = "NUM_CPF", Description = "CPF", AllowNull = false, PropertyType = PropertyCategories.Field)]
        public string Cpf
        {
            get;
            set;
        }

        [PropertyAttribute(Field = "FK_TIPO_PIS_PASEP", AllowNull = true, Description = "PIS/PASEP", PropertyType = PropertyCategories.ForeignKey, Variable = "iIdTipoPisPasep")]
        public TipoPisPasep TipoPisPasep
        {
            get
            {
                if (oTipoPisPasep == null && iIdTipoPisPasep != null)
                    oTipoPisPasep = new TipoPisPasep((int)iIdTipoPisPasep, oDao);
                return oTipoPisPasep;
            }
            set
            {
                oTipoPisPasep = value;
                iIdTipoPisPasep = oTipoPisPasep.ID;
            }
        }

        [PropertyAttribute(Field = "NUM_PIS_PASEP", Description = "Número Pis/Pasep", AllowNull = true, PropertyType = PropertyCategories.Field)]
        public string PisPasep
        {
            get;
            set;
        }

        [PropertyAttribute(Field = "NUM_IDENTIDADE", Description = "Número Identidade", AllowNull = true, PropertyType = PropertyCategories.Field)]
        public string Identidade
        {
            get;
            set;
        }

        [PropertyAttribute(Field = "DSC_IDENTIDADE_EXPEDIDOR", Description = "Expedidor da identidade", AllowNull = true, PropertyType = PropertyCategories.Field)]
        public string IdentidadeExpedidor
        {
            get;
            set;
        }

        [PropertyAttribute(Field = "DAT_IDENTIDADE_EXPEDICAO", Description = "Data de expedição da identidade", AllowNull = true, PropertyType = PropertyCategories.Field)]
        public DateTime? DataIdentidadeExpedicao
        {
            get { return dDataIdentidadeExpedicao; }
            set { dDataIdentidadeExpedicao = value; }
        }

        [PropertyAttribute(Field = "NUM_TITULO_ELEITOR", Description = "Número do Titulo de eleitor", AllowNull = true, PropertyType = PropertyCategories.Field)]
        public string TituloEleitor
        {
            get;
            set;
        }

        [PropertyAttribute(Field = "FK_ESTADO_CIVIL", AllowNull = false, Description = "Estado Civil", PropertyType = PropertyCategories.ForeignKey, Variable = "iIdEstadoCivil")]
        public EstadoCivil EstadoCivil
        {
            get
            {
                if (oEstadoCivil == null && iIdEstadoCivil != null)
                    oEstadoCivil = new EstadoCivil((int)iIdEstadoCivil, oDao);
                return oEstadoCivil;
            }
            set
            {
                oEstadoCivil = value;
                iIdEstadoCivil = oEstadoCivil.ID;
            }
        }

        [PropertyAttribute(Field = "FK_GRAU_INSTRUCAO", AllowNull = true, Description = "Grau de instrução", PropertyType = PropertyCategories.ForeignKey, Variable = "iIdGrauInstrucao")]
        public GrauInstrucao GrauInstrucao
        {
            get
            {
                if (oGrauInstrucao == null && iIdGrauInstrucao != null)
                    oGrauInstrucao = new GrauInstrucao((int)iIdGrauInstrucao, oDao);
                return oGrauInstrucao;
            }
            set
            {
                oGrauInstrucao = value;
                iIdGrauInstrucao = oGrauInstrucao.ID;
            }
        }

        [PropertyAttribute(Field = "FK_SEXO", AllowNull = false, Description = "Sexo", PropertyType = PropertyCategories.ForeignKey, Variable = "iIdSexo")]
        public Sexo Sexo
        {
            get
            {
                if (oSexo == null && iIdSexo != null)
                    oSexo = new Sexo((int)iIdSexo, oDao);
                return oSexo;
            }
            set
            {
                oSexo = value;
                iIdSexo = oSexo.ID;
            }
        }

        [PropertyAttribute(Field = "DSC_NOME_MAE", Description = "Nome da mãe", AllowNull = false, PropertyType = PropertyCategories.Field)]
        public string NomeMae
        {
            get;
            set;
        }

        [PropertyAttribute(Field = "DSC_NOME_PAI", Description = "Nome da mãe", AllowNull = true, PropertyType = PropertyCategories.Field)]
        public string NomePai
        {
            get;
            set;
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

        [PropertyAttribute(Field = "NUM_TELEFONE", Description = "Telefone", AllowNull = true, PropertyType = PropertyCategories.Field)]
        public string Telefone
        {
            get;
            set;
        }

        [PropertyAttribute(Field = "NUM_DEPENDENTES", Description = "Número de dependentes", AllowNull = true, PropertyType = PropertyCategories.Field)]
        public int Dependentes
        {
            get;
            set;
        }


        #endregion

        #region Construtores
        public Pessoal() { }
        public Pessoal(Dao dao)
        {
            oDao = dao;
        }

        public Pessoal(int id, Dao dao)
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
            ValidacaoCpf();
            ValidarCpfCadastrado();
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
            ManipularDatas();
            CampoNuloOuInvalidoException ex = new CampoNuloOuInvalidoException();
            ex.Mensagens = Pro.Utils.ClassFunctions.ValidateRules(this);

            return ex;
        }

        private void ValidacaoCpf()
        {         
            if (!Pro.Utils.Validacoes.ValidarCpf(this.Cpf))
                throw new ViolacaoRegraException("CPF inválido, informe um CPF correto.");
        }

        private void ValidarCpfCadastrado()
        {
            List<Parameter> parametro = new List<Parameter>();
            parametro.Add(new Parameter("Cpf", this.Cpf, OperationTypes.EqualsTo));
            parametro.Add(new Parameter("ID", this.ID, OperationTypes.NotIn));

            if (oDao.Select(parametro, "plutonium", "TB_PESSOAL_PESS", typeof(Pessoal)).Rows.Count != 0)
                throw new RegraNegocioException("Campo já cadastrado com o Cpf informado.");
        }

        #endregion

    }

}

