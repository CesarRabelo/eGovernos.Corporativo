<%@ Control Language="C#" CodeBehind="ucEndereco.ascx.cs" Inherits="Platinium.Web.ucEndereco" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="Pro.Controls" Namespace="Pro.Controls" TagPrefix="pro" %>
<%--<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>--%>
<link href="/Parts/Thema1/Estilo.css" rel="stylesheet" type="text/css" />
<cc1:ListSearchExtender runat="server" PromptPosition="Top" PromptText="Digite..."
    PromptCssClass="obj_Controle" ID="lseEstado" TargetControlID="ddlEstado" />
<cc1:ListSearchExtender runat="server" PromptPosition="Top" PromptText="Digite para buscar..."
    PromptCssClass="obj_Controle" ID="lseLocalidade" TargetControlID="ddlLocalidade" />
<cc1:ListSearchExtender runat="server" PromptPosition="Top" PromptText="Digite para buscar..."
    PromptCssClass="obj_Controle" ID="lseBairro" TargetControlID="ddlBairro" />
<pro:ProPanel ID="pnlEndereco" runat="server" >
    <table border="0" cellpadding="0" cellspacing="0" >
        <tr>
            <td class="linha_rotulo">
                <pro:ProTextBox ID="txtCep" runat="server" CssClass="obj_Controle_Obrigatorio" CssClassFocus="obj_Controle_Obrigatorio_Focus"
                    DataField="Cep" DataType="CEP" Label="CEP:" IncludeTopSpace="False" Width="60px"></pro:ProTextBox>
                <asp:Button ID="btnBuscaCep" runat="server" OnClick="btnBuscaCep_Click" Width="22px"
                    CssClass="obj_Btn_Command" Text="..." />
            </td>
            <td class="linha_rotulo">
                &nbsp;&nbsp;
            </td>
            <td class="linha_rotulo">
                <pro:ProDropDownList ID="ddlEstado" runat="server" CssClass="obj_Controle_Obrigatorio"
                    CssClassFocus="obj_Controle_Obrigatorio_Focus" Width="80px" DataField="SiglaEstado"
                    OnSelectedIndexChanged="ddlEstado_SelectedIndexChanged" AutoPostBack="True" DataTextField="SiglaEstado"
                    DataValueField="SiglaEstado" EnableTheming="False" IncludeTopSpace="False" Label="Estado:"
                    DefaultText=" ">
                </pro:ProDropDownList>
            </td>
            <td class="linha_rotulo">
                &nbsp;&nbsp;
            </td>
            <td class="linha_rotulo" colspan="2">
                <pro:ProDropDownList ID="ddlLocalidade" runat="server" CssClass="obj_Controle_Obrigatorio"
                    CssClassFocus="obj_Controle_Obrigatorio_Focus" Width="100%" OnSelectedIndexChanged="ddlMunicipio_SelectedIndexChanged"
                    AutoPostBack="True" DataField="Localidade" DataTextField="Localidade" DataValueField="Localidade"
                    Enabled="False" IncludeTopSpace="False" Label="Localidade:" DefaultText=" ">
                </pro:ProDropDownList>
            </td>
            <td class="linha_rotulo">
                &nbsp;&nbsp;
            </td>
            <td class="linha_rotulo" colspan="3">
                <pro:ProDropDownList ID="ddlBairro" runat="server" CssClass="obj_Controle_Obrigatorio"
                    CssClassFocus="obj_Controle_Obrigatorio_Focus" Width="100%" DataField="Bairro"
                    DataTextField="Bairro" DataValueField="Bairro" Enabled="False" IncludeTopSpace="False"
                    Label="Bairro:" DefaultText=" ">
                </pro:ProDropDownList>
            </td>
        </tr>
        <tr>
            <td class="linha_rotulo" colspan="6">
                <pro:ProTextBox ID="txtLogradouro" runat="server" CssClass="obj_Controle_Obrigatorio"
                    CssClassFocus="obj_Controle_Obrigatorio_Focus" DataField="Logradouro" Width="97%"
                    Label="Logradouro:"></pro:ProTextBox>
            </td>
            <td class="linha_rotulo">
                &nbsp;
            </td>
            <td class="linha_rotulo">
                <pro:ProTextBox ID="txtNumero" runat="server" CssClass="obj_Controle_Obrigatorio"
                    CssClassFocus="obj_Controle_Obrigatorio_Focus" DataField="Numero" Label="Número:"
                    Width="60px"></pro:ProTextBox>               
                     <asp:ImageButton ID="imgMap" ImageUrl="/Parts/Thema1/marcadorOn.png"
                                   runat="server" OnClick="btnShowMap_Click" ToolTip="Mostrar Mapa" />
            </td>
            <td class="linha_rotulo">
            </td>
            <td class="linha_rotulo">
                <pro:ProTextBox ID="txtComplemento" runat="server" CssClass="obj_Controle" Width="70px"
                    DataField="Complemento" Label="Complemento:"></pro:ProTextBox>
            </td>
        </tr>
        <tr>
            <td class="linha_rotulo">
            </td>
            <td class="linha_rotulo">
            </td>
            <td class="linha_rotulo">
            </td>
            <td class="linha_rotulo">
            </td>
            <td class="linha_rotulo">
            </td>
            <td class="linha_rotulo">
            </td>
            <td class="linha_rotulo">
            </td>
            <td class="linha_rotulo">
            </td>
            <td class="linha_rotulo">
            </td>
            <td class="linha_rotulo">
            </td>
        </tr>
    </table>
</pro:ProPanel>
<cc1:AutoCompleteExtender ID="aceLogradouro" runat="server" ServiceMethod="Busca"
    ServicePath="BuscaEndereco.asmx" TargetControlID="txtLogradouro" UseContextKey="True"
    Enabled="True" MinimumPrefixLength="1" CompletionListItemCssClass="autocomplete_listItem"
    CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" CompletionInterval="500">
</cc1:AutoCompleteExtender>
