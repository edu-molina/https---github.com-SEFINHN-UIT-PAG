using System.Collections.Generic;
using System.ServiceModel;

using PAG_DTO;

/// <summary>
/// SERVICIO iEGA_BENEFICIARIOS
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
        List<EGA_BENEFICIARIOS_DTO> qry_EGA_BENEFICIARIOS_listado();

        [OperationContract]
        List<EGA_BENEFICIARIOS_DTO> qry_EGA_BENEFICIARIOS_filtrado(EGA_BENEFICIARIOS_DTO precDto);

    }
}
