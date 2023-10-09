using System.Collections.Generic;
using System.ServiceModel;

using PAG_DTO;

namespace PAG_INTERFACES
{


    public partial interface iPAG_Services
    {

        [OperationContract]
        List<BANCOS_DTO> qry_BANCOS_listado();

        [OperationContract]
        List<BANCOS_DTO> qry_BANCOS_filtrado(BANCOS_DTO precDto);
    }
}
