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
    public class ManterFonte : IManter
    {

        #region Variáveis e Propriedades

        private Fonte oFonte;
        private Dao oDao;

        #endregion

        #region Construtores

        public ManterFonte()
        {
            oDao = new Dao();
        }

        public ManterFonte(string connectionString, DataBaseTypes dataBaseType)
        {
            oDao = new Dao(connectionString, dataBaseType);
        }

        #endregion

        #region Métodos

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao, string colunaSort)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(Fonte));
            dicionario.Add("dsc_ativo", "DscAtivo");
            dicionario.Add("cod_grupo_fonte", "CodGrpFonte");
            dicionario.Add("dsc_grupo_fonte", "DscGrpFonte");
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

            return this.oDao.Select(lstParametros, "platinium", "vi_fonte_font", dicionario);

        }

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(Fonte));
            dicionario.Add("dsc_ativo", "DscAtivo");
            dicionario.Add("cod_grupo_fonte", "CodGrpFonte");
            dicionario.Add("dsc_grupo_fonte", "DscGrpFonte");
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
            return this.oDao.Select(lstParametros, "platinium", "vi_fonte_font", dicionario);
        }

        public void PrepararInclusao()
        {
            oFonte = new Fonte(oDao);
        }

        public Dictionary<string, object> Selecionar(int id)
        {
            oFonte = new Fonte(id, oDao);
            return ClassFunctions.GetProperties(oFonte);
        }

        public CrudActionTypes Salvar(Dictionary<string, object> valores)
        {
            ClassFunctions.SetProperties(oFonte, valores);
            return oFonte.Salvar();
        }

        public int SalvarRetornandoId(Dictionary<string, object> valores)
        {
            ClassFunctions.SetProperties(oFonte, valores);
            oFonte.Salvar();
            return oFonte.ID;
        }


        public CrudActionTypes Excluir()
        {
            return oFonte.Excluir();
        }
        #endregion
    }
}
