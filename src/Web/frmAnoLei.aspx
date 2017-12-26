﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true"
    CodeBehind="frmAnoLei.aspx.cs" Inherits="Platinium.Web.AnoLei" %>

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
                        <pro:ProDropDownList Label="Buscar por: " LabelPosition="Beside" LabelCssClass="LabelFiltro"
                            ID="ddlCampoBusca" runat="server" CssClass="obj_Controle" />
                        <asp:Label ID="lblBusca" runat="server"></asp:Label><pro:ProTextBox ID="txtBusca"
                            runat="server" Width="200px" CssClass="obj_Controle" ToolTip="Informe o texto para busca."></pro:ProTextBox>
                        <asp:Button ID="btnBuscar" runat="server" CssClass="obj_Btn_Command" Text="Buscar"
                            Width="50px" />
                        <asp:Button ID="btnNovo" runat="server" Text="Novo" CssClass="obj_Btn_Command" CommandName="Novo"
                            Width="65px" />
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
                                        <asp:BoundField DataField="AnoElaboracao" HeaderText="Ano" ItemStyle-Width="5%" SortExpression="Codigo"
                                            HeaderStyle-HorizontalAlign="Left"></asp:BoundField>
                                        <asp:BoundField DataField="DscLeiLdo" HeaderStyle-HorizontalAlign="Left" HeaderText="Lei LDO"
                                            ItemStyle-Width="30%" SortExpression="DscLeiLdo">
                                            <HeaderStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DscLeiLoa" HeaderStyle-HorizontalAlign="Left" HeaderText="Lei LOA"
                                            ItemStyle-Width="30%" SortExpression="DscLeiLoa">
                                            <HeaderStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DscLeiPpa" HeaderStyle-HorizontalAlign="Left" HeaderText="Lei PPA"
                                            ItemStyle-Width="30%" SortExpression="DscLeiPpa">
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
                                <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%" style="vertical-align: top;
                                    width: 100%; text-align: center">
                                    <tr>
                                        <td class="linha_rotulo" colspan="3" style="height: 15px">
                                            <pro:ProTextBox ID="txtAnoElaboracao" CssClass="obj_Controle_Obrigatorio_P" CssClassFocus="obj_Controle_Obrigatorio_Focus_P"
                                                ToolTip="Informe o ano elaboração da lei." DataField="AnoElaboracao" Label="Ano Elaboração:"
                                                runat="server" MaxLength="4"></pro:ProTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <pro:ProPanel ID="pnlLeiLdo" runat="server" GroupingText="Lei LDO">
                                                <table align="center" border="0" cellpadding="0" cellspacing="0" width="95%" style="vertical-align: top;
                                                    width: 95%; text-align: center">
                                                    <tr>
                                                        <td class="linha_rotulo" colspan="3" style="height: 15px">
                                                            <pro:ProTextBox ID="txtDscLeiLdo" runat="server" CssClass="obj_Controle_Obrigatorio_G"
                                                                CssClassFocus="obj_Controle_Obrigatorio_Focus_G" ToolTip="Informe a descrição da lei."
                                                                DataField="DscLeiLdo" Label="Descrição da lei do LDO:"></pro:ProTextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </pro:ProPanel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <pro:ProPanel ID="pnlLeiLoa" runat="server" GroupingText="Lei LOA">
                                                <table align="center" border="0" cellpadding="0" cellspacing="0" width="95%" style="vertical-align: top;
                                                    width: 95%; text-align: center">
                                                    <tr>
                                                        <td class="linha_rotulo" colspan="3" style="height: 15px">
                                                            <pro:ProTextBox ID="txtDscLeiLoa" runat="server" CssClass="obj_Controle_Obrigatorio_G"
                                                                CssClassFocus="obj_Controle_Obrigatorio_Focus_G" ToolTip="Informe a descrição da lei."
                                                                DataField="DscLeiLoa" Label="Lei LOA:"></pro:ProTextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="linha_rotulo" style="height: 15px; width: 200px;">
                                                            <pro:ProTextBox ID="txtNumLeiLoa" runat="server" CssClass="obj_Controle_P"
                                                                CssClassFocus="obj_Controle_Focus_P" ToolTip="Informe o número da lei."
                                                                DataField="NumLeiLoa" Label="Número da lei do LOA:"></pro:ProTextBox>
                                                        </td>
                                                        <td class="linha_rotulo" style="height: 15px; width: 200px;">
                                                            <pro:ProTextBox ID="txtPercSuplAprovLeiLoa" runat="server" CssClass="obj_Controle_P"
                                                                CssClassFocus="obj_Controle_Focus_P" ToolTip="Informe o percentual de suplementação aprovado."
                                                                DataField="PercSuplAprovLeiLoa" Label="Perc. de suplementação aprovado:"></pro:ProTextBox>
                                                        </td>
                                                        <td class="linha_rotulo" style="height: 15px; width: 200px;">
                                                            <pro:ProTextBox ID="txtTotalSuplAprovLeiLoa" runat="server" CssClass="obj_Controle_P"
                                                                CssClassFocus="obj_Controle_Focus_P" ToolTip="Informe o valor total suplementação aprovado."
                                                                DataField="TotalSuplAprovLeiLoa" Label="Valor suplementação aprovado:"></pro:ProTextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="linha_rotulo" style="height: 15px">
                                                             <pro:ProTextBox ID="txtDataEnvio" runat="server" CssClass="obj_Controle_P"
                                                                CssClassFocus="obj_Controle_Focus_P" ToolTip="Informe a data do envio."
                                                                DataField="DataEnvio" DataType="Date" Label="Data do envio:"></pro:ProTextBox>
                                                        </td>
                                                        <td class="linha_rotulo" style="height: 15px">
                                                             <pro:ProTextBox ID="txtDataAprovacao" runat="server" CssClass="obj_Controle_P"
                                                                CssClassFocus="obj_Controle_Focus_P" ToolTip="Informe a data da aprovação."
                                                                DataField="DataAprovacao" DataType="Date" Label="Data da aprovação:"></pro:ProTextBox>
                                                        </td>
                                                        <td class="linha_rotulo" style="height: 15px">
                                                            <pro:ProTextBox ID="txtDataPublicacao" runat="server" CssClass="obj_Controle_P"
                                                                CssClassFocus="obj_Controle_Focus_P" ToolTip="Informe a data da publicação."
                                                                DataField="DataPublicacao" DataType="Date" Label="Data da publicação:"></pro:ProTextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </pro:ProPanel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <pro:ProPanel ID="pnlLeiPpa" runat="server" GroupingText="Lei PPA">
                                                <table align="center" border="0" cellpadding="0" cellspacing="0" width="95%" style="vertical-align: top;
                                                    width: 95%; text-align: center">
                                                    <tr>
                                                        <td class="linha_rotulo" colspan="3" style="height: 15px">
                                                            <pro:ProTextBox ID="txtDscLeiPpa" runat="server" CssClass="obj_Controle_Obrigatorio_G"
                                                                CssClassFocus="obj_Controle_Obrigatorio_Focus_G" ToolTip="Informe a descrição da lei."
                                                                DataField="DscLeiPpa" Label="Descrição da lei do PPA:"></pro:ProTextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </pro:ProPanel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="linha_rotulo" colspan="1" style="height: 15px; width: 120px;">
                                        </td>
                                        <td class="linha_rotulo" colspan="2" style="height: 15px">
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
