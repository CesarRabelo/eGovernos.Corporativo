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
    public class ManterLocalidade:IManter
    {
        
        #region Variáveis e Propriedades

        private Localidade oLocalidade;
        private Dao oDao;

        #endregion

        #region Construtores

        public ManterLocalidade()
		{
            oDao = new Dao();
		}

        public ManterLocalidade(string connectionString, DataBaseTypes dataBaseType)
        {
            oDao = new Dao(connectionString, dataBaseType);
        }

	    #endregion 
    
        #region Métodos

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao, string colunaSort)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(Localidade));
            dicionario.Add("DSC_ATIVO", "DescricaoAtivo");
            dicionario.Add("DSC_REGIAO", "DescricaoRegiao");

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

            return this.oDao.Select(lstParametros, "platinium", "VI_LOCALIDADE_LOCA", dicionario);

        }

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(Localidade));
            dicionario.Add("DSC_ATIVO", "DescricaoAtivo");
            dicionario.Add("DSC_REGIAO", "DescricaoRegiao");


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
            return this.oDao.Select(lstParametros, "platinium", "VI_LOCALIDADE_LOCA", dicionario);
        }

        public void PrepararInclusao()
        {
            oLocalidade = new Localidade(oDao);
        }

        public Dictionary<string, object> Selecionar(int id)
        {
            oLocalidade = new Localidade(id, oDao);
            return ClassFunctions.GetProperties(oLocalidade);
        }

        public CrudActionTypes Salvar(Dictionary<string, object> valores)
        {
            ClassFunctions.SetProperties(oLocalidade, valores);
            return oLocalidade.Salvar();
        }

        public CrudActionTypes Excluir()
        {
            return oLocalidade.Excluir();
        }

        public int SalvarRetornandoId(Dictionary<string, object> valores)
        {
            ClassFunctions.SetProperties(oLocalidade, valores);
            oLocalidade.Salvar();
            return oLocalidade.ID;
        }

        #endregion
    }
}
