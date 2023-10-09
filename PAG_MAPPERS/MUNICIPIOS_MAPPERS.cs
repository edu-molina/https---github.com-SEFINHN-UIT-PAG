
using PAG_DA;
using PAG_DTO;

namespace PAG_MAPPERS
{
    public static class MUNICIPIOS_MAPPERS
    {
        public static MUNICIPIOS_DTO ToDto(this MUNICIPIOS entity)
        {
            MUNICIPIOS_DTO dto = new MUNICIPIOS_DTO();
            dto.DEPARTAMENTO = entity.DEPARTAMENTO;
            dto.MUNICIPIO = entity.MUNICIPIO;
            dto.DESC_MUNICIPIO = entity.DESC_MUNICIPIO;
            dto.SIGLA_MUNICIPIO = entity.SIGLA_MUNICIPIO;
            dto.VIGENTE = entity.VIGENTE;
            dto.API_ESTADO = entity.API_ESTADO;
            return dto;
        }

        public static MUNICIPIOS ToEntity(this MUNICIPIOS_DTO dto)
        {
            MUNICIPIOS entity = new MUNICIPIOS();
            entity.DEPARTAMENTO = dto.DEPARTAMENTO;
            entity.MUNICIPIO = dto.MUNICIPIO;
            entity.DESC_MUNICIPIO = dto.DESC_MUNICIPIO;
            entity.SIGLA_MUNICIPIO = dto.SIGLA_MUNICIPIO;
            entity.VIGENTE = dto.VIGENTE;
            entity.API_ESTADO = dto.API_ESTADO;
            return entity;
        }
    }
}
