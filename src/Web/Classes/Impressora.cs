using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Bematech;
using Bematech.MiniImpressoras;


namespace Web.Classes
{
    public class Impressora
    {
        private bool bBematech;
        private ModeloImpressoraNaoFiscal modeloMiniImpressora;
        private ImpressoraNaoFiscal miniImpressora;

        public ModeloImpressoraNaoFiscal ModeloMiniImpressora
        {
          get {
              try
              {
                  switch (ConfigurationManager.AppSettings["ImpressoraBematechModelo"])
                  {
                      case "0":
                          modeloMiniImpressora = ModeloImpressoraNaoFiscal.MP20CI;
                          break;
                      case "1":
                          modeloMiniImpressora = ModeloImpressoraNaoFiscal.MP20MI;
                          break;
                      default:
                          modeloMiniImpressora = ModeloImpressoraNaoFiscal.MP20MI;
                          break;
                  }
                  return modeloMiniImpressora;
              }
              catch
              {
                  throw new Exception("Classe: ImpressoraBematechModelo, não definido no web.config.\nNó AppSettrings.");
              }

          }
        }

        public string Porta
        {
            get
            {
                try
                {
                    return ConfigurationManager.AppSettings["ImpressoraBematechPorta"].ToString();
                }
                catch {
                    throw new Exception("Classe: ImpressoraBematechPorta, não definido no web.config.\nNó AppSettrings.");
                }
            }
        }

        public Impressora()
        {
            try
            {
                bBematech = ConfigurationManager.AppSettings["ImpressoraBematech"].ToLower() == "true";
            }
            catch
            {
                throw new Exception("Classe: ImpressoraBematech, não definido no web.config.\nNó AppSettrings.");
            }
            miniImpressora = new ImpressoraNaoFiscal(ModeloMiniImpressora, Porta);            
        }

        public bool Autenticar(string texto)
        {
            try
            {
                //Buffer.SetByte(as,1, = (char)(27) + (char)(26) + (char)(49);
                miniImpressora.AutenticarDocumento("*" + texto + ConfigurationManager.AppSettings["ImpressoraBematechCliente"].ToString() + "#", 0);
                return true;
            }
            catch (MiniImpressoraException ex)
            {
                throw new Exception(ex.Message + 
                    "<br>Modelo: " + modeloMiniImpressora.ToString() +
                    "<br>Porta: " + Porta);
            }
        }
        public bool Imprimir(string texto)
        {
            try
            {
                miniImpressora.Imprimir("*" + texto + ConfigurationManager.AppSettings["ImpressoraBematechCliente"].ToString() + "#");
                return true;
            }
            catch (MiniImpressoraException ex)
            {
                throw new Exception(ex.Message +
                    "<br>Modelo: " + modeloMiniImpressora.ToString() +
                    "<br>Porta: " + Porta);
            }
        }

    }
}
