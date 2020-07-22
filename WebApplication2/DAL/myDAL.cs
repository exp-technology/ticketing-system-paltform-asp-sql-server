using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;


namespace WebApplication2.DAL
{
    //Database Layer of 3 tier architecture
    public class myDAL
    {
        //connection string of the server database
        private static readonly string connString =
            System.Configuration.ConfigurationManager.ConnectionStrings["sqlCon1"].ConnectionString;






        //-----------------------------------------------------------------------------------//
        //																					 //
        //									SIGNUP											 //
        //																					 //
        //-----------------------------------------------------------------------------------//



        /*CHECKS WHETHER IT IS A VALID USER AND RETURN ITS TYPE*/
        public int validateLogin(string Email, string Password, ref int type, ref int id,ref string Users)
        {
            SqlConnection con = new SqlConnection(connString);
            con.Open();

            try
            {

                SqlCommand cmd1 = new SqlCommand("Login", con);
                cmd1.CommandType = CommandType.StoredProcedure;

                /*
                 procedure Login
                 @email varchar(30),
                 @password varchar(20),
                 @status int output,
                 @ID int output,
                 @type int output
                 */


                cmd1.Parameters.Add("@email", SqlDbType.VarChar, 30).Value = Email;
                cmd1.Parameters.Add("@password", SqlDbType.VarChar, 20).Value = Password;

                cmd1.Parameters.Add("@status", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd1.Parameters.Add("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd1.Parameters.Add("@type", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd1.Parameters.Add("@Users", SqlDbType.VarChar, 30).Direction = ParameterDirection.Output;

                cmd1.ExecuteNonQuery();

                int status = (int)cmd1.Parameters["@status"].Value;
                type = (int)cmd1.Parameters["@type"].Value;
                id = (int)cmd1.Parameters["@ID"].Value;
                Users = (cmd1.Parameters["@Users"].Value).ToString();
                
                HttpContext.Current.Session["NameUser"] = Users;
                System.Diagnostics.Debug.WriteLine(HttpContext.Current.Session["NameUser"].ToString());
                return status;
            }

            catch (SqlException ex)
            {
                return -1;
            }

            finally
            {
                con.Close();
            }
        }






        public int validateUser(string Name, string BirthDate, string Email, string Password, string PhoneNo, string gender, string Address,string dept, ref int id)
        {
            //Based on your comment you need to parse the DateTime like:
            DateTime date = DateTime.ParseExact(BirthDate,
                                     "dd-MM-yyyy", null);
            DateTime myDateTime = DateTime.Now.AddDays(1);

            SqlConnection con = new SqlConnection(connString);
            con.Open();

            try
            {

                /*
                  Procedure  UserSignUp
                  @name varchar(20),
                  @phone char(15),
                  @address varchar(40),
                  @date Date,
                  @gender char(1),
                  @password varchar(20),
                  @email varchar(30),
                  @status int output,
                  @ID int output
                  */


                SqlCommand cmd1 = new SqlCommand("UserSignup", con);
                cmd1.CommandType = CommandType.StoredProcedure;

                cmd1.Parameters.Add("@name", SqlDbType.VarChar, 20).Value = Name;
                cmd1.Parameters.Add("@address", SqlDbType.VarChar, 40).Value = Address;
                cmd1.Parameters.Add("@gender", SqlDbType.VarChar, 1).Value = gender;


                
                //cmd1.Parameters.Add("@BirthDate", SqlDbType.Date).Value = myDateTime;
                cmd1.Parameters.Add("@date", SqlDbType.Date).Value = date;
                cmd1.Parameters.Add("@email", SqlDbType.VarChar, 30).Value = Email;
                cmd1.Parameters.Add("@password", SqlDbType.VarChar, 20).Value = Password;
                cmd1.Parameters.Add("@phone", SqlDbType.Char, 15).Value = PhoneNo;
                cmd1.Parameters.Add("@department", SqlDbType.Char, 15).Value = dept;
                cmd1.Parameters.Add("@status", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd1.Parameters.Add("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd1.ExecuteNonQuery();

                int status = (int)cmd1.Parameters["@status"].Value;

                if (status != 0)
                {
                    id = (int)cmd1.Parameters["@ID"].Value;
                }


                return status;
            }

            catch (SqlException ex)
            {
                return -1;
            }

            finally
            {
                con.Close();
            }
        }







        //-----------------------------------------------------------------------------------//
        //                                                                                   //
        //                                       ADMIN                                       //
        //                                                                                   //
        //-----------------------------------------------------------------------------------//
        
        public void AddTicket(string Name, string desc, string TCat, string Assign, string NameUser)
        {
            //Based on your comment you need to parse the DateTime like:
            //DateTime date = DateTime.ParseExact(BirthDate,
            //                         "dd-MM-yyyy", null);
            DateTime myDateTime = DateTime.Now.AddDays(1);
            SqlConnection con = new SqlConnection(connString);
            con.Open();


            SqlCommand cmd = new SqlCommand("AddTicket", con);
            cmd.CommandType = CommandType.StoredProcedure;


            System.Diagnostics.Debug.WriteLine(NameUser +" ini nilai name user di ticket");
            cmd.Parameters.Add("@DateT", SqlDbType.Date).Value = myDateTime;
            cmd.Parameters.Add("@Name", SqlDbType.VarChar, 30).Value = Name;
            cmd.Parameters.Add("@Descriptions", SqlDbType.VarChar, 1000).Value = desc;
            cmd.Parameters.Add("@Users", SqlDbType.VarChar, 30).Value = NameUser;
            cmd.Parameters.Add("@Asignee", SqlDbType.VarChar, 30).Value = Assign;
            cmd.Parameters.Add("@StatusP", SqlDbType.VarChar, 15).Value = "Open";
            cmd.Parameters.Add("@Category", SqlDbType.VarChar, 30).Value = TCat;
         
            cmd.ExecuteNonQuery();
            con.Close();


        }
        
        public int Get_Ticket(int dID, ref string name, ref string date, ref string users, ref string description, ref string category, ref string status, ref string assignee)
        {
            SqlConnection con = new SqlConnection(connString);
            con.Open();


            try
            {
                /*
                procedure Get_Ticket
                @dID int,

                @Name varchar(30) output,
                @DateT Date output,
                @Users varchar(30) output,
                @Descriptions varchar(1000) output,
                @Category varchar(30) output,
                @StatusP varchar(30) output,
                @Asignee varchar(30) output
                 */

                SqlCommand cmd1 = new SqlCommand("Get_Ticket", con);

                cmd1.CommandType = CommandType.StoredProcedure;


                //Inputs
                cmd1.Parameters.Add("@dID", SqlDbType.Int).Value = dID;

                //Outputs
                cmd1.Parameters.Add("@name", SqlDbType.VarChar, 30).Direction = ParameterDirection.Output;
                cmd1.Parameters.Add("@DateT", SqlDbType.VarChar,15).Direction = ParameterDirection.Output;
                cmd1.Parameters.Add("@Users", SqlDbType.VarChar, 30).Direction = ParameterDirection.Output;
                cmd1.Parameters.Add("@Descriptions", SqlDbType.VarChar, 1000).Direction = ParameterDirection.Output;
                cmd1.Parameters.Add("@Category", SqlDbType.VarChar, 30).Direction = ParameterDirection.Output;
                cmd1.Parameters.Add("@StatusP", SqlDbType.VarChar, 30).Direction = ParameterDirection.Output;
                cmd1.Parameters.Add("@Asignee", SqlDbType.VarChar,30).Direction = ParameterDirection.Output;


                cmd1.ExecuteNonQuery();

                /*GETTING OUTPUT*/
                name = (string)cmd1.Parameters["@name"].Value;
                date = (string)cmd1.Parameters["@DateT"].Value;
                users = (string)cmd1.Parameters["@Users"].Value;
                description = (string)cmd1.Parameters["@Descriptions"].Value;
                category = (string)cmd1.Parameters["@Category"].Value;
                status = (string)cmd1.Parameters["@StatusP"].Value;
                assignee = (string)cmd1.Parameters["@Asignee"].Value;



            }

            catch (SqlException ex)
            {
                return -1;
            }

            con.Close();
            return 1;
        }


        


    }


}
