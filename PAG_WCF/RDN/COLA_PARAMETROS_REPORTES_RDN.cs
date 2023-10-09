using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PAG_DTO;
using PAG_DA;
using PAG_MAPPERS;
using System.Transactions;
using System.ServiceModel;
using System.Data;

namespace PAG_WCF
{
    public class COLA_PARAMETROS_REPORTES_RDN
    {
        public List<COLA_PARAMETROS_REPORTES_DTO> COLA_PARAMETROS_REPORTES_listado()
        {
            // TODO: Desarrolle su Codigo Aqui.
            List<COLA_PARAMETROS_REPORTES_DTO> ltCOLA_PARAMETROS_REPORTES = new List<COLA_PARAMETROS_REPORTES_DTO>();
            using (PAG_Entities context = new PAG_Entities(PAG_Security.DictionaryClaims))
            {
                IQueryable<COLA_PARAMETROS_REPORTES> query;
                query = from rec in context.COLA_PARAMETROS_REPORTES
                        orderby rec.ID
                        select rec;
                foreach (var item in query)
                {
                    var prec = item.ToDto();
                    ltCOLA_PARAMETROS_REPORTES.Add(prec);
                }
            }
            return ltCOLA_PARAMETROS_REPORTES;
        }

        // Filtrado.
        public List<COLA_PARAMETROS_REPORTES_DTO> COLA_PARAMETROS_REPORTES_filtrado(COLA_PARAMETROS_REPORTES_DTO precDto)
        {
            // TODO: Desarrolle su Codigo Aqui.
            List<COLA_PARAMETROS_REPORTES_DTO> ltCOLA_PARAMETROS_REPORTES = new List<COLA_PARAMETROS_REPORTES_DTO>();
            using (PAG_Entities context = new PAG_Entities(PAG_Security.DictionaryClaims))
            {
                var entity = precDto.ToEntity();
                var filters = new COLA_PARAMETROS_REPORTES_FILTER();
                var delegates = filters.GetExpression(entity);
                //Aplicar pFilters Dinamico
                if (!filters.hasFilters) { return ltCOLA_PARAMETROS_REPORTES; };
                var filteredCollection = context.COLA_PARAMETROS_REPORTES.OrderBy(x => x.ID).Where(delegates).ToList();
                //Transformar pFilter Dinamico
                foreach (var item in filteredCollection)
                {
                    var prec = item.ToDto();
                    ltCOLA_PARAMETROS_REPORTES.Add(prec);
                }
            }
            return ltCOLA_PARAMETROS_REPORTES;
        }

        private String armaParametro(String parametro, String valor)
        {
            String nuevo = "<" + parametro + ">" + valor + "</" + parametro + ">";
            return nuevo;
        }
        // Inserta.
        public COLA_PARAMETROS_REPORTES_DTO COLA_PARAMETROS_REPORTES_inserta(COLA_PARAMETROS_REPORTES_DTO precDto)
        {
            // TODO: Desarrolle su Codigo Aqui.
            using (PAG_Entities context = new PAG_Entities(PAG_Security.DictionaryClaims))
            {
                // Se arma la caden de seguridad
                if (precDto.PARAMETROS_SESION == null)
                {
                    String seguridad = "";
                    String valor = PAG_Security.DictionaryClaims.ContainsKey(KeysHeadersClaims.Usuario.ToString()) ? PAG_Security.DictionaryClaims[KeysHeadersClaims.Usuario.ToString()] : "PAG";
                    seguridad = seguridad + armaParametro("PA_USR_SESSION_ID_P", valor);
                    valor = PAG_Security.DictionaryClaims.ContainsKey(KeysHeadersClaims.Sistema.ToString()) ? PAG_Security.DictionaryClaims[KeysHeadersClaims.Sistema.ToString()] : "0";
                    seguridad = seguridad + armaParametro("PA_USR_SYSTEM_IDENTIFIER", valor);
                    valor = PAG_Security.DictionaryClaims.ContainsKey(KeysHeadersClaims.TOKEN.ToString()) ? PAG_Security.DictionaryClaims[KeysHeadersClaims.TOKEN.ToString()] : "";
                    seguridad = seguridad + armaParametro("PA_USR_CLIENT_TOKEN", valor);
                    valor = PAG_Security.DictionaryClaims.ContainsKey(KeysHeadersClaims.Usuario.ToString()) ? PAG_Security.DictionaryClaims[KeysHeadersClaims.Usuario.ToString()] : "PAG";
                    seguridad = seguridad + armaParametro("PA_USR_CLIENT_IDENTIFIER", valor);
                    valor = PAG_Security.DictionaryClaims.ContainsKey(KeysHeadersClaims.idFlujo.ToString()) ? PAG_Security.DictionaryClaims[KeysHeadersClaims.idFlujo.ToString()] : "0";
                    seguridad = seguridad + armaParametro("PA_USR_CLIENT_FLUJO", valor);
                    valor = PAG_Security.DictionaryClaims.ContainsKey(KeysHeadersClaims.idOperacion.ToString()) ? PAG_Security.DictionaryClaims[KeysHeadersClaims.idOperacion.ToString()] : "0";
                    seguridad = seguridad + armaParametro("PA_USR_CLIENT_OPERACION", valor);
                    valor = PAG_Security.DictionaryClaims.ContainsKey(KeysHeadersClaims.PerfilActual.ToString()) ? PAG_Security.DictionaryClaims[KeysHeadersClaims.PerfilActual.ToString()] : "0";
                    seguridad = seguridad + armaParametro("PA_USR_PERFIL_IDENTIFIER", valor);
                    valor = "12";
                    seguridad = seguridad + armaParametro("PA_USR_AREA", valor);
                    valor = "16";
                    seguridad = seguridad + armaParametro("PA_USR_GRUPO", valor);
                    valor = "1998";
                    seguridad = seguridad + armaParametro("PA_USR_PERFIL", valor);
                    precDto.PARAMETROS_SESION = seguridad;
                }

                precDto.API_ESTADO = "INICIAL";
                precDto.API_TRANSACCION = "CREAR";
                precDto.USU_CRE = PAG_ServicesUtil.usuarioPAG;
                //Insert NewRow Client
                COLA_PARAMETROS_REPORTES entity = new COLA_PARAMETROS_REPORTES();
                //Begin SavePoint
                using (TransactionScope SavePoint = new TransactionScope())
                {
                    entity = precDto.ToEntity();
                    context.COLA_PARAMETROS_REPORTES.Add(entity);
                    context.SaveChanges();
                    SavePoint.Complete(); //Commit SavePoint

                }//End SavePoint
                 //Retuning NewRow DataBase
                precDto.ID = entity.ID;
                precDto.PARAMETROS = entity.PARAMETROS;
                precDto.PARAMETROS_SESION = entity.PARAMETROS_SESION;
                //Retuning NewAudit DataBase
                precDto.API_ESTADO = entity.API_ESTADO;
                precDto.API_TRANSACCION = entity.API_TRANSACCION;
                precDto.USU_CRE = entity.USU_CRE;
                precDto.FEC_CRE = entity.FEC_CRE;
                precDto.USU_MOD = null;
                precDto.FEC_MOD = null;
            }
            //
            return precDto;
        }

        // Actualiza.
        public COLA_PARAMETROS_REPORTES_DTO COLA_PARAMETROS_REPORTES_actualiza(COLA_PARAMETROS_REPORTES_DTO precDto)
        {
            using (PAG_Entities context = new PAG_Entities(PAG_Security.DictionaryClaims))
            {
                //Validate RDN
                var entity = context.COLA_PARAMETROS_REPORTES.Find(precDto.ID);
                if (entity == null) { throw new FaultException(PAG_ServicesUtil.ObtDescWFCExcepcion("PAG", 2, soloMensaje: true), new FaultCode(PAG_ServicesUtil.ObtCodWFCExcepcion("PAG", 2))); } /*"Registro NO Encontrado."*/
                List<API_TRANSICIONES> transicion = context.API_TRANSICIONES.Where(col => col.TABLA == "COLA_PARAMETROS_REPORTES" && col.ESTADO_INICIAL == entity.API_ESTADO && col.TRANSACCION == precDto.API_TRANSACCION).ToList();
                if (transicion.Count == 0) { throw new FaultException(PAG_ServicesUtil.ObtDescWFCExcepcion("PAG", 4, soloMensaje: true), new FaultCode(PAG_ServicesUtil.ObtCodWFCExcepcion("PAG", 4))); } /*"Transición NO Definida en Flujo del Registro."*/
                //Assign Data NewRow
                var pEntity = precDto.ToEntity();
                entity.ID = pEntity.ID;
                entity.PARAMETROS = pEntity.PARAMETROS;
                entity.PARAMETROS_SESION = pEntity.PARAMETROS_SESION;
                entity.API_TRANSACCION = pEntity.API_TRANSACCION;
                entity.USU_MOD = PAG_ServicesUtil.usuarioPAG;
                //Update NewRow Cliente
                //Begin SavePoint
                using (TransactionScope SavePoint = new TransactionScope())
                {
                    context.COLA_PARAMETROS_REPORTES.Attach(entity);
                    var entry = context.Entry(entity);
                    entry.State = EntityState.Modified;
                    context.SaveChanges();
                    context.Entry(entity).Reload();
                    SavePoint.Complete(); //Commit SavePoint
                }//End SavePoint
                 //Retuning NewAudit DataBase
                precDto.PARAMETROS = entity.PARAMETROS;
                precDto.PARAMETROS_SESION = entity.PARAMETROS_SESION;
                precDto.API_ESTADO = entity.API_ESTADO;
                precDto.API_TRANSACCION = entity.API_TRANSACCION;
                precDto.USU_MOD = entity.USU_MOD;
                precDto.FEC_MOD = entity.FEC_MOD;
            }
            return precDto;        
        }
        public COLA_PARAMETROS_REPORTES_DTO COLA_PARAMETROS_REPORTES_elimina(params object[] pkeysDto)
        {
            throw new FaultException("PAG-00001 Administrado por el àrea de desarrollo", new FaultCode("PAG-00001"));
        }
    }
}