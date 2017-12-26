using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using Pro.Utils;
using Pro.Dal;
using Platinium.Entidade;


namespace Platinium.Entidade
{

    [ClassAttribute(Schema = "platinium", Table = "TB_CONFIGURACAO_CONF")]
    public class Configuracao
    {
        #region Variáveis e Propriedades

        private Dao oDao;

        private int? iIdSecretaria;
        private Secretaria oSecretaria;
        private int? iIdPPA;
        private PPA oPPA;
        private int iID = 0;

        [PropertyAttribute(Field = "ID_CONFIGURACAO", AllowNull = false, PropertyType = PropertyCategories.PrimaryKey, Variable = "iID")]
        public int ID
        {
            get { return iID; }
        }

        [PropertyAttribute(Field = "COD_MUNICIPIO", AllowNull = true, Description = "Código do Municipio", PropertyType = PropertyCategories.Field)]
        public string CodigoMunicipio
        {
            get;
            set;
        }

        [PropertyAttribute(Field = "DSC_NOME_RAZAO_SOCIAL", AllowNull = false, Description = "Razão Social", PropertyType = PropertyCategories.Field)]
        public string DescricaoRazaoSocial
        {
            get;
            set;
        }

        [PropertyAttribute(Field = "DSC_NOME_FANTASIA", AllowNull = true, Description = "Nome Fantasia", PropertyType = PropertyCategories.Field)]
        public string DescricaoNomeFantasia
        {
            get;
            set;
        }
        
        [PropertyAttribute(Field = "NUM_TELEFONE", AllowNull = true, Description = "Número do Telefone", PropertyType = PropertyCategories.Field)]
        public string NumeroTelefone
        {
            get;
            set;
        }
        
        [PropertyAttribute(Field = "NUM_FAX", AllowNull = true, Description = "Número do Fax", PropertyType = PropertyCategories.Field)]
        public string NumeroFax
        {
            get;
            set;
        }
        
        [PropertyAttribute(Field = "NUM_CNPJ", AllowNull = true, Description = "Número do CNPJ", PropertyType = PropertyCategories.Field)]
        public string NumeroCNPJ
        {
            get;
            set;
        }
        
        [PropertyAttribute(Field = "DSC_SITE", AllowNull = true, Description = "Site", PropertyType = PropertyCategories.Field)]
        public string DescricaoSite
        {
            get;
            set;
        }

        [PropertyAttribute(Field = "DSC_EMAIL", AllowNull = true, Description = "Email", PropertyType = PropertyCategories.Field)]
        public string DescricaoEmail
        {
            get;
            set;
        }

        [PropertyAttribute(Field = "FK_SECRETARIA", AllowNull = true, Description = "Secretaria", PropertyType = PropertyCategories.ForeignKey, Variable = "iIdSecretaria")]
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

        [PropertyAttribute(Field = "DSC_ESTADO", AllowNull = true, Description = "DescricaoEstado", PropertyType = PropertyCategories.Field)]
        public string DescricaoEstado
        {
            get;
            set;
        }

        [PropertyAttribute(Field = "CAM_LOGO_ESTADUAL", AllowNull = true, Description = "Logo Estadual", PropertyType = PropertyCategories.Field)]
        public string LogoEstadual
        {
            get;
            set;
        }

        [PropertyAttribute(Field = "FK_PPA_CORRENTE", AllowNull = true, Description = "PPA", PropertyType = PropertyCategories.ForeignKey, Variable = "iIdPPA")]
        public PPA PPA
        {
            get
            {
                if (oPPA == null && iIdPPA != null)
                    oPPA = new PPA((int)iIdPPA, oDao);
                return oPPA;
            }
            set
            {
                oPPA = value;
                iIdPPA = oPPA.ID;
            }
        }

        [PropertyAttribute(Field = "NUM_ANO_LOA", AllowNull = true, Description = "Número Ano Loa", PropertyType = PropertyCategories.Field)]
        public int NumeroAnoLoa
        {
            get;
            set;
        }

        #endregion

        #region Construtores

        public Configuracao()
        {
            oDao = new Dao();
            object id = oDao.SelectSingleValue("SELECT MAX(ID_CONFIGURACAO) FROM PLATINIUM.TB_CONFIGURACAO_CONF");
            if (id != DBNull.Value)
            {
                List<Parameter> prm = new List<Parameter>();
                prm.Add(new Parameter("ID", (int)id, ParameterTypes.Filter));

                oDao.Load(this, prm);
            }
        }

        #endregion

        #region Métodos

        public CrudActionTypes Salvar()
        {
            Validar();

            if (iID == 0)
                return oDao.Insert(this);
            else
                return oDao.Update(this);
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