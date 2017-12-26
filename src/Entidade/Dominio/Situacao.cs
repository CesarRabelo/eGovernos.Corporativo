using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

using Pro.Utils;
using Pro.Dal;


namespace Platinium.Entidade
{
    [ClassAttribute(Schema = "platinium", Table = "TB_SITUACAO_SITU")]
    public class Situacao
    {
        #region Variáveis e Propriedades

        private Dao oDao;
        private int iID = 0;
        private bool bAtivo;

        [PropertyAttribute(Field = "ID_SITUACAO_SITU", AllowNull = false, PropertyType = PropertyCategories.PrimaryKey, Variable = "iID")]
        public int ID
        {
            get { return iID; }
        }

        [PropertyAttribute(Field = "COD_SITUACAO", AllowNull = false, Description="Código", PropertyType = PropertyCategories.Field, Size = 2)]
        public string Codigo
        {
            get;
            set;
        }
        [PropertyAttribute(Field = "DSC_SITUACAO", AllowNull = false, Description="Descrição" ,PropertyType = PropertyCategories.Field, Size = 255)]
        public string Descricao
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
        public Situacao() { }
		public Situacao(Dao dao)
		{
			oDao = dao;
		}

        public Situacao(int id, Dao dao)
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

            Validar();
            ValidarCodigoCadastrado();
            ValidarDescricaoCadastrado();

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
        private void ValidarCodigoCadastrado()
        {
            List<Parameter> parametro = new List<Parameter>();
            parametro.Add(new Parameter("Codigo", this.Codigo.ToUpper(), ParameterTypes.Filter));
            parametro.Add(new Parameter("ID", this.ID, OperationTypes.NotIn));

            if (oDao.Select(parametro, "platinium", "TB_SITUACAO_SITU", typeof(Situacao)).Rows.Count != 0)
                throw new RegraNegocioException("Situação já cadastrada com o código informado");
        }

        private void ValidarDescricaoCadastrado()
        {
            List<Parameter> parametro = new List<Parameter>();
            parametro.Add(new Parameter("Descricao", this.Descricao.ToUpper(), ParameterTypes.Filter));
            parametro.Add(new Parameter("ID", this.ID, OperationTypes.NotIn));

            if (oDao.Select(parametro, "platinium", "TB_SITUACAO_SITU", typeof(Situacao)).Rows.Count != 0)
                throw new RegraNegocioException("Situação já cadastrada com a descrição informada");
        }

        #endregion
    }
}
