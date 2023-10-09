using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Agregadas por DSA

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PAG_DTO
{
    /// <summary>
    /// Clase DTO de la columna API_CLIENTE
    /// </summary>
    /// <history>
    /// FECHA               REPONSABLE              DESCRIPCION
    /// 26/May/2016         Danny Lainez            Creacion de Clase
    /// </history>
    public class AUX_AUD_DTO
    {
        public AUX_AUD_DTO() 
        {
        }

        [DisplayName("Usuario Creación")]//, MaxLength(30), ReadOnly(true)]
        public string USU_CREACION { get; set; }

        [DisplayName("Fecha Creación")]//, ReadOnly(true)]
        public DateTime? FEC_CREACION { get; set; }

        [DisplayName("Usuario Modificación")]//, MaxLength(30), ReadOnly(true)]
        public string USU_MODIFICACION { get; set; }

        [DisplayName("Fecha Modificación")]//, ReadOnly(true)]
        public DateTime? FEC_MODIFICACION { get; set; }
    }
}
