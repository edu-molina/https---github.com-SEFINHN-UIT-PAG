using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PAG_DTO
{
    public class OBJETOS_DEL_GASTO_DTO
    {
        [DisplayName("Gestión")]//, MaxLength(4), ReadOnly(true)]
        public short GESTION { get; set; }
        [DisplayName("Objeto")]//, MaxLength(5), ReadOnly(true)]
        public string OBJETO { get; set; }
        [DisplayName("Grupo Objeto")]//, MaxLength(30), ReadOnly(true)]
        public short GRUPO_OBJETO { get; set; }
        [DisplayName("Sub Grupo Objeto")]//, MaxLength(1), ReadOnly(true)]
        public short SUB_GRUPO_OBJETO { get; set; }
        [DisplayName("Partida")]//, MaxLength(1), ReadOnly(true)]
        public short PARTIDA_OBJETO { get; set; }
        [DisplayName("Sub Partida")]//, MaxLength(2), ReadOnly(true)]
        public short SUB_PARTIDA_OBJETO { get; set; }
        [DisplayName("Institución")]//, MaxLength(200), ReadOnly(true)]
        public string DESC_OBJETO { get; set; }
        [DisplayName("Institución")]//, MaxLength(1), ReadOnly(true)]
        public string VIGENTE { get; set; }
        [DisplayName("Institución")]//, MaxLength(20), ReadOnly(true)]
        public string API_ESTADO { get; set; }
    }
}
