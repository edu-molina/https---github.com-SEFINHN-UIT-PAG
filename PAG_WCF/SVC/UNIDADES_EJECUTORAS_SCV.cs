using System.Collections.Generic;

using PAG_DTO;
using PAG_INTERFACES;

/// <summary>
/// Clase UNIDADES_EJECUTORAS_SCV
/// </summary>
/// <history>
/// FECHA               REPONSABLE              DESCRIPCION
/// 04/Abril/2017       Elia Enamorado          Creacion de Clase
/// </history>
/// 

// public class UNIDADES_EJECUTORAS_SCV
namespace PAG_WCF
{
    public partial class PAG_Services : iPAG_Services
    {

        public List<UNIDADES_EJECUTORAS_DTO> qry_UNIDADES_EJECUTORAS_listado()
        {
            // TODO: Desarrolle su Codigo Aqui.
            return new UNIDADES_EJECUTORAS_RDN().UNIDADES_EJECUTORAS_listado();
        }

        public List<UNIDADES_EJECUTORAS_DTO> qry_UNIDADES_EJECUTORAS_filtrado(UNIDADES_EJECUTORAS_DTO precDto)
        {
            // TODO: Desarrolle su Codigo Aqui.
            return new UNIDADES_EJECUTORAS_RDN().UNIDADES_EJECUTORAS_filtrado(precDto);
        }
    }

}
