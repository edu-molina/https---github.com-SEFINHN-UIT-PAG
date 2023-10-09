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
    public class INSTITUCIONES_FILTER : ExpressionBuilder<INSTITUCIONES>
    {
        public override void build(INSTITUCIONES da)
        {
            // TODO: Desarrolle su Codigo Aqui.
            if (da.INSTITUCION > 0) and (col => col.INSTITUCION == da.INSTITUCION);
            if (String.IsNullOrEmpty(da.DESC_INSTITUCION) == false) and(col => col.DESC_INSTITUCION == da.DESC_INSTITUCION);
            if (String.IsNullOrEmpty(da.VIGENTE) == false) and(col => col.VIGENTE == da.VIGENTE);
            if (String.IsNullOrEmpty(da.API_ESTADO) == false) and(col => col.API_ESTADO.Contains(da.API_ESTADO));
        }
    }
}
