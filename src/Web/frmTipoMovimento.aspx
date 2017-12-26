<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true"
    CodeBehind="frmTipoMovimento.aspx.cs" Inherits="Platinium.Web.TipoMovimento" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="Pro.Controls" Namespace="Pro.Controls" TagPrefix="pro" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/ucCabecalhoObrigatorio.ascx" TagName="ucObrigatorio" TagPrefix="obr" %>
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
                        <pro:ProDropDownList Label="Buscar por: " LabelPosition="Beside" LabelCssClass="LabelFiltro"
                            ID="ddlCampoBusca" runat="server" CssClass="obj_Controle" />
                        <asp:Label ID="lblBusca" runat="server"></asp:Label><pro:ProTextBox ID="txtBusca"
                            runat="server" Width="200px" CssClass="obj_Controle" ToolTip="Informe o texto para busca."></pro:ProTextBox>
                        <asp:Button ID="btnBuscar" runat="server" CssClass="obj_Btn_Command" Text="Buscar"
                            Width="50px" />
                        <asp:Button ID="btnNovo" runat="server" Text="Novo" CssClass="obj_Btn_Command" CommandName="Novo"
                            Width="65px" />
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
                                        <asp:BoundField DataField="Codigo" HeaderText="Código" SortExpression="Codigo" ItemStyle-HorizontalAlign="Center">
                                            <ItemStyle Width="5%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Descricao" HeaderStyle-HorizontalAlign="Left" HeaderText="Descrição"
                                            ItemStyle-Width="70%" SortExpression="Descricao">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle Width="70%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DscTipo" HeaderStyle-HorizontalAlign="Left" HeaderText="Tipo do Movimento"
                                            ItemStyle-Width="5%" SortExpression="DscTipo">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle Width="5%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DataCriado" HeaderStyle-HorizontalAlign="Left" HeaderText="Data de Criação"
                                            ItemStyle-Width="10%" SortExpression="DataCriado" DataFormatString="{0:d}">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle Width="10%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DscAtivo" HeaderText="Ativo" SortExpression="DscAtivo" ItemStyle-HorizontalAlign="Center" />
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
                                <table align="center" border="0" cellpadding="0" cellspacing="0" width="95%" style="vertical-align: top;
                                    width: 95%; text-align: center">
                                    <tr>
                                        <td class="linha_rotulo" style="height: 15px; width: 188px;">
                                            <pro:ProTextBox ID="txtCodigo" CssClass="obj_Controle_Obrigatorio_P" CssClassFocus="obj_Controle_Obrigatorio_Focus_P"
                                                ToolTip="Informe o código do tipo de movimento." DataField="Codigo" Label="Código:"
                                                runat="server" MaxLength="2" ></pro:ProTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="linha_rotulo" style="height: 15px; width: 188px;">
                                            <pro:ProTextBox ID="txtDescricao" runat="server" CssClass="obj_Controle_Obrigatorio_M"
                                                CssClassFocus="obj_Controle_Obrigatorio_Focus_M" ToolTip="Informe a descrição do tipo de movimento."
                                                DataField="Descricao" Label="Descrição:"></pro:ProTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="linha_rotulo" style="height: 15px">
                                            <pro:ProRadioButtonList ID="rdtTipo" runat="server" RepeatDirection="Horizontal"
                                                Width="50px" DataField="Tipo" Height="50px" >
                                                <asp:ListItem Text="Crédito" Value="C" />
                                                <asp:ListItem Text="Débito" Value="D" />
                                            </pro:ProRadioButtonList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 188px">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="linha_rotulo" style="height: 15px; width: 188px;">
                                            <pro:ProCheckBox ID="chkAtivo" DataField="Ativo" Text="Ativo ?" runat="server" IncludeTopSpace="False" />
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
</asp:Content>
