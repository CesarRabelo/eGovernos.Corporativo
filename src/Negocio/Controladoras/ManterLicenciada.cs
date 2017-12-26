using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using Pro.Utils;
using Pro.Dal;
using Platinium.Entidade;
using Negocio;

namespace Platinium.Negocio
{
    public class ManterLicenciada
    {
        
        #region Variáveis e Propriedades

        private Licenciada oLicenciada;
        private Dao oDao;

        #endregion

        #region Construtores

        public ManterLicenciada()
		{
            oDao = new Dao();
		}

	    #endregion 
    
        #region Métodos

        public Dictionary<string, object> Selecionar()
        {
            oLicenciada = new Licenciada();
            //if (PossuiEndereco(oLicenciada))
            //{
            //    int idEndereco = GetEnderecoID(oLicenciada);                
            //}
            return ClassFunctions.GetProperties(oLicenciada);
        }

        public CrudActionTypes Salvar(Dictionary<string, object> valores)
        {
            try
            {
                ClassFunctions.SetProperties(oLicenciada, valores);
                return oLicenciada.Salvar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public int SalvarRetornandoId(Dictionary<string, object> valores)
        //{
        //    try
        //    {
        //        Salvar(valores);
        //        return oLicenciada.ID;
        //    }
        //    catch
        //    {
        //        oDao.RollBack();
        //        throw;
        //    }
        //}

        //public bool PossuiEndereco(Licenciada licenciada)
        //{
        //    if (licenciada.Endereco == null)
        //        return false;
        //    else
        //        return true;
        //}

        //public int GetEnderecoID(Licenciada licenciada)
        //{
        //    return licenciada.Endereco.ID;
        //}

        //public int GetEnderecoIDStatic
        //{
        //    get { return oLicenciada.Endereco.ID; }
        //}

        #endregion
    }
}
