using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Reflection;

using Pro.Utils;
using Pro.Dal;

namespace Negocio
{
    public class InicializarSistema
    {
        Dao oDao;

        public InicializarSistema()
        {
            oDao = new Dao();
            oDao.CheckAccess = false;
        }

        public bool ExistemUsuarios
        {
            get
            {
                return Convert.ToInt32(oDao.SelectSingleValue("Select count(*) from usuario")) > 0;
            }
        }

        public void CadastrarUsuarioInicial(Dictionary<string, object> valores)
		{
            try
            {
                //oDao.StartTransactionMode();
                //Usuario oUsuario = new Usuario(oDao);
                //ClassFunctions.SetProperties(oUsuario, valores);
                //oUsuario.Ativo = true;
                //oUsuario.Salvar();
                //Perfil oPerfil = new Perfil(oDao);
                //oPerfil.Nome = "Administrador";
                //oPerfil.Descricao = "Administradores do sistema";
                //oPerfil.Salvar();
                //UsuarioPerfil oUsuarioPerfil = new UsuarioPerfil(oDao);
                //oUsuarioPerfil.Perfil = oPerfil;
                //oUsuarioPerfil.Usuario = oUsuario;
                //oUsuarioPerfil.Salvar();
                //DefinirPermissoesIniciais(oPerfil);
                //oDao.Commit();
            }
            catch (Exception ex)
            {
                oDao.RollBack();
                throw ex;
            }
            
		}

        public void DefinirPermissoesIniciais()
        {
            try
            {
                //int iIdPerfil = Convert.ToInt32(oDao.SelectSingleValue("SELECT MIN(ID_PERFIL) FROM PERFIL"));
                //DefinirPermissoesIniciais(new Perfil(iIdPerfil, oDao));
            }
            catch { 
                
            }
        }

        private void CriarEnumerador(Type type)
        {
            DataTable dtb = EnumFunctions.GetValues(type);
            foreach (DataRow dtr in dtb.Rows)
            {
                DataTable dtbTemp;
                string sQuey;
                List<Parameter> parametro = new List<Parameter>();
                parametro.Add(new Parameter("ID_DOMINIO", Convert.ToInt32(dtr["ID"]), ParameterTypes.Filter));
                dtbTemp = oDao.Select(parametro, "DOMINIO", new Dictionary<string,string>());
                if (dtbTemp.Rows.Count == 0)
                {
                    sQuey = "SET IDENTITY_INSERT DOMINIO ON;INSERT INTO DOMINIO(ID_DOMINIO,CAMPO,DESCRICAO)"
                    + "SELECT " + dtr["ID"]
                    + ",'" + dtr["Tipo"] + "'"
                    + ",'" + dtr["Descricao"] + "' SET IDENTITY_INSERT DOMINIO OFF;";
                    
                }
                else
                {
                    sQuey = "UPDATE DOMINIO SET CAMPO = '" + dtr["Tipo"] + "', DESCRICAO = '" + dtr["Descricao"] + "' WHERE ID_DOMINIO = " + dtr["ID"];
                }
                
                oDao.ExecuteNonQuery(sQuey);
            }

        }
    }
}
