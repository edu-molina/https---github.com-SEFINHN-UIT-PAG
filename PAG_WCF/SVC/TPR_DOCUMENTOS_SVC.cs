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
        public List<TPR_DOCUMENTOS_DTO> qry_TPR_DOCUMENTOS_listado()
        {
            return new TPR_DOCUMENTOS_RDN().TPR_DOCUMENTOS_listado();
        }

        public List<TPR_DOCUMENTOS_DTO> qry_TPR_DOCUMENTOS_filtrado(TPR_DOCUMENTOS_DTO precDto)
        {
            return new TPR_DOCUMENTOS_RDN().TPR_DOCUMENTOS_filtrado(precDto);
        }

        public TPR_DOCUMENTOS_DTO ins_TPR_DOCUMENTOS_inserta(TPR_DOCUMENTOS_DTO precDto)
        {
            return new TPR_DOCUMENTOS_RDN().TPR_DOCUMENTOS_inserta(precDto);
        }

        public TPR_DOCUMENTOS_DTO upd_TPR_DOCUMENTOS_actualiza(TPR_DOCUMENTOS_DTO precDto)
        {
            return new TPR_DOCUMENTOS_RDN().TPR_DOCUMENTOS_actualiza(precDto);
        }

        public TPR_DOCUMENTOS_DTO del_TPR_DOCUMENTOS_elimina(params object[] pkeysDto)
        {
            return new TPR_DOCUMENTOS_RDN().TPR_DOCUMENTOS_elimina(pkeysDto);
        }
    }
}