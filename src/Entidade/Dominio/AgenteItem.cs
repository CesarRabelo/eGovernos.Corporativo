using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using Pro.Utils;
using Pro.Dal;
using Platinium.Entidade;

namespace Platinium.Entidade
{
    [ClassAttribute(Schema = "plutonium", Table = "TB_AGENTE_ITEM_REMUNERATORIO_AGIR")]
    public class AgenteItem
    {
        #region Variáveis e Propriedades

        private Dao oDao;
        private int iID = 0;
        private bool bAtivo;
        private DateTime? dDataCriado;
        private DateTime? dDataDesativado;
        private DateTime? dDataExpedienteConcessao;
        private DateTime? dDataExpedienteConcessaoPublicacao;
        private DateTime? dDataExpedienteSuspensao;
        private DateTime? dDataExpedienteSuspensaoPublicacao;
        private int? iIdAgentePublico;
        private AgentePublico oAgentePublico;
        private int? iIdItemRemuneratorio;
        private ItemRemuneratorio oItemRemuneratorio;
        private int? iIdTipoExpediente;
        private TipoExpediente oTipoExpediente;
        private int? iIdTipoExpedienteSuspensao;
        private TipoExpediente oTipoExpedienteSuspensao;

        [PropertyAttribute(Field = "ID_AGENTE_ITEM_REMUNERATORIO", AllowNull = false, PropertyType = PropertyCategories.PrimaryKey, Variable = "iID")]
        public int ID
        {
            get { return iID; }
        }

        [PropertyAttribute(Field = "FK_AGENTE_PUBLICO", Description = "Agente Público", AllowNull = false, PropertyType = PropertyCategories.ForeignKey, Variable = "iIdAgentePublico")]
        public AgentePublico AgentePublico
        {
            get
            {
                if (oAgentePublico == null && iIdAgentePublico != null)
                    oAgentePublico = new AgentePublico((int)iIdAgentePublico, oDao);
                return oAgentePublico;
            }
            set
            {
                oAgentePublico = value;
                iIdAgentePublico = oAgentePublico.ID;
            }
        }

        [PropertyAttribute(Field = "FK_ITEM_REMUNERATORIO", AllowNull = false, PropertyType = PropertyCategories.ForeignKey, Variable = "iIdItemRemuneratorio")]
        public ItemRemuneratorio ItemRemuneratorio
        {
            get
            {
                if (oItemRemuneratorio == null && iIdItemRemuneratorio != null)
                    oItemRemuneratorio = new ItemRemuneratorio((int)iIdItemRemuneratorio, oDao);
                return oItemRemuneratorio;
            }
            set
            {
                oItemRemuneratorio = value;
                iIdItemRemuneratorio = oItemRemuneratorio.ID;
            }
        }

        [PropertyAttribute(Field = "NUM_EXPEDIENTE_CONCESSAO", AllowNull = false, Description = "Número Expediente", PropertyType = PropertyCategories.Field)]
        public string NumeroExpediente
        {
            get;
            set;
        }

        [PropertyAttribute(Field = "FK_TIPO_EXPEDIENTE_CONCESSAO", AllowNull = false, PropertyType = PropertyCategories.ForeignKey, Variable = "iIdTipoExpediente")]
        public TipoExpediente TipoExpediente
        {
            get
            {
                if (oTipoExpediente == null && iIdTipoExpediente != null)
                    oTipoExpediente = new TipoExpediente((int)iIdTipoExpediente, oDao);
                return oTipoExpediente;
            }
            set
            {
                oTipoExpediente = value;
                iIdTipoExpediente = oTipoExpediente.ID;
            }
        }

        [PropertyAttribute(Field = "DAT_EXPEDIENTE_CONCESSAO", Description = "Data de expediente de concessão", AllowNull = false, PropertyType = PropertyCategories.Field)]
        public DateTime? DataExpedienteConcessao
        {
            get { return dDataExpedienteConcessao; }
            set { dDataExpedienteConcessao = value; }
        }

        [PropertyAttribute(Field = "DAT_EXPEDIENTE_CONCESSAO_PUBLICACAO", Description = "Data expediente de concessão da publicação", AllowNull = false, PropertyType = PropertyCategories.Field)]
        public DateTime? DataExpedienteConcessaoPublicacao
        {
            get { return dDataExpedienteConcessaoPublicacao; }
            set { dDataExpedienteConcessaoPublicacao = value; }
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

        [PropertyAttribute(Field = "FLG_ATIVO", AllowNull = false, PropertyType = PropertyCategories.Field, DataType = DataTypes.Char)]
        public bool Ativo
        {
            get { return bAtivo; }
            set { bAtivo = value; }
        }

        [PropertyAttribute(Field = "NUM_EXPEDIENTE_SUSPENSAO", AllowNull = true, Description = "Número Expediente de suspensão", PropertyType = PropertyCategories.Field)]
        public string NumeroExpedienteSuspensao
        {
            get;
            set;
        }

        [PropertyAttribute(Field = "FK_TIPO_EXPEDIENTE_SUSPENSAO", AllowNull = true, PropertyType = PropertyCategories.ForeignKey, Variable = "iIdTipoExpedienteSuspensao")]
        public TipoExpediente TipoExpedienteSuspensao
        {
            get
            {
                if (oTipoExpedienteSuspensao == null && iIdTipoExpedienteSuspensao != null)
                    oTipoExpedienteSuspensao = new TipoExpediente((int)iIdTipoExpedienteSuspensao, oDao);
                return oTipoExpedienteSuspensao;
            }
            set
            {
                oTipoExpedienteSuspensao = value;
                iIdTipoExpedienteSuspensao = oTipoExpedienteSuspensao.ID;
            }
        }

        [PropertyAttribute(Field = "DAT_EXPEDIENTE_SUSPENSAO", Description = "Data de expediente de suspensão", AllowNull = true, PropertyType = PropertyCategories.Field)]
        public DateTime? DataExpedienteSuspensao
        {
            get { return dDataExpedienteSuspensao; }
            set { dDataExpedienteSuspensao = value; }
        }

        [PropertyAttribute(Field = "DAT_EXPEDIENTE_SUSPENSAO_PUBLICACAO", Description = "Data expediente de suspensão da publicação", AllowNull = true, PropertyType = PropertyCategories.Field)]
        public DateTime? DataExpedienteSuspensaoPublicacao
        {
            get { return dDataExpedienteSuspensaoPublicacao; }
            set { dDataExpedienteSuspensaoPublicacao = value; }
        }

        #endregion

        #region Construtores
        public AgenteItem() { }
        public AgenteItem(Dao dao)
        {
            oDao = dao;
        }

        public AgenteItem(int id, Dao dao)
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

            Ativo = DataExpedienteSuspensao == null;

            if (this.ID <= 0 && Ativo == false)
                ValidarItensCadastrados();

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

        public CampoNuloOuInvalidoException ValidarExterno()
        {
            CampoNuloOuInvalidoException ex = new CampoNuloOuInvalidoException();
            ex.Mensagens = Pro.Utils.ClassFunctions.ValidateRules(this);
            return ex;
        }

        public bool ValidarItensCadastrados()
        {
            List<Parameter> parametro = new List<Parameter>();

            parametro.Add(new Parameter("ItemRemuneratorio", this.ItemRemuneratorio.ID, OperationTypes.EqualsTo));
            parametro.Add(new Parameter("AgentePublico", this.AgentePublico.ID, OperationTypes.EqualsTo));

            DataTable dt = oDao.Select(parametro, "plutonium", "TB_AGENTE_ITEM_REMUNERATORIO_AGIR", typeof(AgenteItem));
            if (dt.Rows.Count != 0)
                return true;
            return false;
        }

        public bool ValidarItensCadastrados(string s)
        {
            List<Parameter> parametro = new List<Parameter>();

            parametro.Add(new Parameter("ItemRemuneratorio", this.ItemRemuneratorio.ID, OperationTypes.EqualsTo));
            parametro.Add(new Parameter("AgentePublico", this.AgentePublico.ID, OperationTypes.EqualsTo));
            parametro.Add(new Parameter("Ativo",s, OperationTypes.EqualsTo));

            DataTable dt = oDao.Select(parametro, "plutonium", "TB_AGENTE_ITEM_REMUNERATORIO_AGIR", typeof(AgenteItem));
            if (dt.Rows.Count != 0)
                return true;
            return false;
        }

        #endregion

        
    }
}
