<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/nav.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Portfolio_ASP.Admin.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link rel="stylesheet" href="./css/index.css">


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <body class="active">

 
  <!-- 
    main part starting
   -->

   <main>

 <div class="contactUs">
    <div class="title">
        <h4>Welcome Back!!</h4>
    </div>
</div>

<div class="box">

    <!-- Form -->
    <div class="contact form">
        <h3>Update Profile</h3>
        <form runat="server">
            <div class="formbox">
            
                <!-- Name -->
                <div class="row100">
                    <div class="inputBox">
                    <asp:Label runat="server" AssociatedControlID="Name" Text="Name" />
                    <asp:TextBox runat="server" ID="Name" TextMode="SingleLine" CssClass="form-control" placeholder="Shayka Islam" required="" />
                </div>
                </div>
                                <!-- Title -->

                <div class="row33">
   
                <div class="inputBox">
                    <asp:Label runat="server" AssociatedControlID="Title1" Text="Title1" />
                    <asp:TextBox runat="server" ID="Title1" TextMode="SingleLine" CssClass="form-control" />
                            <asp:RequiredFieldValidator ID="wrongimg0" runat="server" ControlToValidate="Title1" ErrorMessage="Cant't be Empty" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
                <div class="inputBox">
                    <asp:Label runat="server" AssociatedControlID="Title2" Text="Title2" />
                    <asp:TextBox runat="server" ID="Title2" TextMode="SingleLine" CssClass="form-control" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Title2" ErrorMessage="Cant't be Empty" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
                <div class="inputBox">
                    <asp:Label runat="server" AssociatedControlID="Title3" Text="Title3" />
                    <asp:TextBox runat="server" ID="Title3" TextMode="SingleLine" CssClass="form-control" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Title3" ErrorMessage="Cant't be Empty" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>   
                </div>    
                   <!-- Bio -->
                <div class="row100">
                    <div class="inputBox">
                    <asp:Label runat="server" AssociatedControlID="bio" Text="Bio" />
                    <asp:TextBox runat="server" ID="bio" TextMode="SingleLine" CssClass="form-control" placeholder="Bio" required="" />
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="bio" ErrorMessage="Cant't be Empty" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
           
                        </div>
                </div>
 

                    <!-- Description -->
                    <div class="row100">
                        <div class="inputBox">
                            <asp:Label runat="server" AssociatedControlID="description" Text="Description" />
                            <asp:TextBox runat="server" ID="description" TextMode="MultiLine" cols="30" Rows="10" CssClass="form-control" placeholder="Write your description here" required=""></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="description" ErrorMessage="Cant't be Empty" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>

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
            </div>
   
    
    <article>
       </article>
   </main>

  <!-- 
    java script file
   -->
   <script src="./script.js"></script>
    
</body>
</asp:Content>
