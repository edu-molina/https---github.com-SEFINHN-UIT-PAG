using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Agregado por DSA
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace PAG_DA
{
    /// <summary>
    /// Clase PARTIAL Entity Context PAG_Entities
    /// </summary>
    /// <history>
    /// FECHA              REPONSABLE            DESCRIPCION
    /// 26/Mar/2016        Danny Lainez          Creacion de Clase
    /// </history>
    public partial class PAG_Entities : DbContext
    {
        partial void OnContextCreated(System.Collections.Generic.Dictionary<string, string> pDictionaryClaims)
        {
            //Ejecuta Codigo Inicializar Contexto por Usuario
            //Fuente: http://stackoverflow.com/questions/9371200/partial-class-constructors-and-event-handler-registration
            //Fuente Principal: https://anilanar.wordpress.com/2013/07/20/execute-code-before-save-and-after-fetch-in-entity-framework/
            ((IObjectContextAdapter)this).ObjectContext.Connection.Open();
            //this.Database.ExecuteSqlCommand("BEGIN SEGADMIN.K_SEG_CONTEXT.SET_SESSION_ID('" + pUsuario + "'); END;");
            if (pDictionaryClaims != null)
            {
                //Confianza para SAS Claims.
                if ((pDictionaryClaims.ContainsKey("APP_SETVPD") ? pDictionaryClaims["APP_SETVPD"] : "S") == "N" &&
                    (pDictionaryClaims.ContainsKey(KeysHeadersClaims.Sistema.ToString()) ? pDictionaryClaims[KeysHeadersClaims.Sistema.ToString()] : "0") == "4" &&
                    (pDictionaryClaims.ContainsKey(KeysHeadersClaims.Sistema.ToString()) ? pDictionaryClaims[KeysHeadersClaims.TOKEN.ToString()] : "0") == "382D5F3BED803C75E054C6388C585879")
                {
                    return;
                }
                else //Para Todas las peticiones se requiere Claims.
                {

                    this.Database.ExecuteSqlCommand(
                        "  DECLARE inicio BOOLEAN;  " +
                        "  BEGIN  " +
                        ///Gestionar Sesion BDD como Usuario de Aplicacion.
                        "  MDSAS.K_SAS_CONTEXT.P_SAS_SET_SESSION_ID(SESSION_ID_P => '" + (pDictionaryClaims.ContainsKey(KeysHeadersClaims.Usuario.ToString()) ? pDictionaryClaims[KeysHeadersClaims.Usuario.ToString()] : "PAG") + "');  " +
                        ///Gestionar Sesion BDD Configurar Variables Globales del Entorno.
                        "  MDSAS.K_SAS_CONTEXT.P_SAS_SET_CTX(SEC_LEVEL_ATTR => 'SYSTEM_IDENTIFIER', SEC_LEVEL_VAL => '" + (pDictionaryClaims.ContainsKey(KeysHeadersClaims.Sistema.ToString()) ? pDictionaryClaims[KeysHeadersClaims.Sistema.ToString()] : "0") + "');  " +
                        "  MDSAS.K_SAS_CONTEXT.P_SAS_SET_CTX(SEC_LEVEL_ATTR => 'CLIENT_TOKEN', SEC_LEVEL_VAL => '" + (pDictionaryClaims.ContainsKey(KeysHeadersClaims.TOKEN.ToString()) ? pDictionaryClaims[KeysHeadersClaims.TOKEN.ToString()] : "") + "');  " +
                        "  MDSAS.K_SAS_CONTEXT.P_SAS_SET_CTX(SEC_LEVEL_ATTR => 'CLIENT_IDENTIFIER', SEC_LEVEL_VAL => '" + (pDictionaryClaims.ContainsKey(KeysHeadersClaims.Usuario.ToString()) ? pDictionaryClaims[KeysHeadersClaims.Usuario.ToString()] : "PAG") + "');  " +
                        "  MDSAS.K_SAS_CONTEXT.P_SAS_SET_CTX(SEC_LEVEL_ATTR => 'CLIENT_FLUJO', SEC_LEVEL_VAL => '" + (pDictionaryClaims.ContainsKey(KeysHeadersClaims.idFlujo.ToString()) ? pDictionaryClaims[KeysHeadersClaims.idFlujo.ToString()] : "0") + "');  " +
                        "  MDSAS.K_SAS_CONTEXT.P_SAS_SET_CTX(SEC_LEVEL_ATTR => 'CLIENT_OPERACION', SEC_LEVEL_VAL => '" + (pDictionaryClaims.ContainsKey(KeysHeadersClaims.idOperacion.ToString()) ? pDictionaryClaims[KeysHeadersClaims.idOperacion.ToString()] : "0") + "');  " +
                        "  MDSAS.K_SAS_CONTEXT.P_SAS_SET_CTX(SEC_LEVEL_ATTR => 'PERFIL_IDENTIFIER', SEC_LEVEL_VAL => '" + (pDictionaryClaims.ContainsKey(KeysHeadersClaims.PerfilActual.ToString()) ? pDictionaryClaims[KeysHeadersClaims.PerfilActual.ToString()] : "0") + "');  " +
                        "  inicio := SIAFI.K_SEGURIDAD.F_INICIALIZAR();  " +
                        "  inicio := SIAFI.K_SEGURIDAD.F_CAMBIAR_PERFIL(PA_AREA => 12, PA_GRUPO => 16, PA_PERFIL => 1998); " +
                        "  END;  ");
                };
            };
        }

        protected override void Dispose(bool disposing)
        {
            if (((IObjectContextAdapter)this).ObjectContext.Connection.State != System.Data.ConnectionState.Closed)
            { ((IObjectContextAdapter)this).ObjectContext.Connection.Close(); }
            base.Dispose(disposing: disposing);
        }
    }
    public enum keysClaims
    {
        NAME,
        NICKNAME,
        NAMEIDENTIFIER,
        EMAILADDRESS,
        GIVENNAME,
        SURNAME,
        COUNTRY,
        RTN,
        HOMEPHONE,
        TIPODOCUMENTO,
        PUESTO,
        SYSTEM,
        AUTHENTICATIONMETHOD,
        AUTHENTICATIONINSTANT,
        APP_TOKEN,
        APP_IDSESSION,
        APP_IDSYSTEM,
        APP_IDFLUJO,
        APP_IDOPERACION,
        APP_IDPERFIL,
        APP_IDGESTION,
        APP_IDETAPAGESTION
    }

    public enum KeysHeadersClaims
    {
        PerfilPorDefault,
        PerfilActual,
        Sistema,
        Usuario,
        TOKEN,
        Gestion,
        Grupo,
        Institucion,
        codigoInstitucion,
        descripcionInstitucion,
        GA,
        codigoGA,
        descripcionGA,
        UE,
        codigoUE,
        descripcionUE,
        idFlujo,
        idOperacion
    }

}

