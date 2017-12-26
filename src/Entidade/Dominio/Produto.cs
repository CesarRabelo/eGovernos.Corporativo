using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

using Pro.Utils;
using Pro.Dal;


namespace Platinium.Entidade
{
    [ClassAttribute(Schema = "platinium", Table = "TB_PRODUTO_PROD")]
    public class Produto
    {
        #region Variáveis e Propriedades

        private Dao oDao;
        private int? iIdUnidade;
        private Unidade oUnidade;
        private int iID = 0;
        private DateTime? dDataCriado;
        private DateTime? dDataDesativado;
        private bool bAtivo;

        [PropertyAttribute(Field = "ID_PRODUTO_PROD", AllowNull = false, PropertyType = PropertyCategories.PrimaryKey, Variable = "iID")]
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

        [PropertyAttribute(Field = "COD_PRODUTO", AllowNull = false, Description = "Código", PropertyType = PropertyCategories.Field, Size = 4)]
        public string Codigo
        {
            get;
            set;
        }
        [PropertyAttribute(Field = "DSC_PRODUTO", AllowNull = false, Description = "Descrição", PropertyType = PropertyCategories.Field)]
        public string Descricao
        {
            get;
            set;
        }
        [PropertyAttribute(Field = "FK_UNIDADE_UNID", AllowNull = false, Description = "Unidade", PropertyType = PropertyCategories.ForeignKey, Variable = "iIdUnidade")]
        public Unidade Unidade
        {
            get
            {
                if (oUnidade == null && iIdUnidade != null)
                    oUnidade = new Unidade((int)iIdUnidade, oDao);
                return oUnidade;
            }
            set
            {
                oUnidade = value;
                iIdUnidade = oUnidade.ID;
            }
        }

        [PropertyAttribute(Field = "FLG_ATIVO", AllowNull = false, PropertyType = PropertyCategories.Field, DataType = DataTypes.Char, Size = 1)]
        public bool Ativo
        {
            get { return bAtivo; }
            set { bAtivo = value; }
        }

        #endregion

        #region Construtores
        public Produto() { }
        public Produto(Dao dao)
        {
            oDao = dao;
        }

        public Produto(int id, Dao dao)
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
            if (iID == 0 && string.IsNullOrEmpty(Codigo))
                this.Codigo = Convert.ToString(MaxCodigoProduto() + 1);
            ManipularDatas();
            Validar();
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

        private void ValidarDescricaoCadastrado()
        {
            List<Parameter> parametro = new List<Parameter>();
            parametro.Add(new Parameter("Descricao", this.Descricao.ToUpper(), ParameterTypes.Filter));
            parametro.Add(new Parameter("ID", this.ID, OperationTypes.NotIn));

            if (oDao.Select(parametro, "platinium", "TB_PRODUTO_PROD", typeof(Produto)).Rows.Count != 0)
                throw new RegraNegocioException("Produto já cadastrado com a descrição informada");
        }
        private int MaxCodigoProduto()
        {
            List<Parameter> parametro = new List<Parameter>();
            return Convert.ToInt32(oDao.Select(parametro, "platinium", "VI_MAX_PRODUTO", new Dictionary<string, string>()).Rows[0][0].ToString());
        }

        #endregion
    }
}
