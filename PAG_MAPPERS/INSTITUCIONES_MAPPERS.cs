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
    public static class INSTITUCIONES_MAPPERS
    {
        public static INSTITUCIONES_DTO ToDto(this INSTITUCIONES entity)
        {
            INSTITUCIONES_DTO dto = new INSTITUCIONES_DTO();
            dto.INSTITUCION = entity.INSTITUCION;
            dto.DESC_INSTITUCION = entity.DESC_INSTITUCION;
            dto.VIGENTE = entity.VIGENTE;
            dto.API_ESTADO = entity.API_ESTADO;
            return dto;
    }
        public static INSTITUCIONES ToEntity(this INSTITUCIONES_DTO dto)
        {
            INSTITUCIONES entity = new INSTITUCIONES();
            entity.INSTITUCION = dto.INSTITUCION;
            entity.DESC_INSTITUCION = dto.DESC_INSTITUCION;
            entity.VIGENTE = dto.VIGENTE;
            entity.API_ESTADO = dto.API_ESTADO;
            return entity;
        }
    }
}
