using System.Collections.Generic;

using PAG_DTO;
using PAG_INTERFACES;

namespace PAG_WCF
{
    public partial class PAG_Services : iPAG_Services
    {

        public List<BANCOS_DTO> qry_BANCOS_listado()
        {
            // TODO: Desarrolle su Codigo Aqui.
            return new BANCOS_RDN().BANCOS_listado();
        }

        public List<BANCOS_DTO> qry_BANCOS_filtrado(BANCOS_DTO precDto)
        {
            // TODO: Desarrolle su Codigo Aqui.
            return new BANCOS_RDN().BANCOS_filtrado(precDto);
        }
    }
}