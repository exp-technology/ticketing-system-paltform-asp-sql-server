using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
	public partial class Admin : System.Web.UI.MasterPage
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {
                usericon.Text = "Hi, " + (string)Session["NameUser"];
            }
            
		}
       protected void createT(object sender, EventArgs e)
        {
            Session["AccessKeyT"] = 0;
            Response.BufferOutput = true;
            Response.Redirect("~/Admin/AddTicket.aspx");
           
        }
	}
}