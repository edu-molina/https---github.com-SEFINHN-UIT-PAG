using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace PAG_DTO
{
    public class CLASES_DE_GASTO_CIP_DTO
    {
        [DisplayName("Gestión")]//, MaxLength(4)]
        public short GESTION { get; set; }
        [DisplayName("Clase de Gasto")]//, MaxLength(2)]
        public short CLASE_DE_GASTO { get; set; }
        [DisplayName("Descripción Clase de Gasto")]//, MaxLength(60), ReadOnly(true)]
        public string DESC_CLASE_DE_GASTO { get; set; }
        [DisplayName("Estado")]//, MaxLength(20), ReadOnly(true)]
        public string API_ESTADO { get; set; }
    }
}
