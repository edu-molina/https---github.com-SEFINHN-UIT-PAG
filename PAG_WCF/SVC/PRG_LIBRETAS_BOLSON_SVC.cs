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


namespace PAG_WCF
{
    
    
    public partial class PAG_Services : iPAG_Services
    {
        public List<PRG_LIBRETAS_BOLSON_DTO> qry_PRG_LIBRETAS_BOLSON_listado()
        {
            return new PRG_LIBRETAS_BOLSON_RDN().PRG_LIBRETAS_BOLSON_listado();
        }

        public List<PRG_LIBRETAS_BOLSON_DTO> qry_PRG_LIBRETAS_BOLSON_filtrado(PRG_LIBRETAS_BOLSON_DTO precDto)
        {
            return new PRG_LIBRETAS_BOLSON_RDN().PRG_LIBRETAS_BOLSON_filtrado(precDto);
        }

        public PRG_LIBRETAS_BOLSON_DTO ins_PRG_LIBRETAS_BOLSON_inserta(PRG_LIBRETAS_BOLSON_DTO precDto)
        {
            return new PRG_LIBRETAS_BOLSON_RDN().PRG_LIBRETAS_BOLSON_inserta(precDto);
        }

        public PRG_LIBRETAS_BOLSON_DTO upd_PRG_LIBRETAS_BOLSON_actualiza(PRG_LIBRETAS_BOLSON_DTO precDto)
        {
            return new PRG_LIBRETAS_BOLSON_RDN().PRG_LIBRETAS_BOLSON_actualiza(precDto);
        }

        public PRG_LIBRETAS_BOLSON_DTO del_PRG_LIBRETAS_BOLSON_elimina(params object[] pkeysDto)
        {
            return new PRG_LIBRETAS_BOLSON_RDN().PRG_LIBRETAS_BOLSON_elimina(pkeysDto);
        }

        public List<PRG_LIBRETAS_BOLSON_DTO> qry_PRG_LIBRETAS_BOLSON_filtradoDocto(DLB_LIB_BOLSON_DET_DTO precDetalle)
        {
            return new PRG_LIBRETAS_BOLSON_RDN().PRG_LIBRETAS_BOLSON_filtradoDocto(precDetalle);
        }
    }
}
