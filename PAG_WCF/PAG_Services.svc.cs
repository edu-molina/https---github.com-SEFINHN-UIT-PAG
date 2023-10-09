using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using PAG_DTO;
using PAG_INTERFACES;
using Sefin.Security.Wcf;
using Sefin.Security;

namespace PAG_WCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "PAG_Services" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione PAG_Services.svc o PAG_Services.svc.cs en el Explorador de soluciones e inicie la depuración.
    public partial class PAG_Services : iPAG_Services
    {
        private readonly ReaderHeader _readerHeader = new ReaderHeader(DefaultClaimHeader.Name, DefaultClaimHeader.Namespace);
        public PAG_Services()
        {
            ////Autorizacion
            //var action = OperationContext.Current.IncomingMessageHeaders.Action;
            //var operationName = action.Substring(action.LastIndexOf("/", StringComparison.OrdinalIgnoreCase) + 1);
        }

        //TODO:iAUX_LOVS-SVC
        public List<AUX_LOVS_DTO> qry_AUX_LOVS_DTO_listado()
        {
            //Autorizacion
            //PAG_ServicesUtil.AutorizadoMetodoUsuario(pMetodo: (new StackTrace().GetFrame(0).GetMethod()).Name.ToUpper());
            //Transacciones
            return new RDN_API_LISTA_VALORES().AUX_LOVS_listado();
        }

        public List<AUX_LOVS_DTO> qry_AUX_LOVS_DTO_filtrado(AUX_LOVS_DTO precLovs)
        {
            //Autorizacion
            //PAG_ServicesUtil.AutorizadoMetodoUsuario(pMetodo: (new StackTrace().GetFrame(0).GetMethod()).Name.ToUpper());
            //Transacciones
            return new RDN_API_LISTA_VALORES().AUX_LOVS_filtrado(precLovs: precLovs);
        }

        //TODO:iAUX_MENU-SVC
        public List<AUX_MENU_DTO> qry_AUX_MENU_DTO_listado()
        {
            //Autorizacion
            //PAG_ServicesUtil.AutorizadoMetodoUsuario(pMetodo: (new StackTrace().GetFrame(0).GetMethod()).Name.ToUpper());
            //Transacciones
            return new RDN_API_SEGURIDAD().AUX_SAS_MENU_DTO_listado();
        }

        public List<AUX_MENU_DTO> qry_AUX_MENU_DTO_filtrado(AUX_MENU_DTO precMenu)
        {
            //Autorizacion
            //PAG_ServicesUtil.AutorizadoMetodoUsuario(pMetodo: (new StackTrace().GetFrame(0).GetMethod()).Name.ToUpper());
            //Transacciones
            return new RDN_API_SEGURIDAD().AUX_SAS_MENU_DTO_filtrado(precMenu: precMenu);
        }

        //TODO:iAPI_TRANSICIONES-SVC
        public List<AUX_LOVS_DTO> qry_API_TRANSICIONES_DTO_listado()
        {
            //Autorizacion
            //PAG_ServicesUtil.AutorizadoMetodoUsuario(pMetodo: (new StackTrace().GetFrame(0).GetMethod()).Name.ToUpper());
            //Transacciones
            return new RDN_API_TRANSICIONES().API_TRANSICIONES_listado();
        }

        public List<AUX_LOVS_DTO> qry_API_TRANSICIONES_DTO_filtrado(AUX_LOVS_DTO precLovs)
        {
            //Autorizacion
            //PAG_ServicesUtil.AutorizadoMetodoUsuario(pMetodo: (new StackTrace().GetFrame(0).GetMethod()).Name.ToUpper());
            //Transacciones
            return new RDN_API_TRANSICIONES().API_TRANSICIONES_filtrado(precLovs: precLovs);
        }
    }
}
