using System.Collections.Generic;

using PAG_DTO;
using PAG_INTERFACES;

namespace PAG_WCF
{
    public partial class PAG_Services : iPAG_Services
    {
        public List<VM_PAG_LISTA_VALORES_DTO> qry_VM_PAG_LISTA_VALORES_listado()
        {
            // TODO: Desarrolle su Codigo Aqui.
            return new VM_PAG_LISTA_VALORES_RDN().VM_PAG_LISTA_VALORES_listado();
        }

        public List<VM_PAG_LISTA_VALORES_DTO> qry_VM_PAG_LISTA_VALORES_filtrado(VM_PAG_LISTA_VALORES_DTO precDto)
        {
            // TODO: Desarrolle su Codigo Aqui.
            return new VM_PAG_LISTA_VALORES_RDN().VM_PAG_LISTA_VALORES_filtrado(precDto);
        }
        public List<VM_PAG_LISTA_VALORES_DTO> qry_VM_PAG_LISTA_VALORES_filtradoDocto(DTP_DETALLES_DET_DTO precDetalle)
        {
            return new VM_PAG_LISTA_VALORES_RDN().VM_PAG_LISTA_VALORES_filtradoDocto(precDetalle);
        }
    }
}