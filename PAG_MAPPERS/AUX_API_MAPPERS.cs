using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Agregado por DSA

using PAG_DA;
using PAG_DTO;
using System.Xml;

namespace PAG_MAPPERS
{
    /// <summary>
    /// Clase MAPPERS para campo Clase API Cliente
    /// </summary>
    /// <history>
    /// FECHA              REPONSABLE            DESCRIPCION
    /// 11/Nov/2015        Danny Lainez          Creacion de Clase
    /// </history>
    public static class AUX_API_MAPPERS
    {
        public static AUX_API_DTO ToAPIDto(string Entity)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml("<ROOT>" + Entity + "</ROOT>");
            AUX_API_DTO dto = new AUX_API_DTO()
            {
                TOKEN = (xDoc.GetElementsByTagName("TOKEN").Count > 0) ? xDoc.GetElementsByTagName("TOKEN")[0].InnerText : null,
                USUARIO = (xDoc.GetElementsByTagName("USUARIO").Count > 0) ? xDoc.GetElementsByTagName("USUARIO")[0].InnerText : null,
                NOMBRE_COMPLETO = (xDoc.GetElementsByTagName("NOMBRE_COMPLETO").Count > 0) ? xDoc.GetElementsByTagName("NOMBRE_COMPLETO")[0].InnerText : null,
                CORREO = (xDoc.GetElementsByTagName("CORREO").Count > 0) ? xDoc.GetElementsByTagName("CORREO")[0].InnerText : null,
                URL = (xDoc.GetElementsByTagName("URL").Count > 0) ? xDoc.GetElementsByTagName("URL")[0].InnerText : null,
                VERIFICADO = (xDoc.GetElementsByTagName("VERIFICADO").Count > 0) ? xDoc.GetElementsByTagName("VERIFICADO")[0].InnerText : null,
            };
            return dto;
        }
        public static string ToAPIEntity(AUX_API_DTO dto)
        {
            AUX_API_DTO apiDto = dto == null ? new AUX_API_DTO() : dto;
            string entity = "<TOKEN>" + apiDto.TOKEN + "</TOKEN>" +
                            "<USUARIO>" + apiDto.USUARIO + "</USUARIO>" +
                            "<NOMBRE_COMPLETO>" + apiDto.NOMBRE_COMPLETO + "</NOMBRE_COMPLETO>" +
                            "<CORREO>" + apiDto.CORREO + "</CORREO>" +
                            "<VERIFICADO>" + apiDto.VERIFICADO + "</VERIFICADO>";
            return entity;
        }
    }
}
