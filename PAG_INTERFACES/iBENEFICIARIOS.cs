using System.Collections.Generic;
using System.ServiceModel;

using PAG_DTO;

namespace PAG_INTERFACES
{


    public partial interface iPAG_Services
    {

        [OperationContract]
        List<BENEFICIARIOS_DTO> qry_BENEFICIARIOS_listado();

        [OperationContract]
        List<BENEFICIARIOS_DTO> qry_BENEFICIARIOS_filtrado(BENEFICIARIOS_DTO precDto);
    }
}
