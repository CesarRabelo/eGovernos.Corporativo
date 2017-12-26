using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

using Pro.Utils;
using Pro.Dal;
using Platinium.Entidade;
using Negocio;
using Neonium.Entidade;
using Platinium.Entidade;

namespace Platinium.Negocio
{

    public  class Listas
    {

        private  Dao oDao = new Dao();


        #region Localizar


        public  string LocalizarPoderByIdSecretaria(string idSecretaria)
        {
            Secretaria oSecretaria = new Secretaria(Convert.ToInt32(idSecretaria), oDao);
            return oSecretaria.Poder.ID.ToString();
        }

        public  string LocalizarTipoByIdOrgao(string idOrgao)
        {
            Orgao oOrgao = new Orgao(Convert.ToInt32(idOrgao), oDao);
            return oOrgao.TipoEntidade.ID.ToString();
        }

        public  string LocalizarOrgao(string tipoentidade)
        {
            Dictionary<string, string> dicionario = Pro.Utils.ClassFunctions.GetMap(typeof(Orgao));
            List<Parameter> lstParametros = new List<Parameter>();
            lstParametros.Add(new Parameter("ID", Convert.ToInt32(tipoentidade), OperationTypes.EqualsTo));
            return oDao.Select(lstParametros, "platinium", "VI_SECRETARIA_SECR", dicionario).Rows[0]["ID"].ToString();
        }

        #endregion

        #region X By Y

        public  DataTable TipoFolhaPagamento  //Para Buscar Item Remuneratório em DDL! 
        {
            get
            {
                List<Parameter> lstParametros = new List<Parameter>();
                lstParametros.Add(new Parameter("Descricao", null, OperationTypes.Null, "ASC"));
                return oDao.Select(lstParametros, "plutonium", "VI_LISTA_TIPO_FOLHA_PAGAMENTO_TIFP", typeof(TipoFolha));
            }
        }

        public  DataTable ItemRemuneratorio  //Para Buscar Item Remuneratório em DDL! 
        {
            get
            {
                List<Parameter> lstParametros = new List<Parameter>();
                lstParametros.Add(new Parameter("Descricao", null, OperationTypes.Null, "ASC"));
                return oDao.Select(lstParametros, "plutonium", "VI_LISTA_ITEM_REMUNERATORIO_ITRE", typeof(ItemRemuneratorio));
            }
        }

        public  DataTable AgentesPublicos  //Para Buscar Agentes Públicos que estão ativos em DDL! 
        {
            get
            {
                List<Parameter> lstParametros = new List<Parameter>();
                lstParametros.Add(new Parameter("DSC_NOME", null, OperationTypes.Null, "ASC"));
                return oDao.Select(lstParametros, "plutonium", "VI_LISTA_AGENTE_PUBLICO_AGPU", typeof(AgentePublico));
            }
        }

        public  DataTable AgentesPublicosPensionista(string id)  //Para Buscar Agentes Públicos que estão ativos em DDL! 
        {
            List<Parameter> lstParametros = new List<Parameter>();
            lstParametros.Add(new Parameter("DSC_NOME", null, OperationTypes.Null, "ASC"));
            lstParametros.Add(new Parameter("ID", Convert.ToInt32(id), OperationTypes.NotEqualsTo));
            return oDao.Select(lstParametros, "plutonium", "VI_LISTA_AGENTE_PUBLICO_AGPU", typeof(AgentePublico));
        }

        public  DataTable TipoDesligamento  //Para Buscar Tipo de Desligamento em DDL! 
        {
            get
            {
                List<Parameter> lstParametros = new List<Parameter>();
                lstParametros.Add(new Parameter("Descricao", null, OperationTypes.Null, "ASC"));
                return oDao.Select(lstParametros, "plutonium", "VI_LISTA_TIPO_DESLIGAMENTO_TIDE", typeof(TipoDesligamento));
            }
        }

        public  DataTable TipoReingresso  //Para Buscar Tipo de Reingresso em DDL! 
        {
            get
            {
                List<Parameter> lstParametros = new List<Parameter>();
                lstParametros.Add(new Parameter("Descricao", null, OperationTypes.Null, "ASC"));
                return oDao.Select(lstParametros, "plutonium", "VI_LISTA_TIPO_REINGRESSO_TIRE", typeof(TipoReingresso));
            }
        }

        public  DataTable TipoItemRemuneratorio  //Para Buscar Tipo Item Remuneratório em DDL! 
        {
            get
            {
                List<Parameter> lstParametros = new List<Parameter>();
                lstParametros.Add(new Parameter("Descricao", null, OperationTypes.Null, "ASC"));
                return oDao.Select(lstParametros, "plutonium", "VI_LISTA_TIPO_ITEM_REMUNERATORIO_TIIR", typeof(TipoItem));
            }
        }


        public  DataTable ClassificacaoItemRemuneratorio  //Para Buscar Classificação Item Remuneratório em DDL! 
        {
            get
            {
                List<Parameter> lstParametros = new List<Parameter>();
                lstParametros.Add(new Parameter("Descricao", null, OperationTypes.Null, "ASC"));
                return oDao.Select(lstParametros, "plutonium", "VI_LISTA_CLASSIFICACAO_ITEM_REMUNERATORIO_CLIR", typeof(ClassificacaoItem));
            }
        }

        public  DataTable TipoAmparo  //Para Buscar Tipo Amparo em DDL! 
        {
            get
            {
                List<Parameter> lstParametros = new List<Parameter>();
                lstParametros.Add(new Parameter("Descricao", null, OperationTypes.Null, "ASC"));
                return oDao.Select(lstParametros, "platinium", "VI_LISTA_TIPO_AMPARO_LEGAL_TIAL", typeof(TipoAmparo));
            }
        }

        public  DataTable Pessoal  //Para Buscar Pessoal em DDL! 
        {
            get
            {
                List<Parameter> lstParametros = new List<Parameter>();
                lstParametros.Add(new Parameter("DescricaoNome", null, OperationTypes.Null, "ASC"));
                return oDao.Select(lstParametros, "plutonium", "VI_LISTA_PESSOAL_PESS", typeof(Pessoal));
            }
        }

        public  DataTable Orgao //Para Buscar Orgão em DDL!
        {
            get
            {
                List<Parameter> lstParametros = new List<Parameter>();
                lstParametros.Add(new Parameter("Descricao", null, OperationTypes.Null, "ASC"));
                return oDao.Select(lstParametros, "platinium", "VI_LISTA_ORGAOS_ORGA", typeof(Orgao));
            }
        }

        public  DataTable Iduso //Para Buscar os identificadores de uso em DDL!
        {
            get
            {
                List<Parameter> lstParametros = new List<Parameter>();
                lstParametros.Add(new Parameter("Descricao", null, OperationTypes.Null, "ASC"));
                return oDao.Select(lstParametros, "platinium", "VI_LISTA_IDUSO_IDUS", typeof(Iduso));
            }
        }

        public  DataTable UnidadeOrcamentaria  //Para Buscar Unidade Orçametaria em DDL! 
        {
            get
            {
                List<Parameter> lstParametros = new List<Parameter>();
                lstParametros.Add(new Parameter("Descricao", null, OperationTypes.Null, "ASC"));
                return oDao.Select(lstParametros, "platinium", "VI_LISTA_UNIDADE_ORCAMENTARIA_UNOR", typeof(UnidadeOrcamentaria));
            }
        }

        public  DataTable FormaIngresso  //Para Buscar Forma de ingresso em DDL! 
        {
            get
            {
                List<Parameter> lstParametros = new List<Parameter>();
                lstParametros.Add(new Parameter("Descricao", null, OperationTypes.Null));
                lstParametros.Add(new Parameter("Codigo", null, OperationTypes.Null, "ASC"));
                return oDao.Select(lstParametros, "platinium", "VI_LISTA_FORMA_INGRESSO_FOIN", typeof(FormaIngresso));
            }
        }

        public  DataTable TipoRelacao  //Para Buscar tipo de relação com o serviço público em DDL! 
        {
            get
            {
                List<Parameter> lstParametros = new List<Parameter>();
                lstParametros.Add(new Parameter("Descricao", null, OperationTypes.Null));
                lstParametros.Add(new Parameter("Codigo", null, OperationTypes.Null, "ASC"));
                return oDao.Select(lstParametros, "platinium", "VI_LISTA_TIPO_RELACAO_TIRE", typeof(TipoRelacao));
            }
        }

        public  DataTable TipoExpediente  //Para Buscar tipo de relação com o serviço público em DDL! 
        {
            get
            {
                List<Parameter> lstParametros = new List<Parameter>();
                lstParametros.Add(new Parameter("Descricao", null, OperationTypes.Null));
                lstParametros.Add(new Parameter("Codigo", null, OperationTypes.Null, "ASC"));
                return oDao.Select(lstParametros, "platinium", "VI_LISTA_TIPO_EXPEDIENTE_TIEX", typeof(TipoExpediente));
            }
        }

        public  DataTable TipoAmparoLegal  //Para Buscar Tipo de Amparo Legal de Expediente de Nomeação ou Posse em DDL! 
        {
            get
            {
                List<Parameter> lstParametros = new List<Parameter>();
                lstParametros.Add(new Parameter("Descricao", null, OperationTypes.Null));
                lstParametros.Add(new Parameter("Codigo", null, OperationTypes.Null, "ASC"));
                return oDao.Select(lstParametros, "platinium", "VI_LISTA_TIPO_AMPARO_LEGAL_TIAL", typeof(TipoAmparo));
            }
        }

        public  DataTable SituacaoFuncional  //Para Buscar Situação Funcional em DDL! 
        {
            get
            {
                List<Parameter> lstParametros = new List<Parameter>();
                lstParametros.Add(new Parameter("Descricao", null, OperationTypes.Null));
                lstParametros.Add(new Parameter("Codigo", null, OperationTypes.Null, "ASC"));
                return oDao.Select(lstParametros, "platinium", "VI_LISTA_SITUACAO_FUNCIONAL_SIFU", typeof(SituacaoFuncional));
            }
        }

        public  DataTable RegimeJuridico  //Para Buscar Regime Jurídico em DDL! 
        {
            get
            {
                List<Parameter> lstParametros = new List<Parameter>();
                lstParametros.Add(new Parameter("Descricao", null, OperationTypes.Null));
                lstParametros.Add(new Parameter("Codigo", null, OperationTypes.Null, "ASC"));
                return oDao.Select(lstParametros, "platinium", "VI_LISTA_REGIME_JURIDICO_REJU", typeof(RegimeJuridico));
            }
        }

        public  DataTable RegimePrevidenciario  //Para Buscar Regime Previdenciario em DDL! 
        {
            get
            {
                List<Parameter> lstParametros = new List<Parameter>();
                lstParametros.Add(new Parameter("Descricao", null, OperationTypes.Null));
                lstParametros.Add(new Parameter("Codigo", null, OperationTypes.Null, "ASC"));
                return oDao.Select(lstParametros, "platinium", "VI_LISTA_REGIME_PREVIDENCIARIO_REPR", typeof(RegimePrevidenciario));
            }
        }

        public  DataTable Sexo  //Para Buscar Sexo em DDL! 
        {
            get
            {
                List<Parameter> lstParametros = new List<Parameter>();
                lstParametros.Add(new Parameter("Descricao", null, OperationTypes.Null));
                lstParametros.Add(new Parameter("Codigo", null, OperationTypes.Null, "ASC"));
                return oDao.Select(lstParametros, "plutonium", "VI_LISTA_SEXO_SEXO", typeof(Sexo));
            }
        }

        public  DataTable TipoPisPasep  //Para Buscar Tipo PIS/PASEP em DDL! 
        {
            get
            {
                List<Parameter> lstParametros = new List<Parameter>();
                lstParametros.Add(new Parameter("Descricao", null, OperationTypes.Null));
                lstParametros.Add(new Parameter("Codigo", null, OperationTypes.Null, "ASC"));
                return oDao.Select(lstParametros, "plutonium", "VI_LISTA_TIPO_PIS_PASEP_TIPP", typeof(TipoPisPasep));
            }
        }

        public  DataTable GrauInstrucao  //Para Buscar Grau Instrução em DDL! 
        {
            get
            {
                List<Parameter> lstParametros = new List<Parameter>();
                lstParametros.Add(new Parameter("Descricao", null, OperationTypes.Null));
                lstParametros.Add(new Parameter("Codigo", null, OperationTypes.Null, "ASC"));
                return oDao.Select(lstParametros, "plutonium", "VI_LISTA_GRAU_INSTRUCAO_GRIN", typeof(GrauInstrucao));
            }
        }

        public  DataTable EstadoCivil  //Para Buscar Estado Civil em DDL! 
        {
            get
            {
                List<Parameter> lstParametros = new List<Parameter>();
                lstParametros.Add(new Parameter("Descricao", null, OperationTypes.Null));
                lstParametros.Add(new Parameter("Codigo", null, OperationTypes.Null, "ASC"));
                return oDao.Select(lstParametros, "plutonium", "VI_LISTA_ESTADO_CIVIL_ESCI", typeof(EstadoCivil));
            }
        }

        public  DataTable Cargo  //Para Buscar Cargo em DDL! 
        {
            get
            {
                List<Parameter> lstParametros = new List<Parameter>();
                lstParametros.Add(new Parameter("DescricaoCargo", null, OperationTypes.Null, "ASC"));
                return oDao.Select(lstParametros, "plutonium", "VI_LISTA_CARGO_CARG", typeof(Cargo));
            }
        }

        public  DataTable Estado  //Para Buscar Estado em DDL! 
        {
            get
            {
                List<Parameter> lstParametros = new List<Parameter>();
                lstParametros.Add(new Parameter("SiglaEstado", null, OperationTypes.Null, "ASC"));
                return oDao.Select(lstParametros, "platinium", "VI_LISTA_ESTADO_ESTA", typeof(Endereco));
            }
        }

        public  DataTable LocalidadeEnd(string estado)  //Para Buscar Estado em DDL! 
        {
            Dictionary<string, string> dicionario = Pro.Utils.ClassFunctions.GetMap(typeof(Endereco));
            List<Parameter> lstParametros = new List<Parameter>();
            lstParametros.Add(new Parameter("SiglaEstado", estado, OperationTypes.EqualsTo));
            lstParametros.Add(new Parameter("Localidade", null, OperationTypes.Null, "ASC"));
            return oDao.Select(lstParametros, "platinium", "VI_LISTA_LOCALIDADE_ENDERECO_LOEN", typeof(Endereco));
        }

        public  DataTable Bairro(string estado, string localidade)  //Para Buscar Bairro em DDL! 
        {
            Dictionary<string, string> dicionario = Pro.Utils.ClassFunctions.GetMap(typeof(Endereco));
            List<Parameter> lstParametros = new List<Parameter>();
            lstParametros.Add(new Parameter("SiglaEstado", estado, OperationTypes.EqualsTo));
            lstParametros.Add(new Parameter("Localidade", localidade, OperationTypes.EqualsTo));
            lstParametros.Add(new Parameter("Bairro", null, OperationTypes.Null, "ASC"));
            return oDao.Select(lstParametros, "platinium", "VI_LISTA_BAIRRO_BAIR", typeof(Endereco));
        }

        public  DataTable Cep(String cep)  //Para Buscar Cep em DDL! 
        {

            {
                List<Parameter> lstParametros = new List<Parameter>();
                lstParametros.Add(new Parameter("Cep", cep, OperationTypes.EqualsTo, "ASC"));
                return oDao.Select(lstParametros, "platinium", "VI_LISTA_CEP", typeof(Endereco));
            }
        }

        #endregion

        # region BuscarEndereco
        public  Dictionary<string, object> BuscarEndereco(string cep)
        {
            if (string.IsNullOrEmpty(cep))
                return null;

            Dictionary<string, string> dicionario = new Dictionary<string, string>();
            dicionario.Add("DSC_CEP", "Cep");
            dicionario.Add("DSC_UF", "SiglaEstado");
            dicionario.Add("DSC_LOCALIDADE", "Localidade");
            dicionario.Add("DSC_BAIRRO", "Bairro");
            dicionario.Add("DSC_LOGRADOURO", "Logradouro");
            dicionario.Add("DSC_COMPLEMENTO", "Complemento");

            DataTable dctResultado = new Listas().Cep(cep);
            if (dctResultado.Rows.Count != 0)
            {
                Dictionary<string, object> Valores = new Dictionary<string, object>();
                Valores.Add("Cep", dctResultado.Rows[0]["Cep"]);
                Valores.Add("SiglaEstado", dctResultado.Rows[0]["SiglaEstado"]);
                Valores.Add("Localidade", dctResultado.Rows[0]["Localidade"]);
                Valores.Add("Bairro", dctResultado.Rows[0]["Bairro"]);
                Valores.Add("Logradouro", dctResultado.Rows[0]["Logradouro"]);
                Valores.Add("Complemento", dctResultado.Rows[0]["Complemento"]);
                return Valores;
            }
            else
                return null;
        }

        public  DataTable BuscarEndereco(string estado, string localidade, string bairro, string logradouro, string campoOrdenacao, string direcao)
        {
            if (string.IsNullOrEmpty(estado) || string.IsNullOrEmpty(localidade))
                throw new CampoInvalidoException("É necessário selecionar o estado e Isento localidade.");
            Dictionary<string, string> dicionario = new Dictionary<string, string>();

            List<Parameter> lstParametros = new List<Parameter>();

            if (!string.IsNullOrEmpty(estado))
                lstParametros.Add(new Parameter("DSC_UF", estado, OperationTypes.EqualsTo));

            if (!string.IsNullOrEmpty(localidade))
                lstParametros.Add(new Parameter("DSC_LOCALIDADE", localidade, OperationTypes.EqualsTo));

            if (!string.IsNullOrEmpty(bairro))
                lstParametros.Add(new Parameter("DSC_BAIRRO", bairro, OperationTypes.EqualsTo));

            if (!string.IsNullOrEmpty(logradouro))
                lstParametros.Add(new Parameter("DSC_LOGRADOURO", logradouro, OperationTypes.Like));

            return oDao.Select(lstParametros, "platinium", "TB_CEP", new Dictionary<string, string>());

        }

        public  DataTable OrigemReceitaByIdCategoria(string idCategoria)
        {
            Dictionary<string, string> dicionario = Pro.Utils.ClassFunctions.GetMap(typeof(OrigemReceita));
            List<Parameter> lstParametros = new List<Parameter>();
            lstParametros.Add(new Parameter("CategoriaEconomica", Convert.ToInt32(idCategoria), OperationTypes.EqualsTo));
            lstParametros.Add(new Parameter("Descricao", null, OperationTypes.Null, "ASC"));
            return oDao.Select(lstParametros, "VI_LISTA_ORIGEM_RECEITA", dicionario);
        }
        public  DataTable UnidadeGestoraByIdOrgao(string idOrgao)
        {
            Dictionary<string, string> dicionario = Pro.Utils.ClassFunctions.GetMap(typeof(UnidadeGestora));
            List<Parameter> lstParametros = new List<Parameter>();
            lstParametros.Add(new Parameter("Entidade", Convert.ToInt32(idOrgao), OperationTypes.EqualsTo));
            lstParametros.Add(new Parameter("Descricao", null, OperationTypes.Null, "ASC"));
            return oDao.Select(lstParametros, "platinium", "VI_LISTA_UNIDADE_GESTORA_UNGE", dicionario);
        }
        public  DataTable TipoByIdOrgao(int idOrgao)
        {
            Dictionary<string, string> dicionario = Pro.Utils.ClassFunctions.GetMap(typeof(TipoEntidade));
            List<Parameter> lstParametros = new List<Parameter>();
            lstParametros.Add(new Parameter("Orgao", Convert.ToInt32(idOrgao), OperationTypes.EqualsTo));
            lstParametros.Add(new Parameter("Descricao", null, OperationTypes.Null, "ASC"));
            return oDao.Select(lstParametros, "platinium", "VI_LISTA_TIPO_ENTIDADE_TIEN", dicionario);
        }

        public  string CategoriaEconomicaDespesabyCodigo(string codigo)
        {
            EconomicaDeDespesa oCatEconomica = new EconomicaDeDespesa(codigo, oDao);
            return oCatEconomica.ID.ToString();
        }

        public  string GrupoDespesabyCodigo(string codigo)
        {
            GrupoDespesa oGrupoDespesa = new GrupoDespesa(codigo, oDao);
            return oGrupoDespesa.ID.ToString();
        }

        public  string ModalidadebyCodigo(string codigo)
        {
            ModalidadeAplicacao oModalidadeAplicacao = new ModalidadeAplicacao(codigo, oDao);
            return oModalidadeAplicacao.ID.ToString();
        }

        public  string ElementoDespesabyCodigo(string codigo)
        {
            ElementoDeDespesa oElementoDeDespesa = new ElementoDeDespesa(codigo, oDao);
            return oElementoDeDespesa.ID.ToString();
        }

        public  DataTable GrupoProgramabyIdTipoPrograma(string idTipoPrograma)
        {
            Dictionary<string, string> dicionario = Pro.Utils.ClassFunctions.GetMap(typeof(GrupoPrograma));
            List<Parameter> lstParametros = new List<Parameter>();
            lstParametros.Add(new Parameter("TipoPrograma", Convert.ToInt32(idTipoPrograma), OperationTypes.EqualsTo));
            lstParametros.Add(new Parameter("Descricao", null, OperationTypes.Null, "ASC"));
            return oDao.Select(lstParametros, "platinium", "VI_LISTA_GRUPO_PROGRAMA_GRPR", dicionario);
        }

        public  DataTable OrgaosByIdSecretaria(string idSecretaria)
        {
            Dictionary<string, string> dicionario = Pro.Utils.ClassFunctions.GetMap(typeof(Orgao));
            List<Parameter> lstParametros = new List<Parameter>();
            lstParametros.Add(new Parameter("Secretaria", Convert.ToInt32(idSecretaria), OperationTypes.EqualsTo));
            lstParametros.Add(new Parameter("Descricao", null, OperationTypes.Null, "ASC"));
            return oDao.Select(lstParametros, "platinium", "VI_LISTA_ORGAOS_ORGA", dicionario);
        }

        public  DataTable OrigemByIdCategoriaEconomica(string idCategoriaEconomica)
        {
            Dictionary<string, string> dicionario = Pro.Utils.ClassFunctions.GetMap(typeof(OrigemReceita));
            List<Parameter> lstParametros = new List<Parameter>();
            lstParametros.Add(new Parameter("CategoriaEconomica", Convert.ToInt32(idCategoriaEconomica), OperationTypes.EqualsTo));
            lstParametros.Add(new Parameter("Descricao", null, OperationTypes.Null, "ASC"));
            return oDao.Select(lstParametros, "platinium", "VI_LISTA_ORIGEM_ORIG", dicionario);
        }

        public  DataTable EspecieByIdOrigemReceita(string idOrigem)
        {
            Dictionary<string, string> dicionario = Pro.Utils.ClassFunctions.GetMap(typeof(Especie));
            List<Parameter> lstParametros = new List<Parameter>();
            lstParametros.Add(new Parameter("OrigemReceita", Convert.ToInt32(idOrigem), OperationTypes.EqualsTo));
            lstParametros.Add(new Parameter("Descricao", null, OperationTypes.Null, "ASC"));
            return oDao.Select(lstParametros, "platinium", "VI_LISTA_ESPECIE_ESPE", dicionario);
        }

        public  DataTable RubricaByIdEspecie(string idEspecie)
        {
            Dictionary<string, string> dicionario = Pro.Utils.ClassFunctions.GetMap(typeof(RubricaReceita));
            List<Parameter> lstParametros = new List<Parameter>();
            lstParametros.Add(new Parameter("Especie", Convert.ToInt32(idEspecie), OperationTypes.EqualsTo));
            lstParametros.Add(new Parameter("Descricao", null, OperationTypes.Null, "ASC"));
            return oDao.Select(lstParametros, "platinium", "VI_LISTA_RUBRICA_RUBR", dicionario);
        }        

        public  DataTable UnidadeOrcamentariaByIdOrgao(string idOrgao)
        {
            Dictionary<string, string> dicionario = Pro.Utils.ClassFunctions.GetMap(typeof(UnidadeOrcamentaria));
            List<Parameter> lstParametros = new List<Parameter>();
            lstParametros.Add(new Parameter("Orgao", Convert.ToInt32(idOrgao), OperationTypes.EqualsTo));
            lstParametros.Add(new Parameter("Descricao", null, OperationTypes.Null, "ASC"));
            return oDao.Select(lstParametros, "platinium", "VI_LISTA_UNIDADE_ORCAMENTARIA_UNOR", dicionario);
        }

        public  DataTable IdusoByIdFonte(string idFonte)
        {
            Dictionary<string, string> dicionario = Pro.Utils.ClassFunctions.GetMap(typeof(FonteIduso));
            dicionario.Add("dsc_iduso", "Descricao");
            List<Parameter> lstParametros = new List<Parameter>();
            lstParametros.Add(new Parameter("Fonte", Convert.ToInt32(idFonte), OperationTypes.EqualsTo));
            lstParametros.Add(new Parameter("Descricao", null, OperationTypes.Null, "ASC"));
            return oDao.Select(lstParametros, "platinium", "VI_LISTA_IDUSO_FONTE_IDFO", dicionario);
        }

        public  string CategoriaEconomicabyCodigo(string codigo)
        {
            EconomicaDeReceita oEconomicaDeReceita = new EconomicaDeReceita(codigo, oDao);
            return oEconomicaDeReceita.ID.ToString();
        }

        public  string OrigemReceitabyCodigo(string codigo)
        {
            OrigemReceita oOrigemReceita = new OrigemReceita(codigo, oDao);
            return oOrigemReceita.ID.ToString();
        }

        public  string EspeciebyCodigo(string codigo, string codigo2)
        {
            if (codigo.Substring(2, 1) == "0")
            {
                OrigemReceita oOrigemReceita = new OrigemReceita(codigo2, oDao);
                Especie oEspecie = new Especie(codigo, oDao, oOrigemReceita.ID);
                return oEspecie.ID.ToString();
            }
            else
            {
                Especie oEspecie = new Especie(codigo, oDao);
                return oEspecie.ID.ToString();
            }
        }

        public  string RubricabyCodigo(string codigo, string codigo2, string codigo3)
        {


            if (codigo.Substring(3, 1) == "0")
            {
                OrigemReceita oOrigemReceita = new OrigemReceita(codigo3, oDao);
                Especie oEspecie = new Especie(codigo, oDao, oOrigemReceita.ID);
                RubricaReceita oRubricaReceita = new RubricaReceita(codigo, oDao, oEspecie.ID);
                return oRubricaReceita.ID.ToString();
            }
            else
            {
                RubricaReceita oRubricaReceita = new RubricaReceita(codigo, oDao);
                return oRubricaReceita.ID.ToString();
            }
        }


        #endregion

        #region Geral
      
        public  string AnoLoa { get { return "2011"; } }

      
       

        public  string[] BuscarEnderecoKey(string cep, string estado, string localidade, string key)
        {
            if (key.Length < 4)
            {
                string[] avisoCaracteres = new string[1] { "Digite ao menos 4 caracteres para efetuar Isento busca." };
                return avisoCaracteres;
            }

            Dictionary<string, string> dicionario = new Dictionary<string, string>();

            List<Parameter> lstParametros = new List<Parameter>();

            if (!string.IsNullOrEmpty(estado))
                lstParametros.Add(new Parameter("DSC_UF", estado, OperationTypes.EqualsTo));

            if (!string.IsNullOrEmpty(cep))
                lstParametros.Add(new Parameter("DSC_CEP", cep, OperationTypes.EqualsTo));

            if (!string.IsNullOrEmpty(localidade))
                lstParametros.Add(new Parameter("DSC_LOCALIDADE", localidade, OperationTypes.EqualsTo));

            List<string> lstItens = new List<string>();

            DataTable dctResultado = oDao.Select(lstParametros, "platinium", "TB_CEP", new Dictionary<string, string>());

            if (dctResultado.Rows.Count == 0)
            {
                string[] avisoNaoEncontrado = new string[1] { "Nenhum logradouro encontrado em " + localidade + "-" + estado + " com " + key + "." };
                return avisoNaoEncontrado;
            }

            foreach (DataRow oRow in dctResultado.Rows)
            {
                lstItens.Add(oRow["Cep"].ToString().Trim() + " | " + oRow["Logradouro"].ToString().Trim() + " | " + oRow["Complemento"].ToString().Trim() + " | " + oRow["Bairro"].ToString().Trim());
                if (lstItens.Count > 1000)
                    break;
            }
            return lstItens.ToArray();
        }

        public  DataTable Secretarias
        {
            get
            {
                Dictionary<string, string> dicionario = Pro.Utils.ClassFunctions.GetMap(typeof(Secretaria));
                List<Parameter> lstParametros = new List<Parameter>();
                lstParametros.Add(new Parameter("Descricao", null, OperationTypes.Null, "ASC"));
                return oDao.Select(lstParametros, "platinium", "VI_LISTA_SECRETARIA_SECR", dicionario);
            }
        }

        public  DataTable Funcoes
        {
            get
            {
                List<Parameter> lstParametros = new List<Parameter>();
                lstParametros.Add(new Parameter("Codigo", null, OperationTypes.Null, "ASC"));
                return oDao.Select(lstParametros, "TB_FUNCAO_FUNC", typeof(Funcao));
            }
        }

        #endregion

        #region Drop Down Lists

        public  DataTable GrupoArquivo //Para Buscar os grupos de arquivos em DDL!
        {
            get
            {
                List<Parameter> lstParametros = new List<Parameter>();
                lstParametros.Add(new Parameter("Descricao", null, OperationTypes.Null, "ASC"));
                return oDao.Select(lstParametros, "platinium", "VI_LISTA_GRUPO_ARQUIVO_GRAR", typeof(GrupoArquivo));
            }
        }
        
        public  DataTable TipoEnvio //Para Buscar os tipos de envios de arquivos em DDL!
        {
            get
            {
                List<Parameter> lstParametros = new List<Parameter>();
                lstParametros.Add(new Parameter("Descricao", null, OperationTypes.Null, "ASC"));
                return oDao.Select(lstParametros, "platinium", "VI_LISTA_TIPOENVIO", typeof(TipoEnvio));
            }
        }

        public  DataTable ResponsavelEnvio //Para Buscar os responsaveis de envios de arquivos em DDL!
        {
            get
            {
                List<Parameter> lstParametros = new List<Parameter>();
                lstParametros.Add(new Parameter("Descricao", null, OperationTypes.Null, "ASC"));
                return oDao.Select(lstParametros, "platinium", "VI_LISTA_RESPONSAVELENVIO", typeof(ResponsavelEnvio));
            }
        }

        public  DataTable ProdutoOrdenado(string tipoOrdenacao)  //Para Buscar Produto em DDL!
        {
            List<Parameter> lstParametros = new List<Parameter>();
            lstParametros.Add(new Parameter(tipoOrdenacao, null, OperationTypes.Null, "ASC"));
            return oDao.Select(lstParametros, "platinium", "VI_LISTA_PRODUTO_ORDENADO_PROR", typeof(Produto));
        }

        public  DataTable UnidadeGestora //Para Buscar as Unidade Gestora para usar em DDL!
        {
            get
            {
                List<Parameter> lstParametros = new List<Parameter>();
                lstParametros.Add(new Parameter("Descricao", null, OperationTypes.Null, "ASC"));
                return oDao.Select(lstParametros, "platinium", "VI_LISTA_UNIDADE_GESTORA_UNGE", typeof(UnidadeGestora));
            }
        }

        public  DataTable Despesas //Para Buscar rubrica receita em DDL!
        {
            get
            {
                List<Parameter> lstParametros = new List<Parameter>();
                lstParametros.Add(new Parameter("Descricao", null, OperationTypes.Null, "ASC"));
                return oDao.Select(lstParametros, "platinium", "VI_LISTA_DESPESA_DESP", typeof(Despesa));
            }
        }

        public  DataTable Rubrica  //Para Buscar rubrica receita em DDL!
        {
            get
            {
                List<Parameter> lstParametros = new List<Parameter>();
                lstParametros.Add(new Parameter("Descricao", null, OperationTypes.Null, "ASC"));
                return oDao.Select(lstParametros, "platinium", "VI_LISTA_RUBRICA_RUBR", typeof(RubricaReceita));
            }
        }



        public  DataTable AreaAtuacao  //Para Buscar área de atuação em DDL!
        {
            get
            {
                List<Parameter> lstParametros = new List<Parameter>();
                lstParametros.Add(new Parameter("Descricao", null, OperationTypes.Null, "ASC"));
                return oDao.Select(lstParametros, "platinium", "VI_LISTA_AREA_ATUACAO_ARAT", typeof(AreaAtuacao));
            }
        }



        public  DataTable GrupoPrograma //Para Buscar Grupo Programa em DDL!
        {
            get
            {
                List<Parameter> lstParametros = new List<Parameter>();
                lstParametros.Add(new Parameter("Descricao", null, OperationTypes.Null, "ASC"));
                return oDao.Select(lstParametros, "platinium", "VI_LISTA_GRUPO_PROGRAMA_GRPR", typeof(GrupoPrograma));
            }
        }

        public  DataTable GrupoFonte //Para Buscar Grupo Fonte em DDL!
        {
            get
            {
                List<Parameter> lstParametros = new List<Parameter>();
                lstParametros.Add(new Parameter("Descricao", null, OperationTypes.Null, "ASC"));
                return oDao.Select(lstParametros, "platinium", "VI_LISTA_GRUPO_FONTE_GRFO", typeof(GrupoFonte));
            }
        }

        public  DataTable Unidade //Para Buscar Unidade em DDL!
        {
            get
            {
                List<Parameter> lstParametros = new List<Parameter>();
                lstParametros.Add(new Parameter("DescricaoUnidade", null, OperationTypes.Null, "ASC"));
                return oDao.Select(lstParametros, "platinium", "VI_LISTA_UNIDADE_UNID", typeof(Unidade));
            }
        }



        public  DataTable Eixos //Para Buscar Eixo em DDL!
        {
            get
            {
                List<Parameter> lstParametros = new List<Parameter>();
                lstParametros.Add(new Parameter("Descricao", null, OperationTypes.Null, "ASC"));
                return oDao.Select(lstParametros, "platinium", "VI_LISTA_EIXO_EIXO", typeof(Eixo));
            }
        }

        public  DataTable CatEconomicaDespesa //Para Buscar Categoria Economica de Despesa em DDL!
        {
            get
            {
                List<Parameter> lstParametros = new List<Parameter>();
                lstParametros.Add(new Parameter("Descricao", null, OperationTypes.Null, "ASC"));
                return oDao.Select(lstParametros, "platinium", "VI_LISTA_CATEGORIA_ECONOMICA_DESPESA_CEDE", typeof(EconomicaDeDespesa));
            }
        }
        public  DataTable GrupoDespesa //Para Buscar Grupo Despesa em DDL!
        {
            get
            {
                List<Parameter> lstParametros = new List<Parameter>();
                lstParametros.Add(new Parameter("Descricao", null, OperationTypes.Null, "ASC"));
                return oDao.Select(lstParametros, "platinium", "VI_LISTA_GRUPO_DESPESA_GRDE", typeof(GrupoDespesa));
            }
        }

        public  DataTable TipoPrograma //Para Buscar Tipo Programa em DDL!
        {
            get
            {
                List<Parameter> lstParametros = new List<Parameter>();
                lstParametros.Add(new Parameter("Descricao", null, OperationTypes.Null, "ASC"));
                return oDao.Select(lstParametros, "platinium", "VI_LISTA_TIPO_PROGRAMA_TIPR", typeof(TipoPrograma));
            }
        }

        public  DataTable TipoAdministracao //Para Buscar Tipo Programa em DDL!
        {
            get
            {
                List<Parameter> lstParametros = new List<Parameter>();
                lstParametros.Add(new Parameter("Descricao", null, OperationTypes.Null, "ASC"));
                return oDao.Select(lstParametros, "platinium", "VI_LISTA_TIPO_ADMINISTRACAO_TIAD", typeof(TipoAdministracao));
            }
        }

        public  DataTable ElementoDespesa  //Para Buscar Elemento Despesa em DDL!
        {
            get
            {
                List<Parameter> lstParametros = new List<Parameter>();
                lstParametros.Add(new Parameter("Descricao", null, OperationTypes.Null, "ASC"));
                return oDao.Select(lstParametros, "platinium", "VI_LISTA_ELEMENTO_DESPESA_ELDE", typeof(ElementoDeDespesa));
            }
        }

        public  DataTable ModalidadeAplicacao //Para Buscar Modalidade Aplicação em DDL!
        {
            get
            {
                List<Parameter> lstParametros = new List<Parameter>();
                lstParametros.Add(new Parameter("Descricao", null, OperationTypes.Null, "ASC"));
                return oDao.Select(lstParametros, "platinium", "VI_LISTA_MODALIDADE_APLICACAO_MOAP", typeof(ModalidadeAplicacao));
            }
        }


        public  DataTable Entidade //Para Buscar Modalidade Aplicação em DDL!
        {
            get
            {
                List<Parameter> lstParametros = new List<Parameter>();
                lstParametros.Add(new Parameter("Descricao", null, OperationTypes.Null, "ASC"));
                return oDao.Select(lstParametros, "platinium", "VI_LISTA_ENTIDADE_ENTI", typeof(Platinium.Entidade.Entidade));
            }
        }

        public  DataTable Secretaria //Para Buscar Secretaria em DDL!
        {
            get
            {
                List<Parameter> lstParametros = new List<Parameter>();
                lstParametros.Add(new Parameter("Descricao", null, OperationTypes.Null, "ASC"));
                return oDao.Select(lstParametros, "platinium", "VI_LISTA_SECRETARIA_SECR", typeof(Secretaria));
            }
        }

        public  DataTable TipoEntidade  //Para Buscar Tipo Entidade em DDL!
        {
            get
            {
                List<Parameter> lstParametros = new List<Parameter>();
                lstParametros.Add(new Parameter("Descricao", null, OperationTypes.Null, "ASC"));
                return oDao.Select(lstParametros, "platinium", "VI_LISTA_TIPO_ENTIDADE_TIEN", typeof(TipoEntidade));
            }
        }
            
        public  DataTable TipoEntidade2  //Para Buscar Tipo Entidade em DDL!
        {
            get
            {
                List<Parameter> lstParametros = new List<Parameter>();
                lstParametros.Add(new Parameter("Descricao", null, OperationTypes.Null, "ASC"));
                return oDao.Select(lstParametros, "platinium", "VI_LISTA_TIPO_ENTIDADE", typeof(TipoEntidade));
            }
        }

        public  DataTable Funcao  //Para Buscar Função em DDL!
        {
            get
            {
                List<Parameter> lstParametros = new List<Parameter>();
                lstParametros.Add(new Parameter("Descricao", null, OperationTypes.Null, "ASC"));
                return oDao.Select(lstParametros, "platinium", "VI_LISTA_FUNCAO_FUNC", typeof(Funcao));
            }
        }
        public  DataTable SubFuncao  //Para Buscar Subfunção em DDL!
        {
            get
            {
                List<Parameter> lstParametros = new List<Parameter>();
                lstParametros.Add(new Parameter("Descricao", null, OperationTypes.Null, "ASC"));
                return oDao.Select(lstParametros, "platinium", "VI_LISTA_SUBFUNCAO_SUBF", typeof(SubFuncao));
            }
        }


        public  DataTable Poder //Para Buscar Poder em DDL!
        {
            get
            {
                List<Parameter> lstParametros = new List<Parameter>();
                lstParametros.Add(new Parameter("Descricao", null, OperationTypes.Null, "ASC"));
                return oDao.Select(lstParametros, "platinium", "VI_LISTA_PODER_PODE", typeof(Poder));
            }
        }
        public  DataTable Regiao //Para Buscar Região em DDL!
        {
            get
            {
                List<Parameter> lstParametros = new List<Parameter>();
                lstParametros.Add(new Parameter("Descricao", null, OperationTypes.Null, "ASC"));
                return oDao.Select(lstParametros, "platinium", "VI_LISTA_REGIAO_REGI", typeof(Regiao));
            }
        }
        public  DataTable CatEconomicaReceita //Para Buscar Categoria Econômica de Receita em DDL!
        {
            get
            {
                List<Parameter> lstParametros = new List<Parameter>();
                lstParametros.Add(new Parameter("Descricao", null, OperationTypes.Null, "ASC"));
                return oDao.Select(lstParametros, "platinium", "VI_LISTA_CAT_ECONOMICA_RECE", typeof(EconomicaDeReceita));
            }
        }
        public  DataTable OrigemReceita //Para Buscar Origem da Receita em DDL! 
        {
            get
            {
                List<Parameter> lstParametros = new List<Parameter>();
                lstParametros.Add(new Parameter("Descricao", null, OperationTypes.Null, "ASC"));
                return oDao.Select(lstParametros, "platinium", "VI_LISTA_ORIGEM_ORIG", typeof(OrigemReceita));
            }
        }

        public  DataTable Especie //Para Buscar Especie em DDL! 
        {
            get
            {
                List<Parameter> lstParametros = new List<Parameter>();
                lstParametros.Add(new Parameter("Descricao", null, OperationTypes.Null, "ASC"));
                return oDao.Select(lstParametros, "platinium", "VI_LISTA_ESPECIE_ESPE", typeof(Especie));
            }
        }
        public  DataTable Fonte //Para Buscar Fonte em DDL!
        {
            get
            {
                List<Parameter> lstParametros = new List<Parameter>();
                lstParametros.Add(new Parameter("Descricao", null, OperationTypes.Null, "ASC"));
                return oDao.Select(lstParametros, "platinium", "VI_LISTA_FONTE_FONT", typeof(Fonte));
            }
        }
        public  DataTable Produto //Para Buscar Produto em DDL! 
        {
            get
            {
                List<Parameter> lstParametros = new List<Parameter>();
                lstParametros.Add(new Parameter("Descricao", null, OperationTypes.Null, "ASC"));
                return oDao.Select(lstParametros, "platinium", "VI_LISTA_PRODUTO_PROD", typeof(Produto));
            }
        }


        public  DataTable Receita  //Para Buscar Receita em DDL!
        {
            get
            {
                List<Parameter> lstParametros = new List<Parameter>();
                lstParametros.Add(new Parameter("Descricao", null, OperationTypes.Null, "ASC"));
                return oDao.Select(lstParametros, "platinium", "VI_LISTA_RECEITA_RECE", typeof(Receita));
            }
        }

        public  DataTable Esfera //Para Buscar Esfera em DDL! 
        {
            get
            {
                List<Parameter> lstParametros = new List<Parameter>();
                lstParametros.Add(new Parameter("Descricao", null, OperationTypes.Null, "ASC"));
                return oDao.Select(lstParametros, "platinium", "VI_LISTA_ESFERA_ESFE", typeof(Esfera));
            }
        }


        public  DataTable Endereco  //Para Buscar Endereco em DDL! 
        {
            get
            {
                List<Parameter> lstParametros = new List<Parameter>();
                lstParametros.Add(new Parameter("Logradouro", null, OperationTypes.Null, "ASC"));
                return oDao.Select(lstParametros, "platinium", "VI_LISTA_ENDERECO_ENDE", typeof(Endereco));
            }
        }

        public  DataTable Arquivos
        {
            get
            {
                List<Parameter> lstParametros = new List<Parameter>();
                lstParametros.Add(new Parameter("Nome", null, OperationTypes.Null, "ASC"));
                return oDao.Select(lstParametros, "platinium", "VI_LISTA_ARQUIVOS", typeof(Arquivo));
            }
        }

        public  DataTable MetodoComplemento
        {
            get
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("ID", typeof(string));
                dt.Columns.Add("MetodoComplemento", typeof(string));

                DataRow Row1 = dt.NewRow();
                Row1["ID"] = "1";
                Row1["MetodoComplemento"] = "Espaços a direita";
                dt.Rows.Add(Row1);
                DataRow Row2 = dt.NewRow();
                Row2["ID"] = "2";
                Row2["MetodoComplemento"] = "Espaços a esquerda";
                dt.Rows.Add(Row2);
                DataRow Row3 = dt.NewRow();
                Row3["ID"] = "3";
                Row3["MetodoComplemento"] = "Zeros a direita";
                dt.Rows.Add(Row3);
                DataRow Row4 = dt.NewRow();
                Row4["ID"] = "4";
                Row4["MetodoComplemento"] = "Zeros a esquerda";
                dt.Rows.Add(Row4);

                return dt;
            }
        }

        #endregion
      

        public  DataTable Tipo
        {
            get
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Tipo", typeof(string));
                dt.Columns.Add("TipoDsc", typeof(string));

                DataRow Row1 = dt.NewRow();
                Row1["Tipo"] = "string";
                Row1["TipoDsc"] = "String";
                dt.Rows.Add(Row1);
                DataRow Row2 = dt.NewRow();
                Row2["Tipo"] = "number";
                Row2["TipoDsc"] = "Number";
                dt.Rows.Add(Row2);

                return dt;
            }
        }
    }
}
