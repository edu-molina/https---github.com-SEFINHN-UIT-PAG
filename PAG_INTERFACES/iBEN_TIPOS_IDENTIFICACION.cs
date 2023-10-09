using System.Collections.Generic;
using System.ServiceModel;

using PAG_DTO;

namespace PAG_INTERFACES
{


    public partial interface iPAG_Services
    {

        [OperationContract]
        List<BEN_TIPOS_IDENTIFICACION_DTO> qry_BEN_TIPOS_IDENTIFICACION_listado();

        [OperationContract]
        List<BEN_TIPOS_IDENTIFICACION_DTO> qry_BEN_TIPOS_IDENTIFICACION_filtrado(BEN_TIPOS_IDENTIFICACION_DTO precDto);
    }
}
