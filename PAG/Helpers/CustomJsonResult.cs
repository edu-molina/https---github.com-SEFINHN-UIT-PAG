using System;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PAG.Helpers
{
    public class CustomJsonResult : JsonResult
    {
        private const string JsonRequest_GetNotAllowed =
            "This request has been blocked because sensitive information could be disclosed to third party web sites when this is used in a GET request. To allow GET requests, set JsonRequestBehavior to AllowGet.";

        public CustomJsonResult()
        {
            MaxJsonLength = 1024000;
            RecursionLimit = 100;
            JsonRequestBehavior = JsonRequestBehavior.AllowGet;
        }

        public int MaxJsonLength { get; set; }
        public int RecursionLimit { get; set; }
        public string jsonData { get; set; }
        public CustomJsonResult AllowGET()
        {
            JsonRequestBehavior =  JsonRequestBehavior.AllowGet;

            return this;
        }
        public JsonResult Json(object o)
        {
            jsonData = JsonConvert.SerializeObject(o/*, new IsoDateTimeConverter() { DateTimeFormat = "yyyy'-'MM'-'dd'T'HH':'mm':'ss.FFFK" }*/);
          //  jsonData = JsonConvert.SerializeObject(o, new JavaScriptDateTimeConverter());

            return this;
        }
        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            if (JsonRequestBehavior == JsonRequestBehavior.DenyGet &&
                String.Equals(context.HttpContext.Request.HttpMethod, "GET", StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException(JsonRequest_GetNotAllowed);
            }

            HttpResponseBase response = context.HttpContext.Response;

            if (!String.IsNullOrEmpty(ContentType))
            {
                response.ContentType = ContentType;
            }
            else
            {
                response.ContentType = "application/json";
            }
            if (ContentEncoding != null)
            {
                response.ContentEncoding = ContentEncoding;
            }
            if (jsonData != null)
            {
               
                response.Write(jsonData);
            }
        }
    }
}