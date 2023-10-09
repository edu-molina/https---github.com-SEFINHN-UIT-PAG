using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace PAG_DTO
{
    public class MUNICIPIOS_DTO
    {
        [DisplayName("Departamento")]//, MaxLength(2), ReadOnly(true)]
        public short DEPARTAMENTO { get; set; }
        [DisplayName("Municipio")]//, MaxLength(2), ReadOnly(true)]
        public short MUNICIPIO { get; set; }
        [DisplayName("Descripción")]//, MaxLength(60), ReadOnly(true)]
        public string DESC_MUNICIPIO { get; set; }
        [DisplayName("Sigla")]//, MaxLength(5), ReadOnly(true)]
        public string SIGLA_MUNICIPIO { get; set; }
        [DisplayName("vigente")]//, MaxLength(1), ReadOnly(true)]
        public string VIGENTE { get; set; }
        [DisplayName("Estado")]//, MaxLength(20), ReadOnly(true)]
        public string API_ESTADO { get; set; }
    }
}
