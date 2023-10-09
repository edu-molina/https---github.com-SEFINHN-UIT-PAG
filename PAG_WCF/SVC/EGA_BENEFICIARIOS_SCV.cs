using System.Collections.Generic;

using PAG_DTO;
using PAG_INTERFACES;


/// <summary>
/// Clase EGA_BENEFICIARIOS_SCV
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

        public List<EGA_BENEFICIARIOS_DTO> qry_EGA_BENEFICIARIOS_listado()
        {
            // TODO: Desarrolle su Codigo Aqui.
            return new EGA_BENEFICIARIOS_RDN().EGA_BENEFICIARIOS_listado();
        }

        public List<EGA_BENEFICIARIOS_DTO> qry_EGA_BENEFICIARIOS_filtrado(EGA_BENEFICIARIOS_DTO precDto)
        {
            // TODO: Desarrolle su Codigo Aqui.
            return new EGA_BENEFICIARIOS_RDN().EGA_BENEFICIARIOS_filtrado(precDto);
        }
    }

}
