<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true"
    CodeBehind="frmOrigemReceita.aspx.cs" Inherits="Platinium.Web.OrigemReceita" %>

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
                                <td style="width: 108px">
                                    <asp:Label ID="lblCategoria" runat="server" Text="Categoria Econômica:" CssClass="LabelFiltro"></asp:Label>
                                </td>
                                <td>
                                    <pro:ProDropDownList ID="ddlBuscaCategoria" runat="server" CssClass="obj_Controle_M"
                                        CssClassFocus="obj_Controle_Focus_M" ToolTip="Informe a categoria econômica a ser filtrada"
                                        DefaultText="Todas as Categorias Econômicas" DataField="CategoriaEconomica" DataType="Number" />
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 108px">
                                    <asp:Label ID="lblBuscar" runat="server" Text="Buscar por:" CssClass="LabelFiltro"></asp:Label>
                                </td>
                                <td>
                                    <pro:ProDropDownList ID="ddlCampoBusca" runat="server" CssClass="obj_Controle" 
                                        Width="130px" />
                                    <asp:Label ID="lblBusca" runat="server"></asp:Label><pro:ProTextBox ID="txtBusca"
                                        runat="server" Width="106px" CssClass="obj_Controle" 
                                        ToolTip="Informe o texto para busca."></pro:ProTextBox>
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
                                    PageSize="15" AutoGenerateColumns="False" AutoPostBack="True" CssClass="obj_Grid"
                                    DataKeyNames="Id" EnableModelValidation="True" GridLines="None" Width="100%">
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
                                        <asp:BoundField DataField="Codigo" HeaderText="Código" ItemStyle-Width="5%" SortExpression="Codigo"
                                            HeaderStyle-HorizontalAlign="Left">
                                            <ItemStyle Width="5%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Descricao" HeaderStyle-HorizontalAlign="Left" HeaderText="Descrição"
                                            ItemStyle-Width="75%" SortExpression="Descricao">
                                            <HeaderStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DescricaoCategoria" HeaderStyle-HorizontalAlign="Left"
                                            HeaderText="Categoria Econômica" ItemStyle-Width="10%" SortExpression="DescricaoCategoria">
                                            <HeaderStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DescricaoAtivo" HeaderText="Ativo" HeaderStyle-HorizontalAlign="Left"
                                            SortExpression="DescricaoAtivo" ItemStyle-HorizontalAlign="left" ItemStyle-Width="5%" />
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
                                        <td class="linha_rotulo" style="height: 15px">
                                            <pro:ProTextBox ID="txtCod1" CssClass="obj_Controle_Obrigatorio" CssClassFocus="obj_Controle_Obrigatorio_Focus"
                                                ToolTip="Informe o código da categoria econômica." Label="Código:" runat="server"
                                                MaxLength="1" Width="20px" IncludeTopSpace="false"></pro:ProTextBox>
                                            <pro:ProTextBox ID="txtCod2" CssClass="obj_Controle_Obrigatorio" CssClassFocus="obj_Controle_Obrigatorio_Focus"
                                                ToolTip="Informe o código da origem de receita." runat="server" MaxLength="1"
                                                Width="20px"></pro:ProTextBox>
                                            <pro:ProTextBox ID="txtCod3" CssClass="obj_Controle_Obrigatorio" CssClassFocus="obj_Controle_Obrigatorio_Focus"
                                                ToolTip="Informe o código." runat="server" MaxLength="1" Width="20px" Enabled="false"
                                                BackColor="#CCCCCCCC"></pro:ProTextBox>
                                            <pro:ProTextBox ID="txtCod4" CssClass="obj_Controle_Obrigatorio" CssClassFocus="obj_Controle_Obrigatorio_Focus"
                                                ToolTip="Informe o código." runat="server" MaxLength="1" Width="20px" Enabled="false"
                                                BackColor="#CCCCCCCC"></pro:ProTextBox>
                                            <pro:ProTextBox ID="txtCod5" CssClass="obj_Controle_Obrigatorio" CssClassFocus="obj_Controle_Obrigatorio_Focus"
                                                ToolTip="Informe o código." runat="server" MaxLength="2" Width="20px" Enabled="false"
                                                BackColor="#CCCCCCCC"></pro:ProTextBox>
                                            <pro:ProTextBox ID="txtCod6" CssClass="obj_Controle_Obrigatorio" CssClassFocus="obj_Controle_Obrigatorio_Focus"
                                                ToolTip="Informe o código." runat="server" MaxLength="2" Width="20px" Enabled="false"
                                                BackColor="#CCCCCCCC"></pro:ProTextBox>
                                            <pro:ProTextBox ID="txtCodigo" CssClass="obj_Controle_Obrigatorio" CssClassFocus="obj_Controle_Obrigatorio_Focus"
                                                ToolTip="Informe o código da origem da receita." DataField="Codigo" Label="Código:"
                                                runat="server" MaxLength="8" Width="20px" Visible="false"></pro:ProTextBox>
                                            <asp:Button ID="btrPreencherCombos" runat="server" Text="..." OnClick="btrPreencherCombos_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="linha_rotulo" colspan="3" style="height: 15px">
                                            <pro:ProTextBox ID="txtDescricao" runat="server" CssClass="obj_Controle_Obrigatorio_M"
                                                CssClassFocus="obj_Controle_Obrigatorio_Focus_M" ToolTip="Informe a descrição da origem da receita."
                                                DataField="Descricao" Label="Descrição:" TabIndex="3"></pro:ProTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="linha_rotulo" colspan="3" style="height: 15px">
                                            <pro:ProDropDownList ID="ddlCategoriaEconomica" runat="server" CssClass="obj_Controle_Obrigatorio_M"
                                                CssClassFocus="obj_Controle_Obrigatorio_Focus_M" ToolTip="Informe uma categoria econômica da origem da receita."
                                                Label="Categoria Econômica" LabelPosition="Top" DataField="CategoriaEconomica"
                                                DataType="Number" DefaultText="Selecione uma categoria econômica." OnSelectedIndexChanged="ddlCategoriaEconomica_OnSelectedIndexChanged"
                                                AutoPostBack="true">
                                            </pro:ProDropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="linha_rotulo" style="height: 15px" width="120">
                                            <pro:ProCheckBox ID="chkAtivo" DataField="Ativo" Text="Ativo ?" runat="server" IncludeTopSpace="False" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="linha_rotulo" style="height: 15px">
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="linha_rotulo">
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
