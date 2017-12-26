<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true"
    CodeBehind="frmSecretaria.aspx.cs" Inherits="Platinium.Web.Secretaria"
    Title="Untitled Page" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="Pro.Controls" Namespace="Pro.Controls" TagPrefix="pro" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/ucCabecalhoObrigatorio.ascx" TagName="ucObrigatorio" TagPrefix="obr" %>
<%@ Register Src="UserControls/ucEndereco.ascx" TagName="ucEndereco" TagPrefix="uc1" %>
<%@ Register Src="UserControls/ucEntidadeLei.ascx" TagName="ucEntidadeLei" TagPrefix="uc2" %>
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
                                    <asp:Label ID="lblPoder" runat="server" Text="Poder:" CssClass="LabelFiltro"></asp:Label>
                                </td>
                                <td>
                                    <pro:ProDropDownList ID="ddlBuscaPoder" runat="server" CssClass="obj_Controle_M"
                                        ToolTip="Informe o poder a ser filtrada." CssClassFocus="obj_Controle_Focus_M"
                                        DefaultText="Todas os Poderes." DataField="Poder" DataType="Number" />
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 60px">
                                    <asp:Label ID="lblTipo" runat="server" Text="Tipo:" CssClass="LabelFiltro"></asp:Label>
                                </td>
                                <td>
                                    <pro:ProDropDownList ID="ddlBuscaTipo" runat="server" CssClass="obj_Controle_M" ToolTip="Informe o tipo a ser filtrado."
                                        CssClassFocus="obj_Controle_Focus_M" DefaultText="Todos os Tipos." DataField="TipoEntidade"
                                        DataType="Number" />
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
                                                    ToolTip="Editar" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemStyle Width="20px" HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgDelete" runat="server" CommandName="Delete" ImageUrl="~/Parts/Thema2/images/icons_container/delete.png"
                                                    OnClientClick="messageBox(this,'PERGUNTA','SIMNAO','Confirmação de exclusão','Deseja realmente excluir este item ?',''); return false;"
                                                    ToolTip="Deletar" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="CodEntidade" HeaderStyle-HorizontalAlign="left" HeaderText="Código"
                                            ItemStyle-Width="5%" ItemStyle-HorizontalAlign="left" SortExpression="CodEntidade">
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Descricao" HeaderStyle-HorizontalAlign="Left" HeaderText="Descrição"
                                            ItemStyle-Width="23%" SortExpression="Descricao"></asp:BoundField>
                                        <asp:BoundField DataField="Sigla" HeaderStyle-HorizontalAlign="Left" HeaderText="Sigla"
                                            ItemStyle-Width="5%" SortExpression="Sigla"></asp:BoundField>
                                        <asp:BoundField DataField="DescricaoPoder" HeaderStyle-HorizontalAlign="Left" HeaderText="Poder"
                                            ItemStyle-Width="10%" SortExpression="DescricaoPoder"></asp:BoundField>
                                        <asp:BoundField DataField="Responsavel" HeaderStyle-HorizontalAlign="Left" HeaderText="Secretário"
                                            ItemStyle-Width="16%" SortExpression="Responsavel"></asp:BoundField>
                                        <asp:BoundField DataField="EmailResponsavel" HeaderStyle-HorizontalAlign="Left" HeaderText="Email Secretário"
                                            ItemStyle-Width="16%" SortExpression="EmailResponsavel"></asp:BoundField>
                                        <asp:BoundField DataField="DscTipoEntidade" HeaderStyle-HorizontalAlign="Left" HeaderText="Tipo Entidade"
                                            ItemStyle-Width="15%" SortExpression="DscTipoEntidade"></asp:BoundField>
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
                        <div class="obj_Conteudo txt_padrao" style="min-height: 670px;">
                            <pro:ProPanel ID="pnlManutencao" runat="server" BorderWidth="0px" Height="100%">
                                <obr:ucObrigatorio ID="ucObrigatorio1" runat="server" />
                                <div class="ColEsquerda">
                                    <table align="center" border="0" cellpadding="0" cellspacing="0" style="vertical-align: top;
                                        text-align: center">
                                        <tr>
                                            <td class="linha_rotulo" style="height: 15px" width="120">
                                                <pro:ProTextBox ID="txtCodigo" runat="server" CssClass="obj_Controle_Obrigatorio_P"
                                                    CssClassFocus="obj_Controle_Obrigatorio_Focus_P" DataField="CodEntidade" Label="Código:"
                                                    ToolTip="Informe o código da secretaria." MaxLength="8"></pro:ProTextBox>
                                            </td>
                                            <td class="linha_rotulo" style="height: 15px" width="120">
                                                <pro:ProTextBox ID="txtCodGestora" runat="server" CssClass="obj_Controle_Obrigatorio_P"
                                                    CssClassFocus="obj_Controle_Obrigatorio_Focus_P" DataField="CodGestora" Label="Código gestora:"
                                                    ToolTip="Informe o código da gestora." MaxLength="6"></pro:ProTextBox>
                                            </td>
                                            <td class="linha_rotulo" style="height: 15px" width="120">
                                                <pro:ProTextBox ID="txtSigla" runat="server" CssClass="obj_Controle_Obrigatorio_P"
                                                    CssClassFocus="obj_Controle_Obrigatorio_Focus_P" DataField="Sigla" Label="Sigla:"
                                                    ToolTip="Informe a sigla da secretaria." MaxLength="10"></pro:ProTextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="linha_rotulo" colspan="3" style="height: 15px">
                                                <pro:ProTextBox ID="txtDescricao" runat="server" CssClass="obj_Controle_Obrigatorio_M"
                                                    CssClassFocus="obj_Controle_Obrigatorio_Focus_M" DataField="Descricao" Label="Descrição:"
                                                    ToolTip="Informe a descrição da secretaria." TextMode="MultiLine" Rows="3"></pro:ProTextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="linha_rotulo" colspan="3" style="height: 15px">
                                                <pro:ProDropDownList ID="ddlPoder" runat="server" CssClass="obj_Controle_Obrigatorio_M"
                                                    CssClassFocus="obj_Controle_Obrigatorio_Focus_M" ToolTip="Informe o poder da secretária."
                                                    Label="Poder" LabelPosition="Top" DataField="Poder" DataType="Number" DefaultText="Selecione o poder.">
                                                </pro:ProDropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="linha_rotulo" colspan="3" style="height: 15px">
                                                <pro:ProDropDownList ID="ddlTipoEntidade" runat="server" CssClass="obj_Controle_Obrigatorio_M"
                                                    CssClassFocus="obj_Controle_Obrigatorio_Focus_M" ToolTip="Informe o tipo da entidade da secretária."
                                                    Label="Tipo de entidade" LabelPosition="Top" DataField="TipoEntidade" DataType="Number"
                                                    DefaultText="Selecione o tipo.">
                                                </pro:ProDropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div class="ColDireita">
                                    <pro:ProPanel ID="pnlSecretaria" GroupingText="Secretário" runat="server" Width="313px">
                                        <table align="center" border="0" cellpadding="0" cellspacing="0" style="vertical-align: top;
                                            text-align: center">
                                            <tr>
                                                <td class="linha_rotulo" colspan="3" style="height: 15px; padding-left: 10px">
                                                    <pro:ProTextBox ID="txtTratamento" runat="server" CssClass="obj_Controle_P " DataField="TratamentoResponsavel"
                                                        Label="Tratamento:" CssClassFocus="obj_Controle_Focus_P" ToolTip="Informe o tratamento do responsável."></pro:ProTextBox>
                                                </td>
                                                <td class="linha_rotulo" colspan="3" style="height: 15px; padding-left: 10px">
                                                    <pro:ProTextBox ID="txtNome" runat="server" CssClass="obj_Controle_M" CssClassFocus="obj_Controle_Focus_M"
                                                        DataField="Responsavel" Label="Nome:" ToolTip="Informe o nome do responsável da secretaria."></pro:ProTextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="linha_rotulo" colspan="3" style="height: 15px; padding-left: 10px">
                                                    <pro:ProTextBox ID="txtTelefone" runat="server" CssClass="obj_Controle_P" CssClassFocus="obj_Controle_Focus_P"
                                                        DataType="Phone" DataField="TelefoneResponsavel" Label="Telefone:" ToolTip="Informe o telefone do responsável da secretaria."
                                                        ></pro:ProTextBox>
                                                </td>
                                                <td class="linha_rotulo" colspan="3" style="height: 15px; padding-left: 10px">
                                                    <pro:ProTextBox ID="txtEmail" runat="server" CssClass="obj_Controle_P" CssClassFocus="obj_Controle_Focus_P"
                                                        DataField="EmailResponsavel" Label="Email:" ToolTip="Informe o email do responsável da secretaria."></pro:ProTextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </pro:ProPanel>
                                    <pro:ProPanel ID="pnlContatos" GroupingText="Contatos" runat="server" Width="313px">
                                        <table align="center" border="0" cellpadding="0" cellspacing="0" width="95%" style="vertical-align: top;
                                            width: 95%; text-align: center">
                                            <tr>
                                                <td class="linha_rotulo" colspan="3" style="height: 15px">
                                                    <pro:ProTextBox ID="txtTelefoneOrgao" runat="server" CssClass="obj_Controle_P" DataField="Telefone"
                                                        Label="Telefone:" ToolTip="Informe o telefone da secretaria." CssClassFocus="obj_Controle_Focus_P"
                                                        DataType="Phone"></pro:ProTextBox>
                                                </td>
                                                <td class="linha_rotulo" colspan="3" style="height: 15px">
                                                    <pro:ProTextBox ID="txtFax" runat="server" CssClass="obj_Controle_P" DataField="Fax"
                                                        Label="Fax:" ToolTip="Informe o fax da secretaria." CssClassFocus="obj_Controle_Focus_P"
                                                        DataType="Phone"></pro:ProTextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="linha_rotulo" colspan="3" style="height: 15px">
                                                    <pro:ProTextBox ID="txtCnpj" runat="server" CssClass="obj_Controle_P" DataField="CNPJ"
                                                        Label="Cnpj:" ToolTip="Informe o Cnpj da secretaria." CssClassFocus="obj_Controle_Focus_P"
                                                        DataType="CNPJ"></pro:ProTextBox>
                                                </td>
                                                <td class="linha_rotulo" colspan="3" style="height: 15px">
                                                    <pro:ProTextBox ID="txtEmailOrgao" runat="server" CssClass="obj_Controle_P" DataField="Email"
                                                        Label="Email:" ToolTip="Informe o email da secretaria." CssClassFocus="obj_Controle_Focus_P"
                                                        DataType="Email"></pro:ProTextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </pro:ProPanel>
                                    <table align="center" border="0" cellpadding="0" cellspacing="0" style="vertical-align: top;
                                        text-align: center">
                                        <tr>
                                            <td class="linha_rotulo" colspan="1" style="height: 15px; width: 120px;">
                                                <pro:ProTextBox ID="txtDataCriado" runat="server" CssClass="obj_Controle_P" DataField="DataCriado"
                                                    Label="Data de Criação:" DataType="Date" Visible="false" Enabled="false" CssClassFocus="obj_Controle_Focus_P"></pro:ProTextBox>
                                            </td>
                                            <td class="linha_rotulo" colspan="2" style="height: 15px">
                                                <pro:ProTextBox ID="txtDataDesativado" runat="server" CssClass="obj_Controle_P" DataField="DataDesativado"
                                                    Enabled="false" Label="Data de Desativação:" DataType="Date" Visible="false"
                                                    CssClassFocus="obj_Controle_Focus_P"></pro:ProTextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="linha_rotulo" style="height: 15px" width="120">
                                                <pro:ProCheckBox ID="chkAtivo" DataField="Ativo" Text="Ativo ?" runat="server" IncludeTopSpace="False"
                                                    DataType="Boolean" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </pro:ProPanel>
                            <div class="ColFooter">
                                <table align="center" border="0" cellpadding="0" cellspacing="0" width="95%" style="vertical-align: top;
                                    width: 95%; text-align: center">
                                    <tr>
                                        <td class="linha_rotulo" colspan="1" style="height: 15px;">
                                            <uc2:ucEntidadeLei ID="ucEntidadeLei1" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="linha_rotulo" colspan="1" style="height: 15px;">
                                            <pro:ProPanel ID="pnlEndereco" GroupingText="Endereço" runat="server" Width="790px">
                                                <table align="center" border="0" cellpadding="0" cellspacing="0" width="95%" style="vertical-align: top;
                                                    width: 95%; text-align: center">
                                                    <uc1:ucEndereco ID="ucEndereco1" runat="server" />
                                                </table>
                                            </pro:ProPanel>
                                        </td>
                                    </tr>
                                </table>
                            </div>
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
