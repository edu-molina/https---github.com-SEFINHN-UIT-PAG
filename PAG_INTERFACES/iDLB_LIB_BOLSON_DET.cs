//------------------------------------------------------------------------------
//                         Secretaria de Finanzas
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using PAG_DTO;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;


namespace PAG_INTERFACES
{
    
    
    public partial interface iPAG_Services
    {
        
        [OperationContract]
        List<DLB_LIB_BOLSON_DET_DTO> qry_DLB_LIB_BOLSON_DET_listado();
        
        [OperationContract]
        List<DLB_LIB_BOLSON_DET_DTO> qry_DLB_LIB_BOLSON_DET_filtrado(DLB_LIB_BOLSON_DET_DTO precDto);
        
        [OperationContract]
        DLB_LIB_BOLSON_DET_DTO ins_DLB_LIB_BOLSON_DET_inserta(DLB_LIB_BOLSON_DET_DTO precDto);

        [OperationContract]
        List<DLB_LIB_BOLSON_DET_DTO> ins_DLB_LIB_BOLSON_DET_insertaArreglo(List<DLB_LIB_BOLSON_DET_DTO> precDto);

        [OperationContract]
        DLB_LIB_BOLSON_DET_DTO upd_DLB_LIB_BOLSON_DET_actualiza(DLB_LIB_BOLSON_DET_DTO precDto);
        
        [OperationContract]
        DLB_LIB_BOLSON_DET_DTO del_DLB_LIB_BOLSON_DET_elimina(params object[] pkeysDto);
        [OperationContract]
        void del_DLB_LIB_BOLSON_DET_borrar(DLB_LIB_BOLSON_DET_DTO precDto);
    }
}