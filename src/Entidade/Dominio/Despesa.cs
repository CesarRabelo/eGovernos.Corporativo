using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

using Pro.Utils;
using Pro.Dal;



namespace Platinium.Entidade
{
    [ClassAttribute(Schema = "platinium", Table = "TB_DESPESA_DESP")]
    public class Despesa
    {
        #region Variáveis e Propriedades

        private Dao oDao;
        private int iID = 0;
        private DateTime? dDataCriado;
        private DateTime? dDataDesativado;
        private int? iIdGrupoDespesa;
        private GrupoDespesa oGrupoDespesa;
        private int? iIdCatEconomica;
        private EconomicaDeDespesa oCatEconomica;
        private int? iIdModalidadeAplicacao;
        private ModalidadeAplicacao oModalidadeAplicacao;
        private int? iIdElementoDespesa;
        private ElementoDeDespesa oElementoDespesa;
        private bool bAtivo;

        [PropertyAttribute(Field = "ID_DESPESA_DESP", AllowNull = false, PropertyType = PropertyCategories.PrimaryKey, Variable = "iID")]
        public int ID
        {
            get { return iID; }
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

        [PropertyAttribute(Field = "COD_DESPESA", AllowNull = false, Description = "Código", PropertyType = PropertyCategories.Field)]
        public string Codigo
        {
            get;
            set;
        }

        [PropertyAttribute(Field = "DSC_DESPESA", AllowNull = false, Description = "Descrição", PropertyType = PropertyCategories.Field)]
        public string Descricao
        {
            get;
            set;
        }

        [PropertyAttribute(Field = "FK_GRUPO_DESPESA_GRDE", AllowNull = false, Description = "Grupo de despesa", PropertyType = PropertyCategories.ForeignKey, Variable = "iIdGrupoDespesa")]
        public GrupoDespesa GrupoDespesa
        {
            get
            {
                if (oGrupoDespesa == null && iIdGrupoDespesa != null)
                    oGrupoDespesa = new GrupoDespesa((int)iIdGrupoDespesa, oDao);
                return oGrupoDespesa;
            }
            set
            {
                oGrupoDespesa = value;
                iIdGrupoDespesa = oGrupoDespesa.ID;
            }
        } 

        [PropertyAttribute(Field = "FK_CAT_ECONOMICA_DESPESA_CAED", AllowNull = false, Description = "Categoria Econômica", PropertyType = PropertyCategories.ForeignKey, Variable = "iIdCatEconomica")]
        public EconomicaDeDespesa CatEconomica
        {
            get
            {
                if (oCatEconomica == null && iIdCatEconomica != null)
                    oCatEconomica = new EconomicaDeDespesa((int)iIdCatEconomica, oDao);
                return oCatEconomica;
            }
            set
            {
                oCatEconomica = value;
                iIdCatEconomica = oCatEconomica.ID;
            }
        }

        [PropertyAttribute(Field = "FK_MODALIDADE_APLICACAO_MOAP", AllowNull = false, Description = "Modalidade de Aplicação", PropertyType = PropertyCategories.ForeignKey, Variable = "iIdModalidadeAplicacao")]
        public ModalidadeAplicacao ModalidadeAplicacao
        {
            get
            {
                if (oModalidadeAplicacao == null && iIdModalidadeAplicacao != null)
                    oModalidadeAplicacao = new ModalidadeAplicacao((int)iIdModalidadeAplicacao, oDao);
                return oModalidadeAplicacao;
            }
            set
            {
                oModalidadeAplicacao = value;
                iIdModalidadeAplicacao = oModalidadeAplicacao.ID;
            }
        }

        [PropertyAttribute(Field = "FK_ELEMENTO_DESPESA_ELDE", AllowNull = false, Description = "Elemento de Despesa", PropertyType = PropertyCategories.ForeignKey, Variable = "iIdElementoDespesa")]
        public ElementoDeDespesa ElementoDespesa
        {
            get
            {
                if (oElementoDespesa == null && iIdElementoDespesa != null)
                    oElementoDespesa = new ElementoDeDespesa((int)iIdElementoDespesa, oDao);
                return oElementoDespesa;
            }
            set
            {
                oElementoDespesa = value;
                iIdElementoDespesa = oElementoDespesa.ID;
            }
        }

        [PropertyAttribute(Field = "FLG_ATIVO", AllowNull = true, PropertyType = PropertyCategories.Field, DataType = DataTypes.Char)]
        public bool Ativo
        {
            get { return bAtivo; }
            set { bAtivo = value; }
        }

        #endregion

        #region Construtores
        public Despesa() { }
        public Despesa(Dao dao)
        {
            oDao = dao;
        }

        public Despesa(int id, Dao dao)
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
            ValidarCodigoCadastrado();
            ValidarCodigoExistente();

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
            if (Codigo.Length <= 6)
                ex.Mensagens.Add("Codigo", "O campo <b>Código</b> é de preenchimento obrigatório.");
            if (this.iIdCatEconomica == 0)
                ex.Mensagens.Add("CatEconomica", "O campo <b>Categoria ecônomica</b> é de preenchimento obrigatório.");
            if (this.iIdGrupoDespesa == 0)
                ex.Mensagens.Add("GrupoDespesa", "O campo <b>Grupo de Despesa</b> é de preenchimento obrigatório.");
            if (this.iIdModalidadeAplicacao == 0)
                ex.Mensagens.Add("ModalidadeAplicacao", "O campo <b>Modalidade de aplicação</b> é de preenchimento obrigatório.");
            if (this.iIdElementoDespesa == 0)
                ex.Mensagens.Add("ElementoDespesa", "O campo <b>Elemento de Despesa</b> é de preenchimento obrigatório.");
            if (ex.Mensagens.Count > 0)
                throw ex;
        }

        private void ValidarCodigoCadastrado()
        {
            List<Parameter> parametro = new List<Parameter>();
            parametro.Add(new Parameter("Codigo", this.Codigo.ToUpper(), ParameterTypes.Filter));
            parametro.Add(new Parameter("ID", this.ID, OperationTypes.NotIn));

            if (oDao.Select(parametro, "platinium", "TB_DESPESA_DESP", typeof(Despesa)).Rows.Count != 0)
                throw new RegraNegocioException("Despesa já cadastrada com o código informado");
        }


        private void ValidarDescricaoCadastrado()
        {
            List<Parameter> parametro = new List<Parameter>();
            parametro.Add(new Parameter("Descricao", this.Descricao.ToUpper(), ParameterTypes.Filter));
            parametro.Add(new Parameter("ID", this.ID, OperationTypes.NotIn));

            if (oDao.Select(parametro, "platinium", "TB_DESPESA_DESP", typeof(Despesa)).Rows.Count != 0)
                throw new RegraNegocioException("Despesa já cadastrada com a descrição informada");
        }

        public void ValidarCodigoExistente()
        {
            CampoNuloOuInvalidoException ex = new CampoNuloOuInvalidoException();
            string codigoCatEconomica = this.Codigo.Substring(0, 1);
            string codigoGrupoDespesa = this.Codigo.Substring(1, 1);
            string codigoModalidadeAplicacao = this.Codigo.Substring(2, 2);
            string codigoElementoDespesa = this.Codigo.Substring(4, 2);

            List<Parameter> parametroCatEconomica = new List<Parameter>();
            parametroCatEconomica.Add(new Parameter("Codigo", codigoCatEconomica, OperationTypes.EqualsTo));
            List<Parameter> parametroGrupoDespesa = new List<Parameter>();
            parametroGrupoDespesa.Add(new Parameter("Codigo", codigoGrupoDespesa, OperationTypes.EqualsTo));
            List<Parameter> parametroModalidadeAplicacao = new List<Parameter>();
            parametroModalidadeAplicacao.Add(new Parameter("Codigo", codigoModalidadeAplicacao, OperationTypes.EqualsTo));
            List<Parameter> parametroElementoDespesa = new List<Parameter>();
            parametroElementoDespesa.Add(new Parameter("Codigo", codigoElementoDespesa, OperationTypes.EqualsTo));

            if (oDao.Select(parametroCatEconomica, "platinium", "TB_CAT_ECONOMICA_DESPESA_CAED", typeof(EconomicaDeDespesa)).Rows.Count == 0)
                ex.Mensagens.Add("Codigo1", string.Format("Categoria econômica não localizada com o código [{0}].", codigoCatEconomica));
            if (oDao.Select(parametroGrupoDespesa, "platinium", "TB_GRUPO_DESPESA_GRDE", typeof(GrupoDespesa)).Rows.Count == 0)
                ex.Mensagens.Add("Codigo2", string.Format("Grupo de Despesa não localizada com o código [{0}].", codigoGrupoDespesa));
            if (oDao.Select(parametroModalidadeAplicacao, "platinium", "TB_MODALIDADE_APLICACAO_MOAP", typeof(ModalidadeAplicacao)).Rows.Count == 0)
                ex.Mensagens.Add("Codigo3", string.Format("Modalidade de aplicação não localizada com o código [{0}].", codigoModalidadeAplicacao));
            if (oDao.Select(parametroElementoDespesa, "platinium", "TB_ELEMENTO_DESPESA_ELDE", typeof(ElementoDeDespesa)).Rows.Count == 0)
                ex.Mensagens.Add("Codigo4", string.Format("Elemento de Despesa não localizada com o código [{0}].", codigoElementoDespesa));

            if (ex.Mensagens.Count > 0)
                throw ex;
        }

        public void validar2(List<string> msg)
        {
            CampoNuloOuInvalidoException ex = new CampoNuloOuInvalidoException();
            int aux = msg.Count;
            for (int i = 0; i < msg.Count; i++)
                ex.Mensagens.Add(Convert.ToString(i), msg[i]);

            if (ex.Mensagens.Count > 0)
                throw ex;
        }
        #endregion

    }
}
