using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

using Pro.Utils;
using Pro.Dal;


namespace Platinium.Entidade
{
    [ClassAttribute(Schema = "plutonium", Table = "TB_SEXO_SEXO")]
    public class Sexo
    {

        #region Vari�veis e Propriedades

        private Dao oDao;

        private int iID = 0;

        [PropertyAttribute(Field = "ID_SEXO", AllowNull = false, PropertyType = PropertyCategories.PrimaryKey, Variable = "iID")]
        public int ID
        {
            get { return iID; }
        }
        
        [PropertyAttribute(Field = "DSC_SEXO", Description = "Descri��o", AllowNull = false, PropertyType = PropertyCategories.Field)]
        public string Descricao
        {
            get;
            set;
        }

        [PropertyAttribute(Field = "COD_SEXO", Description = "C�digo", AllowNull = false, PropertyType = PropertyCategories.Field)]
        public string Codigo
        {
            get;
            set;
        }

        
        #endregion

        #region Construtores
        public Sexo() { }
        public Sexo(Dao dao)
        {
            oDao = dao;
        }

        public Sexo(int id, Dao dao)
        {
            List<Parameter> parametro = new List<Parameter>();
            parametro.Add(new Parameter("ID", id, ParameterTypes.Filter));
            oDao = dao;
            oDao.Load(this, parametro);
        }

        #endregion

        #region M�todos

        public CrudActionTypes Salvar()
        {
            Validar();
            if (iID == 0) return oDao.Insert(this);
            else return oDao.Update(this);
        }


        public CrudActionTypes Excluir()
        {
            try
            {
                return oDao.Delete(this);
            }
            catch
            {
                throw new ViolacaoRegraException("Registro n�o pode ser excluido !");
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

