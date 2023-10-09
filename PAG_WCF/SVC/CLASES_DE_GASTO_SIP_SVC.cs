using System.Collections.Generic;

using PAG_DTO;
using PAG_INTERFACES;

namespace PAG_WCF
{
    public partial class PAG_Services : iPAG_Services
    {
        public List<CLASES_DE_GASTO_SIP_DTO> qry_CLASES_DE_GASTO_SIP_listado()
        {
            // TODO: Desarrolle su Codigo Aqui.
            return new CLASES_DE_GASTO_SIP_RDN().CLASES_DE_GASTO_SIP_listado();
        }

        public List<CLASES_DE_GASTO_SIP_DTO> qry_CLASES_DE_GASTO_SIP_filtrado(CLASES_DE_GASTO_SIP_DTO precDto)
        {
            // TODO: Desarrolle su Codigo Aqui.
            return new CLASES_DE_GASTO_SIP_RDN().CLASES_DE_GASTO_SIP_filtrado(precDto);
        }
    }
}