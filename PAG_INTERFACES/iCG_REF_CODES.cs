using System.Collections.Generic;
using System.ServiceModel;

using PAG_DTO;

/// <summary>
/// SERVICIO iCG_REF_CODES
/// </summary>
/// <history>
/// FECHA               REPONSABLE              DESCRIPCION
/// 03/Abril/2017       Elia Enamorado          Creacion de Interfaz
/// </history>
/// 
namespace PAG_INTERFACES
{
    public partial interface iPAG_Services
    {

        [OperationContract]
        List<CG_REF_CODES_DTO> qry_CG_REF_CODES_listado();

        [OperationContract]
        List<CG_REF_CODES_DTO> qry_CG_REF_CODES_filtrado(CG_REF_CODES_DTO precDto);

    }
}
