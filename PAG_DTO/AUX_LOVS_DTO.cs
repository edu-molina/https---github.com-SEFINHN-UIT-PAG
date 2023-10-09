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
    /// Clase DTO para las LOVS de SIRFIDE
    /// </summary>
    /// <history>
    /// FECHA               REPONSABLE              DESCRIPCION
    /// 01/Nov/2015         Danny Lainez            Creacion de Clase
    /// 20/Jun/2016         Danny Lainez            Agregados 2 Columnas de Valores
    /// </history>
    public class AUX_LOVS_DTO
    {
        public AUX_LOVS_DTO()
        {         
        }

        //Datos

        [DisplayName("Nombre LOV")]//, MaxLength(100)]
        public string LOV_NOMBRE { get; set; }

        [DisplayName("Código LOV")]//, MaxLength(50)]
        public string LOV_CODIGO { get; set; }

        [DisplayName("Descripción LOV")]//, MaxLength(600)]
        public string LOV_DESCRIPCION { get; set; }

        //[MaxLength(2000)]
        public string LOV_VALOR_01 { get; set; }

        //[MaxLength(2000)]
        public string LOV_VALOR_02 { get; set; }

        //[MaxLength(2000)]
        public string LOV_VALOR_03 { get; set; }

        //[MaxLength(2000)]
        public string LOV_VALOR_04 { get; set; }

        //[MaxLength(2000)]
        public string LOV_VALOR_05 { get; set; }       
    }
}
