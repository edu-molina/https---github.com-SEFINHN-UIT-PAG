using PAG_DA;
using PAG_DTO;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Clase UNIDADES_EJECUTORAS_MAPPERS
/// </summary>
/// <history>
/// FECHA               REPONSABLE              DESCRIPCION
/// 04/Abril/2017       Elia Enamorado          Creacion de Clase
/// </history>

namespace PAG_MAPPERS
{
    public static class UNIDADES_EJECUTORAS_MAPPERS
    {
        public static UNIDADES_EJECUTORAS_DTO ToDto(this UNIDADES_EJECUTORAS entity)
        {
            UNIDADES_EJECUTORAS_DTO dto = new UNIDADES_EJECUTORAS_DTO();
            dto.GESTION = entity.GESTION;
            dto.INSTITUCION = entity.INSTITUCION;
            dto.UE = entity.UE;
            dto.DESC_UE = entity.DESC_UE;
            dto.VIGENTE = entity.VIGENTE;
            dto.API_ESTADO = entity.API_ESTADO;
            return dto;
    }
        public static UNIDADES_EJECUTORAS ToEntity(this UNIDADES_EJECUTORAS_DTO dto)
        {
            UNIDADES_EJECUTORAS entity = new UNIDADES_EJECUTORAS();
            entity.GESTION = dto.GESTION;
            entity.INSTITUCION = dto.INSTITUCION;
            entity.UE = dto.UE;
            entity.DESC_UE = dto.DESC_UE;
            entity.VIGENTE = dto.VIGENTE;
            entity.API_ESTADO = dto.API_ESTADO;
            return entity;
        }
    }
}


