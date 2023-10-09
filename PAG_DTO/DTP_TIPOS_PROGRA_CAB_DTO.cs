//------------------------------------------------------------------------------
//                         Secretaria de Finanzas
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PAG_DTO
{
    
    
    public class DTP_TIPOS_PROGRA_CAB_DTO
    {


        [DisplayName("Gestión")]//, MaxLength(4)]
        public short GESTION { get; set; }
        [DisplayName("Institución")]//, MaxLength(4)]
        public short INSTITUCION { get; set; }
        [DisplayName("GA")]//, MaxLength(3)]
        public short GA { get; set; }
        [DisplayName("Nro. Documento")]//, MaxLength(5)]
        public short NRO_DOCUMENTO { get; set; }
        [DisplayName("Lugar")]//, MaxLength(2)]
        public short DPTO_LUGAR { get; set; }
        //[Required(), MaxLength(2)]
        public short MUN_LUGAR { get; set; }
        [DisplayName("Operación")]//, MaxLength(1)]
        public System.String TIPO_OPERACION { get; set; }
        [DisplayName("Verificado por")]//, MaxLength(30), ReadOnly(true)]
        public System.String USU_VERIFICACION { get; set; }
        [DisplayName("Fecha Verificación")]//, ReadOnly(true), DisplayFormat(DataFormatString = AUX_CONST_DTO.FormatoFechaCortayHora)]
        public System.DateTime? FEC_VERIFICACION { get; set; }
        [DisplayName("Aprobado por")]//, MaxLength(30), ReadOnly(true)]
        public System.String USU_APROBACION { get; set; }
        [DisplayName("Fecha Aprobación")]//, ReadOnly(true), DisplayFormat(DataFormatString = AUX_CONST_DTO.FormatoFechaCortayHora)]
        public System.DateTime? FEC_APROBACION { get; set; }
        [DisplayName("Estado")]//, MaxLength(20), ReadOnly(true)]
        public System.String API_ESTADO { get; set; }
        [DisplayName("Transacción")]//, MaxLength(20), Required(ErrorMessage = "La Transacción es obligatoria")]
        public System.String API_TRANSACCION { get; set; }
        [DisplayName("Creado por")]//, MaxLength(30), ReadOnly(true)]
        public System.String USU_CRE { get; set; }
        [DisplayName("Fecha Creación ")]//, ReadOnly(true)]
        public System.DateTime FEC_CRE { get; set; }
        [DisplayName("Modificado por")]//, MaxLength(30), ReadOnly(true)]
        public System.String USU_MOD { get; set; }
        [DisplayName("Fecha Modificación")]//, ReadOnly(true)]
        public System.DateTime? FEC_MOD { get; set; }

        // Descripciones
        //
        [DisplayName("")]//, MaxLength(60), ReadOnly(true)]
        public System.String DESC_INSTITUCION { get; set; }
        [DisplayName("")]//, MaxLength(60), ReadOnly(true)]
        public System.String DESC_GA { get; set; }
        [DisplayName("")]//, MaxLength(60), ReadOnly(true)]
        public System.String DESC_LUGAR { get; set; }

        [DisplayName("Tipo Operación")]//, MaxLength(60), ReadOnly(true)]
        public System.String DESC_TIPO_OPERACION { get; set; }

        //public DTP_TIPOS_PROGRA_CAB_DTO()
        //{
        //}
    }
}
