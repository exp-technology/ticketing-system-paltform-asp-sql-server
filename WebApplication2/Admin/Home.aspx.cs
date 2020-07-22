using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.DAL;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;

namespace WebApplication2
{
    
    public partial class Home : System.Web.UI.Page
	{
        protected void Page_Load(object sender, EventArgs e)
		{
            int pid = (int)Session["idoriginal"];
            if (!IsPostBack)
			{
               
                get_table();
                System.Diagnostics.Debug.WriteLine(Session["idoriginal"].ToString());
            }
		}
        
        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Manage.PageIndex = e.NewPageIndex;
            get_table();
            
            Manage.SelectedIndex = -1;
            Manage.EditIndex = -1;
        }
        
		/*THIS FUNCTION WILL SEARCH THE NAME AND GIVE RESULTS OR RETURN ALL TUPLES FROM DATABASE IN THE GRID VIE*/
		protected void Search_btn(object sender, EventArgs e)
		{

            get_table();
		}
       


		protected void SelectCommand(object sender, GridViewCommandEventArgs e)
		{
           
            get_table();
            int num = Convert.ToInt32(e.CommandArgument);

            string perintah = Convert.ToString(e.CommandArgument);
            int id2 = (Manage.DataSource as DataTable).Rows.Count;
            int page_index = Manage.PageIndex;
            page_index += 1;
            int x = Manage.PageSize;
            int y = Manage.SelectedIndex;
            int z = num;

            if (e.CommandName == "Select")
            {
                
                int id = Convert.ToInt32(Manage.Rows[z].Cells[1].Text);
                Session["TID"] = id;
                string ownerT = Manage.Rows[z].Cells[4].Text;
                string AssigneeT = Manage.Rows[z].Cells[6].Text;
                if( (string)Session["NameUser"] == ownerT)
                {
                    Session["AccessKeyT"] = 1;
                }
                else if((string)Session["NameUser"] == AssigneeT){
                    Session["AccessKeyT"] = 2;
                }
                else
                {
                    Session["AccessKeyT"] = 3;
                }
                Response.Redirect("~/Admin/AddTicket.aspx");
                               
            }
        }

        protected void relation_SelectedIndexChanged(object sender, EventArgs e)
        {
            get_table();
        }

        protected void Statuss_SelectedIndexChanged(object sender, EventArgs e)
        {
            get_table();
        }
        private void get_table()
        {
            int stat = Convert.ToInt32(Statuss.SelectedValue);
            int rel = Convert.ToInt32(relation.SelectedValue);
            string search = "'" +txtSearch.Text+ "'";
            string searchtxt = txtSearch.Text;
            //0 for all
            //    1 for open
            //        2 for in progress
            //            3 for done
            //                4 for closed
            string status = "";
            string rell = "";
            string select = "SELECT Ticket.TicketID as ID , Ticket.DateT as Date ,Ticket.Name ,Ticket.Users as owner, Ticket.Descriptions, Ticket.Asignee ,Ticket.Category ,Ticket.StatusP as status FROM Ticket";
            string where = " where ";
            string statusp = "Ticket.StatusP = ";
            string ownert = "Ticket.Users = ";
            string assigneet = "Ticket.Asignee = ";
            string namet = "Ticket.Name= "; 
            string or = " or ";
            switch (stat)
            {
                case 0:
                    status = "";
                    break;
                case 1:
                    status = "'Open'";
                    break;
                case 2:
                    status = "'In Progress'";
                    break;
                case 3:
                    status = "'Done'";
                    break;
                case 4:
                    status = "'Closed'";
                    break;
            }
            switch (rel)
            {
                case 0:
                    rell = "";
                    break;
                case 1:
                    rell = "'" + (string)Session["NameUser"] + "'";
                    break;
                case 2:
                    rell = "'" + (string)Session["NameUser"] + "'";
                    break;
                case 3:
                    rell = "'" + (string)Session["NameUser"] + "'";
                    break;
            }

            if (stat > 0)
            {
                select += (where + statusp + status);
                if (rel == 1)
                {
                    select += (or + ownert + rell);
                    if (searchtxt != "")
                    {
                        select += (or + namet + search);
                    }
                }
                else if (rel == 2)
                {
                    select += (or + assigneet + rell);
                    if (searchtxt != "")
                    {
                        select += (or + namet + search);
                    }
                }
                else if (rel == 3)
                {
                    select += (or + ownert + rell + or + assigneet + rell);
                    if (searchtxt != "")
                    {
                        select += (or + namet + search);
                    }

                }
                else
                {
                    if (searchtxt != "")
                    {
                        select += (or + namet + search);
                    }
                }
            }
            else
            {
                if (rel == 1)
                {
                    select += (where + ownert + rell);
                    if (searchtxt != "")
                    {
                        select += (or + namet + search);
                    }
                }
                else if (rel == 2)
                {
                    select += (where + assigneet + rell);
                    if (searchtxt != "")
                    {
                        select += (or + namet + search);
                    }
                }
                else if (rel == 3)
                {
                    select += (where + ownert + rell + or + assigneet + rell);
                    if (searchtxt != "")
                    {
                        select += (or + namet + search);
                    }

                }
                else
                {
                    if (searchtxt != "")
                    {
                        select += (where + namet + search);
                    }
                }
            }
            DataTable table = new DataTable();
            //string command1 = "Select Name, UserID from Users where Name=" + "'" + AssigneeList.SelectedItem.Text + "'";
            System.Diagnostics.Debug.WriteLine("ini stat " + stat.ToString() + "ini rel" + rel.ToString() + "ini search" + search);
            System.Diagnostics.Debug.WriteLine(select);
            string CS = ConfigurationManager.ConnectionStrings["sqlCon1"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {

                SqlCommand cmd = new SqlCommand(select, con);
                con.Open();

                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                Adapter.Fill(table);
                
                con.Close();
            }
            
            Manage.DataSource = table;
            Manage.Caption = "Tickets";
            Manage.DataBind();
            Manage.SelectedIndex = -1;
            Manage.EditIndex = -1;
        }
    }
}