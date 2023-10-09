using PAG_DA;
using PAG_DTO;

namespace PAG_MAPPERS
{
    public static class LIBROS_BANCO_MAPPERS
    {
        public static LIBROS_BANCO_DTO ToDto(this LIBROS_BANCO entity)
        {
            LIBROS_BANCO_DTO dto = new LIBROS_BANCO_DTO();
            dto.GESTION = entity.GESTION;
            dto.BANCO = entity.BANCO;
            dto.CUENTA = entity.CUENTA;
            dto.MONEDA = entity.MONEDA;
            dto.UTILIZA_LIBRETAS = entity.UTILIZA_LIBRETAS;
            dto.API_ESTADO = entity.API_ESTADO;
            return dto;
        }

        public static LIBROS_BANCO ToEntity(this LIBROS_BANCO_DTO dto)
        {
            LIBROS_BANCO entity = new LIBROS_BANCO();
            entity.GESTION = dto.GESTION;
            entity.BANCO = dto.BANCO;
            entity.CUENTA = dto.CUENTA;
            entity.MONEDA = dto.MONEDA;
            entity.UTILIZA_LIBRETAS = dto.UTILIZA_LIBRETAS;
            entity.API_ESTADO = dto.API_ESTADO;
            return entity;
        }
    }
}
