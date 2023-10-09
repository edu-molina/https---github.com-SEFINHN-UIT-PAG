using System.Collections.Generic;
using System.ServiceModel;

using PAG_DTO;

namespace PAG_INTERFACES
{
    public partial interface iPAG_Services
    {

        [OperationContract]
        List<MUNICIPIOS_DTO> qry_MUNICIPIOS_listado();

        [OperationContract]
        List<MUNICIPIOS_DTO> qry_MUNICIPIOS_filtrado(MUNICIPIOS_DTO precDto);

    }
}
