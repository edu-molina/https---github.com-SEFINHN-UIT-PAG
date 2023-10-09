using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using PAG_DA;
using PAG_DTO;

namespace PAG_WCF
{
    public class OBJETOS_DEL_GASTO_FILTER : ExpressionBuilder<OBJETOS_DEL_GASTO>
    {
        public override void build(OBJETOS_DEL_GASTO da)
        {
            // TODO: Desarrolle su Codigo Aqui.
            if (da.GESTION > 0) and(col => col.GESTION == da.GESTION);
            if (String.IsNullOrEmpty(da.OBJETO) == false) and(col => col.OBJETO == da.OBJETO);
            if (da.GRUPO_OBJETO > 0) and(col => col.GRUPO_OBJETO == da.GRUPO_OBJETO);
            if (da.SUB_GRUPO_OBJETO > 0) and(col => col.SUB_GRUPO_OBJETO == da.SUB_GRUPO_OBJETO);
            if (da.PARTIDA_OBJETO > 0) and(col => col.PARTIDA_OBJETO == da.PARTIDA_OBJETO);
            if (da.SUB_PARTIDA_OBJETO > 0) and(col => col.SUB_PARTIDA_OBJETO == da.SUB_PARTIDA_OBJETO);
            if (String.IsNullOrEmpty(da.DESC_OBJETO) == false) and(col => col.DESC_OBJETO == da.DESC_OBJETO);
            if (String.IsNullOrEmpty(da.VIGENTE) == false) and(col => col.VIGENTE == da.VIGENTE);
            if (String.IsNullOrEmpty(da.API_ESTADO) == false) and(col => col.API_ESTADO.Contains(da.API_ESTADO));
        }
    }
}

