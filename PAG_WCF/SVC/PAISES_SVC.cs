using System.Collections.Generic;

using PAG_DTO;
using PAG_INTERFACES;

namespace PAG_WCF
{
    public partial class PAG_Services : iPAG_Services
    {

        public List<PAISES_DTO> qry_PAISES_listado()
        {
            // TODO: Desarrolle su Codigo Aqui.
            return new PAISES_RDN().PAISES_listado();
        }

        public List<PAISES_DTO> qry_PAISES_filtrado(PAISES_DTO precDto)
        {
            // TODO: Desarrolle su Codigo Aqui.
            return new PAISES_RDN().PAISES_filtrado(precDto);
        }
    }
}