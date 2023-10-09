using PAG_DA;
using PAG_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAG_MAPPERS
{
    public static class VM_PAG_LISTA_VALORES_MAPPERS
    {
        public static VM_PAG_LISTA_VALORES_DTO ToDto(this VM_PAG_LISTA_VALORES entity)
        {
            VM_PAG_LISTA_VALORES_DTO dto = new VM_PAG_LISTA_VALORES_DTO();
            dto.LLAVE_VIEW = entity.LLAVE_VIEW;
            dto.ID_COLUMNA = entity.ID_COLUMNA;
            dto.DESC_COLUMNA = entity.DESC_COLUMNA;
            dto.TABLA = entity.TABLA;
            dto.COLUMNA = entity.COLUMNA;
            dto.TIPO_VALOR = entity.TIPO_VALOR;
            dto.VALOR = entity.VALOR;
            dto.DESCRIPCION = entity.DESCRIPCION;
            dto.OTROS_VALORES = entity.OTROS_VALORES;
            return dto;
        }

        public static VM_PAG_LISTA_VALORES ToEntity(this VM_PAG_LISTA_VALORES_DTO dto)
        {
            VM_PAG_LISTA_VALORES entity = new VM_PAG_LISTA_VALORES();
            entity.LLAVE_VIEW = dto.LLAVE_VIEW;
            entity.ID_COLUMNA = dto.ID_COLUMNA;
            entity.DESC_COLUMNA = dto.DESC_COLUMNA;
            entity.TABLA = dto.TABLA;
            entity.COLUMNA = dto.COLUMNA;
            entity.TIPO_VALOR = dto.TIPO_VALOR;
            entity.VALOR = dto.VALOR;
            entity.DESCRIPCION = dto.DESCRIPCION;
            entity.OTROS_VALORES = dto.OTROS_VALORES;
            return entity;
        }
    }
}
