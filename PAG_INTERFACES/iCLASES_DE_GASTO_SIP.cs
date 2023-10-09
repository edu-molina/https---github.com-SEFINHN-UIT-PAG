using System.Collections.Generic;
using System.ServiceModel;

using PAG_DTO;

namespace PAG_INTERFACES
{


    public partial interface iPAG_Services
    {

        [OperationContract]
        List<CLASES_DE_GASTO_SIP_DTO> qry_CLASES_DE_GASTO_SIP_listado();

        [OperationContract]
        List<CLASES_DE_GASTO_SIP_DTO> qry_CLASES_DE_GASTO_SIP_filtrado(CLASES_DE_GASTO_SIP_DTO precDto);

    }
}
