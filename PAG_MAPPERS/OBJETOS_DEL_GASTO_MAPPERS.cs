
using PAG_DA;
using PAG_DTO;

namespace PAG_MAPPERS
{
    public static class OBJETOS_DEL_GASTO_MAPPERS
    {
        public static OBJETOS_DEL_GASTO_DTO ToDto(this OBJETOS_DEL_GASTO entity)
        {
            OBJETOS_DEL_GASTO_DTO dto = new OBJETOS_DEL_GASTO_DTO();
            dto.OBJETO = entity.OBJETO;
            dto.GRUPO_OBJETO = entity.GRUPO_OBJETO;
            dto.SUB_GRUPO_OBJETO = entity.SUB_GRUPO_OBJETO;
            dto.PARTIDA_OBJETO = entity.PARTIDA_OBJETO;
            dto.SUB_PARTIDA_OBJETO = entity.SUB_PARTIDA_OBJETO;
            dto.DESC_OBJETO = entity.DESC_OBJETO;
            dto.VIGENTE = entity.VIGENTE;
            dto.API_ESTADO = entity.API_ESTADO;
            return dto;
        }

        public static OBJETOS_DEL_GASTO ToEntity(this OBJETOS_DEL_GASTO_DTO dto)
        {
            OBJETOS_DEL_GASTO entity = new OBJETOS_DEL_GASTO();
            entity.OBJETO = dto.OBJETO;
            entity.GRUPO_OBJETO = dto.GRUPO_OBJETO;
            entity.SUB_GRUPO_OBJETO = dto.SUB_GRUPO_OBJETO;
            entity.PARTIDA_OBJETO = dto.PARTIDA_OBJETO;
            entity.SUB_PARTIDA_OBJETO = dto.SUB_PARTIDA_OBJETO;
            entity.DESC_OBJETO = dto.DESC_OBJETO;
            entity.VIGENTE = dto.VIGENTE;
            entity.API_ESTADO = dto.API_ESTADO;
            return entity;
        }
    }
}
