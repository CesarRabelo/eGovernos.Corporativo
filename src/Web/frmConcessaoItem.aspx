<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true"
    CodeBehind="frmConcessaoItem.aspx.cs" Inherits="Platinium.Web.frmConcessaoItem" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="Pro.Controls" Namespace="Pro.Controls" TagPrefix="pro" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/ucCabecalhoObrigatorio.ascx" TagName="ucObrigatorio" TagPrefix="obr" %>
<%@ Register Src="UserControls/ucEndereco.ascx" TagName="ucEndereco" TagPrefix="uc1" %>
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
                                    <asp:Label ID="lblOrgao" runat="server" Text="Órgão:" CssClass="LabelFiltro"></asp:Label>
                                </td>
                                <td class="linha_rotulo" style="height: 15px">
                                    <pro:ProDropDownList ID="ddlBuscarOrgao2" runat="server" CssClass="obj_Controle_G"
                                        CssClassFocus="obj_Controle_Focus_G" ToolTip="Informe o órgão responsável para busca."
                                        DataType="Number" DefaultText="Selecione um Órgão." AutoPostBack="true" OnSelectedIndexChanged="ddlBuscaOrgao_SelectedIndexChanged2" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblUnidadeOrcamentaria" runat="server" Text="Unidade Orçamentária:"
                                        CssClass="LabelFiltro"></asp:Label>
                                </td>
                                <td>
                                    <pro:ProDropDownList ID="ddlBuscarUnidadeOrcamentaria2" runat="server" CssClass="obj_Controle_G"
                                        CssClassFocus="obj_Controle_Focus_G" DataField="CodUnidadeOrcamentaria" DefaultText="Selecione uma Unidade Orçamentária."
                                        AutoPostBack="true" ToolTip="Informe a Unidade Orçamentária para busca." DataType="Number" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblItemRemuneratorio" runat="server" Text="Ítem Remuneratório:" CssClass="LabelFiltro"></asp:Label>
                                </td>
                                <td>
                                    <pro:ProDropDownList ID="ddlBuscaItemRemuneratorio" runat="server" CssClass="obj_Controle_G"
                                        CssClassFocus="obj_Controle_Focus_G" DataField="ItemRemuneratorio" DefaultText="Selecione uma Ítem Remuneratório."
                                        ToolTip="Informe o ítem remuneratório para busca." DataType="Number" />
                                </td>
                            </tr>
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
                                    <asp:Button ID="btnSuspenderSelecionados" OnClick="btnSuspenderSelecionados_OnClick"
                                        runat="server" Text="Suspender" CssClass="obj_Btn_Command" Width="65px" />
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
                                    AutoGenerateColumns="False" CssClass="obj_Grid" DataKeyNames="Id" EnableModelValidation="True"
                                    GridLines="None" Width="100%" AutoGenerateSelectColumn="True" SelectionMode="Multiple">
                                    <HeaderStyle CssClass="obj_Grid_Header" />
                                    <AlternatingRowStyle CssClass="obj_Grid_AlternatingRow" />
                                    <RowStyle CssClass="obj_Grid_Row" />
                                    <SelectedRowStyle CssClass="obj_Grid_SelectedRow" />
                                    <PagerStyle CssClass="obj_Grid_Pager" />
                                    <Columns>
                                        <asp:TemplateField Visible="false">
                                            <ItemStyle Width="20px" HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgEdit" ImageUrl="~/Parts/Thema2/images/icons_container/edit-archive.png"
                                                    runat="server" CommandName="Edit" ToolTip="Editar" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="false">
                                            <ItemStyle Width="20px" HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgDelete" ImageUrl="~/Parts/Thema2/images/icons_container/delete.png"
                                                    runat="server" CommandName="Delete" ToolTip="Deletar" OnClientClick="messageBox(this,'PERGUNTA','SIMNAO','Confirmação de exclusão','Deseja realmente excluir este item ?',''); return false;" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="CodAgente" HeaderText="Código" ItemStyle-Width="5%" SortExpression="CodAgente"
                                            HeaderStyle-HorizontalAlign="Left"></asp:BoundField>
                                        <asp:BoundField DataField="DscSigla" HeaderText="Sigla" ItemStyle-Width="10%" SortExpression="DscSigla"
                                            HeaderStyle-HorizontalAlign="Left"></asp:BoundField>
                                        <asp:BoundField DataField="DscNome" HeaderText="Nome do Agente" ItemStyle-Width="40%"
                                            SortExpression="DscNome" HeaderStyle-HorizontalAlign="Left"></asp:BoundField>
                                        <asp:BoundField DataField="DscItem" HeaderText="Ítem Remuneratório" ItemStyle-Width="30%"
                                            SortExpression="DscNome" HeaderStyle-HorizontalAlign="Left"></asp:BoundField>
                                        <asp:BoundField DataField="DscData" HeaderText="Data  Concessão" ItemStyle-Width="10%"
                                            SortExpression="DscData" HeaderStyle-HorizontalAlign="Left" DataFormatString="{0:dd/MM/yyyy}">
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
                                                <pro:ProDropDownList ID="ddlItemRemuneratorio" runat="server" CssClass="obj_Controle_Obrigatorio"
                                                    CssClassFocus="obj_Controle_Obrigatorio_Focus" ToolTip="Informe uma item remuneratório."
                                                    DataField="ItemRemuneratorio" Label="Item Remuneratório:" Width="269px" DataType="Number"
                                                    LabelPosition="Top" DefaultText="Selecione um item remuneratório">
                                                </pro:ProDropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="linha_rotulo" style="height: 15px" colspan="3">
                                                <pro:ProDropDownList ID="ddlTipoExpediente" runat="server" CssClass="obj_Controle_Obrigatorio"
                                                    CssClassFocus="obj_Controle_Obrigatorio_Focus" ToolTip="Informe um tipo de expediente."
                                                    DataField="TipoExpediente" Label="Tipo Expediente:" Width="269px" DataType="Number"
                                                    LabelPosition="Top" DefaultText="Selecione um tipo de expediente.">
                                                </pro:ProDropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="linha_rotulo" style="height: 15px; width: 152px;">
                                                <pro:ProTextBox ID="txtNumeroExpediente" runat="server" CssClass="obj_Controle_Obrigatorio_PP"
                                                    ToolTip="Informe número do expediente." CssClassFocus="obj_Controle_Obrigatorio_Focus_PP"
                                                    DataField="NumeroExpediente" Label="Num. de Expediente:" Width="100px" MaxLength="10"></pro:ProTextBox>
                                            </td>
                                            <td class="linha_rotulo" style="height: 15px;">
                                                <pro:ProTextBox ID="txtDataExpediente" runat="server" CssClass="obj_Controle_Obrigatorio"
                                                    CssClassFocus="obj_Controle_Obrigatorio_Focus" ToolTip="Informe a data do expediente."
                                                    DataType="Date" DataField="DataExpedienteConcessao" Label="Data do Expediente:"
                                                    Width="100px"></pro:ProTextBox>
                                                <asp:ImageButton runat="server" ID="btnDataExpediente" ImageUrl="~/Parts/Thema2/images/ico_calendar.gif"
                                                    CssClass="cssCalendar" />
                                                <cc1:CalendarExtender runat="server" ID="ceDataExpediente" TargetControlID="txtDataExpediente"
                                                    PopupButtonID="btnDataExpediente" Format="dd/MM/yyyy">
                                                </cc1:CalendarExtender>
                                            </td>
                                            <td class="linha_rotulo" style="height: 15px;">
                                                <pro:ProTextBox ID="txtDataPublicacaoExpediente" runat="server" CssClass="obj_Controle_Obrigatorio_PP"
                                                    CssClassFocus="obj_Controle_Obrigatorio_Focus_PP" ToolTip="Informe a data do expediente."
                                                    DataType="Date" DataField="DataExpedienteConcessaoPublicacao" Label="Data Publicação do Expediente:"
                                                    Width="100px"></pro:ProTextBox>
                                                <asp:ImageButton runat="server" ID="btnDataPublicacaoNomeacao" ImageUrl="~/Parts/Thema2/images/ico_calendar.gif"
                                                    CssClass="cssCalendar" />
                                                <cc1:CalendarExtender runat="server" ID="ceDataPublicacao" TargetControlID="txtDataPublicacaoExpediente"
                                                    PopupButtonID="btnDataPublicacaoNomeacao" Format="dd/MM/yyyy">
                                                </cc1:CalendarExtender>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div class="ColFooter" style="padding-left: 10px; width: 70%">
                                    <pro:ProPanel ID="pnlConsultaUC" runat="server" GroupingText="Pessoas">
                                        <table>
                                            <tr>
                                                <td>
                                                    <pro:ProDropDownList ID="ddlBuscarOrgao" runat="server" CssClass="obj_Controle_Obrigatorio_M"
                                                        CssClassFocus="obj_Controle_Obrigatorio_Focus_M" LabelPosition="Top" DataField="Orgao"
                                                        ToolTip="Informe o órgão a ser filtrado." DefaultText="Selecione um órgão" LabelAjuda="labelAjudaComissao"
                                                        Width="320px" Label="Órgão:" DataType="Number" AutoPostBack="true" OnSelectedIndexChanged="ddlBuscaOrgao_SelectedIndexChanged">
                                                    </pro:ProDropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <pro:ProDropDownList ID="ddlBuscarUnidadeOrcamentaria" runat="server" CssClass="obj_Controle_Obrigatorio"
                                                        CssClassFocus="obj_Controle_Obrigatorio_Focus" LabelPosition="Top" DataField="UnidadeOrcamentaria"
                                                        ToolTip="Informe a unidade orçamentária a ser filtrada." DefaultText="Selecione uma unidade orçamentária"
                                                        LabelAjuda="labelAjudaComissao" Width="320px" Label="Unidade Orçamentária:" DataType="Number">
                                                    </pro:ProDropDownList>
                                                    <asp:Button ID="btnFiltrar" runat="server" Visible="true" Text="Filtrar" CssClass="obj_Btn_Box"
                                                        Width="75px" Style="margin-left: 16px" OnClick="btnFiltrar_OnClick" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                        <pro:ProGridView ID="grdListagemUC" AllowSorting="true" runat="server" CssClass="obj_Grid"
                                            GridLines="None" Width="100%" AutoGenerateColumns="False" AllowPaging="True"
                                            DataKeyNames="Id" ShowTotalRegisters="false" AutoGenerateSelectColumn="True"
                                            SelectionMode="Multiple" OnSorting="grdListagemUC_Sorting">
                                            <HeaderStyle CssClass="obj_Grid_Header" />
                                            <AlternatingRowStyle CssClass="obj_Grid_AlternatingRow" />
                                            <RowStyle CssClass="obj_Grid_Row" />
                                            <SelectedRowStyle CssClass="obj_Grid_SelectedRow" />
                                            <PagerStyle CssClass="obj_Grid_Pager" />
                                            <Columns>
                                                <asp:BoundField DataField="DscNome" SortExpression="DscNome" HeaderText="Nome">
                                                    <HeaderStyle HorizontalAlign="Left" Width="85%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="DscCPF" HeaderText="CPF" SortExpression="DscCPF">
                                                    <HeaderStyle HorizontalAlign="Left" Width="10%" />
                                                </asp:BoundField>
                                            </Columns>
                                            <EmptyDataRowStyle CssClass="obj_Grid_Row_Nao_Localizado" />
                                        </pro:ProGridView>
                                        <div style="text-align: right">
                                        </div>
                                    </pro:ProPanel>
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
                        <asp:Button ID="btnSalvar" runat="server" Text="Salvar" CommandName="Salvar" CssClass="obj_Btn_Command"
                            Visible="false" />
                        <asp:Button ID="btnProcessarSelecionados" runat="server" Text="Conceder Selecionados"
                            CssClass="obj_Btn_Box" OnClick="btnProcessarSelecionados_OnClick" Visible="true" />
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
    <cc1:ModalPopupExtender ID="mpeSuspensao" runat="server" PopupControlID="divCadastroUCSuspensao"
        BackgroundCssClass="BackGroundPopup" TargetControlID="hdnBtn1" CancelControlID="imgFecharUC">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnBtn1" runat="server" />
    <div id="divCadastroUCSuspensao" style="display: none; width: 600px;">
        <pro:ProPanel ID="pnlManutencaoUCSuspensao" runat="server">
            <div id="LAY_CONTENT_CENTER_POPUP" style="height: 295px; width: 500px;">
                <div id="LAY_CONTENT_LEFT_POPUP">
                    <div id="LAY_CONTENT_RIGHT_POPUP">
                        <div id="LAY_TITULO_POPUP">
                            <asp:Label ID="Label1" runat="server" Text="Suspensão"></asp:Label>
                            <div id="LAY_BOTAO_FECHAR_POPUP">
                                <asp:Image ID="imgFecharUC" runat="server" ImageUrl="~/Parts/Thema1/btnClose.png">
                                </asp:Image></div>
                        </div>
                        <table align="left" border="0" cellpadding="0" cellspacing="0" style="vertical-align: top;
                            text-align: left">
                            <tr>
                                <pro:ProTextBox ID="txtID" runat="server" Visible="false"></pro:ProTextBox>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <pro:ProTextBox ID="txtNumExpedienteSuspensao" runat="server" CssClass="obj_Controle_Obrigatorio_P"
                                        CssClassFocus="obj_Controle_Obrigatorio_Focus_P" ToolTip="Informe o número do Expediente da Suspensão."
                                        DataField="NumeroExpedienteSuspensao" Label="Num. do Expediente:" Width="100px"
                                        MaxLength="10"></pro:ProTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="linha_rotulo" style="height: 15px" colspan="3">
                                    <pro:ProDropDownList ID="ddlTipoExpedienteSuspensao" runat="server" CssClass="obj_Controle_Obrigatorio_M"
                                        CssClassFocus="obj_Controle_Obrigatorio_Focus_M" ToolTip="Informe o Tipo de Expediente da Suspensão."
                                        DataField="TipoExpedienteSuspensao" Label="Tipo Expediente:" DataType="Number"
                                        LabelPosition="Top" DefaultText="Selecione um Tipo de Expediente">
                                    </pro:ProDropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <pro:ProTextBox ID="txtDataExpedienteSuspensao" runat="server" CssClass="obj_Controle_Obrigatorio_PP"
                                        CssClassFocus="obj_Controle_Obrigatorio_Focus_PP" ToolTip="Informe a data do Expediente da Suspensão."
                                        DataField="DataExpedienteSuspensao" DataType="Date" Label="Data do Expediente:"></pro:ProTextBox>
                                    <asp:ImageButton runat="server" ID="btnDataExpedienteSuspensao" ImageUrl="~/Parts/Thema2/images/ico_calendar.gif"
                                        CssClass="cssCalendar" />
                                    <cc1:CalendarExtender runat="server" ID="ceDataExpedienteSuspensao" TargetControlID="txtDataExpedienteSuspensao"
                                        PopupButtonID="btnDataExpedienteSuspensao" Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                                </td>
                                <td>
                                    <pro:ProTextBox ID="txtDataPublicacaoSuspensao" runat="server" CssClass="obj_Controle_Obrigatorio_PP"
                                        CssClassFocus="obj_Controle_Obrigatorio_Focus_PP" ToolTip="Informe a data de Publicação do Expediente da Suspensão."
                                        DataField="DataExpedienteSuspensaoPublicacao" DataType="Date" Label="Data de Publicação do Expediente:"></pro:ProTextBox>
                                    <asp:ImageButton runat="server" ID="btnDataPublicacaoSuspensao" ImageUrl="~/Parts/Thema2/images/ico_calendar.gif"
                                        CssClass="cssCalendar" />
                                    <cc1:CalendarExtender runat="server" ID="ceDataExpedientePublicacaoSuspensao" TargetControlID="txtDataPublicacaoSuspensao"
                                        PopupButtonID="btnDataPublicacaoSuspensao" Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="btnSalvarSuspensao" runat="server" OnClick="btnSalvarSuspensao_OnClick"
                                        Width="90px" OnClientClick="messageBox(this,'PERGUNTA','SIMNAO','Confirmação a Suspensão','Deseja realmente fazer a suspensão desse item ?',''); return false;"
                                        Text="Suspensão" CssClass="obj_Btn_Command" Visible="true" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </pro:ProPanel>
    </div>
</asp:Content>
