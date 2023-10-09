using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Agregadas por DSA

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PAG_DTO
{
    public class AUX_MENU_DTO
    {
        public AUX_MENU_DTO()
        {
        }

        //Datos

        [DisplayName("Id Menu")]//, MaxLength(22)]
        public int ID_MENU { get; set; }

        [DisplayName("Id Sistema")]//, MaxLength(22)]
        public int ID_SISTEMA { get; set; }

        [DisplayName("Nombre Menu")]//, DataType(DataType.MultilineText), MaxLength(500)]
        public string NOMBRE_MENU { get; set; }

        [DisplayName("Id Menu Padre")]//, MaxLength(22)]
        public int ID_MENU_PADRE { get; set; }

        [DisplayName("Orden")]//, Range(1, 999)]
        public short ORDEN { get; set; }

        [DisplayName("Jerarquia")]//, MaxLength(100)]
        public string JERARQUIA { get; set; }

        [DisplayName("Metodo")]//, DataType(DataType.MultilineText), MaxLength(500)]
        public string METODO { get; set; }

        [DisplayName("Desc Menu")]//, DataType(DataType.MultilineText), MaxLength(500)]
        public string DESC_MENU { get; set; }

        [DisplayName("Tipo Menu")]//, DataType(DataType.MultilineText), MaxLength(1)]
        public string TIPO_MENU { get; set; }

        [DataType(DataType.MultilineText)]//, DisplayName("Icono Menu"), MaxLength(240)]
        public string ICO_MENU { get; set; }

        [DisplayName("Tooltip")]//, DataType(DataType.MultilineText), MaxLength(240)]
        public string TOOLTIP { get; set; }

        [DisplayName("Vigente")]//, DataType(DataType.MultilineText), MaxLength(1)]
        public string VIGENTE { get; set; }

        [DisplayName("Habilitado")]//, DataType(DataType.MultilineText), MaxLength(240)]
        public string HABILITADO { get; set; }

        //Transiciones

        [DisplayName("Estado")]//, MaxLength(20)]
        public string API_ESTADO { get; set; }

        [DisplayName("Transacción")]//, MaxLength(20)]
        public string API_TRANSACCION { get; set; }

        //Auditorias

        [DisplayName("Usuario creación")]//, MaxLength(30)]
        public string USU_CRE { get; set; }

        [DisplayName("Usuario modificación")]//, MaxLength(30)]
        public string USU_MOD { get; set; }

        [DisplayName("Fecha creación")]
        public DateTime FEC_CRE { get; set; }

        [ DisplayName("Fecha modificación")]
        public DateTime? FEC_MOD { get; set; }
    }
}
