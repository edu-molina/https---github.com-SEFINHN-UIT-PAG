using System.Web.Mvc;

namespace PAG.Helpers
{
    public static class JsonExtension
    {
        public static JsonResult json(this object valor)
        {
            return new CustomJsonResult().Json(valor);
        }
    }
}