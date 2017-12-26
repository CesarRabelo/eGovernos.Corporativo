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
    public class ManterOrigemReceita:IManter
    {
        
        #region Variáveis e Propriedades

        private OrigemReceita oOrigemReceita;
        private Dao oDao;

        #endregion

        #region Construtores

        public ManterOrigemReceita()
		{
            oDao = new Dao();
		}

        public ManterOrigemReceita(string connectionString, DataBaseTypes dataBaseType)
        {
            oDao = new Dao(connectionString, dataBaseType);
        }

	    #endregion 
    
        #region Métodos

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao, string colunaSort)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(OrigemReceita));
            dicionario.Add("dsc_cat_economica_rece", "DescricaoCategoria");
            dicionario.Add("dsc_ativo", "DescricaoAtivo");

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

            return this.oDao.Select(lstParametros, "platinium", "VI_ORIGEM_ORIG", dicionario);

        }

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(OrigemReceita));
            dicionario.Add("dsc_cat_economica_rece", "DescricaoCategoria");
            dicionario.Add("dsc_ativo", "DescricaoAtivo");

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
            return this.oDao.Select(lstParametros, "platinium", "VI_ORIGEM_ORIG", dicionario);
        }

        public void PrepararInclusao()
        {
            oOrigemReceita = new OrigemReceita(oDao);
        }

        public Dictionary<string, object> Selecionar(int id)
        {
            oOrigemReceita = new OrigemReceita(id, oDao);
            return ClassFunctions.GetProperties(oOrigemReceita);
        }

        public CrudActionTypes Salvar(Dictionary<string, object> valores)
        {
            ClassFunctions.SetProperties(oOrigemReceita, valores);
            return oOrigemReceita.Salvar();
        }

        public CrudActionTypes Excluir()
        {
            return oOrigemReceita.Excluir();
        }

        public string GetCodReceita(int id)
        {
            EconomicaDeReceita oEconomicaDeReceita = new EconomicaDeReceita(id, oDao);
            string codigo = oEconomicaDeReceita.Codigo.ToString();
            return codigo.Substring(0, 1);
        }

        #endregion
    }
}
