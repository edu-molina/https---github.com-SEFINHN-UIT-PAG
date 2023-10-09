using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ServiceModel;
using PAG_DTO;


namespace PAG_INTERFACES
{
    [ServiceContract(Namespace = "http://pagos.sefin.gob.hn")]
    public partial interface iPAG_Services
    {
        //TODO:iAUX_LOVS
        [OperationContract]
        List<AUX_LOVS_DTO> qry_AUX_LOVS_DTO_listado();

        [OperationContract]
        List<AUX_LOVS_DTO> qry_AUX_LOVS_DTO_filtrado(AUX_LOVS_DTO precLovs);

        //TODO:iAUX_MENU
        [OperationContract]
        List<AUX_MENU_DTO> qry_AUX_MENU_DTO_listado();

        [OperationContract]
        List<AUX_MENU_DTO> qry_AUX_MENU_DTO_filtrado(AUX_MENU_DTO precMenu);

        //TODO:iAPI_TRANSICIONES
        [OperationContract]
        List<AUX_LOVS_DTO> qry_API_TRANSICIONES_DTO_listado();

        [OperationContract]
        List<AUX_LOVS_DTO> qry_API_TRANSICIONES_DTO_filtrado(AUX_LOVS_DTO precLovs);
    }
}
