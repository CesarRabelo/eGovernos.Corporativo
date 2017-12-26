<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucMensagemConfirmacao.ascx.cs" Inherits="Platinium.Web.MsgConfirmacao.ucMensagemConfirmacao" %>
    <%--
    
    --%><script type="text/javascript">
            function ExibirMensagem(mensagem) {
                $(function () {
                    /Titulo/
                    $('#popupDiv').html(mensagem);
                    /Corpo/
                    var width = $('#popupDiv').width();
                    var height = $('#popupDiv').height();
                    leftVal = $(window).width();
                    leftVal = leftVal - (width) - 90 + 'px';
                    //topVal = $(window).height() / 2;
                    topVal = $(window).height() - 20;
                    tamBody = $(document).height();
                    topVal = tamBody - topVal - (height / 2) + 18 + 'px';

                    //topVal = topVal - (height / 2) + 'px'; { mode: "hide" },
                    $('#popupDiv').css({ left: leftVal, bottom: topVal });
                    $('#popupDiv').effect('blind', { direction: "vertical", mode: "show" }, 1500).fadeOut(4000);
                });
            }

    </script>
    <style type="text/css">
      .popup_msg{
         background: url("parts/thema2/images/ok.png") no-repeat scroll 13px 23px #ECF5FE;
    border-color: #CCCCCC;
    border-style: solid;
    border-width: 1px 2px 2px 1px;
    color: #990000;
    cursor: wait;
    display: none;
    font: 12px arial;
    height: 50px;
    padding: 24px 25px 10px 60px;
    position: absolute;
    text-align: center;
    width: 110px;
    z-index: 1000;
        }                
    </style>

        <div id="popupDiv" class="popup_msg">
            Mensagem !
        </div>
