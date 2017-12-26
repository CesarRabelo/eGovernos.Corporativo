<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="InicializarSistema.aspx.cs" Inherits="Web.frmInicializarSistema" Title="Untitled Page" %>

<%@ Register Assembly="Pro.Controls" Namespace="Pro.Controls" TagPrefix="pro" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphPadrao" runat="server">
<div class="obj_Conteudo txt_padrao">
    <asp:MultiView id="mtvInicializar" runat="server">
        <asp:View id="vwUsuarioInicial" runat="server">
        <center>
            &nbsp;</center>
            <center>
                Preencha os campos do usuário inicial do sistema.<br /><br />
            </center>
            <pro:ProPanel ID="pnlDadosUsuario"
            runat="server" BorderStyle="None" GroupingText="Dados do Usuário" Height="100%"
            Width="100%">
            <table align="center" border="0" cellpadding="0" cellspacing="0" style="vertical-align: top;
                width: 98%; text-align: left">
                <tbody>
                    <tr>
                        <td class="linha_rotulo" style="width: 20%">
                        </td>
                        <td class="linha_rotulo" style="width: 20%">
                        </td>
                        <td class="linha_rotulo" style="width: 20%">
                            </td>
                        <td class="linha_rotulo" style="width: 20%">
                        </td>
                        <td class="linha_rotulo" style="width: 20%">
                        </td>
                    </tr>
                    <tr>
                        <td class="linha_rotulo" colspan="3">
                            <pro:ProTextBox ID="txtNome" runat="server" CssClass="obj_Controle" DataField="Nome"
                                IncludeTopSpace="False" Label="Nome:" MaxLength="100" Width="300px"></pro:ProTextBox></td>
                        <td class="linha_rotulo" colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td class="linha_rotulo" colspan="3">
                            <pro:ProTextBox ID="txtEmail" runat="server" CssClass="obj_Controle" DataField="Email"
                                Label="Email:" MaxLength="100" Width="300px"></pro:ProTextBox></td>
                        <td class="linha_rotulo" colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td class="linha_rotulo" style="width: 20%">
                            <pro:ProTextBox ID="txtLogin" runat="server" CssClass="obj_Controle" DataField="Login"
                                Label="Login:" MaxLength="15" Width="110px"></pro:ProTextBox></td>
                        <td class="linha_rotulo" style="width: 20%">
                            <pro:ProTextBox ID="txtSenha" runat="server" CssClass="obj_Controle" DataField="Senha"
                                Label="Senha:" MaxLength="15" TextMode="Password" Width="110px"></pro:ProTextBox></td>
                        <td class="linha_rotulo" style="width: 20%">
                            &nbsp; &nbsp; &nbsp; &nbsp;
                        </td>
                        <td class="linha_rotulo" style="width: 20%">
                        </td>
                        <td class="linha_rotulo" style="vertical-align: bottom; width: 20%; text-align: right">
                            &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;
                        </td>
                    </tr>
                </tbody>
            </table>
        </pro:ProPanel>
            <br />
            <br />
                    <div class="obj_Aba_Commands">
                        &nbsp; &nbsp;
                            <asp:Button id="btnCadastrarUsuario" runat="server" CssClass="obj_Btn_Command"
                                Text="Confirmar" OnClick="btnCadastrarUsuario_Click" />
            </div> 
        </asp:View>
    </asp:MultiView>
</div>
</asp:Content>
