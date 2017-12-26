
using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

using Pro.Utils;
using Pro.Dal;


namespace Platinium.Entidade
{
    [ClassAttribute(Schema = "platinium", Table = "TB_RECEITA_RECE")]
    public class Receita
    {
        #region Variáveis e Propriedades

        private Dao oDao;
        private int iID = 0;
        private DateTime? dDataCriado;
        private DateTime? dDataDesativado;
        private int? iIdCatEconomica;
        private EconomicaDeReceita oCatEconomica;
        private int? iIdOrigemReceita;
        private OrigemReceita oOrigemReceita;
        private int? iIdEspecie;
        private Especie oEspecie;
        private int? iIdRubricaReceita;
        private RubricaReceita oRubricaReceita;
        private bool bAtivo;

        [PropertyAttribute(Field = "ID_RECEITA_RECE", AllowNull = false, PropertyType = PropertyCategories.PrimaryKey, Variable = "iID")]
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

        [PropertyAttribute(Field = "DAT_DESATIVADO", Description = "Data de desativação", AllowNull = true, PropertyType = PropertyCategories.Field)]
        public DateTime? DataDesativado
        {
            get { return dDataDesativado; }
            set { dDataDesativado = value; }
        }

        [PropertyAttribute(Field = "COD_RECEITA", AllowNull = false, Description="Código", PropertyType = PropertyCategories.Field)]
        public string Codigo
        {
            get;
            set;
        }
        [PropertyAttribute(Field = "DSC_RECEITA", AllowNull = false, Description="Descrição", PropertyType = PropertyCategories.Field)]
        public string Descricao
        {
            get;
            set;
        }

        [PropertyAttribute(Field = "FK_CAT_ECONOMICA_RECE", AllowNull = false, Description = "Categoria econômica de receita", PropertyType = PropertyCategories.ForeignKey, Variable = "iIdCatEconomica")]
        public EconomicaDeReceita CatEconomica
        {
            get
            {
                if (oCatEconomica == null && iIdCatEconomica != null)
                    oCatEconomica = new EconomicaDeReceita((int)iIdCatEconomica, oDao);
                return oCatEconomica;
            }
            set
            {
                oCatEconomica = value;
                iIdCatEconomica = oCatEconomica.ID;
            }
        }

        [PropertyAttribute(Field = "FK_ORIGEM_ORIG", AllowNull = false, Description = "Origem de receita", PropertyType = PropertyCategories.ForeignKey, Variable = "iIdOrigemReceita")]
        public OrigemReceita OrigemReceita
        {
            get
            {
                if (oOrigemReceita == null && iIdOrigemReceita != null)
                    oOrigemReceita = new OrigemReceita((int)iIdOrigemReceita, oDao);
                return oOrigemReceita;
            }
            set
            {
                oOrigemReceita = value;
                iIdOrigemReceita = oOrigemReceita.ID;
            }
        }

        [PropertyAttribute(Field = "FK_ESPECIE_ESPE", AllowNull = false, Description = "Espécie", PropertyType = PropertyCategories.ForeignKey, Variable = "iIdEspecie")]
        public Especie Especie
        {
            get
            {
                if (oEspecie == null && iIdEspecie != null)
                    oEspecie = new Especie((int)iIdEspecie, oDao);
                return oEspecie;
            }
            set
            {
                oEspecie = value;
                iIdEspecie = oEspecie.ID;
            }
        }

        [PropertyAttribute(Field = "FK_RUBRICA_RUBR", AllowNull = false, Description = "Rubrica Receita", PropertyType = PropertyCategories.ForeignKey, Variable = "iIdRubricaReceita")]
        public RubricaReceita RubricaReceita
        {
            get
            {
                if (oRubricaReceita == null && iIdRubricaReceita != null)
                    oRubricaReceita = new RubricaReceita((int)iIdRubricaReceita, oDao);
                return oRubricaReceita;
            }
            set
            {
                oRubricaReceita = value;
                iIdRubricaReceita = oRubricaReceita.ID;
            }
        }

        [PropertyAttribute(Field = "FLG_ATIVO", AllowNull = true, PropertyType = PropertyCategories.Field, DataType = DataTypes.Char)]
        public bool Ativo
        {
            get { return bAtivo; }
            set { bAtivo = value; }
        }

        #endregion

        #region Construtores
        public Receita() { }
		public Receita(Dao dao)
		{
			oDao = dao;
		}

        public Receita(int id, Dao dao)
		{
			List<Parameter> parametro = new List<Parameter>();
            parametro.Add(new Parameter("ID", id, ParameterTypes.Filter));
			oDao = dao;
            oDao.Load(this, parametro);
		}

        public Receita(string codigo, Dao dao)
        {
            List<Parameter> parametro = new List<Parameter>();
            parametro.Add(new Parameter("Codigo", codigo, ParameterTypes.Filter));
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
            //ValidarDescricaoCadastrado();

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
            {
                if (Codigo.Length < 8)
                    ex.Mensagens.Add(Codigo, "O campo <b>Código</b> é de preenchimento obrigatório.");
                throw ex;
            }
        }

        private void ValidarCodigoCadastrado()
        {
            List<Parameter> parametro = new List<Parameter>();
            parametro.Add(new Parameter("Codigo", this.Codigo.ToUpper(), ParameterTypes.Filter));
            parametro.Add(new Parameter("ID", this.ID, OperationTypes.NotIn));

            if (oDao.Select(parametro, "platinium", "VI_RECEITA_RECE", typeof(Receita)).Rows.Count != 0)
                throw new RegraNegocioException("Receita já cadastrada com o código informado");
        }

        //private void ValidarDescricaoCadastrado()
        //{
        //    List<Parameter> parametro = new List<Parameter>();
        //    parametro.Add(new Parameter("Descricao", this.Descricao.ToUpper(), ParameterTypes.Filter));
        //    parametro.Add(new Parameter("ID", this.ID, OperationTypes.NotIn));

        //    if (oDao.Select(parametro, "platinium", "TB_RECEITA_RECE", typeof(Receita)).Rows.Count != 0)
        //        throw new RegraNegocioException("Receita já cadastrada com a descrição informada");
        //}
        

        #endregion
    }
}
