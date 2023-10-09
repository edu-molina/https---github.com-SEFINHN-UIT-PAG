using System.Collections.Generic;

using PAG_DTO;
using PAG_INTERFACES;

namespace PAG_WCF
{
    public partial class PAG_Services : iPAG_Services
    {

        public List<MUNICIPIOS_DTO> qry_MUNICIPIOS_listado()
        {
            // TODO: Desarrolle su Codigo Aqui.
            return new MUNICIPIOS_RDN().MUNICIPIOS_listado();
        }

        public List<MUNICIPIOS_DTO> qry_MUNICIPIOS_filtrado(MUNICIPIOS_DTO precDto)
        {
            // TODO: Desarrolle su Codigo Aqui.
            return new MUNICIPIOS_RDN().MUNICIPIOS_filtrado(precDto);
        }
    }
}