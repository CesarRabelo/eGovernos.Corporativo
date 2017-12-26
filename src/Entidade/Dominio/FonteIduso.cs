using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

using Pro.Utils;
using Pro.Dal;
  


namespace Platinium.Entidade
{
    [ClassAttribute(Schema = "platinium", Table = "TB_FONTE_IDUSO")]
    public class FonteIduso
    {
        #region Variáveis e Propriedades

        private Dao oDao;
        private int? iIdFonte;
        private Fonte oFonte;
        private int? iIdIduso;
        private Iduso oIduso;
        private int iID = 0;

        [PropertyAttribute(Field = "ID_FONTE_IDUSO", AllowNull = false, PropertyType = PropertyCategories.PrimaryKey, Variable = "iID")]
        public int ID
        {
            get { return iID; }
        }

        [PropertyAttribute(Field = "FK_FONTE", AllowNull = true, Description = "Fonte", PropertyType = PropertyCategories.ForeignKey, Variable = "iIdFonte")]
        public Fonte Fonte
        {
            get
            {
                if (oFonte == null && iIdFonte != null)
                    oFonte = new Fonte((int)iIdFonte, oDao);
                return oFonte;
            }
            set
            {
                oFonte = value;
                iIdFonte = oFonte.ID;
            }
        }

        [PropertyAttribute(Field = "FK_IDUSO", AllowNull = true, Description = "Iduso", PropertyType = PropertyCategories.ForeignKey, Variable = "iIdIduso")]
        public Iduso Iduso
        {
            get
            {
                if (oIduso == null && iIdIduso != null)
                    oIduso = new Iduso((int)iIdIduso, oDao);
                return oIduso;
            }
            set
            {
                oIduso = value;
                iIdIduso = oIduso.ID;
            }
        }

        #endregion

        #region Construtores
        public FonteIduso() { }
		public FonteIduso(Dao dao)
		{
			oDao = dao;
		}

        public FonteIduso(int id, Dao dao)
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
        #endregion
    }
}
