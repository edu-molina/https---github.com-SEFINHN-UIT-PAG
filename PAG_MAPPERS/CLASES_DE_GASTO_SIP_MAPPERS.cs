using PAG_DA;
using PAG_DTO;

namespace PAG_MAPPERS
{
    public static class CLASES_DE_GASTO_SIP_MAPPERS
    {
        public static CLASES_DE_GASTO_SIP_DTO ToDto(this CLASES_DE_GASTO_SIP entity)
        {
            CLASES_DE_GASTO_SIP_DTO dto = new CLASES_DE_GASTO_SIP_DTO();
            dto.GESTION = entity.GESTION;
            dto.CLASE_DE_GASTO = entity.CLASE_DE_GASTO;
            dto.DESC_CLASE_DE_GASTO = entity.DESC_CLASE_DE_GASTO;
            dto.API_ESTADO = entity.API_ESTADO;
            return dto;
        }

        public static CLASES_DE_GASTO_SIP ToEntity(this CLASES_DE_GASTO_SIP_DTO dto)
        {
            CLASES_DE_GASTO_SIP entity = new CLASES_DE_GASTO_SIP();
            entity.GESTION = dto.GESTION;
            entity.CLASE_DE_GASTO = dto.CLASE_DE_GASTO;
            entity.DESC_CLASE_DE_GASTO = dto.DESC_CLASE_DE_GASTO;
            entity.API_ESTADO = dto.API_ESTADO;
            return entity;
        }
    }
}
