using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

using Pro.Utils;
using Pro.Dal;
using Neonium.Entidade;
  


namespace Platinium.Entidade
{
    [ClassAttribute(Schema = "platinium", Table = "TB_ENTIDADE_LEI_ENLE")]
    public class EntidadeLei
    {

    #region Variáveis e Propriedades

        private Dao oDao;

        private int iID = 0;
        private DateTime? dDataCriado;
        private DateTime? dDataInicio;
        private DateTime? dDataExtinsao;
        private int? iIdEntidade;
        private Entidade oEntidade;
        private DateTime? dDataDesativado;
        private bool bAtivo;

        [PropertyAttribute(Field = "ID_ENTIDADE_LEI", AllowNull = false, PropertyType = PropertyCategories.PrimaryKey, Variable = "iID")]
        public int ID
        {
            get { return iID; }
        }

        [PropertyAttribute(Field = "FK_ENTIDADE", AllowNull = false, Description = "Entidade", PropertyType = PropertyCategories.ForeignKey, Variable = "iIdEntidade")]
        public Entidade Entidade
        {
            get
            {
                if (oEntidade == null && iIdEntidade != null)
                    oEntidade = new Entidade((int)iIdEntidade, oDao);
                return oEntidade;
            }
            set
            {
                oEntidade = value;
                iIdEntidade = oEntidade.ID;
            }
        }

        [PropertyAttribute(Field = "DSC_LEI", Description = "Descrição", AllowNull = false, PropertyType = PropertyCategories.Field)]
        public string Descricao
        {
            get;
            set;
        }

        [PropertyAttribute(Field = "DAT_CRIADO", Description = "Data de criação", AllowNull = false, PropertyType = PropertyCategories.Field)]
        public DateTime? DataCriado
        {
            get { return dDataCriado; }
            set { dDataCriado = value; }
        }

        [PropertyAttribute(Field = "DAT_INICIO", Description = "Data de início", AllowNull = false, PropertyType = PropertyCategories.Field)]
        public DateTime? DataInicio
        {
            get { return dDataInicio; }
            set { dDataInicio = value; }
        }
                
        [PropertyAttribute(Field = "DAT_TERMINO", Description = "Data de término", AllowNull = true, PropertyType = PropertyCategories.Field)]
        public DateTime? DataTermino
        {
            get { return dDataExtinsao; }
            set { dDataExtinsao = value; }
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
        public EntidadeLei() { }
		public EntidadeLei(Dao dao)
		{
			oDao = dao;
		}

        public EntidadeLei(int id, Dao dao)
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

	#endregion

    }

}

