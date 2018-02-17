 
using MVCDem1.Models.TaxiProp.Datalayer;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaxiModelNamespace;

namespace MVCDem1.Controllers
{
    public class ListTaxiController : Controller
    {
        // GET: ListTask
        public ActionResult Index()
        {
            TaxiDataLayer ObjTaxiDataLayer = new TaxiDataLayer();
            List<Taxi> ListTaxes = ObjTaxiDataLayer.GetTaxes();

            return View(ListTaxes);
        }  
        public ActionResult Map()
        {
            return View( );
        }

        public ActionResult Temp2()
        {
            return View();
        }

      
    }
}