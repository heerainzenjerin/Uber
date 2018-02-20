using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using MVCDem1.Models.Home.Properties;
using MVCDem1.Intrastructure;
using System.Web.Security;


namespace MVCDem1.Models.Home.DataLayer
{
    public class UserDataLayer
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["MVCDemo1"].ConnectionString.ToString();
        public UserReponse InsertUserAndGetResponse(User ObjBindedUser)
        {
            UserReponse Response ;
           using(SqlConnection con = new SqlConnection(ConnectionString))
           {
               try
               {
                   con.Open();
                   SqlCommand cmd = new SqlCommand("SPHeeraUserInsert", con);
                   cmd.CommandType = CommandType.StoredProcedure;

                   string encryptedPassword = FormsAuthentication.
                       HashPasswordForStoringInConfigFile(ObjBindedUser.Password, "SHA1");


                   cmd.Parameters.AddWithValue("@FIRST_NAME", ObjBindedUser.FirstName);
                   cmd.Parameters.AddWithValue("@LAST_NAME", ObjBindedUser.LastName );
                   cmd.Parameters.AddWithValue("@EMAIL", ObjBindedUser.Email);
                   cmd.Parameters.AddWithValue("@PASSWORD", encryptedPassword);
                   cmd.Parameters.AddWithValue("@IsDriver", ObjBindedUser.IsDriver);
                   cmd.Parameters.AddWithValue("@LisenceNo", ObjBindedUser.LisenceNo);
                   string Result =(string)cmd.ExecuteScalar();

                   if (Result == "USER_EXISTS")
                   {
 
                        Response = new UserReponse
                       {
                           Message="User already exists",
                           ResultCode = ResultCodes.Exists
                       };
                       
                   }
                   else if(Result == "USER_INSERTED")
                   {
                       Response = new UserReponse
                       {
                           Message = "User inserted successfully",
                           ResultCode = ResultCodes.Success
                       };
                   }
                   else
                   {
                       Response = new UserReponse
                       {
                           Message = "Some thing went wrong",
                           ResultCode = ResultCodes.Error
                       };
                   }


               }
               catch (Exception ex)
               {

                   Response = new UserReponse
                   {
                       Message = ex.Message,
                       ResultCode = ResultCodes.Error
                   };
               }
               finally
               {
                   con.Close();
               }

           }

            return Response;

        }


        public bool AuthenticateUser(string Email, string Password)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

               
                try
                {
                    con.Open();
           
                    string EncryptedPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(Password, "SHA1");
                    SqlCommand cmd = new SqlCommand("Select * FROM HEERA_USER Where Email=@Email and Password=@Password",con);
                    cmd.Parameters.AddWithValue("@Email", Email);
                    cmd.Parameters.AddWithValue("@Password", EncryptedPassword);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    return rdr.HasRows;
                }
                catch 
                {
                    throw;
                }
                finally
                {
                    con.Close();
                }
            }

        }

        public List<User> GetUsers()
        {
            List<User> ListUser = new List<User>();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select * from HEERA_USER", con);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    if(rdr.HasRows)
                    {
                        while(rdr.Read())
                        {
                            User objUser = new User();
                            objUser.FirstName = rdr["FIRST_NAME"].ToString();
                            objUser.LastName = rdr["LAST_NAME"].ToString();
                            objUser.Email = rdr["EMAIL"].ToString();
                           
                            ListUser.Add(objUser);
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
                return ListUser;
            }
        }



        
    }
}