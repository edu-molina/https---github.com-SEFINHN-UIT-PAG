using System.Collections.Generic;
using System.ServiceModel;

using PAG_DTO;

namespace PAG_INTERFACES
{


    public partial interface iPAG_Services
    {

        [OperationContract]
        List<GERENCIAS_ADMINISTRATIVAS_DTO> qry_GERENCIAS_ADMINISTRATIVAS_listado();

        [OperationContract]
        List<GERENCIAS_ADMINISTRATIVAS_DTO> qry_GERENCIAS_ADMINISTRATIVAS_filtrado(GERENCIAS_ADMINISTRATIVAS_DTO precDto);

    }
}
