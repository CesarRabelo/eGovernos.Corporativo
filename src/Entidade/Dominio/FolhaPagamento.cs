using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using Platinium.Entidade;
using Pro.Utils;
using Pro.Dal;


namespace Platinium.Entidade
{
    [ClassAttribute(Schema = "plutonium", Table = "TB_FOLHA_PAGAMENTO_FOPA")]
    public class FolhaPagamento
    {

        #region Variáveis e Propriedades

        private Dao oDao;

        private int iID = 0;
        private DateTime? dDataEmissao;
        private DateTime? dDataCompetencia;
        private Orgao oOrgao;
        private int? iIdOrgao;
        private UnidadeOrcamentaria oUnidadeOrcamentaria;
        private int? iIdUnidadeOrcamentaria;
        private TipoFolha oTipoFolha;
        private int? iIdTipoFolha;

        [PropertyAttribute(Field = "ID_FOLHA_PAGAMENTO", AllowNull = false, PropertyType = PropertyCategories.PrimaryKey, Variable = "iID")]
        public int ID
        {
            get { return iID; }
        }

        [PropertyAttribute(Field = "FK_ORGAO", AllowNull = false, Description = "Órgão", PropertyType = PropertyCategories.ForeignKey, Variable = "iIdOrgao")]
        public Orgao Orgao
        {
            get
            {
                if (oOrgao == null && iIdOrgao != null)
                    oOrgao = new Orgao((int)iIdOrgao, oDao);
                return oOrgao;
            }
            set
            {
                oOrgao = value;
                iIdOrgao = oOrgao.ID;
            }
        }

        [PropertyAttribute(Field = "FK_UNIDADE_ORCAMENTARIA", AllowNull = false, Description = "Unidade Orcamentária", PropertyType = PropertyCategories.ForeignKey, Variable = "iIdUnidadeOrcamentaria")]
        public UnidadeOrcamentaria UnidadeOrcamentaria
        {

            get
            {
                if (oUnidadeOrcamentaria == null && iIdUnidadeOrcamentaria != null)
                    oUnidadeOrcamentaria = new UnidadeOrcamentaria((int)iIdUnidadeOrcamentaria, oDao);
                return oUnidadeOrcamentaria;
            }
            set
            {
                oUnidadeOrcamentaria = value;
                iIdUnidadeOrcamentaria = oUnidadeOrcamentaria.ID;
            }
        }

        [PropertyAttribute(Field = "FK_TIPO_FOLHA_PAGAMENTO", AllowNull = false, Description = "Tipo da Folha", PropertyType = PropertyCategories.ForeignKey, Variable = "iIdTipoFolha")]
        public TipoFolha TipoFolha
        {

            get
            {
                if (oTipoFolha == null && iIdTipoFolha != null)
                    oTipoFolha = new TipoFolha((int)iIdTipoFolha, oDao);
                return oTipoFolha;
            }
            set
            {
                oTipoFolha = value;
                iIdTipoFolha = oTipoFolha.ID;
            }
        }

        [PropertyAttribute(Field = "DAT_EMISSAO", Description = "Data de criação", AllowNull = false, PropertyType = PropertyCategories.Field)]
        public DateTime? DataEmissao
        {
            get { return dDataEmissao; }
            set { dDataEmissao = value; }
        }

        [PropertyAttribute(Field = "DAT_COMPETENCIA", Description= "Data da Competência", AllowNull = false, PropertyType = PropertyCategories.Field)]
        public DateTime? DataCompetencia
        {
            get { return dDataCompetencia; }
            set { dDataCompetencia = value; }
        }

        #endregion

        #region Construtores
        public FolhaPagamento() { }
        public FolhaPagamento(Dao dao)
        {
            oDao = dao;
        }

        public FolhaPagamento(int id, Dao dao)
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
            ValidacoesCadastradas();

            if (iID == 0) return oDao.Insert(this);
            else return oDao.Update(this);
        }

        private void ManipularDatas()
        {
            if (iID == 0)
                this.DataEmissao = DateTime.Now;
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

        private void ValidacoesCadastradas()
        {
            List<Parameter> parametro = new List<Parameter>();
            parametro.Add(new Parameter("TipoFolha", this.TipoFolha.ID, OperationTypes.EqualsTo));
            parametro.Add(new Parameter("UnidadeOrcamentaria", this.UnidadeOrcamentaria.ID, OperationTypes.EqualsTo));
            parametro.Add(new Parameter("DataCompetencia", this.DataCompetencia, OperationTypes.EqualsTo));

            if (oDao.Select(parametro, "plutonium", "TB_FOLHA_PAGAMENTO_FOPA", typeof(FolhaPagamento)).Rows.Count != 0)
                throw new RegraNegocioException("Unidade Orçamentária e Tipo de Folha já cadastrados para esta competência!");
        }

        #endregion

    }

}

