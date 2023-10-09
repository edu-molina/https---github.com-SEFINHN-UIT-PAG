using PAG_DA;
using PAG_DTO;

namespace PAG_MAPPERS
{
    public static class MONEDAS_MAPPERS
    {
        public static MONEDAS_DTO ToDto(this MONEDAS entity)
        {
            MONEDAS_DTO dto = new MONEDAS_DTO();
            dto.MONEDA = entity.MONEDA;
            dto.DESC_MONEDA = entity.DESC_MONEDA;
            dto.API_ESTADO = entity.API_ESTADO;
            return dto;
        }

        public static MONEDAS ToEntity(this MONEDAS_DTO dto)
        {
            MONEDAS entity = new MONEDAS();
            entity.MONEDA = dto.MONEDA;
            entity.DESC_MONEDA = dto.DESC_MONEDA;
            entity.API_ESTADO = dto.API_ESTADO;
            return entity;
        }
    }
}
