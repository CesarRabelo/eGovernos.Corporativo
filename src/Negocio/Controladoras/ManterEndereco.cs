using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

using Pro.Utils;
using Pro.Dal;
using Neonium.Entidade;
using Negocio;

namespace Platinium.Negocio
{
    public class ManterEndereco:IManter
    {
        
        #region Variáveis e Propriedades

        private Endereco oEndereco;
        private Dao oDao;

     
        #endregion

        #region Construtores

        public ManterEndereco()
		{
            oDao = new Dao();
		}

        public ManterEndereco(string connectionString, DataBaseTypes dataBaseType)
        {
            oDao = new Dao(connectionString, dataBaseType);
        }
       
	    #endregion 
    
        #region Métodos

        public void SetarID(int id)
        {
            this.oEndereco.ID = id;
        }
        public Dictionary<string, object> ObterAtributos()
        {
            return ClassFunctions.GetProperties(oEndereco);
        }
        public DataTable Consultar(Dictionary<string, object> filtros, string direcao, string colunaSort)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(Endereco));

            List<Parameter> lstParametros = new List<Parameter>();
            foreach (KeyValuePair<string, object> item in filtros)
            {
                lstParametros.Add(new Parameter(item.Key, item.Value, OperationTypes.Like));
            }
            lstParametros.Add(new Parameter(colunaSort, null, OperationTypes.Null, direcao));

            return this.oDao.Select(lstParametros, "platinium", "TB_ENDERECO_ENDE", dicionario);

        }

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(Endereco));

            List<Parameter> lstParametros = new List<Parameter>();
            foreach (KeyValuePair<string, object> item in filtros)
            {
                lstParametros.Add(new Parameter(item.Key, item.Value, OperationTypes.Like, direcao));
            }
            return this.oDao.Select(lstParametros, "platinium", "TB_ENDERECO_ENDE", dicionario);
        }

        public void PrepararInclusao()
        {
            oEndereco = new Endereco(oDao);
        }

        public Dictionary<string, object> Selecionar(int id)
        {
            oEndereco = new Endereco(id, oDao);
            return ClassFunctions.GetProperties(oEndereco);
        }

        public String EnderecoCompletoExibicao(int id)
        {
            oEndereco = new Endereco(id, oDao);
            string enderecoCompleto = oEndereco.Logradouro + ", " + oEndereco.Numero + " " + oEndereco.Bairro + ", " + oEndereco.Localidade + " " + oEndereco.SiglaEstado;
            return enderecoCompleto;
        }

        public string Coordenadas(int id)
        {
            oEndereco = new Endereco(id, oDao);
            string coordenadas = null;
            if (!string.IsNullOrEmpty(oEndereco.Latitude) || !string.IsNullOrEmpty(oEndereco.Longitude))
                coordenadas = oEndereco.Latitude + "," + oEndereco.Longitude;
            return coordenadas;
        }

        public CrudActionTypes Salvar(Dictionary<string, object> valores)
        {
            ClassFunctions.SetProperties(oEndereco, valores);
            return oEndereco.Salvar();
        }
        public int SalvarRetornandoId(Dictionary<string, object> valores)
        {
            ClassFunctions.SetProperties(oEndereco, valores);
            oEndereco.Salvar();
            return oEndereco.ID;
        }
        public CrudActionTypes Excluir()
        {
            return oEndereco.Excluir();
        }

        #endregion
    }
}
