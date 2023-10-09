using System.Collections.Generic;

using PAG_DTO;
using PAG_INTERFACES;

namespace PAG_WCF
{
    public partial class PAG_Services : iPAG_Services
    {

        public List<OBJETOS_DEL_GASTO_DTO> qry_OBJETOS_DEL_GASTO_listado()
        {
            // TODO: Desarrolle su Codigo Aqui.
            return new OBJETOS_DEL_GASTO_RDN().OBJETOS_DEL_GASTO_listado();
        }

        public List<OBJETOS_DEL_GASTO_DTO> qry_OBJETOS_DEL_GASTO_filtrado(OBJETOS_DEL_GASTO_DTO precDto)
        {
            // TODO: Desarrolle su Codigo Aqui.
            return new OBJETOS_DEL_GASTO_RDN().OBJETOS_DEL_GASTO_filtrado(precDto);
        }
    }
}