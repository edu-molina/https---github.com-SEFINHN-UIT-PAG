using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace PAG_DTO
{
    public class FUENTES_FINANCIAMIENTO_DTO
   {
        [DisplayName("Fuente")]//, MaxLength(2), ReadOnly(true)]
        public short FUENTE { get; set; }
        [DisplayName("Grupo Fuente")]//, MaxLength(1), ReadOnly(true)]
        public short GRUPO_FUENTE { get; set; }
        [DisplayName("SubGrupo Fuente")]//, MaxLength(2), ReadOnly(true)]
        public short SUB_GRUPO_FUENTE { get; set; }
        [DisplayName("Decripción Fuente")]//, MaxLength(60), ReadOnly(true)]
        public string DESC_FUENTE { get; set; }
        [DisplayName("Vigente")]//, MaxLength(1), ReadOnly(true)]
        public string VIGENTE { get; set; }
        [DisplayName("Estado")]//, MaxLength(20), ReadOnly(true)]
        public string API_ESTADO { get; set; }
    }
}
