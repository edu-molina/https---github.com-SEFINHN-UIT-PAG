
using System.Collections.Generic;


using PAG_DTO;
using PAG_INTERFACES;

namespace PAG_WCF
{
    public partial class PAG_Services : iPAG_Services
    {

        public List<FUENTES_FINANCIAMIENTO_DTO> qry_FUENTES_FINANCIAMIENTO_listado()
        {
            // TODO: Desarrolle su Codigo Aqui.
            return new FUENTES_FINANCIAMIENTO_RDN().FUENTES_FINANCIAMIENTO_listado();
        }

        public List<FUENTES_FINANCIAMIENTO_DTO> qry_FUENTES_FINANCIAMIENTO_filtrado(FUENTES_FINANCIAMIENTO_DTO precDto)
        {
            // TODO: Desarrolle su Codigo Aqui.
            return new FUENTES_FINANCIAMIENTO_RDN().FUENTES_FINANCIAMIENTO_filtrado(precDto);
        }
    }
}