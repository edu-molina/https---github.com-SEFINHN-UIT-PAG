//------------------------------------------------------------------------------
//                         Secretaria de Finanzas
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using PAG_DTO;
using PAG_INTERFACES;
using System.Collections.Generic;

namespace PAG_WCF
{


    public partial class PAG_Services : iPAG_Services
    {
        public List<DLB_LIB_BOLSON_DET_DTO> qry_DLB_LIB_BOLSON_DET_listado()
        {
            return new DLB_LIB_BOLSON_DET_RDN().DLB_LIB_BOLSON_DET_listado();
        }

        public List<DLB_LIB_BOLSON_DET_DTO> qry_DLB_LIB_BOLSON_DET_filtrado(DLB_LIB_BOLSON_DET_DTO precDto)
        {
            return new DLB_LIB_BOLSON_DET_RDN().DLB_LIB_BOLSON_DET_filtrado(precDto);
        }

        public DLB_LIB_BOLSON_DET_DTO ins_DLB_LIB_BOLSON_DET_inserta(DLB_LIB_BOLSON_DET_DTO precDto)
        {
            return new DLB_LIB_BOLSON_DET_RDN().DLB_LIB_BOLSON_DET_inserta(precDto);
        }

        public List<DLB_LIB_BOLSON_DET_DTO> ins_DLB_LIB_BOLSON_DET_insertaArreglo(List<DLB_LIB_BOLSON_DET_DTO> precDto)
        {
            return new DLB_LIB_BOLSON_DET_RDN().DLB_LIB_BOLSON_DET_insertaArreglo(precDto);
        }

        public DLB_LIB_BOLSON_DET_DTO upd_DLB_LIB_BOLSON_DET_actualiza(DLB_LIB_BOLSON_DET_DTO precDto)
        {
            return new DLB_LIB_BOLSON_DET_RDN().DLB_LIB_BOLSON_DET_actualiza(precDto);
        }

        public DLB_LIB_BOLSON_DET_DTO del_DLB_LIB_BOLSON_DET_elimina(params object[] pkeysDto)
        {
            return new DLB_LIB_BOLSON_DET_RDN().DLB_LIB_BOLSON_DET_elimina(pkeysDto);
        }
        public void del_DLB_LIB_BOLSON_DET_borrar(DLB_LIB_BOLSON_DET_DTO precDto)
        {
            new DLB_LIB_BOLSON_DET_RDN().DLB_LIB_BOLSON_DET_borrar(precDto);
        }
        
    }
}