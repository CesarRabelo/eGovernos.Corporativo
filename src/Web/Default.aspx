<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="Web.Default" Title="Untitled Page" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="Pro.Controls" Namespace="Pro.Controls" TagPrefix="pro" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cphPadrao" runat="server">
    <div class="paginaPrincipal">
        <asp:Panel runat="server" ID="pnlListagem">
            <center>
                <pro:ProGridView ID="grdListagem" runat="server" AllowPaging="True" AllowSorting="True"
                    AutoGenerateColumns="False" CssClass="obj_Grid" DataKeyNames="Id" GridLines="None"
                    Width="100%" OnRowDataBound="grdListagem_RowDataBound" PageSize="15" OnPageIndexChanging="grdListagem_PageIndexChanging">
                    <Columns>
                       <asp:BoundField DataField="Nome" HeaderText="Cliente">
                            <HeaderStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Imovel.Codigo" HeaderText="C&#243;digo">
                            <HeaderStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Endereco.Logradouro" HeaderText="Im&#243;vel">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="DataProximoReajuste" DataFormatString="{0:dd/MM/yyyy}"
                            HeaderText="Pr&#243;x.&#160;reajuste" >
                            <HeaderStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="DiasReajuste" HeaderText="Dias">
                            <HeaderStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:HyperLinkField DataNavigateUrlFields="Id" 
                            DataNavigateUrlFormatString="frmReajusteContratoLocacao.aspx?id={0}" Text="..." /> 
                    </Columns>
                    <EmptyDataRowStyle CssClass="obj_Grid_Row_Nao_Localizado" />
                    <HeaderStyle CssClass="obj_Grid_Header" />
                    <PagerStyle CssClass="obj_Grid_Pager_default" />
                    <AlternatingRowStyle CssClass="obj_Grid_AlternatingRow" />
                    <RowStyle CssClass="obj_Grid_Row" />
                    <SelectedRowStyle CssClass="obj_Grid_SelectedRow" />
                </pro:ProGridView>
            </center>
        </asp:Panel>
    </div>
</asp:Content>
