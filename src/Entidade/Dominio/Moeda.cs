using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

using Pro.Utils;
using Pro.Dal;


namespace Platinium.Entidade
{
    [ClassAttribute(Schema = "platinium", Table = "TB_MOEDA_MOED")]
    public class Moeda
    {
        #region Variáveis e Propriedades

        private Dao oDao;
        private int iID = 0;

        [PropertyAttribute(Field = "ID_MOEDA", AllowNull = false, PropertyType = PropertyCategories.PrimaryKey, Variable = "iID")]
        public int ID
        {
            get { return iID; }
        }


        [PropertyAttribute(Field = "DSC_CIFRA", AllowNull = false, Description="Descrição" ,PropertyType = PropertyCategories.Field, Size = 10)]
        public string DescricaoCifra
        {
            get;
            set;
        }


        [PropertyAttribute(Field = "DSC_MOEDA", AllowNull = false, Description = "Descrição", PropertyType = PropertyCategories.Field, Size = 50)]
        public string DescricaoMoeda
        {
            get;
            set;
        }

        
        #endregion

        #region Construtores
        public Moeda() { }
		public Moeda(Dao dao)
		{
			oDao = dao;
		}

        public Moeda(int id, Dao dao)
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
            ValidarDescricaoCadastrado();
            ValidarDescricaoCadastrado2();

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
        
        private void ValidarDescricaoCadastrado()
        {
            List<Parameter> parametro = new List<Parameter>();
            parametro.Add(new Parameter("DescricaoCifra", this.DescricaoCifra.ToUpper(), ParameterTypes.Filter));
            parametro.Add(new Parameter("ID", this.ID, OperationTypes.NotIn));

            if (oDao.Select(parametro, "platinium", "TB_MOEDA_MOED", typeof(Moeda)).Rows.Count != 0)
                throw new RegraNegocioException("Moeda já cadastrada com a descrição da cifra informada");
        }
        
        private void ValidarDescricaoCadastrado2()
        {
            List<Parameter> parametro = new List<Parameter>();
            parametro.Add(new Parameter("DescricaoMoeda", this.DescricaoMoeda.ToUpper(), ParameterTypes.Filter));
            parametro.Add(new Parameter("ID", this.ID, OperationTypes.NotIn));

            if (oDao.Select(parametro, "platinium", "TB_MOEDA_MOED", typeof(Moeda)).Rows.Count != 0)
                throw new RegraNegocioException("Moeda já cadastrada com a descrição da moeda informada");
        }
        
        #endregion
    }
}
