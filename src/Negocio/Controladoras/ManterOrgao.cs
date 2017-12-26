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
    public class ManterOrgao : IManter
    {

        #region Variáveis e Propriedades

        private Orgao oOrgao;
        private Dao oDao;

        #endregion

        #region Construtores

        public ManterOrgao()
        {
            oDao = new Dao();
        }

        #endregion

        #region Métodos
        public DataTable Consultar(Dictionary<string, object> filtros, string direcao, string colunaSort)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(Orgao));
            dicionario.Add("DSC_PODER", "DescricaoPoder");
            dicionario.Add("DSC_ATIVO", "DscAtivo");
            dicionario.Add("DSC_SECRETARIA", "DscSecretaria");
            dicionario.Add("DSC_TIPO_ENTIDADE", "DscTipoEntidade");

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

            return this.oDao.Select(lstParametros, "platinium", "VI_ORGAO_ORGA", dicionario);

        }
        public DataTable Consultar(Dictionary<string, object> filtros, string direcao)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(Orgao));
            dicionario.Add("DSC_PODER", "DescricaoPoder");
            dicionario.Add("DSC_ATIVO", "DscAtivo");
            dicionario.Add("DSC_SECRETARIA", "DscSecretaria");
            dicionario.Add("DSC_TIPO_ENTIDADE", "DscTipoEntidade");

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
            return this.oDao.Select(lstParametros, "platinium", "VI_ORGAO_ORGA", dicionario);
        }

        public Dictionary<string, object> Selecionar(int id)
        {
            oOrgao = new Orgao(id, oDao);
            return ClassFunctions.GetProperties(oOrgao);
        }

        public void PrepararInclusao()
        {
            oOrgao = new Orgao(oDao);
        }

        public CrudActionTypes Salvar(Dictionary<string, object> valores)
        {
            ClassFunctions.SetProperties(oOrgao, valores);
            return oOrgao.Salvar();
        }

        public int SalvarRetornandoIdOrgao(Dictionary<string, object> valores)
        {
            try
            {
                Salvar(valores);
                return oOrgao.ID;
            }
            catch
            {
                oDao.RollBack();
                throw;
            }
        }

        public CrudActionTypes Excluir()
        {
            return oOrgao.Excluir();
        }

        #endregion

        public bool PossuiEndereco()
        {
            if (oOrgao.Endereco == null)
                return false;
            else
                return true;
        }

        public int GetEnderecoID
        {
            get { return oOrgao.Endereco.ID; }
        }

    }
}
