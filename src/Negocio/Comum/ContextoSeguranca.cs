using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Atom.Client.Classes;

namespace Platinium.Negocio
{
    public class ContextoSeguranca
    {

        #region Variáveis e propriedades

        Sistema oSistema;

        public int UsuarioID
        {
            get { return oSistema.UsuarioAtom.Id; }
        }
        public string UsuarioNome
        {
            get { return oSistema.UsuarioAtom.Nome; }
        }
        public string GrupoNome
        {
            get { return oSistema.Grupo.Nome; }
        }

        public string PaginaSemAcesso
        { get { return oSistema.PaginaSemAcesso; } }

        #endregion

        #region Construtor
        public ContextoSeguranca(Sistema sistema)
        {
            oSistema = sistema;
        }
        #endregion

        #region Métodos
        public bool Ler(string objeto)
        {
            try
            {
                return oSistema.Grupo.Objeto(objeto).Ler;
            }
            catch { return false; }
        }
        public bool Inserir(string objeto)
        {
            try
            {
                return oSistema.Grupo.Objeto(objeto).Inserir;
            }
            catch { return false; }
        }
        public bool Atualizar(string objeto)
        {
            try
            {
                return oSistema.Grupo.Objeto(objeto).Atualizar;
            }
            catch { return false; }
        }
        public bool Deletar(string objeto)
        {
            try
            {
                return oSistema.Grupo.Objeto(objeto).Deletar;
            }
            catch { return false; }
        }
        public string Parametro(string parametro)
        {
            return oSistema.Grupo.Parametro(parametro);
        }
        #endregion
    }

}
