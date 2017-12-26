using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

using Pro.Utils;
using Pro.Dal;


namespace Platinium.Entidade
{
    [ClassAttribute(Schema = "platinium", Table = "tb_arquivo_coluna_arco")]
    public class ArquivoColuna
    {
        #region Variáveis e Propriedades

        private Dao oDao;

        private int iID = 0;
        private int? iIdArquivo;
        private Arquivo oArquivo;

        [PropertyAttribute(Field = "ID_ARQUIVO_COLUNA", AllowNull = false, PropertyType = PropertyCategories.PrimaryKey, Variable = "iID")]
        public int ID
        {
            get { return iID; }
        }

        [PropertyAttribute(Field = "NUM_SEQUENCIA", AllowNull = false, Description = "Sequência", PropertyType = PropertyCategories.Field)]
        public int Sequencia
        {
            get;
            set;
        }

        [PropertyAttribute(Field = "DSC_COLUNA", AllowNull = false, Description = "Descrição", PropertyType = PropertyCategories.Field)]
        public string Descricao
        {
            get;
            set;
        }

        [PropertyAttribute(Field = "DSC_DETALHES", AllowNull = true, Description = "Detalhes", PropertyType = PropertyCategories.Field)]
        public string Detalhes
        {
            get;
            set;
        }

        [PropertyAttribute(Field = "QTD_POSICOES", AllowNull = false, Description = "Posições", PropertyType = PropertyCategories.Field)]
        public int Posicoes
        {
            get;
            set;
        }

        [PropertyAttribute(Field = "DSC_MASCARA", AllowNull = true, Description = "Máscara", PropertyType = PropertyCategories.Field)]
        public string Mascara
        {
            get;
            set;
        }
        [PropertyAttribute(Field = "DSC_TIPO", AllowNull = true, Description = "Tipo", PropertyType = PropertyCategories.Field)]
        public string Tipo
        {
            get;
            set;
        }
        [PropertyAttribute(Field = "NUM_METODO_COMPLEMENTO", AllowNull = true, Description = "Método complemento", PropertyType = PropertyCategories.Field)]
        public int MetodoComplemento
        {
            get;
            set;
        }
        [PropertyAttribute(Field = "FK_ARQUIVO", AllowNull = false, Description = "Arquivo", PropertyType = PropertyCategories.ForeignKey, Variable = "iIdArquivo")]
        public Arquivo Arquivo
        {
            get
            {
                if (oArquivo == null && iIdArquivo != null)
                    oArquivo = new Arquivo((int)iIdArquivo, oDao);
                return oArquivo;
            }
            set
            {
                oArquivo = value;
                iIdArquivo = oArquivo.ID;
            }
        }
        #endregion

        #region Construtores
        public ArquivoColuna() { }
        public ArquivoColuna(Dao dao)
        {
            oDao = dao;
        }

        public ArquivoColuna(int id, Dao dao)
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
