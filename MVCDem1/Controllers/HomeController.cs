
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDem1.Models.Home.Properties;
using MVCDem1.Models.Home.DataLayer;
using MVCDem1.Intrastructure;

namespace MVCDem1.Controllers
{

    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            
             
            return View();
        }
        [HttpPost]
        public ActionResult Index(FormCollection frmCollection)
        {
            if(frmCollection["Password"].ToString()==frmCollection["cnfPassword"].ToString())
            {
              
                User ObjUser = new User();
                ObjUser.FirstName = frmCollection["FName"];
                ObjUser.LastName = frmCollection["LName"];
                ObjUser.Email = frmCollection["Email"];
                ObjUser.Password = frmCollection["Password"];
                ObjUser.    Age = 34;

                UserDataLayer UserDataLayer = new UserDataLayer();

             UserReponse Response=UserDataLayer.InsertUserAndGetResponse(ObjUser);

                if(Response.ResultCode==ResultCodes.Error)
                {
                    ViewBag.InfoError = Response.Message;

                }
                else if (Response.ResultCode == ResultCodes.Exists)
                {
                    ViewBag.InfoMessage = Response.Message;

                }
                else if (Response.ResultCode==ResultCodes.Success)
                {
                    ViewBag.InfoMessage = Response.Message;
                }


            }
            else
            {
                ViewBag.Message = "Password doesnt Match!!!";
            }

    

            return View();
        }

        public ActionResult ViewUser()
        {
            UserDataLayer objData = new UserDataLayer();
            List<User> ListUser = objData.GetUsers();

            return View(ListUser);
        }

    }
}