using PAG_DA;
using PAG_DTO;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Clase DOCUMENTOS_DE_GASTOS_MAPPERS
/// </summary>
/// <history>
/// FECHA               REPONSABLE              DESCRIPCION
/// 04/Abril/2017       Elia Enamorado          Creacion de Clase
/// </history>
/// 
namespace PAG_MAPPERS
{
    public static class DOCUMENTOS_DE_GASTOS_MAPPERS
    {
        public static DOCUMENTOS_DE_GASTOS_DTO ToDto(this DOCUMENTOS_DE_GASTOS entity)
        {
            DOCUMENTOS_DE_GASTOS_DTO dto = new DOCUMENTOS_DE_GASTOS_DTO();
            dto.GESTION = entity.GESTION;
            dto.INSTITUCION = entity.INSTITUCION;
            dto.GA = entity.GA;
            dto.NRO_PRECOMPROMISO = entity.NRO_PRECOMPROMISO;
            dto.NRO_COMPROMISO = entity.NRO_COMPROMISO;
            dto.NRO_DEVENGADO = entity.NRO_DEVENGADO;
            dto.NRO_SECUENCIA = entity.NRO_SECUENCIA;
            dto.NRO_DEVENGADO_SIP = entity.NRO_DEVENGADO_SIP;
            dto.UE = entity.UE;
            dto.TIPO_FORMULARIO = entity.TIPO_FORMULARIO;
            dto.TIPO_DOCUMENTO = entity.TIPO_DOCUMENTO;
            dto.EJERCICIO = entity.EJERCICIO;
            dto.LUGAR_DEP = entity.LUGAR_DEP;
            dto.LUGAR_MUN = entity.LUGAR_MUN;
            dto.APLICACION = entity.APLICACION;
            dto.FUENTE = entity.FUENTE;
            dto.ORGANISMO = entity.ORGANISMO;
            dto.BIP = entity.BIP;
            dto.CONVENIO = entity.CONVENIO;
            dto.SIGADE = entity.SIGADE;
            dto.TRAMO = entity.TRAMO;
            dto.API_ESTADO = entity.API_ESTADO;
            return dto;
            
    }
    public static DOCUMENTOS_DE_GASTOS ToEntity(this DOCUMENTOS_DE_GASTOS_DTO dto)
        {
            DOCUMENTOS_DE_GASTOS entity = new DOCUMENTOS_DE_GASTOS();
            entity.GESTION = dto.GESTION;
            entity.INSTITUCION = dto.INSTITUCION;
            entity.GA = dto.GA;
            entity.NRO_PRECOMPROMISO = dto.NRO_PRECOMPROMISO;
            entity.NRO_COMPROMISO = dto.NRO_COMPROMISO;
            entity.NRO_DEVENGADO = dto.NRO_DEVENGADO;
            entity.NRO_SECUENCIA = dto.NRO_SECUENCIA;
            entity.NRO_DEVENGADO_SIP = dto.NRO_DEVENGADO_SIP;
            entity.UE = dto.UE;
            entity.TIPO_FORMULARIO = dto.TIPO_FORMULARIO;
            entity.TIPO_DOCUMENTO = dto.TIPO_DOCUMENTO;
            entity.EJERCICIO = dto.EJERCICIO;
            entity.LUGAR_DEP = dto.LUGAR_DEP;
            entity.LUGAR_MUN = dto.LUGAR_MUN;
            entity.APLICACION = dto.APLICACION;
            entity.FUENTE = dto.FUENTE;
            entity.ORGANISMO = dto.ORGANISMO;
            entity.BIP = dto.BIP;
            entity.CONVENIO = dto.CONVENIO;
            entity.SIGADE = dto.SIGADE;
            entity.TRAMO = dto.TRAMO;
            entity.API_ESTADO = dto.API_ESTADO;
            return entity;
        }
    }
}
