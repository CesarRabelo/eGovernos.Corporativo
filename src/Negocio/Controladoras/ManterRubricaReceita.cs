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
    public class ManterRubricaReceita:IManter
    {
        
        #region Variáveis e Propriedades

        private RubricaReceita oRubricaReceita;
        private Dao oDao;

        #endregion

        #region Construtores

        public ManterRubricaReceita()
		{
            oDao = new Dao();
		}

        public ManterRubricaReceita(string connectionString, DataBaseTypes dataBaseType)
        {
            oDao = new Dao(connectionString, dataBaseType);
        }

	    #endregion 
    
        #region Métodos

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao, string colunaSort)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(RubricaReceita));
            dicionario.Add("DSC_ESPECIE", "DescricaoEspecie");
            dicionario.Add("COD_ESPECIE", "CodEspecie");
            dicionario.Add("DSC_ORIGEM", "DescricaoOrigem");
            dicionario.Add("COD_ORIGEM", "CodOrigem");
            dicionario.Add("COD_CAT_ECONOMICA_RECE", "CodCatEconomica");
            dicionario.Add("DSC_CAT_ECONOMICA_RECE", "DescricaoCategoria");
            dicionario.Add("DSC_ATIVO", "DescricaoAtivo");

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

            return this.oDao.Select(lstParametros, "platinium", "VI_RUBRICA_RUBI", dicionario);

        }

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(RubricaReceita));
            dicionario.Add("DSC_ESPECIE", "DescricaoEspecie");
            dicionario.Add("COD_ESPECIE", "CodEspecie");
            dicionario.Add("DSC_ORIGEM", "DescricaoOrigem");
            dicionario.Add("COD_ORIGEM", "CodOrigem");
            dicionario.Add("COD_CAT_ECONOMICA_RECE", "CodCatEconomica");
            dicionario.Add("DSC_CAT_ECONOMICA_RECE", "DescricaoCategoria");
            dicionario.Add("DSC_ATIVO", "DescricaoAtivo");

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
            return this.oDao.Select(lstParametros, "platinium", "VI_RUBRICA_RUBI", dicionario);
        }

        public void PrepararInclusao()
        {
            oRubricaReceita = new RubricaReceita(oDao);
        }

        public Dictionary<string, object> Selecionar(int id)
        {
            oRubricaReceita = new RubricaReceita(id, oDao);
            return ClassFunctions.GetProperties(oRubricaReceita);
        }

        public CrudActionTypes Salvar(Dictionary<string, object> valores)
        {
            ClassFunctions.SetProperties(oRubricaReceita, valores);
            return oRubricaReceita.Salvar();
        }

        public CrudActionTypes Excluir()
        {
            return oRubricaReceita.Excluir();
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

        public int CategoriaEconomicaID { get { return oRubricaReceita.EconomicaDeReceita.ID; } }
        public int OrigemReceitaID { get { return oRubricaReceita.OrigemReceita.ID; } }
        public int EspecieID { get { return oRubricaReceita.Especie.ID; } }
    }
}
