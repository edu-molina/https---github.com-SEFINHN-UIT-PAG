using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// Clase EGA_BENEFICIARIOS_DTO
/// </summary>
/// <history>
/// FECHA               REPONSABLE              DESCRIPCION
/// 03/Abril/2017       Elia Enamorado          Creacion de Clase
/// </history>
namespace PAG_DTO
{
    public class EGA_BENEFICIARIOS_DTO
    {
        [DisplayName("Gestión")]//, MaxLength(4), ReadOnly(true)]
        public short GESTION { get; set; }

        [DisplayName("Institución")]//, MaxLength(6), ReadOnly(true)]
        public short INSTITUCION { get; set; }

        [DisplayName("GA")]//, MaxLength(6), ReadOnly(true)]
        public short GA { get; set; }

        [DisplayName("Nro Precompromiso")]//, MaxLength(5), ReadOnly(true)]
        public short NRO_PRECOMPROMISO { get; set; }

        [DisplayName("Nro Compromiso")]//, MaxLength(2), ReadOnly(true)]
        public short NRO_COMPROMISO { get; set; }

        [DisplayName("Nro Devengado")]//, MaxLength(5), ReadOnly(true)]
        public short NRO_DEVENGADO { get; set; }

        [DisplayName("Nro Secuencia ")]//, MaxLength(2), ReadOnly(true)]
        public short NRO_SECUENCIA { get; set; }

        [DisplayName("Sec Pago")]//, MaxLength(4), ReadOnly(true)]
        public short SEC_PAGO { get; set; }

        [DisplayName("Pais Id")]//, MaxLength(3), ReadOnly(true)]
        public string PAIS_ID { get; set; }

        [DisplayName("Tipo Id")]//, MaxLength(3), ReadOnly(true)]
        public string TIPO_ID { get; set; }

        [DisplayName("Nro Id")]//, MaxLength(20), ReadOnly(true)]
        public string NRO_ID { get; set; }

        [DisplayName("Ejercicio")]//, MaxLength(4), ReadOnly(true)]
        public short EJERCICIO { get; set; }

        [DisplayName("Tipos Momentos")]//, MaxLength(12), ReadOnly(true)]
        public string TIPOS_MOMENTOS { get; set; }

        [DisplayName("Banco")]//, MaxLength(5), ReadOnly(true)]
        public System.Nullable<short> BANCO { get; set; }

        [DisplayName("Cuenta")]//, MaxLength(20), ReadOnly(true)]
        public string CUENTA { get; set; }

        [DisplayName("Monto")]//, MaxLength(38), ReadOnly(true)]
        public decimal MONTO { get; set; }

        [DisplayName("Monto")]//, MaxLength(38), ReadOnly(true)]
        public decimal MONTO_DC { get; set; }

        [DisplayName("Monto ME")]//, MaxLength(38), ReadOnly(true)]
        public decimal MONTO_ME { get; set; }

        [DisplayName("Estado")]//, MaxLength(30), ReadOnly(true)]
        public string API_ESTADO { get; set; }
    }
}