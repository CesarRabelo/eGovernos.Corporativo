<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true"
    CodeBehind="frmUnidadeOrcamentaria.aspx.cs" Inherits="Platinium.Web.UnidadeOrcamentaria" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="Pro.Controls" Namespace="Pro.Controls" TagPrefix="pro" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/ucCabecalhoObrigatorio.ascx" TagName="ucObrigatorio" TagPrefix="obr" %>
<%@ Register src="UserControls/ucEntidadeLei.ascx" tagname="ucEntidadeLei" tagprefix="uc1" %>
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
                                    <asp:Label ID="lblSecretaria" runat="server" Text="Secretaria:" CssClass="LabelFiltro"></asp:Label>
                                </td>
                                <td>
                                    <pro:ProDropDownList ID="ddlBuscaSecretaria" runat="server" CssClass="obj_Controle_G"
                                        CssClassFocus="obj_Controle_Focus_G" ToolTip="Informe a secretaria a ser filtrada."
                                        DefaultText="Todas as secretarias." DataField="Secretaria" DataType="Number" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblOrgao" runat="server" Text="Orgão:" CssClass="LabelFiltro"></asp:Label>
                                </td>
                                <td>
                                    <pro:ProDropDownList ID="ddlBuscaOrgao" runat="server" CssClass="obj_Controle_G"
                                        ToolTip="Informe o orgão a ser filtrado." CssClassFocus="obj_Controle_Focus_G"
                                        DefaultText="Todos os orgãos." DataField="Orgao" DataType="Number" AutoPostBack="true"
                                        OnSelectedIndexChanged="ddlBuscaOrgao_SelectedIndexChanged" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblPoder" runat="server" Text="Poder:" CssClass="LabelFiltro"></asp:Label>
                                </td>
                                <td>
                                    <pro:ProDropDownList ID="ddlBuscaPoder" CssClassFocus="obj_Controle_Focus_M" runat="server"
                                        CssClass="obj_Controle_M" ToolTip="Informe o poder a ser filtrado." DefaultText="Todos os poderes."
                                        DataField="Poder" DataType="Number" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblTipo" runat="server" Text="Tipo:" CssClass="LabelFiltro"></asp:Label>
                                </td>
                                <td>
                                    <pro:ProDropDownList ID="ddlBuscaTipo" runat="server" CssClass="obj_Controle_M" CssClassFocus="obj_Controle_Focus_M"
                                        ToolTip="Informe o tipo de entidade a ser filtrado." DefaultText="Todos os tipos de entidades."
                                        DataField="TipoEntidade" DataType="Number" />
                                </td>
                            </tr>
                            <tr>
                                <td>
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
                                        <asp:BoundField DataField="DscSecretariaSigla" HeaderStyle-HorizontalAlign="Left"
                                            HeaderText="Secretaria" ItemStyle-Width="5%" SortExpression="DscSecretariaSigla">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle Width="5%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="codOrgao" HeaderText="Cód. Orgão" ItemStyle-Width="10%"
                                            SortExpression="codOrgao" HeaderStyle-HorizontalAlign="Left">
                                            <ItemStyle Width="5%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="dscOrgaoSigla" HeaderStyle-HorizontalAlign="Left" HeaderText="Orgão"
                                            ItemStyle-Width="5%" SortExpression="dscOrgaoSigla">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle Width="5%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="dscPoder" HeaderStyle-HorizontalAlign="Left" HeaderText="Poder"
                                            ItemStyle-Width="5%" SortExpression="dscPoder">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle Width="5%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="dscTipoEntidade" HeaderStyle-HorizontalAlign="Left" HeaderText="Tipo"
                                            ItemStyle-Width="7%" SortExpression="dscTipoEntidade">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle Width="7%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CodEntidade" HeaderStyle-HorizontalAlign="Left" HeaderText="Cód. Unidade"
                                            ItemStyle-Width="5%" SortExpression="CodEntidade">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle Width="5%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CodGestora" HeaderStyle-HorizontalAlign="Left" HeaderText="Cód. Gestora"
                                            ItemStyle-Width="5%" SortExpression="CodGestora">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle Width="5%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Sigla" HeaderStyle-HorizontalAlign="Left" HeaderText="Sigla"
                                            ItemStyle-Width="5%" SortExpression="Sigla">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle Width="5%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Descricao" HeaderStyle-HorizontalAlign="Left" HeaderText="Descrição"
                                            ItemStyle-Width="28%" SortExpression="Descricao">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle Width="28%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Responsavel" HeaderStyle-HorizontalAlign="Left" HeaderText="Responsável"
                                            ItemStyle-Width="10%" SortExpression="Responsavel">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle Width="10%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="EmailResponsavel" HeaderStyle-HorizontalAlign="Left" HeaderText="Email Responsável"
                                            ItemStyle-Width="10%" SortExpression="EmailResponsavel">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle Width="10%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DscAtivo" HeaderText="Ativo" ItemStyle-Width="5%" HeaderStyle-HorizontalAlign="Left"
                                            SortExpression="DscAtivo" ItemStyle-HorizontalAlign="Left" />
                                    </Columns>
                                    <EmptyDataRowStyle CssClass="obj_Grid_Row_Nao_Localizado" />
                                </pro:ProGridView>
                            </div>
                        </pro:ProPanel>
                    </asp:View>
                    <asp:View ID="vwCadastro" runat="server">
                        <div class="obj_Conteudo txt_padrao">
                            <pro:ProPanel ID="pnlManutencao" runat="server" BorderWidth="0px" Height="100%">
                                <obr:ucObrigatorio ID="ucObrigatorio1" runat="server" />
                                <div class="ColEsquerda">
                                    <table align="center" border="0" cellpadding="0" cellspacing="0" style="text-align: left">
                                        <tr>
                                            <td class="linha_rotulo" style="height: 15px" width="110">
                                                <pro:ProTextBox ID="txtCodigo" runat="server" CssClass="obj_Controle_Obrigatorio_P"
                                                    CssClassFocus="obj_Controle_Obrigatorio_Focus_P" DataField="CodEntidade" Label="Código:"
                                                    ToolTip="Informe o código da unidade orçamentária." MaxLength="8"></pro:ProTextBox>
                                            </td>
                                            <td class="linha_rotulo" style="height: 15px" width="110">
                                                <pro:ProTextBox ID="txtCodGestora" runat="server" CssClass="obj_Controle_Obrigatorio_P"
                                                    CssClassFocus="obj_Controle_Obrigatorio_Focus_P" DataField="CodGestora" Label="Código gestora:"
                                                    ToolTip="Informe o código da gestora." MaxLength="6"></pro:ProTextBox>
                                            </td>
                                            <td class="linha_rotulo" style="height: 15px" width="110">
                                                <pro:ProTextBox ID="txtSigla" runat="server" CssClass="obj_Controle_P" DataField="Sigla"
                                                    Label="Sigla:" ToolTip="Informe a sigla da unidade orçamentária." CssClassFocus="obj_Controle_Focus_P"
                                                    MaxLength="10"></pro:ProTextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="linha_rotulo" colspan="3" style="height: 15px">
                                                <pro:ProTextBox ID="txtDescricao" runat="server" CssClass="obj_Controle_Obrigatorio_M"
                                                    CssClassFocus="obj_Controle_Obrigatorio_Focus_M" DataField="Descricao" Label="Descrição:"
                                                    ToolTip="Informe a descrição da unidade orçamentária."></pro:ProTextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="linha_rotulo" colspan="3" style="height: 15px">
                                                <pro:ProDropDownList ID="ddlSecretaria" runat="server" CssClass="obj_Controle_Obrigatorio_G"
                                                    CssClassFocus="obj_Controle_Obrigatorio_Focus_G" ToolTip="Informe a secretaria da unidade orçamentária."
                                                    Label="Secretaria:" LabelPosition="Top" DataField="Secretaria" DataType="Number"
                                                    AutoPostBack="true" OnSelectedIndexChanged="ddlSecretaria_SelectedIndexChanged"
                                                    DefaultText="Selecione a secretaria.">
                                                </pro:ProDropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="linha_rotulo" colspan="3" style="height: 15px">
                                                <pro:ProDropDownList ID="ddlOrgao" runat="server" CssClass="obj_Controle_Obrigatorio_G"
                                                    DefaultText="Selecione um órgão." CssClassFocus="obj_Controle_Obrigatorio_Focus_G"
                                                    ToolTip="Informe o orgão da unidade orçamentária." Label="Órgão:" LabelPosition="Top"
                                                    DataField="Orgao" DataType="Number" AutoPostBack="true" OnSelectedIndexChanged="ddlOrgao_SelectedIndexChanged">
                                                </pro:ProDropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="linha_rotulo" colspan="3" style="height: 15px">
                                                <pro:ProDropDownList ID="ddlPoder" runat="server" CssClass="obj_Controle_Obrigatorio_M"
                                                    CssClassFocus="obj_Controle_Obrigatorio_Focus_M" ToolTip="Informe o poder da secretaria."
                                                    Label="Poder:" LabelPosition="Top" DataField="Poder" DataType="Number" DefaultText="Selecione um poder."
                                                    Enabled="false">
                                                </pro:ProDropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="linha_rotulo" colspan="3" style="height: 15px">
                                                <pro:ProDropDownList ID="ddlTipo" runat="server" CssClass="obj_Controle_Obrigatorio_M"
                                                    CssClassFocus="obj_Controle_Obrigatorio_Focus_M" ToolTip="Informe o tipo do órgão."
                                                    Label="Tipo:" LabelPosition="Top" DataField="TipoEntidade" DataType="Number"
                                                    DefaultText="Selecione um tipo." Enabled="false">
                                                </pro:ProDropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="linha_rotulo" colspan="3" style="height: 15px">
                                                <pro:ProDropDownList ID="ddlTipoAdministracao" runat="server" CssClass="obj_Controle_Obrigatorio_M"
                                                    CssClassFocus="obj_Controle_Obrigatorio_Focus_M" ToolTip="Informe o tipo de administração."
                                                    Label="Tipo de Administração:" LabelPosition="Top" DataField="TipoAdministracao" DataType="Number"
                                                    DefaultText="Selecione um tipo de administração.">
                                                </pro:ProDropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div class="ColDireita">
                                    <pro:ProPanel ID="pnlSecretaria" GroupingText="Responsável" runat="server" Width="290px">
                                        <table align="center" border="0" cellpadding="0" cellspacing="0" style="vertical-align: top;
                                            text-align: center">
                                            <tr>
                                                <td class="linha_rotulo" colspan="3" style="height: 30px; width: 100px">
                                                    <pro:ProTextBox ID="txtTratamento" runat="server" CssClass="obj_Controle_P" DataField="TratamentoResponsavel"
                                                        Label="Tratamento:" ToolTip="Informe o tratamento do responsável da unidade orçamentária."
                                                        CssClassFocus="obj_Controle_Focus_P"></pro:ProTextBox>
                                                </td>
                                                <td class="linha_rotulo" colspan="3" style="height: 30px" align="center">
                                                    <pro:ProTextBox ID="txtNome" runat="server" CssClass="obj_Controle_M" DataField="Responsavel"
                                                        Label="Nome:" ToolTip="Informe o nome do responsável da unidade orçamentária."
                                                        CssClassFocus="obj_Controle_Focus_M"></pro:ProTextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="linha_rotulo" colspan="3" style="height: 15px">
                                                    <pro:ProTextBox ID="txtTelefone" runat="server" CssClass="obj_Controle_P" DataType="Phone"
                                                        CssClassFocus="obj_Controle_Focus_P" DataField="TelefoneResponsavel" Label="Telefone:"
                                                        ToolTip="Informe o telefone do responsável da unidade orçamentária."></pro:ProTextBox>
                                                </td>
                                                <td class="linha_rotulo" colspan="3" style="height: 15px" align="center">
                                                    <pro:ProTextBox ID="txtEmail" runat="server" CssClass="obj_Controle_M" DataField="EmailResponsavel"
                                                        Label="Email:" ToolTip="Informe o email do responsável da unidade orçamentária."
                                                        CssClassFocus="obj_Controle_Focus_M"></pro:ProTextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </pro:ProPanel>
                                    <table align="center" border="0" cellpadding="0" cellspacing="0" style="vertical-align: top;
                                        text-align: center">
                                        <tr>
                                            <td class="linha_rotulo" colspan="1" style="height: 15px; width: 130px;">
                                                <pro:ProTextBox ID="txtDataCriado" runat="server" CssClass="obj_Controle_P" DataField="DataCriado"
                                                    CssClassFocus="obj_Controle_Focus_P" Label="Data de Criação:" DataType="Date"
                                                    Visible="false" Enabled="false"></pro:ProTextBox>
                                            </td>
                                            <td class="linha_rotulo" colspan="2" style="height: 15px">
                                                <pro:ProTextBox ID="txtDataDesativado" runat="server" CssClass="obj_Controle_P" DataField="DataDesativado"
                                                    Enabled="false" Label="Data de Desativação:" DataType="Date" Visible="false"
                                                    CssClassFocus="obj_Controle_Focus_P"></pro:ProTextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 130px">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="linha_rotulo" style="height: 15px; width: 130px;">
                                                <pro:ProCheckBox ID="chkAtivo" DataField="Ativo" Text="Ativo ?" runat="server" IncludeTopSpace="False" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                
                                <div class="ColFooter">
                                    <table align="center" border="0" cellpadding="0" cellspacing="0" width="95%" style="vertical-align: top;
                                        width: 95%; text-align: center">
                                        <tr>
                                            <td class="linha_rotulo" colspan="1" style="height: 15px;">
                                                <uc1:ucEntidadeLei ID="ucEntidadeLei1" runat="server" />
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
