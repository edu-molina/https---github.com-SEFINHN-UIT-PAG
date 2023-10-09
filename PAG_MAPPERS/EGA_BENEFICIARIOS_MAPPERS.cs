using PAG_DA;
using PAG_DTO;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Clase EGA_BENEFICIARIOS_MAPPERS
/// </summary>
/// <history>
/// FECHA               REPONSABLE              DESCRIPCION
/// 04/Abril/2017       Elia Enamorado          Creacion de Clase
/// </history>
/// 
namespace PAG_MAPPERS
{
    public static class EGA_BENEFICIARIOS_MAPPERS
    {
        public static EGA_BENEFICIARIOS_DTO ToDto(this EGA_BENEFICIARIOS entity)
        {
            EGA_BENEFICIARIOS_DTO dto = new EGA_BENEFICIARIOS_DTO();
            dto.GESTION = entity.GESTION;
            dto.INSTITUCION = entity.INSTITUCION;
            dto.GA = entity.GA;
            dto.NRO_PRECOMPROMISO = entity.NRO_PRECOMPROMISO;
            dto.NRO_COMPROMISO = entity.NRO_COMPROMISO;
            dto.NRO_DEVENGADO = entity.NRO_DEVENGADO;
            dto.NRO_SECUENCIA = entity.NRO_SECUENCIA;
            dto.SEC_PAGO = entity.SEC_PAGO;
            dto.PAIS_ID = entity.PAIS_ID;
            dto.TIPO_ID = entity.TIPO_ID;
            dto.NRO_ID = entity.NRO_ID;
            dto.EJERCICIO = entity.EJERCICIO;
            dto.TIPOS_MOMENTOS = entity.TIPOS_MOMENTOS;
            dto.BANCO = entity.BANCO;
            dto.CUENTA = entity.CUENTA;
            dto.MONTO = entity.MONTO;
            dto.MONTO_DC = entity.MONTO_DC;
            dto.MONTO_ME = entity.MONTO_ME;
            dto.API_ESTADO = entity.API_ESTADO;
            return dto;
        }
        public static EGA_BENEFICIARIOS ToEntity(this EGA_BENEFICIARIOS_DTO dto)
        {
            EGA_BENEFICIARIOS entity = new EGA_BENEFICIARIOS();
            entity.GESTION = dto.GESTION;
            entity.INSTITUCION = dto.INSTITUCION;
            entity.GA = dto.GA;
            entity.NRO_PRECOMPROMISO = dto.NRO_PRECOMPROMISO;
            entity.NRO_COMPROMISO = dto.NRO_COMPROMISO;
            entity.NRO_DEVENGADO = dto.NRO_DEVENGADO;
            entity.NRO_SECUENCIA = dto.NRO_SECUENCIA;
            entity.SEC_PAGO = dto.SEC_PAGO;
            entity.PAIS_ID = dto.PAIS_ID;
            entity.TIPO_ID = dto.TIPO_ID;
            entity.NRO_ID = dto.NRO_ID;
            entity.EJERCICIO = dto.EJERCICIO;
            entity.TIPOS_MOMENTOS = dto.TIPOS_MOMENTOS;
            entity.BANCO = dto.BANCO;
            entity.CUENTA = dto.CUENTA;
            entity.MONTO = dto.MONTO;
            entity.MONTO_DC = dto.MONTO_DC;
            entity.MONTO_ME = dto.MONTO_ME;
            entity.API_ESTADO = dto.API_ESTADO;
            return entity;
        }
    }
}

