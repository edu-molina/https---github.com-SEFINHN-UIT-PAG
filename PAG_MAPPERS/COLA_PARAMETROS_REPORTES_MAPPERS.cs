using PAG_DA;
using PAG_DTO;


namespace PAG_MAPPERS
{
    public static class COLA_PARAMETROS_REPORTES_MAPPERS
    {
        public static COLA_PARAMETROS_REPORTES_DTO ToDto(this COLA_PARAMETROS_REPORTES entity)
        {
            COLA_PARAMETROS_REPORTES_DTO dto = new COLA_PARAMETROS_REPORTES_DTO();
            dto.ID = entity.ID;
            dto.REPORTE = entity.REPORTE;
            dto.PARAMETROS = entity.PARAMETROS;
            dto.PARAMETROS_SESION = entity.PARAMETROS_SESION;
            dto.API_ESTADO = entity.API_ESTADO;
            dto.API_TRANSACCION = entity.API_TRANSACCION;
            dto.USU_CRE = entity.USU_CRE;
            dto.FEC_CRE = entity.FEC_CRE;
            dto.USU_MOD = entity.USU_MOD;
            dto.FEC_MOD = entity.FEC_MOD;
            return dto;
        }

        public static COLA_PARAMETROS_REPORTES ToEntity(this COLA_PARAMETROS_REPORTES_DTO dto)
        {
            COLA_PARAMETROS_REPORTES entity = new COLA_PARAMETROS_REPORTES();
            entity.ID = dto.ID;
            entity.REPORTE = dto.REPORTE;
            entity.PARAMETROS = dto.PARAMETROS;
            entity.PARAMETROS_SESION = dto.PARAMETROS_SESION;
            entity.API_ESTADO = dto.API_ESTADO;
            entity.API_TRANSACCION = dto.API_TRANSACCION;
            entity.USU_CRE = dto.USU_CRE;
            entity.FEC_CRE = dto.FEC_CRE;
            entity.USU_MOD = dto.USU_MOD;
            entity.FEC_MOD = dto.FEC_MOD;
            return entity;
        }
    }
}
