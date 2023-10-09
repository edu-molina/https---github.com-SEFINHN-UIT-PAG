using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace PAG_DTO
{
    public class BENEFICIARIOS_DTO
    {
        [DisplayName("País ID")]//, MaxLength(3), ReadOnly(true)]
        public string PAIS_ID { get; set; }
        [DisplayName("Tipo ID")]//, MaxLength(3), ReadOnly(true)]
        public string TIPO_ID { get; set; }
        [DisplayName("Nro. ID")]//, MaxLength(20), ReadOnly(true)]
        public string NRO_ID { get; set; }
        [DisplayName("Descripción Otro Tipo ID")]//, MaxLength(30), ReadOnly(true)]
        public string DESC_OTRO_TIPO_ID { get; set; }
        [DisplayName("Nombre Beneficiario")]//, MaxLength(200), ReadOnly(true)]
        public string NOMBRE_BENEFICIARIO { get; set; }
        [DisplayName("Tipo Beneficiario")]//, MaxLength(2), ReadOnly(true)]
        public string TIPO_BENEFICIARIO { get; set; }
        [DisplayName("Clase Beneficiario")]//, MaxLength(1), ReadOnly(true)]
        public string CLASE_BENEFICIARIO { get; set; }
        [DisplayName("Estado")]//, MaxLength(20), ReadOnly(true)]
        public string API_ESTADO { get; set; }
    }
}
