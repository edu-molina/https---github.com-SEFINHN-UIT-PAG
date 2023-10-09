//Agregadas por DSA

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PAG.Models
{
    public class AUX_MENU_DTO
    {
        public AUX_MENU_DTO()
        {
        }

        //Datos

        [Required(), DisplayName("Id Menu"), MaxLength(22)]
        public int ID_MENU { get; set; }

        [Required(), DisplayName("Id Sistema"), MaxLength(22)]
        public int ID_SISTEMA { get; set; }

        [Required(), DisplayName("Nombre Menu"), DataType(DataType.MultilineText), MaxLength(500)]
        public string NOMBRE_MENU { get; set; }

        [DisplayName("Id Menu Padre"), MaxLength(22)]
        public int ID_MENU_PADRE { get; set; }

        [Required(), DisplayName("Orden"), Range(1, 999)]
        public short ORDEN { get; set; }

        [Required(), DisplayName("Jerarquia"), MaxLength(100)]
        public string JERARQUIA { get; set; }

        [DisplayName("Metodo"), DataType(DataType.MultilineText), MaxLength(500)]
        public string METODO { get; set; }

        [Required(), DisplayName("Desc Menu"), DataType(DataType.MultilineText), MaxLength(500)]
        public string DESC_MENU { get; set; }

        [Required(), DisplayName("Tipo Menu"), DataType(DataType.MultilineText), MaxLength(1)]
        public string TIPO_MENU { get; set; }

        [DataType(DataType.MultilineText), DisplayName("Icono Menu"), MaxLength(240)]
        public string ICO_MENU { get; set; }

        [DisplayName("Tooltip"), DataType(DataType.MultilineText), MaxLength(240)]
        public string TOOLTIP { get; set; }

        [Required(), DisplayName("Vigente"), DataType(DataType.MultilineText), MaxLength(1)]
        public string VIGENTE { get; set; }

        [Required(), DisplayName("Habilitado"), DataType(DataType.MultilineText), MaxLength(240)]
        public string HABILITADO { get; set; }

        //Transiciones

        [DisplayName("Estado"), MaxLength(20)]
        public string API_ESTADO { get; set; }

        [Required(ErrorMessage = "La Transacción es obligatorio"), DisplayName("Transacción"), MaxLength(20)]
        public string API_TRANSACCION { get; set; }

        //Auditorias

        [ReadOnly(true), DisplayName("Usuario creación"), MaxLength(30)]
        public string USU_CRE { get; set; }

        [ReadOnly(true), DisplayName("Usuario modificación"), MaxLength(30)]
        public string USU_MOD { get; set; }

        [ReadOnly(true), DisplayName("Fecha creación")]
        public DateTime FEC_CRE { get; set; }

        [ReadOnly(true), DisplayName("Fecha modificación")]
        public DateTime? FEC_MOD { get; set; }
    }
}
