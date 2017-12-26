<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true"
    CodeBehind="frmAgentePublico.aspx.cs" Inherits="Platinium.Web.frmAgentePublico" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="Pro.Controls" Namespace="Pro.Controls" TagPrefix="pro" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/ucCabecalhoObrigatorio.ascx" TagName="ucObrigatorio" TagPrefix="obr" %>
<%@ Register Src="UserControls/ucEndereco.ascx" TagName="ucEndereco" TagPrefix="uc1" %>
<%@ Register Src="UserControls/ucAgenteItem.ascx" TagName="ucAgenteItem" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphPadrao" runat="server">
    <div class="padding">
        <div id="box-tit-pagina">
            <div class="t">
                <div class="t">
                    <div class="t">
                    </div>
                </div>
            </div>
            <div class="m">
                <div class="tit-pagina icon-title">
                    <h2>
                        <pro:ProLabel ID="lblTitulo" runat="server"></pro:ProLabel></h2>
                </div>
            </div>
            <div class="b">
                <div class="b">
                    <div class="b">
                    </div>
                </div>
            </div>
        </div>
        <div id="Content">
            <div class="t">
                <div class="t">
                    <div class="t">
                    </div>
                </div>
            </div>
            <div class="m">
                <div id="LAY_FILTRO">
                    <pro:ProPanel ID="pnlConsulta" GroupingText="Filtros para busca" runat="server">
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="lblBuscaPor" runat="server" Text="Buscar por:" CssClass="LabelFiltro"></asp:Label>
                                </td>
                                <td>
                                    <pro:ProDropDownList ID="ddlCampoBusca" runat="server" CssClass="obj_Controle" />
                                    <asp:Label ID="lblBusca" runat="server"></asp:Label><pro:ProTextBox ID="txtBusca"
                                        runat="server" Width="200px" CssClass="obj_Controle" ToolTip="Informe o texto para busca."></pro:ProTextBox>
                                    <asp:Button ID="btnBuscar" runat="server" CssClass="obj_Btn_Command" Text="Buscar"
                                        Width="50px" />
                                    <asp:Button ID="btnNovo" runat="server" Text="Novo" CssClass="obj_Btn_Command" CommandName="Novo"
                                        Width="65px" />
                                    <asp:Button ID="btnLimpar" runat="server" Text="Limpar" CssClass="obj_Btn_Command"
                                        Width="65px" />
                                </td>
                            </tr>
                        </table>
                    </pro:ProPanel>
                </div>
                <asp:MultiView ID="mtvPrincipal" runat="server" ActiveViewIndex="0">
                    <asp:View ID="vwListagem" runat="server">
                        <pro:ProPanel ID="pnlListagem" BorderWidth="0px" runat="server" Height="100%" Width="100%">
                            <div class="obj_Conteudo txt_padrao">
                                <pro:ProGridView ID="grdListagem" runat="server" AllowPaging="True" AllowSorting="True"
                                    AutoGenerateColumns="False" AutoPostBack="True" CssClass="obj_Grid" DataKeyNames="Id"
                                    EnableModelValidation="True" GridLines="None" Width="100%" OnRowCommand="grdListagem_RowCommand">
                                    <HeaderStyle CssClass="obj_Grid_Header" />
                                    <AlternatingRowStyle CssClass="obj_Grid_AlternatingRow" />
                                    <RowStyle CssClass="obj_Grid_Row" />
                                    <SelectedRowStyle CssClass="obj_Grid_SelectedRow" />
                                    <PagerStyle CssClass="obj_Grid_Pager" />
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemStyle Width="20px" HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgEdit" ImageUrl="~/Parts/Thema2/images/icons_container/edit-archive.png"
                                                    runat="server" CommandName="Edit" ToolTip="Editar" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemStyle Width="20px" HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgDelete" ImageUrl="~/Parts/Thema2/images/icons_container/delete.png"
                                                    runat="server" CommandName="Delete" ToolTip="Deletar" OnClientClick="messageBox(this,'PERGUNTA','SIMNAO','Confirmação de exclusão','Deseja realmente excluir este item ?',''); return false;" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemStyle Width="20px" HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgDesligamento" CommandName="DESLIGAMENTO" ImageUrl="~/Parts/Thema2/images/icons_container/extinguir.png"
                                                    runat="server" ToolTip="Desligamento" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="DscPessoal" HeaderText="Nome" ItemStyle-Width="20%" SortExpression="DscPessoal"
                                            HeaderStyle-HorizontalAlign="Left">
                                            <ItemStyle Width="20%" />
                                            <HeaderStyle Width="20%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DscCpf" HeaderText="CPF" ItemStyle-Width="10%" SortExpression="DscCpf"
                                            HeaderStyle-HorizontalAlign="Left">
                                            <ItemStyle Width="10%" />
                                            <HeaderStyle Width="10%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DscOrgao" HeaderText="Órgão" ItemStyle-Width="10%" SortExpression="DscOrgao"
                                            HeaderStyle-HorizontalAlign="Left">
                                            <ItemStyle Width="10%" />
                                            <HeaderStyle Width="10%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DscFormaIngresso" HeaderText="Forma de ingresso" ItemStyle-Width="25%"
                                            SortExpression="DscFormaIngresso" HeaderStyle-HorizontalAlign="Left">
                                            <ItemStyle Width="25%" />
                                            <HeaderStyle Width="25%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DscTipoExpediente" HeaderText="Tipo de nomeação" ItemStyle-Width="25%"
                                            SortExpression="DscTipoExpediente" HeaderStyle-HorizontalAlign="Left">
                                            <ItemStyle Width="25%" />
                                            <HeaderStyle Width="25%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DataPublicacaoNomeacao" HeaderText="publicação da nomeação"
                                            ItemStyle-Width="10%" SortExpression="DataPublicacaoNomeacao" HeaderStyle-HorizontalAlign="Left"
                                            DataFormatString="{0:dd/MM/yyyy}">
                                            <ItemStyle Width="10%" />
                                            <HeaderStyle Width="10%" />
                                        </asp:BoundField>
                                    </Columns>
                                    <EmptyDataRowStyle CssClass="obj_Grid_Row_Nao_Localizado" />
                                </pro:ProGridView>
                            </div>
                        </pro:ProPanel>
                    </asp:View>
                    <asp:View ID="vwCadastro" runat="server">
                        <div class="obj_Conteudo txt_padrao">
                            <pro:ProPanel ID="pnlManutencao" runat="server" BorderWidth="0px" Height="100%" Width="100%">
                                <obr:ucObrigatorio ID="ucObrigatorio1" runat="server" />
                                <div class="ColEsquerda">
                                    <table align="left" border="0" cellpadding="0" cellspacing="0" style="vertical-align: top;
                                        width: 136%; text-align: center">
                                        <tr>
                                            <td class="linha_rotulo" style="height: 15px" colspan="3">
                                                <pro:ProDropDownList ID="ddlUnidadeOrcamentaria" runat="server" CssClass="obj_Controle_Obrigatorio"
                                                    CssClassFocus="obj_Controle_Obrigatorio_Focus" ToolTip="Informe uma unidade orçamentaria."
                                                    DataField="UnidadeOrcamentaria" Label="Unidade Orçamentaria:" Width="269px" DataType="Number"
                                                    LabelPosition="Top" DefaultText="Selecione uma unidade orçamentaria">
                                                </pro:ProDropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="linha_rotulo" style="height: 15px" colspan="3">
                                                <pro:ProDropDownList ID="ddlPessoal" runat="server" CssClass="obj_Controle_Obrigatorio"
                                                    CssClassFocus="obj_Controle_Obrigatorio_Focus" ToolTip="Informe uma pessoa."
                                                    DataField="Pessoal" Label="Pessoal:" Width="269px" DataType="Number" LabelPosition="Top"
                                                    DefaultText="Selecione uma pessoa">
                                                </pro:ProDropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="linha_rotulo" style="height: 15px;" colspan="3">
                                                <pro:ProDropDownList ID="ddlTipoExpediente" runat="server" CssClass="obj_Controle_Obrigatorio"
                                                    CssClassFocus="obj_Controle_Obrigatorio_Focus" ToolTip="Informe o tipo de expediente."
                                                    DataField="TipoExpediente" Label="Tipo de Nomeação:" Width="269px" DataType="Number"
                                                    LabelPosition="Top" DefaultText="Selecione o tipo de expediente">
                                                </pro:ProDropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="linha_rotulo" style="height: 15px; width: 152px;">
                                                <pro:ProTextBox ID="txtExpedienteNomeacao" runat="server" CssClass="obj_Controle"
                                                    ToolTip="Informe o expediente da nomeação." DataField="ExpedienteNomeacao" Label="Num. de Nomeação:"
                                                    Width="100px" MaxLength="10"></pro:ProTextBox>
                                            </td>
                                            <td class="linha_rotulo" style="height: 15px;">
                                                <pro:ProTextBox ID="txtDataPublicacaoNomeacao" runat="server" CssClass="obj_Controle_Obrigatorio_PP"
                                                    CssClassFocus="obj_Controle_Obrigatorio_Focus_PP" ToolTip="Informe a data de publicação da nomeação."
                                                    DataType="Date" DataField="DataPublicacaoNomeacao" Label="Data de publicação da nomeação:"></pro:ProTextBox>
                                                <asp:ImageButton runat="server" ID="btnDataPublicacaoNomeacao" ImageUrl="~/Parts/Thema2/images/ico_calendar.gif"
                                                    CssClass="cssCalendar" />
                                                <cc1:CalendarExtender runat="server" ID="CalendarExtender2" TargetControlID="txtDataPublicacaoNomeacao"
                                                    PopupButtonID="btnDataPublicacaoNomeacao" Format="dd/MM/yyyy">
                                                </cc1:CalendarExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="linha_rotulo" style="height: 15px; width: 152px;">
                                                <pro:ProTextBox ID="txtDataNomeacao" runat="server" CssClass="obj_Controle_PP" CssClassFocus="obj_Controle_Focus_PP"
                                                    ToolTip="Informe a data de nomeação." DataType="Date" DataField="DataNomeacao"
                                                    Label="Data de nomeação:"></pro:ProTextBox>
                                                <asp:ImageButton runat="server" ID="btnDataNomeacao" ImageUrl="~/Parts/Thema2/images/ico_calendar.gif"
                                                    CssClass="cssCalendar" />
                                                <cc1:CalendarExtender runat="server" ID="CalendarExtender3" TargetControlID="txtDataNomeacao"
                                                    PopupButtonID="btnDataNomeacao" Format="dd/MM/yyyy">
                                                </cc1:CalendarExtender>
                                            </td>
                                            <td class="linha_rotulo" style="height: 15px;">
                                                <pro:ProTextBox ID="txtDataPosse" runat="server" CssClass="obj_Controle_PP" CssClassFocus="obj_Controle_Focus_PP"
                                                    DataField="DataPosse" DataType="Date" Label="Data de posse:" ToolTip="Informe a data de posse."></pro:ProTextBox>
                                                <asp:ImageButton runat="server" ID="btnDataPosse" ImageUrl="~/Parts/Thema2/images/ico_calendar.gif"
                                                    CssClass="cssCalendar" />
                                                <cc1:CalendarExtender runat="server" ID="CalendarExtender4" TargetControlID="txtDataPosse"
                                                    PopupButtonID="btnDataPosse" Format="dd/MM/yyyy">
                                                </cc1:CalendarExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="linha_rotulo" style="height: 15px" colspan="3">
                                                <pro:ProDropDownList ID="ddlFormaIngresso" runat="server" CssClass="obj_Controle_Obrigatorio"
                                                    CssClassFocus="obj_Controle_Obrigatorio_Focus" ToolTip="Informe a forma de ingresso."
                                                    DataField="FormaIngresso" Label="Forma de ingresso:" Width="269px" DataType="Number"
                                                    LabelPosition="Top" DefaultText="Selecione a forma de ingresso">
                                                </pro:ProDropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="linha_rotulo" style="height: 15px" colspan="3">
                                                <pro:ProDropDownList ID="ddlTipoRelacao" runat="server" CssClass="obj_Controle" ToolTip="Informe o tipo de relação."
                                                    DataField="TipoRelacao" Label="Tipo de Relação:" Width="269px" DataType="Number"
                                                    LabelPosition="Top" DefaultText="Selecione o tipo de relação">
                                                </pro:ProDropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div class="ColDireita" style="padding-left: 90px; width: 35%">
                                    <table>
                                        <tr>
                                            <td class="linha_rotulo" style="height: 15px; width: 154px;" colspan="2">
                                                <pro:ProDropDownList ID="ddlTipoAmparo" runat="server" CssClass="obj_Controle" ToolTip="Informe o tipo de amparo."
                                                    DataField="TipoAmparo" Label="Tipo de Amparo:" Width="269px" LabelPosition="Top"
                                                    DataType="Number" DefaultText="Selecione o tipo de amparo">
                                                </pro:ProDropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="linha_rotulo" style="height: 15px; width: 148px;">
                                                <pro:ProTextBox ID="txtNumAmparoLegal" runat="server" CssClass="obj_Controle" ToolTip="Informe o número do amparo."
                                                    DataField="NumAmparoLegal" Label="Num. Amparo Legal:" Width="99px" LabelPosition="Top"
                                                    MaxLength="10">
                                                </pro:ProTextBox>
                                            </td>
                                            <td class="linha_rotulo" style="height: 15px">
                                                <pro:ProTextBox ID="txtDataAmparoLegal" runat="server" CssClass="obj_Controle_PP"
                                                    CssClassFocus="obj_Controle_Focus_PP" DataField="DataAmparoLegal" DataType="Date"
                                                    Label="Data do amparo:" ToolTip="Informe a data do amparo."></pro:ProTextBox>
                                                <asp:ImageButton runat="server" ID="btnDataAmparoLegal" ImageUrl="~/Parts/Thema2/images/ico_calendar.gif"
                                                    CssClass="cssCalendar" />
                                                <cc1:CalendarExtender runat="server" ID="CalendarExtender5" TargetControlID="txtDataAmparoLegal"
                                                    PopupButtonID="btnDataAmparoLegal" Format="dd/MM/yyyy">
                                                </cc1:CalendarExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="linha_rotulo" style="height: 15px" colspan="3">
                                                <pro:ProTextBox ID="txtNumMatriculaMunicipal" runat="server" CssClass="obj_Controle"
                                                    ToolTip="Informe o número da matrícula municipal" DataField="NumMatriculaMunicipal"
                                                    Label="Num. Matrícula Municipal:" Width="100px" MaxLength="15"></pro:ProTextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="linha_rotulo" style="height: 15px;" colspan="3">
                                                <pro:ProDropDownList ID="ddlSituacaoFuncional" runat="server" CssClass="obj_Controle"
                                                    ToolTip="Informe a situação funcional." DataField="SituacaoFuncional" Label="Situação Funcional:"
                                                    Width="269px" DataType="Number" LabelPosition="Top" DefaultText="Selecione a situação funcional">
                                                </pro:ProDropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="linha_rotulo" style="height: 15px;" colspan="3">
                                                <pro:ProDropDownList ID="ddlRegimeJuridico" runat="server" CssClass="obj_Controle"
                                                    ToolTip="Informe o regime jurídico." DataField="RegimeJuridico" Label="Regime Jurídico:"
                                                    Width="269px" DataType="Number" LabelPosition="Top" DefaultText="Selecione o regime jurídico">
                                                </pro:ProDropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="linha_rotulo" style="height: 15px;" colspan="3">
                                                <pro:ProDropDownList ID="ddlRegimePrevidenciario" runat="server" CssClass="obj_Controle"
                                                    ToolTip="Informe o regime previdenciario." DataField="RegimePrevidenciario" Label="Regime Previdenciario:"
                                                    Width="269px" DataType="Number" LabelPosition="Top" DefaultText="Selecione o regime previdenciario">
                                                </pro:ProDropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="linha_rotulo" style="height: 15px;">
                                                <pro:ProDropDownList ID="ddlCargo" runat="server" CssClass="obj_Controle" ToolTip="Informe o cargo."
                                                    DataField="Cargo" Label="Cargo:" Width="117px" DataType="Number" LabelPosition="Top"
                                                    DefaultText="Selecione o cargo">
                                                </pro:ProDropDownList>
                                            </td>
                                            <td class="linha_rotulo" style="height: 15px" colspan="3">
                                                <pro:ProTextBox ID="txtNumCargaHorariaSemanal" runat="server" CssClass="obj_Controle"
                                                    ToolTip="Informe a carga horária semanal" DataField="NumCargaHorariaSemanal"
                                                    DataType="Number" Label="Num. Carga Horária Semanal:" Width="100px"></pro:ProTextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 154px">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="linha_rotulo" style="height: 15px">
                                                <pro:ProCheckBox ID="chkAtivo" DataField="Ativo" Text="Ativo?" runat="server" IncludeTopSpace="False" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div class="ColFooter" style="padding-left: 10px; width: 70%">
                                    <uc2:ucAgenteItem ID="ucAgenteItem1" runat="server" />
                                </div>
                            </pro:ProPanel>
                        </div>
                    </asp:View>
                </asp:MultiView>
                <div class="statusBar">
                    <label id="labelAjuda" class="Ajuda">
                    </label>
                </div>
            </div>
            <div class="b">
                <div class="b">
                    <div class="b">
                    </div>
                </div>
            </div>
            <div class="clr">
            </div>
            <div id="subgroup-menu">
                <div class="t">
                    <div class="t">
                        <div class="t">
                        </div>
                    </div>
                </div>
                <div id="menu-box" class="m">
                    <div id="right-box-tit" class="misc-box-tit">
                        <asp:Button ID="btnSalvar" runat="server" Text="Salvar" CommandName="Salvar" CssClass="obj_Btn_Command" />
                        <asp:Button ID="btnDesligamento" runat="server" Text="Desligamento" CssClass="obj_Btn_Command"
                            Width="90px" OnClick="btnDesligamento_OnClick" />
                        <asp:Button ID="btnNovoCadastro" runat="server" CommandName="Novo" Text="Novo" CssClass="obj_Btn_Command" />
                        <asp:Button ID="btnExcluir" runat="server" Text="Excluir" CommandName="Excluir" CssClass="obj_Btn_Command" />
                        <asp:Button ID="btnListagem" runat="server" Text="Listagem" CommandName="Listagem"
                            CssClass="obj_Btn_Command" />
                    </div>
                </div>
                <div class="b">
                    <div class="b">
                        <div class="b">
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <cc1:ModalPopupExtender ID="mpeDesligamentoAgentes" runat="server" PopupControlID="divCadastroUCDesligamento"
        BackgroundCssClass="BackGroundPopup" TargetControlID="hdnBtn1" CancelControlID="imgFecharUC">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnBtn1" runat="server" />
    <div id="divCadastroUCDesligamento" style="display: none; width: 600px;">
        <pro:ProPanel ID="pnlManutencaoUCDesligamento" runat="server">
            <div id="LAY_CONTENT_CENTER_POPUP" style="height: 295px; width: 500px;">
                <div id="LAY_CONTENT_LEFT_POPUP">
                    <div id="LAY_CONTENT_RIGHT_POPUP">
                        <div id="LAY_TITULO_POPUP">
                            <asp:Label ID="Label1" runat="server" Text="Desligamento"></asp:Label>
                            <div id="LAY_BOTAO_FECHAR_POPUP">
                                <asp:Image ID="imgFecharUC" runat="server" ImageUrl="~/Parts/Thema1/btnClose.png">
                                </asp:Image></div>
                        </div>
                        <table align="left" border="0" cellpadding="0" cellspacing="0" style="vertical-align: top;
                            text-align: left">
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td class="linha_rotulo" style="height: 15px">
                                    <pro:ProLabel ID="lblAgentePublico" runat="server" LabelCssClass="LabelFiltro" Visible="false"></pro:ProLabel>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <pro:ProTextBox ID="txtIDLista" runat="server" Visible="false"></pro:ProTextBox>
                                </td>
                                <td class="linha_rotulo" style="height: 15px" colspan="3">
                                    <pro:ProDropDownList ID="ddlTipoDesligamento" runat="server" CssClass="obj_Controle_Obrigatorio_M"
                                        CssClassFocus="obj_Controle_Obrigatorio_Focus_M" ToolTip="Informe o Tipo de Desligamento."
                                        DataField="TipoDesligamento" Label="Tipo:" DataType="Number" LabelPosition="Top"
                                        AutoPostBack="true" OnSelectedIndexChanged="ddlTipoDesligamento_SelectedIndexChanged"
                                        DefaultText="Selecione um Tipo de Desligamento">
                                    </pro:ProDropDownList>
                                </td>
                                <td style="width: 5%">
                                    &nbsp;
                                </td>
                                <td>
                                    <pro:ProTextBox ID="txtNumExpedienteDesligamento" runat="server" CssClass="obj_Controle_Obrigatorio_P"
                                        CssClassFocus="obj_Controle_Obrigatorio_Focus_P" ToolTip="Informe o número do Expediente de Desligamento."
                                        DataField="NumeroExpediente" Label="Num. do Expediente:" Width="100px" MaxLength="10"></pro:ProTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td class="linha_rotulo" style="height: 15px" colspan="3">
                                    <pro:ProDropDownList ID="ddlTipoExpedienteDesligamento" runat="server" CssClass="obj_Controle_Obrigatorio_M"
                                        CssClassFocus="obj_Controle_Obrigatorio_Focus_M" ToolTip="Informe o Tipo do Expediente de Desligamento."
                                        DataField="TipoExpediente" Label="Tipo do Expediente:" DataType="Number" LabelPosition="Top"
                                        DefaultText="Selecione um Tipo do Expediente">
                                    </pro:ProDropDownList>
                                </td>
                                <td style="width: 5%">
                                    &nbsp;
                                </td>
                                <td>
                                    <pro:ProTextBox ID="txtDataExpedienteDesligamento" runat="server" CssClass="obj_Controle_Obrigatorio_PP"
                                        CssClassFocus="obj_Controle_Obrigatorio_Focus_PP" ToolTip="Informe a data do Expediente de Desligamento."
                                        DataField="DataExpediente" DataType="Date" Label="Data do Expediente:"></pro:ProTextBox>
                                    <asp:ImageButton runat="server" ID="btnDataExpedienteDesligamento" ImageUrl="~/Parts/Thema2/images/ico_calendar.gif"
                                        CssClass="cssCalendar" />
                                    <cc1:CalendarExtender runat="server" ID="calIni" TargetControlID="txtDataExpedienteDesligamento"
                                        PopupButtonID="btnDataExpedienteDesligamento" Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td class="linha_rotulo" style="height: 15px" colspan="3">
                                    <pro:ProDropDownList ID="ddlPensionista" runat="server" CssClass="obj_Controle_Obrigatorio_M"
                                        CssClassFocus="obj_Controle_Obrigatorio_Focus_M" ToolTip="Informe o Pensionista."
                                        DataField="Pensionista" Visible="false" Label="Pensionista:" DataType="Number"
                                        LabelPosition="Top" DefaultText="Selecione um Pensionista">
                                    </pro:ProDropDownList>
                                </td>
                                <td style="width: 5%">
                                    &nbsp;
                                </td>
                                <td>
                                    <pro:ProTextBox ID="txtDataPublicacaoDesligamento" runat="server" CssClass="obj_Controle_Obrigatorio_PP"
                                        CssClassFocus="obj_Controle_Obrigatorio_Focus_PP" ToolTip="Informe a data de Publicação do Expediente de Desligamento."
                                        DataField="DataPublicacao" DataType="Date" Label="Data de Publicação do Expediente:"></pro:ProTextBox>
                                    <asp:ImageButton runat="server" ID="btnDataPublicacaoDesligamento" ImageUrl="~/Parts/Thema2/images/ico_calendar.gif"
                                        CssClass="cssCalendar" />
                                    <cc1:CalendarExtender runat="server" ID="CalendarExtender1" TargetControlID="txtDataPublicacaoDesligamento"
                                        PopupButtonID="btnDataPublicacaoDesligamento" Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <table>
                        <tr>
                            <td>
                                <asp:Button ID="btnSalvarDesligamento" runat="server" OnClick="btnSalvarDesligamento_OnClick"
                                    Width="90px" OnClientClick="messageBox(this,'PERGUNTA','SIMNAO','Confirmação o Desligamento','Deseja realmente fazer o desligamento desse agente público ?',''); return false;"
                                    Text="Desligamento" CssClass="obj_Btn_Command" Visible="false" />
                                <asp:Button ID="btnSavarDesligamentoLista" runat="server" OnClick="btnSavarDesligamentoLista_OnClick"
                                    Width="90px" OnClientClick="messageBox(this,'PERGUNTA','SIMNAO','Confirmação o Desligamento','Deseja realmente fazer o desligamento desse agente público ?',''); return false;"
                                    Text="Desligamento" CssClass="obj_Btn_Command" Visible="false" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </pro:ProPanel>
    </div>
    <div class="statusBar">
        <label id="labelAjudaComissao" class="Ajuda">
        </label>
    </div>
</asp:Content>
