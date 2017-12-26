using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

using Pro.Utils;
using Pro.Dal;


namespace Platinium.Entidade
{
    [ClassAttribute(Schema = "platinium", Table = "TB_UNIDADE_UNID")]
    public class Unidade
    {
        #region Variáveis e Propriedades

        private Dao oDao;

        private int iID = 0;
        private DateTime? dDataCriado;
        private DateTime? dDataDesativado;
        private bool bAtivo;

        [PropertyAttribute(Field = "ID_UNIDADE_UNID", AllowNull = false, PropertyType = PropertyCategories.PrimaryKey, Variable = "iID")]
        public int ID
        {
            get { return iID; }
        }

        [PropertyAttribute(Field = "COD_UNIDADE", AllowNull = false,Description="Código", PropertyType = PropertyCategories.Field)]
        public string Codigo
        {
            get;
            set;
        }
        [PropertyAttribute(Field = "DSC_UNIDADE", AllowNull = false,Description="Descrição", PropertyType = PropertyCategories.Field)]
        public string DescricaoUnidade
        {
            get;
            set;
        }

        [PropertyAttribute(Field = "DAT_CRIADO", Description = "Data de criação", AllowNull = true, PropertyType = PropertyCategories.Field)]
        public DateTime? DataCriacao
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
        [PropertyAttribute(Field = "DSC_SIGLA", AllowNull = true,Description="Sigla", PropertyType = PropertyCategories.Field)]
        public String DescricaoSigla
        {
            get;
            set;
        }

        [PropertyAttribute(Field = "FLG_ATIVO", AllowNull = false,Description="Ativo", PropertyType = PropertyCategories.Field, DataType = DataTypes.Char)]
        public bool FlagAtivo
        {
            get { return bAtivo; }
            set { bAtivo = value; }
        }
      

        #endregion

        #region Construtores
        public Unidade() { }
		public Unidade(Dao dao)
		{
			oDao = dao;
		}

        public Unidade(int id, Dao dao)
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
                this.DataCriacao = DateTime.Now;

            this.DataDesativado = null;

            if (!this.FlagAtivo) this.DataDesativado = DateTime.Now;
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

            if (oDao.Select(parametro, "platinium", "TB_UNIDADE_UNID", typeof(Unidade)).Rows.Count != 0)
                throw new RegraNegocioException("Unidade já cadastrada com o código informado.");
        }

        private void ValidarDescricaoCadastrado()
        {
            List<Parameter> parametro = new List<Parameter>();
            parametro.Add(new Parameter("DescricaoUnidade", this.DescricaoUnidade.ToUpper(), ParameterTypes.Filter));
            parametro.Add(new Parameter("ID", this.ID, OperationTypes.NotIn));

            if (oDao.Select(parametro, "platinium", "TB_UNIDADE_UNID", typeof(Unidade)).Rows.Count != 0)
                throw new RegraNegocioException("Unidade já cadastrada com a descrição informada.");
        }


        #endregion
    }
}
