<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/nav.Master" AutoEventWireup="true" CodeBehind="upd_skill.aspx.cs" Inherits="Portfolio_ASP.Admin.upd_skill" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- 
  - custom css link
-->

<link rel="stylesheet" href="./css/skill.css">


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <main>
  
    <div class="contactUs">
    <div class="title">
        <h4>Update Skill Information</h4>
    </div>
</div>


<div class="box">

    <!-- Form -->
    <div class="contact form">
        <h3>Update Information</h3>
        <form runat="server">
            <div class="formbox">

          <div class="row50">  

         <div class="inputBox">
        <asp:Label runat="server" AssociatedControlID="skillType" Text="Skill Type" />
        <asp:DropDownList runat="server" ID="skillType" CssClass="form-control">
            <asp:ListItem Text="Professional" Value="prof"></asp:ListItem>
            <asp:ListItem Text="Technical" Value="tech"></asp:ListItem>
        </asp:DropDownList>
    </div>
               </div>

          <div class="row50">  
                <!-- skill name -->
                
                    <div class="inputBox">
                    <asp:Label runat="server" AssociatedControlID="title" Text="Skill Name" />
                    <asp:TextBox runat="server" ID="title" TextMode="SingleLine" CssClass="form-control" placeholder="HTML" required="" />
                </div>
                <!-- Percentage -->
                <div class="inputBox">
                    <asp:Label runat="server" AssociatedControlID="perc" Text="Percentage" />
                    <asp:TextBox runat="server" ID="perc" TextMode="Number" CssClass="form-control" placeholder="30" />
                </div>
                    
                </div>    
 
        </div>            
                

                   
                <!-- Send Button -->
                <div class="row100">
                    <div class="inputBox">
                        <asp:Button runat="server" ID="sendButton" Text="Update" CssClass="btn" OnClick="sendButton_Click"  />
                    </div>
                </div>
            </div>
    </form>
</main>

      <!-- 
    java script file
   -->
   <script src="./script.js"></script>
    
</div>
    
</asp:Content>
