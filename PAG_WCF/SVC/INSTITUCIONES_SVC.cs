using PAG_DA;
using PAG_DTO;
using PAG_INTERFACES;
using PAG_MAPPERS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.ServiceModel;
//

namespace PAG_WCF
{
  
    public partial class PAG_Services : iPAG_Services
    {

        public List<INSTITUCIONES_DTO> qry_INSTITUCIONES_listado()
        {
            // TODO: Desarrolle su Codigo Aqui.
            return new INSTITUCIONES_RDN().INSTITUCIONES_listado();
        }

        public List<INSTITUCIONES_DTO> qry_INSTITUCIONES_filtrado(INSTITUCIONES_DTO precDto)
        {
            // TODO: Desarrolle su Codigo Aqui.
            return new INSTITUCIONES_RDN().INSTITUCIONES_filtrado(precDto);
        }
    }

}

