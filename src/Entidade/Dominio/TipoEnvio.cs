using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

using Pro.Utils;
using Pro.Dal;


namespace Platinium.Entidade
{
    [ClassAttribute(Schema = "platinium", Table = "TB_TIPO_ENVIO_TIEN")]
    public class TipoEnvio
    {
        #region Variáveis e Propriedades

        private Dao oDao;
        private int iID = 0;

        [PropertyAttribute(Field = "ID_TIPO_ENVIO", AllowNull = false, PropertyType = PropertyCategories.PrimaryKey, Variable = "iID")]
        public int ID
        {
            get { return iID; }
        }

        [PropertyAttribute(Field = "COD_TIPO_ENVIO", AllowNull = false, Description="Código", PropertyType = PropertyCategories.Field, Size = 2)]
        public string Codigo
        {
            get;
            set;
        }
        [PropertyAttribute(Field = "DSC_TIPO_ENVIO", AllowNull = false, Description="Descrição" ,PropertyType = PropertyCategories.Field, Size = 50)]
        public string Descricao
        {
            get;
            set;
        }

        #endregion

        #region Construtores
        public TipoEnvio() { }
        public TipoEnvio(Dao dao)
		{
			oDao = dao;
		}

        public TipoEnvio(int id, Dao dao)
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

            if (oDao.Select(parametro, "platinium", "TB_TIPO_ENVIO_TIEN", typeof(TipoEnvio)).Rows.Count != 0)
                throw new RegraNegocioException("Tipo de envio já cadastrado com o código informado");
        }

        private void ValidarDescricaoCadastrado()
        {
            List<Parameter> parametro = new List<Parameter>();
            parametro.Add(new Parameter("Descricao", this.Descricao.ToUpper(), ParameterTypes.Filter));
            parametro.Add(new Parameter("ID", this.ID, OperationTypes.NotIn));

            if (oDao.Select(parametro, "platinium", "TB_TIPO_ENVIO_TIEN", typeof(TipoEnvio)).Rows.Count != 0)
                throw new RegraNegocioException("Tipo de envio já cadastrado com a descrição informada");
        }

        #endregion
    }
}
