using System.Collections.Generic;
using System.Web;
using SAS_DTO;
using Sefin.Security.Interfaces;

namespace Sefin.Security.Mvc
{
    public class DecoratorSessionVariables : IDecoratorSessionVariables
    {
        public UsuarioClaim Claims
        {
            get
            {
                if (HttpContext.Current.Session["Claims"] == null) return _nullUsuarioClaim;
                return (dynamic) HttpContext.Current.Session["Claims"];
            }
            set { HttpContext.Current.Session["Claims"] = value; }
        }

        public AUX_SEGURIDAD_DTO Permisos
        {
            get
            {
                if (HttpContext.Current.Session["Permisos"] == null) return _nullAuxSeguridadDto;
                return (dynamic) HttpContext.Current.Session["Permisos"];
            }
            set { HttpContext.Current.Session["Permisos"] = value; }
        }

        public string sessionID
        {
            get { return HttpContext.Current.Session.SessionID; }
        }

        public IEnumerable<AUX_SEGURIDAD_OPERACIONACCION_DTO> OperacionesActuales
        {
            get
            {
                if ((dynamic) HttpContext.Current.Session["operacionesActuales"] == null)
                    return new List<AUX_SEGURIDAD_OPERACIONACCION_DTO>();
                return (dynamic) HttpContext.Current.Session["operacionesActuales"];
            }
            set { HttpContext.Current.Session["operacionesActuales"] = value; }
        }

        public bool isClaimsEmpty
        {
            get { return HttpContext.Current.Session["Claims"] == null; }
        }

        public bool isPermisosEmpty
        {
            get { return HttpContext.Current.Session["Permisos"] == null; }
        }



        public void clean()
        {
            Claims = null;
            Permisos = null;
            OperacionesActuales = null;
        }

        private static readonly AUX_SEGURIDAD_DTO _nullAuxSeguridadDto = new AUX_SEGURIDAD_DTO()
        {
            Permisos = new List<string>(),
            GA = string.Empty,
            Gestion = 0,
            Gestiones = new List<decimal>(),
            Institucion = string.Empty,
            PerfilActual = 0,
            OperacionesAcciones = new List<AUX_SEGURIDAD_OPERACIONACCION_DTO>(),
            PerfilPorDefault = 0,
            Perfiles = new List<SAS_PERFILES_DTO>(),
            FlujosOperaciones = new List<AUX_SEGURIDAD_FLUJOS_OPERACION_DTO>(),
            Grupo = 0,
            Menus = new List<SAS_MENUS_DTO>(),
            Sistema = 0,
            TOKEN = string.Empty,
            UE = string.Empty,
            Usuario = string.Empty,
            codigoGA = 0,
            codigoInstitucion = 0,
            codigoUE = 0,
            descripcionGA = string.Empty,
            descripcionInstitucion = string.Empty,
            descripcionUE = string.Empty
        };

        private static readonly UsuarioClaim _nullUsuarioClaim = new UsuarioClaim()
        {
           APELLIDOS = string.Empty,
           CAMBIA_CLAVE = string.Empty,
           CELULAR = string.Empty,
           DIRECCION= string.Empty,
           EMAIL = string.Empty,
           ESTADO = string.Empty,
           PAIS = string.Empty,
           PASSWORD = string.Empty,
           NOMBRES = string.Empty,
           NIVEL_USUARIO = string.Empty,
           NICKNAME = string.Empty,
           IDENTIDAD= string.Empty,
           NUMERO_ACTA= string.Empty,
           RTN= string.Empty,
           ESTADO_LOGIN = string.Empty,
           ES_TEMPORAL = string.Empty,
           FECHA_ACTIVO = string.Empty,
           FECHA_CREACION = string.Empty,
           FECHA_INACTIVO = string.Empty,
           FECHA_MODIFICA = string.Empty,
           FEC_ULT_LOGIN= string.Empty,
           PUESTO = string.Empty,
           PASSWORD_SALT = string.Empty,
           SESION_MULTIPLE= string.Empty,
           TELEFONO = string.Empty,
           TIPO_DOCUMENTO = string.Empty,
           USUARIO= string.Empty,
           ULT_FEC_CAMBIO_CLAVE = string.Empty,
           USUARIO_CREACION = string.Empty,
           USUARIO_MODIFICA = string.Empty,
           VIGENTE= string.Empty,
           ROLES= new List<string>(),
           SISTEMAS= new List<string>(),
        };
    }
}