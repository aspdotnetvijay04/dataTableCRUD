using IPCAppp.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IPCAppp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //GetICTRecord();
            return View();
        }
        [HttpGet]
        public JsonResult GetICTRecord()
        {

            CP_GCSP_DevEntities1 db = new CP_GCSP_DevEntities1();
            List<InterCommunicationTrace> List = db.InterCommunicationTraces.Take(1000).ToList();

            //List<InterCommunicationTrace> List = db.InterCommunicationTraces.Select(x => new InterCommunicationTrace
            //{
            //    ComponentCode = x.ComponentCode,
            //    InternalRefId = x.InternalRefId,
            //    VendorRefId = x.VendorRefId,
            //    IsOutBoundCall = x.IsOutBoundCall,
            //    CreatedDate = x.CreatedDate,
            //    ModifiedDate = x.ModifiedDate
            //}).ToList();

            return Json(List, JsonRequestBehavior.AllowGet);

        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}