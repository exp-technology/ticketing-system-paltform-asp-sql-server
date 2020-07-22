﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="WebApplication2.Home" %>

<script runat="server">

    
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>




<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">

<style type = "text/css">

    .outer {
       margin-left:20%;
       display:inline-block;
  
     

    }
    .mydiv
    {
        display:inline-block;
    }
</style>


</asp:Content>









<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <form runat="server">


        
        <div class="outer">



    <div>

        
        
        <div class="form-group">
            <h5 style="font:bold">Select The Ticket by status :</h5>
            <br />
           <asp:DropDownList ID="Statuss" runat="server" 
                                    Width="228px" Height="30px" OnSelectedIndexChanged="Statuss_SelectedIndexChanged" AutoPostBack="true">
                                            
                                                 <asp:ListItem Text="All" Value="0"></asp:ListItem>
                                                 <asp:ListItem Text="Open" Value="1"></asp:ListItem>
                                                 <asp:ListItem Text="In Progress" Value="2"></asp:ListItem>
                                                 <asp:ListItem Text="Done" Value="3"></asp:ListItem>
                                                 <asp:ListItem Text="Closed" Value="4"></asp:ListItem>
                                                                                            
           </asp:DropDownList>
            <h5 style="font:bold">Select The Ticket by relation with You :</h5>
            <br />
            <asp:DropDownList ID="relation" runat="server" 
                                    Width="228px" Height="30px" OnSelectedIndexChanged="relation_SelectedIndexChanged" AutoPostBack="true">
                                            
                                                 <asp:ListItem Text="Free" Value="0"></asp:ListItem>
                                                 <asp:ListItem Text="Your Own" Value="1"></asp:ListItem>
                                                 <asp:ListItem Text="Assign for you" Value="2"></asp:ListItem>
                                                 <asp:ListItem Text="Your Own and Assign for You" Value ="3"></asp:ListItem>
                                                                                            
           </asp:DropDownList>
        </div>
           
           

    </div>
        <div>
            <div>
                <br />
        <h6 style="font:bold">Select Ticket by Name of Ticket</h6>
        <asp:TextBox ID="txtSearch" runat="server" />
        <asp:button Text ="Search"  runat="server" type="submit" class="btn btn-primary"  OnClick="Search_btn" ></asp:button>
        <br />
        <asp:Label ID="Msg" runat="server" Font-Bold="True"></asp:Label>
        
                   
                <asp:GridView
                    ID="Manage"
                    
                    EnableViewState="False"
                    
                    OnPageIndexChanging="OnPageIndexChanging"
                    OnRowCommand="SelectCommand"
                    runat="server" BackColor="White" BorderColor="#CCCCCC"
                    BorderStyle="None" BorderWidth="1px" CellPadding="20"
                    Caption="Ticket Table" CaptionAlign="Top" HorizontalAlign="Center"
                    Width="1000px" GridLines="Horizontal" AllowPaging="True" PageSize="5" ForeColor="Black">

                    <Columns>
                        <asp:CommandField SelectText="Edit" ShowSelectButton="True" />
                    </Columns>

                    <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                    <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                    <PagerSettings PageButtonCount="3" />
                    <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                    <RowStyle BorderStyle="solid" BorderWidth="4px" />
                    <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F7F7F7" />
                    <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                    <SortedDescendingCellStyle BackColor="#E5E5E5" />
                    <SortedDescendingHeaderStyle BackColor="#242121" />

            </asp:GridView>
           
          
            


            </div>
            
            
            
            
            </div>


            
          </div>

             <div style="display:inline-block; float:right;margin-right:10%" runat="server" id="mydiv"></div>

          

                     
           

        </form>
</asp:Content>
