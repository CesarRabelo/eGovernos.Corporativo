
using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using Pro.Utils;
using Pro.Dal;


namespace Platinium.Entidade
{
    [ClassAttribute(Schema = "platinium", Table = "TB_LOCALIDADE_LOCA")]
    public class Localidade
    {
        #region Variáveis e Propriedades

        private Dao oDao;

        private int iID = 0;
        private int? iIdRegiao;
        private Regiao oRegiao;
        private DateTime? dDataCriado;
        private DateTime? dDataDesativado;
        private bool bAtivo;

        [PropertyAttribute(Field = "ID_LOCALIDADE_LOCA", AllowNull = false, PropertyType = PropertyCategories.PrimaryKey, Variable = "iID")]
        public int ID
        {
            get { return iID; }
        }

        [PropertyAttribute(Field = "FK_REGIAO_REGI", AllowNull = false, Description = "Região", PropertyType = PropertyCategories.ForeignKey, Variable = "iIdRegiao")]
        public Regiao Regiao
        {
            get
            {
                if (oRegiao == null && iIdRegiao != null)
                    oRegiao = new Regiao((int)iIdRegiao, oDao);
                return oRegiao;
            }
            set
            {
                oRegiao = value;
                iIdRegiao = oRegiao.ID;
            }
        }

        [PropertyAttribute(Field = "COD_LOCALIDADE", Description = "Código", AllowNull = false, PropertyType = PropertyCategories.Field, Size = 7)]
        public string Codigo
        {
            get;
            set;
        }

        [PropertyAttribute(Field = "COD_MICROREGIAO", Description = "Microregião", AllowNull = false, PropertyType = PropertyCategories.Field, Size = 10)]
        public string Microregiao
        {
            get;
            set;
        }

        [PropertyAttribute(Field = "COD_TERRITORIO", Description = "Território", AllowNull = false, PropertyType = PropertyCategories.Field, Size = 2)]
        public string Territorio
        {
            get;
            set;
        }

        [PropertyAttribute(Field = "DSC_LOCALIDADE", Description = "Descrição", AllowNull = false, PropertyType = PropertyCategories.Field, Size = 255)]
        public string Descricao
        {
            get;
            set;
        }

        [PropertyAttribute(Field = "DAT_CRIADO", Description="Data de criação", AllowNull = false, PropertyType = PropertyCategories.Field)]
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

        [PropertyAttribute(Field = "FLG_ATIVO", AllowNull = false, PropertyType = PropertyCategories.Field, DataType = DataTypes.Char, Size = 1)]
        public bool Ativo
        {
            get { return bAtivo; }
            set { bAtivo = value; }
        }

        #endregion

        #region Construtores
        public Localidade() { }
		public Localidade(Dao dao)
		{
			oDao = dao;
		}

        public Localidade(int id, Dao dao)
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
            ValidarCodigoCadastrado();
            ValidarDescricaoCadastrado();

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
        private void ValidarCodigoCadastrado()
        {
            List<Parameter> parametro = new List<Parameter>();
            parametro.Add(new Parameter("Codigo", this.Codigo.ToUpper(), ParameterTypes.Filter));
            parametro.Add(new Parameter("ID", this.ID, OperationTypes.NotIn));

            if (oDao.Select(parametro, "platinium", "TB_LOCALIDADE_LOCA", typeof(Localidade)).Rows.Count != 0)
                throw new RegraNegocioException("Localidade já cadastrada com o código informado");
        }

        private void ValidarDescricaoCadastrado()
        {
            List<Parameter> parametro = new List<Parameter>();
            parametro.Add(new Parameter("Descricao", this.Descricao.ToUpper(), ParameterTypes.Filter));
            parametro.Add(new Parameter("ID", this.ID, OperationTypes.NotIn));

            if (oDao.Select(parametro, "platinium", "TB_LOCALIDADE_LOCA", typeof(Localidade)).Rows.Count != 0)
                throw new RegraNegocioException("Localidade já cadastrada com a descrição informado");
        }

        #endregion
    }
}

