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
    
    public partial class DCO_COLUMNAS
    {
        public DCO_COLUMNAS()
        {
            this.DCO_DOCUMENTOS_COLUMNAS = new HashSet<DCO_DOCUMENTOS_COLUMNAS>();
        }
    
        public short ID_COLUMNA { get; set; }
        public string DESC_COLUMNA { get; set; }
        public string TIPO_COLUMNA { get; set; }
        public string TABLA { get; set; }
        public string COLUMNA { get; set; }
        public string API_ESTADO { get; set; }
        public string API_TRANSACCION { get; set; }
        public string USU_CRE { get; set; }
        public System.DateTime FEC_CRE { get; set; }
        public string USU_MOD { get; set; }
        public Nullable<System.DateTime> FEC_MOD { get; set; }
        public string TABLA_ORIGEN { get; set; }
        public string COLUMNA_ORIGEN { get; set; }
        public string OTROS_VALORES { get; set; }
        public string TIENE_LISTA { get; set; }
    
        public virtual ICollection<DCO_DOCUMENTOS_COLUMNAS> DCO_DOCUMENTOS_COLUMNAS { get; set; }
    }
}