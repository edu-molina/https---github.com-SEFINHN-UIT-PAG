using System.Collections.Generic;
using System.ServiceModel;

using PAG_DTO;

namespace PAG_INTERFACES
{
    
    
    public partial interface iPAG_Services
    {
        
        [OperationContract]
        List<INSTITUCIONES_DTO> qry_INSTITUCIONES_listado();
        
        [OperationContract]
        List<INSTITUCIONES_DTO> qry_INSTITUCIONES_filtrado(INSTITUCIONES_DTO precDto);
        
    }
}
