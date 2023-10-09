using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// Clase CG_REF_CODES_DTO
/// </summary>
/// <history>
/// FECHA               REPONSABLE              DESCRIPCION
/// 03/Abril/2017       Elia Enamorado          Creacion de Clase
/// </history>

namespace PAG_DTO
{
    public class CG_REF_CODES_DTO
    {
        [DisplayName("RV_Domain")]//, MaxLength(30), ReadOnly(true)]
        public string RV_DOMAIN { get; set; }

        [DisplayName("RV_Low_Value")]//, MaxLength(30), ReadOnly(true)]
        public string RV_LOW_VALUE { get; set; }

        [DisplayName("RV_High_Value")]//, MaxLength(30), ReadOnly(true)]
        public string RV_HIGH_VALUE { get; set; }


        [DisplayName("RV_Abbrevation")]//, MaxLength(30), ReadOnly(true)]
        public string RV_ABBREVIATION { get; set; }

        [DisplayName("RV_Meaning")]//, MaxLength(30), ReadOnly(true)]
        public string RV_MEANING { get; set; }
    }
}
