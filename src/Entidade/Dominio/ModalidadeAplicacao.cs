using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

using Pro.Utils;
using Pro.Dal;


namespace Platinium.Entidade
{
    [ClassAttribute(Schema = "platinium", Table = "TB_MODALIDADE_APLICACAO_MOAP")]
    public class ModalidadeAplicacao
    {

    #region Variáveis e Propriedades

        private Dao oDao;

        private int iID = 0;
        private DateTime? DthCriado;
        private DateTime? DthDesativado;
        private bool sAtivo;

        [PropertyAttribute(Field = "ID_MODALIDADE_APLICACAO_MOAP", AllowNull = false, PropertyType = PropertyCategories.PrimaryKey, Variable = "iID")]
        public int ID
        {
            get { return iID; }
        }

        [PropertyAttribute(Field = "DAT_CRIADO", AllowNull = false, Description = "Data de criação", PropertyType = PropertyCategories.Field)]
        public DateTime? DataCriado
        {
            get { return DthCriado; }
            set { DthCriado = value; }
        }

        [PropertyAttribute(Field = "DAT_DESATIVADO", Description = "Data de desativação", AllowNull = true, PropertyType = PropertyCategories.Field)]
        public DateTime? DataDesativado
        {
            get { return DthDesativado; }
            set { DthDesativado = value; }
        }

        [PropertyAttribute(Field = "COD_MODALIDADE_APLICACAO_MOAP", AllowNull = false, Description = "Código", PropertyType = PropertyCategories.Field, Size = 2)]
        public string Codigo
        {
            get;
            set;
        }

        [PropertyAttribute(Field = "DSC_MODALIDADE_APLICACAO_MOAP", Description = "Descrição", AllowNull = false, PropertyType = PropertyCategories.Field, Size = 255)]
        public string Descricao
        {
            get;
            set;
        }

        [PropertyAttribute(Field = "FLG_ATIVO", AllowNull = false, PropertyType = PropertyCategories.Field, Size = 1, DataType = DataTypes.Char)]
        public bool Ativo
        {
            get { return sAtivo; }
            set { sAtivo = value; }
        }

    #endregion

    #region Construtores
        public ModalidadeAplicacao() { }
		public ModalidadeAplicacao(Dao dao)
		{
			oDao = dao;
		}

        public ModalidadeAplicacao(int id, Dao dao)
		{
			List<Parameter> parametro = new List<Parameter>();
            parametro.Add(new Parameter("ID", id, ParameterTypes.Filter));
			oDao = dao;
            oDao.Load(this, parametro);
		}

        public ModalidadeAplicacao(string codigo, Dao dao)
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
            ValidarDuplicidade();

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

        private void ValidarDuplicidade()
        {
            ValidarCodigoCadastrada();

            ValidarDescricaoCadastrada();
        }

        private void ValidarCodigoCadastrada()
        {
            List<Parameter> parametro = new List<Parameter>();
            parametro.Add(new Parameter("Codigo", this.Codigo.ToUpper(), ParameterTypes.Filter));
            parametro.Add(new Parameter("ID", this.ID, OperationTypes.NotIn));

            if (oDao.Select(parametro, "platinium", "TB_MODALIDADE_APLICACAO_MOAP", typeof(ModalidadeAplicacao)).Rows.Count != 0)
                throw new RegraNegocioException("Modalidade já cadastrada com o código informado!");
        }

        private void ValidarDescricaoCadastrada()
        {
            List<Parameter> parametro = new List<Parameter>();
            parametro.Add(new Parameter("Descricao", this.Descricao.ToUpper(), ParameterTypes.Filter));
            parametro.Add(new Parameter("ID", this.ID, OperationTypes.NotIn));

            if (oDao.Select(parametro, "platinium", "TB_MODALIDADE_APLICACAO_MOAP", typeof(ModalidadeAplicacao)).Rows.Count != 0)
                throw new RegraNegocioException("Modalidade já cadastrada com a descrição informada!");
        }

	#endregion

    }

}

