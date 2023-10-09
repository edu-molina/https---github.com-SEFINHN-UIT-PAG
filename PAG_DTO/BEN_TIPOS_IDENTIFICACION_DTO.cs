using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PAG_DTO
{
    public class BEN_TIPOS_IDENTIFICACION_DTO
    {
        [DisplayName("Tipo Documento")]//, MaxLength(3), ReadOnly(true)]
        public string TIPO_DOCUMENTO { get; set; }
        [DisplayName("Descripción Tipo Documento")]//, MaxLength(60), ReadOnly(true)]
        public string DESC_TIPO_DOCUMENTO { get; set; }
        [DisplayName("Estado")]//, MaxLength(20), ReadOnly(true)]
        public string API_ESTADO { get; set; }
   }
}
