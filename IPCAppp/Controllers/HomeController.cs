using IPCAppp.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace IPCAppp.Controllers
{
    public class HomeController : Controller
    {
        CP_GCSP_DevEntities1 db = new CP_GCSP_DevEntities1();
        public ActionResult Index()
        {
            //GetICTRecord();
            return View();
        }
        [HttpGet]
        public JsonResult GetICTRecord()
        {

           
            List<InterCommunicationTrace> List = db.InterCommunicationTraces.OrderByDescending(x=>x.CreatedDate).Take(500).ToList();         

            return Json(List, JsonRequestBehavior.AllowGet);

        }
        public ActionResult ErrorList()
        {
           
            return View();
        }
        [HttpGet]
        public JsonResult GetLogRecord()
        {

           
            List<Log> List = db.Logs.OrderByDescending(x => x.CreatedDate).Take(500).ToList();

            return Json(List, JsonRequestBehavior.AllowGet);

        }

        public ActionResult ErrorDetails()
        {
          return View();
        }
        [HttpGet]
        // GET: Employees/Details/5
        public ActionResult ErrorDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Log ict = db.Logs.Find(id);

            if (ict == null)
            {
                return HttpNotFound();
            }
            return View(ict);
        }
    }
}