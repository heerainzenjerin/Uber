using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDem1.Controllers
{
    public class LoginController : Controller
    {
        //Ramjin
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection frmData)
        {
            return RedirectToAction("Index", "TaxiSearch");
        }
    }
}