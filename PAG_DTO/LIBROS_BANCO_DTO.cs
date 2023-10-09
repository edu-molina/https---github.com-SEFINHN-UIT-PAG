using System;
using System.ComponentModel;

namespace PAG_DTO
{
    public class LIBROS_BANCO_DTO
    {

        [DisplayName("Gestión")]
        public short GESTION { get; set; }
        [DisplayName("Banco")]
        public short BANCO { get; set; }
        [DisplayName("Cuenta")]
        public string CUENTA { get; set; }
        [DisplayName("Moneda")]
        public string MONEDA { get; set; }
        public string TIPO_CUENTA { get; set; }
        public string CUENTA_CONTABLE { get; set; }
        public Nullable<decimal> SALDO_INICIAL { get; set; }
        public decimal SALDO { get; set; }
        public short INSTITUCION { get; set; }
        public short GA { get; set; }
        public string UTILIZA_LIBRETAS { get; set; }
        public string SE_CONCILIA { get; set; }
        public string DEBITA_POR { get; set; }
        public string ACREDITA_POR { get; set; }
        public string API_ESTADO { get; set; }
        public string API_TRANSACCION { get; set; }
        public string USU_CRE { get; set; }
        public System.DateTime FEC_CRE { get; set; }
        public string USU_MOD { get; set; }
        public Nullable<System.DateTime> FEC_MOD { get; set; }

        // Decripciones
        [DisplayName("Decripción")]
        public string DESC_CUENTA { get; set; }

    }
}
