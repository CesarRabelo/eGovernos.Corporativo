using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

using Pro.Utils;
using Pro.Dal;
using Platinium.Entidade;
  
using Negocio;

namespace Platinium.Negocio
{
    public class ManterEspecie:IManter
    {
        
        #region Variáveis e Propriedades

        private Especie oEspecie;
        private Dao oDao;

        #endregion

        #region Construtores

        public ManterEspecie()
		{
            oDao = new Dao();
		}

        public ManterEspecie(string connectionString, DataBaseTypes dataBaseType)
        {
            oDao = new Dao(connectionString, dataBaseType);
        }

	    #endregion 
    
        #region Métodos

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao, string colunaSort)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(Especie));
            dicionario.Add("dsc_ativo", "DscAtivo");
            dicionario.Add("dsc_cat_economica_rece", "DscCatEconomicaRece");
            dicionario.Add("dsc_origem", "DscOrigem");
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

            return this.oDao.Select(lstParametros, "platinium", "VI_ESPECIE_ESPE", dicionario);

        }

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(Especie));
            dicionario.Add("dsc_ativo", "DscAtivo");
            dicionario.Add("dsc_cat_economica_rece", "DscCatEconomicaRece");
            dicionario.Add("dsc_origem", "DscOrigem");

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
            return this.oDao.Select(lstParametros, "platinium", "VI_ESPECIE_ESPE", dicionario);
        }

        public void PrepararInclusao()
        {
            oEspecie = new Especie(oDao);
        }

        public Dictionary<string, object> Selecionar(int id)
        {
            oEspecie = new Especie(id, oDao);
            return ClassFunctions.GetProperties(oEspecie);
        }

        public CrudActionTypes Salvar(Dictionary<string, object> valores)
        {
            ClassFunctions.SetProperties(oEspecie, valores);
            return oEspecie.Salvar();
        }

        public CrudActionTypes Excluir()
        {
            return oEspecie.Excluir();
        }

        public int CategoriaEconomicaID { get { return oEspecie.CategoriaEconomica.ID; } }
        public int OrigemReceitaID { get { return oEspecie.OrigemReceita.ID; } }

        #endregion

        public string GetCodCategoriaEconomica(int id)
        {
            EconomicaDeReceita oEconomicaDeReceita = new EconomicaDeReceita(id, oDao);
            string codigo = oEconomicaDeReceita.Codigo.ToString();
            return codigo.Substring(0, 1);
        }

        public string GetCodOrigemReceita(int id)
        {
            OrigemReceita oOrigemReceita = new OrigemReceita(id, oDao);
            string codigo = oOrigemReceita.Codigo.ToString();
            return codigo.Substring(1, 1);
        }
    }
}
