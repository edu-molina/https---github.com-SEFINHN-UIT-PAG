using System;
using System.ComponentModel;

namespace PAG_DTO
{
    public class MONEDAS_DTO
    {
        [DisplayName("Moneda")]
        public string MONEDA { get; set; }
        [DisplayName("Descripción")]
        public string DESC_MONEDA { get; set; }
        public string API_ESTADO { get; set; }
        public string API_TRANSACCION { get; set; }
        public string USU_CRE { get; set; }
        public System.DateTime FEC_CRE { get; set; }
        public string USU_MOD { get; set; }
        public Nullable<System.DateTime> FEC_MOD { get; set; }
    }
}
