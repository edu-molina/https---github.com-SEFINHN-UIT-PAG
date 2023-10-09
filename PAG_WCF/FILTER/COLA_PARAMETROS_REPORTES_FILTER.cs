using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PAG_DA;
using PAG_DTO;

namespace PAG_WCF
{
    public class COLA_PARAMETROS_REPORTES_FILTER : ExpressionBuilder<COLA_PARAMETROS_REPORTES>
    {
        public override void build(COLA_PARAMETROS_REPORTES da)
        {
            and(col => col.ID == da.ID);
            if (String.IsNullOrEmpty(da.API_ESTADO) == false) and(col => col.API_ESTADO.Contains(da.API_ESTADO));
        }
    }
}