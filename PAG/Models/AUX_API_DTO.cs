//Agregadas por DSA
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PAG.Models
{
    /// <summary>
    /// Clase DTO de la columna API_CLIENTE
    /// </summary>
    /// <history>
    /// FECHA               REPONSABLE              DESCRIPCION
    /// 01/Nov/2015         Danny Lainez            Creacion de Clase
    /// </history>
    public class AUX_API_DTO
    {
        //External User Information
        [DisplayName("Token")]//Required()
        public string TOKEN { get; set; }

        [DisplayName("Usuario")]//Required()
        public string USUARIO { get; set; }
        
        [DisplayName("Nombre Completo")]
        public string NOMBRE_COMPLETO { get; set; }

        [DisplayName("URL Transacción")]
        public string URL { get; set; }

        [Required(), DisplayName("Correo")]
        public string CORREO { get; set; }

        [DisplayName("Correo")]
        public string VERIFICADO { get; set; }
    }
}
