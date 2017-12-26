<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true"
    CodeBehind="frmItemRemuneratorio.aspx.cs" Inherits="Platinium.Web.frmItemRemuneratorio" %>

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
                        <table>
                            <tr>
                                <td style="width: 129px">
                                    <asp:Label ID="lblTipoItem" runat="server" Text="Tipo de Item:" CssClass="LabelFiltro"></asp:Label>
                                </td>
                                <td>
                                    <pro:ProDropDownList ID="ddlBuscaTipoItem" runat="server" CssClass="obj_Controle_M"
                                        CssClassFocus="obj_Controle_Focus_M" DataField="TipoItem" DataType="Number" ToolTip="Informe o tipo do item a ser filtrado."
                                        DefaultText="Todos os tipos de itens." />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblBuscaPor" runat="server" Text="Buscar por:" CssClass="LabelFiltro"></asp:Label>
                                </td>
                                <td>
                                    <pro:ProDropDownList ID="ddlCampoBusca" runat="server" CssClass="obj_Controle" />
                                    <asp:Label ID="lblBusca" runat="server"></asp:Label><pro:ProTextBox ID="txtBusca"
                                        runat="server" Width="200px" CssClass="obj_Controle" ToolTip="Informe o texto para busca."></pro:ProTextBox>
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
                                        <asp:TemplateField>
                                            <ItemStyle Width="20px" HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgExtinguir" CommandName="EXTINGUIR" ImageUrl="~/Parts/Thema2/images/icons_container/extinguir.png"
                                                    runat="server" ToolTip="Extinguir" OnClick="imgExtinguir_OnClick" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="CodigoItemremuneratorio" HeaderText="Código" SortExpression="CodigoItemremuneratorio">
                                            <ItemStyle Width="5%" HorizontalAlign="Left" />
                                            <HeaderStyle Width="5%" HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DscItemRemuneratorio" HeaderText="Descrição" SortExpression="DscItemRemuneratorio">
                                            <ItemStyle Width="35%" HorizontalAlign="Left" />
                                            <HeaderStyle Width="35%" HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="NumAmparoLegal" HeaderText="Número do Amparo" SortExpression="NumAmparoLegal">
                                            <ItemStyle Width="10%" HorizontalAlign="Left" />
                                            <HeaderStyle Width="10%" HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DscTipoItem" HeaderText="Tipo do Item" SortExpression="DscTipoItem">
                                            <ItemStyle Width="20%" HorizontalAlign="Left" />
                                            <HeaderStyle Width="20%" HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DscTipoAmparo" HeaderText="Amparo Legal" SortExpression="DscTipoAmparo">
                                            <ItemStyle Width="15%" HorizontalAlign="Left" />
                                            <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DataAmparoLegal" HeaderText="Data do Amparo Legal" DataFormatString="{0:dd/MM/yyyy}"
                                            SortExpression="DataAmparoLegal">
                                            <ItemStyle Width="10%" HorizontalAlign="Left" />
                                            <HeaderStyle Width="10%" HorizontalAlign="Left" />
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
                                    <table align="center" border="0" cellpadding="0" cellspacing="0" style="vertical-align: top;
                                        width: 100%; text-align: center">
                                        <tr>
                                            <td class="linha_rotulo" style="height: 15px" colspan="3">
                                                <pro:ProDropDownList ID="ddlTipoItem" runat="server" CssClass="obj_Controle_Obrigatorio_M"
                                                    CssClassFocus="obj_Controle_Obrigatorio_Focus_M" ToolTip="Informe o tipo do item."
                                                    DataField="TipoItem" Label="Tipo do Item:" DataType="Number" LabelPosition="Top"
                                                    DefaultText="Selecione um tipo de item">
                                                </pro:ProDropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="linha_rotulo" style="height: 15px" colspan="3">
                                                <pro:ProRadioButtonList ID="rblUtilizado" runat="server" DataField="" Label="Utilizado por:"
                                                    AutoPostBack="true" OnSelectedIndexChanged="rblUtilizado_OnSelectedIndexChanged"
                                                    RepeatDirection="Horizontal">
                                                    <asp:ListItem Text="Poder Executivo" Value="E" />
                                                    <asp:ListItem Text="Poder Legislativo" Value="L" />
                                                </pro:ProRadioButtonList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="linha_rotulo" style="height: 15px; width: 34px;" colspan="3">
                                                <asp:Label ID="lblItemRemuneratorio" runat="server" Text="Código" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="linha_rotulo" style="height: 15px; width: 34px;" colspan="0">
                                                <pro:ProTextBox ID="txtDigito" runat="server" CssClass="obj_Controle" Enabled="false"
                                                    BackColor="#CCCCCC" Width="20px" DataField="Digito" MaxLength="1"></pro:ProTextBox>
                                            </td>
                                            <td class="linha_rotulo" style="height: 15px">
                                                <pro:ProTextBox ID="txtCodigo" runat="server" CssClass="obj_Controle_Obrigatorio_PP"
                                                    CssClassFocus="obj_Controle_Obrigatorio_Focus_PP" ToolTip="Informe o código."
                                                    DataField="Codigo" MaxLength="3"></pro:ProTextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="linha_rotulo" style="height: 15px" colspan="3">
                                                <pro:ProTextBox ID="txtDescricao" runat="server" CssClass="obj_Controle_Obrigatorio_M"
                                                    CssClassFocus="obj_Controle_Obrigatorio_Focus_M" ToolTip="Informe a descrição."
                                                    DataField="Descricao" Label="Descrição:" TextMode="MultiLine" Rows="3"></pro:ProTextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="linha_rotulo" style="height: 15px" colspan="3">
                                                <pro:ProDropDownList ID="ddlClassificacaoItem" runat="server" CssClass="obj_Controle_Obrigatorio_M"
                                                    CssClassFocus="obj_Controle_Obrigatorio_Focus_M" ToolTip="Informe a classificação do item."
                                                    DataField="ClassificacaoItem" Label="Classificação do item:" Width="269px" DataType="Number"
                                                    LabelPosition="Top" DefaultText="Selecione uma classificação do item">
                                                </pro:ProDropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 34px">
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div class="ColDireita">
                                    <pro:ProPanel ID="pnlAmparo" GroupingText="Amparo Legal" BorderWidth="0px" runat="server"
                                        Height="50%" Width="80%">
                                        <table>
                                            <tr>
                                                <td class="linha_rotulo" style="height: 15px" colspan="3">
                                                    <pro:ProDropDownList ID="ddlAmparo" runat="server" CssClass="obj_Controle_Obrigatorio_M"
                                                        CssClassFocus="obj_Controle_Obrigatorio_Focus_M" ToolTip="Informe o Amparo."
                                                        DataField="AmparoLegal" Label="Amparo:" DataType="Number" LabelPosition="Top"
                                                        DefaultText="Selecione um Amparo">
                                                    </pro:ProDropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="linha_rotulo" style="height: 15px">
                                                    <pro:ProTextBox ID="txtNumero" runat="server" CssClass="obj_Controle_Obrigatorio_PP"
                                                        CssClassFocus="obj_Controle_Obrigatorio_Focus_PP" Label="Número:" ToolTip="Informe o número."
                                                        DataField="NumeroAmparo" MaxLength="10"></pro:ProTextBox>
                                                </td>
                                                <td class="linha_rotulo" style="height: 15px">
                                                    <pro:ProTextBox ID="txtData" runat="server" CssClass="obj_Controle_Obrigatorio_PP"
                                                        CssClassFocus="obj_Controle_Obrigatorio_Focus_PP" Label="Data:" ToolTip="Informe a Data Legal."
                                                        DataField="DataAmparoLegal" DataType="Date"></pro:ProTextBox>
                                                    <asp:ImageButton runat="server" ID="btnData" ImageUrl="~/Parts/Thema2/images/ico_calendar.gif"
                                                        CssClass="cssCalendar" />
                                                    <cc1:CalendarExtender runat="server" ID="CalendarExtender2" TargetControlID="txtData"
                                                        PopupButtonID="btnData" Format="dd/MM/yyyy">
                                                    </cc1:CalendarExtender>
                                                </td>
                                                <td class="linha_rotulo" style="height: 15px">
                                                    <pro:ProTextBox ID="txtDataPublicacao" runat="server" CssClass="obj_Controle_PP" CssClassFocus="obj_Controle_Focus_PP"
                                                        Label="Data da Publicação :" ToolTip="Informe a data da publicação." DataField="DataAmparoPublicacao"
                                                        DataType="Date"></pro:ProTextBox>
                                                    <asp:ImageButton runat="server" ID="btnDataPublicacao" ImageUrl="~/Parts/Thema2/images/ico_calendar.gif"
                                                        CssClass="cssCalendar" />
                                                    <cc1:CalendarExtender runat="server" ID="CalendarExtender1" TargetControlID="txtDataPublicacao"
                                                        PopupButtonID="btnDataPublicacao" Format="dd/MM/yyyy">
                                                    </cc1:CalendarExtender>
                                                </td>
                                            </tr>
                                        </table>
                                    </pro:ProPanel>
                                    <pro:ProPanel ID="pnlNormaLegal" GroupingText="Última Norma Legal" BorderWidth="0px"
                                        runat="server" Height="50%" Width="80%">
                                        <table>
                                            <tr>
                                                <td class="linha_rotulo" style="height: 15px">
                                                    <pro:ProTextBox ID="txtNumeroNorma" runat="server" CssClass="obj_Controle_Obrigatorio_PP"
                                                        CssClassFocus="obj_Controle_Obrigatorio_Focus_PP" Label="Número:" ToolTip="Informe o número."
                                                        DataField="NumeroNormaLegal" MaxLength="10"></pro:ProTextBox>
                                                </td>
                                                <td class="linha_rotulo" style="height: 15px">
                                                    <pro:ProTextBox ID="txtDataNorma" runat="server" CssClass="obj_Controle_Obrigatorio_PP"
                                                        CssClassFocus="obj_Controle_Obrigatorio_Focus_PP" Label="Data:" ToolTip="Informe a Data."
                                                        DataField="DataNormaLegal" DataType="Date"></pro:ProTextBox>
                                                    <asp:ImageButton runat="server" ID="btnDataNorma" ImageUrl="~/Parts/Thema2/images/ico_calendar.gif"
                                                        CssClass="cssCalendar" />
                                                    <cc1:CalendarExtender runat="server" ID="CalendarExtender3" TargetControlID="txtDataNorma"
                                                        PopupButtonID="btnDataNorma" Format="dd/MM/yyyy">
                                                    </cc1:CalendarExtender>
                                                </td>
                                                <td class="linha_rotulo" style="height: 15px">
                                                    <pro:ProTextBox ID="txtDataNormaPublicacao" runat="server" CssClass="obj_Controle_PP"
                                                        CssClassFocus="obj_Controle_Focus_PP" Label="Data da Publicação :" ToolTip="Informe a Data da publicação."
                                                        DataField="DataNormaPublicacao" DataType="Date"></pro:ProTextBox>
                                                    <asp:ImageButton runat="server" ID="btnDataNormaPublicacao" ImageUrl="~/Parts/Thema2/images/ico_calendar.gif"
                                                        CssClass="cssCalendar" />
                                                    <cc1:CalendarExtender runat="server" ID="CalendarExtender4" TargetControlID="txtDataNormaPublicacao"
                                                        PopupButtonID="btnDataNormaPublicacao" Format="dd/MM/yyyy">
                                                    </cc1:CalendarExtender>
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
                        <asp:Button ID="btnExtincao" runat="server" Text="Extinguir" CssClass="obj_Btn_Command"
                            OnClick="MostrarExtinsao" />
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
    <cc1:ModalPopupExtender ID="mpeExtincaoItemsRemuneratorios" runat="server" PopupControlID="divCadastroUC"
        BackgroundCssClass="BackGroundPopup" TargetControlID="hdnBtn1" CancelControlID="imgFecharUC">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnBtn1" runat="server" />
    <div id="divCadastroUC" style="display: none; width: 600px;">
        <pro:ProPanel ID="pnlManutencaoUC" runat="server">
            <div id="LAY_CONTENT_CENTER_POPUP" style="height: 305px; width: 500px;">
                <div id="LAY_CONTENT_LEFT_POPUP">
                    <div id="LAY_CONTENT_RIGHT_POPUP">
                        <div id="LAY_TITULO_POPUP">
                            <asp:Label ID="lblTituloPopap" Text="Extinção de item remuneratório" runat="server"></asp:Label>
                            <div id="LAY_BOTAO_FECHAR_POPUP">
                                <asp:Image ID="imgFecharUC" runat="server" ImageUrl="~/Parts/Thema1/btnClose.png">
                                </asp:Image></div>
                        </div>
                        <pro:ProPanel ID="pnlAmparoExtincao" GroupingText="Amparo Legal para Extinção" BorderWidth="0px" runat="server" Height="50%" Width="80%">
                            <table style="padding: 1px; width: 397px;" >
                                <tr>
                                    <td class="linha_rotulo" style="height: 15px" colspan="3">
                                        <pro:ProDropDownList ID="ddlAmparoExtincao" runat="server" CssClass="obj_Controle_Obrigatorio_M"
                                            CssClassFocus="obj_Controle_Obrigatorio_Focus_M" ToolTip="Informe o Amparo."
                                            DataField="AmparoLegalExtincao" Label="Amparo:" DataType="Number" LabelPosition="Top"
                                            DefaultText="Selecione um Amparo">
                                        </pro:ProDropDownList>
                                    </td>
                                    <td class="linha_rotulo" style="height: 15px">
                                        <pro:ProTextBox ID="txtIDLista" runat="server" Visible="false" DataField="IdLista"></pro:ProTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="linha_rotulo" style="height: 15px">
                                        <pro:ProTextBox ID="txtNumeroExtincao" runat="server" CssClass="obj_Controle_Obrigatorio_PP"
                                            CssClassFocus="obj_Controle_Obrigatorio_Focus_PP" Label="Número:" ToolTip="Informe o número."
                                            DataField="NumeroAmparoExtincao" MaxLength="10"></pro:ProTextBox>
                                    </td>
                                    <td class="linha_rotulo" style="height: 15px">
                                        <pro:ProTextBox ID="txtDataExtincao" runat="server" CssClass="obj_Controle_Obrigatorio_PP"
                                            CssClassFocus="obj_Controle_Obrigatorio_Focus_PP" Label="Data:" ToolTip="Informe a Data Legal."
                                            DataField="DataAmparoLegalExtincao" DataType="Date"></pro:ProTextBox>
                                        <asp:ImageButton runat="server" ID="btnDataExtincao" ImageUrl="~/Parts/Thema2/images/ico_calendar.gif"
                                            CssClass="cssCalendar" />
                                        <cc1:CalendarExtender runat="server" ID="CalendarExtender5" TargetControlID="txtDataExtincao"
                                            PopupButtonID="btnDataExtincao" Format="dd/MM/yyyy">
                                        </cc1:CalendarExtender>
                                    </td>
                                    <td class="linha_rotulo" style="height: 15px">
                                        <pro:ProTextBox ID="txtDataPublicacaoExtincao" runat="server" CssClass="obj_Controle_PP"
                                            CssClassFocus="obj_Controle_Focus_PP" Label="Data da Publicação :" ToolTip="Informe a data da publicação."
                                            DataField="DataAmparoExtincaoPublicacao" DataType="Date"></pro:ProTextBox>
                                        <asp:ImageButton runat="server" ID="btnDataPublicacaoExtincao" ImageUrl="~/Parts/Thema2/images/ico_calendar.gif"
                                            CssClass="cssCalendar" />
                                        <cc1:CalendarExtender runat="server" ID="CalendarExtender6" TargetControlID="txtDataPublicacaoExtincao"
                                            PopupButtonID="btnDataPublicacaoExtincao" Format="dd/MM/yyyy">
                                        </cc1:CalendarExtender>
                                    </td>
                                </tr>
                            </table>
                        </pro:ProPanel>
                        <pro:ProPanel ID="pnlNormaExtincao" GroupingText="Última Norma Legal para Extinção"
                            BorderWidth="0px" runat="server" Height="50%" Width="80%">
                            <table style="padding: 1px; width: 397px;" >
                                <tr>
                                    <td class="linha_rotulo" style="height: 15px">
                                        <pro:ProTextBox ID="txtNormaExtincao" runat="server" CssClass="obj_Controle_Obrigatorio_PP"
                                            CssClassFocus="obj_Controle_Obrigatorio_Focus_PP" Label="Número:" ToolTip="Informe o número."
                                            DataField="NumeroNormaLegalExtincao" MaxLength="10"></pro:ProTextBox>
                                    </td>
                                    <td class="linha_rotulo" style="height: 15px">
                                        <pro:ProTextBox ID="txtNormaDataExtincao" runat="server" CssClass="obj_Controle_Obrigatorio_PP"
                                            CssClassFocus="obj_Controle_Obrigatorio_Focus_PP" Label="Data:" ToolTip="Informe a Data."
                                            DataField="DataNormaLegalExtincao" DataType="Date"></pro:ProTextBox>
                                        <asp:ImageButton runat="server" ID="btnDataNormaExtincao" ImageUrl="~/Parts/Thema2/images/ico_calendar.gif"
                                            CssClass="cssCalendar" />
                                        <cc1:CalendarExtender runat="server" ID="CalendarExtender7" TargetControlID="txtNormaDataExtincao"
                                            PopupButtonID="btnDataNormaExtincao" Format="dd/MM/yyyy">
                                        </cc1:CalendarExtender>
                                    </td>
                                    <td class="linha_rotulo" style="height: 15px">
                                        <pro:ProTextBox ID="txtDataNormaPublicacaoextincao" runat="server" CssClass="obj_Controle_PP"
                                            CssClassFocus="obj_Controle_Focus_PP" Label="Data da Publicação :" ToolTip="Informe a Data da publicação."
                                            DataField="DataNormaExtincaoPublicacao" DataType="Date"></pro:ProTextBox>
                                        <asp:ImageButton runat="server" ID="btnDataNormaExtincaoPublicacao" ImageUrl="~/Parts/Thema2/images/ico_calendar.gif"
                                            CssClass="cssCalendar" />
                                        <cc1:CalendarExtender runat="server" ID="CalendarExtender8" TargetControlID="txtDataNormaPublicacaoextincao"
                                            PopupButtonID="btnDataNormaExtincaoPublicacao" Format="dd/MM/yyyy">
                                        </cc1:CalendarExtender>
                                    </td>
                                </tr>
                            </table>
                        </pro:ProPanel>
                        <table>
                            <tr>
                                <td>
                                    <asp:Button ID="btnSalvarExtincao" runat="server" OnClick="btnSalvarExtincao_OnClick"
                                        OnClientClick="messageBox(this,'PERGUNTA','SIMNAO','Confirmação a Extinção','Deseja realmente extinguir este item ?',''); return false;"
                                        Text="Extinguir" CssClass="obj_Btn_Command" Visible="false" />
                                    <asp:Button ID="btnSavarExtincaoLista" runat="server" OnClick="btnSavarExtincaoLista_OnClick"
                                        OnClientClick="messageBox(this,'PERGUNTA','SIMNAO','Confirmação a Extinção','Deseja realmente extinguir este item ?',''); return false;"
                                        Text="Extinguir" CssClass="obj_Btn_Command" Visible="false" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </pro:ProPanel>
    </div>
    <div class="statusBar">
        <label id="labelAjudaComissao" class="Ajuda">
        </label>
    </div>
    <cc1:ModalPopupExtender ID="mpePergunta" runat="server" PopupControlID="divCadastroUCPergunta"
        BackgroundCssClass="BackGroundPopup" TargetControlID="hdnBtn11" CancelControlID="imgFecharUC">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnBtn11" runat="server" />
    <div id="divCadastroUCPergunta" style="display: none; width: 600px;">
        <pro:ProPanel ID="pnlManutencaoUCPergunta" Visible="false" runat="server">
            <div id="LAY_CONTENT_CENTER_POPUP" style="height: 115px; width: 349px;">
                <div id="LAY_CONTENT_LEFT_POPUP">
                    <div id="LAY_CONTENT_RIGHT_POPUP">
                        <table width="100%" cellspacing="0" cellpadding="0" border="0" style="background: url(Parts/Thema2/images/bg_meio-right.jpg)">
                            <tr>
                                <td height="1" style="background-image: url(parts/thema1/pixel_mensagem.gif)">
                                    <img width="1" height="1" src="parts/thema1/pixel_mensagem.gif" alt="">
                                </td>
                            </tr>
                            <tr>
                                <td bgcolor="#e8f2f9">
                                    <div id="lblPopupTitulo" style="height: 15px; margin: 4px; background-color: #c1d2e7;
                                        font-family: Tahoma, Arial, Verdana; font-size: 11px; color: #000000; font-weight: bold;
                                        cursor: move;">
                                        Confirmação de Extinção
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td bgcolor="#f1f4f8">
                                    <div style="margin: 4px">
                                        <table width="100%" cellspacing="5" cellpadding="3" border="0">
                                            <tr>
                                                <td style="width: 50px">
                                                    <img id="imgPopupIcone" width="40" height="40" border="0" src="parts/Thema1/imgPERGUNTAMessageBox.gif"
                                                        alt="" />
                                                </td>
                                                <td id="Td1" align="left" style="width: 94%; font-family: Tahoma, Arial, Verdana;
                                                    font-weight: normal; font-size: 11px; color: #000000;">
                                                    <asp:Label ID="lblPergunta" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="width: 100%" colspan="2">
                                                    <asp:Button ID="btnSim" runat="server" Text="Sim" OnClick="btnSim_OnClick" CssClass="obj_Btn_Command"
                                                        Width=" 96px" />
                                                    <asp:Button ID="btnNao" runat="server" Text="Não" OnClick="btnNao_OnClick" CssClass="obj_Btn_Command"
                                                        Width=" 96px" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td height="4" style="background-image: url(parts/thema1/pixel_mensagem.gif)">
                                    <img width="1" height="1" src="parts/thema1/pixel_mensagem.gif" alt="" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </pro:ProPanel>
    </div>
    <div class="statusBar">
        <label id="labelAjudaComissao1" class="Ajuda">
        </label>
    </div>
</asp:Content>
