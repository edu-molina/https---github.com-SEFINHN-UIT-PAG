using System.Collections.Generic;

using PAG_DTO;
using PAG_INTERFACES;

namespace PAG_WCF
{
    public partial class PAG_Services : iPAG_Services
    {

        public List<LIBRETAS_DTO> qry_LIBRETAS_listado()
        {
            // TODO: Desarrolle su Codigo Aqui.
            return new LIBRETAS_RDN().LIBRETAS_listado();
        }

        public List<LIBRETAS_DTO> qry_LIBRETAS_filtrado(LIBRETAS_DTO precDto)
        {
            // TODO: Desarrolle su Codigo Aqui.
            return new LIBRETAS_RDN().LIBRETAS_filtrado(precDto);
        }
    }
}