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
        List<PRG_LIBRETAS_BOLSON_DTO> qry_PRG_LIBRETAS_BOLSON_listado();
        
        [OperationContract]
        List<PRG_LIBRETAS_BOLSON_DTO> qry_PRG_LIBRETAS_BOLSON_filtrado(PRG_LIBRETAS_BOLSON_DTO precDto);
        
        [OperationContract]
        PRG_LIBRETAS_BOLSON_DTO ins_PRG_LIBRETAS_BOLSON_inserta(PRG_LIBRETAS_BOLSON_DTO precDto);
        
        [OperationContract]
        PRG_LIBRETAS_BOLSON_DTO upd_PRG_LIBRETAS_BOLSON_actualiza(PRG_LIBRETAS_BOLSON_DTO precDto);
        
        [OperationContract]
        PRG_LIBRETAS_BOLSON_DTO del_PRG_LIBRETAS_BOLSON_elimina(params object[] pkeysDto);

        [OperationContract]
        List<PRG_LIBRETAS_BOLSON_DTO> qry_PRG_LIBRETAS_BOLSON_filtradoDocto(DLB_LIB_BOLSON_DET_DTO precDetalle);

    }
}