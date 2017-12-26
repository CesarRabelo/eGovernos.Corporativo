<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucToolBar.ascx.cs" Inherits="Platinium.Web.ucToolBar" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<div id="menu">
    <ul class="menu">
        <li><a href="#" class="parent"><span>Entidades</span></a>
            <ul>
                <li><a href="frmPoder.aspx"><span>Poder</span></a></li>
                <li><a href="frmSecretaria.aspx"><span>Secretaria</span></a></li>
                <li><a href="frmOrgao.aspx"><span>Órgão</span></a></li>
                <li><a href="frmUnidadeGestora.aspx"><span>Unidade Gestora</span></a></li>
                <li><a href="frmUnidadeOrcamentaria.aspx"><span>Unidade Orçamentária</span></a></li>
                <%--<li><a href="frmUnidadeOrcamentaria.aspx"><span>Unidade Orçamentária</span></a></li>--%>
            </ul>
        </li>
        <li><a href="#" class="parent"><span>Despesa</span></a>
            <ul>
                <li><a href="frmEconomicaDeDespesa.aspx">Categoria Econômica</a></li>
                <li><a href="frmGrupoDespesa.aspx">Grupo de Despesa</a></li>
                <li><a href="frmModalidadeAplicacao.aspx">Modalidade de Aplicação</a></li>
                <li><a href="frmElementoDeDespesa.aspx">Elemento de Despesa</a></li>
                <li><a href="frmDespesa.aspx">Natureza da Despesa</a></li>
            </ul>
        </li>
        <li><a href="#" class="parent"><span>Receita</span></a>
            <ul>
                <li><a href="frmEconomicaDeReceita.aspx">Categoria Econômica</a></li>
                <li><a href="frmOrigemReceita.aspx">Origem</a></li>
                <li><a href="frmEspecie.aspx">Espécie</a></li>
                <li><a href="frmRubricaReceita.aspx">Rúbrica</a></li>
                <li><a href="frmReceita.aspx">Natureza da Receita</a></li>
            </ul>
        </li>
        <li><a href="#" class="parent"><span>Eixo</span></a>
            <ul>
                <li><a href="frmEixo.aspx">Eixo</a></li>
                <li><a href="frmAreaAtuacao.aspx">Área de Atuação</a></li>
            </ul>
        </li>
        <li><a href="#" class="parent"><span>Fonte</span></a>
            <ul>
                <li><a href="frmGrupoFonte.aspx">Grupo de Fonte</a></li>
                <li><a href="frmFonte.aspx">Fonte</a></li>
            </ul>
        </li>
        <li><a href="#" class="parent"><span>Produto</span></a>
            <ul>
                <li><a href="frmUnidade.aspx">Unidade</a></li>
                <li><a href="frmProduto.aspx">Produto</a></li>
            </ul>
        </li>
        <li><a href="#" class="parent"><span>Pessoal</span></a>
            <ul>
                <li><a href="frmAgentePublico.aspx">Agente Publico</a></li>
                <li><a href="frmCargo.aspx">Cargo</a></li>
                <li><a href="frmConcessaoItem.aspx">Concessao de Item</a></li>
                <li><a href="frmEstadoCivil.aspx">Estado Civil</a></li>
                <li><a href="frmFolhaPagamento.aspx">Folha de Pagamento</a></li>
                <li><a href="frmFormaIngresso.aspx">Ingresso</a></li>
                <li><a href="frmGrauInstrucao.aspx">Grau de Instrução</a></li>
                <li><a href="frmItemRemuneratorio.aspx">Items Remuneratorios</a></li>
                <li><a href="frmPessoal.aspx">Pessoal</a></li>
                <li><a href="frmRegimeJuridico.aspx">Regime Juridico</a></li>
                <li><a href="frmRegimePrevidenciario.aspx">Regime Previdenciario</a></li>
                <li><a href="frmReingresso.aspx">Reingresso</a></li>
                <li><a href="frmSexo.aspx">Sexo</a></li>
                <li><a href="frmSituacaoFuncional.aspx">Situação Funcional</a></li>
                <li><a href="frmTipoAmparo.aspx">Tipo Amparo</a></li>
                <li><a href="frmTipoDesligamento.aspx">Tipo Desligamento</a></li>
                <li><a href="frmTipoExpediente.aspx">Tipo Expediente</a></li>
                <li><a href="frmTipoFolha.aspx">Tipo Folha</a></li>
                <li><a href="FrmTipoPisPasep.aspx">Tipo Pis/Pasep</a></li>
                <li><a href="frmTipoReingresso.aspx">Tipo de Reingresso</a></li>
                <li><a href="frmTipoRelacao.aspx">Tipo Relação</a></li>

            </ul>
        </li>
        <li><a href="#" class="parent"><span>Cadastros</span></a>
            <ul>
                <li><a href="frmLicenciada.aspx">Licenciada</a></li>
                <li><a href="frmAnoLei.aspx">Leis por Ano</a></li>
                <li><a href="frmTipoEntidade.aspx">Tipo de Entidade</a></li>
                <li><a href="frmTipoPrograma.aspx">Tipo de Programa</a></li>
                <li><a href="frmTipoAdministracao.aspx">Tipo de Administração</a></li>
                <li><a href="frmGrupoPrograma.aspx">Grupo de Programa</a></li>
                <li><a href="frmFuncoes.aspx">Funções</a></li>
                <li><a href="frmSubFuncao.aspx">SubFunções</a></li>
                <li><a href="frmRegiao.aspx">Região</a></li>
                <li><a href="frmLocalidade.aspx">Localidade</a></li>
                <li><a href="frmSituacao.aspx">Situação</a></li>
                <li><a href="frmEsfera.aspx">Esfera</a></li>
                <li><a href="frmTaxa.aspx">Taxa</a></li>
                <li><a href="frmModalidadePagamento.aspx">Modalidade de Pagamento</a></li>
                <li><a href="frmArquivo.aspx">Arquivos</a>
                    <ul>
                        <li><a href="frmTipoEnvio.aspx">Tipo de Envio</a>
                            <li><a href="frmResponsavelEnvio.aspx">Responsável de Envio</a>
                    </ul>
                </li>
                <li><a href="frmResponsavelEnvioArquivo.aspx">Responsável Envio de Arquivos</a></li>
            </ul>
        </li>
        <li><a href="frmArquivosGeral.aspx" class="parent"><span>Arquivos</span></a></li>
    </ul>
    </li> </ul>
</div>
<%--

                <asp:Menu ID="mnUtilitarios" runat="server" Orientation="Horizontal" >
                    <StaticMenuItemStyle CssClass="obj_Menu" />
                    <DynamicHoverStyle CssClass="obj_Menu_SubItem_Hover" />
                    <DynamicMenuStyle CssClass="obj_Menu_SubMenu" />
                    <DynamicMenuItemStyle CssClass="obj_Menu_SubItem" />
                    <StaticHoverStyle CssClass="obj_Menu_Hover" />
                    <Items>
                        <asp:MenuItem Text="PPA">
                            <asp:MenuItem NavigateUrl="~/frmPrograma.aspx" Text="Programas de Governo" />
                            <asp:MenuItem NavigateUrl="~/frmAcao.aspx" Text="Ações por programa" />
                        </asp:MenuItem>
                        <asp:MenuItem Text="LOA">
                            <asp:MenuItem NavigateUrl="~/frmFuncionalProgramatica.aspx" Text="Funcionais programática" />
                            <asp:MenuItem NavigateUrl="~/frmMetas.aspx" Text="Metas por programa e ação" />
                            <asp:MenuItem NavigateUrl="~/frmEspecificacaoDespesa.aspx" Text="Despesas por funcional" />
                            <asp:MenuItem NavigateUrl="~/frmReceitaMovimento.aspx" Text="Receitas da administração indireta" />
                        </asp:MenuItem>
                        <asp:MenuItem Text="Corporativo">
                            <asp:MenuItem Text="Entidades">
                                <asp:MenuItem NavigateUrl="~/frmPoder.aspx" Text="Poder" />
                                <asp:MenuItem NavigateUrl="~/frmSecretaria.aspx" Text="Secretária" />
                                <asp:MenuItem NavigateUrl="~/frmOrgao.aspx" Text="Orgão" />
                                <asp:MenuItem NavigateUrl="~/frmUnidadeOrcamentaria.aspx" Text="Unidade Orçamentária" />
                            </asp:MenuItem>
                            <asp:MenuItem Text="Despesa">
                                <asp:MenuItem NavigateUrl="~/frmEconomicaDeDespesa.aspx" Text="Categoria Econômica" />
                                <asp:MenuItem NavigateUrl="~/frmGrupoDespesa.aspx" Text="Grupo de Despesa" />
                                <asp:MenuItem NavigateUrl="~/frmModalidadeAplicacao.aspx" Text="Modalidade de Aplicacao" />
                                <asp:MenuItem NavigateUrl="~/frmElementoDeDespesa.aspx" Text="Elemento de Despesa" />
                                <asp:MenuItem NavigateUrl="~/frmDespesa.aspx" Text="Natureza da Despesa" />
                            </asp:MenuItem>
                            <asp:MenuItem Text="Receita">
                                <asp:MenuItem NavigateUrl="~/frmEconomicaDeReceita.aspx" Text="Categoria Econômica" />
                                <asp:MenuItem NavigateUrl="~/frmOrigemReceita.aspx" Text="Origem" />
                                <asp:MenuItem NavigateUrl="~/frmEspecie.aspx" Text="Espécie" />
                                <asp:MenuItem NavigateUrl="~/frmRubricaReceita.aspx" Text="Rúbrica" />
                                <asp:MenuItem NavigateUrl="~/frmReceita.aspx" Text="Natureza da Receita" />
                            </asp:MenuItem>
                            <asp:MenuItem Text="Eixo">
                                <asp:MenuItem NavigateUrl="~/frmEixo.aspx" Text="Eixo" />
                                <asp:MenuItem NavigateUrl="~/frmAreaAtuacao.aspx" Text="Area de Atuação" />
                            </asp:MenuItem>
                            <asp:MenuItem Text="Fonte">
                                <asp:MenuItem NavigateUrl="~/frmGrupoFonte.aspx" Text="Grupo de Fonte" />
                                <asp:MenuItem NavigateUrl="~/frmFonte.aspx" Text="Fonte" />
                            </asp:MenuItem>
                            <asp:MenuItem Text="Produto">
                                <asp:MenuItem NavigateUrl="~/frmUnidade.aspx" Text="Unidade" />
                                <asp:MenuItem NavigateUrl="~/frmProduto.aspx" Text="Produto" />
                            </asp:MenuItem>
                            <asp:MenuItem Text="Cadastros">
                                <asp:MenuItem Text="Tipos">
                                    <asp:MenuItem NavigateUrl="~/frmTipoEntidade.aspx" Text="Tipo de Entidade" />
                                    <asp:MenuItem NavigateUrl="~/frmTipoPrograma.aspx" Text="Tipo de Programa" />
                                    <asp:MenuItem NavigateUrl="~/frmTipoAcao.aspx" Text="Tipo de Ação" />
                                </asp:MenuItem>
                                <asp:MenuItem NavigateUrl="~/frmIndicador.aspx" Text="Indicadores" />
                                <asp:MenuItem NavigateUrl="~/frmClassificacaoAcao.aspx" Text="Classificação da ação" />
                                <asp:MenuItem NavigateUrl="~/frmGrupoPrograma.aspx" Text="Grupo programa" />
                                <asp:MenuItem NavigateUrl="~/frmGerente.aspx" Text="Gerente" />
                                <asp:MenuItem NavigateUrl="~/frmFuncoes.aspx" Text="Funções" />
                                <asp:MenuItem NavigateUrl="~/frmSubFuncao.aspx" Text="Sub Funções" />
                                <asp:MenuItem NavigateUrl="~/frmRegiao.aspx" Text="Região" />
                                <asp:MenuItem NavigateUrl="~/frmLocalidade.aspx" Text="Localidade" />
                                <asp:MenuItem NavigateUrl="~/frmSituacao.aspx" Text="Situação" />
                                <asp:MenuItem NavigateUrl="~/frmEsfera.aspx" Text="Esfera   " />
                            </asp:MenuItem>
                        </asp:MenuItem>
                        <asp:MenuItem Text="Administração">
                            <asp:MenuItem Text="Mensagem" />
                        </asp:MenuItem>
                        <asp:MenuItem Text="Relatórios" NavigateUrl="~/Relatorios/relGeral.aspx">--%>
<%--                            <asp:MenuItem Text="Anexo II - Demonstrativo da receita por fonte e da despesa por unidade orçamentária" />
                            <asp:MenuItem Text="Anexo III - Demonstrativo da receita por fonte e da despesa por função" />
                            <asp:MenuItem Text="Anexo IV - Demonstrativo da despesa por unidade orçamentária" />
                            <asp:MenuItem Text="Anexo V - Demonstrativo do orçamento por unidade orçamentária, função, subfunção, programa, projeto" />
                            <asp:MenuItem Text="Anexo VI - Adendo V a portaria SOF Nº 08, de 04 de fevereiro de 1985 (anexo VI, da lei Nº 4.320/64)" />
                            <asp:MenuItem Text="Anexo VII - Adendo VII a portaria SOF Nº 08, de 04 de fevereiro de 1985 (anexo VII, da lei Nº 4.320/64)" />
                            <asp:MenuItem Text="Anexo VIII - Adendo VIII a portaria SOF Nº 08, de 04 de fevereiro de 1985 (anexo VIII, da lei Nº 4.320/64)" />
                            <asp:MenuItem Text="Anexo IX - da lei Nº 4.320/64 Demonstrativo da despesa por órgão e funções" />
                            <asp:MenuItem Text="Lei Orçamentária anual Nº 1037 de 04/11/2010 Quadro de detalhamento das despesas" />
                            <asp:MenuItem Text="Plano Plurianual - Projeto de lei 2010-2013 Sumarização por função e subfunção" />
                            <asp:MenuItem Text="Plano Plurianual - 2010-2013 Demonstrativo das fontes por unidade orçamentária" />
                            <asp:MenuItem Text="Plano Plurianual - 2010-2013 Anexo I - Macrotemas e Programas" />
                            <asp:MenuItem Text="Plano Plurianual - 2010-2013 Anexo II - Programas e Ações por função e subfunção" />                            
                            <asp:MenuItem Text="Plano Plurianual - 2010-2013 Anexo III - Programas de Governo" />
                            <asp:MenuItem Text="Plano Plurianual - 2010-2013 Anexo de prioridades e metas" />
                      </asp:MenuItem>
                    </Items>
                </asp:Menu>
            </td>
        </tr>
    </table>--%>
