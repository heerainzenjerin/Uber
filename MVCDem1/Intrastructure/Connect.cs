using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace MVCDem1.Intrastructure
{
    public static class Connect
    {
        public static string GetSqlConnectionString()
        {
             string ConnectionString = ConfigurationManager.ConnectionStrings["MVCDemo1"].ConnectionString.ToString();
             return ConnectionString;
        }
    }
}