using IPCAppp.Context;
using IPCAppp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace IPCAppp.Controllers
{
    public class InterProcessController : Controller
    {
        // GET: InterProcess
        CP_GCSP_DevEntities1 dbObject = new CP_GCSP_DevEntities1();
        [HttpGet]
        public ActionResult InterProcess()
        {
            //var aa = dbObject.InterCommunicationTraces.ToList();
            return View(GetCustomers(1));
        }
        [HttpPost]
        public ActionResult InterProcess(int currentPageIndex)
        {
            return View(this.GetCustomers(currentPageIndex));
        }
        [HttpGet]
        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            InterCommunicationTrace ict = dbObject.InterCommunicationTraces.Find(id);

            if (ict == null)
            {
                return HttpNotFound();
            }
            return View(ict);
        }
        private CustomerModel GetCustomers(int currentPage)
        {
            int maxRows = 50;
            using (CP_GCSP_DevEntities1 entities = new CP_GCSP_DevEntities1())
            {
                CustomerModel customerModel = new CustomerModel();

                customerModel.InterCommunicationTraces = (from ict in entities.InterCommunicationTraces
                                                          select ict)
                            .OrderByDescending(ict => ict.CreatedDate)
                            .Skip((currentPage - 1) * maxRows)
                            .Take(maxRows).ToList();

                double pageCount = (double)((decimal)entities.InterCommunicationTraces.Count() / Convert.ToDecimal(maxRows));
                customerModel.PageCount = (int)Math.Ceiling(pageCount);

                customerModel.CurrentPageIndex = currentPage;

                return customerModel;
            }
        }
    }
}