using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication2.DAL;
using System.Data;


namespace WebApplication2
{
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["idoriginal"] = "";
            

        }

        //-----------------------Function1--------------------------//
        protected void loginV(object sender, EventArgs e)
        {
            string email = loginEmail.Text;
            string password = loginPassword.Text;

            myDAL objmyDAl = new myDAL();

            int status = 0;
            int type = 0;
            int id = 0;
            string Users1 = "";

            status = objmyDAl.validateLogin(email, password, ref type, ref id, ref Users1) ;

            if (status == 0)
            {
                Session["idoriginal"] = id;
                //Session["NameUser"] = Users1;
                //System.Diagnostics.Debug.WriteLine(Users1);
                if (type == 1)
                {
                    Session["NameUser"] = Users1;
                    Response.BufferOutput = true;
                    Response.Redirect("~/Admin/Home.aspx");
                    return;
                }
            }            
            else if (status == 1)
            {
                Response.Write("<script>alert('Email not found. Try Again !');</script>");
            }

            else if (status == 2)
            {
                Response.Write("<script>alert('Incorrect Password. Try Again !');</script>");
            }

            else if (status == -1)
            {
                Response.Write("<script>alert('There was some error. Try Again !');</script>");
            }
        }




        //-----------------------Function2--------------------------//
        protected void signupV(object sender, EventArgs e)
        {
            string Name = sName.Text;
            string BirthDate = sBirthDate.Text;
            string Email = sEmail.Text;
            string Password = sPassword.Text;
            string PhoneNo = Phone.Text;
            string Addr = Address.Text;
            int dept = Convert.ToInt32(Division.SelectedValue);
            string deptS = (Division.SelectedItem).ToString();
            System.Diagnostics.Debug.WriteLine(dept.ToString());
            string gender = Request.Form["Gender"].ToString();
            string[] hasil_string = BirthDate.Split('-');
            string BirthDate2 = hasil_string[2] + "-" + hasil_string[1] + "-" + hasil_string[0];

            Session["NameUser"] = Name;


            myDAL objmyDAl = new myDAL();

            int id = 0;

            


            //status == 0 failure
            if(dept == 0)
            {
               Response.Write("<script>alert('please choose your division.');</script>");
            }
            else
            {
                int status = objmyDAl.validateUser(Name, BirthDate, Email, Password, PhoneNo, gender, Addr,deptS, ref id);
                if (status == 0)
                {
                    Response.Write("<script>alert('Email already exists. Please choose a different one.');</script>");
                }

                else if (status == 1)
                {
                    Session["idoriginal"] = id;

                    //Response.Write("<script>alert('Registration Successful !');</script>");

                    Response.BufferOutput = true;
                    Response.Redirect("~/Admin/Home.aspx");
                }

                else if (status == -1)
                {
                    Response.Write("<script>alert('There was some error. Try again !');</script>");
                }
            }
            

        }

            //Enter new function here//
    }

}