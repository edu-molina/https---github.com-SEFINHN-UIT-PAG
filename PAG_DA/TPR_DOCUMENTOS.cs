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
    
    public partial class TPR_DOCUMENTOS
    {
        public TPR_DOCUMENTOS()
        {
            this.TPR_DETALLES = new HashSet<TPR_DETALLES>();
        }
    
        public short INSTITUCION { get; set; }
        public short GA { get; set; }
        public short TIPO_PROGRAMACION { get; set; }
        public short SECUENCIA_DOC { get; set; }
        public string ID_DOCUMENTO { get; set; }
        public string OBSERVACION { get; set; }
        public string API_ESTADO { get; set; }
        public string API_TRANSACCION { get; set; }
        public string USU_CRE { get; set; }
        public System.DateTime FEC_CRE { get; set; }
        public string USU_MOD { get; set; }
        public Nullable<System.DateTime> FEC_MOD { get; set; }
    
        public virtual DCO_DOCUMENTOS DCO_DOCUMENTOS { get; set; }
        public virtual ICollection<TPR_DETALLES> TPR_DETALLES { get; set; }
        public virtual TPR_TIPOS_PROGRAMACION TPR_TIPOS_PROGRAMACION { get; set; }
    }
}
