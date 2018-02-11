using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDem1.Controllers
{
    public class TaxiSearchController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection frmCollection)
        {
            string Place = frmCollection["PlaceName"].ToString();
          //  List<string> Data=null;//From database
            return RedirectToAction("Index", "ListTaxi");
        }
    }
}