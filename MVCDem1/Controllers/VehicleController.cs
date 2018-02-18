using MVCDem1.Models.VechicleNamespace.DataLayer;
using MVCDem1.Models.VechicleNamespace.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDem1.Controllers
{
    public class VehicleController : Controller
    {
        [HttpGet]
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [Authorize]
        public ActionResult Index(FormCollection frmCollection)
        {

            VechicleDataLayer objData = new VechicleDataLayer();
            Vechicle Objvech = new Vechicle
            {
                DriverName = frmCollection["DriverName"].ToString(),
                Rating = frmCollection["Rating"].ToString(),
                vechicleModel = frmCollection["vechicleModel"].ToString(),
                vechicleNo = frmCollection["vechicleNo"].ToString()
            };
            bool Response = objData.InsertVechicleDetails(Objvech);
            if (Response) { ViewBag.Message = "Vehicle details added succesfully"; }
            else { ViewBag.Message = "Internal error occured"; }
            return View();
        }
    }
}