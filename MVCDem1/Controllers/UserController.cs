using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDem1.Models.Home.Properties;
using MVCDem1.Models.Home.DataLayer;

namespace MVCDem1.Controllers
{
    public class UserController : Controller
    {

            [Authorize]
        public ActionResult Index()
        {
            UserDataLayer ObjUserDataLayer = new UserDataLayer();

            List<User> ListUser = ObjUserDataLayer.GetUsers();



            return View(ListUser);
        }
    }
}