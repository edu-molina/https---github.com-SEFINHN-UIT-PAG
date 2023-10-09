using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using PAG_DTO;
using System.ServiceModel;
using PAG.Helpers;
using System.Configuration;
using PAG_INTERFACES;
using Sefin.Security;

namespace PAG.Controllers
{
    [Authorize]
    public class ReportsController : Controller
    {
        iPAG_Services _service;
        public Models.Funciones fRef = new Models.Funciones();
        public ISecurityManager Security { get; set; }
        public ReportsController()
        {

        }
        public ReportsController(iPAG_Services service)
        {
            this._service = service;
        }
        public int[] idFlujosOperacionesController
        {
            get { return new int[] { 243, 244, 245 }; }
        }
        [HttpGet]
        public ActionResult Index()
        {
            //verificaPerfiles();           

            return View("AngularShared");
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult ReportViewer()
        {
            return PartialView();
        }
        [HttpPost]
        public JsonResult DisplayReporte(COLA_PARAMETROS_REPORTES_DTO param)
        {

            ViewBag.Report_tittle = param.API_ESTADO;
            param.API_ESTADO = "CREADO";
            param = _service.ins_COLA_PARAMETROS_REPORTES_inserta(param);     
            string UrlBase = ConfigurationManager.AppSettings["urlBaseReportes"] + "&" + param.REPORTE + "&" + param.ID ;
            var urlReport = UrlBase;
            byte[] bitMap;
            using (var webClient = new WebClient())
            {
                bitMap = webClient.DownloadData(urlReport);
            }

            var stringMap = Json(bitMap);

            //return Json(bitMap);
            return Json(new salida() { text = bitMap, text64 = Convert.ToBase64String(bitMap) });
        }

    }
    internal class salida
    {
        public Byte[] text { get; set; }
        public string text64 { get; set; }
    }
}
