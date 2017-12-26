<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true"
    CodeBehind="frmFonte.aspx.cs" Inherits="Platinium.Web.Fonte" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="Pro.Controls" Namespace="Pro.Controls" TagPrefix="pro" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/ucCabecalhoObrigatorio.ascx" TagName="ucObrigatorio" TagPrefix="obr" %>
<%@ Register Src="UserControls/ucFonteIduso.ascx" TagName="ucFonteIduso" TagPrefix="uc1" %>
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
                                <td style="width: 78px">
                                    <asp:Label ID="lblGrupo" runat="server" Text="Grupo de Fonte:" CssClass="LabelFiltro"></asp:Label>
                                </td>
                                <td>
                                    <pro:ProDropDownList ID="ddlBuscaGrupo" runat="server" CssClass="obj_Controle_M"
                                        ToolTip="Informe o grupo de fonte a ser filtrado." DefaultText="Todos os Grupos de Fonte."
                                        DataField="GrpFonte" DataType="Number" CssClassFocus="obj_Controle_Focus_M" />
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 78px">
                                    <asp:Label ID="lblBuscaPor" runat="server" Text="Buscar por:" CssClass="LabelFiltro"></asp:Label>
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
                                        <asp:BoundField DataField="CodGrpFonte" HeaderText="Cód. Grupo" ItemStyle-Width="5%"
                                            SortExpression="CodGrpFonte">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle Width="5%" HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DscGrpFonte" HeaderStyle-HorizontalAlign="Left" HeaderText="Grupo de Fonte"
                                            ItemStyle-Width="20%" SortExpression="DscGrpFonte">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle Width="20%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Codigo" HeaderText="Cód. Fonte" ItemStyle-Width="5%" SortExpression="Codigo"
                                            HeaderStyle-HorizontalAlign="Left">
                                            <ItemStyle Width="5%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Descricao" HeaderText="Descrição" ItemStyle-Width="60%"
                                            SortExpression="Descricao">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle Width="60%" HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DscAtivo" HeaderText="Ativo" ItemStyle-Width="5%" SortExpression="DscAtivo">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle Width="5%" HorizontalAlign="Left" />
                                        </asp:BoundField>
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
                                        <td class="linha_rotulo" style="height: 15px; width: 112px;" colspan="0">
                                            <pro:ProTextBox ID="txtCodigo" CssClass="obj_Controle_Obrigatorio_P" CssClassFocus="obj_Controle_Obrigatorio_Focus_P"
                                                ToolTip="Informe o código da fonte." DataField="Codigo" Label="Código:" runat="server"
                                                MaxLength="2"></pro:ProTextBox>
                                        </td>
                                        <td class="linha_rotulo" style="height: 15px" colspan="0">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="linha_rotulo" style="height: 15px; width: 70px;" colspan="2">
                                            <pro:ProTextBox ID="txtSigla" CssClass="obj_Controle_P" CssClassFocus="obj_Controle_Focus_P"
                                                ToolTip="Informe a sigla da fonte." DataField="Sigla" Label="Sigla:" runat="server"
                                                MaxLength="10"></pro:ProTextBox>
                                        </td>
                                        <td class="linha_rotulo" style="height: 15px" colspan="0">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="linha_rotulo" colspan="2" style="height: 15px; width: 70px;">
                                            <pro:ProTextBox ID="txtDescricao" runat="server" CssClass="obj_Controle_Obrigatorio_M"
                                                CssClassFocus="obj_Controle_Obrigatorio_Focus_M" ToolTip="Informe a descrição da fonte."
                                                DataField="Descricao" Label="Descrição:"></pro:ProTextBox>
                                        </td>
                                        <td class="linha_rotulo" style="height: 15px" colspan="0">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="linha_rotulo" colspan="1" style="height: 15px; width: 112px;">
                                            <pro:ProTextBox ID="txtDataCriado" runat="server" CssClass="obj_Controle_P" CssClassFocus="obj_Controle_Focus_P"
                                                DataField="DataCriado" Label="Data de Criação:" DataType="Date" Visible="false"
                                                Enabled="false"></pro:ProTextBox>
                                        </td>
                                        <td class="linha_rotulo" colspan="1" style="height: 15px">
                                            <pro:ProTextBox ID="txtDataDesativado" DataType="Date" runat="server" CssClass="obj_Controle_P"
                                                DataField="DataDesativado" Enabled="false" Label="Data de Desativação:" CssClassFocus="obj_Controle_Focus_P"
                                                Visible="false"></pro:ProTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="linha_rotulo" style="height: 15px; width: 70px;" colspan="2">
                                            <pro:ProDropDownList ID="ddlGrpFonte" runat="server" CssClass="obj_Controle_Obrigatorio_M"
                                                CssClassFocus="obj_Controle_Obrigatorio_Focus_M" ToolTip="Informe o grupo da fonte."
                                                DataField="GrpFonte" Label="Grupo de Fonte:" DataType="Number" LabelPosition="Top"
                                                DefaultText="Selecione o grupo fonte">
                                            </pro:ProDropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 112px">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="linha_rotulo" style="height: 15px; width: 112px;">
                                            <pro:ProCheckBox ID="chkAtivo" DataField="Ativo" Text="Ativo ?" runat="server" IncludeTopSpace="False" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 112px">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="linha_rotulo" style="height: 15px; width: 70px;" colspan="2">
                                            <uc1:ucFonteIduso ID="ucFonteIduso1" runat="server" />
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
