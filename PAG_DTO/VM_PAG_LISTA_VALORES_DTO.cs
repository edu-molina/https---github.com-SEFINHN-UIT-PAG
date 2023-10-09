using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PAG_DTO
{
    public class VM_PAG_LISTA_VALORES_DTO
    {
        [DisplayName("Pk")]
        public decimal LLAVE_VIEW { get; set; }
        [DisplayName("Id Columna")]//MaxLength(4), ReadOnly(true)]
        public short ID_COLUMNA { get; set; }
        [DisplayName("Descripción")]// MaxLength(200), ReadOnly(true)]
        public string DESC_COLUMNA { get; set; }
        [DisplayName("Tabla")]//, MaxLength(30), ReadOnly(true)]
        public string TABLA { get; set; }
        [DisplayName("columna")]//, MaxLength(30), ReadOnly(true)]
        public string COLUMNA { get; set; } 
        [DisplayName("Tipo")]//, MaxLength(10), ReadOnly(true)]
        public string TIPO_VALOR { get; set; }
        [DisplayName("valor")]//, MaxLength(40), ReadOnly(true)]
        public string VALOR { get; set; }
        [DisplayName("Descripción")]//, MaxLength(200), ReadOnly(true)]
        public string DESCRIPCION { get; set; }
        [DisplayName("Otros Valores")]//], MaxLength(200), ReadOnly(true)]
        public string OTROS_VALORES { get; set; }

    }
}
