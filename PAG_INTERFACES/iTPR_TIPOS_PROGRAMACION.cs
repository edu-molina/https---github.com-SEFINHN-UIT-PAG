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
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;


namespace PAG_INTERFACES
{
    
    
    public partial interface iPAG_Services
    {
        
        [OperationContract]
        List<TPR_TIPOS_PROGRAMACION_DTO> qry_TPR_TIPOS_PROGRAMACION_listado();
        
        [OperationContract]
        List<TPR_TIPOS_PROGRAMACION_DTO> qry_TPR_TIPOS_PROGRAMACION_filtrado(TPR_TIPOS_PROGRAMACION_DTO precDto);
        
        [OperationContract]
        TPR_TIPOS_PROGRAMACION_DTO ins_TPR_TIPOS_PROGRAMACION_inserta(TPR_TIPOS_PROGRAMACION_DTO precDto);
        
        [OperationContract]
        TPR_TIPOS_PROGRAMACION_DTO upd_TPR_TIPOS_PROGRAMACION_actualiza(TPR_TIPOS_PROGRAMACION_DTO precDto);
        
        [OperationContract]
        TPR_TIPOS_PROGRAMACION_DTO del_TPR_TIPOS_PROGRAMACION_elimina(params object[] pkeysDto);

        [OperationContract]
        List<TPR_TIPOS_PROGRAMACION_DTO> qry_TPR_TIPOS_PROGRAMACION_filtradoDocto(DTP_TIPOS_PROGRA_DET_DTO precTiposProgram);

    }
}
