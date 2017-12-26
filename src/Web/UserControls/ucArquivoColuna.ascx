<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucArquivoColuna.ascx.cs"
    Inherits="Platinium.Web.ucArquivoColuna" %>
<%@ Register Assembly="Pro.Controls" Namespace="Pro.Controls" TagPrefix="pro" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<pro:ProPanel ID="pnlConsultaUC" runat="server" Width="650px" GroupingText="Colunas do Arquivo">
    <pro:ProTextBox ID="txtIdPaiConsulta" runat="server" DataField="Arquivo" Visible="false"
        DataType="Number" />
    <pro:ProGridView ID="grdListagemUC" runat="server" CssClass="obj_Grid" GridLines="None"
        Width="100%" AutoGenerateColumns="False" AllowSorting="true" AllowPaging="false" AutoPostBack="True"
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
            <asp:BoundField DataField="Sequencia" HeaderText="Seq." HeaderStyle-HorizontalAlign="Left"
                ItemStyle-Width="5%" SortExpression="Sequencia" ItemStyle-HorizontalAlign="Left"></asp:BoundField>
            <asp:BoundField DataField="Descricao" HeaderText="Descrição" HeaderStyle-HorizontalAlign="Left"
                ItemStyle-Width="35%" SortExpression="Descricao" ItemStyle-HorizontalAlign="Left"></asp:BoundField>
            <asp:BoundField DataField="Detalhes" HeaderText="Detalhes" HeaderStyle-HorizontalAlign="Left"
                ItemStyle-Width="60%" SortExpression="Detalhes" ItemStyle-HorizontalAlign="Left"></asp:BoundField>
        </Columns>
        <EmptyDataRowStyle CssClass="obj_Grid_Row_Nao_Localizado" />
    </pro:ProGridView>
    <div style="text-align: right">
        <asp:Button ID="btnNovoUC" runat="server" Text="Nova coluna" CssClass="obj_Btn_Box" />
    </div>
</pro:ProPanel>
<div id="divCadastroUCColuna" style="display: none; width: 500px;">
    <pro:ProPanel ID="pnlManutencaoUC" runat="server">
        <pro:ProTextBox ID="txtIdPaiManutencao" runat="server" DataField="Arquivo" Visible="false"
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
                            <td style="width: 120px">
                                <pro:ProTextBox ID="txtSequencia" CssClass="obj_Controle_Obrigatorio_P" CssClassFocus="obj_Controle_Obrigatorio_Focus_P"
                                    ToolTip="Informe a sequencia da coluna." DataField="Sequencia" Label="Sequência:"
                                    runat="server" DataType="Number"></pro:ProTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <pro:ProTextBox ID="txtDescricao" CssClass="obj_Controle_Obrigatorio_G" CssClassFocus="obj_Controle_Obrigatorio_Focus_G"
                                    ToolTip="Informe a descrição da coluna." DataField="Descricao" Label="Descrição:"
                                    runat="server" ></pro:ProTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <pro:ProTextBox ID="txtDetalhes" CssClass="obj_Controle_Obrigatorio_G" CssClassFocus="obj_Controle_Obrigatorio_Focus_G"
                                    ToolTip="Informe os detalhes da coluna." DataField="Detalhes" Label="Detalhes :"
                                    runat="server" TextMode="MultiLine" Rows="3"></pro:ProTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 120px">
                                <pro:ProTextBox ID="txtPosicoes" CssClass="obj_Controle_Obrigatorio_P" CssClassFocus="obj_Controle_Obrigatorio_Focus_P"
                                    ToolTip="Informe a quantidade de posiçõesda coluna." DataField="Posicoes" Label="Posições:"
                                    runat="server" DataType="Number"></pro:ProTextBox>
                            </td>
                            <td style="width: 120px">
                                <pro:ProTextBox ID="txtMascara" CssClass="obj_Controle_Obrigatorio_P" CssClassFocus="obj_Controle_Obrigatorio_Focus_P"
                                    ToolTip="Informe a máscara da coluna." DataField="Mascara" Label="Máscara:" runat="server"
                                    ></pro:ProTextBox>
                            </td>
                            <td style="width: 120px">
                                <pro:ProDropDownList ID="ddlTipo" CssClass="obj_Controle_Obrigatorio_P" CssClassFocus="obj_Controle_Obrigatorio_Focus_P"
                                    ToolTip="Informe o tipo da coluna." DataField="Tipo" Label="Tipo:" runat="server"
                                     DefaultText="Selecione.">
                                </pro:ProDropDownList>
                            </td>
                            <td style="width: 120px">
                                <pro:ProDropDownList ID="ddlMetodoComplemento" CssClass="obj_Controle_Obrigatorio_P"
                                    CssClassFocus="obj_Controle_Obrigatorio_Focus_P" ToolTip="Informe o método de complemento da coluna."
                                    DataField="MetodoComplemento" Label="Complemento:" runat="server" 
                                    DataType="Number" DefaultText="Selecione.">
                                </pro:ProDropDownList>
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
<cc1:ModalPopupExtender ID="mpeUC" runat="server" PopupControlID="divCadastroUCColuna"
    BackgroundCssClass="BackGroundPopup" TargetControlID="hdnBtn1" CancelControlID="imgFecharUC"
    OkControlID="btnCancelarUC" PopupDragHandleControlID="LAY_TITULO_POPUP" />
<asp:HiddenField ID="hdnBtn1" runat="server" />
