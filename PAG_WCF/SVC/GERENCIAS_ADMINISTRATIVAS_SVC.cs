
using System.Collections.Generic;


using PAG_DTO;
using PAG_INTERFACES;

namespace PAG_WCF
{
    public partial class PAG_Services : iPAG_Services
    {

        public List<GERENCIAS_ADMINISTRATIVAS_DTO> qry_GERENCIAS_ADMINISTRATIVAS_listado()
        {
            // TODO: Desarrolle su Codigo Aqui.
            return new GERENCIAS_ADMINISTRATIVAS_RDN().GERENCIAS_ADMINISTRATIVAS_listado();
        }

        public List<GERENCIAS_ADMINISTRATIVAS_DTO> qry_GERENCIAS_ADMINISTRATIVAS_filtrado(GERENCIAS_ADMINISTRATIVAS_DTO precDto)
        {
            // TODO: Desarrolle su Codigo Aqui.
            return new GERENCIAS_ADMINISTRATIVAS_RDN().GERENCIAS_ADMINISTRATIVAS_filtrado(precDto);
        }
    }
}