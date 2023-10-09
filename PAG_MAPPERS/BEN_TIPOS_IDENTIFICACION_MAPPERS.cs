
using PAG_DA;
using PAG_DTO;

namespace PAG_MAPPERS
{
    public static class BEN_TIPOS_IDENTIFICACION_MAPPERS
    {
        public static BEN_TIPOS_IDENTIFICACION_DTO ToDto(this BEN_TIPOS_IDENTIFICACION entity)
        {
            BEN_TIPOS_IDENTIFICACION_DTO dto = new BEN_TIPOS_IDENTIFICACION_DTO();
            dto.TIPO_DOCUMENTO = entity.TIPO_DOCUMENTO;
            dto.DESC_TIPO_DOCUMENTO = entity.DESC_TIPO_DOCUMENTO;
            dto.API_ESTADO = entity.API_ESTADO;

            return dto;
        }

        public static BEN_TIPOS_IDENTIFICACION ToEntity(this BEN_TIPOS_IDENTIFICACION_DTO dto)
        {
            BEN_TIPOS_IDENTIFICACION entity = new BEN_TIPOS_IDENTIFICACION();
            entity.TIPO_DOCUMENTO = dto.TIPO_DOCUMENTO;
            entity.DESC_TIPO_DOCUMENTO = dto.DESC_TIPO_DOCUMENTO;
            entity.API_ESTADO = dto.API_ESTADO;
            return entity;
        }
    }
}
