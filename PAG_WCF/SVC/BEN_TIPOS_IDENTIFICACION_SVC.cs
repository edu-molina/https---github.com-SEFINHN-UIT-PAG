using System.Collections.Generic;

using PAG_DTO;
using PAG_INTERFACES;

namespace PAG_WCF
{
    public partial class PAG_Services : iPAG_Services
    {

        public List<BEN_TIPOS_IDENTIFICACION_DTO> qry_BEN_TIPOS_IDENTIFICACION_listado()
        {
            // TODO: Desarrolle su Codigo Aqui.
            return new BEN_TIPOS_IDENTIFICACION_RDN().BEN_TIPOS_IDENTIFICACION_listado();
        }

        public List<BEN_TIPOS_IDENTIFICACION_DTO> qry_BEN_TIPOS_IDENTIFICACION_filtrado(BEN_TIPOS_IDENTIFICACION_DTO precDto)
        {
            // TODO: Desarrolle su Codigo Aqui.
            return new BEN_TIPOS_IDENTIFICACION_RDN().BEN_TIPOS_IDENTIFICACION_filtrado(precDto);
        }
    }
}