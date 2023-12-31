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

using PAG_DA;
using PAG_DTO;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PAG_MAPPERS
{
    
    
    public static class DLB_LIB_BOLSON_CAB_MAPPERS
    {
        
        public static DLB_LIB_BOLSON_CAB_DTO ToDto(this DLB_LIB_BOLSON_CAB entity)
        {
            DLB_LIB_BOLSON_CAB_DTO dto = new DLB_LIB_BOLSON_CAB_DTO();
            dto.GESTION = entity.GESTION;
            dto.INSTITUCION = entity.INSTITUCION;
            dto.GA = entity.GA;
            dto.NRO_DOCUMENTO = entity.NRO_DOCUMENTO;
            dto.DPTO_LUGAR = entity.DPTO_LUGAR;
            dto.MUN_LUGAR = entity.MUN_LUGAR;
            dto.TIPO_OPERACION = entity.TIPO_OPERACION;
            dto.USU_VERIFICACION = entity.USU_VERIFICACION;
            dto.FEC_VERIFICACION = entity.FEC_VERIFICACION;
            dto.USU_APROBACION = entity.USU_APROBACION;
            dto.FEC_APROBACION = entity.FEC_APROBACION;
            dto.API_ESTADO = entity.API_ESTADO;
            dto.API_TRANSACCION = entity.API_TRANSACCION;
            dto.USU_CRE = entity.USU_CRE;
            dto.FEC_CRE = entity.FEC_CRE;
            dto.USU_MOD = entity.USU_MOD;
            dto.FEC_MOD = entity.FEC_MOD;
            //            dto.LUGAR = entity.DPTO_LUGAR.ToString(AUX_CONST_DTO.FormatoSecuencias2) + entity.MUN_LUGAR.ToString(AUX_CONST_DTO.FormatoSecuencias2);
            dto.LUGAR = "1245";//entity.DPTO_LUGAR.ToString() + entity.MUN_LUGAR.ToString();
            return dto;
        }
        
        public static DLB_LIB_BOLSON_CAB ToEntity(this DLB_LIB_BOLSON_CAB_DTO dto)
        {
            DLB_LIB_BOLSON_CAB entity = new DLB_LIB_BOLSON_CAB();
            entity.GESTION = dto.GESTION;
            entity.INSTITUCION = dto.INSTITUCION;
            entity.GA = dto.GA;
            entity.NRO_DOCUMENTO = dto.NRO_DOCUMENTO;
            entity.DPTO_LUGAR = dto.DPTO_LUGAR;
            entity.MUN_LUGAR = dto.MUN_LUGAR;
            entity.TIPO_OPERACION = dto.TIPO_OPERACION;
            entity.USU_VERIFICACION = dto.USU_VERIFICACION;
            entity.FEC_VERIFICACION = dto.FEC_VERIFICACION;
            entity.USU_APROBACION = dto.USU_APROBACION;
            entity.FEC_APROBACION = dto.FEC_APROBACION;
            entity.API_ESTADO = dto.API_ESTADO;
            entity.API_TRANSACCION = dto.API_TRANSACCION;
            entity.USU_CRE = dto.USU_CRE;
            entity.FEC_CRE = dto.FEC_CRE;
            entity.USU_MOD = dto.USU_MOD;
            entity.FEC_MOD = dto.FEC_MOD;
            return entity;
        }

    }
}
