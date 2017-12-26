using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

using Pro.Utils;
using Pro.Dal;


namespace Platinium.Entidade
{
    [ClassAttribute(Schema = "platinium", Table = "TB_IDUSO")]
    public class Iduso
    {
        #region Variáveis e Propriedades

        private Dao oDao;
        private int iID = 0;

        [PropertyAttribute(Field = "ID_IDUSO", AllowNull = false, PropertyType = PropertyCategories.PrimaryKey, Variable = "iID")]
        public int ID
        {
            get { return iID; }
        }

        [PropertyAttribute(Field = "COD_IDUSO", AllowNull = false, Description="Código", PropertyType = PropertyCategories.Field)]
        public string Codigo
        {
            get;
            set;
        }
        [PropertyAttribute(Field = "DSC_IDUSO", AllowNull = false, Description="Descrição", PropertyType = PropertyCategories.Field)]
        public string Descricao
        {
            get;
            set;
        }
        #endregion

        #region Construtores
        public Iduso() { }
		public Iduso(Dao dao)
		{
			oDao = dao;
		}

        public Iduso(int id, Dao dao)
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

            if (oDao.Select(parametro, "platinium", "TB_IDUSO", typeof(Iduso)).Rows.Count != 0)
                throw new RegraNegocioException("Iduso já cadastrada com o código informado");
        }

        private void ValidarDescricaoCadastrado()
        {
            List<Parameter> parametro = new List<Parameter>();
            parametro.Add(new Parameter("Descricao", this.Descricao.ToUpper(), ParameterTypes.Filter));
            parametro.Add(new Parameter("ID", this.ID, OperationTypes.NotIn));

            if (oDao.Select(parametro, "platinium", "TB_IDUSO", typeof(Iduso)).Rows.Count != 0)
                throw new RegraNegocioException("Iduso já cadastrada com a descrição informada");
        }
        

        #endregion
    }
}
