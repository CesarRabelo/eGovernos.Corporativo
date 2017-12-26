using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

using Pro.Utils;
using Pro.Dal;


namespace Platinium.Entidade
{
    [ClassAttribute(Schema = "platinium", Table = "tb_arquivo_arqu")]
    public class Arquivo
    {
        #region Variáveis e Propriedades

        private Dao oDao;

        private int iID = 0;
        private int? iIdGrupoArquivo;
        private GrupoArquivo oGrupoArquivo;
        private bool bPr = false;
        private bool bCa = false;
        private bool bUg = false;
        private bool bM = false;
        private bool bA = false;
        private bool bO = false;
        private bool bE = false;

        [PropertyAttribute(Field = "ID_ARQUIVO", AllowNull = false, PropertyType = PropertyCategories.PrimaryKey, Variable = "iID")]
        public int ID
        {
            get { return iID; }
        }

        [PropertyAttribute(Field = "COD_ARQUIVO", AllowNull = false, Description = "Código", PropertyType = PropertyCategories.Field)]
        public string Codigo
        {
            get;
            set;
        }

        [PropertyAttribute(Field = "NOM_ARQUIVO", AllowNull = false, Description = "Nome", PropertyType = PropertyCategories.Field)]
        public string Nome
        {
            get;
            set;
        }

        [PropertyAttribute(Field = "COD_PREFIXO_ARQUIVO", AllowNull = false, Description = "Prefixo", PropertyType = PropertyCategories.Field)]
        public string Prefixo
        {
            get;
            set;
        }

        [PropertyAttribute(Field = "COD_MASCARA_ARQUIVO", AllowNull = false, Description = "Máscara", PropertyType = PropertyCategories.Field)]
        public string Mascara
        {
            get;
            set;
        }
        [PropertyAttribute(Field = "FK_GRUPO_ARQUIVO", AllowNull = false, Description = "Grupo de Arquivo", PropertyType = PropertyCategories.ForeignKey, Variable = "iIdGrupoArquivo")]
        public GrupoArquivo GrupoArquivo
        {
            get
            {
                if (oGrupoArquivo == null && iIdGrupoArquivo != null)
                    oGrupoArquivo = new GrupoArquivo((int)iIdGrupoArquivo, oDao);
                return oGrupoArquivo;
            }
            set
            {
                oGrupoArquivo = value;
                iIdGrupoArquivo = oGrupoArquivo.ID;
            }
        }

        [PropertyAttribute(Field = "FLG_ENVIO_PREFEITURA", AllowNull = false, PropertyType = PropertyCategories.Field, DataType = DataTypes.Char, Size = 1)]
        public bool EnvioPrefeitura
        {
            get { return bPr; }
            set { bPr = value; }
        }

        [PropertyAttribute(Field = "FLG_ENVIO_CAMARA", AllowNull = false, PropertyType = PropertyCategories.Field, DataType = DataTypes.Char, Size = 1)]
        public bool EnvioCamara
        {
            get { return bCa; }
            set { bCa = value; }
        }

        [PropertyAttribute(Field = "FLG_ENVIO_UNIDADE_GESTORA", AllowNull = false, PropertyType = PropertyCategories.Field, DataType = DataTypes.Char, Size = 1)]
        public bool EnvioUnidadeGestora
        {
            get { return bUg; }
            set { bUg = value; }
        }

        [PropertyAttribute(Field = "FLG_ENVIO_MENSAL", AllowNull = false, PropertyType = PropertyCategories.Field, DataType = DataTypes.Char, Size = 1)]
        public bool EnvioMensal
        {
            get { return bM; }
            set { bM = value; }
        }

        [PropertyAttribute(Field = "FLG_ENVIO_ALTERACAO_ORCAMENTO", AllowNull = false, PropertyType = PropertyCategories.Field, DataType = DataTypes.Char, Size = 1)]
        public bool EnvioAlteracaoOrcamento
        {
            get { return bO; }
            set { bO = value; }
        }

        [PropertyAttribute(Field = "FLG_ENVIO_ATUALIZACAO_DADOS", AllowNull = false, PropertyType = PropertyCategories.Field, DataType = DataTypes.Char, Size = 1)]
        public bool EnvioAltualizacaoDados
        {
            get { return bA; }
            set { bA = value; }
        }

        [PropertyAttribute(Field = "FLG_ENVIO_MOTIVO_ESPECIFICO", AllowNull = false, PropertyType = PropertyCategories.Field, DataType = DataTypes.Char, Size = 1)]
        public bool EnvioMotivoEspecifico
        {
            get { return bE; }
            set { bE = value; }
        }

        #endregion

        #region Construtores
        public Arquivo() { }
        public Arquivo(Dao dao)
        {
            oDao = dao;
        }

        public Arquivo(int id, Dao dao)
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
