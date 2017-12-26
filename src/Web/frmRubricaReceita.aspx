<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true"
    CodeBehind="frmRubricaReceita.aspx.cs" Inherits="Platinium.Web.RubricaReceita" %>

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
                                <td style="width: 109px">
                                    <asp:Label ID="lblCategoria" runat="server" Text="Categoria Econômica:" CssClass="LabelFiltro"></asp:Label>
                                </td>
                                <td>
                                    <pro:ProDropDownList ID="ddlBuscaCategoria" runat="server" CssClass="obj_Controle_M"
                                        DataField="EconomicaDeReceita" DataType="Number" CssClassFocus="obj_Controle_Focus_M"
                                        ToolTip="Informe a categoria econômica a ser filtrada" DefaultText="Todas as Categorias Econômicas"
                                        AutoPostBack="true" OnSelectedIndexChanged="ddlBuscaCategoriaEconomica_OnSelectedIndexChanged" />
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 109px">
                                    <asp:Label ID="lblOrigemReceita" runat="server" Text="Origem Receita:" CssClass="LabelFiltro"></asp:Label>
                                </td>
                                <td>
                                    <pro:ProDropDownList ID="ddlBuscaOrigemReceita" runat="server" CssClass="obj_Controle_M"
                                        DataField="OrigemReceita" DataType="Number" CssClassFocus="obj_Controle_Focus_M"
                                        ToolTip="Informe a origem receita a ser filtrada" DefaultText="Todas as Origens Receita"
                                        AutoPostBack="true" OnSelectedIndexChanged="ddlBuscaOrigem_OnSelectedIndexChanged" />
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 109px">
                                    <asp:Label ID="lblEspecie" runat="server" Text="Espécie:" CssClass="LabelFiltro"></asp:Label>
                                </td>
                                <td>
                                    <pro:ProDropDownList ID="ddlBuscaEspecie" runat="server" CssClass="obj_Controle_M"
                                        ToolTip="Informe a espécie a ser filtrada" DataField="Especie" DataType="Number"
                                        CssClassFocus="obj_Controle_Focus_M" DefaultText="Todas as Espécies" Width="350px" />
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 109px">
                                    <asp:Label ID="lblBuscar" runat="server" Text="Buscar por:" CssClass="LabelFiltro"></asp:Label>
                                </td>
                                <td>
                                    <pro:ProDropDownList ID="ddlCampoBusca" runat="server" CssClass="obj_Controle" 
                                        Width="130px" />
                                    <asp:Label ID="lblBusca" runat="server"></asp:Label><pro:ProTextBox ID="txtBusca"
                                        runat="server" Width="206px" CssClass="obj_Controle" 
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
                                        <asp:BoundField DataField="Codigo" HeaderText="Código" ItemStyle-Width="5%" SortExpression="Codigo"
                                            HeaderStyle-HorizontalAlign="Left">
                                            <ItemStyle Width="5%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Descricao" HeaderStyle-HorizontalAlign="Left" HeaderText="Descrição"
                                            ItemStyle-Width="25%" SortExpression="Descricao">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle Width="25%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DescricaoEspecie" HeaderStyle-HorizontalAlign="Left" HeaderText="Espécie"
                                            ItemStyle-Width="20%" SortExpression="DescricaoEspecie">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle Width="20%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DescricaoOrigem" HeaderStyle-HorizontalAlign="Left" HeaderText="Origem"
                                            ItemStyle-Width="20%" SortExpression="DescricaoOrigem">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle Width="20%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DescricaoCategoria" HeaderStyle-HorizontalAlign="Left"
                                            HeaderText="Categoria Econômica" ItemStyle-Width="20%" SortExpression="DescricaoCategoria">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle Width="20%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DescricaoAtivo" HeaderText="Ativo" SortExpression="DescricaoAtivo"
                                            ItemStyle-HorizontalAlign="Left">
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
                                        <td class="linha_rotulo" style="height: 15px">
                                            <pro:ProTextBox ID="txtCod1" CssClass="obj_Controle_Obrigatorio" CssClassFocus="obj_Controle_Obrigatorio_Focus"
                                                ToolTip="Informe o código da categoria econômica." Label="Código:" runat="server"
                                                MaxLength="1" Width="20px" TabIndex="1" IncludeTopSpace="false"></pro:ProTextBox>
                                            <pro:ProTextBox ID="txtCod2" CssClass="obj_Controle_Obrigatorio" CssClassFocus="obj_Controle_Obrigatorio_Focus"
                                                ToolTip="Informe o código da origem de receita." TabIndex="2" runat="server"
                                                MaxLength="1" Width="20px"></pro:ProTextBox>
                                            <pro:ProTextBox ID="txtCod3" CssClass="obj_Controle_Obrigatorio" CssClassFocus="obj_Controle_Obrigatorio_Focus"
                                                ToolTip="Informe o código da espécie da receita." TabIndex="3" runat="server"
                                                MaxLength="1" Width="20px"></pro:ProTextBox>
                                            <pro:ProTextBox ID="txtCod4" CssClass="obj_Controle_Obrigatorio" CssClassFocus="obj_Controle_Obrigatorio_Focus"
                                                ToolTip="Informe o código da rúbrica da receita." TabIndex="4" runat="server"
                                                MaxLength="1" Width="20px"></pro:ProTextBox>
                                            <pro:ProTextBox ID="txtCod5" CssClass="obj_Controle_Obrigatorio" TabIndex="5" CssClassFocus="obj_Controle_Obrigatorio_Focus"
                                                runat="server" MaxLength="2" Width="20px" Enabled="false" BackColor="#CCCCCCCC"></pro:ProTextBox>
                                            <pro:ProTextBox ID="txtCod6" CssClass="obj_Controle_Obrigatorio" TabIndex="6" CssClassFocus="obj_Controle_Obrigatorio_Focus"
                                                runat="server" MaxLength="2" Width="20px" Enabled="false" BackColor="#CCCCCCCC"></pro:ProTextBox>
                                            <pro:ProTextBox ID="txtCodigo" CssClass="obj_Controle_Obrigatorio" TabIndex="7" CssClassFocus="obj_Controle_Obrigatorio_Focus"
                                                DataField="Codigo" Label="Código:" runat="server" MaxLength="8" Width="20px"
                                                Visible="false"></pro:ProTextBox>
                                            <asp:Button ID="btrPreencherCombos" TabIndex="8" runat="server" Text="..." OnClick="btrPreencherCombos_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="linha_rotulo" colspan="3" style="height: 15px">
                                            <pro:ProTextBox ID="txtDescricao" runat="server" CssClass="obj_Controle_Obrigatorio_M"
                                                CssClassFocus="obj_Controle_Obrigatorio_Focus_M" ToolTip="Informe a descrição da rubrica da receita."
                                                DataField="Descricao" Label="Descrição:" TabIndex="9"></pro:ProTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="linha_rotulo" colspan="3" style="height: 15px">
                                            <pro:ProDropDownList ID="ddlCategoriaEconomica" runat="server" CssClass="obj_Controle_Obrigatorio_M"
                                                CssClassFocus="obj_Controle_Obrigatorio_Focus_M" ToolTip="Informe uma categoria econômica."
                                                Label="Categoria Econômica" LabelPosition="Top" DataField="EconomicaDeReceita"
                                                DataType="Number" TabIndex="10" DefaultText="Selecione uma categoria econômica."
                                                AutoPostBack="true" OnSelectedIndexChanged="ddlCategoriaEconomica_OnSelectedIndexChanged">
                                            </pro:ProDropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="linha_rotulo" colspan="3" style="height: 15px">
                                            <pro:ProDropDownList ID="ddlOrigemReceita" TabIndex="11" runat="server" CssClass="obj_Controle_Obrigatorio_M"
                                                CssClassFocus="obj_Controle_Obrigatorio_Focus_M" ToolTip="Informe uma origem da receita."
                                                Label="Origem Receita" LabelPosition="Top" DataField="OrigemReceita" DataType="Number"
                                                DefaultText="Selecione uma origem receita." AutoPostBack="true" OnSelectedIndexChanged="ddlOrigemReceita_OnSelectedIndexChanged">
                                            </pro:ProDropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="linha_rotulo" colspan="3" style="height: 15px">
                                            <pro:ProDropDownList ID="ddlEspecie" runat="server" TabIndex="12" CssClass="obj_Controle_Obrigatorio_G"
                                                CssClassFocus="obj_Controle_Obrigatorio_Focus_G" ToolTip="Informe uma espécie."
                                                Label="Espécie" LabelPosition="Top" DataField="Especie" DataType="Number" DefaultText="Selecione uma espécie."
                                                AutoPostBack="true" OnSelectedIndexChanged="ddlEspecie_OnSelectedIndexChanged">
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
                                            <pro:ProCheckBox ID="chkAtivo" DataField="Ativo" Text="Ativo ?" TabIndex="13" runat="server"
                                                IncludeTopSpace="False" />
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
