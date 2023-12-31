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
    
    public partial class DOCUMENTOS_DE_GASTOS
    {
        public short GESTION { get; set; }
        public short INSTITUCION { get; set; }
        public short GA { get; set; }
        public short NRO_PRECOMPROMISO { get; set; }
        public short NRO_COMPROMISO { get; set; }
        public short NRO_DEVENGADO { get; set; }
        public short NRO_SECUENCIA { get; set; }
        public short EJERCICIO { get; set; }
        public Nullable<int> NRO_CARGA { get; set; }
        public Nullable<short> SECUENCIA_CARGA { get; set; }
        public Nullable<short> NRO_DEVENGADO_SIP { get; set; }
        public short UE { get; set; }
        public string TIPO_FORMULARIO { get; set; }
        public string TIPO_DOCUMENTO { get; set; }
        public string TIPO_EJECUCION { get; set; }
        public string PRECOMPROMISO { get; set; }
        public string COMPROMISO { get; set; }
        public string DEVENGADO { get; set; }
        public string PAGO { get; set; }
        public string DEVENGADO_SIP { get; set; }
        public string PAGO_SIP { get; set; }
        public string REGULARIZACION { get; set; }
        public string GLOBAL { get; set; }
        public short LUGAR_DEP { get; set; }
        public short LUGAR_MUN { get; set; }
        public System.DateTime FECHA_ELABORACION { get; set; }
        public string RDO_TIPO { get; set; }
        public string RDO_DOC { get; set; }
        public Nullable<short> RDO_SECUENCIA { get; set; }
        public Nullable<short> RDO_TOTAL { get; set; }
        public Nullable<System.DateTime> RDO_FECHA_RECEPCION { get; set; }
        public Nullable<System.DateTime> RDO_FECHA_VENCIMIENTO { get; set; }
        public string RDO_COMPRA { get; set; }
        public string APLICACION { get; set; }
        public Nullable<short> CLASE_DE_GASTO { get; set; }
        public Nullable<short> CLASE_DE_GASTO_SIP { get; set; }
        public Nullable<short> FUENTE { get; set; }
        public Nullable<short> ORGANISMO { get; set; }
        public string BIP { get; set; }
        public string CONVENIO { get; set; }
        public string SIGADE { get; set; }
        public Nullable<short> TRAMO { get; set; }
        public Nullable<System.DateTime> FECHA_VERIFICACION { get; set; }
        public Nullable<System.DateTime> FECHA_APROBACION { get; set; }
        public Nullable<System.DateTime> FECHA_FIRMA { get; set; }
        public string API_ESTADO { get; set; }
        public string API_TRANSACCION { get; set; }
        public string USU_CRE { get; set; }
        public System.DateTime FEC_CRE { get; set; }
        public string USU_MOD { get; set; }
        public Nullable<System.DateTime> FEC_MOD { get; set; }
    
        public virtual FUENTES_FINANCIAMIENTO FUENTES_FINANCIAMIENTO { get; set; }
        public virtual MUNICIPIOS MUNICIPIOS { get; set; }
    }
}
