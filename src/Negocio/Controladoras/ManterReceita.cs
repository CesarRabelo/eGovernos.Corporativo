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
    public class ManterReceita:IManter
    {
        
        #region Variáveis e Propriedades

        private Receita oReceita;
        private Dao oDao;

        #endregion

        #region Construtores

        public ManterReceita()
		{
            oDao = new Dao();
		}

        public ManterReceita(string connectionString, DataBaseTypes dataBaseType)
        {
            oDao = new Dao(connectionString, dataBaseType);
        }

	    #endregion 
    
        #region Métodos

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao, string colunaSort)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(Receita));
            dicionario.Add("DSC_ESPECIE", "DescricaoEspecie");
            dicionario.Add("DSC_ORIGEM", "DescricaoOrigem");
            dicionario.Add("DSC_CAT_ECONOMICA_RECE", "DescricaoCategoria");
            dicionario.Add("DSC_ATIVO", "DescricaoAtivo");
            dicionario.Add("DSC_RUBRICA", "DscRubrica");
            dicionario.Add("COD_RUBRICA", "CodRubrica");
            
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

            return this.oDao.Select(lstParametros, "platinium", "VI_RECEITA_RECE", dicionario);

        }

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(Receita));
            dicionario.Add("DSC_ESPECIE", "DescricaoEspecie");
            dicionario.Add("DSC_ORIGEM", "DescricaoOrigem");
            dicionario.Add("DSC_CAT_ECONOMICA_RECE", "DescricaoCategoria");
            dicionario.Add("DSC_ATIVO", "DescricaoAtivo");
            dicionario.Add("DSC_RUBRICA", "DscRubrica");
            dicionario.Add("COD_RUBRICA", "CodRubrica");

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
            return this.oDao.Select(lstParametros, "platinium", "VI_RECEITA_RECE", dicionario);
        }

        public void PrepararInclusao()
        {
            oReceita = new Receita(oDao);
        }

        public Dictionary<string, object> Selecionar(int id)
        {
            oReceita = new Receita(id, oDao);
            return ClassFunctions.GetProperties(oReceita);
        }

        public CrudActionTypes Salvar(Dictionary<string, object> valores)
        {
            ClassFunctions.SetProperties(oReceita, valores);
            return oReceita.Salvar();
        }

        public CrudActionTypes Excluir()
        {
            return oReceita.Excluir();
        }
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

        public string GetCodEspecie(int id)
        {
            Especie oEspecie = new Especie(id, oDao);
            string codigo = oEspecie.Codigo.ToString();
            return codigo.Substring(2, 1);
        }

        public string GetCodRubrica(int id)
        {
            Especie oEspecie = new Especie(id, oDao);
            string codigo = oEspecie.Codigo.ToString();
            return codigo.Substring(3, 1);
        }

        public int CategoriaEconomicaID { get { return oReceita.CatEconomica.ID; } }
        public int OrigemReceitaID { get { return oReceita.OrigemReceita.ID; } }
        public int EspecieID { get { return oReceita.Especie.ID; } }
        public int RubricaID { get { return oReceita.RubricaReceita.ID; } }
    }
}
