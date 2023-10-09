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
    
    
    public static class DCO_DOCUMENTOS_COLUMNAS_MAPPERS
    {
        
        public static DCO_DOCUMENTOS_COLUMNAS_DTO ToDto(this DCO_DOCUMENTOS_COLUMNAS entity)
        {
            DCO_DOCUMENTOS_COLUMNAS_DTO dto = new DCO_DOCUMENTOS_COLUMNAS_DTO();
            dto.ID_DOCUMENTO = entity.ID_DOCUMENTO;
            dto.ID_COLUMNA = entity.ID_COLUMNA;
            dto.ESPECIAL = entity.ESPECIAL;
            dto.API_ESTADO = entity.API_ESTADO;
            dto.API_TRANSACCION = entity.API_TRANSACCION;
            dto.USU_CRE = entity.USU_CRE;
            dto.FEC_CRE = entity.FEC_CRE;
            dto.USU_MOD = entity.USU_MOD;
            dto.FEC_MOD = entity.FEC_MOD;
            return dto;
        }
        
        public static DCO_DOCUMENTOS_COLUMNAS ToEntity(this DCO_DOCUMENTOS_COLUMNAS_DTO dto)
        {
            DCO_DOCUMENTOS_COLUMNAS entity = new DCO_DOCUMENTOS_COLUMNAS();
            entity.ID_DOCUMENTO = dto.ID_DOCUMENTO;
            entity.ID_COLUMNA = dto.ID_COLUMNA;
            entity.ESPECIAL = dto.ESPECIAL;
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
