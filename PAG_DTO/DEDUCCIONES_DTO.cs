using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PAG_DTO
{
    public class DEDUCCIONES_DTO
    {
        [DisplayName("Deducción")]//, MaxLength(4), ReadOnly(true)]
        public short DEDUCCION { get; set; }
        [DisplayName("Tipo")]//, MaxLength(1), ReadOnly(true)]
        public short TIPO { get; set; }
        [DisplayName("Sub Tipo")]//, MaxLength(3), ReadOnly(true)]
        public short SUB_TIPO { get; set; }
        [DisplayName("Descripción")]//, MaxLength(60), ReadOnly(true)]
        public string DESCRIPCION { get; set; }
        [DisplayName("Estado")]//, MaxLength(20), ReadOnly(true)]
        public string API_ESTADO { get; set; }
    }
}
