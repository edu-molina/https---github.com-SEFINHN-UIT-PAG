using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace PAG_DTO
{
    public class INSTITUCIONES_DTO
    {
        [DisplayName("Institución")]//, MaxLength(30), ReadOnly(true)]
        public short INSTITUCION { get; set; }
        [DisplayName("Descripción")]//, MaxLength(60), ReadOnly(true)]
        public string DESC_INSTITUCION { get; set; }
        [DisplayName("Vigente")]//, MaxLength(1), ReadOnly(true)]
        public string VIGENTE { get; set; }
        [DisplayName("Estado")]//, MaxLength(30), ReadOnly(true)]
        public string API_ESTADO { get; set; }
    }
}
