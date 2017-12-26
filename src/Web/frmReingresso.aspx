<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true"
    CodeBehind="frmReingresso.aspx.cs" Inherits="Platinium.Web.frmReingresso" %>

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
                                        Width="65px" Visible="false" />
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
                                    EnableModelValidation="True" GridLines="None" Width="100%">
                                    <HeaderStyle CssClass="obj_Grid_Header" />
                                    <AlternatingRowStyle CssClass="obj_Grid_AlternatingRow" />
                                    <RowStyle CssClass="obj_Grid_Row" />
                                    <SelectedRowStyle CssClass="obj_Grid_SelectedRow" />
                                    <PagerStyle CssClass="obj_Grid_Pager" />
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemStyle Width="20px" HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgReingresso" CommandName="REINGRESSO" ImageUrl="~/Parts/Thema2/images/icons_container/extinguir.png"
                                                    runat="server" ToolTip="Reingresso" OnClick="imgReingresso_OnClick" />
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
                                        <asp:BoundField DataField="DatPublicacaoNomeacaoAgente" HeaderText="publicação da nomeação"
                                            ItemStyle-Width="10%" SortExpression="DatPublicacaoNomeacaoAgente" HeaderStyle-HorizontalAlign="Left"
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
                                <table align="left" border="0" cellpadding="0" cellspacing="0" style="vertical-align: top;
                                    width: 136%; text-align: center">
                                    <tr>
                                        <td>
                                            <pro:ProTextBox ID="txtID" runat="server" Visible="false"></pro:ProTextBox>
                                        </td>
                                    </tr>
                                </table>
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
                        <asp:Button ID="btnNovoCadastro" runat="server" CommandName="Novo" Text="Novo" CssClass="obj_Btn_Command"
                            Visible="false" />
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
    <cc1:ModalPopupExtender ID="mpeReingressoAgentes" runat="server" PopupControlID="divCadastroUCReingresso"
        BackgroundCssClass="BackGroundPopup" TargetControlID="hdnBtn1" CancelControlID="imgFecharUC">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnBtn1" runat="server" />
    <div id="divCadastroUCReingresso" style="display: none; width: 600px;">
        <pro:ProPanel ID="pnlManutencaoUCReingresso" runat="server">
            <div id="LAY_CONTENT_CENTER_POPUP" style="height: 295px; width: 500px;">
                <div id="LAY_CONTENT_LEFT_POPUP">
                    <div id="LAY_CONTENT_RIGHT_POPUP">
                        <div id="LAY_TITULO_POPUP">
                            <asp:Label ID="Label1" runat="server" Text="Reingresso"></asp:Label>
                            <div id="LAY_BOTAO_FECHAR_POPUP">
                                <asp:Image ID="imgFecharUC" runat="server" ImageUrl="~/Parts/Thema1/btnClose.png">
                                </asp:Image></div>
                        </div>
                        <table align="left" border="0" cellpadding="0" cellspacing="0" style="vertical-align: top;
                            text-align: left">
                            <tr>
                                <td>
                                    <pro:ProTextBox ID="txtIDLista" runat="server" Visible="false"></pro:ProTextBox>
                                </td>
                                <td class="linha_rotulo" style="height: 15px">
                                    <pro:ProDropDownList ID="ddlTipoReingresso" runat="server" CssClass="obj_Controle_Obrigatorio_M"
                                        CssClassFocus="obj_Controle_Obrigatorio_Focus_M" ToolTip="Informe o Tipo de Reingresso."
                                        DataField="TipoReingresso" Label="Tipo:" DataType="Number" LabelPosition="Top"
                                        DefaultText="Selecione um Tipo de Reingresso">
                                    </pro:ProDropDownList>
                                </td>
                                <td style="width: 5%">
                                    &nbsp;
                                </td>
                                <td class="linha_rotulo" style="height: 15px">
                                    <pro:ProTextBox ID="txtDataExpedienteReingresso" runat="server" CssClass="obj_Controle_Obrigatorio_PP"
                                        DataType="Date" CssClassFocus="obj_Controle_Obrigatorio_Focus_PP" ToolTip="Informe a data do Expediente de Reingresso."
                                        DataField="DataExpedienteReingresso" Label="Data do Expediente:"></pro:ProTextBox>
                                    <asp:ImageButton runat="server" ID="btnDataExpedienteReingresso" ImageUrl="~/Parts/Thema2/images/ico_calendar.gif"
                                        CssClass="cssCalendar" />
                                    <cc1:CalendarExtender runat="server" ID="calIni" TargetControlID="txtDataExpedienteReingresso"
                                        PopupButtonID="btnDataExpedienteReingresso" Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td class="linha_rotulo" style="height: 15px">
                                    <pro:ProDropDownList ID="ddlTipoExpedienteReingresso" runat="server" CssClass="obj_Controle_Obrigatorio_M"
                                        CssClassFocus="obj_Controle_Obrigatorio_Focus_M" ToolTip="Informe o Tipo do Expediente de Reingresso."
                                        DataField="TipoExpedienteReingresso" Label="Tipo do Expediente:" DataType="Number"
                                        LabelPosition="Top" DefaultText="Selecione um Tipo do Expediente">
                                    </pro:ProDropDownList>
                                </td>
                                <td style="width: 5%">
                                    &nbsp;
                                </td>
                                <td class="linha_rotulo" style="height: 15px">
                                    <pro:ProTextBox ID="txtDataPublicacaoReingresso" runat="server" CssClass="obj_Controle_Obrigatorio_PP"
                                        CssClassFocus="obj_Controle_Obrigatorio_Focus_PP" ToolTip="Informe a data de Publicação do Expediente de Reingresso."
                                        DataField="DataPublicacaoReingresso" DataType="Date" Label="Data de Publicação do Expediente:"></pro:ProTextBox>
                                    <asp:ImageButton runat="server" ID="btnDataPublicacaoReingresso" ImageUrl="~/Parts/Thema2/images/ico_calendar.gif"
                                        CssClass="cssCalendar" />
                                    <cc1:CalendarExtender runat="server" ID="CalendarExtender1" TargetControlID="txtDataPublicacaoReingresso"
                                        PopupButtonID="btnDataPublicacaoReingresso" Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td class="linha_rotulo" style="height: 15px">
                                    <pro:ProTextBox ID="txtNumExpedienteReingresso" runat="server" CssClass="obj_Controle_Obrigatorio_P"
                                        CssClassFocus="obj_Controle_Obrigatorio_Focus_P" ToolTip="Informe o número do Expediente de Reingresso."
                                        DataField="NumeroExpedienteReingresso" Label="Num. do Expediente:" Width="100px"></pro:ProTextBox>
                                </td>
                                <td style="width: 5%">
                                    &nbsp;
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td class="linha_rotulo" style="height: 15px" colspan="3">
                                    <pro:ProPanel ID="pnlAmparoLEgal" GroupingText="Amparo Legal do Expediente de Reingresso"
                                        runat="server">
                                        <table align="left" border="0" cellpadding="0" cellspacing="0" style="vertical-align: top;
                                            text-align: left">
                                            <tr>
                                                <td class="linha_rotulo" style="height: 15px">
                                                    <pro:ProDropDownList ID="ddlTipoAmparo" runat="server" CssClass="obj_Controle_Obrigatorio_M"
                                                        CssClassFocus="obj_Controle_Obrigatorio_Focus_M" ToolTip="Informe o tipo do amparo legal do expediente de reingresso."
                                                        DataField="TipoAmparo" Label="Tipo:" DataType="Number" LabelPosition="Top" DefaultText="Selecione um Tipo">
                                                    </pro:ProDropDownList>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td class="linha_rotulo" style="height: 15px">
                                                    <pro:ProTextBox ID="txtData" runat="server" CssClass="obj_Controle_Obrigatorio_PP"
                                                        CssClassFocus="obj_Controle_Obrigatorio_Focus_PP" Label="Data:" ToolTip="Informe a data do amparo legal do expediente de reingresso."
                                                        DataField="DataAmparoLegal" DataType="Date"></pro:ProTextBox>
                                                    <asp:ImageButton runat="server" ID="btnData" ImageUrl="~/Parts/Thema2/images/ico_calendar.gif"
                                                        CssClass="cssCalendar" />
                                                    <cc1:CalendarExtender runat="server" ID="CalendarExtender2" TargetControlID="txtData"
                                                        PopupButtonID="btnData" Format="dd/MM/yyyy">
                                                    </cc1:CalendarExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="linha_rotulo" style="height: 15px">
                                                    <pro:ProTextBox ID="txtNumeroAmparoLegal" runat="server" CssClass="obj_Controle_Obrigatorio_P"
                                                        CssClassFocus="obj_Controle_Obrigatorio_Focus_P" Label="Número:" ToolTip="Informe o Número do amparo legal do expediente de reingresso."
                                                        DataField="NumeroAmparoLegalReingresso"></pro:ProTextBox>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td class="linha_rotulo" style="height: 15px">
                                                    <pro:ProTextBox ID="txtDataPublicacaoAmparoLegal" runat="server" CssClass="obj_Controle_Obrigatorio_PP"
                                                        CssClassFocus="obj_Controle_Obrigatorio_Focus_PP" Label="Data da publicação:"
                                                        ToolTip="Informe a Data de Ppublicação do amparo legal do expediente de reingresso."
                                                        DataField="DataPublicacaoAmparoLegal" DataType="Date"></pro:ProTextBox>
                                                    <asp:ImageButton runat="server" ID="btnDataPublicacaoAmparoLegal" ImageUrl="~/Parts/Thema2/images/ico_calendar.gif"
                                                        CssClass="cssCalendar" />
                                                    <cc1:CalendarExtender runat="server" ID="CalendarExtender3" TargetControlID="txtDataPublicacaoAmparoLegal"
                                                        PopupButtonID="btnDataPublicacaoAmparoLegal" Format="dd/MM/yyyy">
                                                    </cc1:CalendarExtender>
                                                </td>
                                            </tr>
                                        </table>
                                    </pro:ProPanel>
                                </td>
                                <td>
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td>
                                    <asp:Button ID="btnSavarReingressoLista" runat="server" OnClick="btnSavarReingressoLista_OnClick"
                                        Width="90px" OnClientClick="messageBox(this,'PERGUNTA','SIMNAO','Confirmação o Reingresso','Deseja realmente fazer o reingresso desse agente público ?',''); return false;"
                                        Text="Reingresso" CssClass="obj_Btn_Command" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </pro:ProPanel>
    </div>
    <div class="statusBar">
        <label id="labelAjudaComissao" class="Ajuda">
        </label>
    </div>
</asp:Content>
