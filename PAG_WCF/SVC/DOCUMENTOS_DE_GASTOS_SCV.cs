using System.Collections.Generic;

using PAG_DTO;
using PAG_INTERFACES;


/// <summary>
/// Clase DOCUMENTOS_DE_GASTOS_SCV
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

        public List<DOCUMENTOS_DE_GASTOS_DTO> qry_DOCUMENTOS_DE_GASTOS_listado()
        {
            // TODO: Desarrolle su Codigo Aqui.
            return new DOCUMENTOS_DE_GASTOS_RDN().DOCUMENTOS_DE_GASTOS_listado();
        }

        public List<DOCUMENTOS_DE_GASTOS_DTO> qry_DOCUMENTOS_DE_GASTOS_filtrado(DOCUMENTOS_DE_GASTOS_DTO precDto)
        {
            // TODO: Desarrolle su Codigo Aqui.
            return new DOCUMENTOS_DE_GASTOS_RDN().DOCUMENTOS_DE_GASTOS_filtrado(precDto);
        }
    }

}
