using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using Pro.Utils;
using Pro.Dal;


namespace Platinium.Entidade
{
    [ClassAttribute(Schema = "platinium", Table = "TB_ANO_LEI_ANLE")]
    public class AnoLei
    {
        #region Variáveis e Propriedades

        private Dao oDao;

        private int iID = 0;
        private DateTime? dDataEnvio;
        private DateTime? dDataAprovacao;
        private DateTime? dDataPublicacao;

        [PropertyAttribute(Field = "ID_ANO_LEI", AllowNull = false, PropertyType = PropertyCategories.PrimaryKey, Variable = "iID")]
        public int ID
        {
            get { return iID; }
        }

        [PropertyAttribute(Field = "ANO_ELABORACAO", AllowNull = false, Description="Ano Elaboração", PropertyType = PropertyCategories.Field, Size=4)]
        public string AnoElaboracao
        {
            get;
            set;
        }

        [PropertyAttribute(Field = "DSC_LEI_LDO", AllowNull = true, Description="Lei LDO", PropertyType = PropertyCategories.Field, Size=100)]
        public string DscLeiLdo
        {
            get;
            set;
        }

        [PropertyAttribute(Field = "DSC_LEI_LOA", AllowNull = true, Description = "Lei LOA", PropertyType = PropertyCategories.Field, Size = 100)]
        public string DscLeiLoa
        {
            get;
            set;
        }

        [PropertyAttribute(Field = "DSC_LEI_PPA", AllowNull = true, Description = "Lei PPA", PropertyType = PropertyCategories.Field, Size = 100)]
        public string DscLeiPpa
        {
            get;
            set;
        }

        [PropertyAttribute(Field = "NUM_LEI_LOA", AllowNull = true, Description = "Número Lei LOA", PropertyType = PropertyCategories.Field)]
        public string NumLeiLoa
        {
            get;
            set;
        }

        [PropertyAttribute(Field = "PERC_SUPL_APROV_LEI_LOA", AllowNull = true, Description = "Percentual de suplementação aprovado para a LOA", PropertyType = PropertyCategories.Field)]
        public string PercSuplAprovLeiLoa
        {
            get;
            set;
        }

        [PropertyAttribute(Field = "TOTAL_SUPL_APROV_LEI_LOA", AllowNull = true, Description = "Valor total suplementação aprovado para a LOA", PropertyType = PropertyCategories.Field)]
        public string TotalSuplAprovLeiLoa
        {
            get;
            set;
        }

        [PropertyAttribute(Field = "DAT_ENVIO_LEI_LOA", Description = "Data envio da LOA", AllowNull = true, PropertyType = PropertyCategories.Field)]
        public DateTime? DataEnvio
        {
            get { return dDataEnvio; }
            set { dDataEnvio = value; }
        }

        [PropertyAttribute(Field = "DAT_APROV_LEI_LOA", Description = "Data aprovação da LOA", AllowNull = true, PropertyType = PropertyCategories.Field)]
        public DateTime? DataAprovacao
        {
            get { return dDataAprovacao; }
            set { dDataAprovacao = value; }
        }

        [PropertyAttribute(Field = "DAT_PUBLI_LEI_LOA", Description = "Data publicação da LOA", AllowNull = true, PropertyType = PropertyCategories.Field)]
        public DateTime? DataPublicacao
        {
            get { return dDataPublicacao; }
            set { dDataPublicacao = value; }
        }

        #endregion

        #region Construtores
        public AnoLei() { }
		public AnoLei(Dao dao)
		{
			oDao = dao;
		}

        public AnoLei(int id, Dao dao)
		{
			List<Parameter> parametro = new List<Parameter>();
            parametro.Add(new Parameter("ID", id, ParameterTypes.Filter));
			oDao = dao;
            oDao.Load(this, parametro);
		}

        public AnoLei(string AnoElaboracao, Dao dao)
        {
            List<Parameter> parametro = new List<Parameter>();
            parametro.Add(new Parameter("AnoElaboracao", AnoElaboracao, ParameterTypes.Filter));
            oDao = dao;
            oDao.Load(this, parametro);
        }

	#endregion

        #region Métodos

        public CrudActionTypes Salvar()
        {
            Validar();
            ValidarCadastrado();
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
            if(string.IsNullOrEmpty(this.DscLeiLdo) && string.IsNullOrEmpty(this.DscLeiLoa) && string.IsNullOrEmpty(this.DscLeiPpa))
                ex.Mensagens.Add("Descrição", "A descrição de uma das leis é de preenchimento obrigatório.");
            if (ex.Mensagens.Count > 0)
                throw ex;
        }

        private void ValidarCadastrado()
        {
            List<Parameter> parametro = new List<Parameter>();
            parametro.Add(new Parameter("AnoElaboracao", this.AnoElaboracao.ToUpper(), ParameterTypes.Filter));

            //if(!string.IsNullOrEmpty(this.DscLeiLdo))
            //    parametro.Add(new Parameter("DscLeiLdo", this.DscLeiLdo.ToUpper(), ParameterTypes.Filter));
            //if (!string.IsNullOrEmpty(this.DscLeiLoa))
            //    parametro.Add(new Parameter("DscLeiLoa", this.DscLeiLoa.ToUpper(), ParameterTypes.Filter));
            //if (!string.IsNullOrEmpty(this.DscLeiPpa))
            //    parametro.Add(new Parameter("DscLeiPpa", this.DscLeiPpa.ToUpper(), ParameterTypes.Filter));

            parametro.Add(new Parameter("ID", this.ID, OperationTypes.NotIn));

            if (oDao.Select(parametro, "platinium", "TB_ANO_LEI_ANLE", typeof(AnoLei)).Rows.Count != 0)
                throw new RegraNegocioException("Ano Elaboração já cadastrado!");
        }
        

        #endregion
    }
}
