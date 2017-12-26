<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucMessageBox.ascx.cs" Inherits="Platinium.Web.Msg.ucMessageBox" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<script type="text/javascript">
var _source;
var _popup;
function messageBox(source, icone, botoes, titulo, mensagem, detalhes){
	this._source = source;
	document.getElementById("lblPopupTitulo").innerHTML = titulo;
	document.getElementById("lblPopupMensagem").innerHTML = mensagem;
    document.getElementById("lblPopupDetalhes").innerHTML = detalhes;            
	mostrarIcone(icone);
	manipularBotoes(botoes);
	setTimeout("ShowPopup()",100);
}
function manipularBotoes(botoes)
{
	document.getElementById("btnPopupOk").style.display = "inline";
	if(botoes == 'OK')
	{
		document.getElementById("btnPopupOk").style.display = "none";
		document.getElementById("btnPopupNo").value = "Ok";
	}
	if(botoes == 'OKCANCELAR')
	{
		document.getElementById("btnPopupOk").value = "Ok";
		document.getElementById("btnPopupNo").value = "Cancelar";
	}            
	if(botoes == 'SIMNAO')
	{
		document.getElementById("btnPopupOk").value = "Sim";
		document.getElementById("btnPopupNo").value = "Não";
	}              
}
function mostrarIcone(icone)
{
	document.getElementById('imgPopupIcone').src = "parts/Thema1/img"+icone+"MessageBox.gif";
	if(icone == 'Erro')
		document.getElementById("<%=LinkName %>").style.display = "inline";
	else
		document.getElementById("<%=LinkName %>").style.display = "none";
}
function okClick(){
    setTimeout("HidePopup()",1);
    __doPostBack(this._source.name, '');
}
function cancelClick(){
    setTimeout("HidePopup()",1);
    this._source = null;
    this._popup = null;
}
function ShowPopup()
{
	$find('mdlPopup').show();
    document.getElementById("btnPopupNo").focus();
}

function HidePopup()
{
	$find('mdlPopup').hide();
}
</script>    
<div id="div" runat="server" align="center" style="display: none;">
    <table border="0" cellpadding="0" cellspacing="0" width="400">
        <tr>
            <td height="1" style="background-image:url(parts/thema1/pixel_mensagem.gif)">
                <img alt="" height="1" src="parts/thema1/pixel_mensagem.gif"
                    width="1" /></td>
        </tr>
        <tr>
            <td valign="top">
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td style="background-image: url(parts/thema1/pixel_mensagem.gif)"
                            width="1">
                            <img alt-="" height="1" src="parts/thema1/pixel_mensagem.gif"
                                width="1" /></td>
                        <td>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td bgcolor="#e8f2f9">
                                        <div ID="lblPopupTitulo" style="height: 15px; margin: 4px; background-color:#c1d2e7; font-family: Tahoma, Arial, Verdana;font-size: 11px;color:#000000;	font-weight:bold; cursor: move;">
                                            Titulo</div>
                                    </td>
                                </tr>
                                <tr>
                                    <td bgcolor="#f1f4f8">
                                        <div style="margin: 4px">
                                            <table border="0" cellpadding="3" cellspacing="5" width="100%">
                                                <tr>
                                                    <td style="width: 50px">
                                                        <img id="imgPopupIcone" alt="" border="0" height="40" src="parts/thema1/imgAlertaMessageBox.gif"
                                                            width="40" />
                                                    </td>
                                                    <td id="Td1" align="left" style="width: 94%; font-family: Tahoma, Arial, Verdana;font-weight:normal; font-size: 11px;color:#000000;	">
                                                    <div id="lblPopupMensagem">Mensagem</div>
                                                    <div id="lblPopupDetalhes" style="font-family: Verdana, Geneva, Arial, Helvetica, sans-serif;font-size: 11px;"></div>
                                                        </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="2" style="width: 100%">
                                                        <input id="btnPopupOk" class="obj_Btn_Command" style="width: 80px" type="button"
                                                            value="Sim" />
                                                        <input id="btnPopupNo" class="obj_Btn_Command" style="width: 80px" type="button"
                                                            value="Não" />
                                                    </td>
                                                </tr>
												<tr>
													<td align="right" colspan="2" style="width: 100%; height: 1px">
														<asp:LinkButton ID="lbtReportarErro" runat="server" CssClass="link_aba" Font-Bold="True">Reportar Erro</asp:LinkButton></td>
												</tr>
												<tr>
													<td align="right" colspan="2" style="width: 100%; height: 1px">
														<asp:Panel ID="pnlMensagem" runat="server" Height="100%" Width="100%">
															<asp:TextBox ID="txtMensagem" runat="server" Rows="10" TextMode="MultiLine" Width="98%"></asp:TextBox>
															<asp:Label ID="lblAviso" runat="server" Font-Names="Arial" Font-Size="9px" Text="<b>Aviso:</b> Ao enviar este reporte, será encaminhada a mensagem acima e um arquivo contendo os últimos erros registrados no sistema para análise.<br>"
																Width="100%"></asp:Label><br />
															<br />
															<asp:Button ID="btnEnviar" runat="server" CssClass="obj_Btn_Command" OnClick="btnEnviar_Click"
																Text="Enviar" UseSubmitBehavior="False" OnClientClick='document.getElementById("<%=LinkName %>").click();' />
													    </asp:Panel>
														</td>
												</tr>
                                            </table>
                                        </div>
										</td>
                                </tr>
                            </table>
                        </td>
                        <td style="background-image: url(parts/thema1/pixel_mensagem.gif)"
                            width="4">
                            <img alt="" height="1" src="parts/thema1/pixel_mensagem.gif"
                                width="1" /></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td height="4" style="background-image: url(parts/thema1/pixel_mensagem.gif)">
                <img alt="" height="1" src="parts/thema1/pixel_mensagem.gif"
                    width="1" /></td>
        </tr>
    </table>
</div>


<cc1:modalpopupextender id="modalMessageBox" runat="server" backgroundcssclass="BackGroundPopup"
    behaviorid="mdlPopup" cancelcontrolid="btnPopupNo" okcontrolid="btnPopupOk" oncancelscript="cancelClick();"
    onokscript="okClick();" popupcontrolid="div" popupdraghandlecontrolid="lblPopupTitulo"
    targetcontrolid="div"></cc1:modalpopupextender>
<cc1:CollapsiblePanelExtender id="cpeMensagem" runat="server" CollapseControlID="lbtReportarErro" Collapsed="True" CollapsedText="Cancelar Reporte" ExpandControlID="lbtReportarErro" ExpandedText="Reportar Erro" TargetControlID="pnlMensagem" Enabled="True">
</cc1:CollapsiblePanelExtender>