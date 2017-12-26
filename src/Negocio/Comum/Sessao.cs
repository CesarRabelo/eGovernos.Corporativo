using System;
using System.Collections.Generic;
using System.Text;

namespace Platinium.Negocio
{
    public static class Sessao
    {
        public static int IdUsuario { get { return 1; } }
        public static string NomeUsuario { get { return "Administrador"; } }
        public static string EmailUsuario { get { return "cesarrabelo@gmail.com"; } }

        //public static int IdUsuario
        //{
        //    get
        //    {
        //        if (System.Web.HttpContext.Current.Session["$Sessao$"] == null)
        //            return 0;

        //        return ((SessaoUsuario)System.Web.HttpContext.Current.Session["$Sessao$"]).IdUsuario; 
        //    }
        //}

        //public static string ChaveGoogle
        //{
        //    get
        //    {
        //        if (System.Web.HttpContext.Current.Session["$ChaveGoogle$"] == null)
        //            System.Web.HttpContext.Current.Session["$ChaveGoogle$"] = Consultas.ObterChaveGoogle(System.Web.HttpContext.Current.Request.Url.AbsoluteUri.Substring(0, System.Web.HttpContext.Current.Request.Url.AbsoluteUri.IndexOf("/", 10) + 1));
                    
        //        return System.Web.HttpContext.Current.Session["$ChaveGoogle$"].ToString();
        //    }
        //}

        //public static string NomeUsuario
        //{
        //    get 
        //    {
        //        if (System.Web.HttpContext.Current.Session["$Sessao$"] == null)
        //            return string.Empty;

        //        return ((SessaoUsuario)System.Web.HttpContext.Current.Session["$Sessao$"]).NomeUsuario; 
        //    }
        //}

        //public static string EmailUsuario
        //{
        //    get
        //    {
        //        if (System.Web.HttpContext.Current.Session["$Sessao$"] == null)
        //            return string.Empty;

        //        return ((SessaoUsuario)System.Web.HttpContext.Current.Session["$Sessao$"]).EmailUsuario;
        //    }
        //}

        public static void LogOff()
        {
            System.Web.HttpContext.Current.Session.Abandon();
        }

        public static bool FiltroAtivo
        {
            get
            {
                if (System.Web.HttpContext.Current.Session["$FiltroAtivo$"] == null)
                    return true;
                else
                    return (bool)System.Web.HttpContext.Current.Session["$FiltroAtivo$"];
            }
            set { System.Web.HttpContext.Current.Session["$FiltroAtivo$"] = value; }
        }

        public static bool FiltroInativo
        {
            get
            {
                if (System.Web.HttpContext.Current.Session["$FiltroInativo$"] == null)
                    return false;
                else
                    return (bool)System.Web.HttpContext.Current.Session["$FiltroInativo$"];
            }
            set { System.Web.HttpContext.Current.Session["$FiltroInativo$"] = value; }
        }
    }
}
