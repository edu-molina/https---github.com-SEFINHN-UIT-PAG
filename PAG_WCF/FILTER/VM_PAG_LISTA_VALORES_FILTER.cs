using System;
using PAG_DA;
using PAG_DTO;

namespace PAG_WCF{
    public class VM_PAG_LISTA_VALORES_FILTER : ExpressionBuilder<VM_PAG_LISTA_VALORES>
    {
        public override void build(VM_PAG_LISTA_VALORES da)
        {
            if (da.ID_COLUMNA > 0) and(col => col.ID_COLUMNA == da.ID_COLUMNA);
            if (String.IsNullOrEmpty(da.DESC_COLUMNA) == false) and(col => col.DESC_COLUMNA.Contains(da.DESC_COLUMNA));
            if (String.IsNullOrEmpty(da.TABLA) == false) and(col => col.TABLA == da.TABLA);
            if (String.IsNullOrEmpty(da.COLUMNA) == false) and(col => col.COLUMNA == da.COLUMNA);
            if (String.IsNullOrEmpty(da.TIPO_VALOR) == false) and(col => col.TIPO_VALOR == da.TIPO_VALOR);
            if (String.IsNullOrEmpty(da.VALOR) == false) and(col => col.VALOR == da.VALOR);
            if (String.IsNullOrEmpty(da.DESCRIPCION) == false) and(col=> col.DESCRIPCION.Contains(da.DESCRIPCION));
            if (String.IsNullOrEmpty(da.OTROS_VALORES) == false) and(col => col.OTROS_VALORES.Contains(da.OTROS_VALORES));
        }
    }
}
