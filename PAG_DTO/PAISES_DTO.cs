using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PAG_DTO
{
    public class PAISES_DTO
    {
        [DisplayName("País")]//, MaxLength(3), ReadOnly(true)]
        public string PAIS { get; set; }
        [DisplayName("Nombre País")]//, MaxLength(60), ReadOnly(true)]
        public string DESC_PAIS { get; set; }
        [DisplayName("Estado")]//, MaxLength(20), ReadOnly(true)]
        public string API_ESTADO { get; set; }
    }
}
