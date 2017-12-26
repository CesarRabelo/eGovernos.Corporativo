<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucAgenteItem.ascx.cs"
    Inherits="Platinium.Web.ucAgenteItem" %>
<%@ Register Assembly="Pro.Controls" Namespace="Pro.Controls" TagPrefix="pro" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<pro:ProPanel ID="pnlConsultaUC" runat="server" GroupingText="Itens">
    <pro:ProTextBox ID="txtIdPaiConsulta" runat="server" DataField="AgentePublico" Visible="false"
        DataType="Number" />
    <pro:ProGridView ID="grdListagemUC" AllowSorting="true" runat="server" CssClass="obj_Grid"
        GridLines="None" Width="100%" AutoGenerateColumns="False" AllowPaging="True"
        DataKeyNames="Id" ShowTotalRegisters="false" AutoGenerateSelectColumn="True"
        SelectionMode="Multiple">
        <HeaderStyle CssClass="obj_Grid_Header" />
        <AlternatingRowStyle CssClass="obj_Grid_AlternatingRow" />
        <RowStyle CssClass="obj_Grid_Row" />
        <SelectedRowStyle CssClass="obj_Grid_SelectedRow" />
        <PagerStyle CssClass="obj_Grid_Pager" />
        <Columns>
            <asp:ButtonField ButtonType="Image" ImageUrl="~/Parts/Thema2/images/icons_container/edit-archive.png"
                CommandName="Edit" ItemStyle-Width="16px" Text="Alterar" />
            <asp:BoundField DataField="ItemRemuneratorio" SortExpression="ItemRemuneratorio"
                HeaderText="Código" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="5%" ItemStyle-HorizontalAlign="Left">
            </asp:BoundField>
            <asp:BoundField DataField="DscItem" HeaderText="Descrição" SortExpression="DscItem"
                HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="15%" ItemStyle-HorizontalAlign="Left">
            </asp:BoundField>
            <asp:BoundField DataField="DscTipoItem" HeaderText="Tipo Item" SortExpression="DscTipoItem"
                HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="15%" ItemStyle-HorizontalAlign="Left">
            </asp:BoundField>
            <asp:BoundField DataField="NumeroExpediente" HeaderText="Número de Expedição" SortExpression="NumeroExpediente"
                HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="20%" ItemStyle-HorizontalAlign="Left">
            </asp:BoundField>
            <asp:BoundField DataField="DscTipoExpediente" HeaderText="Tipo de Expedição" SortExpression="DscTipoExpediente"
                HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="15%" ItemStyle-HorizontalAlign="Left">
            </asp:BoundField>
            <asp:BoundField DataField="DataExpedienteConcessao" HeaderText="Data Concessão" SortExpression="DataExpedienteConcessao"
                HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="15%" ItemStyle-HorizontalAlign="Left"
                DataFormatString="{0:dd/MM/yyyy}"></asp:BoundField>
            <asp:BoundField DataField="DataExpedienteConcessaoPublicacao" HeaderText="Data Publicação"
                SortExpression="DataExpedienteConcessaoPublicacao" HeaderStyle-HorizontalAlign="Left"
                ItemStyle-Width="15%" ItemStyle-HorizontalAlign="Left" DataFormatString="{0:dd/MM/yyyy}">
            </asp:BoundField>
        </Columns>
        <EmptyDataRowStyle CssClass="obj_Grid_Row_Nao_Localizado" />
    </pro:ProGridView>
    <div style="text-align: right">
        <asp:Button ID="btnNovoUC" runat="server" Text="Adicionar item" CssClass="obj_Btn_Box" />
        <asp:Button ID="btnNovoUCItens" runat="server" Text="Adicionar mútiplos itens" OnClick="btnNovoUCItens_Click"
            CssClass="obj_Btn_Box" Enabled="false" />
        <asp:Button ID="btnSuspenderSelecionados" runat="server" OnClick="btnSuspenderItensSelecionados_OnClick"
            Text="Suspender" CssClass="obj_Btn_Box" />
    </div>
</pro:ProPanel>
<div id="divCadastroUC" style="display: none; width: 600px;">
    <pro:ProPanel ID="pnlManutencaoUC" runat="server">
        <pro:ProTextBox ID="txtIdPaiManutencao" runat="server" DataField="AgentePublico"
            Visible="false" DataType="Number" />
        <div id="LAY_CONTENT_CENTER_POPUP" style="height: 200px;">
            <div id="LAY_CONTENT_LEFT_POPUP">
                <div id="LAY_CONTENT_RIGHT_POPUP">
                    <div id="LAY_TITULO_POPUP">
                        <asp:Label ID="lblTitulo" runat="server"></asp:Label>
                        <div id="LAY_BOTAO_FECHAR_POPUP">
                            <asp:Image ID="imgFecharUC" runat="server" ImageUrl="~/Parts/Thema1/btnClose.png">
                            </asp:Image></div>
                    </div>
                    <div class="Esq">
                        <pro:ProTextBox ID="txtIdAgenteItem" runat="server" CssClass="obj_Controle" DataField="Id"
                            Label="Id:" DataType="Number" Visible="false"></pro:ProTextBox>
                    </div>
                    <div class="ColEsquerdaPopup" style="width: 139px; padding-left: 100px;">
                        <table align="left" border="0" cellpadding="0" cellspacing="0" style="vertical-align: top;
                            text-align: left">
                            <tr>
                                <td colspan="2">
                                    <pro:ProDropDownList ID="ddlItemRemuneratorio" runat="server" CssClass="obj_Controle_Obrigatorio_M"
                                        CssClassFocus="obj_Controle_Obrigatorio_Focus_M" LabelPosition="Beside" DataField="ItemRemuneratorio"
                                        ToolTip="Informe o item remuneratório." DefaultText="Selecione um item remuneratório"
                                        LabelAjuda="labelAjudaComissao" Label="Item:" DataType="Number">
                                    </pro:ProDropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <pro:ProTextBox ID="txtNumeroExpediente" runat="server" CssClass="obj_Controle_Obrigatorio_P "
                                        DataField="NumeroExpediente" Label="Número:" ToolTip="Informe o número do expediente."
                                        MaxLength="10" CssClassFocus="obj_Controle_Obrigatorio_Focus_P"></pro:ProTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <pro:ProDropDownList ID="ddlTipoExpediente" runat="server" CssClass="obj_Controle_Obrigatorio_M"
                                        CssClassFocus="obj_Controle_Obrigatorio_Focus_M" LabelPosition="Beside" DataField="TipoExpediente"
                                        ToolTip="Informe o tipo expediente concessão." DefaultText="Selecione um tipo expediente concessão"
                                        LabelAjuda="labelAjudaComissao" Label="Tipo Expedição:" DataType="Number">
                                    </pro:ProDropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <pro:ProTextBox ID="txtDataExpedienteConcessao" runat="server" CssClass="obj_Controle_Obrigatorio_PP "
                                        DataField="DataExpedienteConcessao" Label="Data:" DataType="Date" CssClassFocus="obj_Controle_Obrigatorio_Focus_PP"
                                        ToolTip="Informe a data do expediente da concessão."></pro:ProTextBox>
                                    <asp:ImageButton runat="server" ID="btnDataExpedienteConcessao" ImageUrl="~/Parts/Thema2/images/ico_calendar.gif"
                                        CssClass="cssCalendar" />
                                    <cc1:CalendarExtender runat="server" ID="ceDataExpediente" TargetControlID="txtDataExpedienteConcessao"
                                        PopupButtonID="btnDataExpedienteConcessao" Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                                </td>
                                <td>
                                    <pro:ProTextBox ID="txtDataExpedienteConcessaoPublicacao" runat="server" CssClass="obj_Controle_Obrigatorio_PP"
                                        DataField="DataExpedienteConcessaoPublicacao" Label="Data da Publicação:" DataType="Date"
                                        CssClassFocus="obj_Controle_Obrigatorio_Focus_PP" ToolTip="Informe a data da publicação do expediente da concessão."></pro:ProTextBox>
                                    <asp:ImageButton runat="server" ID="btnDataExpedientePublicacao" ImageUrl="~/Parts/Thema2/images/ico_calendar.gif"
                                        CssClass="cssCalendar" />
                                    <cc1:CalendarExtender runat="server" ID="ceDataExpedientePublicacao" TargetControlID="txtDataExpedienteConcessaoPublicacao"
                                        PopupButtonID="btnDataExpedientePublicacao" Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <pro:ProGridView ID="grdListagemItens" runat="server" CssClass="obj_Grid" GridLines="None"
                                        Width="250px" AllowPaging="false" AutoPostBack="False" DataKeyNames="Id" ShowTotalRegisters="false"
                                        AutoGenerateSelectColumn="true" SelectionMode="Multiple" AutoGenerateColumns="false"
                                        ShowFooter="true" Visible="true">
                                        <HeaderStyle CssClass="obj_Grid_Header" />
                                        <AlternatingRowStyle CssClass="obj_Grid_AlternatingRow" />
                                        <RowStyle CssClass="obj_Grid_Row" />
                                        <SelectedRowStyle CssClass="obj_Grid_SelectedRow" />
                                        <PagerStyle CssClass="obj_Grid_Pager" />
                                        <Columns>
                                            <asp:BoundField DataField="CodItem" SortExpression="CodItem" HeaderText="Código"
                                                HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="20%" ItemStyle-HorizontalAlign="Left">
                                            </asp:BoundField>
                                            <asp:BoundField DataField="DscItens" HeaderText="Descrição" SortExpression="DscItens"
                                                HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="65%" ItemStyle-HorizontalAlign="Left">
                                            </asp:BoundField>
                                        </Columns>
                                        <EmptyDataRowStyle CssClass="obj_Grid_Row_Nao_Localizado" />
                                    </pro:ProGridView>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
            <div class="statusBar">
                <label id="labelAjudaComissao" class="Ajuda">
                </label>
            </div>
            <div class="obj_Popup_Aba_Commands">
                <asp:Button ID="btnSalvarUC" runat="server" Text="Salvar" CssClass="obj_Btn_Command"
                    CommandName="Salvar" Width="65px" />
                <asp:Button ID="btnExcluirUC" runat="server" Text="Excluir" CssClass="obj_Btn_Command"
                    OnClientClick="messageBox(this,'PERGUNTA','SIMNAO','Confirmação de exclusão','Deseja realmente excluir este item ?',''); return false;"
                    CommandName="Excluir" Width="65px" Visible="false" />
                <asp:Button ID="btnCancelarUC" runat="server" Text="Cancelar" CssClass="obj_Btn_Command"
                    Width="65px" />
            </div>
        </div>
    </pro:ProPanel>
</div>
<cc1:ModalPopupExtender ID="mpeUC" runat="server" PopupControlID="divCadastroUC"
    BackgroundCssClass="BackGroundPopup" TargetControlID="hdnBtn1" CancelControlID="imgFecharUC"
    OkControlID="btnCancelarUC" PopupDragHandleControlID="LAY_TITULO_POPUP" />
<asp:HiddenField ID="hdnBtn1" runat="server" />
<cc1:ModalPopupExtender ID="mpeSuspensaoItem" runat="server" PopupControlID="divCadastroUCSuspensaoItem"
    BackgroundCssClass="BackGroundPopup" TargetControlID="hdnBtn2" CancelControlID="imgFecharUC">
</cc1:ModalPopupExtender>
<asp:HiddenField ID="hdnBtn2" runat="server" />
<div id="divCadastroUCSuspensaoItem" style="display: none; width: 600px;">
    <pro:ProPanel ID="pnlManutencaoUCSuspensao" runat="server">
        <div id="LAY_CONTENT_CENTER_POPUP" style="height: 295px; width: 500px;">
            <div id="LAY_CONTENT_LEFT_POPUP">
                <div id="LAY_CONTENT_RIGHT_POPUP">
                    <div id="LAY_TITULO_POPUP">
                        <asp:Label ID="lblSuspensao" runat="server" Text="Suspensão"></asp:Label>
                        <div id="LAY_BOTAO_FECHAR_POPUP">
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
                                <asp:Button ID="btnCancelarSuspensao" runat="server" Text="Cancelar" OnClick="btnCancelarSuspensao_OnClick"
                                    CssClass="obj_Btn_Box" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </pro:ProPanel>
</div>
