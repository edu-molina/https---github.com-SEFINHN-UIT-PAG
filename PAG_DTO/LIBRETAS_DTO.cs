using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAG_DTO
{
    public class LIBRETAS_DTO
    {
        [DisplayName("Gestión")]
        public short GESTION { get; set; }
        [DisplayName("Banco")]
        public short BANCO { get; set; }
        [DisplayName("Cuenta")]
        public string CUENTA { get; set; }
        [DisplayName("Libreta")]
        public string LIBRETA { get; set; }
        public string MONEDA { get; set; }
        public short INSTITUCION { get; set; }
        public short GA { get; set; }
        public short FUENTE { get; set; }
        public short SECUENCIA_FUENTE { get; set; }
        [DisplayName("Descripción")]
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
    }
}
