using System.Collections.Generic;

using PAG_DTO;
using PAG_INTERFACES;

namespace PAG_WCF
{
    public partial class PAG_Services : iPAG_Services
    {

        public List<DEDUCCIONES_DTO> qry_DEDUCCIONES_listado()
        {
            // TODO: Desarrolle su Codigo Aqui.
            return new DEDUCCIONES_RDN().DEDUCCIONES_listado();
        }

        public List<DEDUCCIONES_DTO> qry_DEDUCCIONES_filtrado(DEDUCCIONES_DTO precDto)
        {
            // TODO: Desarrolle su Codigo Aqui.
            return new DEDUCCIONES_RDN().DEDUCCIONES_filtrado(precDto);
        }
    }
}