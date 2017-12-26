<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true"
    CodeBehind="frmLicenciada.aspx.cs" Inherits="Platinium.Web.Licenciada" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="Pro.Controls" Namespace="Pro.Controls" TagPrefix="pro" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/ucCabecalhoObrigatorio.ascx" TagName="ucObrigatorio" TagPrefix="obr" %>
<%@ Register Src="UserControls/ucEndereco.ascx" TagName="ucEndereco" TagPrefix="uc1" %>
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
                <asp:MultiView ID="mtvPrincipal" runat="server" ActiveViewIndex="0">
                    <asp:View ID="vwCadastro" runat="server">
                        <div class="obj_Conteudo txt_padrao">
                            <pro:ProPanel ID="pnlManutencao" runat="server" BorderWidth="0px" Height="100%" Width="100%">
                                <obr:ucObrigatorio ID="ucObrigatorio1" runat="server" />
                                <table align="center" border="0" cellpadding="0" cellspacing="0" width="95%" style="vertical-align: top;
                                    width: 95%; text-align: center">
                                    <tr>
                                        <td class="linha_rotulo" style="height: 15px">
                                            <pro:ProTextBox ID="txtLicenciada" CssClass="obj_Controle_Obrigatorio_G" CssClassFocus="obj_Controle_Obrigatorio_Focus_G"
                                                ToolTip="Informe a licenciada." DataField="Descricao" Label="Licenciada:" runat="server"></pro:ProTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="linha_rotulo" colspan="3" style="height: 15px">
                                            <pro:ProTextBox ID="txtCnpj" CssClass="obj_Controle_Obrigatorio_M" CssClassFocus="obj_Controle_Obrigatorio_Focus_M"
                                                ToolTip="Informe o CNPJ da licenciada." DataField="Cnpj" Label="CNPJ:" runat="server"
                                                DataType="CNPJ"></pro:ProTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="linha_rotulo" colspan="3" style="height: 15px">
                                            <pro:ProTextBox ID="txtEstado" CssClass="obj_Controle_Obrigatorio_M" CssClassFocus="obj_Controle_Obrigatorio_Focus_M"
                                                ToolTip="Informe o estado da licenciada." DataField="Estado" Label="Estado:"
                                                runat="server"></pro:ProTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="linha_rotulo" colspan="3" style="height: 15px">
                                            <pro:ProTextBox ID="txtCodMunicipio" CssClass="obj_Controle_Obrigatorio_P" CssClassFocus="obj_Controle_Obrigatorio_Focus_P"
                                                ToolTip="Informe o código do município." DataField="CodigoMunicipio" Label="Código do Município:"
                                                runat="server"></pro:ProTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="linha_rotulo" colspan="3" style="height: 15px">
                                            <pro:ProTextBox ID="txtTelefone" CssClass="obj_Controle_Obrigatorio_M" CssClassFocus="obj_Controle_Obrigatorio_Focus_M"
                                                ToolTip="Informe o telefone da licenciada." DataField="Telefone" Label="Telefone:"
                                                runat="server" DataType="Phone"></pro:ProTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="linha_rotulo" colspan="3" style="height: 15px">
                                            <pro:ProTextBox ID="txtEmail" CssClass="obj_Controle_Obrigatorio_M" CssClassFocus="obj_Controle_Obrigatorio_Focus_M"
                                                ToolTip="Informe o email da licenciada." DataField="Email" Label="Email:" runat="server"></pro:ProTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="linha_rotulo" colspan="3" style="height: 15px">
                                            <pro:ProTextBox ID="txtContato" CssClass="obj_Controle_Obrigatorio_M" CssClassFocus="obj_Controle_Obrigatorio_Focus_M"
                                                ToolTip="Informe o contato da licenciada." DataField="Contato" Label="Contato:"
                                                runat="server"></pro:ProTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="linha_rotulo" colspan="1" style="height: 15px; width: 120px;">
                                        </td>
                                        <td class="linha_rotulo" colspan="2" style="height: 15px">
                                        </td>
                                    </tr>
                                </table>
                                <%--<div class="ColFooter">
                                    <pro:ProPanel ID="pnlEndereco" GroupingText="Endereço" runat="server" Width="790px">
                                        <table align="center" border="0" cellpadding="0" cellspacing="0" width="95%" style="vertical-align: top;
                                            width: 95%; text-align: center">
                                            <uc1:ucEndereco ID="ucEndereco1" runat="server" />
                                        </table>
                                    </pro:ProPanel>
                                </div>--%>
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
                        <asp:Button ID="btnSalvar" runat="server" Text="Salvar" CommandName="Salvar" CssClass="obj_Btn_Command"
                            OnClick="btnSalvar_Click" />
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
