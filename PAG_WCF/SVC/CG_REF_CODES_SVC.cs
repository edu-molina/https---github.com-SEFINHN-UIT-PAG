using System.Collections.Generic;

using PAG_DTO;
using PAG_INTERFACES;

/// <summary>
/// Clase CG_REF_CODES_SVC
/// </summary>
/// <history>
/// FECHA               REPONSABLE              DESCRIPCION
/// 04/Abril/2017       Elia Enamorado          Creacion de Clase
/// </history>
/// 

namespace PAG_WCF
{
         public partial class PAG_Services : iPAG_Services
    {

        public List<CG_REF_CODES_DTO> qry_CG_REF_CODES_listado()
        {
            // TODO: Desarrolle su Codigo Aqui.
            return new CG_REF_CODES_RDN().CG_REF_CODES_listado();
        }

        public List<CG_REF_CODES_DTO> qry_CG_REF_CODES_filtrado(CG_REF_CODES_DTO precDto)
        {
            // TODO: Desarrolle su Codigo Aqui.
            return new CG_REF_CODES_RDN().CG_REF_CODES_filtrado(precDto);
        }
    }
   
}