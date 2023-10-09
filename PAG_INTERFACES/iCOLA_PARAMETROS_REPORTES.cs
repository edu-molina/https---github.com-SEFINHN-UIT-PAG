using System;
using System.Collections.Generic;
using PAG_DTO;
using System.ServiceModel;

namespace PAG_INTERFACES
{
    public partial interface iPAG_Services
    {

        [OperationContract]
        List<COLA_PARAMETROS_REPORTES_DTO> qry_COLA_PARAMETROS_REPORTES_listado();
        [OperationContract]
        List<COLA_PARAMETROS_REPORTES_DTO> qry_COLA_PARAMETROS_REPORTES_filtrado(COLA_PARAMETROS_REPORTES_DTO precDto);
        [OperationContract]
        COLA_PARAMETROS_REPORTES_DTO ins_COLA_PARAMETROS_REPORTES_inserta(COLA_PARAMETROS_REPORTES_DTO precDto);
        [OperationContract]
        COLA_PARAMETROS_REPORTES_DTO upd_COLA_PARAMETROS_REPORTES_actualiza(COLA_PARAMETROS_REPORTES_DTO precDto);
        [OperationContract]
        COLA_PARAMETROS_REPORTES_DTO del_COLA_PARAMETROS_REPORTES_elimina(params object[] pkeysDto);
    }
}
