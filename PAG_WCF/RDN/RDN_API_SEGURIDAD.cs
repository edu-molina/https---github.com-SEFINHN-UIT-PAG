using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//Agregado por DSA

using PAG_DA;
using PAG_DTO;
using PAG_MAPPERS;
using PAG_INTERFACES;
using System.Reflection;
using System.Data;
using System.Transactions;
using System.ServiceModel;

namespace PAG_WCF
{
    #region SVC-API_SEGURIDAD

    #endregion

    #region RDN-API_SEGURIDAD
    public class RDN_API_SEGURIDAD
    {
        public List<AUX_MENU_DTO> AUX_SAS_MENU_DTO_listado() 
        {
            List<SAS_DTO.SAS_MENUS_DTO> lsMenuSAS = PAG_Seguridad.MenuListado();
            //Colocar Ciclo Para Mappear a DTO PAG
            return new List<AUX_MENU_DTO>();
        }

        public List<AUX_MENU_DTO> AUX_SAS_MENU_DTO_filtrado(AUX_MENU_DTO precMenu)
        {
            SAS_DTO.SAS_MENUS_DTO precMenuSAS = new SAS_DTO.SAS_MENUS_DTO();
            //Crear SAS_DTO precMenu
            List<SAS_DTO.SAS_MENUS_DTO> lsMenuSAS = PAG_Seguridad.MenuFiltrado(precMenu: precMenuSAS);
            //Colocar Ciclo Para Mappear a DTO PAG
            return new List<AUX_MENU_DTO>();
        }
    }
    #endregion

}