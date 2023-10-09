using System.Collections.Generic;
using SAS_DTO;

namespace Sefin.Security.Interfaces
{
    public interface IDecoratorSessionVariables
    {
        string sessionID { get; }
        UsuarioClaim Claims { get; set; }
        AUX_SEGURIDAD_DTO Permisos { get; set; }
        IEnumerable<AUX_SEGURIDAD_OPERACIONACCION_DTO> OperacionesActuales { get; set; }
        bool isClaimsEmpty { get; }
        bool isPermisosEmpty { get; }
        void clean();
    }

    //public class DecoratorSessionVariables : IDecoratorSessionVariables
    //{
    //    public UsuarioClaim Claims
    //    {
    //        get { return (dynamic)HttpContext.Current.Session["Claims"]; }
    //        set { HttpContext.Current.Session["Claims"] = value; }
    //    }

    //    public AUX_SEGURIDAD_DTO Permisos
    //    {
    //        get { return(dynamic) HttpContext.Current.Session["Permisos"]; }
    //         set { HttpContext.Current.Session["Permisos"] = value; }
    //    }

    //    public string sessionID { get { return HttpContext.Current.Session.SessionID; } }

    //    public IEnumerable<AUX_SEGURIDAD_OPERACIONACCION_DTO> OperacionesActuales
    //    {
    //        get
    //        {
    //            if ((dynamic)HttpContext.Current.Session["operacionesActuales"]== null) return new List<AUX_SEGURIDAD_OPERACIONACCION_DTO>();
    //            return (dynamic)HttpContext.Current.Session["operacionesActuales"];
    //        }
    //        set { HttpContext.Current.Session["operacionesActuales"] = value; }
    //    } 
    //}
}