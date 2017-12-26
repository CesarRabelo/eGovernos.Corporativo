using System;
using System.Data;
using System.Collections.Generic;

using Pro.Utils;
using Pro.Dal;
using Negocio;
using Platinium.Negocio;


namespace Platinium.Comum
{
    public class ExibirRelatorio
    {
        #region Variáveis e Propriedades
        private Dao oDao;
        #endregion

        #region Construtores

        public ExibirRelatorio()
        {
            oDao = new Dao();
        }

        #endregion

        #region Métodos
        public DataTable ListarCabecalho()
        {
            DataTable dtb = new DataTable();
            dtb.Columns.Add("linha1");
            dtb.Columns.Add("linha2");
            dtb.Columns.Add("linha3");
            dtb.Columns.Add("linha4");
            dtb.Columns.Add("rodape");
            dtb.Rows.Add("L 1", "L 11", "L 13", "L 14", "Rodape");
            // oDao.Select("Select * from TB_CONFIGURACOES_CONF", new Dictionary<string, string>());
            dtb.TableName = "ReportHeader";
            //DataSet ds = new DataSet();
            //ds.Tables.Add(dtb);
            //ds.WriteXml("d:\\Cabecalho.xml", XmlWriteMode.WriteSchema);
            return dtb;
        }

        public DataTable ListarCabecalhoPPAProgramaAcao()
        {
            DataTable dtb = new DataTable();
            dtb.Columns.Add("linha1");
            dtb.Columns.Add("linha2");
            dtb.Columns.Add("linha3");
            dtb.Columns.Add("linha4");
            dtb.Columns.Add("rodape");
            dtb.Rows.Add("ESTADO DO CEARÁ", "GOVERNO MUNICIPAL DE SOBRAL", "-", "ANEXO V - DEMONSTRATIVO DO ORÇAMENTO POR UO, FUNÇÃO, SUBFUNÇÃO, PROGRAMA, PROJETO E ATIVIDADE", "Rodape");
            // oDao.Select("Select * from TB_CONFIGURACOES_CONF", new Dictionary<string, string>());
            dtb.TableName = "ReportHeader";
            //DataSet ds = new DataSet();
            //ds.Tables.Add(dtb);
            //ds.WriteXml("d:\\Cabecalho.xml", XmlWriteMode.WriteSchema);
            return dtb;
        }

        public DataTable ListarCabecalhoQDD()
        {
            DataTable dtb = new DataTable();
            dtb.Columns.Add("linha1");
            dtb.Columns.Add("linha2");
            dtb.Columns.Add("linha3");
            dtb.Columns.Add("linha4");
            dtb.Columns.Add("rodape");
            dtb.Rows.Add("ESTADO DO CEARÁ", "GOVERNO MUNICIPAL DE SOBRAL", "-", "QUADRO DE DETALHAMENTO DAS DESPESAS", "Rodape");
            // oDao.Select("Select * from TB_CONFIGURACOES_CONF", new Dictionary<string, string>());
            dtb.TableName = "ReportHeader";
            //DataSet ds = new DataSet();
            //ds.Tables.Add(dtb);
            //ds.WriteXml("d:\\Cabecalho.xml", XmlWriteMode.WriteSchema);
            return dtb;
        }

        //public DataTable ListarCabecalhoQDD2()
        //{
        //    DataTable dtb = new DataTable();
        //    dtb.Columns.Add("linha1");
        //    dtb.Columns.Add("linha2");
        //    dtb.Columns.Add("linha3");
        //    dtb.Columns.Add("linha4");
        //    dtb.Columns.Add("rodape");
        //    dtb.Rows.Add("ESTADO DO CEARÁ", "GOVERNO MUNICIPAL DE SOBRAL", "-", "QUADRO DE DETALHAMENTO DAS DESPESAS 2", "Rodape");
        //    // oDao.Select("Select * from TB_CONFIGURACOES_CONF", new Dictionary<string, string>());
        //    dtb.TableName = "ReportHeader";
        //    //DataSet ds = new DataSet();
        //    //ds.Tables.Add(dtb);
        //    //ds.WriteXml("d:\\Cabecalho.xml", XmlWriteMode.WriteSchema);
        //    return dtb;
        //}

        public DataTable ListarCabecalhoAcaoFuncaoSub()
        {
            DataTable dtb = new DataTable();
            dtb.Columns.Add("linha1");
            dtb.Columns.Add("linha2");
            dtb.Columns.Add("linha3");
            dtb.Columns.Add("linha4");
            dtb.Columns.Add("rodape");
            dtb.Rows.Add("ESTADO DO CEARÁ", "GOVERNO MUNICIPAL DE SOBRAL", "-", "AÇÕES, FUNÇÕES E SUBFUNÇÕES", "Rodape");
            // oDao.Select("Select * from TB_CONFIGURACOES_CONF", new Dictionary<string, string>());
            dtb.TableName = "ReportHeader";
            //DataSet ds = new DataSet();
            //ds.Tables.Add(dtb);
            //ds.WriteXml("d:\\Cabecalho.xml", XmlWriteMode.WriteSchema);
            return dtb;
        }
        public DataTable ListarCabecalhoAnexoII()
        {
            DataTable dtb = new DataTable();
            dtb.Columns.Add("linha1");
            dtb.Columns.Add("linha2");
            dtb.Columns.Add("linha3");
            dtb.Columns.Add("linha4");
            dtb.Columns.Add("rodape");
            dtb.Rows.Add("ESTADO DO CEARÁ", "GOVERNO MUNICIPAL DE SOBRAL", "LEI ORÇAMENTÁRIA ANUAL Nº 1037 DE 04/11/2010", "ANEXO II - DEMONSTRATIVO DA RECEITA POR FONTE E DA DESPESA POR UNIDADE ORCAMENTÁRIA", "Rodape");
            // oDao.Select("Select * from TB_CONFIGURACOES_CONF", new Dictionary<string, string>());
            dtb.TableName = "ReportHeader";
            //DataSet ds = new DataSet();
            //ds.Tables.Add(dtb);
            //ds.WriteXml("d:\\Cabecalho.xml", XmlWriteMode.WriteSchema);
            return dtb;
        }

        public DataTable ListarCabecalhoAnexoIII()
        {
            DataTable dtb = new DataTable();
            dtb.Columns.Add("linha1");
            dtb.Columns.Add("linha2");
            dtb.Columns.Add("linha3");
            dtb.Columns.Add("linha4");
            dtb.Columns.Add("rodape");
            dtb.Rows.Add("ESTADO DO CEARÁ", "GOVERNO MUNICIPAL DE SOBRAL", "PROJETO DE LEI 2011", "ANEXO III - DEMONSTRATIVO DA RECEITA POR FONTE E DA DESPESA POR FUNÇÃO", "Rodape");
            // oDao.Select("Select * from TB_CONFIGURACOES_CONF", new Dictionary<string, string>());
            dtb.TableName = "ReportHeader";
            //DataSet ds = new DataSet();
            //ds.Tables.Add(dtb);
            //ds.WriteXml("d:\\Cabecalho.xml", XmlWriteMode.WriteSchema);
            return dtb;
        }

        public DataTable ListarCabecalhoAnexoIV()
        {
            DataTable dtb = new DataTable();
            dtb.Columns.Add("linha1");
            dtb.Columns.Add("linha2");
            dtb.Columns.Add("linha3");
            dtb.Columns.Add("linha4");
            dtb.Columns.Add("rodape");
            dtb.Rows.Add("ESTADO DO CEARÁ", "GOVERNO MUNICIPAL DE SOBRAL", "LEI ORÇAMENTÁRIA ANUAL Nº 1037 DE 04/11/2010", "ANEXO IV - DEMONSTRATIVO DA DESPESA POR UNIDADE ORÇAMENTÁRIA", "Rodape");
            // oDao.Select("Select * from TB_CONFIGURACOES_CONF", new Dictionary<string, string>());
            dtb.TableName = "ReportHeader";
            //DataSet ds = new DataSet();
            //ds.Tables.Add(dtb);
            //ds.WriteXml("d:\\Cabecalho.xml", XmlWriteMode.WriteSchema);
            return dtb;
        }
        public DataTable ListarCabecalhoAnexoV()
        {
            DataTable dtb = new DataTable();
            dtb.Columns.Add("linha1");
            dtb.Columns.Add("linha2");
            dtb.Columns.Add("linha3");
            dtb.Columns.Add("linha4");
            dtb.Columns.Add("rodape");
            dtb.Rows.Add("ESTADO DO CEARÁ", "GOVERNO MUNICIPAL DE SOBRAL", "-", "ANEXO V - INSTRUÇÃO NORMATIVA", "Rodape");
            // oDao.Select("Select * from TB_CONFIGURACOES_CONF", new Dictionary<string, string>());
            dtb.TableName = "ReportHeader";
            //DataSet ds = new DataSet();
            //ds.Tables.Add(dtb);
            //ds.WriteXml("d:\\Cabecalho.xml", XmlWriteMode.WriteSchema);
            return dtb;
        }
        public DataTable ListarCabecalhoAnexoVI()
        {
            DataTable dtb = new DataTable();
            dtb.Columns.Add("linha1");
            dtb.Columns.Add("linha2");
            dtb.Columns.Add("linha3");
            dtb.Columns.Add("linha4");
            dtb.Columns.Add("rodape");
            dtb.Rows.Add("ESTADO DO CEARÁ", "GOVERNO MUNICIPAL DE SOBRAL", "LEI ORÇAMENTÁRIA ANUAL Nº 1037 DE 04/11/2010", "ANEXO VI - ADENDO V A PORTARIA SOF Nº 08, DE 04 DE FEVEREIRO DE 1985 (ANEXO VI, DA LEI Nº 4.320/64)", "Rodape");
            // oDao.Select("Select * from TB_CONFIGURACOES_CONF", new Dictionary<string, string>());
            dtb.TableName = "ReportHeader";
            //DataSet ds = new DataSet();
            //ds.Tables.Add(dtb);
            //ds.WriteXml("d:\\Cabecalho.xml", XmlWriteMode.WriteSchema);
            return dtb;
        }

        public DataTable ListarCabecalhoAnexoVII()
        {
            DataTable dtb = new DataTable();
            dtb.Columns.Add("linha1");
            dtb.Columns.Add("linha2");
            dtb.Columns.Add("linha3");
            dtb.Columns.Add("linha4");
            dtb.Columns.Add("rodape");
            dtb.Rows.Add("ESTADO DO CEARÁ", "GOVERNO MUNICIPAL DE SOBRAL", "LEI ORÇAMENTÁRIA ANUAL Nº 1037 DE 04/11/2010", "ANEXO VII - ADENDO VI A PORTARIA SOF Nº 08, DE 04 DE FEVEREIRO DE 1985 (ANEXO VII, DA LEI Nº 4.320/64)", "Rodape");
            // oDao.Select("Select * from TB_CONFIGURACOES_CONF", new Dictionary<string, string>());
            dtb.TableName = "ReportHeader";
            //DataSet ds = new DataSet();
            //ds.Tables.Add(dtb);
            //ds.WriteXml("d:\\Cabecalho.xml", XmlWriteMode.WriteSchema);
            return dtb;
        }

        public DataTable ListarCabecalhoAnexoVIII()
        {
            DataTable dtb = new DataTable();
            dtb.Columns.Add("linha1");
            dtb.Columns.Add("linha2");
            dtb.Columns.Add("linha3");
            dtb.Columns.Add("linha4");
            dtb.Columns.Add("rodape");
            dtb.Rows.Add("ESTADO DO CEARÁ", "GOVERNO MUNICIPAL DE SOBRAL", "LEI ORÇAMENTÁRIA ANUAL Nº 1037 DE 04/11/2010", "ANEXO VIII - ADENDO VI A PORTARIA SOF Nº 08, DE 04 DE FEVEREIRO DE 1985 (ANEXO VII, DA LEI Nº 4.320/64)", "Rodape");
            // oDao.Select("Select * from TB_CONFIGURACOES_CONF", new Dictionary<string, string>());
            dtb.TableName = "ReportHeader";
            //DataSet ds = new DataSet();
            //ds.Tables.Add(dtb);
            //ds.WriteXml("d:\\Cabecalho.xml", XmlWriteMode.WriteSchema);
            return dtb;
        }

        #endregion

        #region Relatorios Titanium

        #region Programas > Metas
        public DataTable MetasPorProgramas(Dictionary<string, object> filtros)
        {
            //string sWhere = string.Empty;
            //if (filtros["TipoImovel"] != null)
            //sWhere = "WHERE ID_TIPO_IMOVEL = " + filtros["TipoImovel"].ToString();
            DataTable dtb = this.oDao.Select(new List<Parameter>(), "reports", "vi_rel_metas_programa", new Dictionary<string, string>());
            dtb.TableName = "TB_PRINCIPAL";
            return dtb;
        }

        #endregion

        #region LogAnexoIIPrincipal
        public DataTable LogAnexoIIPrincipal(Dictionary<string, object> filtros)
        {
            List<Parameter> parametros = new List<Parameter>();
            parametros.Add(new Parameter("ano_elaboracao", new Listas().AnoLoa, OperationTypes.EqualsTo));
            //string sWhere = string.Empty;
            //if (filtros["TipoImovel"] != null)
            //sWhere = "WHERE ID_TIPO_IMOVEL = " + filtros["TipoImovel"].ToString();
            DataTable dtb = this.oDao.Select(parametros, "reports", "vi_rel_anexoii_principal", new Dictionary<string, string>());
            dtb.TableName = "TB_PRINCIPAL";
            return dtb;
        }
        public DataTable LogAnexoIISub(Dictionary<string, object> filtros)
        {
            List<Parameter> parametros = new List<Parameter>();
            parametros.Add(new Parameter("ano_loa", new Listas().AnoLoa, OperationTypes.EqualsTo));
            //string sWhere = string.Empty;            
            //if (filtros["TipoImovel"] != null)
            //sWhere = "WHERE ID_TIPO_IMOVEL = " + filtros["TipoImovel"].ToString();
            DataTable dtb = this.oDao.Select(parametros, "reports", "vi_rel_anexoii_sub", new Dictionary<string, string>());
            dtb.TableName = "tb_sub1";
            return dtb;
        }
        #endregion

        #region LogAnexoIIIPrincipal
        public DataTable LogAnexoIIIPrincipal(Dictionary<string, object> filtros)
        {
            //string sWhere = string.Empty;
            //if (filtros["TipoImovel"] != null)
            //sWhere = "WHERE ID_TIPO_IMOVEL = " + filtros["TipoImovel"].ToString();
            DataTable dtb = this.oDao.Select(string.Format(@"select * from reports.vi_rel_demo_funcao_ano vi where vi.ano_elaboracao = '{0}'", new Listas().AnoLoa), new Dictionary<string, string>());
            dtb.TableName = "TB_PRINCIPAL";
            return dtb;
        }
        public DataTable LogAnexoIIISub(Dictionary<string, object> filtros)
        {
            //string sWhere = string.Empty;
            //if (filtros["TipoImovel"] != null)
            //sWhere = "WHERE ID_TIPO_IMOVEL = " + filtros["TipoImovel"].ToString();
            DataTable dtb = this.oDao.Select(string.Format(@"select * from reports.vi_receitas_ano rec where rec.ano_loa = '{0}'", new Listas().AnoLoa), new Dictionary<string, string>());
            dtb.TableName = "tb_sub1";
            return dtb;
        }
        #endregion

        #region LogAnexoIVPrincipal
        public DataTable LogAnexoIVPrincipal(Dictionary<string, object> filtros)
        {
            //string sWhere = string.Empty;
            //if (filtros["TipoImovel"] != null)
            //sWhere = "WHERE ID_TIPO_IMOVEL = " + filtros["TipoImovel"].ToString();
            DataTable dtb = this.oDao.Select(string.Format(@"select * from reports.vi_rel_cons_entidade_ano vi where vi.ano_elaboracao = '{0}'", new Listas().AnoLoa), new Dictionary<string, string>());
            dtb.TableName = "TB_PRINCIPAL";
            return dtb;
        }
        #endregion

        #region LogAnexoV
        public DataTable LogAnexoV(Dictionary<string, object> filtros)
        {
            Dictionary<string, string> dicionario = new Dictionary<string, string>();
            List<Parameter> lstParametros = new List<Parameter>();

            //if (filtros["Banco"] != null)
            //    lstParametros.Add(new Parameter("ISN_BANCO", filtros["Banco"], OperationTypes.EqualsTo));
            //if (filtros["Convenio"] != null)
            //    lstParametros.Add(new Parameter("ISN_CONVENIO_PRAZO", filtros["Convenio"], OperationTypes.EqualsTo));

            DataTable dt = this.oDao.Select(lstParametros, "REPORTS", "VI_ANEXOV_PRINCIPAL", dicionario);
            dt.TableName = "TB_PRINCIPAL";
            return dt;
        }
        #endregion

        #region LogAnexoVIPrincipal
        public DataTable LogAnexoVIPrincipal(Dictionary<string, object> filtros)
        {
            //string sWhere = string.Empty;
            //if (filtros["TipoImovel"] != null)
            //sWhere = "WHERE ID_TIPO_IMOVEL = " + filtros["TipoImovel"].ToString();
            DataTable dtb = this.oDao.Select(string.Format(@"select * from reports.vi_anexoVI_principal vi where vi.ano_elaboracao = '{0}'", new Listas().AnoLoa), new Dictionary<string, string>());
            dtb.TableName = "TB_PRINCIPAL";
            return dtb;
        }
        #endregion

        #region LogAnexoVIIPrincipal
        public DataTable LogAnexoVIIPrincipal(Dictionary<string, object> filtros)
        {
            //string sWhere = string.Empty;
            //if (filtros["TipoImovel"] != null)
            //sWhere = "WHERE ID_TIPO_IMOVEL = " + filtros["TipoImovel"].ToString();
            DataTable dtb = this.oDao.Select(string.Format(@"select * from reports.vi_anexoviii_principal vi  where vi.ano_elaboracao = '{0}'", new Listas().AnoLoa), new Dictionary<string, string>());
            dtb.TableName = "tb_anoxoviii_loa";
            return dtb;
        }
        #endregion

        #region LogAnexoVIIIPrincipal
        public DataTable LogAnexoVIIIPrincipal(Dictionary<string, object> filtros)
        {
            //string sWhere = string.Empty;
            //if (filtros["TipoImovel"] != null)
            //sWhere = "WHERE ID_TIPO_IMOVEL = " + filtros["TipoImovel"].ToString();
            DataTable dtb = this.oDao.Select(string.Format(@"select * from reports.vi_anexoviii_principal vi  where vi.ano_elaboracao = '{0}'", new Listas().AnoLoa), new Dictionary<string, string>());
            dtb.TableName = "tb_anoxoviii_loa";
            return dtb;
        }
        #endregion

        #region LogAnexoIXPrincipal
        public DataTable LogAnexoIXPrincipal(Dictionary<string, object> filtros)
        {
            List<Parameter> parametros = new List<Parameter>();
            parametros.Add(new Parameter("ano_elaboracao", new Listas().AnoLoa, OperationTypes.EqualsTo));
            //string sWhere = string.Empty;
            //if (filtros["TipoImovel"] != null)
            //sWhere = "WHERE ID_TIPO_IMOVEL = " + filtros["TipoImovel"].ToString();
            DataTable dtb = this.oDao.Select(parametros, "reports", "vi_anexoix_principal", new Dictionary<string, string>());
            dtb.TableName = "TB_PRINCIPAL";
            return dtb;
        }
        #endregion

        #region PPAProgramaAcaoPrincipal
        public DataTable PPAProgramaAcaoPrincipal(Dictionary<string, object> filtros)
        {
            //string sWhere = string.Empty;
            //if (filtros["TipoImovel"] = null)
            //sWhere = "WHERE ID_TIPO_IMOVEL = " + filtros["TipoImovel"].ToString();
            DataTable dtb;
            if (filtros["Secretaria"] != null)
                dtb = this.oDao.Select(string.Format(@"select * from reports.vi_DetPrgAcoPro vi where vi.ano_elaboracao = '{0}' and vi.fk_entidade = '{1}'", new Listas().AnoLoa, filtros["Secretaria"]), new Dictionary<string, string>());
            else
                dtb = this.oDao.Select(string.Format(@"select * from reports.vi_DetPrgAcoPro vi where vi.ano_elaboracao = '{0}'", new Listas().AnoLoa), new Dictionary<string, string>());
            dtb.TableName = "tb_principal";
            return dtb;
        }
        #endregion

        #region PPAProgramaAcaoSub
        public DataTable PPAProgramaAcaoSub(Dictionary<string, object> filtros)
        {
            //string sWhere = string.Empty;
            //if (filtros["TipoImovel"] != null)
            //sWhere = "WHERE ID_TIPO_IMOVEL = " + filtros["TipoImovel"].ToString();
            DataTable dtb;
            if (filtros["Secretaria"] != null)
                dtb = this.oDao.Select(string.Format(@"select pro.fk_projeto_lei,
                    prod.cod_produto||'.'||prod.dsc_produto||' - '|| und.cod_unidade as produto,
                    qtd_ano1, qtd_ano2, qtd_ano3, qtd_ano4
                    from ( select plp.fk_projeto_lei,
                    plp.fk_produto,
                    sum(plp.qtd_ano1) as qtd_ano1,
                    sum(plp.qtd_ano2) as qtd_ano2,
                    sum(plp.qtd_ano3) as qtd_ano3,
                    sum(plp.qtd_ano4) as qtd_ano4
                    from titanium.tb_projeto_lei_produto_prlp plp
                    join titanium.tb_projeto_lei_prle pl on plp.fk_projeto_lei = pl.id_projeto_lei_prle
                    join platinium.tb_entidade_enti ent on pl.fk_unidade_orcamentaria = ent.id_entidade_enti
                    where ent.fk_orgao = '{0}'
                    group by plp.fk_projeto_lei, plp.fk_produto) pro
                    join platinium.tb_produto_prod prod on pro.fk_produto = prod.id_produto_prod
                    join platinium.tb_unidade_unid und on prod.fk_unidade_unid = und.id_unidade_unid", filtros["Secretaria"]), new Dictionary<string, string>());
            else
                dtb = this.oDao.Select(string.Format(@"select pro.fk_projeto_lei,
                    prod.cod_produto||'.'||prod.dsc_produto||' - '|| und.cod_unidade as produto,
                    qtd_ano1, qtd_ano2, qtd_ano3, qtd_ano4
                    from ( select plp.fk_projeto_lei,
                    plp.fk_produto,
                    sum(plp.qtd_ano1) as qtd_ano1,
                    sum(plp.qtd_ano2) as qtd_ano2,
                    sum(plp.qtd_ano3) as qtd_ano3,
                    sum(plp.qtd_ano4) as qtd_ano4
                    from titanium.tb_projeto_lei_produto_prlp plp
                    join titanium.tb_projeto_lei_prle pl on plp.fk_projeto_lei = pl.id_projeto_lei_prle
                    join platinium.tb_entidade_enti ent on pl.fk_unidade_orcamentaria = ent.id_entidade_enti
                    group by plp.fk_projeto_lei, plp.fk_produto) pro
                    join platinium.tb_produto_prod prod on pro.fk_produto = prod.id_produto_prod
                    join platinium.tb_unidade_unid und on prod.fk_unidade_unid = und.id_unidade_unid"), new Dictionary<string, string>());

            dtb.TableName = "tb_sub1";
            return dtb;
        }
        #endregion

        #region QDD
        public DataTable relQDD(Dictionary<string, object> filtros)
        {
            Dictionary<string, string> dicionario = new Dictionary<string, string>();
            List<Parameter> lstParametros = new List<Parameter>();

            //if (filtros["Banco"] != null)
            //    lstParametros.Add(new Parameter("ISN_BANCO", filtros["Banco"], OperationTypes.EqualsTo));
            //if (filtros["Convenio"] != null)
            //    lstParametros.Add(new Parameter("ISN_CONVENIO_PRAZO", filtros["Convenio"], OperationTypes.EqualsTo));

            DataTable dt = this.oDao.Select(lstParametros, "REPORTS", "VI_REL_QDD", dicionario);
            dt.TableName = "TB_PRINCIPAL";
            return dt;
        }
        #endregion

        #region QDD2
        public DataTable relQDD2(Dictionary<string, object> filtros)
        {
            Dictionary<string, string> dicionario = new Dictionary<string, string>();
            List<Parameter> lstParametros = new List<Parameter>();

            //if (filtros["Banco"] != null)
            //    lstParametros.Add(new Parameter("ISN_BANCO", filtros["Banco"], OperationTypes.EqualsTo));
            //if (filtros["Convenio"] != null)
            //    lstParametros.Add(new Parameter("ISN_CONVENIO_PRAZO", filtros["Convenio"], OperationTypes.EqualsTo));

            DataTable dt = this.oDao.Select(lstParametros, "REPORTS", "VI_REL_QDD", dicionario);
            dt.TableName = "TB_PRINCIPAL";
            return dt;
        }
        #endregion

        #region PrioridaDeMetas
        public DataTable PrioridadesMetas(Dictionary<string, object> filtros)
        {
            Dictionary<string, string> dicionario = new Dictionary<string, string>();
            List<Parameter> lstParametros = new List<Parameter>();

            //if (filtros["Banco"] != null)
            //    lstParametros.Add(new Parameter("ISN_BANCO", filtros["Banco"], OperationTypes.EqualsTo));
            //if (filtros["Convenio"] != null)
            //    lstParametros.Add(new Parameter("ISN_CONVENIO_PRAZO", filtros["Convenio"], OperationTypes.EqualsTo));

            DataTable dt = this.oDao.Select(lstParametros, "REPORTS", "VI_REL_PRIORIDADES_METAS", dicionario);
            dt.TableName = "TB_PRINCIPAL";
            return dt;
        }
        #endregion

        #endregion

        #region Relatorios Transporte
        #region MarcaModelo
        public DataTable RelMarcaModelo(Dictionary<string, object> filtros)
        {
            Dictionary<string, string> dicionario = new Dictionary<string, string>();
            List<Parameter> lstParametros = new List<Parameter>();

            //if (filtros["Banco"] != null)
            //    lstParametros.Add(new Parameter("ISN_BANCO", filtros["Banco"], OperationTypes.EqualsTo));
            //if (filtros["Convenio"] != null)
            //    lstParametros.Add(new Parameter("ISN_CONVENIO_PRAZO", filtros["Convenio"], OperationTypes.EqualsTo));

            DataTable dt = this.oDao.Select(lstParametros, "neonium", "VI_REL_MARCA_MODELO", dicionario);
            dt.TableName = "VI_REL_MARCA_MODELO";
            return dt;
        }
        #endregion

        #region RelRequisicaoAtendimento
        public DataTable RelRequisicaoAtendimento(Dictionary<string, object> filtros)
        {
            Dictionary<string, string> dicionario = new Dictionary<string, string>();
            List<Parameter> lstParametros = new List<Parameter>();

            //if (filtros["Banco"] != null)
            //    lstParametros.Add(new Parameter("ISN_BANCO", filtros["Banco"], OperationTypes.EqualsTo));
            //if (filtros["Convenio"] != null)
            //    lstParametros.Add(new Parameter("ISN_CONVENIO_PRAZO", filtros["Convenio"], OperationTypes.EqualsTo));

            DataTable dt = this.oDao.Select(lstParametros, "neonium", "VI_REL_REQUISICAO_ATENDIMENTO", dicionario);
            dt.TableName = "VI_REL_REQUISICAO_ATENDIMENTO";
            return dt;
        }
        #endregion

        #region RelRequisicaoVeiculo
        public DataTable RelRequisicaoVeiculo(Dictionary<string, object> filtros)
        {
            Dictionary<string, string> dicionario = new Dictionary<string, string>();
            List<Parameter> lstParametros = new List<Parameter>();

            //if (filtros["Banco"] != null)
            //    lstParametros.Add(new Parameter("ISN_BANCO", filtros["Banco"], OperationTypes.EqualsTo));
            //if (filtros["Convenio"] != null)
            //    lstParametros.Add(new Parameter("ISN_CONVENIO_PRAZO", filtros["Convenio"], OperationTypes.EqualsTo));

            DataTable dt = this.oDao.Select(lstParametros, "neonium", "VI_REL_REQUISICAO_VEICULO", dicionario);
            dt.TableName = "VI_REL_REQUISICAO_VEICULO";
            return dt;
        }
        #endregion

        #region RelRequisicaoMotorista
        public DataTable RelRequisicaoMotorista(Dictionary<string, object> filtros)
        {
            Dictionary<string, string> dicionario = new Dictionary<string, string>();
            List<Parameter> lstParametros = new List<Parameter>();

            //if (filtros["Banco"] != null)
            //    lstParametros.Add(new Parameter("ISN_BANCO", filtros["Banco"], OperationTypes.EqualsTo));
            //if (filtros["Convenio"] != null)
            //    lstParametros.Add(new Parameter("ISN_CONVENIO_PRAZO", filtros["Convenio"], OperationTypes.EqualsTo));

            DataTable dt = this.oDao.Select(lstParametros, "neonium", "VI_REL_REQUISICAO_MOTORISTA", dicionario);
            dt.TableName = "VI_REL_REQUISICAO_MOTORISTA";
            return dt;
        }
        #endregion

        #region RelAtendimentoDespesa
        public DataTable RelAtendimentoDespesa(Dictionary<string, object> filtros)
        {
            Dictionary<string, string> dicionario = new Dictionary<string, string>();
            List<Parameter> lstParametros = new List<Parameter>();

            //if (filtros["Banco"] != null)
            //    lstParametros.Add(new Parameter("ISN_BANCO", filtros["Banco"], OperationTypes.EqualsTo));
            //if (filtros["Convenio"] != null)
            //    lstParametros.Add(new Parameter("ISN_CONVENIO_PRAZO", filtros["Convenio"], OperationTypes.EqualsTo));

            DataTable dt = this.oDao.Select(lstParametros, "neonium", "VI_REL_REQUISICAO_MOTORISTA", dicionario);
            dt.TableName = "VI_REL_REQUISICAO_MOTORISTA";
            return dt;
        }
        #endregion
        #endregion

        #region Relatorios Corporativo

        public DataTable VisualizarArquivo(string id)
        {
            
            Dictionary<string, string> dicionario = new Dictionary<string, string>();
            List<Parameter> lstParametros = new List<Parameter>();

            if (!string.IsNullOrEmpty(id))
                lstParametros.Add(new Parameter("ID_ARQUIVO", Convert.ToInt32(id), OperationTypes.EqualsTo));
            //if (filtros["Convenio"] != null)
            //    lstParametros.Add(new Parameter("ISN_CONVENIO_PRAZO", filtros["Convenio"], OperationTypes.EqualsTo));

            DataTable dt = this.oDao.Select(lstParametros, "platinium", "VI_REL_ARQUIVO_COLUNA", dicionario);
            dt.TableName = "TB_PRINCIPAL";
            return dt;
        }

        #endregion
    }
}
