using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

using Pro.Utils;
using Pro.Dal;


namespace Platinium.Entidade
{
    [ClassAttribute(Schema = "platinium", Table = "TB_ARQUIVO_RESPONSAVEL_ENVIO_ARRE")]
    public class ArquivoResponsavel
    {
        #region Variáveis e Propriedades

        private Dao oDao;

        private int iID = 0;
        private int? iIdArquivo;
        private Arquivo oArquivo;
        private int? iIdResponsavelEnvio;
        private ResponsavelEnvio oResponsavelEnvio;

        [PropertyAttribute(Field = "ID_ARQUIVO_RESPONSAVEL_ENVIO", AllowNull = false, PropertyType = PropertyCategories.PrimaryKey, Variable = "iID")]
        public int ID
        {
            get { return iID; }
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

        [PropertyAttribute(Field = "FK_RESPONSAVEL_ENVIO", AllowNull = false, Description = "Responsável de Envio", PropertyType = PropertyCategories.ForeignKey, Variable = "iIdResponsavelEnvio")]
        public ResponsavelEnvio ResponsavelEnvio
        {
            get
            {
                if (oResponsavelEnvio == null && iIdResponsavelEnvio != null)
                    oResponsavelEnvio = new ResponsavelEnvio((int)iIdResponsavelEnvio, oDao);
                return oResponsavelEnvio;
            }
            set
            {
                oResponsavelEnvio = value;
                iIdResponsavelEnvio = oResponsavelEnvio.ID;
            }
        }


        #endregion

        #region Construtores
        public ArquivoResponsavel() { }
        public ArquivoResponsavel(Dao dao)
        {
            oDao = dao;
        }

        public ArquivoResponsavel(int id, Dao dao)
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
            ValidarResponsavel();

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

        private void ValidarResponsavel()
        {
            List<Parameter> parametro = new List<Parameter>();
            parametro.Add(new Parameter("Arquivo", this.Arquivo.ID, OperationTypes.EqualsTo));
            parametro.Add(new Parameter("ResponsavelEnvio", this.ResponsavelEnvio.ID, OperationTypes.EqualsTo));
            parametro.Add(new Parameter("ID", this.ID, OperationTypes.NotIn));

            if (oDao.Select(parametro, "platinium", "TB_ARQUIVO_RESPONSAVEL_ENVIO_ARRE", typeof(ArquivoResponsavel)).Rows.Count != 0)
                throw new ViolacaoRegraException("Responsável de envio ja cadastrado com o item selecionado!");
        }


        #endregion
    }
}
