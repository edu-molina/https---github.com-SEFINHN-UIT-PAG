using System.Collections.Generic;
using System.ServiceModel;

using PAG_DTO;

namespace PAG_INTERFACES
{


    public partial interface iPAG_Services
    {

        [OperationContract]
        List<DEDUCCIONES_DTO> qry_DEDUCCIONES_listado();

        [OperationContract]
        List<DEDUCCIONES_DTO> qry_DEDUCCIONES_filtrado(DEDUCCIONES_DTO precDto);

    }
}
