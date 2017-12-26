<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucUnidadeGestoraOrcamentaria.ascx.cs"
    Inherits="Platinium.Web.ucUnidadeGestoraOrcamentaria" %>
<%@ Register Assembly="Pro.Controls" Namespace="Pro.Controls" TagPrefix="pro" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<pro:ProPanel ID="pnlConsultaUC" runat="server" Width="650px" GroupingText="Unidade Orçamentária">
    <pro:ProTextBox ID="txtIdPaiConsulta" runat="server" DataField="UnidadeGestora" Visible="false"
        DataType="Number" />
    <pro:ProGridView ID="grdListagemUC" runat="server" CssClass="obj_Grid" GridLines="None"
        Width="100%" AutoGenerateColumns="False" AllowPaging="True" AllowSorting="true" AutoPostBack="True"
        DataKeyNames="Id">
        <HeaderStyle CssClass="obj_Grid_Header" />
        <AlternatingRowStyle CssClass="obj_Grid_AlternatingRow" />
        <RowStyle CssClass="obj_Grid_Row" />
        <SelectedRowStyle CssClass="obj_Grid_SelectedRow" />
        <PagerStyle CssClass="obj_Grid_Pager" />
        <Columns>
            <asp:ButtonField ButtonType="Image" ImageUrl="~/Parts/Thema2/images/icons_container/edit-archive.png"
                CommandName="Edit" ItemStyle-Width="16px" Text="Alterar" />
            <asp:TemplateField ItemStyle-Width="16px">
                <ItemTemplate>
                    <asp:ImageButton ID="imgDelete" ImageUrl="~/Parts/Thema2/images/icons_container/delete.png"
                        runat="server" CommandName="Delete" OnClientClick="messageBox(this,'PERGUNTA','SIMNAO','Confirmação de exclusão','Deseja realmente excluir este item ?',''); return false;" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="DscUnidadeOrcamentaria" SortExpression="DscUnidadeOrcamentaria" HeaderText="Unidade Orçamentária"
                HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="75%" ItemStyle-HorizontalAlign="Left">
            </asp:BoundField>
            <asp:BoundField DataField="DataInicio" HeaderText="Data Inicial" HeaderStyle-HorizontalAlign="Left" DataFormatString="{0:dd/MM/yyyy}"
                ItemStyle-Width="10%" SortExpression="DataInicio" ItemStyle-HorizontalAlign="Left"></asp:BoundField>
            <asp:BoundField DataField="DataFim" HeaderText="Data Final" HeaderStyle-HorizontalAlign="Left" DataFormatString="{0:dd/MM/yyyy}"
                ItemStyle-Width="10%" SortExpression="DataFim" ItemStyle-HorizontalAlign="Left"></asp:BoundField>
        </Columns>
        <EmptyDataRowStyle CssClass="obj_Grid_Row_Nao_Localizado" />
    </pro:ProGridView>
    <div style="text-align: right">
        <asp:Button ID="btnNovoUC" runat="server" Text="Nova Unidade Orçamentária" CssClass="obj_Btn_Box" />
    </div>
</pro:ProPanel>
<div id="divCadastroUCResponsavel" style="display: none; width: 500px;">
    <pro:ProPanel ID="pnlManutencaoUC" runat="server">
        <pro:ProTextBox ID="txtIdPaiManutencao" runat="server" DataField="UnidadeGestora"
            Visible="false" DataType="Number" />
        <div id="LAY_CONTENT_CENTER_POPUP">
            <div id="LAY_CONTENT_LEFT_POPUP">
                <div id="LAY_CONTENT_RIGHT_POPUP">
                    <div id="LAY_TITULO_POPUP">
                        <asp:Label ID="lblTitulo" runat="server"></asp:Label>
                        <div id="LAY_BOTAO_FECHAR_POPUP">
                            <asp:Image ID="imgFecharUC" runat="server" ImageUrl="~/Parts/Thema1/btnClose.png">
                            </asp:Image></div>
                    </div>
                    <table>
                        <tr>
                            <td>
                                <pro:ProDropDownList ID="ddlUnidadeOrcamentaria" runat="server" CssClass="obj_Controle_Obrigatorio_G"
                                    CssClassFocus="obj_Controle_Obrigatorio_Focus_G" LabelPosition="Beside" DataField="UnidadeOrcamentaria"
                                    ToolTip="Informe a unidade orçamentária." DefaultText="Selecione uma unidade orçamentária"
                                    LabelAjuda="labelAjudaComissao" Label="Unidade Orçamentária:" DataType="Number">
                                </pro:ProDropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="linha_rotulo" colspan="3" style="height: 15px">
                                <pro:ProTextBox ID="txtDataInicio" runat="server" CssClass="obj_Controle_Obrigatorio_P"
                                    CssClassFocus="obj_Controle_Obrigatorio_Focus_P" ToolTip="Informe a data inicial."
                                    DataType="Date" DataField="DataInicio" Label="Data Inicial:"></pro:ProTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="linha_rotulo" colspan="3" style="height: 15px">
                                <pro:ProTextBox ID="txtDataFim" runat="server" CssClass="obj_Controle_P"
                                    CssClassFocus="obj_Controle_Focus_P" ToolTip="Informe a data final."
                                    DataType="Date" DataField="DataFim" Label="Data Final:"></pro:ProTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="linha_rotulo" style="height: 15px" width="120">
                                <pro:ProCheckBox ID="chkAtivo" DataField="Ativo" Text="Ativo ?" runat="server" IncludeTopSpace="False"
                                    DataType="Boolean" />
                            </td>
                        </tr>
                    </table>
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
<cc1:ModalPopupExtender ID="mpeUC" runat="server" PopupControlID="divCadastroUCResponsavel"
    BackgroundCssClass="BackGroundPopup" TargetControlID="hdnBtn1" CancelControlID="imgFecharUC"
    OkControlID="btnCancelarUC" PopupDragHandleControlID="LAY_TITULO_POPUP" />
<asp:HiddenField ID="hdnBtn1" runat="server" />
