using System.Collections.Generic;
using System.ServiceModel;

using PAG_DTO;

/// <summary>
/// SERVICIO iDOCUMENTOS_DE_GASTOS
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
        List<DOCUMENTOS_DE_GASTOS_DTO> qry_DOCUMENTOS_DE_GASTOS_listado();

        [OperationContract]
        List<DOCUMENTOS_DE_GASTOS_DTO> qry_DOCUMENTOS_DE_GASTOS_filtrado(DOCUMENTOS_DE_GASTOS_DTO precDto);

    }
}
