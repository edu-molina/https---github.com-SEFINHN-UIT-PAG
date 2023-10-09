using System.Collections.Generic;

using PAG_DTO;
using PAG_INTERFACES;

namespace PAG_WCF
{
    public partial class PAG_Services : iPAG_Services
    {

        public List<LIBROS_BANCO_DTO> qry_LIBROS_BANCO_listado()
        {
            // TODO: Desarrolle su Codigo Aqui.
            return new LIBROS_BANCO_RDN().LIBROS_BANCO_listado();
        }

        public List<LIBROS_BANCO_DTO> qry_LIBROS_BANCO_filtrado(LIBROS_BANCO_DTO precDto)
        {
            // TODO: Desarrolle su Codigo Aqui.
            return new LIBROS_BANCO_RDN().LIBROS_BANCO_filtrado(precDto);
        }
    }
}