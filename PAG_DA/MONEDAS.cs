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
    
    public partial class MONEDAS
    {
        public MONEDAS()
        {
            this.DLB_LIB_BOLSON_DET = new HashSet<DLB_LIB_BOLSON_DET>();
            this.LIBROS_BANCO = new HashSet<LIBROS_BANCO>();
            this.PRG_LIBRETAS_BOLSON = new HashSet<PRG_LIBRETAS_BOLSON>();
            this.CUENTAS_BANCARIAS = new HashSet<CUENTAS_BANCARIAS>();
        }
    
        public string MONEDA { get; set; }
        public string DESC_MONEDA { get; set; }
        public string API_ESTADO { get; set; }
        public string API_TRANSACCION { get; set; }
        public string USU_CRE { get; set; }
        public System.DateTime FEC_CRE { get; set; }
        public string USU_MOD { get; set; }
        public Nullable<System.DateTime> FEC_MOD { get; set; }
    
        public virtual ICollection<DLB_LIB_BOLSON_DET> DLB_LIB_BOLSON_DET { get; set; }
        public virtual ICollection<LIBROS_BANCO> LIBROS_BANCO { get; set; }
        public virtual ICollection<PRG_LIBRETAS_BOLSON> PRG_LIBRETAS_BOLSON { get; set; }
        public virtual ICollection<CUENTAS_BANCARIAS> CUENTAS_BANCARIAS { get; set; }
    }
}
