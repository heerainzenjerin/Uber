using MVCDem1.Models.Home.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCDem1.Controllers
{
    public class LoginController : Controller
    {
        //Ramjin
        [HttpGet]
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

    
        [HttpPost]
        [ActionName("Index")]
        public ActionResult IndexPost()
        {
            UserDataLayer dataLayer = new UserDataLayer();

            if (dataLayer.AuthenticateUser(Request.Form["Username"].ToString(), Request.Form["password"].ToString()))
            {
                FormsAuthentication.RedirectFromLoginPage(Request.Form["Username"].ToString(), false);
                return RedirectToAction("Index", "TaxiSearch");
            }

            else
            {
                ViewBag.Message = "Invalid credentails";
                return RedirectToAction("Index", "UnAuthorized");
            }
        }
    }
}