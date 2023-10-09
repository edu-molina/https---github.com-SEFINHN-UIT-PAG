using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Agregado por DSA

using PAG_DA;
using PAG_DTO;

namespace PAG_MAPPERS
{
    /// <summary>
    /// Clase MAPPERS para campo Clase API Cliente
    /// </summary>
    /// <history>
    /// FECHA              REPONSABLE            DESCRIPCION
    /// 26/May/2016        Danny Lainez          Creacion de Clase
    /// </history>
    public static class AUX_AUD_MAPPERS
    {
        public static AUX_AUD_DTO ToAUDDto(string Creador, DateTime? Creado, string Modificador, DateTime? Modificado)
        {
            AUX_AUD_DTO dto = new AUX_AUD_DTO()
            {
                USU_CREACION = Creador,
                FEC_CREACION = Creado,
                USU_MODIFICACION = Modificador,
                FEC_MODIFICACION = Modificado,
            };
            return dto;
        }
    }
}
