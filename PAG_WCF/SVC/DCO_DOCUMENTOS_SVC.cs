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
        public List<DCO_DOCUMENTOS_DTO> qry_DCO_DOCUMENTOS_listado()
        {
            return new DCO_DOCUMENTOS_RDN().DCO_DOCUMENTOS_listado();
        }

        public List<DCO_DOCUMENTOS_DTO> qry_DCO_DOCUMENTOS_filtrado(DCO_DOCUMENTOS_DTO precDto)
        {
            return new DCO_DOCUMENTOS_RDN().DCO_DOCUMENTOS_filtrado(precDto);
        }

        public DCO_DOCUMENTOS_DTO ins_DCO_DOCUMENTOS_inserta(DCO_DOCUMENTOS_DTO precDto)
        {
            return new DCO_DOCUMENTOS_RDN().DCO_DOCUMENTOS_inserta(precDto);
        }

        public DCO_DOCUMENTOS_DTO upd_DCO_DOCUMENTOS_actualiza(DCO_DOCUMENTOS_DTO precDto)
        {
            return new DCO_DOCUMENTOS_RDN().DCO_DOCUMENTOS_actualiza(precDto);
        }

        public DCO_DOCUMENTOS_DTO del_DCO_DOCUMENTOS_elimina(params object[] pkeysDto)
        {
            return new DCO_DOCUMENTOS_RDN().DCO_DOCUMENTOS_elimina(pkeysDto);
        }
        
    }
}
