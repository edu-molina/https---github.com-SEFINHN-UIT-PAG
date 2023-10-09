using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PAG_DTO
{
    public class EGA_PARTIDAS_DTO
    {
        [DisplayName("Gestión")]//, MaxLength(4), ReadOnly(true)]
        public short GESTION { get; set; }
        [DisplayName("Institución")]//, MaxLength(4), ReadOnly(true)]
        public short INSTITUCION { get; set; }
        [DisplayName("GA")]//, MaxLength(3), ReadOnly(true)]
        public short GA { get; set; }
        [DisplayName("Nro. Precompromiso")]//, MaxLength(5), ReadOnly(true)]
        public short NRO_PRECOMPROMISO { get; set; }
        [DisplayName("Nro. Compromiso")]//, MaxLength(2), ReadOnly(true)]
        public short NRO_COMPROMISO { get; set; }
        [DisplayName("Nro. Devengado")]//, MaxLength(5), ReadOnly(true)]
        public short NRO_DEVENGADO { get; set; }
        [DisplayName("Nro. Secuencia")]//, MaxLength(2), ReadOnly(true)]
        public short NRO_SECUENCIA { get; set; }
        [DisplayName("Sec. Pago")]//, MaxLength(4), ReadOnly(true)]
        public short SEC_PAGO { get; set; }
        [DisplayName("UE")]//, MaxLength(3), ReadOnly(true)]
        public short UE { get; set; }
        [DisplayName("Programa")]//, MaxLength(2), ReadOnly(true)]
        public short PROGRAMA { get; set; }
        [DisplayName("Sub Programa")]//, MaxLength(2), ReadOnly(true)]
        public short SUB_PROGRAMA { get; set; }
        [DisplayName("Proyecto"), MaxLength(3), ReadOnly(true)]
        public short PROYECTO { get; set; }
        [DisplayName("Actividad/Obra")]//, MaxLength(3), ReadOnly(true)]
        public short ACTIVIDAD_OBRA { get; set; }
        [DisplayName("Fuente")]//, MaxLength(2), ReadOnly(true)]
        public short FUENTE { get; set; }
        [DisplayName("Oraganismo")]//, MaxLength(3), ReadOnly(true)]
        public short ORGANISMO { get; set; }
        [DisplayName("objeto")]//, MaxLength(5), ReadOnly(true)]
        public string OBJETO { get; set; }
        [DisplayName("Ben. Transferencia")]//, MaxLength(4), ReadOnly(true)]
        public short TRF_BENEFICIARIO { get; set; }
        [DisplayName("Estado")]//, MaxLength(20), ReadOnly(true)]
        public string API_ESTADO { get; set; }
    }
}
