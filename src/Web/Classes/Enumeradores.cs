using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Web
{
    public enum ModosPagina { Listar, Inserir, Atualizar }
    public enum TiposMensagem { Informacao, Erro, Alerta, Pergunta }
    public enum Botao { Clientes,ContratoAdm,ContratoLocacao,Imovel,Parcela,Condominio,Repasse,Servico,Vistoria,}
}