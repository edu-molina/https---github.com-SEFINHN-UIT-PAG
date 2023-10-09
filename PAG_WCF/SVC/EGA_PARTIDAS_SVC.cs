using System.Collections.Generic;

using PAG_DTO;
using PAG_INTERFACES;

namespace PAG_WCF
{
    public partial class PAG_Services : iPAG_Services
    {
        public List<EGA_PARTIDAS_DTO> qry_EGA_PARTIDAS_listado()
        {
            return new EGA_PARTIDAS_RDN().EGA_PARTIDAS_listado();
        }

        public List<EGA_PARTIDAS_DTO> qry_EGA_PARTIDAS_filtrado(EGA_PARTIDAS_DTO precDto)
        {
            return new EGA_PARTIDAS_RDN().EGA_PARTIDAS_filtrado(precDto);
        }
    }
}