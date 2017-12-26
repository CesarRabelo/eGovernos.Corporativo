using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

using Pro.Utils;
using Pro.Dal;


namespace Platinium.Entidade
{
    [ClassAttribute(Schema = "platinium", Table = "tb_grupo_arquivo_grar")]
    public class GrupoArquivo
    {
        #region Variáveis e Propriedades

        private Dao oDao;

        private int iID = 0;

        [PropertyAttribute(Field = "ID_GRUPO_ARQUIVO", AllowNull = false, PropertyType = PropertyCategories.PrimaryKey, Variable = "iID")]
        public int ID
        {
            get { return iID; }
        }

        [PropertyAttribute(Field = "COD_GRUPO_ARQUIVO", AllowNull = false, Description = "Código", PropertyType = PropertyCategories.Field)]
        public string Codigo
        {
            get;
            set;
        }

        [PropertyAttribute(Field = "DSC_GRUPO_ARQUIVO", AllowNull = false, Description = "Descrição", PropertyType = PropertyCategories.Field)]
        public string Descricao
        {
            get;
            set;
        }
        #endregion

        #region Construtores
        public GrupoArquivo() { }
        public GrupoArquivo(Dao dao)
        {
            oDao = dao;
        }

        public GrupoArquivo(int id, Dao dao)
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
