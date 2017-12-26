using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

using Pro.Utils;
using Pro.Dal;
using Platinium.Entidade;
using Neonium.Entidade;
  
using Negocio;

namespace Platinium.Negocio
{
    public class ManterAgentePublico:IManter
    {
        
        #region Variáveis e Propriedades

        private AgentePublico oAgentePublico;
        private Desligamento oDesligamento;
        private Dao oDao;

        #endregion

        #region Construtores

        public ManterAgentePublico()
		{
            oDao = new Dao();
		}

        public ManterAgentePublico(string connectionString, DataBaseTypes dataBaseType)
        {
            oDao = new Dao(connectionString, dataBaseType);
        }

	    #endregion 
    
        #region Métodos

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao, string colunaSort)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(AgentePublico));
            dicionario.Add("DSC_NOME", "DscPessoal");
            dicionario.Add("NUM_CPF", "DscCpf");
            dicionario.Add("DSC_FORMA_INGRESSO", "DscFormaIngresso");
            dicionario.Add("DSC_TIPO_EXPEDIENTE", "DscTipoExpediente");
            dicionario.Add("DSC_SIGLA", "DscOrgao");


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

            return this.oDao.Select(lstParametros, "plutonium", "VI_AGENTE_PUBLICO_AGPU", dicionario);

        }

        public DataTable Consultar(Dictionary<string, object> filtros, string direcao)
        {
            Dictionary<string, string> dicionario = ClassFunctions.GetMap(typeof(AgentePublico));
            dicionario.Add("DSC_NOME", "DscPessoal");
            dicionario.Add("NUM_CPF", "DscCpf");
            dicionario.Add("DSC_FORMA_INGRESSO", "DscFormaIngresso");
            dicionario.Add("DSC_TIPO_EXPEDIENTE", "DscTipoExpediente");
            dicionario.Add("DSC_SIGLA", "DscOrgao");

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
            return this.oDao.Select(lstParametros, "plutonium", "VI_AGENTE_PUBLICO_AGPU", dicionario);
        }

        public void PrepararInclusao()
        {
            oAgentePublico = new AgentePublico(oDao);
            oDesligamento = new Desligamento(oDao);
        }

        public Dictionary<string, object> Selecionar(int id)
        {
            oAgentePublico = new AgentePublico(id, oDao);
            return ClassFunctions.GetProperties(oAgentePublico);
        }

        public CrudActionTypes Salvar(Dictionary<string, object> valores)
        {
            ClassFunctions.SetProperties(oAgentePublico, valores);
            return oAgentePublico.Salvar();
        }

        public int SalvarRetornandoId(Dictionary<string, object> valores)
        {
            ClassFunctions.SetProperties(oAgentePublico, valores);
            oAgentePublico.Salvar();
            return oAgentePublico.ID;
        }

        public CrudActionTypes Excluir()
        {
            return oAgentePublico.Excluir();
        }

        public CrudActionTypes SalvarComUc(Dictionary<string, object> valoresUC, int idAgente)
        {
            try
            {
                oDao.StartTransactionMode();
                PrepararInclusao();
                ClassFunctions.SetProperties(oDesligamento, valoresUC);
                AgentePublico oAgente = new AgentePublico(idAgente, oDao);
                oAgente.Ativo = false;
                oAgente.Salvar();
                oDesligamento.AgentePublico = oAgente;

                CampoNuloOuInvalidoException ex = oDesligamento.ValidarExterno();
                if (ex.Mensagens.Count > 0)
                    throw ex;

                CrudActionTypes evento = oDesligamento.Salvar(); 
                oDao.Commit();
                return evento;
            }
            catch
            {
                oDao.RollBack();
                throw;
            }
        }

        public string GetNomeAgentePublico(int AgentePublicoID)
        {
            AgentePublico oAgentePublico = new AgentePublico(AgentePublicoID, oDao);
            return "Agente Público: " + oAgentePublico.Pessoal.DescricaoNome;
        }

        #endregion

    }
}
