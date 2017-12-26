<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true"
    CodeBehind="frmDespesa.aspx.cs" Inherits="Platinium.Web.Despesa" %>

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
                                <td style="width: 129px">
                                    <asp:Label ID="lblCategoria" runat="server" Text="Categoria econômica:" CssClass="LabelFiltro"></asp:Label>
                                </td>
                                <td>
                                    <pro:ProDropDownList ID="ddlBuscaCategoria" runat="server" CssClass="obj_Controle_G"
                                        CssClassFocus="obj_Controle_Focus_G" DataField="CatEconomica" DataType="Number"
                                        ToolTip="Informe a categoria econômica a ser filtrado." DefaultText="Todas as categorias econômicas." />
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 129px">
                                    <asp:Label ID="lblGrupo" runat="server" Text="Grupo de despesa:" CssClass="LabelFiltro"></asp:Label>
                                </td>
                                <td>
                                    <pro:ProDropDownList ID="ddlBuscaGrupoDespesa" runat="server" CssClass="obj_Controle_G"
                                        CssClassFocus="obj_Controle_Focus_G" DataField="GrupoDespesa" DataType="Number"
                                        ToolTip="Informe o grupo de despesa a ser filtrado." DefaultText="Todos os grupos de despesa." />
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 129px">
                                    <asp:Label ID="lblModalidade" runat="server" Text="Modalidade de aplicação:" CssClass="LabelFiltro"></asp:Label>
                                </td>
                                <td>
                                    <pro:ProDropDownList ID="ddlBuscaModalidade" runat="server" CssClass="obj_Controle_G"
                                        CssClassFocus="obj_Controle_Focus_G" DataField="ModalidadeAplicacao" DataType="Number"
                                        ToolTip="Informe a modalidade de aplicação a ser filtrado." DefaultText="Todas as modalidades de aplicação." />
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 129px">
                                    <asp:Label ID="lblBuscaPor" runat="server" Text="Buscar por:" CssClass="LabelFiltro"></asp:Label>
                                </td>
                                <td>
                                    <pro:ProDropDownList ID="ddlCampoBusca" runat="server" CssClass="obj_Controle" Width="130px" />
                                    <asp:Label ID="lblBusca" runat="server"></asp:Label><pro:ProTextBox ID="txtBusca"
                                        runat="server" Width="306px" CssClass="obj_Controle" ToolTip="Informe o texto para busca."></pro:ProTextBox>
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
                                    PageSize="15" EnableModelValidation="True" GridLines="None" Width="100%">
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
                                        <asp:BoundField DataField="CodDespesa" HeaderText="Código" ItemStyle-Width="5%" SortExpression="CodDespesa">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle Width="5%" HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Descricao" HeaderText="Descrição" ItemStyle-Width="85%"
                                            SortExpression="Descricao">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle Width="85%" HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DscAtivo" HeaderText="Ativo" ItemStyle-Width="5%" SortExpression="DscAtivo">
                                            <HeaderStyle HorizontalAlign="left" />
                                            <ItemStyle Width="5%" HorizontalAlign="left" />
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
                                        <td class="linha_rotulo" style="height: 15px">
                                            <pro:ProTextBox ID="txtCod1" CssClass="obj_Controle_Obrigatorio" CssClassFocus="obj_Controle_Obrigatorio_Focus"
                                                ToolTip="Informe o código da categoria econômica de despesa." Label="Código:"
                                                runat="server" MaxLength="1" Width="20px" IncludeTopSpace="false"></pro:ProTextBox>
                                            <pro:ProTextBox ID="txtCod2" CssClass="obj_Controle_Obrigatorio" CssClassFocus="obj_Controle_Obrigatorio_Focus"
                                                ToolTip="Informe o código do grupo de despesa." runat="server" MaxLength="1"
                                                Width="20px"></pro:ProTextBox>
                                            <pro:ProTextBox ID="txtCod3" CssClass="obj_Controle_Obrigatorio" CssClassFocus="obj_Controle_Obrigatorio_Focus"
                                                ToolTip="Informe o código da modalidade de aplicação da despesa." runat="server"
                                                MaxLength="2" Width="20px"></pro:ProTextBox>
                                            <pro:ProTextBox ID="txtCod4" CssClass="obj_Controle_Obrigatorio" CssClassFocus="obj_Controle_Obrigatorio_Focus"
                                                ToolTip="Informe o código do elemento de despesa." runat="server" MaxLength="2"
                                                Width="20px"></pro:ProTextBox>
                                            <pro:ProTextBox ID="txtCod5" CssClass="obj_Controle_Obrigatorio" CssClassFocus="obj_Controle_Obrigatorio_Focus"
                                                ToolTip="Informe o código da despesa." runat="server" MaxLength="2" Width="20px"></pro:ProTextBox>
                                            <pro:ProTextBox ID="txtCodigo" CssClass="obj_Controle_Obrigatorio" CssClassFocus="obj_Controle_Obrigatorio_Focus"
                                                ToolTip="Informe o código da despesa." DataField="Codigo" Label="Código:" runat="server"
                                                MaxLength="8" Width="20px" Visible="false"></pro:ProTextBox>
                                            <asp:Button ID="btrPreencherCombos" runat="server" Text="..." OnClick="btrPreencherCombos_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="linha_rotulo" colspan="3" style="height: 15px">
                                            <pro:ProTextBox ID="txtDescricao" runat="server" CssClass="obj_Controle_Obrigatorio_M"
                                                CssClassFocus="obj_Controle_Obrigatorio_Focus_M" ToolTip="Informe a descrição da despesa."
                                                DataField="Descricao" Label="Descrição:"></pro:ProTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="linha_rotulo" style="height: 15px">
                                            <pro:ProDropDownList ID="ddlCatEconomica" runat="server" CssClass="obj_Controle_Obrigatorio_G"
                                                OnSelectedIndexChanged="ddlCatEconomica_OnSelectedIndexChanged" CssClassFocus="obj_Controle_Obrigatorio_Focus_G"
                                                ToolTip="Informe a categoria econômica da despesa." AutoPostBack="true" DataField="CatEconomica"
                                                Label="Categoria econômica:" DataType="Number" LabelPosition="Top" DefaultText="Selecione a categoria econômica">
                                            </pro:ProDropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="linha_rotulo" style="height: 15px">
                                            <pro:ProDropDownList ID="ddlGrupoDespesa" runat="server" CssClass="obj_Controle_Obrigatorio_G"
                                                AutoPostBack="true" OnSelectedIndexChanged="ddlGrupoDespesa_OnSelectedIndexChanged"
                                                CssClassFocus="obj_Controle_Obrigatorio_Focus_G" ToolTip="Informe o grupo de despesa."
                                                DataField="GrupoDespesa" Label="Grupo de despesa:" DataType="Number" LabelPosition="Top"
                                                DefaultText="Selecione o grupo de despesa">
                                            </pro:ProDropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="linha_rotulo" style="height: 15px">
                                            <pro:ProDropDownList ID="ddlModalidadeAplicacao" runat="server" CssClass="obj_Controle_Obrigatorio_G"
                                                AutoPostBack="true" OnSelectedIndexChanged="ddlModalidadeAplicacao_OnSelectedIndexChanged"
                                                CssClassFocus="obj_Controle_Obrigatorio_Focus_G" ToolTip="Informe a modalidade de aplicação da despesa."
                                                DataField="ModalidadeAplicacao" Label="Modalidade de aplicação:" DataType="Number"
                                                LabelPosition="Top" DefaultText="Selecione a modalidade de aplicação">
                                            </pro:ProDropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="linha_rotulo" style="height: 15px">
                                            <pro:ProDropDownList ID="ddlElementoDespesa" runat="server" CssClass="obj_Controle_Obrigatorio_G"
                                                AutoPostBack="true" OnSelectedIndexChanged="ddlElementoDespesa_OnSelectedIndexChanged"
                                                CssClassFocus="obj_Controle_Obrigatorio_Focus_G" ToolTip="Informe o elemento de despesa."
                                                DataField="ElementoDespesa" Label="Elemento de despesa:" DataType="Number" LabelPosition="Top"
                                                DefaultText="Selecione o elemento de depesa">
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
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                                <div class="ColFooter" style="padding-left: 10px; width: 24%">
                                    <pro:ProPanel ID="pnlConsultaUC" runat="server" GroupingText="Ítens" Width="600px">
                                        <pro:ProGridView ID="grdListagemItens" runat="server" AllowPaging="True" AllowSorting="true"
                                            AutoGenerateColumns="False" CssClass="obj_Grid"
                                            OnRowCommand="grdListagemItens_RowCommand" DataKeyNames="Id" GridLines="None"
                                            OnSorting="grdListagemUC_Sorting" ShowTotalRegisters="false"
                                            Width="97%">
                                            <HeaderStyle CssClass="obj_Grid_Header" />
                                            <AlternatingRowStyle CssClass="obj_Grid_AlternatingRow" />
                                            <RowStyle CssClass="obj_Grid_Row" />
                                            <SelectedRowStyle CssClass="obj_Grid_SelectedRow" />
                                            <PagerStyle CssClass="obj_Grid_Pager" />
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemStyle Width="20px" HorizontalAlign="Center" />
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="imgDelete" ImageUrl="~/Parts/Thema2/images/icons_container/delete.png"
                                                            runat="server" ToolTip="Deletar" CommandName="ExcluirItem" OnClientClick="messageBox(this,'PERGUNTA','SIMNAO','Confirmação de exclusão','Deseja realmente excluir este item ?',''); return false;" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="CodDespesaItem" HeaderText="Código" SortExpression="CodDespesaItem">
                                                    <HeaderStyle HorizontalAlign="Left" Width="15%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="DscItem" HeaderText="Ítem" SortExpression="DscItem">
                                                    <HeaderStyle HorizontalAlign="Left" Width="80%" />
                                                </asp:BoundField>
                                            </Columns>
                                            <EmptyDataRowStyle CssClass="obj_Grid_Row_Nao_Localizado" />
                                        </pro:ProGridView>
                                        <table>
                                            <tr>
                                                <td style="width: 497px">
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    <asp:Button ID="btnAdicionar" runat="server" CommandName="Adicionar" CssClass="obj_Btn_Command"
                                                        Text="Adicionar" Width="65px" OnClick="btnAdicionar_OnClick" />
                                                </td>
                                            </tr>
                                        </table>
                                    </pro:ProPanel>
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
    <cc1:ModalPopupExtender ID="mpeAdicionarItem" runat="server" PopupControlID="divCadastroUCItem"
        BackgroundCssClass="BackGroundPopup" TargetControlID="hdnBtn1" CancelControlID="imgFecharUC">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnBtn1" runat="server" />
    <div id="divCadastroUCItem" style="display: none; width: 600px;">
        <pro:ProPanel ID="pnlManutencaoUC" runat="server">
            <div id="LAY_CONTENT_CENTER_POPUP" style="height: 295px; width: 500px;">
                <div id="LAY_CONTENT_LEFT_POPUP">
                    <div id="LAY_CONTENT_RIGHT_POPUP">
                        <div id="LAY_TITULO_POPUP">
                            <asp:Label ID="Label1" runat="server" Text="Ítens"></asp:Label>
                            <div id="LAY_BOTAO_FECHAR_POPUP">
                                <asp:Image ID="imgFecharUC" runat="server" ImageUrl="~/Parts/Thema1/btnClose.png">
                                </asp:Image></div>
                            <pro:ProPanel ID="pnlConsultaCadastroItens" GroupingText="Filtros para busca" Style="margin-top: 10px;" Width="470px" runat="server">
                                <table align="left" border="0" cellpadding="0" cellspacing="0" style="vertical-align: top;
                                    text-align: left">
                                    <tr>
                                        <td>
                                            <pro:ProTextBox ID="txtBuscaCodigo" runat="server" CssClass="obj_Controle_P" CssClassFocus="obj_Controle_Focus_P"
                                                ToolTip="Informe o código do ítem." DataField="CodItem" Label="Código:"></pro:ProTextBox>
                                        </td>
                                        <td>
                                        &nbsp;
                                        </td>
                                        <td>
                                            <pro:ProTextBox ID="txtBuscaDescricao" runat="server" CssClass="obj_Controle_M" CssClassFocus="obj_Controle_Focus_M"
                                                ToolTip="Informe a descrição do ítem." DataField="DscItem" Label="Descrição:"></pro:ProTextBox>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnFiltrar" runat="server" Visible="true" Text="Filtrar" CssClass="obj_Btn_Box"
                                                Width="75px" Style="margin-left: 15px; margin-top: 30px" OnClick="btnFiltrar_OnClick" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </pro:ProPanel>
                            <table align="left" border="0" cellpadding="0" cellspacing="0" style="vertical-align: top;
                                text-align: left">
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <pro:ProGridView ID="grdCadastroItens" runat="server" AllowPaging="True" AllowSorting="true"
                                    AutoGenerateColumns="False" AutoGenerateSelectColumn="True" CssClass="obj_Grid"
                                    DataKeyNames="Id" GridLines="None" OnSorting="grdListagemUC_Sorting" SelectionMode="Multiple"
                                    ShowTotalRegisters="false" Width="97%">
                                    <HeaderStyle CssClass="obj_Grid_Header" />
                                    <AlternatingRowStyle CssClass="obj_Grid_AlternatingRow" />
                                    <RowStyle CssClass="obj_Grid_Row" />
                                    <SelectedRowStyle CssClass="obj_Grid_SelectedRow" />
                                    <PagerStyle CssClass="obj_Grid_Pager" />
                                    <Columns>
                                        <asp:BoundField DataField="CodItem" HeaderText="Código" SortExpression="CodItem">
                                            <HeaderStyle HorizontalAlign="Left" Width="5%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DscItem" HeaderText="Ítem" SortExpression="DscItem">
                                            <HeaderStyle HorizontalAlign="Left" Width="25%" />
                                        </asp:BoundField>
                                    </Columns>
                                    <EmptyDataRowStyle CssClass="obj_Grid_Row_Nao_Localizado" />
                                </pro:ProGridView>
                                <tr>
                                    <pro:ProTextBox ID="txtID" runat="server" Visible="false"></pro:ProTextBox>
                                    <pro:ProTextBox ID="txtIdDespesaSelecionada" runat="server" Visible="false"></pro:ProTextBox>
                                    <pro:ProTextBox ID="txtIdExclusao" runat="server" Visible="false"></pro:ProTextBox>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button ID="btnSalvarItens" runat="server" OnClick="btnSalvarItens_OnClick" Width="90px"
                                            Text="Salvar" CssClass="obj_Btn_Command" Visible="true" Style="margin-top: 230px; margin-left: 330px;" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
        </pro:ProPanel>
    </div>
</asp:Content>
