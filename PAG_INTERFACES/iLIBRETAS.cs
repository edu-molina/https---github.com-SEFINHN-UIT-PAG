using System.Collections.Generic;
using System.ServiceModel;

using PAG_DTO;

namespace PAG_INTERFACES
{


    public partial interface iPAG_Services
    {

        [OperationContract]
        List<LIBRETAS_DTO> qry_LIBRETAS_listado();

        [OperationContract]
        List<LIBRETAS_DTO> qry_LIBRETAS_filtrado(LIBRETAS_DTO precDto);
    }
}
