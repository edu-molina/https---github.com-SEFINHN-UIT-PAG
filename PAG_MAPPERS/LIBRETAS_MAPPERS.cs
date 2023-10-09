using PAG_DA;
using PAG_DTO;

namespace PAG_MAPPERS
{
    public static class LIBRETAS_MAPPERS
    {
        public static LIBRETAS_DTO ToDto(this LIBRETAS entity)
        {
            LIBRETAS_DTO dto = new LIBRETAS_DTO();
            dto.GESTION= entity.GESTION;
            dto.BANCO = entity.BANCO;
            dto.CUENTA = entity.CUENTA;
            dto.LIBRETA = entity.LIBRETA;
            dto.DESC_LIBRETA = entity.DESC_LIBRETA;
            dto.API_ESTADO = entity.API_ESTADO;
            return dto;
        }

        public static LIBRETAS ToEntity(this LIBRETAS_DTO dto)
        {
            LIBRETAS entity = new LIBRETAS();
            entity.GESTION = dto.GESTION;
            entity.BANCO = dto.BANCO;
            entity.CUENTA = dto.CUENTA;
            entity.LIBRETA = dto.LIBRETA;
            entity.DESC_LIBRETA = dto.DESC_LIBRETA;
            entity.API_ESTADO = dto.API_ESTADO;
            return entity;
        }
    }
}
