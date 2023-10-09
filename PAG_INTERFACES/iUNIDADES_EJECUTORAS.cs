using System.Collections.Generic;
using System.ServiceModel;

using PAG_DTO;

/// <summary>
/// SERVICIO iUNIDADES_EJECUTORAS
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
        List<UNIDADES_EJECUTORAS_DTO> qry_UNIDADES_EJECUTORAS_listado();

        [OperationContract]
        List<UNIDADES_EJECUTORAS_DTO> qry_UNIDADES_EJECUTORAS_filtrado(UNIDADES_EJECUTORAS_DTO precDto);

    }
}
