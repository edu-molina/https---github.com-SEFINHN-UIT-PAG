//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PAG_DA
{
    using System;
    using System.Collections.Generic;
    
    public partial class EGA_BENEFICIARIOS
    {
        public short GESTION { get; set; }
        public short INSTITUCION { get; set; }
        public short GA { get; set; }
        public short NRO_PRECOMPROMISO { get; set; }
        public short NRO_COMPROMISO { get; set; }
        public short NRO_DEVENGADO { get; set; }
        public short NRO_SECUENCIA { get; set; }
        public short SEC_PAGO { get; set; }
        public string PAIS_ID { get; set; }
        public string TIPO_ID { get; set; }
        public string NRO_ID { get; set; }
        public short EJERCICIO { get; set; }
        public string TIPOS_MOMENTOS { get; set; }
        public Nullable<short> BANCO { get; set; }
        public string CUENTA { get; set; }
        public decimal MONTO { get; set; }
        public decimal MONTO_DC { get; set; }
        public decimal MONTO_ME { get; set; }
        public string API_ESTADO { get; set; }
        public string API_TRANSACCION { get; set; }
        public string USU_CRE { get; set; }
        public System.DateTime FEC_CRE { get; set; }
        public string USU_MOD { get; set; }
        public Nullable<System.DateTime> FEC_MOD { get; set; }
    
        public virtual BENEFICIARIOS BENEFICIARIOS { get; set; }
    }
}
