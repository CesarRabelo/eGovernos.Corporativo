<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true"
    CodeBehind="frmResponsavelEnvioArquivo.aspx.cs" Inherits="Platinium.Web.ResponsavelEnvioArquivo" %>

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
                                    <pro:ProDropDownList Label="Buscar por: " LabelPosition="Beside" LabelCssClass="LabelFiltro"
                                        ID="ddlCampoBusca" runat="server" CssClass="obj_Controle" Width="130px" />
                                    <asp:Label ID="lblBusca" runat="server"></asp:Label><pro:ProTextBox ID="txtBusca"
                                        runat="server" Width="200px" CssClass="obj_Controle" ToolTip="Informe o texto para busca."></pro:ProTextBox>
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
                                        <asp:BoundField DataField="DscNomeGestor" HeaderStyle-HorizontalAlign="Left" HeaderText="Gestor"
                                            HeaderStyle-Width="18%" ItemStyle-Width="18%" SortExpression="DscNomeGestor">
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DscNomeEmpresaContabilidade" HeaderStyle-HorizontalAlign="Left"
                                            HeaderText="Empresa de Contabilidade" HeaderStyle-Width="18%" ItemStyle-Width="18%"
                                            SortExpression="DscNomeEmpresaContabilidade"></asp:BoundField>
                                        <asp:BoundField DataField="DscNomeContador" HeaderStyle-HorizontalAlign="Left" HeaderText="Contador"
                                            HeaderStyle-Width="18%" ItemStyle-Width="18%" SortExpression="DscNomeContador">
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DscNomeEmpresaInformatica" HeaderStyle-HorizontalAlign="Left"
                                            HeaderText="Empresa de Informática" HeaderStyle-Width="18%" ItemStyle-Width="18%"
                                            SortExpression="DscNomeEmpresaInformatica"></asp:BoundField>
                                        <asp:BoundField DataField="DscNomeAssessorInformatica" HeaderStyle-HorizontalAlign="Left"
                                            HeaderText="Assessor de Informática" HeaderStyle-Width="18%" ItemStyle-Width="18%"
                                            SortExpression="DscNomeAssessorInformatica"></asp:BoundField>
                                        <asp:BoundField DataField="DscAtivo" HeaderStyle-HorizontalAlign="Left" HeaderText="Ativo"
                                            HeaderStyle-Width="5%" SortExpression="DscAtivo">
                                            <HeaderStyle HorizontalAlign="Left" />
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
                                <div class="ColEsquerda">
                                    <pro:ProPanel ID="pnlGestor" GroupingText="Gestor Responsável" runat="server" Width="30%">
                                        <table align="center" border="0" cellpadding="0" cellspacing="0" style="vertical-align: top;
                                            width: 39%; text-align: center">
                                            <tr>
                                                <td class="linha_rotulo" colspan="3" style="height: 15px; width: 155px;">
                                                    <pro:ProTextBox ID="txtNomeGestor" runat="server" CssClass="obj_Controle_Obrigatorio_M"
                                                        CssClassFocus="obj_Controle_Obrigatorio_Focus_M" MaxLength="50" ToolTip="Informe o nome do gestor."
                                                        DataField="DscNomeGestor" Label="Nome:"></pro:ProTextBox>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td class="linha_rotulo" colspan="3" style="height: 15px">
                                                    <pro:ProTextBox ID="txtCPFGestor" runat="server" CssClass="obj_Controle_Obrigatorio_P"
                                                        CssClassFocus="obj_Controle_Obrigatorio_Focus_P" DataType="CPF" ToolTip="Informe o cpf do gestor."
                                                        DataField="DscCpfGestor" Label="CPF:" Format="false"></pro:ProTextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="linha_rotulo" colspan="3" style="height: 15px; width: 155px;">
                                                    <pro:ProDropDownList ID="ddlCargo" runat="server" CssClass="obj_Controle_Obrigatorio_M"
                                                        CssClassFocus="obj_Controle_Obrigatorio_Focus_M" ToolTip="Informe o cargo do gestor."
                                                        DataField="Cargo" Label="Cargo:" DataType="Number" LabelPosition="Top" DefaultText="Selecione o Cargo">
                                                    </pro:ProDropDownList>
                                                </td>
                                            </tr>
                                        </table>
                                    </pro:ProPanel>
                                    <pro:ProPanel ID="pnlEmpresaContabilidade" GroupingText="Empresa de Contabilidaade"
                                        runat="server" Width="30%">
                                        <table align="center" border="0" cellpadding="0" cellspacing="0" style="vertical-align: top;
                                            width: 39%; text-align: center">
                                            <tr>
                                                <td class="linha_rotulo" colspan="3" style="height: 15px; width: 155px;">
                                                    <pro:ProTextBox ID="txtNomeEmpresaContabilidade" runat="server" CssClass="obj_Controle_Obrigatorio_M"
                                                        CssClassFocus="obj_Controle_Obrigatorio_Focus_M" MaxLength="100" ToolTip="Informe o nome da empresa de contabilidade."
                                                        DataField="DscNomeEmpresaContabilidade" Label="Nome:"></pro:ProTextBox>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td class="linha_rotulo" colspan="3" style="height: 15px">
                                                    <pro:ProTextBox ID="txtCNPJEmpresaContabilidade" runat="server" CssClass="obj_Controle_Obrigatorio_P"
                                                        CssClassFocus="obj_Controle_Obrigatorio_Focus_P" DataType="CNPJ" ToolTip="Informe o cnpj da empresa de contabilidade."
                                                        DataField="DscCnpjEmpresaContabilidade" Label="CNPJ:" Format="false"></pro:ProTextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </pro:ProPanel>
                                    <pro:ProPanel ID="pnlContador" GroupingText="Contador" runat="server" Width="30%">
                                        <table align="center" border="0" cellpadding="0" cellspacing="0" style="vertical-align: top;
                                            width: 39%; text-align: center">
                                            <tr>
                                                <td class="linha_rotulo" colspan="3" style="height: 15px; width: 155px;">
                                                    <pro:ProTextBox ID="txtNomeContador" runat="server" CssClass="obj_Controle_Obrigatorio_M"
                                                        CssClassFocus="obj_Controle_Obrigatorio_Focus_M" MaxLength="50" ToolTip="Informe o nome do contador."
                                                        DataField="DscNomeContador" Label="Nome:"></pro:ProTextBox>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td class="linha_rotulo" colspan="3" style="height: 15px">
                                                    <pro:ProTextBox ID="txtCPFContador" runat="server" CssClass="obj_Controle_Obrigatorio_P"
                                                        CssClassFocus="obj_Controle_Obrigatorio_Focus_P" DataType="CPF" ToolTip="Informe o cpf do contador."
                                                        DataField="DscCpfContador" Label="CPF:" Format="false"></pro:ProTextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="linha_rotulo" colspan="3" style="height: 15px">
                                                    <pro:ProTextBox ID="txtCRCContador" runat="server" CssClass="obj_Controle_Obrigatorio_M"
                                                        CssClassFocus="obj_Controle_Obrigatorio_Focus_M" ToolTip="Informe o CRC do contador."
                                                        DataField="DscCrcContador" Label="CRC:" MaxLength="20"></pro:ProTextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </pro:ProPanel>
                                </div>
                                <div class="ColDireita">
                                    <pro:ProPanel ID="pnlEmpresaInformática" GroupingText="Empresa de Informática" runat="server"
                                        Width="30%">
                                        <table align="center" border="0" cellpadding="0" cellspacing="0" style="vertical-align: top;
                                            width: 39%; text-align: center">
                                            <tr>
                                                <td class="linha_rotulo" colspan="3" style="height: 15px; width: 155px;">
                                                    <pro:ProTextBox ID="txtNomeEmpresaInformatica" runat="server" CssClass="obj_Controle_Obrigatorio_M"
                                                        CssClassFocus="obj_Controle_Obrigatorio_Focus_M" MaxLength="60" ToolTip="Informe o nome da empresa de informática."
                                                        DataField="DscNomeEmpresaInformatica" Label="Nome:"></pro:ProTextBox>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td class="linha_rotulo" colspan="3" style="height: 15px">
                                                    <pro:ProTextBox ID="txtCnpjEmpresaInformatica" runat="server" CssClass="obj_Controle_Obrigatorio_P"
                                                        CssClassFocus="obj_Controle_Obrigatorio_Focus_P" DataType="CNPJ" ToolTip="Informe o cnpj da empresa de informática."
                                                        DataField="DscCnpjEmpresaInformatica" Label="CNPJ:" Format="false"></pro:ProTextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </pro:ProPanel>
                                    <pro:ProPanel ID="pnlAssessorInformatica" GroupingText="Assessor de Informática"
                                        runat="server" Width="30%">
                                        <table align="center" border="0" cellpadding="0" cellspacing="0" style="vertical-align: top;
                                            width: 39%; text-align: center">
                                            <tr>
                                                <td class="linha_rotulo" colspan="3" style="height: 15px; width: 155px;">
                                                    <pro:ProTextBox ID="txtAssessorInformatica" runat="server" CssClass="obj_Controle_Obrigatorio_M"
                                                        CssClassFocus="obj_Controle_Obrigatorio_Focus_M" MaxLength="50" ToolTip="Informe o nome do assesor de informática."
                                                        DataField="DscNomeAssessorInformatica" Label="Nome:"></pro:ProTextBox>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td class="linha_rotulo" colspan="3" style="height: 15px">
                                                    <pro:ProTextBox ID="txtCPFAssessorInformatica" runat="server" CssClass="obj_Controle_Obrigatorio_P"
                                                        CssClassFocus="obj_Controle_Obrigatorio_Focus_P" DataType="CPF" ToolTip="Informe o cpf do assessor de informática."
                                                        DataField="DscCpfAssessorInformatica" Label="CPF:" Format="false"></pro:ProTextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </pro:ProPanel>
                                    <table align="center" border="0" cellpadding="0" cellspacing="0" style="vertical-align: top;
                                        width: 50%; text-align: center">
                                        <tr>
                                            <td class="linha_rotulo" style="height: 15px; width: 150px;" colspan="3">
                                                <pro:ProTextBox ID="txtDataInicio" runat="server" CssClass="obj_Controle_Obrigatorio_P"
                                                    CssClassFocus="obj_Controle_Obrigatorio_Focus_P" ToolTip="Informe a data de inicio."
                                                    DataField="DataInicio" Label="Data de Inicio:" DataType="Date"></pro:ProTextBox>
                                                <asp:ImageButton runat="server" ID="btnDataInicio" ImageUrl="~/Parts/Thema2/images/ico_calendar.gif"
                                                    CssClass="cssCalendar" />
                                                <cc1:CalendarExtender runat="server" ID="calIni" TargetControlID="txtDataInicio"
                                                    PopupButtonID="btnDataInicio" Format="dd/MM/yyyy">
                                                </cc1:CalendarExtender>
                                            </td>
                                            <td class="linha_rotulo" style="height: 15px; width: 150px;" colspan="3">
                                                <pro:ProTextBox ID="txtDataFim" runat="server" CssClass="obj_Controle_P" CssClassFocus="obj_Controle_Focus_P"
                                                    ToolTip="Informe a data final." DataField="DataFim" Label="Data Final:" DataType="Date"></pro:ProTextBox>
                                                <asp:ImageButton runat="server" ID="btnDataFim" ImageUrl="~/Parts/Thema2/images/ico_calendar.gif"
                                                    CssClass="cssCalendar" />
                                                <cc1:CalendarExtender runat="server" ID="calFim" TargetControlID="txtDataFim" PopupButtonID="btnDataFim"
                                                    Format="dd/MM/yyyy">
                                                </cc1:CalendarExtender>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div class="ColFooter">
                                    <table align="center" border="0" cellpadding="0" cellspacing="0" width="95%" style="vertical-align: top;
                                        width: 95%; text-align: center">
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
