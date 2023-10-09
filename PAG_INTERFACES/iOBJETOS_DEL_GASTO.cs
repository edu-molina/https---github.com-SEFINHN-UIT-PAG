using System.Collections.Generic;
using System.ServiceModel;

using PAG_DTO;


namespace PAG_INTERFACES
{
    public partial interface iPAG_Services
    {

        [OperationContract]
        List<OBJETOS_DEL_GASTO_DTO> qry_OBJETOS_DEL_GASTO_listado();

        [OperationContract]
        List<OBJETOS_DEL_GASTO_DTO> qry_OBJETOS_DEL_GASTO_filtrado(OBJETOS_DEL_GASTO_DTO precDto);

    }
}
