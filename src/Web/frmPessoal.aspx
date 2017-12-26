<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true"
    CodeBehind="frmPessoal.aspx.cs" Inherits="Platinium.Web.frmPessoal" %>

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
                <div id="LAY_FILTRO">
                    <pro:ProPanel ID="pnlConsulta" GroupingText="Filtros para busca" runat="server">
                        <table>
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
                                        <asp:BoundField DataField="DescricaoNome" HeaderText="Nome" ItemStyle-Width="30%"
                                            SortExpression="DescricaoNome" HeaderStyle-HorizontalAlign="Left">
                                            <ItemStyle Width="30%" />
                                            <HeaderStyle Width="30%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="NomeMae" HeaderText="Mãe" ItemStyle-Width="30%" SortExpression="NomeMae"
                                            HeaderStyle-HorizontalAlign="Left">
                                            <ItemStyle Width="30%" />
                                            <HeaderStyle Width="30%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Cpf" HeaderText="CPF" ItemStyle-Width="10%" SortExpression="Cpf"
                                            HeaderStyle-HorizontalAlign="Left">
                                            <ItemStyle Width="10%" />
                                            <HeaderStyle Width="10%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Identidade" HeaderText="Identidade" ItemStyle-Width="10%"
                                            SortExpression="Identidade" HeaderStyle-HorizontalAlign="Left">
                                            <ItemStyle Width="10%" />
                                            <HeaderStyle Width="10%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="IdentidadeExpedidor" HeaderText="Expedidor Identidade"
                                            ItemStyle-Width="10%" SortExpression="IdentidadeExpedidor" HeaderStyle-HorizontalAlign="Left">
                                            <ItemStyle Width="10%" />
                                            <HeaderStyle Width="10%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Telefone" HeaderText="Telefone" ItemStyle-Width="10%"
                                            SortExpression="Telefone" HeaderStyle-HorizontalAlign="Left">
                                            <ItemStyle Width="10%" />
                                            <HeaderStyle Width="10%" />
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
                                <pro:ProPanel ID="ProPanel1" GroupingText="Dados Gerais" runat="server" Width="655px">
                                    <table align="left" border="0" cellpadding="0" cellspacing="0" style="vertical-align: top;
                                        width: 55%; text-align: center">
                                        <tr>
                                            <td class="linha_rotulo" style="height: 15px" colspan="2">
                                                <pro:ProTextBox ID="txtNome" runat="server" CssClass="obj_Controle_Obrigatorio" CssClassFocus="obj_Controle_Obrigatorio_Focus"
                                                    MaxLength="150" ToolTip="Informe o nome." DataField="DescricaoNome" Label="Nome:"
                                                    Width="300px"></pro:ProTextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="linha_rotulo" style="height: 15px; width: 167px;">
                                                <pro:ProTextBox ID="txtDataNascimento" runat="server" CssClass="obj_Controle_Obrigatorio"
                                                    CssClassFocus="obj_Controle_Obrigatorio_Focus" ToolTip="Informe a data de nascimento."
                                                    DataField="DataNascimento" Label="Data de nascimento:" Width="140px" DataType="Date"></pro:ProTextBox>
                                            </td>
                                            <td class="linha_rotulo" style="height: 15px">
                                                <pro:ProDropDownList ID="ddlSexo" runat="server" CssClass="obj_Controle_Obrigatorio"
                                                    CssClassFocus="obj_Controle_Obrigatorio_Focus" ToolTip="Informe o sexo." DataField="Sexo"
                                                    Label="Sexo:" Width="150px" DataType="Number" LabelPosition="Top" DefaultText="Selecione o sexo.">
                                                </pro:ProDropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="linha_rotulo" style="height: 15px; width: 167px;">
                                                <pro:ProDropDownList ID="ddlEstadoCivil" runat="server" CssClass="obj_Controle_Obrigatorio"
                                                    CssClassFocus="obj_Controle_Obrigatorio_Focus" ToolTip="Informe o estado civil."
                                                    DataField="EstadoCivil" Label="Estado Civil:" Width="155px" DataType="Number"
                                                    LabelPosition="Top" DefaultText="Selecione o estado civil">
                                                </pro:ProDropDownList>
                                            </td>
                                            <td class="linha_rotulo" style="height: 15px">
                                                <pro:ProTextBox ID="txtDependentes" runat="server" CssClass="obj_Controle" ToolTip="Informe o número de dependentes."
                                                    DataField="Dependentes" Label="Número de dependentes:" Width="133px" DataType="Number"></pro:ProTextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="linha_rotulo" style="height: 15px" colspan="2">
                                                <pro:ProDropDownList ID="ddlGrauInstrucao" runat="server" CssClass="obj_Controle"
                                                    ToolTip="Informe o grupo de despesa." DataField="GrauInstrucao" Label="Grau de instrução:"
                                                    Width="316px" DataType="Number" LabelPosition="Top" DefaultText="Selecione o grau de instrução">
                                                </pro:ProDropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="linha_rotulo" style="height: 15px" colspan="2">
                                                <pro:ProTextBox ID="txtTelefone" runat="server" CssClass="obj_Controle" ToolTip="Informe o telefone."
                                                    DataField="Telefone" Label="Telefone:" Width="100px" DataType="Phone"></pro:ProTextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </pro:ProPanel>
                                <pro:ProPanel ID="ProPanel2" GroupingText="Documentação" runat="server" Width="656px">
                                    <table align="left" border="0" cellpadding="0" cellspacing="0" style="vertical-align: top;
                                        width: 60%; text-align: center">
                                        <tr>
                                            <td class="linha_rotulo" style="height: 15px">
                                                <pro:ProTextBox ID="txtNumIdentidade" runat="server" CssClass="obj_Controle" ToolTip="Informe a identidade."
                                                    DataField="Identidade" Label="Número Identidade:" Width="100px" MaxLength="13"></pro:ProTextBox>
                                            </td>
                                            <td class="linha_rotulo" style="height: 15px">
                                                <pro:ProTextBox ID="txtExpedidorIdentidade" runat="server" CssClass="obj_Controle"
                                                    ToolTip="Informe o orgão expedidor da identidade." DataField="IdentidadeExpedidor"
                                                    Label="Expedidor Identidade:" Width="100px" MaxLength="10"></pro:ProTextBox>
                                            </td>
                                            <td class="linha_rotulo" style="height: 15px">
                                                <pro:ProTextBox ID="txtDataExpedicao" runat="server" CssClass="obj_Controle" ToolTip="Informe a data de expedição da identidade."
                                                    DataField="DataIdentidadeExpedicao" Label="Data expedição:" Width="100px" DataType="Date"></pro:ProTextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="linha_rotulo" style="height: 15px">
                                                <pro:ProTextBox ID="txtCpf" runat="server" CssClass="obj_Controle_Obrigatorio" CssClassFocus="obj_Controle_Obrigatorio_Focus"
                                                    ToolTip="Informe o cpf." DataField="Cpf" Label="Cpf:" Width="100px" DataType="CPF"
                                                    MaxLength="14"></pro:ProTextBox>
                                            </td>
                                            <td class="linha_rotulo" style="height: 15px">
                                                <pro:ProTextBox ID="txtTituloEleitor" runat="server" CssClass="obj_Controle" ToolTip="Informe o título de eleitor."
                                                    DataField="TituloEleitor" Label="Título eleitor:" Width="100px" MaxLength="15"></pro:ProTextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="linha_rotulo" style="height: 15px">
                                                <pro:ProDropDownList ID="ddlTipoPrograma" runat="server" CssClass="obj_Controle"
                                                    ToolTip="Informe o tipo de programa." DataField="TipoPisPasep" Label="Tipo de programa:"
                                                    Width="110px" DataType="Number" LabelPosition="Top" DefaultText="Selecione o tipo de programa">
                                                </pro:ProDropDownList>
                                            </td>
                                            <td class="linha_rotulo" style="height: 15px">
                                                <pro:ProTextBox ID="txtPisPasep" runat="server" CssClass="obj_Controle" ToolTip="Informe o número do PIS ou PASEP."
                                                    DataField="PisPasep" Label="Número PIS/PASEP:" Width="100px" MaxLength="11"></pro:ProTextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </pro:ProPanel>
                                <pro:ProPanel ID="ProPanel3" GroupingText="Filiação" runat="server" Width="657px">
                                    <table align="left" border="0" cellpadding="0" cellspacing="0" style="vertical-align: top;
                                        width: 56%; text-align: center">
                                        <tr>
                                            <td class="linha_rotulo" style="height: 15px" colspan="2">
                                                <pro:ProTextBox ID="txtNomeMae" runat="server" CssClass="obj_Controle_Obrigatorio"
                                                    CssClassFocus="obj_Controle_Obrigatorio_Focus" ToolTip="Informe o nome da mãe."
                                                    DataField="NomeMae" Label="Nome Mãe:" Width="358px" MaxLength="100"></pro:ProTextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="linha_rotulo" style="height: 15px" colspan="2">
                                                <pro:ProTextBox ID="txtNomePai" runat="server" CssClass="obj_Controle" ToolTip="Informe o nome do pai."
                                                    DataField="NomePai" Label="Nome Pai:" Width="358px" MaxLength="100"></pro:ProTextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </pro:ProPanel>
                                <pro:ProPanel ID="pnlEndereco" runat="server" GroupingText="Endereço" Width="657px">
                                    <table align="center" border="0" cellpadding="0" cellspacing="0" style="vertical-align: top;
                                        width: 101%; text-align: center">
                                        <tr>
                                            <td class="linha_rotulo" style="height: 15px" colspan="2">
                                                <uc1:ucEndereco ID="ucEndereco1" runat="server" />
                                                <br />
                                            </td>
                                        </tr>
                                    </table>
                                </pro:ProPanel>
                            </pro:ProPanel>
                        </div>
                    </asp:View>
                </asp:MultiView>
            </div>
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
