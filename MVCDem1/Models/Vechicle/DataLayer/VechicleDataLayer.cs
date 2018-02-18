using MVCDem1.Models.VechicleNamespace.Properties;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MVCDem1.Models.VechicleNamespace.DataLayer
{
    public class VechicleDataLayer
    {

        public bool InsertVechicleDetails(Vechicle ObjVechicle)
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["MVCDemo1"].ConnectionString.ToString();
           
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO [Uber].[HEERA_TAXI]([DriverName],[vechicleNo],[vechicleModel],[Rating]) VALUES(@DriverName,@vechicleNo,@vechicleModel,@Rating)", con);
                    cmd.CommandType = CommandType.Text;


                    cmd.Parameters.AddWithValue("@DriverName", ObjVechicle.DriverName);
                    cmd.Parameters.AddWithValue("@vechicleNo", ObjVechicle.vechicleNo);
                    cmd.Parameters.AddWithValue("@vechicleModel", ObjVechicle.vechicleModel);
                    cmd.Parameters.AddWithValue("@Rating", ObjVechicle.Rating);
                    cmd.ExecuteNonQuery();
                    return true;

                   


                }
                catch (Exception ex)
                {

                    return true;
                }
                finally
                {
                    con.Close();
                }

            }

           

        }
    }
}