using PAG_DA;
using PAG_DTO;


namespace PAG_MAPPERS
{
    public static class FUENTES_FINANCIAMIENTO_MAPPERS
    {
        public static FUENTES_FINANCIAMIENTO_DTO ToDto(this FUENTES_FINANCIAMIENTO entity)
        {
            FUENTES_FINANCIAMIENTO_DTO dto = new FUENTES_FINANCIAMIENTO_DTO();
            dto.FUENTE = entity.FUENTE;
            dto.GRUPO_FUENTE = entity.GRUPO_FUENTE;
            dto.SUB_GRUPO_FUENTE = entity.SUB_GRUPO_FUENTE;
            dto.DESC_FUENTE = entity.DESC_FUENTE;
            dto.VIGENTE = entity.VIGENTE;
            dto.API_ESTADO = entity.API_ESTADO;
            return dto;
        }
        public static FUENTES_FINANCIAMIENTO ToEntity(this FUENTES_FINANCIAMIENTO_DTO dto)
        {
            FUENTES_FINANCIAMIENTO entity = new FUENTES_FINANCIAMIENTO();
            entity.FUENTE = dto.FUENTE;
            entity.GRUPO_FUENTE = dto.GRUPO_FUENTE;
            entity.SUB_GRUPO_FUENTE = dto.SUB_GRUPO_FUENTE;
            entity.DESC_FUENTE = dto.DESC_FUENTE;
            entity.VIGENTE = dto.VIGENTE;
            entity.API_ESTADO = dto.API_ESTADO;
            return entity;
        }
    }
}
