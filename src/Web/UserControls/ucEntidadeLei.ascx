<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucEntidadeLei.ascx.cs"
    Inherits="Platinium.Web.ucEntidadeLei" %>
<%@ Register Assembly="Pro.Controls" Namespace="Pro.Controls" TagPrefix="pro" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<pro:ProPanel ID="pnlConsultaUC" runat="server" Width="650px" GroupingText="Base Legal">
    <pro:ProTextBox ID="txtIdPaiConsulta" runat="server" DataField="Entidade" Visible="false"
        DataType="Number" />
    <pro:ProGridView ID="grdListagemUC" runat="server" CssClass="obj_Grid" GridLines="None"
        Width="100%" AutoGenerateColumns="False" AllowPaging="True" AllowSorting="true"
        AutoPostBack="True" DataKeyNames="Id">
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
            <asp:BoundField DataField="Descricao" HeaderText="Descrição" HeaderStyle-HorizontalAlign="Left"
                ItemStyle-Width="85%" ItemStyle-HorizontalAlign="Left" SortExpression="Descricao">
            </asp:BoundField>
            <asp:BoundField DataField="DataInicio" HeaderText="Início" HeaderStyle-HorizontalAlign="Left"
                ItemStyle-Width="5%" ItemStyle-HorizontalAlign="Left" SortExpression="DataInicio" DataFormatString="{0:dd/MM/yyyy}">
            </asp:BoundField>
            <asp:BoundField DataField="DataTermino" HeaderText="Término" HeaderStyle-HorizontalAlign="Left"
                ItemStyle-Width="5%" ItemStyle-HorizontalAlign="Left" SortExpression="DataTermino" DataFormatString="{0:dd/MM/yyyy}">
            </asp:BoundField>
        </Columns>
        <EmptyDataRowStyle CssClass="obj_Grid_Row_Nao_Localizado" />
    </pro:ProGridView>
    <div style="text-align: right">
        <asp:Button ID="btnNovoUC" runat="server" Text="Nova Base Legal" CssClass="obj_Btn_Box" />
    </div>
</pro:ProPanel>
<div id="divCadastroUC" style="display: none; width: 500px;">
    <pro:ProPanel ID="pnlManutencaoUC" runat="server">
        <pro:ProTextBox ID="txtIdPaiManutencao" runat="server" DataField="Entidade" Visible="false"
            DataType="Number" />
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
                                <pro:ProTextBox ID="txtDescricao" CssClass="obj_Controle_Obrigatorio_G" CssClassFocus="obj_Controle_Obrigatorio_Focus_G"
                                    ToolTip="Informe a descrição da lei." DataField="Descricao" Label="Descrição:"
                                    runat="server" TextMode="MultiLine" Rows="3"></pro:ProTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <pro:ProTextBox ID="txtDataInicio" CssClass="obj_Controle_Obrigatorio_P" CssClassFocus="obj_Controle_Obrigatorio_Focus_P"
                                    ToolTip="Informe a data de início da lei." DataField="DataInicio" Label="Início da lei :"
                                    runat="server" DataType="Date" ></pro:ProTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <pro:ProTextBox ID="txtDataTermino" CssClass="obj_Controle_P" CssClassFocus="obj_Controle_Focus_P"
                                    ToolTip="Informe a data de término da lei." DataField="DataTermino" Label="Término da lei :"
                                    runat="server" DataType="Date"></pro:ProTextBox>
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
<cc1:ModalPopupExtender ID="mpeUC" runat="server" PopupControlID="divCadastroUC"
    BackgroundCssClass="BackGroundPopup" TargetControlID="hdnBtn1" CancelControlID="imgFecharUC"
    OkControlID="btnCancelarUC" PopupDragHandleControlID="LAY_TITULO_POPUP" />
<asp:HiddenField ID="hdnBtn1" runat="server" />
