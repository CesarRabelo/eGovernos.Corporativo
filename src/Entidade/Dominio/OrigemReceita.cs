using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

using Pro.Utils;
using Pro.Dal;


namespace Platinium.Entidade
{
    [ClassAttribute(Schema = "platinium", Table = "TB_RECEITA_RECE")]
    public class OrigemReceita
    {
        #region Variáveis e Propriedades

        private Dao oDao;

        private int iID = 0;
        private int? iIdEconomicaDeReceita;
        private EconomicaDeReceita oEconomicaDeReceita;
        private DateTime? dDataCriado;
        private DateTime? dDataDesativado;
        private bool bAtivo;

        [PropertyAttribute(Field = "ID_RECEITA_RECE", AllowNull = false, PropertyType = PropertyCategories.PrimaryKey, Variable = "iID")]
        public int ID
        {
            get { return iID; }
        }

        [PropertyAttribute(Field = "COD_RECEITA", Description = "Código", AllowNull = false, PropertyType = PropertyCategories.Field)]
        public string Codigo
        {
            get;
            set;
        }
        
        [PropertyAttribute(Field = "DSC_RECEITA", AllowNull = false, PropertyType = PropertyCategories.Field)]
        public string Descricao
        {
            get;
            set;
        }
        
        [PropertyAttribute(Field = "FK_CAT_ECONOMICA_RECE", AllowNull = false, Description = "Categoria Econômica", PropertyType = PropertyCategories.ForeignKey, Variable = "iIdEconomicaDeReceita")]
        public EconomicaDeReceita CategoriaEconomica
        {
            get
            {
                if (oEconomicaDeReceita == null && iIdEconomicaDeReceita != null)
                    oEconomicaDeReceita = new EconomicaDeReceita((int)iIdEconomicaDeReceita, oDao);
                return oEconomicaDeReceita;
            }
            set
            {
                oEconomicaDeReceita = value;
                iIdEconomicaDeReceita = oEconomicaDeReceita.ID;
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

        [PropertyAttribute(Field = "FLG_ATIVO", AllowNull = false, PropertyType = PropertyCategories.Field, DataType = DataTypes.Char)]
        public bool Ativo
        {
            get { return bAtivo; }
            set { bAtivo = value; }
        }

        #endregion

        #region Construtores
        public OrigemReceita() { }
        public OrigemReceita(Dao dao)
        {
            oDao = dao;
        }

        public OrigemReceita(int id, Dao dao)
        {
            List<Parameter> parametro = new List<Parameter>();
            parametro.Add(new Parameter("ID", id, ParameterTypes.Filter));
            oDao = dao;
            oDao.Load(this, parametro);
        }

        public OrigemReceita(string codigo, Dao dao)
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
            ValidarDescricaoCadastrado();
            ValidarCodigoCadastrado();
            ValidarCodigoExistente();
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



        public void ValidarCodigoExistente()
        {
            string codigo = this.Codigo.Substring(0, 1) + "0000000";
            List<Parameter> parametro = new List<Parameter>();
            parametro.Add(new Parameter("Codigo", codigo, OperationTypes.EqualsTo));

            if (oDao.Select(parametro, "platinium", "TB_RECEITA_RECE", typeof(OrigemReceita)).Rows.Count == 0)
                throw new RegraNegocioException(string.Format("Categoria econômica não localizada com o código [{0}].", codigo));
        }

        private void Validar()
        {
            CampoNuloOuInvalidoException ex = new CampoNuloOuInvalidoException();
            ex.Mensagens = Pro.Utils.ClassFunctions.ValidateRules(this);
            if (Codigo.Length < 8)
                ex.Mensagens.Add(Codigo, "O campo <b>Código</b> é de preenchimento obrigatório.");
            if (ex.Mensagens.Count > 0)
                throw ex;
        }

        private void ValidarCodigoCadastrado()
        {
            List<Parameter> parametro = new List<Parameter>();
            parametro.Add(new Parameter("Codigo", this.Codigo.ToUpper(), ParameterTypes.Filter));
            parametro.Add(new Parameter("ID", this.ID, OperationTypes.NotIn));

            if (oDao.Select(parametro, "platinium", "VI_ORIGEM_ORIG", typeof(OrigemReceita)).Rows.Count != 0)
                throw new RegraNegocioException("Origem Receita já cadastrada com o código informado");
        }

        private void ValidarDescricaoCadastrado()
        {
            List<Parameter> parametro = new List<Parameter>();
            parametro.Add(new Parameter("Descricao", this.Descricao.ToUpper(), ParameterTypes.Filter));
            parametro.Add(new Parameter("ID", this.ID, OperationTypes.NotIn));

            if (oDao.Select(parametro, "platinium", "VI_ORIGEM_ORIG", typeof(OrigemReceita)).Rows.Count != 0)
                throw new RegraNegocioException("Origem Receita já cadastrada com a descrição informada");
        }

        #endregion
    }
}
