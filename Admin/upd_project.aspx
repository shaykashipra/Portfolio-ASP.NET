<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/nav.Master" AutoEventWireup="true" CodeBehind="upd_project.aspx.cs" Inherits="Portfolio_ASP.Admin.upd_project" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

             <!-- 
   - custom css link
 -->
   <link href="css/project.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <!-- 
    main part starting
   -->

   <main>

 <div class="contactUs">
    <div class="title">
        <h4>Add Projects</h4>
    </div>
</div>

<div class="box">
           <form runat="server">

    <!-- Form -->
    <div class="contact form">
        <h3>Update Project</h3>
       
            <div class="formbox">
            
                <!-- Title -->
                <div class="row50">
                    <div class="inputBox">
                    <asp:Label runat="server" AssociatedControlID="title" Text="Title" />
                    <asp:TextBox runat="server" ID="title" TextMode="SingleLine" CssClass="form-control" placeholder="Pay Online" required=""  />
                            <asp:RequiredFieldValidator ID="wrongimg1" runat="server" ControlToValidate="title" ErrorMessage="Cant't be Empty" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>

         <div class="inputBox">
       <asp:Label runat="server" AssociatedControlID="subtitle" Text="Subtitle" />
       <asp:TextBox runat="server" ID="subtitle" TextMode="SingleLine" CssClass="form-control" placeholder="An OOP based project" required="" />
   </div>
                </div>

  
                                <!-- Link Img File -->

                <div class="row33">
   
                <div class="inputBox">
                    <asp:Label runat="server" AssociatedControlID="link" Text="Link" />
                    <asp:TextBox runat="server" ID="link" TextMode="SingleLine" CssClass="form-control" />
                </div>
                <div class="inputBox">
                    <asp:Label runat="server" AssociatedControlID="file" Text="File" />
                    <asp:FileUpload ID="file" runat="server" />

                </div>

                                   <div class="inputBox">
                   <asp:Label runat="server" AssociatedControlID="img" Text="Image" />
                   <asp:FileUpload ID="img" runat="server" />

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



               
        
         </div>
        </div>
               </form>

    <script src="./script.js"></script>  
    </main>
</asp:Content>
