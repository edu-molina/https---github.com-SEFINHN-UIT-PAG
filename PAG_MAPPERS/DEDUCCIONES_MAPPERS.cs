using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PAG_DA;
using PAG_DTO;

namespace PAG_MAPPERS
{
    public static class DEDUCCIONES_MAPPERS
    {
        public static DEDUCCIONES_DTO ToDto(this DEDUCCIONES entity)
        {
            DEDUCCIONES_DTO dto = new DEDUCCIONES_DTO();
            dto.DEDUCCION = entity.DEDUCCION;
            dto.TIPO = entity.TIPO;
            dto.SUB_TIPO = entity.SUB_TIPO;
            dto.DESCRIPCION = entity.DESCRIPCION;
            dto.API_ESTADO = entity.API_ESTADO;
            return dto;
        }

        public static DEDUCCIONES ToEntity(this DEDUCCIONES_DTO dto)
        {
            DEDUCCIONES entity = new DEDUCCIONES();
            entity.DEDUCCION = dto.DEDUCCION;
            entity.TIPO = dto.TIPO;
            entity.SUB_TIPO = dto.SUB_TIPO;
            entity.DESCRIPCION = dto.DESCRIPCION;
            entity.API_ESTADO = dto.API_ESTADO;
            return entity;
        }
    }
}

