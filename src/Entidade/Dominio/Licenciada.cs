using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using Pro.Utils;
using Pro.Dal;
using Neonium.Entidade;


namespace Platinium.Entidade
{
    [ClassAttribute(Schema = "platinium", Table = "TB_LICENCIADA_LICE")]
    public class Licenciada
    {
        #region Variáveis e Propriedades

        private Dao oDao;

        private int iID = 0;
        private int? iIdEndereco;
        private Endereco oEndereco;

        [PropertyAttribute(Field = "ID_LICENCIADA", AllowNull = false, PropertyType = PropertyCategories.PrimaryKey, Variable = "iID")]
        public int ID
        {
            get { return iID; }
        }

        [PropertyAttribute(Field = "DSC_LICENCIADA", AllowNull = false, Description="Descrição", PropertyType = PropertyCategories.Field, Size=255)]
        public string Descricao
        {
            get;
            set;
        }

        [PropertyAttribute(Field = "COD_MUNICIPIO", AllowNull = false, Description = "Código do Município", PropertyType = PropertyCategories.Field, Size = 3)]
        public string CodigoMunicipio
        {
            get;
            set;
        }

        [PropertyAttribute(Field = "CNPJ_LICENCIADA", AllowNull = false, Description = "CNPJ", PropertyType = PropertyCategories.Field, Size = 50)]
        public string Cnpj
        {
            get;
            set;
        }

        [PropertyAttribute(Field = "TELEFONE_LICENCIADA", AllowNull = false, Description = "Telefone", PropertyType = PropertyCategories.Field, Size = 50)]
        public string Telefone
        {
            get;
            set;
        }

        [PropertyAttribute(Field = "ESTADO_LICENCIADA", AllowNull = false, Description = "Estado", PropertyType = PropertyCategories.Field, Size = 50)]
        public string Estado
        {
            get;
            set;
        }

        [PropertyAttribute(Field = "EMAIL_LICENCIADA", AllowNull = false, Description = "Email", PropertyType = PropertyCategories.Field, Size = 50)]
        public string Email
        {
            get;
            set;
        }

        [PropertyAttribute(Field = "CONTATO_LICENCIADA", AllowNull = false, Description = "Contato", PropertyType = PropertyCategories.Field, Size = 50)]
        public string Contato
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

        #endregion

        #region Construtores

        public Licenciada()
        {
            oDao = new Dao();
            object id = oDao.SelectSingleValue("SELECT MAX(ID_LICENCIADA) FROM PLATINIUM.TB_LICENCIADA_LICE");
            if (id != DBNull.Value)
            {
                List<Parameter> prm = new List<Parameter>();
                prm.Add(new Parameter("ID", (int)id, ParameterTypes.Filter));

                oDao.Load(this, prm);
            }
        }

	#endregion

        #region Métodos

        //public CrudActionTypes Salvar()
        //{
        //    Validar();
        //    ValidarCadastrado();
        //    if (iID == 0)
        //        return oDao.Insert(this);
        //    else
        //        return oDao.Update(this);
        //}

        public CrudActionTypes Salvar()
        {
            Validar();
            if (iID == 0)
            {
                CrudActionTypes oCrudActionTypes = oDao.Insert(this);
                return oCrudActionTypes;
            }
            else
            {
                CrudActionTypes oCrudActionTypes = oDao.Update(this);
                return oCrudActionTypes;
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
