using PAG_DTO;
using PAG_INTERFACES;
using System.Collections.Generic;

namespace PAG_WCF
{
    public partial class PAG_Services : iPAG_Services
    {
        public List<COLA_PARAMETROS_REPORTES_DTO> qry_COLA_PARAMETROS_REPORTES_listado()
        {
            return new COLA_PARAMETROS_REPORTES_RDN().COLA_PARAMETROS_REPORTES_listado();
        }

        public List<COLA_PARAMETROS_REPORTES_DTO> qry_COLA_PARAMETROS_REPORTES_filtrado(COLA_PARAMETROS_REPORTES_DTO precDto)
        {
            return new COLA_PARAMETROS_REPORTES_RDN().COLA_PARAMETROS_REPORTES_filtrado(precDto);
        }

        
        public COLA_PARAMETROS_REPORTES_DTO ins_COLA_PARAMETROS_REPORTES_inserta(COLA_PARAMETROS_REPORTES_DTO precDto)
        {
            return new COLA_PARAMETROS_REPORTES_RDN().COLA_PARAMETROS_REPORTES_inserta(precDto);
        }

        public COLA_PARAMETROS_REPORTES_DTO upd_COLA_PARAMETROS_REPORTES_actualiza(COLA_PARAMETROS_REPORTES_DTO precDto)
        {
            return new COLA_PARAMETROS_REPORTES_RDN().COLA_PARAMETROS_REPORTES_actualiza(precDto);
        }

        public COLA_PARAMETROS_REPORTES_DTO del_COLA_PARAMETROS_REPORTES_elimina(params object[] pkeysDto)
        {
            return new COLA_PARAMETROS_REPORTES_RDN().COLA_PARAMETROS_REPORTES_elimina(pkeysDto);
        }

    }

}