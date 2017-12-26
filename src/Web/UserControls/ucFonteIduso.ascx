<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucFonteIduso.ascx.cs"
    Inherits="Platinium.Web.ucFonteIduso" %>
<%@ Register Assembly="Pro.Controls" Namespace="Pro.Controls" TagPrefix="pro" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<pro:ProPanel ID="pnlConsultaUC" runat="server" Width="650px" GroupingText="Indicadores de uso">
    <pro:ProTextBox ID="txtIdPaiConsulta" runat="server" DataField="Fonte" Visible="false"
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
            <asp:ButtonField ButtonType="Image" ImageUrl="~/Parts/Thema2/images/icons_container/edit-archive.png" CommandName="Edit"
                ItemStyle-Width="16px" Text="Alterar" />
            <asp:TemplateField ItemStyle-Width="16px">
                <ItemTemplate>
                    <asp:ImageButton ID="imgDelete" ImageUrl="~/Parts/Thema2/images/icons_container/delete.png" runat="server"
                        CommandName="Delete" OnClientClick="messageBox(this,'PERGUNTA','SIMNAO','Confirmação de exclusão','Deseja realmente excluir este item ?',''); return false;" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="CodIduso" HeaderText="Cód. Iduso" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="5%"
                ItemStyle-HorizontalAlign="Left" SortExpression="CodIduso"></asp:BoundField>
            <asp:BoundField DataField="DscIduso" HeaderText="Iduso" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="90%"
                ItemStyle-HorizontalAlign="Left" SortExpression="DscIduso" ></asp:BoundField>
        </Columns>
        <EmptyDataRowStyle CssClass="obj_Grid_Row_Nao_Localizado" />
    </pro:ProGridView>
    <div style="text-align: right">
        <asp:Button ID="btnNovoUC" runat="server" Text="Novo iduso" CssClass="obj_Btn_Box" />
    </div>
</pro:ProPanel>
<div id="divCadastroUC" style="display: none; width: 500px;">
    <pro:ProPanel ID="pnlManutencaoUC" runat="server">
        <pro:ProTextBox ID="txtIdPaiManutencao" runat="server" DataField="Fonte" Visible="false"
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
                    <div class="Esq">
                    <div class="Dir"><pro:ProTextBox ID="txtIdComissao" runat="server" CssClass="obj_Controle" DataField="Id"
                                    Label="Id:"  DataType="Number" Visible="false"></pro:ProTextBox>

                                    <pro:ProDropDownList ID="ddlIduso" runat="server" CssClass="obj_Controle_Obrigatorio_M"
                                     CssClassFocus="obj_Controle_Obrigatorio_Focus_M" LabelPosition="Beside" DataField="Iduso"
                                    ToolTip="Informe o identificador de uso." DefaultText="Selecione um identificador de uso"
                                     LabelAjuda="labelAjudaComissao" Label="Identificador de uso:" DataType="Number" ></pro:ProDropDownList></div>
                   
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