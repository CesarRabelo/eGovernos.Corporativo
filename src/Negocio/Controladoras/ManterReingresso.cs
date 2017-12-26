using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

using Pro.Utils;
using Pro.Dal;
using Platinium.Negocio;
using Platinium.Entidade;
using Negocio;

namespace Platinium.Negocio
{
    public class ManterReingresso:IManter
    {
        
        #region Variáveis e Propriedades

        private Desligamento oReingresso;
        private Dao oDao;

        #endregion

        #region Construtores

        public ManterReingresso()
		{
            oDao = new Dao();
		}

        public ManterReingresso(string connectionString, DataBaseTypes dataBaseType)
        {
            oDao = new Dao(connectionString, dataBaseType);
        }

	    #endregion 
        
        #region Métodos

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao, string colunaSort)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(Desligamento));
            dicionario.Add("DSC_NOME", "DscPessoal");
            dicionario.Add("NUM_CPF", "DscCpf");
            dicionario.Add("DSC_FORMA_INGRESSO", "DscFormaIngresso");
            dicionario.Add("DSC_TIPO_EXPEDIENTE", "DscTipoExpediente");
            dicionario.Add("DSC_SIGLA", "DscOrgao");
            dicionario.Add("DAT_PUBLICACAO_NOMEACAO_AGENTE", "DatPublicacaoNomeacaoAgente");

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

            return this.oDao.Select(lstParametros, "plutonium", "VI_REINGRESSO_AGENTE_PUBLICO_REAP", dicionario);

        }

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(Desligamento));
            dicionario.Add("DSC_NOME", "DscPessoal");
            dicionario.Add("NUM_CPF", "DscCpf");
            dicionario.Add("DSC_FORMA_INGRESSO", "DscFormaIngresso");
            dicionario.Add("DSC_TIPO_EXPEDIENTE", "DscTipoExpediente");
            dicionario.Add("DSC_SIGLA", "DscOrgao");
            dicionario.Add("DAT_PUBLICACAO_NOMEACAO_AGENTE", "DatPublicacaoNomeacaoAgente");

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
            return this.oDao.Select(lstParametros, "plutonium", "VI_REINGRESSO_AGENTE_PUBLICO_REAP", dicionario);
        }

        public void PrepararInclusao()
        {
            oReingresso = new Desligamento(oDao);
        }

        public Dictionary<string, object> Selecionar(int id)
        {
            oReingresso = new Desligamento(id, oDao);
            return ClassFunctions.GetProperties(oReingresso);
        }

        public CrudActionTypes Salvar(Dictionary<string, object> valores)
        {
            ClassFunctions.SetProperties(oReingresso, valores);
            return oReingresso.Salvar();
        }

        public CrudActionTypes SalvarComUc(Dictionary<string, object> valoresUC, int idDesligamento)
        {
            try
            {
                oDao.StartTransactionMode();
                PrepararInclusao();
                Desligamento oReingresso = new Desligamento(idDesligamento, oDao);
                ClassFunctions.SetProperties(oReingresso, valoresUC);
                AgentePublico oAgente = new AgentePublico(oReingresso.AgentePublico.ID, oDao);
                oAgente.Ativo = true;
                oAgente.Salvar();

                CampoNuloOuInvalidoException ex = oReingresso.ValidarExterno();
                if (ex.Mensagens.Count > 0)
                    throw ex;

                CrudActionTypes evento = oReingresso.Salvar();

                oDao.Commit();
                return evento;
            }
            catch
            {
                oDao.RollBack();
                throw;
            }
        }

        public CrudActionTypes Excluir()
        {
            return oReingresso.Excluir();
        }
        #endregion

    }
}
