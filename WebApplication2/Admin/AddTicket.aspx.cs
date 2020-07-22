using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication2.DAL;

namespace WebApplication2
{
	public partial class TicketRegistrationForm : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            int pid = (int)Session["AccessKeyT"];
            System.Diagnostics.Debug.WriteLine(Session["idoriginal"].ToString());
            
            if (!IsPostBack)
            {
                Label1.Visible = true;
                Label2.Visible = true;
                Label4.Visible = true;
                Label7.Visible = true;
                get_asigneelist();
                if (pid == 0)
                {
                    //Create  a new one
                    TicketID.Visible = false;
                    TicketDate.Visible = false;
                    NameTicket.Visible = true;
                    Owner.Visible = false;
                    Description.Visible = true;
                    TCategoryT.Visible = false;
                    Selectcategory.Visible = false;
                    TCategory.Visible = true;
                    AssignListT.Visible = false;
                    Selectassigne.Visible = false;
                    AssigneeList.Visible = true;
                    Status.Visible = false;
                    IDTValid.Visible = false;
                    NameTValid.Visible = false;
                    Back.Visible = true;
                    Create.Visible = true;
                    Update.Visible = false;
                    Delete.Visible = false;
                    InProg.Visible = false;
                    Done.Visible = false;
                    Closed.Visible = false;


                    Label1.Visible = false;
                    Label2.Visible = false;
                    Label4.Visible = false;
                    Label7.Visible = false;


                }
                else if (pid == 1)
                {
                    //Owner
                    TicketID.Visible = true;
                    TicketDate.Visible = true;
                    NameTicket.Visible = true;
                    Owner.Visible = true;
                    Description.Visible = true;
                    TCategoryT.Visible = true;
                    Selectcategory.Visible = true;
                    TCategory.Visible = true;
                    AssignListT.Visible = true;
                    Selectassigne.Visible = true;
                    AssigneeList.Visible = true;
                    Status.Visible = true;
                    IDTValid.Visible = true;
                    NameTValid.Visible = true;
                    Back.Visible = true;
                    Create.Visible = false;
                    Update.Visible = true;
                    Delete.Visible = true;
                    InProg.Visible = false;
                    Done.Visible = true;
                    Closed.Visible = true;
                    get_ticket_owner();
                }
                else if (pid == 2)
                {
                    //Assignee
                    TicketID.Visible = true;
                    TicketDate.Visible = true;
                    NameTicket.Visible = true;
                    Owner.Visible = true;
                    Description.Visible = true;
                    TCategoryT.Visible = true;
                    Selectcategory.Visible = false;
                    TCategory.Visible = false;
                    AssignListT.Visible = true;
                    Selectassigne.Visible = false;
                    AssigneeList.Visible = false;
                    Status.Visible = true;
                    IDTValid.Visible = false;
                    NameTValid.Visible = false;
                    Back.Visible = true;
                    Create.Visible = false;
                    Update.Visible = false;
                    Delete.Visible = false;
                    InProg.Visible = true;
                    Done.Visible = true;
                    Closed.Visible = true;

                    Label7.Visible = false;
                    get_ticket_assignee();
                }
                else
                {
                    //The other
                    TicketID.Visible = true;
                    TicketDate.Visible = true;
                    NameTicket.Visible = true;
                    Owner.Visible = true;
                    Description.Visible = true;
                    TCategoryT.Visible = true;
                    Selectcategory.Visible = false;
                    TCategory.Visible = false;
                    AssignListT.Visible = true;
                    Selectassigne.Visible = false;
                    AssigneeList.Visible = false;
                    Status.Visible = true;
                    IDTValid.Visible = false;
                    NameTValid.Visible = false;
                    Back.Visible = true;
                    Create.Visible = false;
                    Update.Visible = false;
                    Delete.Visible = false;
                    InProg.Visible = false;
                    Done.Visible = false;
                    Closed.Visible = false;

                    Label7.Visible = false;
                    get_ticket_other();
                }
            }
            
        }

        private void get_ticket_owner()
        {
            myDAL objMyDAL = new myDAL();
            int id_ticket = (int)Session["TID"];
            string Name = "";
            string Date = "";
            string Users = "";
            string Descriptions = "";
            string Category = "";
            string status = "";
            string Assignee = "";
            //            @dID int,

            //@Name varchar(30) output,
            //@DateT Date output,
            //@Users varchar(30) output,
            //@Descriptions varchar(1000) output,
            //@Category varchar(30) output,
            //@StatusP varchar(30) output,
            //@Asignee varchar(30) output
            objMyDAL.Get_Ticket(id_ticket, ref Name, ref Date, ref Users, ref Descriptions, ref Category, ref status, ref Assignee);
                       
            if (status == "In Progress")
            {
                InProg.Visible = false;
            }
            else if (status == "Done")
            {
                Done.Visible = false;
            }
            else if (status == "Closed")
            {
                Closed.Visible = false;
            }
            TicketID.Text = id_ticket.ToString();
            TicketDate.Text =Date;
            NameTicket.Text =  Name;
            Owner.Text = Users;
            Description.Text =Descriptions;
            TCategoryT.Text = Category;
            AssignListT.Text = Assignee;
            Status.Text =status;

            TicketID.ReadOnly = true;
            TicketDate.ReadOnly = true;
            NameTicket.ReadOnly = false;
            Owner.ReadOnly = true;
            Description.ReadOnly = false;
            TCategoryT.ReadOnly = true;
            AssignListT.ReadOnly = true;
            Status.ReadOnly = true;
        }

        private void get_ticket_assignee()
        {
            myDAL objMyDAL = new myDAL();
            int id_ticket = (int)Session["TID"];
            string Name = "";
            string Date = "";
            string Users = "";
            string Descriptions = "";
            string Category = "";
            string status = "";
            string Assignee = "";
            //            @dID int,

            //@Name varchar(30) output,
            //@DateT Date output,
            //@Users varchar(30) output,
            //@Descriptions varchar(1000) output,
            //@Category varchar(30) output,
            //@StatusP varchar(30) output,
            //@Asignee varchar(30) output
            objMyDAL.Get_Ticket(id_ticket, ref Name, ref Date, ref Users, ref Descriptions, ref Category, ref status, ref Assignee);
            if(status == "In Progress")
            {
                InProg.Visible = false;
            }
            else if(status == "Done"){
                Done.Visible = false;
            }
            else if(status == "Closed")
            {
                Closed.Visible = false;
            }
            TicketID.Text = id_ticket.ToString();
            TicketDate.Text = Date;
            NameTicket.Text =  Name;
            Owner.Text =  Users;
            Description.Text = Descriptions;
            TCategoryT.Text = Category;
            AssignListT.Text = Assignee;
            Status.Text =status;

            TicketID.ReadOnly = true;
            TicketDate.ReadOnly = true;
            NameTicket.ReadOnly = true;
            Owner.ReadOnly = true;
            Description.ReadOnly = true;
            TCategoryT.ReadOnly = true;
            AssignListT.ReadOnly = true;
            Status.ReadOnly = true;


        }

        private void get_ticket_other()
        {
            myDAL objMyDAL = new myDAL();
            int id_ticket = (int)Session["TID"];
            string Name = "";
            string Date = "";
            string Users = "";
            string Descriptions = "";
            string Category = "";
            string status = "";
            string Assignee = "";
            //            @dID int,

            //@Name varchar(30) output,
            //@DateT Date output,
            //@Users varchar(30) output,
            //@Descriptions varchar(1000) output,
            //@Category varchar(30) output,
            //@StatusP varchar(30) output,
            //@Asignee varchar(30) output
            objMyDAL.Get_Ticket(id_ticket, ref Name, ref Date, ref Users, ref Descriptions, ref Category, ref status, ref Assignee);
            TicketID.Text = id_ticket.ToString();
            TicketDate.Text =Date;
            NameTicket.Text = Name;
            Owner.Text = Users;
            Description.Text =Descriptions;
            TCategoryT.Text = Category;
            AssignListT.Text = Assignee;
            Status.Text = status;

            TicketID.ReadOnly = true;
            TicketDate.ReadOnly = true;
            NameTicket.ReadOnly = true;
            Owner.ReadOnly = true;
            Description.ReadOnly = true;
            TCategoryT.ReadOnly = true;
            AssignListT.ReadOnly = true;
            Status.ReadOnly = true;

        }

        private void get_asigneelist()
        {
            string command1 = "Select Name, UserID from Users where UserID !=" + (Session["idoriginal"]).ToString();
            string CS = ConfigurationManager.ConnectionStrings["sqlCon1"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                
                SqlCommand cmd = new SqlCommand(command1, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                AssigneeList.DataTextField = "Name";
                AssigneeList.DataValueField = "UserID";
                AssigneeList.DataSource = rdr;
                AssigneeList.DataBind();
                con.Close();
            }

        }

        protected void BackToHome(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/Home.aspx");
        } 
        protected void TicketRegister(object sender, EventArgs e)
        {
            if (Convert.ToInt32(TCategory.SelectedValue) != 0 && Convert.ToInt32(AssigneeList.SelectedValue) != 0)
            {
                myDAL objmyDAL = new myDAL();
                string NameT = NameTicket.Text;
                string desc = Description.Text;
                string TCat = (TCategory.SelectedItem).ToString();
                string Assign = (AssigneeList.SelectedItem).ToString();
                string NameUser = (string)(Session["NameUser"]);
                objmyDAL.AddTicket(NameT, desc, TCat, Assign, NameUser);
                Response.Redirect("~/Admin/Home.aspx");
            }
            else
            {
                Response.Write("<script>alert('Please Choose your ticket category');</script>");
            }
            
        }
        protected void inprog(object sender , EventArgs e)
        {
            int id_ticket = (int)Session["TID"];
            string command1 = "Update Ticket set StatusP='In Progress' where TicketID =" + id_ticket;
            string CS = ConfigurationManager.ConnectionStrings["sqlCon1"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {

                SqlCommand cmd = new SqlCommand(command1, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            Response.Redirect("~/Admin/Home.aspx");
        }
        //masih ada error di assigne list dan description baik dari update maupun dari create
        protected void update(object sender, EventArgs e)
        {
            
            System.Diagnostics.Debug.WriteLine(TicketID.Text + IDTValid.Text + NameTicket.Text + NameTicket.Text + Description.Text + TCategory.SelectedItem.Text + AssigneeList.SelectedItem.Text + AssigneeList.DataTextField.ToString());
            if (((TicketID.Text == IDTValid.Text) && (NameTicket.Text == NameTValid.Text)) && TCategory.SelectedValue != "0")
            {
                Description.ReadOnly = false;   
                int id_ticket = (int)Session["TID"];
                string new_name = (string)NameTValid.Text;
                string new_desc = (string)Description.Text;
                string command1 = "Update Ticket set Name='" + new_name +"'," +
                    "Descriptions='" + new_desc + "'," +
                    "Category='" + (TCategory.SelectedItem).ToString() + "',"+
                    "Asignee='" + (AssigneeList.SelectedItem).ToString() + 
                    "' where TicketID =" + id_ticket;
                System.Diagnostics.Debug.WriteLine(command1 + "ini sql");
                string CS = ConfigurationManager.ConnectionStrings["sqlCon1"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {

                    SqlCommand cmd = new SqlCommand(command1, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                Response.Redirect("~/Admin/Home.aspx");
            }
            else
            {
                Response.Write("<script>alert('Validation Failed ! Please Check Your Validation Form or new category and assignee ticket');</script>");
            }
            
        }
        protected void delete(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(TicketID.Text + IDTValid.Text + NameTicket.Text + NameTicket.Text + Description.Text + TCategory.SelectedItem.Text + AssigneeList.SelectedItem.Text);
            if (((TicketID.Text == IDTValid.Text) && (NameTicket.Text == NameTValid.Text)))
            {

                int id_ticket = (int)Session["TID"];
                string new_name = (string)NameTValid.Text;
                string new_desc = (string)Description.Text;
                string command1 = "delete from Ticket "+
                    "where TicketID =" + id_ticket;
                System.Diagnostics.Debug.WriteLine(command1 + "ini sql");
                string CS = ConfigurationManager.ConnectionStrings["sqlCon1"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {

                    SqlCommand cmd = new SqlCommand(command1, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                Response.Redirect("~/Admin/Home.aspx");
            }
            else
            {
                Response.Write("<script>alert('Validation Failed ! Please Check Your Validation Form or new category and assignee ticket');</script>");
            }
        }
        protected void done(object sender, EventArgs e)
        {
            int id_ticket = (int)Session["TID"];
            string command1 = "Update Ticket set StatusP='Done' where TicketID =" + id_ticket;
            string CS = ConfigurationManager.ConnectionStrings["sqlCon1"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {

                SqlCommand cmd = new SqlCommand(command1, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            Response.Redirect("~/Admin/Home.aspx");
        }
        protected void closed(object sender, EventArgs e)
        {
            int id_ticket = (int)Session["TID"];
            string command1 = "Update Ticket set StatusP='Closed' where TicketID =" + id_ticket;
            string CS = ConfigurationManager.ConnectionStrings["sqlCon1"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {

                SqlCommand cmd = new SqlCommand(command1, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            Response.Redirect("~/Admin/Home.aspx");
        }

        protected void AssigneeList_SelectedIndexChanged(object sender, EventArgs e)
        {

            //Session["AssigneeList"] = AssigneeList.SelectedItem.Text;
            string command1 = "Select Name, UserID from Users where Name=" +"'" +AssigneeList.SelectedItem.Text +"'";
            string CS = ConfigurationManager.ConnectionStrings["sqlCon1"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {

                SqlCommand cmd = new SqlCommand(command1, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                AssigneeList.DataTextField = "Name";
                AssigneeList.DataValueField = "UserID";
                AssigneeList.DataSource = rdr;
                AssigneeList.DataBind();
                con.Close();
            }
        }
    }
}