<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/nav.Master" AutoEventWireup="true" CodeBehind="upd_education.aspx.cs" Inherits="Portfolio_ASP.Admin.upd_education" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
         <!-- 
   - custom css link
 -->
   <link href="css/education.css" rel="stylesheet" />
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main>
        <div class="contactUs">
    <div class="title">
        <h4>Educational Info Update</h4>
    </div>
</div>


<div class="box">

    <!-- Form -->
    <div class="contact form">
        <h3>Update Information</h3>
        <form runat="server">
            <div class="formbox">
            
                <!-- Title -->
                <div class="row50">
                    <div class="inputBox">
                    <asp:Label runat="server" AssociatedControlID="title" Text="Name" />
                    <asp:TextBox runat="server" ID="title" TextMode="SingleLine" CssClass="form-control" placeholder="Shayka" required="" />
                </div>
                <!-- Date Range -->
                <div class="inputBox">
                    <asp:Label runat="server" AssociatedControlID="dateRange" Text="Date Range" />
                    <asp:TextBox runat="server" ID="dateRange" CssClass="form-control" placeholder="1/2/2015-2/2/2016" />
                </div>
                    
                </div>    
 
                    
                    <!-- Image add -->
                    <div class="row100">
                        <div class="inputBox">
           <asp:Label runat="server" AssociatedControlID="image" Text="Image" />

                 <asp:FileUpload runat="server" ID="image" CssClass="form-control" />
                      </div>
                    </div>

                    <!-- Description -->
                    <div class="row100">
                        <div class="inputBox">
                            <asp:Label runat="server" AssociatedControlID="description" Text="Description" />
                            <asp:TextBox runat="server" ID="description" TextMode="MultiLine" cols="30" Rows="10" CssClass="form-control" placeholder="Write your description here" required=""></asp:TextBox>
                        </div>
                    </div>

                   
                <!-- Send Button -->
                <div class="row100">
                    <div class="inputBox">
                        <asp:Button runat="server" ID="sendButton" Text="Update" CssClass="btn" OnClick="sendButton_Click"  />
                    </div>
                </div>
</form>
</div>
            </main>

   
  <script src="./script.js"></script>
</div>
</asp:Content>
