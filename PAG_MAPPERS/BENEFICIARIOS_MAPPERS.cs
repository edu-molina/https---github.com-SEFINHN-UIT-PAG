using PAG_DA;
using PAG_DTO;

namespace PAG_MAPPERS
{
    public static class BENEFICIARIOS_MAPPERS
    {
        public static BENEFICIARIOS_DTO ToDto(this BENEFICIARIOS entity)
        {
            BENEFICIARIOS_DTO dto = new BENEFICIARIOS_DTO();
            dto.PAIS_ID = entity.PAIS_ID;
            dto.TIPO_ID = entity.TIPO_ID;
            dto.NRO_ID = entity.NRO_ID;
            dto.DESC_OTRO_TIPO_ID = entity.DESC_OTRO_TIPO_ID;
            dto.NOMBRE_BENEFICIARIO = entity.NOMBRE_BENEFICIARIO;
            dto.TIPO_BENEFICIARIO = entity.TIPO_BENEFICIARIO;
            dto.API_ESTADO = entity.API_ESTADO;

            return dto;
        }

        public static BENEFICIARIOS ToEntity(this BENEFICIARIOS_DTO dto)
        {
            BENEFICIARIOS entity = new BENEFICIARIOS();
            entity.PAIS_ID = dto.PAIS_ID;
            entity.TIPO_ID = dto.TIPO_ID;
            entity.NRO_ID = dto.NRO_ID;
            entity.DESC_OTRO_TIPO_ID = dto.DESC_OTRO_TIPO_ID;
            entity.NOMBRE_BENEFICIARIO = dto.NOMBRE_BENEFICIARIO;
            entity.TIPO_BENEFICIARIO = dto.TIPO_BENEFICIARIO;
            entity.API_ESTADO = dto.API_ESTADO;
            return entity;
        }
    }
}

