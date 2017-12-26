using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using Platinium.Entidade;
using Pro.Utils;
using Pro.Dal;
using Plutonium.Entidade;


namespace Platinium.Entidade
{
    [ClassAttribute(Schema = "platinium", Table = "TB_RESPONSAVEL_ENVIO_ARQUIVO_REEA")]
    public class ResponsavelEnvioArquivo
    {
        #region Variáveis e Propriedades

        private Dao oDao;

        private int iID = 0;
        private int? iIdCargo;
        private Cargo oCargo;
        private DateTime? dDataCriado;
        private DateTime? dDataDesativado;
        private DateTime? dDataInicio;
        private DateTime? dDataFim;
        private bool bAtivo;

        [PropertyAttribute(Field = "ID_RESPONSAVEL_ENVIO_ARQUIVO", AllowNull = false, PropertyType = PropertyCategories.PrimaryKey, Variable = "iID")]
        public int ID
        {
            get { return iID; }
        }

        [PropertyAttribute(Field = "FK_CARGO_GESTOR", AllowNull = false, Description = "Cargo do Gestor", PropertyType = PropertyCategories.ForeignKey, Variable = "iIdCargo")]
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

        [PropertyAttribute(Field = "DAT_DESATIVADO", AllowNull = true, PropertyType = PropertyCategories.Field)]
        public DateTime? DataDesativado
        {
            get { return dDataDesativado; }
            set { dDataDesativado = value; }
        }


        [PropertyAttribute(Field = "DAT_INICIO", Description = "Data de Inicio", AllowNull = false, PropertyType = PropertyCategories.Field)]
        public DateTime? DataInicio
        {
            get { return dDataInicio; }
            set { dDataInicio = value; }
        }

        [PropertyAttribute(Field = "DAT_FIM", AllowNull = true, PropertyType = PropertyCategories.Field)]
        public DateTime? DataFim
        {
            get { return dDataFim; }
            set { dDataFim = value; }
        }
        
        [PropertyAttribute(Field = "DSC_CPF_GESTOR", AllowNull = false, Description = "CPF do Gestor", PropertyType = PropertyCategories.Field)]
        public string DscCpfGestor
        {
            get;
            set;
        }
        
        [PropertyAttribute(Field = "DSC_NOME_GESTOR", AllowNull = false, Description = "Nome do Gestor", PropertyType = PropertyCategories.Field)]
        public string DscNomeGestor
        {
            get;
            set;
        }
        
        [PropertyAttribute(Field = "DSC_CPF_CONTADOR", AllowNull = false, Description = "CPF do Contador", PropertyType = PropertyCategories.Field)]
        public string DscCpfContador
        {
            get;
            set;
        }
        
        [PropertyAttribute(Field = "DSC_CRC_CONTADOR", AllowNull = false, Description = "CRC do Contador", PropertyType = PropertyCategories.Field)]
        public string DscCrcContador
        {
            get;
            set;
        }
        
        [PropertyAttribute(Field = "DSC_NOME_CONTADOR", AllowNull = false, Description = "Nome do Contador", PropertyType = PropertyCategories.Field)]
        public string DscNomeContador
        {
            get;
            set;
        }
        
        [PropertyAttribute(Field = "DSC_CNPJ_EMPRESA_CONTABILIDADE", AllowNull = false, Description = "CNPJ da Empresa de Contabilidade", PropertyType = PropertyCategories.Field)]
        public string DscCnpjEmpresaContabilidade
        {
            get;
            set;
        }
        
        [PropertyAttribute(Field = "DSC_NOME_EMPRESA_CONTABILIDADE", AllowNull = false, Description = "Nome da Empresa de Contabilidade", PropertyType = PropertyCategories.Field)]
        public string DscNomeEmpresaContabilidade
        {
            get;
            set;
        }
        
        [PropertyAttribute(Field = "DSC_CPF_ASSESSOR_INFORMATICA", AllowNull = false, Description = "CPF do Assessor de Informática", PropertyType = PropertyCategories.Field)]
        public string DscCpfAssessorInformatica
        {
            get;
            set;
        }
        
        [PropertyAttribute(Field = "DSC_NOME_ASSESSOR_INFORMATICA", AllowNull = false, Description = "Nome do Assessor de Informática", PropertyType = PropertyCategories.Field)]
        public string DscNomeAssessorInformatica
        {
            get;
            set;
        }
        
        [PropertyAttribute(Field = "DSC_CNPJ_EMPRESA_INFORMATICA", AllowNull = false, Description = "CNPJ da Empresa de Informática", PropertyType = PropertyCategories.Field)]
        public string DscCnpjEmpresaInformatica
        {
            get;
            set;
        }
        
        [PropertyAttribute(Field = "DSC_NOME_EMPRESA_INFORMATICA", AllowNull = false, Description = "Nome da Empresa de Informática", PropertyType = PropertyCategories.Field)]
        public string DscNomeEmpresaInformatica
        {
            get;
            set;
        }

        [PropertyAttribute(Field = "FLG_ATIVO", AllowNull = false, PropertyType = PropertyCategories.Field, DataType = DataTypes.Char, Size = 1)]
        public bool Ativo
        {
            get { return bAtivo; }
            set { bAtivo = value; }
        }

        #endregion

        #region Construtores
        public ResponsavelEnvioArquivo() { }
        public ResponsavelEnvioArquivo(Dao dao)
        {
            oDao = dao;
        }

        public ResponsavelEnvioArquivo(int id, Dao dao)
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
        
            if (iID == 0)
                return oDao.Insert(this);
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
        
        #endregion
    }
}
