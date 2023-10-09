using System.Collections.Generic;
using System.ServiceModel;

using PAG_DTO;

namespace PAG_INTERFACES
{


    public partial interface iPAG_Services
    {

        [OperationContract]
        List<MONEDAS_DTO> qry_MONEDAS_listado();

        [OperationContract]
        List<MONEDAS_DTO> qry_MONEDAS_filtrado(MONEDAS_DTO precDto);
    }
}
