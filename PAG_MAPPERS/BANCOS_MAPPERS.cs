using PAG_DA;
using PAG_DTO;

namespace PAG_MAPPERS
{
    public static class BANCOS_MAPPERS
    {
            public static BANCOS_DTO ToDto(this BANCOS entity)
            {
                BANCOS_DTO dto = new BANCOS_DTO();
                dto.BANCO = entity.BANCO;
                dto.DESC_BANCO = entity.DESC_BANCO;
                dto.API_ESTADO = entity.API_ESTADO;
            return dto;
            }

            public static BANCOS ToEntity(this BANCOS_DTO dto)
            {
                BANCOS entity = new BANCOS();
                entity.BANCO = dto.BANCO;
                entity.DESC_BANCO = dto.DESC_BANCO;
                entity.API_ESTADO = dto.API_ESTADO;
            return entity;
            }
    }
}
