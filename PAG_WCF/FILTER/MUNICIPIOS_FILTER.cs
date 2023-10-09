using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using PAG_DA;
using PAG_DTO;

namespace PAG_WCF
{
    public class MUNICIPIOS_FILTER : ExpressionBuilder<MUNICIPIOS>
    {
        public override void build(MUNICIPIOS da)
        {
            if (da.DEPARTAMENTO > 0) and(col => col.DEPARTAMENTO == da.DEPARTAMENTO);
            if (da.MUNICIPIO > 0) and(col => col.MUNICIPIO == da.MUNICIPIO);
            if (String.IsNullOrEmpty(da.DESC_MUNICIPIO) == false) and(col => col.DESC_MUNICIPIO == da.DESC_MUNICIPIO);
            if (String.IsNullOrEmpty(da.SIGLA_MUNICIPIO) == false) and(col => col.SIGLA_MUNICIPIO.Contains(da.SIGLA_MUNICIPIO));
            if (String.IsNullOrEmpty(da.VIGENTE) == false) and(col => col.VIGENTE.Contains(da.VIGENTE));
            if (String.IsNullOrEmpty(da.API_ESTADO) == false) and(col => col.API_ESTADO.Contains(da.API_ESTADO));
        }
    }
}