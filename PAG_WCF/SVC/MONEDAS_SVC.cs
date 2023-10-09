using System.Collections.Generic;

using PAG_DTO;
using PAG_INTERFACES;

namespace PAG_WCF
{
    public partial class PAG_Services : iPAG_Services
    {

        public List<MONEDAS_DTO> qry_MONEDAS_listado()
        {
            // TODO: Desarrolle su Codigo Aqui.
            return new MONEDAS_RDN().MONEDAS_listado();
        }

        public List<MONEDAS_DTO> qry_MONEDAS_filtrado(MONEDAS_DTO precDto)
        {
            // TODO: Desarrolle su Codigo Aqui.
            return new MONEDAS_RDN().MONEDAS_filtrado(precDto);
        }
    }
}