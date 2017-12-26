using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

using Pro.Utils;
using Pro.Dal;


namespace Platinium.Entidade
{
    [ClassAttribute(Schema = "platinium", Table = "TB_GRUPO_PROGRAMA_GRPR")]
    public class GrupoPrograma
    {
        #region Variáveis e Propriedades

        private Dao oDao;

        private int iID = 0;
        private DateTime? dDataCriado;
        private DateTime? dDataDesativado;
        private int? iIdIpoPrograma;
        private bool bAtivo;
        private int? iIdTipoPrograma;
        private TipoPrograma oTipoPrograma;

        [PropertyAttribute(Field = "ID_GRUPO_PROGRAMA_GRPR", AllowNull = false, PropertyType = PropertyCategories.PrimaryKey, Variable = "iID")]
        public int ID
        {
            get { return iID; }
        }

        [PropertyAttribute(Field = "COD_GRUPO_PROGRAMA", Description="Código", AllowNull = false, PropertyType = PropertyCategories.Field, Size = 2)]
        public string Codigo
        {
            get;
            set;
        }

        [PropertyAttribute(Field = "DSC_GRUPO_PROGRAMA", Description="Descrição", AllowNull = false, PropertyType = PropertyCategories.Field, Size = 200)]
        public string Descricao
        {
            get;
            set;
        }

        [PropertyAttribute(Field = "ID_TIPO_PROGRAMA_TIPR", AllowNull = false, Description = "Tipo Programa", PropertyType = PropertyCategories.ForeignKey, Variable = "iIdTipoPrograma")]
        public TipoPrograma TipoPrograma
        {
            get
            {
                if (oTipoPrograma == null && iIdTipoPrograma != null)
                    oTipoPrograma = new TipoPrograma((int)iIdTipoPrograma, oDao);
                return oTipoPrograma;
            }
            set
            {
                oTipoPrograma = value;
                iIdTipoPrograma = oTipoPrograma.ID;
            }
        }

        [PropertyAttribute(Field = "DAT_CRIADO", Description="Data de criação", AllowNull = false, PropertyType = PropertyCategories.Field)]
        public DateTime? DataCriado
        {
            get { return dDataCriado; }
            set { dDataCriado = value; }
        }

        [PropertyAttribute(Field = "DAT_DESATIVADO", Description="Data de desativação", AllowNull = true, PropertyType = PropertyCategories.Field)]
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
        public GrupoPrograma() { }
		public GrupoPrograma(Dao dao)
		{
			oDao = dao;
		}

        public GrupoPrograma(int id, Dao dao)
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
            ValidarDescricaoCadastrado();
            ValidarCodigoCadastrado();

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

            if (oDao.Select(parametro, "platinium", "TB_GRUPO_PROGRAMA_GRPR", typeof(GrupoPrograma)).Rows.Count != 0)
                throw new RegraNegocioException("Grupo programa já cadastrado com o código informado");
        }

        private void ValidarDescricaoCadastrado()
        {
            List<Parameter> parametro = new List<Parameter>();
            parametro.Add(new Parameter("Descricao", this.Descricao.ToUpper(), ParameterTypes.Filter));
            parametro.Add(new Parameter("ID", this.ID, OperationTypes.NotIn));

            if (oDao.Select(parametro, "platinium", "TB_GRUPO_PROGRAMA_GRPR", typeof(GrupoPrograma)).Rows.Count != 0)
                throw new RegraNegocioException("Grupo programa já cadastrado com a descrição informada");
        }

        #endregion
    }
}
