using PAG_DA;
using PAG_DTO;

namespace PAG_MAPPERS
{
    public static class EGA_PARTIDAS_MAPPERS
    {
        public static EGA_PARTIDAS_DTO ToDto(this EGA_PARTIDAS entity)
        {
            EGA_PARTIDAS_DTO dto = new EGA_PARTIDAS_DTO();
            dto.GESTION = entity.GESTION;
            dto.INSTITUCION = entity.INSTITUCION;
            dto.GA = entity.GA;
            dto.NRO_PRECOMPROMISO = entity.NRO_PRECOMPROMISO;
            dto.NRO_COMPROMISO = entity.NRO_COMPROMISO;
            dto.NRO_DEVENGADO = entity.NRO_DEVENGADO;
            dto.NRO_SECUENCIA = entity.NRO_SECUENCIA;
            dto.SEC_PAGO = entity.SEC_PAGO;
            dto.UE = entity.UE;
            dto.PROGRAMA = entity.PROGRAMA;
            dto.SUB_PROGRAMA = entity.SUB_PROGRAMA;
            dto.PROYECTO = entity.PROYECTO;
            dto.ACTIVIDAD_OBRA = entity.ACTIVIDAD_OBRA;
            dto.FUENTE = entity.FUENTE;
            dto.ORGANISMO = entity.ORGANISMO;
            dto.OBJETO = entity.OBJETO;
            dto.TRF_BENEFICIARIO = entity.TRF_BENEFICIARIO;
            dto.API_ESTADO = entity.API_ESTADO;
            return dto;
        }

        public static EGA_PARTIDAS ToEntity(this EGA_PARTIDAS_DTO dto)
        {
            EGA_PARTIDAS entity = new EGA_PARTIDAS();
            entity.GESTION = dto.GESTION;
            entity.INSTITUCION = dto.INSTITUCION;
            entity.GA = dto.GA;
            entity.NRO_PRECOMPROMISO = dto.NRO_PRECOMPROMISO;
            entity.NRO_COMPROMISO = dto.NRO_COMPROMISO;
            entity.NRO_DEVENGADO = dto.NRO_DEVENGADO;
            entity.NRO_SECUENCIA = dto.NRO_SECUENCIA;
            entity.SEC_PAGO = dto.SEC_PAGO;
            entity.UE = dto.UE;
            entity.PROGRAMA = dto.PROGRAMA;
            entity.SUB_PROGRAMA = dto.SUB_PROGRAMA;
            entity.PROYECTO = dto.PROYECTO;
            entity.ACTIVIDAD_OBRA = dto.ACTIVIDAD_OBRA;
            entity.FUENTE = dto.FUENTE;
            entity.ORGANISMO = dto.ORGANISMO;
            entity.OBJETO = dto.OBJETO;
            entity.TRF_BENEFICIARIO = dto.TRF_BENEFICIARIO;
            entity.API_ESTADO = dto.API_ESTADO;
            return entity;
        }
    }
}
