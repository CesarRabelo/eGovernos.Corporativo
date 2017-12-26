using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

using Pro.Utils;
using Pro.Dal;
using Platinium.Entidade;
using Neonium.Entidade;
  
using Negocio;

namespace Platinium.Negocio
{
    public class ManterPessoal:IManter
    {
        
        #region Variáveis e Propriedades

        private Pessoal oPessoal;
        private Dao oDao;

        #endregion

        #region Construtores

        public ManterPessoal()
		{
            oDao = new Dao();
		}

        public ManterPessoal(string connectionString, DataBaseTypes dataBaseType)
        {
            oDao = new Dao(connectionString, dataBaseType);
        }

	    #endregion 
    
        #region Métodos

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao, string colunaSort)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(Pessoal));


            List<Parameter> lstParametros = new List<Parameter>();
            foreach (KeyValuePair<string, object> item in filtros)
            {
                if (item.Value != null)
                {
                    if (item.Value.GetType() == typeof(Int32))
                        lstParametros.Add(new Parameter(item.Key, item.Value, OperationTypes.EqualsTo));
                    else
                        lstParametros.Add(new Parameter(item.Key, item.Value, OperationTypes.Like));
                }
            }
            lstParametros.Add(new Parameter(colunaSort, null, OperationTypes.Null, direcao));

            return this.oDao.Select(lstParametros, "plutonium", "TB_PESSOAL_PESS", dicionario);

        }

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(Pessoal));

            List<Parameter> lstParametros = new List<Parameter>();
            foreach (KeyValuePair<string, object> item in filtros)
            {
                if (item.Value != null)
                {
                    if (item.Value.GetType() == typeof(Int32))
                        lstParametros.Add(new Parameter(item.Key, item.Value, OperationTypes.EqualsTo));
                    else
                        lstParametros.Add(new Parameter(item.Key, item.Value, OperationTypes.Like));
                }
            }
            return this.oDao.Select(lstParametros, "plutonium", "TB_PESSOAL_PESS", dicionario);
        }

        public void PrepararInclusao()
        {
            oPessoal = new Pessoal(oDao);
        }

        public Dictionary<string, object> Selecionar(int id)
        {
            oPessoal = new Pessoal(id, oDao);
            return ClassFunctions.GetProperties(oPessoal);
        }

        public int SalvarRetornandoIdPessoal(Dictionary<string, object> valores)
        {
            try
            {
                Salvar2(valores);
                return oPessoal.ID;
            }
            catch
            {
                oDao.RollBack();
                throw;
            }
        }

        private void Salvar2(Dictionary<string, object> valores)
        {
            oDao.StartTransactionMode();
            ClassFunctions.SetProperties(oPessoal, valores);
            CrudActionTypes evento = oPessoal.Salvar();
            oDao.Commit();
        }

        public CrudActionTypes Salvar(Dictionary<string, object> valores)
        {
            try
            {
                oDao.StartTransactionMode();
                ClassFunctions.SetProperties(oPessoal, valores);
                CrudActionTypes evento = oPessoal.Salvar();
                oDao.Commit();
                return evento;
            }
            catch
            {
                oDao.RollBack();
                throw;
            }
        }

        //public CrudActionTypes Salvar(Dictionary<string, object> valores)
        //{
        //    ClassFunctions.SetProperties(oPessoal, valores);
        //    return oPessoal.Salvar();
        //}

        public CrudActionTypes Excluir()
        {
            try
            {
                oDao.StartTransactionMode();
                Endereco end = oPessoal.Endereco;
                CrudActionTypes evento = oPessoal.Excluir();
                end.Excluir();
                oDao.Commit();
                return evento;
            }
            catch
            {
                oDao.RollBack();
                throw;
            }
        }

        public int GetPessoalID
        {
            get { return oPessoal.ID; }
        }

        public int GetEnderecoID
        {
            get { return oPessoal.Endereco.ID; }
        }
        public bool PossuiEndereco()
        {
            if (oPessoal.Endereco == null)
                return false;
            else
                return true;
        }

        public void Validacao(Dictionary<string, object> valores)
        {
            ClassFunctions.SetProperties(oPessoal, valores);
            oPessoal.Salvar();
        }

        //public void Validacao()
        //{
        //    oPessoal.Salvar();
        //}

        #endregion

        public string RetornarEndereco(int idPessoal)
        {
            oPessoal = new Pessoal(idPessoal, oDao);
            Endereco endereco = oPessoal.Endereco;
            if (endereco != null)
                return endereco.Logradouro + ", " + endereco.Numero + " " + endereco.Bairro + ", " + endereco.Localidade + " " + endereco.SiglaEstado;
            else
                return null;
        }

        public CampoNuloOuInvalidoException ValidarCampos(Dictionary<string, object> dicionario)
        {
            try
            {
                ClassFunctions.SetProperties(oPessoal, dicionario);
                CampoNuloOuInvalidoException ex = oPessoal.ValidarExterno();
                return ex;
            }
            catch
            {
                oDao.RollBack();
                throw;
            }
        }
    }
}
