<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true"
    CodeBehind="frmFolhaPagamento.aspx.cs" Inherits="Platinium.Web.frmFolhaPagamento" %>

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
                        <table width="100%">
                            <tr>
                                <td>
                                    <asp:Label ID="lblBuscar" runat="server" Text="Buscar por:" CssClass="LabelFiltro"></asp:Label>
                                </td>
                                <td>
                                    <pro:ProDropDownList ID="ddlCampoBusca" runat="server" ToolTip="Selecione a coluna que será filtrada."
                                        CssClass="obj_Controle" Width="130px" />
                                    <asp:Label ID="lblBusca" runat="server"></asp:Label><pro:ProTextBox ID="txtBusca"
                                        runat="server" Width="305px" CssClass="obj_Controle" ToolTip="Informe o texto para busca."></pro:ProTextBox>
                                </td>
                                <td style="float: right;">
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
                                        <asp:BoundField DataField="DscOrgao" HeaderText="Órgão" SortExpression="DscOrgao">
                                            <HeaderStyle HorizontalAlign="Left" Width="25%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DscUnidadeOrcamentaria" HeaderText="Unidade Orçamentária"
                                            SortExpression="DscUnidadeOrcamentaria">
                                            <HeaderStyle HorizontalAlign="Left" Width="25%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DscTipoFolha" HeaderText="Tipo da Folha" SortExpression="DscTipoFolha">
                                            <HeaderStyle HorizontalAlign="Left" Width="25%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DataEmissao" HeaderText="Data de Emissão"
                                            ItemStyle-Width="10%" SortExpression="DataEmissao" HeaderStyle-HorizontalAlign="Left"
                                            DataFormatString="{0:dd/MM/yyyy}">
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DataCompetencia" HeaderText="Data de Competência"
                                            ItemStyle-Width="10%" SortExpression="DataCompetencia" HeaderStyle-HorizontalAlign="Left"
                                            DataFormatString="{0:MM/yyyy}">
                                        </asp:BoundField>
                                    </Columns>
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
                                            <td class="linha_rotulo" style="height: 15px" colspan="3">
                                                <pro:ProDropDownList ID="ddlOrgao" runat="server" CssClass="obj_Controle_Obrigatorio"
                                                    CssClassFocus="obj_Controle_Obrigatorio_Focus" ToolTip="Informe um órgão."
                                                    DataField="Orgao" Label="Órgão:" Width="269px" DataType="Number"
                                                    LabelPosition="Top" DefaultText="Selecione um Órgão" AutoPostBack="true" OnSelectedIndexChanged="ddlOrgao_SelectedIndexChanged">
                                                </pro:ProDropDownList>
                                            </td>
                                    </tr>
                                    <tr>
                                            <td class="linha_rotulo" style="height: 15px" colspan="3">
                                                <pro:ProDropDownList ID="ddlUnidadeOrcamentaria" runat="server" CssClass="obj_Controle_Obrigatorio"
                                                    CssClassFocus="obj_Controle_Obrigatorio_Focus" ToolTip="Informe uma unidade orçamentária."
                                                    DataField="UnidadeOrcamentaria" Label="Unidade Orçamentária:" Width="269px" DataType="Number"
                                                    LabelPosition="Top" DefaultText="Selecione uma unidade orçamentária">
                                                </pro:ProDropDownList>
                                            </td>
                                    </tr>
                                    <tr>
                                            <td class="linha_rotulo" style="height: 15px" colspan="3">
                                                <pro:ProDropDownList ID="ddlTipoFolha" runat="server" CssClass="obj_Controle_Obrigatorio"
                                                    CssClassFocus="obj_Controle_Obrigatorio_Focus" ToolTip="Informe um tipo da folha."
                                                    DataField="TipoFolha" Label="Tipo da Folha:" Width="269px" DataType="Number"
                                                    LabelPosition="Top" DefaultText="Selecione um Tipo da Folha">
                                                </pro:ProDropDownList>
                                            </td>
                                    </tr>
                                     <td class="linha_rotulo" style="height: 15px">
                                                <pro:ProTextBox ID="txtDataCompetencia" runat="server" CssClass="obj_Controle_Obrigatorio_PP"
                                                    CssClassFocus="obj_Controle_Obrigatorio_Focus_PP" DataField="DataCompetencia" DataType="MonthYear"
                                                    Label="Data da Competência:" ToolTip="Informe a data da competência."></pro:ProTextBox>
                                            </td>
                                    <tr>
                                        <td>
                                            &nbsp;
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
