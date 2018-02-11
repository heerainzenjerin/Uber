using MVCDem1.Intrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCDem1.Models.Home.Properties
{
    public class User
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
        public int Age { get; set; }
    }


    public class UserReponse
    {
        public ResultCodes ResultCode { get; set; }
        public string Message { get; set; }
    }
}