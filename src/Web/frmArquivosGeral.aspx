<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true"
    CodeBehind="frmArquivosGeral.aspx.cs" Inherits="Web.Arquivos.ArquivosGeral"
    Title="Untitled Page" %>

<%@ Register Assembly="Pro.Controls" Namespace="Pro.Controls" TagPrefix="pro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphPadrao" runat="server">
    <div class="obj_txt_padrao">
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
                    <pro:ProPanel ID="pnlFiltros" runat="server" BorderWidth="0px" Height="100%" Width="100%"
                        GroupingText="Filtros">
                        <table align="center" style="vertical-align: top; width: 98%; text-align: left" border="0"
                            cellpadding="0" cellspacing="0">
                            <tr>
                                <td class="linha_rotulo" style="width: 157px; text-align: left; height: 20px;">
                                    <br />
                                    <pro:ProLabel ID="lblSecretaria" Text="Arquivo: " runat="server" CssClass="LabelFiltro"></pro:ProLabel>
                                </td>
                                <td class="linha_rotulo">
                                    <pro:ProDropDownList runat="server" ID="ddlArquivo" CssClass="obj_Controle_M" CssClassFocus="obj_Controle_Focus_M"
                                        DefaultText="Selecione um arquivo." DataField="Arquivo">
                                    </pro:ProDropDownList>
                                </td>
                                <td class="linha_rotulo">
                                    <asp:Button ID="btnDetalhes" runat="server" Width="120px" CssClass="obj_Btn_Command"
                                        Text="Detalhar arquivo" OnClick="btnDetalhes_Click" />
                                </td>
                                <td class="linha_rotulo">
                                </td>
                                <td align="right" class="linha_rotulo" rowspan="3" style="width: 50%;">
                                </td>
                            </tr>
                            <tr>
                                <td class="linha_rotulo" style="width: 200px; height: 20px;">
                                    <br />
                                    <pro:ProLabel ID="lblOrgao" Text="Mês referência: " runat="server" CssClass="LabelFiltro"></pro:ProLabel>
                                </td>
                                <td class="linha_rotulo">
                                    <pro:ProTextBox ID="txtMes" runat="server" CssClass="obj_Controle_P" CssClassFocus="obj_Controle_Focus_P"
                                        DataType="MonthYear"></pro:ProTextBox>
                                </td>
                                <td class="linha_rotulo">
                                </td>
                                <td class="linha_rotulo">
                                </td>
                                <td align="right" class="linha_rotulo">
                                </td>
                            </tr>
                            <tr>
                                <td class="linha_rotulo" colspan="4">
                                    <pro:ProCheckBox ID="chkSepararVirgula" runat="server" Label="Separar por vírgula (strings)"
                                        LabelCssClass="LabelFiltro" LabelPosition="Beside"></pro:ProCheckBox>
                                </td>
                            </tr>
                            <td class="linha_rotulo" colspan="4">
                                <pro:ProCheckBox ID="chkAspasDuplas" runat="server" Label="Aspas duplas em tipo texto"
                                    LabelCssClass="LabelFiltro" LabelPosition="Beside"></pro:ProCheckBox>
                            </td>
                            <tr>
                                <td class="linha_rotulo" colspan="4">
                                    <pro:ProCheckBox ID="chkRemoverEspeciais" runat="server" Label="Sem caracteres especiais"
                                        LabelCssClass="LabelFiltro" LabelPosition="Beside"></pro:ProCheckBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="linha_rotulo" colspan="4">
                                    <pro:ProCheckBox ID="chkTrocarPonto" runat="server" Label="Trocar '.' por ','" LabelCssClass="LabelFiltro"
                                        LabelPosition="Beside"></pro:ProCheckBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="linha_rotulo" colspan="4">
                                    <pro:ProCheckBox ID="chkRemoverPontoVirgula" runat="server" Label="Remover '.' e ','" LabelCssClass="LabelFiltro"
                                        LabelPosition="Beside"></pro:ProCheckBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="linha_rotulo" colspan="2" style="width: 20%; padding-top: 30px; height: 20px;">
                                    <asp:Button ID="btnGerar" runat="server" Text="Gerar arquivo" CssClass="obj_Btn_Command"
                                        Width="120px" />
                                    <asp:Button ID="btnVisualizarArquivo" runat="server" Text="Visualizar arquivo" CssClass="obj_Btn_Command"
                                        Width="120px" OnClick="btnVisualizarArquivo_Click" />
                                </td>
                                <td class="linha_rotulo" style="width: 20%">
                                </td>
                                <td class="linha_rotulo" style="width: 20%">
                                </td>
                                <td class="linha_rotulo" style="width: 20%">
                                </td>
                                <td class="linha_rotulo" style="width: 20%">
                                </td>
                            </tr>
                            <tr>
                                <td colspan="5" style="width: 100%">
                                    <pro:ProGridView ID="grdListagem" runat="server" AllowPaging="false" AutoGenerateColumns="false"
                                        CssClass="obj_Grid" EnableModelValidation="True" GridLines="None" Width="100%">
                                        <HeaderStyle CssClass="obj_Grid_Header" />
                                        <AlternatingRowStyle CssClass="obj_Grid_AlternatingRow" />
                                        <RowStyle CssClass="obj_Grid_Row" />
                                        <SelectedRowStyle CssClass="obj_Grid_SelectedRow" />
                                        <PagerStyle CssClass="obj_Grid_Pager" />
                                        <Columns>
                                            <asp:BoundField DataField="Sequencia" HeaderText="Sequência" />
                                            <asp:BoundField DataField="Descricao" HeaderText="Descrição" />
                                            <asp:BoundField DataField="Posicoes" HeaderText="Qtd. Posições" ItemStyle-Width="80px" />
                                            <asp:BoundField DataField="Detalhes" HeaderText="Detalhes" />
                                        </Columns>
                                        <EmptyDataRowStyle CssClass="obj_Grid_Row_Nao_Localizado" />
                                    </pro:ProGridView>
                                </td>
                            </tr>
                        </table>
                    </pro:ProPanel>
                    <br />
                    <br />
                </div>
                <div class="b">
                    <div class="b">
                        <div class="b">
                        </div>
                    </div>
                </div>
                <div class="clr">
                </div>
            </div>
        </div>
    </div>
</asp:Content>
