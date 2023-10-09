using System.Collections.Generic;

using PAG_DTO;
using PAG_INTERFACES;

namespace PAG_WCF
{
    public partial class PAG_Services : iPAG_Services
    {

        public List<BENEFICIARIOS_DTO> qry_BENEFICIARIOS_listado()
        {
            // TODO: Desarrolle su Codigo Aqui.
            return new BENEFICIARIOS_RDN().BENEFICIARIOS_listado();
        }

        public List<BENEFICIARIOS_DTO> qry_BENEFICIARIOS_filtrado(BENEFICIARIOS_DTO precDto)
        {
            // TODO: Desarrolle su Codigo Aqui.
            return new BENEFICIARIOS_RDN().BENEFICIARIOS_filtrado(precDto);
        }
    }
}