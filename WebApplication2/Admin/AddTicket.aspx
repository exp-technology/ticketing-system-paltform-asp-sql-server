 <%@ Page Language="C#" AutoEventWireup="true" UnobtrusiveValidationMode="None"  CodeBehind ="AddTicket.aspx.cs" Inherits="WebApplication2.TicketRegistrationForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title></title>

<style type = "text/css">
  
   

    html
    {
      background-image:url("/assets/3.jpg");   
      background-size: cover;
      background-position: 0 -90px;
      background-attachment: fixed;
    }
    body {
        background: none !important;
    }
    .backstretch {
        display: none !important;
    }

    .grad{

  background: linear-gradient(to right, rgba(30, 160, 130 , 0.15),rgba(0, 148, 255 , 1)); 
  border-radius:8px;
}
 
  #space
  {
    padding-bottom:50px;
  }

    
    
    </style>

</head>
<body>
    <form id="form1" runat="server">
      
        
        <div id ="myclass">    
        
        
        
        <link rel="stylesheet" href="http://fonts.googleapis.com/css?family=Roboto:400,100,300,500"/>
        <link rel="stylesheet" href="/assets/bootstrap/css/bootstrap.min.css"/>
        <link rel="stylesheet" href="/assets/font-awesome/css/font-awesome.min.css"/>
        <link rel="stylesheet" href="/assets/css/form-elements.css"/>
        <link rel="stylesheet" href="/assets/css/style.css"/>
        

            



        <!-- Top content -->
             	                   
                      
        <div class="top-content">
       
            
            <div class="inner-bg">
            
                <div class="container grad">
                
                    

                    <div class="row">
                    
                        <div class="col-sm-8 col-sm-offset-2 text">
                        
                            <h1><strong>Issue Ticket Tracker</strong> Ticket Registration</h1>
                            
                            <div class="description">
                            	<p><strong>"Ticker Registration Form"</strong> for Issued Ticket Tracker. 
	                            	Fill out the information of your ticket.
                                    
                            	</p>
                            
                            </div>
                        </div>

                    </div>
                    </div>
                   </div>
            </div>
        
                                    
                                    
                                    
                                    
                                    
                                    <div class="container myclass">

                                       
                                        <div class ="row">

                                                      
                        
                        <div class="col-sm-2"></div>
                        	
                            <div class="col-sm-8">
                        	
                            	<div class="form-box" id="spaces">
                        		<div class="form-top">
	                        		<div class="form-top-left">
	                        			<h3>Write Now
                                            
                                        </h3>
                                        
                                        <asp:Label ID="Msg" runat="server" ForeColor="Blue" Visible="False" Font-Bold="True" Font-Size="Large" Font-Strikeout="False" ></asp:Label>

	                        		</div>
	                            </div>
	                            <div class="form-bottom">
				                                                    
                                    <!-- sign up form start honay laga hai :)-->
                                    
                                        <div class="form-group">
                                            <asp:Label ID="Label1" runat="server" Text="Ticket ID" Width="350px" />
                                            <asp:Label ID="Label2" runat="server" Text="Ticket Date" />
                                        </div>
                                        <div class="form-group">
			                               
                                            <asp:TextBox ID="TicketID" runat="server" type="text" placeholder="Ticket ID" Width="340px" ></asp:TextBox>
                                            <asp:TextBox ID="TicketDate" runat="server" type="text" placeholder="Ticket Date" Width="340px"></asp:TextBox>
                                      
                                        </div> 
				                       <div class="form-group">
                                            <asp:Label ID="Label3" runat="server" Text="Name Ticket" Width="350px" />
                                       </div>
				                        <div class="form-group">
				                        
                                            <asp:TextBox ID="NameTicket" runat="server" type="text" class="form-username form-control" placeholder="Title : e.g Error loop program" ></asp:TextBox>

                                        </div>

                                        <div class="form-group">
                                            <asp:Label ID="Label4" runat="server" Text="Owner" Width="350px" />
                                       </div>
                                        <div class="form-group">
				               
                                            <asp:TextBox ID="Owner" runat="server" type="text" class="form-username form-control" placeholder="Owner" ></asp:TextBox>

                                        </div>
                                         <div class="form-group">
                                            <asp:Label ID="Label5" runat="server" Text="Description" Width="350px" />
                                         </div>
                                         <div class="form-group">
                                                
                                                <asp:TextBox ID="Description" runat="server" type="text" TextMode="multiline" Columns="40" Rows="10" class="form-username form-control" placeholder="Description of your ticket"></asp:TextBox>

                                        </div>
                                        <div class="form-group">
                                            <asp:Label ID="Label6" runat="server" Text="Category                Assigne & Status" Width="350px" />
                                       </div>
                                         <div class="form-group">

                                             <asp:TextBox ID="TCategoryT" runat="server" type="text" placeholder="category text"  Height="39px" Width="220px"></asp:TextBox>
                                             <asp:Label ID="Selectcategory" runat="server" Text="Select new Category" />
                                             <asp:DropDownList ID="TCategory" runat="server" Width="228px" Height="39px">
                                            
                                                 
                                                 <asp:ListItem Text="Select Ticket Category" Value="0"></asp:ListItem>
                                                 <asp:ListItem Text="Back-End Engineer" Value="1"></asp:ListItem>
                                                 <asp:ListItem Text="Hardware Engineer" Value="2"></asp:ListItem>
                                                 <asp:ListItem Text="Front-End" Value="3"></asp:ListItem>
                                                 <asp:ListItem Text="Management" Value="4"></asp:ListItem>
                                             
                                             </asp:DropDownList>
                                             <%--<asp:Label ID="TextBox1" Text="Select Assignee :" Height="39px" ></asp:Label>--%>
                                             <asp:TextBox ID="AssignListT" runat="server" type="text" placeholder="assignee list text"  Height="39px" Width="220px"></asp:TextBox>
                                             <asp:Label ID="Selectassigne" runat="server" Text="Select new Assignee" />
                                             <asp:DropDownList ID="AssigneeList" runat="server" DataTextField="Name" DataValueField="UserID" Width="228px" Height="39px"
                                                 onselectedindexchanged="AssigneeList_SelectedIndexChanged" AutoPostBack="true">
                                            
                                                 <asp:ListItem Text="Select Asignee Person" Value="0"></asp:ListItem>
                                                 
                                             </asp:DropDownList>
                                             <asp:TextBox ID="Status" runat="server" type="text" placeholder="Status"  Height="39px" Width="220px"></asp:TextBox>                                           
                                                                                       
                                               
                                             
                                        </div>
                                         <div class="form-group">
                                            <asp:Label ID="Label7" runat="server" Text="Please FIll for Update or Delete" Width="350px" />
                                        </div>
                                        <div class="form-group">
                                            <asp:TextBox ID="IDTValid" runat="server" type="text" placeholder="Write Ticket ID for update"  Height="39px" Width="325px"></asp:TextBox>  
                                            <asp:TextBox ID="NameTValid" runat="server" type="text" placeholder="Write Ticket Name for update"  Height="39px" Width="360px"></asp:TextBox>  
                                        </div>
  
				                        <asp:button Text ="Back" id="Back" runat="server" type="submit" class="btn btn-primary" onclick="BackToHome" ></asp:button>
                                        <asp:button Text ="Create" id="Create"  runat="server" type="submit" class="btn btn-primary" onclick="TicketRegister" ></asp:button>
                                        <asp:button Text ="Update" id="Update" runat="server" type="submit" class="btn btn-primary" onclick="update" ></asp:button>
                                        <asp:button Text ="Delete" id="Delete" runat="server" type="submit" class="btn btn-primary" onclick="delete" ></asp:button>
                                        <asp:button Text ="In Progress" id="InProg" runat="server" type="submit" class="btn btn-primary" onclick="inprog" ></asp:button>
                                        <asp:button Text ="Done" id="Done" runat="server" type="submit" class="btn btn-primary" onclick="done" ></asp:button>
                                        <asp:button Text ="Closed" id="Closed" runat="server" type="submit" class="btn btn-primary" onclick="closed" ></asp:button>
                                        
				                <!-- onclick="signup" -->
                              
                                </div>
                        	</div>
                        	
                        </div>
                    </div>
                    
                </div>
            </div>
            


                                    

        





            

        <!-- Footer -->
        <footer ">
        	<div class="container">
        		<div class="row">
        			
        			<div class="col-sm-8 col-sm-offset-2">
        				<div class="footer-border"></div>
        				<p style="color:darkslategrey">if You have Any Query
        					Please Feel Free to Contact US. <i class="fa fa-smile-o"></i></p>
        			
                   
                    
                    </div>
        			
        		</div>
        	</div>
        </footer>

        <!-- Javascript -->
        <script src="/assets/js/jquery-1.11.1.min.js"></script>
        <script src="/assets/bootstrap/js/bootstrap.min.js"></script>
        <script src="/assets/js/jquery.backstretch.min.js"></script>
        <script src="/assets/js/scripts.js"></script>
        
        <!--[if lt IE 10]>
            <script src="assets/js/placeholder.js"></script>
        <![endif]-->







     
    
    
    </form>
</body>
</html>
