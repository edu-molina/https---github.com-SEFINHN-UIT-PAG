using PAG_DA;
using PAG_DTO;


namespace PAG_MAPPERS
{
    public static class GERENCIAS_ADMINISTRATIVAS_MAPPERS
    {

            public static GERENCIAS_ADMINISTRATIVAS_DTO ToDto(this GERENCIAS_ADMINISTRATIVAS entity)
            {
            GERENCIAS_ADMINISTRATIVAS_DTO dto = new GERENCIAS_ADMINISTRATIVAS_DTO();
                dto.GESTION = entity.GESTION;
                dto.INSTITUCION = entity.INSTITUCION;
                dto.GA = entity.GA;
                dto.DESC_GA = entity.DESC_GA;
                dto.TIPO_GA = entity.TIPO_GA;
                dto.VIGENTE = entity.VIGENTE;
                dto.API_ESTADO = entity.API_ESTADO;
                return dto;
            }
            public static GERENCIAS_ADMINISTRATIVAS ToEntity(this GERENCIAS_ADMINISTRATIVAS_DTO dto)
            {
            GERENCIAS_ADMINISTRATIVAS entity = new GERENCIAS_ADMINISTRATIVAS();
                entity.GESTION = dto.GESTION;
                entity.INSTITUCION = dto.INSTITUCION;
                entity.GA = dto.GA;
                entity.DESC_GA = dto.DESC_GA;
                entity.TIPO_GA = dto.TIPO_GA;
                entity.VIGENTE = dto.VIGENTE;
                entity.API_ESTADO = dto.API_ESTADO;
                return entity;
            }

}
}
