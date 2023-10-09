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
    
    public partial class LIBRETAS
    {
        public LIBRETAS()
        {
            this.DLB_LIB_BOLSON_DET = new HashSet<DLB_LIB_BOLSON_DET>();
            this.PRG_LIBRETAS_BOLSON = new HashSet<PRG_LIBRETAS_BOLSON>();
        }
    
        public short GESTION { get; set; }
        public short BANCO { get; set; }
        public string CUENTA { get; set; }
        public string LIBRETA { get; set; }
        public string MONEDA { get; set; }
        public short INSTITUCION { get; set; }
        public short GA { get; set; }
        public short FUENTE { get; set; }
        public short SECUENCIA_FUENTE { get; set; }
        public string DESC_LIBRETA { get; set; }
        public Nullable<decimal> SALDO_INICIAL { get; set; }
        public decimal SALDO { get; set; }
        public string SE_CONCILIA { get; set; }
        public string DEBITA_POR { get; set; }
        public string ACREDITA_POR { get; set; }
        public string API_ESTADO { get; set; }
        public string API_TRANSACCION { get; set; }
        public string USU_CRE { get; set; }
        public System.DateTime FEC_CRE { get; set; }
        public string USU_MOD { get; set; }
        public Nullable<System.DateTime> FEC_MOD { get; set; }
    
        public virtual ICollection<DLB_LIB_BOLSON_DET> DLB_LIB_BOLSON_DET { get; set; }
        public virtual FUENTES_FINANCIAMIENTO FUENTES_FINANCIAMIENTO { get; set; }
        public virtual GERENCIAS_ADMINISTRATIVAS GERENCIAS_ADMINISTRATIVAS { get; set; }
        public virtual LIBROS_BANCO LIBROS_BANCO { get; set; }
        public virtual ICollection<PRG_LIBRETAS_BOLSON> PRG_LIBRETAS_BOLSON { get; set; }
    }
}
