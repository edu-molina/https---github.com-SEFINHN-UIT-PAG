using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// Clase DOCUMENTOS_DE_GASTOS_DTO
/// </summary>
/// <history>
/// FECHA               REPONSABLE              DESCRIPCION
/// 03/Abril/2017       Elia Enamorado          Creacion de Clase
/// </history>
namespace PAG_DTO
{
    public class DOCUMENTOS_DE_GASTOS_DTO
    {
        [DisplayName("Gestión")]//, MaxLength(4), ReadOnly(true)]
        public short GESTION { get; set; }

        [DisplayName("Institución")]//, MaxLength(6), ReadOnly(true)]
        public short INSTITUCION { get; set; }

        [DisplayName("GA")]//, MaxLength(6), ReadOnly(true)]
        public short GA { get; set; }

        [DisplayName("Nro Precompromiso")]//, MaxLength(5), ReadOnly(true)]
        public short NRO_PRECOMPROMISO { get; set; }
        
        [DisplayName("Nro Compromiso")]//, MaxLength(2), ReadOnly(true)]
        public short NRO_COMPROMISO { get; set; }

        [DisplayName("Nro Devengado")]//, MaxLength(5), ReadOnly(true)]
        public short NRO_DEVENGADO { get; set; }

        [DisplayName("Nro Secuencia ")]//, MaxLength(2), ReadOnly(true)]
        public short NRO_SECUENCIA { get; set; }

        [DisplayName("Ejercicio")]//, MaxLength(4), ReadOnly(true)]
        public short EJERCICIO { get; set; }

        //      [DisplayName("Nro Carga"), MaxLength(6), ReadOnly(true)]
        // public System.Nullable<int> NRO_CARGA { get; set; }

        //       [DisplayName("Secuencia Carga"), MaxLength(4), ReadOnly(true)]
        //       public System.Nullable<short> SECUENCIA_CARGA { get; set; }

        [DisplayName("Nro Devengado SIP")]//, MaxLength(5), ReadOnly(true)]
        public System.Nullable<short> NRO_DEVENGADO_SIP { get; set; }

        [DisplayName("UE")]//, MaxLength(5), ReadOnly(true)]
        public short UE { get; set; }

        [DisplayName("Tipo Formulario")]//, MaxLength(1), ReadOnly(true)]
        public string TIPO_FORMULARIO { get; set; }

        [DisplayName("Tipo Documento")]//, MaxLength(1), ReadOnly(true)]
        public string TIPO_DOCUMENTO { get; set; }

        //      [DisplayName("Tipo Ejecución"), MaxLength(1), ReadOnly(true)]
        //      public string TIPO_EJECUCION { get; set; }

        //     [DisplayName("Precompromiso"), MaxLength(1), ReadOnly(true)]
        //     public string PRECOMPROMISO { get; set; }

        //     [DisplayName("Compromiso"), MaxLength(1), ReadOnly(true)]
        //     public string COMPROMISO { get; set; }

        //     [DisplayName("Devengado"), MaxLength(1), ReadOnly(true)]
        //     public string DEVENGADO { get; set; }

        //      [DisplayName("Pago"), MaxLength(1), ReadOnly(true)]
        //    public string PAGO { get; set; }

        //      [DisplayName("Devengado SIP"), MaxLength(1), ReadOnly(true)]
        //      public string DEVENGADO_SIP { get; set; }

        //      [DisplayName("Pago SIP"), MaxLength(1), ReadOnly(true)]
        //       public string PAGO_SIP { get; set; }

        //      [DisplayName("Regularización"), MaxLength(1), ReadOnly(true)]
        //     public string REGULARIZACION { get; set; }

        //      [DisplayName("Global"), MaxLength(1), ReadOnly(true)]
        //      public string GLOBAL { get; set; }

        [DisplayName("Lugar Dep")]//, MaxLength(2), ReadOnly(true)]
        public short LUGAR_DEP { get; set; }

        [DisplayName("Lugar Mun")]//, MaxLength(2), ReadOnly(true)]
        public short LUGAR_MUN { get; set; }
        //    public System.DateTime FECHA_ELABORACION { get; set; }
        //     public string RDO_TIPO { get; set; }
        //   public string RDO_DOC { get; set; }
        // public System.Nullable<short> RDO_SECUENCIA { get; set; }
        // public System.Nullable<short> RDO_TOTAL { get; set; }
        // public System.Nullable<System.DateTime> RDO_FECHA_RECEPCION { get; set; }
        //  public System.Nullable<System.DateTime> RDO_FECHA_VENCIMIENTO { get; set; }
        // public string RDO_COMPRA { get; set; }

        [DisplayName("Aplicación")]//, MaxLength(5), ReadOnly(true)]
        public string APLICACION { get; set; }

        //   [DisplayName("Clase Gasto"), MaxLength(2), ReadOnly(true)]
        //   public System.Nullable<short> CLASE_DE_GASTO { get; set; }

        //    [DisplayName("Clase Gasto"), MaxLength(1), ReadOnly(true)]
        //   public System.Nullable<short> CLASE_DE_GASTO_SIP { get; set; }

        [DisplayName("Fuente")]//, MaxLength(2), ReadOnly(true)]
        public System.Nullable<short> FUENTE { get; set; }

        [DisplayName("Organismo")]//, MaxLength(3), ReadOnly(true)]
        public System.Nullable<short> ORGANISMO { get; set; }

        [DisplayName("BIP")]//, MaxLength(20), ReadOnly(true)]
        public string BIP { get; set; }

        [DisplayName("Convenio")]//, MaxLength(30), ReadOnly(true)]
        public string CONVENIO { get; set; }

        [DisplayName("SIGADE")]//, MaxLength(15), ReadOnly(true)]
        public string SIGADE { get; set; }

        [DisplayName("Tramo")]//, MaxLength(4), ReadOnly(true)]
        public System.Nullable<short> TRAMO { get; set; }

        [DisplayName("Estado")]//, MaxLength(4), ReadOnly(true)]
        public string API_ESTADO { get; set; }
  
    }
}
