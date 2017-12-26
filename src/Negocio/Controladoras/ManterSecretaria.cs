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
    public class ManterSecretaria:IManter
    {

    #region Variáveis e Propriedades

        private Secretaria oSecretaria;
        private Dao oDao;

    #endregion

	#region Construtores

        public ManterSecretaria()
		{
            oDao = new Dao();
		}

	#endregion

    #region Métodos
        public DataTable Consultar(Dictionary<string, object> filtros, string direcao, string colunaSort)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(Secretaria));
            dicionario.Add("DSC_PODER", "DescricaoPoder");
            dicionario.Add("DSC_ATIVO", "DscAtivo");
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

            return this.oDao.Select(lstParametros, "platinium", "VI_SECRETARIA_SECR", dicionario);

        }
        public DataTable Consultar(Dictionary<string, object> filtros, string direcao)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(Secretaria));
            dicionario.Add("DSC_PODER", "DescricaoPoder");
            dicionario.Add("DSC_ATIVO", "DscAtivo");
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
            return this.oDao.Select(lstParametros, "platinium", "VI_SECRETARIA_SECR", dicionario);
        }

        public Dictionary<string, object> Selecionar(int id)
        {
            oSecretaria = new Secretaria(id, oDao);
            return ClassFunctions.GetProperties(oSecretaria);
        }

        public void PrepararInclusao()
        {
            oSecretaria = new Secretaria(oDao);
        }

        public CrudActionTypes Salvar(Dictionary<string, object> valores)
        {
            ClassFunctions.SetProperties(oSecretaria, valores);
            return oSecretaria.Salvar();
        }

        public int SalvarRetornandoIdSecretaria(Dictionary<string, object> valores)
        {
            try
            {
                Salvar(valores);
                return oSecretaria.ID;
            }
            catch
            {
                oDao.RollBack();
                throw;
            }
        }

        public CrudActionTypes Excluir()
        {
            return oSecretaria.Excluir();
        }

    #endregion

        public bool PossuiEndereco()
        {
            if (oSecretaria.Endereco == null)
                return false;
            else
                return true;
        }

        public int GetEnderecoID
        {
            get { return oSecretaria.Endereco.ID; }
        }
    }
}
