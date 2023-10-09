using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PAG_DTO
{
    public class GERENCIAS_ADMINISTRATIVAS_DTO
    {
        [DisplayName("Gestión")]//, MaxLength(4), ReadOnly(true)]
        public short GESTION { get; set; }
        [DisplayName("Institución")]//, MaxLength(4), ReadOnly(true)]
        public short INSTITUCION { get; set; }
        [DisplayName("Gerencia Administrativa")]//, MaxLength(3), ReadOnly(true)]
        public short GA { get; set; }
        [DisplayName("Descripción GA")]//, MaxLength(60), ReadOnly(true)]
        public string DESC_GA { get; set; }
        [DisplayName("Tipo GA")]//, MaxLength(1), ReadOnly(true)]
        public string TIPO_GA { get; set; }
        [DisplayName("Vigente")]//, MaxLength(1), ReadOnly(true)]
        public string VIGENTE { get; set; }
        [DisplayName("Estado")]//, MaxLength(20), ReadOnly(true)]
        public string API_ESTADO { get; set; }
    }
}
