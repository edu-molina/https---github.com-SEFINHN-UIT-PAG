
using PAG_DA;
using PAG_DTO;

namespace PAG_MAPPERS
{
    public static class PAISES_MAPPERS
    {
        public static PAISES_DTO ToDto(this PAISES entity)
        {
            PAISES_DTO dto = new PAISES_DTO();
            dto.PAIS = entity.PAIS;
            dto.DESC_PAIS = entity.DESC_PAIS;
            dto.API_ESTADO = entity.API_ESTADO;
            return dto;
        }

        public static PAISES ToEntity(this PAISES_DTO dto)
        {
            PAISES entity = new PAISES();
            entity.PAIS = dto.PAIS;
            entity.DESC_PAIS = dto.DESC_PAIS;
            entity.API_ESTADO = dto.API_ESTADO;
            return entity;
        }
    }
}
