using System;

namespace PAG_DTO
{
    public class COLA_PARAMETROS_REPORTES_DTO
    {
        public int ID { get; set; }
        public string REPORTE { get; set; }
        public string PARAMETROS { get; set; }
        public string PARAMETROS_SESION { get; set; }
        public string API_ESTADO { get; set; }
        public string API_TRANSACCION { get; set; }
        public string USU_CRE { get; set; }
        public System.DateTime FEC_CRE { get; set; }
        public string USU_MOD { get; set; }
        public Nullable<System.DateTime> FEC_MOD { get; set; }
        public COLA_PARAMETROS_REPORTES_DTO()
        {
        }
    }
}
