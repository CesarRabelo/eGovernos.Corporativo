using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using Platinium.Entidade;

using Pro.Utils;
using Pro.Dal;
using Plutonium.Entidade;


namespace Platinium.Entidade
{
    [ClassAttribute(Schema = "platinium", Table = "TB_UNIDADE_GESTORA_ORDENADOR_UNGO")]
    public class UnidadeGestoraOrdenador
    {
        #region Variáveis e Propriedades

        private Dao oDao;

        private int iID = 0;
        private int? iIdUnidadeGestora;
        private UnidadeGestora oUnidadeGestora;
        private int? iIdOrdenador;
        private Pessoal oOrdenador;
        private DateTime? dDataCriado;
        private DateTime? dDataDesativado;
        private DateTime? dDataInicio;
        private DateTime? dDataFim;
        private bool bAtivo;


        [PropertyAttribute(Field = "ID_ORDENADOR_DESPESA", AllowNull = false, PropertyType = PropertyCategories.PrimaryKey, Variable = "iID")]
        public int ID
        {
            get { return iID; }
        }

        [PropertyAttribute(Field = "FK_UNIDADE_GESTORA", AllowNull = false, Description = "Unidade Gestora", PropertyType = PropertyCategories.ForeignKey, Variable = "iIdUnidadeGestora")]
        public UnidadeGestora UnidadeGestora
        {
            get
            {
                if (oUnidadeGestora == null && iIdUnidadeGestora != null)
                    oUnidadeGestora = new UnidadeGestora((int)iIdUnidadeGestora, oDao);
                return oUnidadeGestora;
            }
            set
            {
                oUnidadeGestora = value;
                iIdUnidadeGestora = oUnidadeGestora.ID;
            }
        }

        [PropertyAttribute(Field = "FK_ORDENADOR", AllowNull = false, Description = "Ordenador", PropertyType = PropertyCategories.ForeignKey, Variable = "iIdOrdenador")]
        public Pessoal Ordenador
        {
            get
            {
                if (oOrdenador == null && iIdOrdenador != null)
                    oOrdenador = new Pessoal((int)iIdOrdenador, oDao);
                return oOrdenador;
            }
            set
            {
                oOrdenador = value;
                iIdOrdenador = oOrdenador.ID;
            }
        }

        [PropertyAttribute(Field = "DAT_INICIO", Description = "Início da Gestão", AllowNull = false, PropertyType = PropertyCategories.Field)]
        public DateTime? DataInicio
        {
            get { return dDataInicio; }
            set { dDataInicio = value; }
        }

        [PropertyAttribute(Field = "DAT_FIM", Description = "Data Final", AllowNull = true, PropertyType = PropertyCategories.Field)]
        public DateTime? DataFim
        {
            get { return dDataFim; }
            set { dDataFim = value; }
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

        [PropertyAttribute(Field = "FLG_ATIVO", AllowNull = false, PropertyType = PropertyCategories.Field, DataType = DataTypes.Char, Size = 1)]
        public bool Ativo
        {
            get { return bAtivo; }
            set { bAtivo = value; }
        }

        #endregion

        #region Construtores
        public UnidadeGestoraOrdenador() { }
        public UnidadeGestoraOrdenador(Dao dao)
        {
            oDao = dao;
        }

        public UnidadeGestoraOrdenador(int id, Dao dao)
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


        #endregion
    }
}
