using System.Collections.Generic;
using System.ServiceModel;

using PAG_DTO;

namespace PAG_INTERFACES
{


    public partial interface iPAG_Services
    {

        [OperationContract]
        List<FUENTES_FINANCIAMIENTO_DTO> qry_FUENTES_FINANCIAMIENTO_listado();

        [OperationContract]
        List<FUENTES_FINANCIAMIENTO_DTO> qry_FUENTES_FINANCIAMIENTO_filtrado(FUENTES_FINANCIAMIENTO_DTO precDto);

    }
}
