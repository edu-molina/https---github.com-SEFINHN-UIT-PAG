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
    
    public partial class BENEFICIARIOS
    {
        public BENEFICIARIOS()
        {
            this.EGA_BENEFICIARIOS = new HashSet<EGA_BENEFICIARIOS>();
        }
    
        public string PAIS_ID { get; set; }
        public string TIPO_ID { get; set; }
        public string NRO_ID { get; set; }
        public string DESC_OTRO_TIPO_ID { get; set; }
        public string NOMBRE_BENEFICIARIO { get; set; }
        public string TIPO_BENEFICIARIO { get; set; }
        public string CLASE_BENEFICIARIO { get; set; }
        public int NRO_REGISTRO_BENEFICIARIO { get; set; }
        public string ACTIVIDAD_COMERCIAL { get; set; }
        public Nullable<short> INSTITUCION { get; set; }
        public Nullable<short> GA { get; set; }
        public string RTN { get; set; }
        public string PAIS { get; set; }
        public Nullable<short> CIUDAD { get; set; }
        public string DIRECCION { get; set; }
        public string TELEFONO { get; set; }
        public string FAX { get; set; }
        public string EMAIL { get; set; }
        public string PIN { get; set; }
        public string API_ESTADO { get; set; }
        public string API_TRANSACCION { get; set; }
        public string USU_CRE { get; set; }
        public System.DateTime FEC_CRE { get; set; }
        public string USU_MOD { get; set; }
        public Nullable<System.DateTime> FEC_MOD { get; set; }
        public Nullable<short> CODIGO_INSTITUCIONAL { get; set; }
        public string SIGLA_BENEFICIARIO { get; set; }
        public string ESTADO_EMAIL { get; set; }
    
        public virtual BEN_TIPOS_IDENTIFICACION BEN_TIPOS_IDENTIFICACION { get; set; }
        public virtual PAISES PAISES { get; set; }
        public virtual PAISES PAISES1 { get; set; }
        public virtual ICollection<EGA_BENEFICIARIOS> EGA_BENEFICIARIOS { get; set; }
    }
}
