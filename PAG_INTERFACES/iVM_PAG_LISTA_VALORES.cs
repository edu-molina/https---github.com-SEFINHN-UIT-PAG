using System.Collections.Generic;
using System.ServiceModel;
using PAG_DTO;

namespace PAG_INTERFACES
{
    public partial interface iPAG_Services
    {

        [OperationContract]
        List<VM_PAG_LISTA_VALORES_DTO> qry_VM_PAG_LISTA_VALORES_listado();

        [OperationContract]
        List<VM_PAG_LISTA_VALORES_DTO> qry_VM_PAG_LISTA_VALORES_filtrado(VM_PAG_LISTA_VALORES_DTO precDto);
        [OperationContract]
        List<VM_PAG_LISTA_VALORES_DTO> qry_VM_PAG_LISTA_VALORES_filtradoDocto(DTP_DETALLES_DET_DTO precDetalle);
    }
}
