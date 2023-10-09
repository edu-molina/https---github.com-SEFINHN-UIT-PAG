using System.Collections.Generic;
using System.ServiceModel;

using PAG_DTO;

namespace PAG_INTERFACES
{


    public partial interface iPAG_Services
    {

        [OperationContract]
        List<LIBROS_BANCO_DTO> qry_LIBROS_BANCO_listado();

        [OperationContract]
        List<LIBROS_BANCO_DTO> qry_LIBROS_BANCO_filtrado(LIBROS_BANCO_DTO precDto);
    }
}

