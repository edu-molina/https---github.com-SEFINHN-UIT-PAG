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
        List<DCO_DOCUMENTOS_DTO> qry_DCO_DOCUMENTOS_listado();
        
        [OperationContract]
        List<DCO_DOCUMENTOS_DTO> qry_DCO_DOCUMENTOS_filtrado(DCO_DOCUMENTOS_DTO precDto);
        
        [OperationContract]
        DCO_DOCUMENTOS_DTO ins_DCO_DOCUMENTOS_inserta(DCO_DOCUMENTOS_DTO precDto);
        
        [OperationContract]
        DCO_DOCUMENTOS_DTO upd_DCO_DOCUMENTOS_actualiza(DCO_DOCUMENTOS_DTO precDto);
        
        [OperationContract]
        DCO_DOCUMENTOS_DTO del_DCO_DOCUMENTOS_elimina(params object[] pkeysDto);
    }
}
