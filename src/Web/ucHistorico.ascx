<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucHistorico.ascx.cs" Inherits="Imobium.Web.ucHistorico" %>
<%@ Register Assembly="Pro.Controls" Namespace="Pro.Controls" TagPrefix="pro" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<div id="LAY_TITULO">
	<div class="obj_Grid_Search_Left">
		<pro:prolabel id="lblTitulo" runat="server"></pro:prolabel>
	</div>
	<pro:propanel id="pnlConsulta" runat="server" cssclass="obj_Grid_Search_Right" horizontalalign="Right">
                        <asp:Label id="lblBusca" runat="server"></asp:Label><pro:ProTextBox ID="txtBusca" runat="server" CssClass="obj_Controle"></pro:ProTextBox>
                        <asp:Button id="btnBuscar" runat="server" CssClass="obj_Btn_Command" Text="Buscar" Width="50px" />
                    </pro:propanel>
</div>
<asp:MultiView ID="mtvPrincipal" runat="server" ActiveViewIndex="0">
	<asp:View ID="vwListagem" runat="server">
		<pro:propanel id="pnlListagem" runat="server" borderwidth="0px" height="100%" width="100%">
            <div class="obj_Conteudo txt_padrao">
                <pro:ProGridView ID="grdListagem" runat="server" CssClass="obj_Grid" GridLines="None" Width="100%" AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" AutoPostBack="True" DataKeyNames="Id" AutoGenerateSelectColumn="True">
                    <HeaderStyle CssClass="obj_Grid_Header" />
                    <AlternatingRowStyle CssClass="obj_Grid_AlternatingRow" />
                    <RowStyle CssClass="obj_Grid_Row" />
                    <SelectedRowStyle CssClass="obj_Grid_SelectedRow" />
                    <PagerStyle CssClass="obj_Grid_Pager" />
                    <Columns>
                        <asp:ButtonField DataTextField="DataOcorrencia"
                            HeaderText="Data" CommandName="Edit" SortExpression="DataOcorrencia" >
                            <headerstyle horizontalalign="Left" Width="140px"/>
                        </asp:ButtonField>
                        <asp:ButtonField DataTextField="Assunto" HeaderText="Assunto" SortExpression="Assunto"
                            Text="Button" CommandName="Edit" >
                            <headerstyle horizontalalign="Left" Width="200px"/>
                        </asp:ButtonField>                             
                        <asp:ButtonField DataTextField="Descricao" HeaderText="Descri&#231;&#227;o" SortExpression="Descricao"
                            Text="Button" CommandName="Edit" >
                            <headerstyle horizontalalign="Left" Width="50%"/>
                        </asp:ButtonField>                        
                        <asp:ButtonField DataTextField="Usuario.Nome"
                            HeaderText="Usu&#225;rio" CommandName="Edit" SortExpression="Usuario.Nome" >
                            <headerstyle horizontalalign="Left" />
                        </asp:ButtonField>
                        <asp:ButtonField CommandName="Edit" DataTextField="Origem.Nome" HeaderText="Origem" SortExpression="Origem.Nome"
                            Text="Button" Visible="false">
                            <headerstyle horizontalalign="Left" />
                        </asp:ButtonField>

                    </Columns>
                    <EmptyDataRowStyle CssClass="SemRegistros" Font-Bold="True" />
                </pro:ProGridView>            
            </div>
            </pro:propanel>
		<div class="obj_Aba_Commands">
			<asp:Button ID="btnNovo" runat="server" CommandName="Novo" CssClass="obj_Btn_Command"
				Text="Novo" Width="65px" />
		</div>
	</asp:View>
	<asp:View ID="vwCadastro" runat="server">
		<div class="obj_Conteudo txt_padrao">
			<pro:propanel id="pnlManutencao" runat="server" borderwidth="0px" height="100%" width="100%"><pro:ProPanel id="pnlDados" runat="server" Width="100%" Height="100%" GroupingText="Dados do Histórico" BorderStyle="None"> <TABLE style="VERTICAL-ALIGN: top; WIDTH: 98%; TEXT-ALIGN: left" cellSpacing=0 cellPadding=0 align=center border=0><TBODY><TR><TD style="WIDTH: 10%" class="linha_rotulo"></TD><TD style="WIDTH: 25%" class="linha_rotulo"></TD><TD style="WIDTH: 20%" class="linha_rotulo"></TD><TD style="WIDTH: 20%" class="linha_rotulo"></TD><TD style="WIDTH: 20%" class="linha_rotulo"></TD></TR>
				<tr>
					<td class="linha_rotulo" style="width: 20%">
						<pro:ProTextBox ID="txtData" runat="server" CssClass="obj_Controle_Somente_Leitura" DataField="DataOcorrencia"
							DataType="DateTime" ReadOnly="true" IncludeTopSpace="False" Label="Data:" Width="100px"></pro:ProTextBox></td>
					<td class="linha_rotulo" style="width: 20%">
						<pro:ProDropDownList ID="ddlOrigem" runat="server" CssClass="obj_Controle" DataField="Origem"
							DataType="Number" DefaultText=" " IncludeTopSpace="False" Label="Origem:" Width="150px" Visible="false">
						</pro:ProDropDownList></td>
					<td class="linha_rotulo" colspan="2">
						<pro:ProDropDownList ID="ddlUsuario" runat="server" CssClass="obj_Controle" DataField="Usuario"
							DataType="Number" DefaultText=" " IncludeTopSpace="False" Label="Usuário:" Width="300px" Visible="false">
						</pro:ProDropDownList></td>
					<td class="linha_rotulo" style="width: 20%">
						<pro:ProTextBox ID="txtCliente" runat="server" DataField="Cliente" DataType="Number"
							Width="50px" Visible="False"></pro:ProTextBox>
						<pro:ProTextBox ID="txtIdCondominio" runat="server" DataField="Condominio" DataType="Number"
							Width="50px" Visible="False"></pro:ProTextBox>
						<pro:ProTextBox ID="txtImovel" runat="server" DataField="Imovel" DataType="Number"
							Width="50px" Visible="False"></pro:ProTextBox>
						<pro:ProTextBox ID="txtCA" runat="server" DataField="ContratoAdministracao" DataType="Number"
							Width="50px" Visible="False"></pro:ProTextBox>
						<pro:ProTextBox ID="txtCL" runat="server" DataField="ContratoLocacao" DataType="Number"
							Width="50px" Visible="False"></pro:ProTextBox>
					</td>
				</tr>
                    <tr>
                        <td class="linha_rotulo" colspan="5">
                            <pro:ProTextBox id="txtAssunto" runat="server" CssClass="obj_Controle" Width="700px" DataField="Assunto" Label="Assunto:"></pro:ProTextBox></td>
                    </tr>				
                    <tr>
                        <td class="linha_rotulo" colspan="5">
                            <pro:ProTextBox id="txtDescricao" runat="server" CssClass="obj_Controle" Width="700px" DataField="Descricao" Label="Descrição:" Rows="6" TextMode="MultiLine"></pro:ProTextBox></td>
                    </tr>
                    <TR><TD style="WIDTH: 20%" class="linha_rotulo"></TD><TD style="WIDTH: 20%" class="linha_rotulo"></TD><TD style="WIDTH: 20%" class="linha_rotulo"></TD><TD style="WIDTH: 20%" class="linha_rotulo"></TD><TD style="WIDTH: 20%" class="linha_rotulo"></TD></TR></TBODY></TABLE> &nbsp;
                </pro:ProPanel> </pro:propanel>
		</div>
		<div class="obj_Aba_Commands">
			&nbsp;
			<asp:Button ID="btnSalvar" runat="server" CommandName="Salvar" CssClass="obj_Btn_Command"
				Text="Salvar" Width="65px" />
			<asp:Button ID="btnNovoCadastro" runat="server" CommandName="Novo" CssClass="obj_Btn_Command"
				Text="Novo" Width="65px" />
			<asp:Button ID="btnExcluir" runat="server" CommandName="Excluir" CssClass="obj_Btn_Command"
				Text="Excluir" Width="65px" />
			<asp:Button ID="btnListagem" runat="server" CommandName="Listagem" CssClass="obj_Btn_Command"
				Text="Listagem" Width="65px" />
		</div>
	</asp:View>
</asp:MultiView>