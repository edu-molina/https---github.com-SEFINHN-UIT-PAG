using PAG_DA;
using PAG_DTO;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Clase CG_REF_CODES_MAPPERS
/// </summary>
/// <history>
/// FECHA               REPONSABLE              DESCRIPCION
/// 04/Abril/2017       Elia Enamorado          Creacion de Clase
/// </history>

namespace PAG_MAPPERS
{
    public static class CG_REF_CODES_MAPPERS
    {
        public static CG_REF_CODES_DTO ToDto(this CG_REF_CODES entity)
        {
            CG_REF_CODES_DTO dto = new CG_REF_CODES_DTO();
            dto.RV_DOMAIN = entity.RV_DOMAIN;
            dto.RV_LOW_VALUE = entity.RV_LOW_VALUE;
            dto.RV_HIGH_VALUE = entity.RV_HIGH_VALUE;
            dto.RV_ABBREVIATION = entity.RV_ABBREVIATION;
            dto.RV_MEANING = entity.RV_MEANING;
            return dto;
        }
        public static CG_REF_CODES ToEntity(this CG_REF_CODES_DTO dto)
        {
          
            CG_REF_CODES entity = new CG_REF_CODES();
            entity.RV_DOMAIN = dto.RV_DOMAIN;
            entity.RV_LOW_VALUE = dto.RV_LOW_VALUE;
            entity.RV_HIGH_VALUE = dto.RV_HIGH_VALUE;
            entity.RV_ABBREVIATION = dto.RV_ABBREVIATION;
            entity.RV_MEANING = dto.RV_MEANING;
            return entity;

        }
    }
}