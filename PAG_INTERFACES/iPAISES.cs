using System.Collections.Generic;
using System.ServiceModel;

using PAG_DTO;

namespace PAG_INTERFACES
{
    public partial interface iPAG_Services
    {

        [OperationContract]
        List<PAISES_DTO> qry_PAISES_listado();

        [OperationContract]
        List<PAISES_DTO> qry_PAISES_filtrado(PAISES_DTO precDto);

    }
}
