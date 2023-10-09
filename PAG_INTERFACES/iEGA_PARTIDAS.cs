using System.Collections.Generic;
using System.ServiceModel;

using PAG_DTO;


namespace PAG_INTERFACES
{
    public partial interface iPAG_Services
    {

        [OperationContract]
        List<EGA_PARTIDAS_DTO> qry_EGA_PARTIDAS_listado();

        [OperationContract]
        List<EGA_PARTIDAS_DTO> qry_EGA_PARTIDAS_filtrado(EGA_PARTIDAS_DTO precDto);
    }
}
