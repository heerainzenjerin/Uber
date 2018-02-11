using System;
using System.Collections.Generic;
using System.Linq;

using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using MVCDem1.Intrastructure;
using TaxiModelNamespace;


namespace MVCDem1.Models.TaxiProp.Datalayer
{
    //
    public class TaxiDataLayer
    {
        public List<Taxi> GetTaxes()
        {
            List<Taxi> ObjListTaxi = new List<Taxi>();

            using(SqlConnection con = new SqlConnection(Connect.GetSqlConnectionString()))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Select * from HEERA_TAXI", con);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    if(rdr.HasRows)
                    {
                        while(rdr.Read())
                        {
                            Taxi ObjTaxi = new Taxi();
                            ObjTaxi.DriverName = rdr["DriverName"].ToString();
                            ObjTaxi.VehicleNo = rdr["vechicleNo"].ToString();
                            ObjTaxi.VehicleModel = rdr["vechicleModel"].ToString();
                            ObjTaxi.Rating = rdr["Rating"].ToString();
                            ObjListTaxi.Add(ObjTaxi);
                        }
                    }


                }
                catch (Exception ex)
                {
                    
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }
             


            return ObjListTaxi;
        }
    }
}