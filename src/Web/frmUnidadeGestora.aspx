<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true"
    CodeBehind="frmUnidadeGestora.aspx.cs" Inherits="Platinium.Web.UnidadeGestora"
    Title="Untitled Page" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="Pro.Controls" Namespace="Pro.Controls" TagPrefix="pro" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/ucCabecalhoObrigatorio.ascx" TagName="ucObrigatorio" TagPrefix="obr" %>
<%@ Register Src="UserControls/ucEndereco.ascx" TagName="ucEndereco" TagPrefix="uc1" %>
<%@ Register src="UserControls/ucUnidadeGestoraOrcamentaria.ascx" tagname="ucUnidadeGestoraOrcamentaria" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphPadrao" runat="Server">
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
                                <td style="width: 60px">
                                    <asp:Label ID="lblOrgao" runat="server" Text="Órgão:" CssClass="LabelFiltro"></asp:Label>
                                </td>
                                <td>
                                    <pro:ProDropDownList ID="ddlBuscaOrgao" runat="server" CssClass="obj_Controle_M"
                                        ToolTip="Informe o órgão a ser filtrado." CssClassFocus="obj_Controle_Focus_M"
                                        DefaultText="Todos os Órgãos ." DataField="Entidade" DataType="Number" />
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 60px">
                                    <asp:Label ID="lblBuscar" runat="server" Text="Buscar por:" CssClass="LabelFiltro"></asp:Label>
                                </td>
                                <td>
                                    <pro:ProDropDownList ID="ddlCampoBusca" runat="server" ToolTip="Selecione a coluna que será filtrada."
                                        CssClass="obj_Controle" Width="130px" />
                                    <asp:Label ID="lblBusca" runat="server"></asp:Label><pro:ProTextBox ID="txtBusca"
                                        runat="server" Width="106px" CssClass="obj_Controle" ToolTip="Informe o texto para busca."></pro:ProTextBox>
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
                                    PageSize="15" GridLines="None" Width="100%">
                                    <HeaderStyle CssClass="obj_Grid_Header" />
                                    <AlternatingRowStyle CssClass="obj_Grid_AlternatingRow" />
                                    <RowStyle CssClass="obj_Grid_Row" />
                                    <SelectedRowStyle CssClass="obj_Grid_SelectedRow" />
                                    <PagerStyle CssClass="obj_Grid_Pager" />
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemStyle Width="20px" HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgEdit" runat="server" CommandName="Edit" ImageUrl="~/Parts/Thema2/images/icons_container/edit-archive.png"
                                                    ToolTip="Editar" /></ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemStyle Width="20px" HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgDelete" runat="server" CommandName="Delete" ImageUrl="~/Parts/Thema2/images/icons_container/delete.png"
                                                    OnClientClick="messageBox(this,'PERGUNTA','SIMNAO','Confirmação de exclusão','Deseja realmente excluir este item ?',''); return false;"
                                                    ToolTip="Deletar" /></ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Codigo" HeaderStyle-HorizontalAlign="left" HeaderText="Código"
                                            ItemStyle-Width="5%" ItemStyle-HorizontalAlign="left" SortExpression="Codigo">
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Descricao" HeaderStyle-HorizontalAlign="Left" HeaderText="Descrição"
                                            ItemStyle-Width="55%" SortExpression="Descricao"></asp:BoundField>
                                        <asp:BoundField DataField="DscSigla" HeaderStyle-HorizontalAlign="Left" HeaderText="Orgão"
                                            ItemStyle-Width="10%" SortExpression="DscSigla"></asp:BoundField>
                                        <asp:BoundField DataField="DataCriacao" HeaderStyle-HorizontalAlign="Left" HeaderText="Data de criação"
                                            ItemStyle-Width="10%" SortExpression="DataCriacao"></asp:BoundField>
                                        <asp:BoundField DataField="NumLei" HeaderStyle-HorizontalAlign="Left" HeaderText="Lei de criação"
                                            ItemStyle-Width="10%" SortExpression="NumLei"></asp:BoundField>
                                        <asp:BoundField DataField="DscAtivo" HeaderStyle-HorizontalAlign="left" HeaderText="Ativo"
                                            ItemStyle-HorizontalAlign="left" ItemStyle-Width="5%" SortExpression="DscAtivo">
                                        </asp:BoundField>
                                    </Columns>
                                    <EmptyDataRowStyle CssClass="obj_Grid_Row_Nao_Localizado" />
                                </pro:ProGridView>
                            </div>
                        </pro:ProPanel>
                    </asp:View>
                    <asp:View ID="vwCadastro" runat="server">
                        <div class="obj_Conteudo txt_padrao" style="min-height: 549px;">
                            <pro:ProPanel ID="pnlManutencao" runat="server" BorderWidth="0px" Height="100%">
                                <obr:ucObrigatorio ID="ucObrigatorio1" runat="server" />
                                <div class="ColEsquerda">
                                    <table align="center" border="0" cellpadding="0" cellspacing="0" style="vertical-align: top;
                                        text-align: center">
                                        <tr>
                                            <td class="linha_rotulo" style="height: 15px" width="120">
                                                <pro:ProTextBox ID="txtCodigo" runat="server" CssClass="obj_Controle_Obrigatorio_P"
                                                    CssClassFocus="obj_Controle_Obrigatorio_Focus_P" DataField="Codigo" Label="Código:"
                                                    ToolTip="Informe o código da secretaria." MaxLength="8"></pro:ProTextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="linha_rotulo" style="height: 15px">
                                                <pro:ProTextBox ID="txtDescricao" runat="server" CssClass="obj_Controle_Obrigatorio_M"
                                                    CssClassFocus="obj_Controle_Obrigatorio_Focus_M" DataField="Descricao" Label="Descrição:"
                                                    ToolTip="Informe a descrição da secretaria."></pro:ProTextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="linha_rotulo" style="height: 15px">
                                                <pro:ProDropDownList ID="ddlOrgao" runat="server" CssClass="obj_Controle_Obrigatorio_M"
                                                    CssClassFocus="obj_Controle_Obrigatorio_Focus_M" ToolTip="Informe o órgão." Label="Órgão"
                                                    LabelPosition="Top" DataField="Entidade" DataType="Number" DefaultText="Selecione o orgão.">
                                                </pro:ProDropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="linha_rotulo" style="height: 15px" width="120">
                                                <pro:ProTextBox ID="txtNumLei" runat="server" CssClass="obj_Controle_P"
                                                    CssClassFocus="obj_Controle_Focus_P" DataField="NumLei" Label="Nº da Lei de criação"
                                                    ToolTip="Informe a lei de criação." MaxLength="10"></pro:ProTextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="linha_rotulo" colspan="1" style="height: 15px; width: 120px;">
                                                <pro:ProTextBox ID="txtDataCriacao" runat="server" CssClass="obj_Controle_Obrigatorio_P"
                                                    CssClassFocus="obj_Controle_Obrigatorio_Focus_P" DataField="DataCriacao" Label="Data de Criação:"
                                                    DataType="Date"></pro:ProTextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="linha_rotulo" colspan="1" style="height: 15px; width: 120px;">
                                                <pro:ProTextBox ID="txtDataExtincao" runat="server" CssClass="obj_Controle_P" CssClassFocus="obj_Controle_Focus_P"
                                                    DataField="DataExtincao" Label="Data de Extinção:" DataType="Date"></pro:ProTextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="linha_rotulo" style="height: 15px" width="120">
                                                <pro:ProCheckBox ID="chkAtivo" DataField="Ativo" Text="Ativo ?" runat="server" IncludeTopSpace="False"
                                                    DataType="Boolean" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="linha_rotulo" style="height: 15px" width="120">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>

                                                <uc2:ucUnidadeGestoraOrcamentaria ID="ucUnidadeGestoraOrcamentaria1" 
                                                    runat="server" />

                                            </td>
                                        </tr>
                                    </table>
                                </div>
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
</asp:Content>
