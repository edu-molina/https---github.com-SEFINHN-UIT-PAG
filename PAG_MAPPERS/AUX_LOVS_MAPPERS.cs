using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Agregadas por DSA

using PAG_DA;
using PAG_DTO;

namespace PAG_MAPPERS
{
    /// <summary>
    /// Clase MAPPERS para las Listas de Valores
    /// </summary>
    /// <history>
    /// FECHA              REPONSABLE            DESCRIPCION
    /// 11/Nov/2015        Danny Lainez          Creacion de Clase
    /// </history>
    public static class AUX_LOVS_MAPPERS
    {
        public static AUX_LOVS_DTO ToLovDto(this CG_REF_CODES entity)
        {
            AUX_LOVS_DTO dto = new AUX_LOVS_DTO()
            {
                LOV_NOMBRE = entity.RV_DOMAIN, 
                LOV_CODIGO = entity.RV_LOW_VALUE,
                LOV_DESCRIPCION = entity.RV_MEANING,
                LOV_VALOR_01 = entity.RV_ABBREVIATION,
            };
            return dto;
        }
        public static AUX_LOVS_DTO ToGADto(this GERENCIAS_ADMINISTRATIVAS entity)
        {
            AUX_LOVS_DTO dto = new AUX_LOVS_DTO()
            {
                LOV_NOMBRE = "GERENCIAS_ADMINISTRATIVAS",
                LOV_CODIGO = entity.GESTION.ToString()+entity.INSTITUCION.ToString()+entity.GA.ToString(),
                LOV_DESCRIPCION = entity.DESC_GA,
                LOV_VALOR_01 = entity.TIPO_GA,
                LOV_VALOR_02 = entity.ETAPA_DOCUMENTO.ToString(),
                LOV_VALOR_03 = entity.VIGENTE,
                LOV_VALOR_05 = entity.GESTION.ToString() +"."+
                               entity.INSTITUCION.ToString() + "." + 
                               entity.GA.ToString()
            };
            return dto;
        }
        public static AUX_LOVS_DTO ToINSDto(this INSTITUCIONES entity)
        {
            AUX_LOVS_DTO dto = new AUX_LOVS_DTO()
            {
                LOV_NOMBRE = "INSTITUCIONES",
                LOV_CODIGO = entity.INSTITUCION.ToString(),
                LOV_DESCRIPCION = entity.DESC_INSTITUCION,
                LOV_VALOR_01 = entity.SIGLA_INSTITUCION,
                LOV_VALOR_02 = entity.VIGENTE,
                LOV_VALOR_05 = entity.INSTITUCION.ToString()
            };
            return dto;
        }
        public static AUX_LOVS_DTO ToUEDto(this UNIDADES_EJECUTORAS entity)
        {
            AUX_LOVS_DTO dto = new AUX_LOVS_DTO()
            {
                LOV_NOMBRE = "UNIDADES_EJECUTORAS",
                LOV_CODIGO = entity.GESTION.ToString()+
                             entity.INSTITUCION.ToString() +
                             entity.UE.ToString(),
                LOV_DESCRIPCION = entity.DESC_UE,
                LOV_VALOR_01 = entity.ETAPA_DOCUMENTO.ToString(),
                LOV_VALOR_02 = entity.VIGENTE,
                LOV_VALOR_05 = entity.GESTION.ToString() + "." +
                               entity.INSTITUCION.ToString() + "." +
                               entity.UE.ToString()
            };
            return dto;
        }
        public static AUX_LOVS_DTO ToPAISDto(this PAISES entity)
        {
            AUX_LOVS_DTO dto = new AUX_LOVS_DTO()
            {
                LOV_NOMBRE = "PAISES",
                LOV_CODIGO = entity.PAIS,
                LOV_DESCRIPCION = entity.DESC_PAIS,
                LOV_VALOR_01 = entity.API_ESTADO,
                LOV_VALOR_05 = entity.PAIS
            };
            return dto;
        }
        public static AUX_LOVS_DTO ToFTEDto(this FUENTES_FINANCIAMIENTO entity)
        {
            AUX_LOVS_DTO dto = new AUX_LOVS_DTO()
            {
                LOV_NOMBRE = "FUENTES_FINANCIAMIENTO",
                LOV_CODIGO = entity.FUENTE.ToString(),
                LOV_DESCRIPCION = entity.DESC_FUENTE,
                LOV_VALOR_01 = entity.GRUPO_FUENTE.ToString(),
                LOV_VALOR_02 = entity.SUB_GRUPO_FUENTE.ToString(),
                LOV_VALOR_03 = entity.VIGENTE,
                LOV_VALOR_05 = entity.FUENTE.ToString()
            };
            return dto;
        }
        public static AUX_LOVS_DTO ToDEDDto(this DEDUCCIONES entity)
        {
            AUX_LOVS_DTO dto = new AUX_LOVS_DTO()
            {
                LOV_NOMBRE = "DEDUCCIONES",
                LOV_CODIGO = entity.DEDUCCION.ToString(),
                LOV_DESCRIPCION = entity.DESCRIPCION,
                LOV_VALOR_01 = entity.TIPO.ToString(),
                LOV_VALOR_02 = entity.SUB_TIPO.ToString(),
                LOV_VALOR_03 = entity.VIGENTE,
                LOV_VALOR_05 = entity.DEDUCCION.ToString()
            };
            return dto;
        }
        public static AUX_LOVS_DTO ToTIDDto(this BEN_TIPOS_IDENTIFICACION entity)
        {
            AUX_LOVS_DTO dto = new AUX_LOVS_DTO()
            {
                LOV_NOMBRE = "BEN_TIPOS_IDENTIFICACION",
                LOV_CODIGO = entity.TIPO_DOCUMENTO,
                LOV_DESCRIPCION = entity.DESC_TIPO_DOCUMENTO,
                LOV_VALOR_01 = entity.API_ESTADO,
                LOV_VALOR_05 = entity.TIPO_DOCUMENTO
            };
            return dto;
        }
        public static AUX_LOVS_DTO ToCGTOCDto(this CLASES_DE_GASTO_CIP entity)
        {
            AUX_LOVS_DTO dto = new AUX_LOVS_DTO()
            {
                LOV_NOMBRE = "CLASES_DE_GASTO_CIP",
                LOV_CODIGO = entity.GESTION.ToString()+entity.CLASE_DE_GASTO.ToString(),
                LOV_DESCRIPCION = entity.DESC_CLASE_DE_GASTO,
                LOV_VALOR_01 = entity.API_ESTADO,
                LOV_VALOR_05 = entity.GESTION.ToString() + "."+
                               entity.CLASE_DE_GASTO.ToString()
            };
            return dto;
        }
        public static AUX_LOVS_DTO ToCGTOSDto(this CLASES_DE_GASTO_SIP entity)
        {
            AUX_LOVS_DTO dto = new AUX_LOVS_DTO()
            {
                LOV_NOMBRE = "CLASES_DE_GASTO_SIP",
                LOV_CODIGO = entity.GESTION.ToString() + entity.CLASE_DE_GASTO.ToString(),
                LOV_DESCRIPCION = entity.DESC_CLASE_DE_GASTO,
                LOV_VALOR_01 = entity.API_ESTADO,
                LOV_VALOR_05 = entity.GESTION.ToString() + "." +
                               entity.CLASE_DE_GASTO.ToString()
            };
            return dto;
        }
        public static AUX_LOVS_DTO ToOBJDto(this OBJETOS_DEL_GASTO entity)
        {
            AUX_LOVS_DTO lovdto = new AUX_LOVS_DTO()
            {
                LOV_NOMBRE = "OBJETOS_DEL_GASTO",
                LOV_CODIGO = entity.GESTION.ToString() + entity.OBJETO.ToString(),
                LOV_DESCRIPCION = entity.DESC_OBJETO,
                LOV_VALOR_01 = entity.IMPUTABLE,
                LOV_VALOR_02 = entity.VIGENTE,
                LOV_VALOR_05 = entity.GESTION.ToString() + "." + entity.OBJETO.ToString()
            };
            return lovdto;
        }
        public static AUX_LOVS_DTO ToBENDto(this BENEFICIARIOS entity)
        {
            AUX_LOVS_DTO lovdto = new AUX_LOVS_DTO()
            {
                LOV_NOMBRE = "BENEFICIARIOS",
                LOV_CODIGO = entity.PAIS_ID + entity.TIPO_ID + entity.NRO_ID,
                LOV_DESCRIPCION = entity.NOMBRE_BENEFICIARIO,
                LOV_VALOR_01 = entity.API_ESTADO,
                LOV_VALOR_05 = entity.PAIS_ID + "." + entity.TIPO_ID + "." + entity.NRO_ID
            };
            return lovdto;
        }
        public static AUX_LOVS_DTO ToTRANSIDto(this API_TRANSICIONES entity)
        {
            AUX_LOVS_DTO dto = new AUX_LOVS_DTO()
            {
                LOV_NOMBRE = entity.TABLA,
                LOV_CODIGO = entity.ESTADO_INICIAL,
                LOV_DESCRIPCION = entity.TRANSACCION,
                LOV_VALOR_01 = entity.ESTADO_FINAL,
                LOV_VALOR_02 = entity.SENTENCIA,
            };
            return dto;
        }
    }
}
