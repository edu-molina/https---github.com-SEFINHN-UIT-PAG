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
        public List<DTP_TIPOS_PROGRA_CAB_DTO> qry_DTP_TIPOS_PROGRA_CAB_listado()
        {
            return new DTP_TIPOS_PROGRA_CAB_RDN().DTP_TIPOS_PROGRA_CAB_listado();
        }

        public List<DTP_TIPOS_PROGRA_CAB_DTO> qry_DTP_TIPOS_PROGRA_CAB_filtrado(DTP_TIPOS_PROGRA_CAB_DTO precDto)
        {
            return new DTP_TIPOS_PROGRA_CAB_RDN().DTP_TIPOS_PROGRA_CAB_filtrado(precDto);
        }

        public DTP_TIPOS_PROGRA_CAB_DTO ins_DTP_TIPOS_PROGRA_CAB_inserta(DTP_TIPOS_PROGRA_CAB_DTO precDto)
        {
            return new DTP_TIPOS_PROGRA_CAB_RDN().DTP_TIPOS_PROGRA_CAB_inserta(precDto);
        }

        public DTP_TIPOS_PROGRA_CAB_DTO upd_DTP_TIPOS_PROGRA_CAB_actualiza(DTP_TIPOS_PROGRA_CAB_DTO precDto)
        {
            return new DTP_TIPOS_PROGRA_CAB_RDN().DTP_TIPOS_PROGRA_CAB_actualiza(precDto);
        }

        public DTP_TIPOS_PROGRA_CAB_DTO del_DTP_TIPOS_PROGRA_CAB_elimina(DTP_TIPOS_PROGRA_CAB_DTO precDto)
        {
            return new DTP_TIPOS_PROGRA_CAB_RDN().DTP_TIPOS_PROGRA_CAB_elimina(precDto);
        }
        public DTP_TIPOS_PROGRA_CAB_DTO upd_DTP_TIPOS_PROGRA_CAB_verifica(DTP_TIPOS_PROGRA_CAB_DTO precDto)
        {
            return new DTP_TIPOS_PROGRA_CAB_RDN().upd_DTP_TIPOS_PROGRA_CAB_verifica(precDto);
        }
        public DTP_TIPOS_PROGRA_CAB_DTO upd_DTP_TIPOS_PROGRA_CAB_desverifica(DTP_TIPOS_PROGRA_CAB_DTO precDto)
        {
            return new DTP_TIPOS_PROGRA_CAB_RDN().upd_DTP_TIPOS_PROGRA_CAB_desverifica(precDto);
        }
        public DTP_TIPOS_PROGRA_CAB_DTO upd_DTP_TIPOS_PROGRA_CAB_aprueba(DTP_TIPOS_PROGRA_CAB_DTO precDto)
        {
            return new DTP_TIPOS_PROGRA_CAB_RDN().upd_DTP_TIPOS_PROGRA_CAB_aprueba(precDto);
        }
    }
}
