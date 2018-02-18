﻿using System;
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
            return View();
        }

    
        [HttpPost]
        [ActionName("Index")]
        public ActionResult IndexPost()
        {
            if (FormsAuthentication.Authenticate(Request.Form["Username"].ToString(), Request.Form["password"].ToString()))
            {
                FormsAuthentication.RedirectFromLoginPage(Request.Form["Username"].ToString(), false);
                return RedirectToAction("Index", "TaxiSearch");
            }

            else
            {
                Response.Write("INvalid user");
                return RedirectToAction("Index","Login");
            }
        }
    }
}