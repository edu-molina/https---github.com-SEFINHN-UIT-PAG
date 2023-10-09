using System;
using System.ComponentModel;

namespace PAG_DTO
{
    public class BANCOS_DTO
    {
        [DisplayName("Banco")]
        public short BANCO { get; set; }
        [DisplayName("Descripción")]
        public string DESC_BANCO { get; set; }
        public string SIGLA_BANCO { get; set; }
        public string TIPO_BANCO { get; set; }
        public string API_ESTADO { get; set; }
        public string API_TRANSACCION { get; set; }
        public string USU_CRE { get; set; }
        public System.DateTime FEC_CRE { get; set; }
        public string USU_MOD { get; set; }
        public Nullable<System.DateTime> FEC_MOD { get; set; }
        public string CUENTA_ENCAJE { get; set; }
        public string RECIPIENTE_ID { get; set; }
        public string CONECTADO_SIAFI { get; set; }
        public string HABILITADO_ENVIOS { get; set; }
        public string BEN_PAIS_ID { get; set; }
        public string BEN_TIPO_ID { get; set; }
        public string BEN_NRO_ID { get; set; }
        public Nullable<short> BEN_BANCO { get; set; }
        public string BEN_CUENTA { get; set; }
    }
}
