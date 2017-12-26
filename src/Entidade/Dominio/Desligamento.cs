using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using Pro.Utils;
using Pro.Dal;
using Platinium.Entidade;

namespace Platinium.Entidade
{
    [ClassAttribute(Schema = "plutonium", Table = "TB_DESLIGAMENTO_AGENTE_PUBLICO_DEAP")]
    public class Desligamento
    {
        #region Variáveis e Propriedades

        private Dao oDao;
        private int iID = 0;
        private bool bAtivo;
        private DateTime? dDataCriado;
        private DateTime? dDataDesativado;
        private DateTime? dDataExpediente;
        private DateTime? dDataPublicacao;
        private DateTime? dDataExpedienteReingresso;
        private DateTime? dDataPublicacaoReingresso;
        private DateTime? dDataAmparoLegal;
        private DateTime? dDataPublicacaoAmparoLegal;
        private int? iIdAgentePublico;
        private AgentePublico oAgentePublico;
        private int? iIdPensionista;
        private AgentePublico oPensionista;
        private int? iIdTipoDesligamento;
        private TipoDesligamento oTipoDesligamento;
        private int? iIdTipoExpediente;
        private TipoExpediente oTipoExpediente;
        private int? iIdTipoReingresso;
        private TipoReingresso oTipoReingresso;
        private int? iIdTipoExpedienteReingresso;
        private TipoExpediente oTipoExpedienteReingresso;
        private int? iIdTipoAmparo;
        private TipoAmparo oTipoAmparo;

        [PropertyAttribute(Field = "ID_DESLIGAMENTO_AGENTE_PUBLICO", AllowNull = false, PropertyType = PropertyCategories.PrimaryKey, Variable = "iID")]
        public int ID
        {
            get { return iID; }
        }

        [PropertyAttribute(Field = "FK_AGENTE_PUBLICO", Description="Agente Público", AllowNull = true, PropertyType = PropertyCategories.ForeignKey, Variable = "iIdAgentePublico")]
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

        #region Desligamento

        [PropertyAttribute(Field = "FK_TIPO_DESLIGAMENTO", AllowNull = true, PropertyType = PropertyCategories.ForeignKey, Variable = "iIdTipoDesligamento")]
        public TipoDesligamento TipoDesligamento
        {
            get
            {
                if (oTipoDesligamento == null && iIdTipoDesligamento != null)
                    oTipoDesligamento = new TipoDesligamento((int)iIdTipoDesligamento, oDao);
                return oTipoDesligamento;
            }
            set
            {
                oTipoDesligamento = value;
                iIdTipoDesligamento = oTipoDesligamento.ID;
            }
        }

        [PropertyAttribute(Field = "FK_TIPO_EXPEDIENTE", AllowNull = true, PropertyType = PropertyCategories.ForeignKey, Variable = "iIdTipoExpediente")]
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

        [PropertyAttribute(Field = "NUM_EXPEDIENTE", AllowNull = true, Description = "Número Expediente", PropertyType = PropertyCategories.Field)]
        public string NumeroExpediente
        {
            get;
            set;
        }

        [PropertyAttribute(Field = "DAT_EXPEDIENTE", Description = "Data de expediente", AllowNull = true, PropertyType = PropertyCategories.Field)]
        public DateTime? DataExpediente
        {
            get { return dDataExpediente; }
            set { dDataExpediente = value; }
        }

        [PropertyAttribute(Field = "DAT_PUBLICACAO", Description = "Data de Publicação", AllowNull = true, PropertyType = PropertyCategories.Field)]
        public DateTime? DataPublicacao
        {
            get { return dDataPublicacao; }
            set { dDataPublicacao = value; }
        }

        [PropertyAttribute(Field = "FK_PENSIONISTA", Description = "Pensionista", AllowNull = true, PropertyType = PropertyCategories.ForeignKey, Variable = "iIdPensionista")]
        public AgentePublico Pensionista
        {
            get
            {
                if (oPensionista == null && iIdPensionista != null)
                    oPensionista = new AgentePublico((int)iIdPensionista, oDao);
                return oPensionista;
            }
            set
            {
                oPensionista = value;
                iIdPensionista = oPensionista.ID;
            }
        }
        #endregion

        #region Reingresso

        [PropertyAttribute(Field = "NUM_EXPEDIENTE_REINGRESSO", AllowNull = true, Description = "Número Expediente de Reingressão", PropertyType = PropertyCategories.Field)]
        public string NumeroExpedienteReingresso
        {
            get;
            set;
        }

        [PropertyAttribute(Field = "FK_TIPO_REINGRESSO", AllowNull = true, PropertyType = PropertyCategories.ForeignKey, Variable = "iIdTipoReingresso")]
        public TipoReingresso TipoReingresso
        {
            get
            {
                if (oTipoReingresso == null && iIdTipoReingresso != null)
                    oTipoReingresso = new TipoReingresso((int)iIdTipoReingresso, oDao);
                return oTipoReingresso;
            }
            set
            {
                oTipoReingresso = value;
                iIdTipoReingresso = oTipoReingresso.ID;
            }
        }

        [PropertyAttribute(Field = "FK_TIPO_EXPEDIENTE_REINGRESSO", AllowNull = true, PropertyType = PropertyCategories.ForeignKey, Variable = "iIdTipoExpedienteReingresso")]
        public TipoExpediente TipoExpedienteReingresso
        {
            get
            {
                if (oTipoExpedienteReingresso == null && iIdTipoExpedienteReingresso != null)
                    oTipoExpedienteReingresso = new TipoExpediente((int)iIdTipoExpedienteReingresso, oDao);
                return oTipoExpedienteReingresso;
            }
            set
            {
                oTipoExpedienteReingresso = value;
                iIdTipoExpedienteReingresso = oTipoExpedienteReingresso.ID;
            }
        }

        

        [PropertyAttribute(Field = "DAT_EXPEDIENTE_REINGRESSO", Description = "Data de expediente", AllowNull = true, PropertyType = PropertyCategories.Field)]
        public DateTime? DataExpedienteReingresso
        {
            get { return dDataExpedienteReingresso; }
            set { dDataExpedienteReingresso = value; }
        }

        [PropertyAttribute(Field = "DAT_PUBLICACAO_REINGRESSO", Description = "Data de Publicação", AllowNull = true, PropertyType = PropertyCategories.Field)]
        public DateTime? DataPublicacaoReingresso
        {
            get { return dDataPublicacaoReingresso; }
            set { dDataPublicacaoReingresso = value; }
        }

        #region TipoAmparo

        [PropertyAttribute(Field = "FK_TIPO_AMPARO_LEGAL_REINGRESSO", Description = "Amparo Legal", AllowNull = true, PropertyType = PropertyCategories.ForeignKey, Variable = "iIdTipoAmparo")]
        public TipoAmparo TipoAmparo
        {
            get
            {
                if (oTipoAmparo == null && iIdTipoAmparo != null)
                    oTipoAmparo = new TipoAmparo((int)iIdTipoAmparo, oDao);
                return oTipoAmparo;
            }
            set
            {
                oTipoAmparo = value;
                iIdTipoAmparo = oTipoAmparo.ID;
            }
        }

        [PropertyAttribute(Field = "NUM_AMPARO_LEGAL_REINGRESSO", AllowNull = true, Description = "Número Expediente de Reingressão", PropertyType = PropertyCategories.Field)]
        public string NumeroAmparoLegalReingresso
        {
            get;
            set;
        }

        [PropertyAttribute(Field = "DAT_AMPARO_LEGAL_RENGRESSO", Description = "Data do Amparo Legal do Expediente de Reingresso", AllowNull = true, PropertyType = PropertyCategories.Field)]
        public DateTime? DataAmparoLegal
        {
            get { return dDataAmparoLegal; }
            set { dDataAmparoLegal = value; }
        }

        [PropertyAttribute(Field = "DAT_AMPARO_LEGAL_PUBLICACAO_REINGRESSO", Description = "Data de Publicação do Amparo Legal", AllowNull = true, PropertyType = PropertyCategories.Field)]
        public DateTime? DataPublicacaoAmparoLegal
        {
            get { return dDataPublicacaoAmparoLegal; }
            set { dDataPublicacaoAmparoLegal = value; }
        }

        #endregion

        #endregion
        
        #endregion

        #region Construtores

        public Desligamento(Dao dao)
		{
			oDao = dao;
		}

        public Desligamento(int id, Dao dao)
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

        public CampoNuloOuInvalidoException ValidarExterno()
        {
            CampoNuloOuInvalidoException ex = new CampoNuloOuInvalidoException();
            ex.Mensagens = Pro.Utils.ClassFunctions.ValidateRules(this);
            return ex;
        }
     

        #endregion
    }
}
