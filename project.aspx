<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/nav.Master" AutoEventWireup="true" CodeBehind="project.aspx.cs" Inherits="Portfolio_ASP.Admin.project" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">

         <!-- 
   - custom css link
 -->
   <link href="css/project.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <body class="active">

 
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

                        </div>
                    </div>

                   
                <!-- Send Button -->
                <div class="row100">
                    <div class="inputBox">
                        <asp:Button runat="server" ID="sendButton" Text="Add" CssClass="btn" OnClick="sendButton_Click"  />
                    </div>
                </div>



               
        
         </div>


         <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" OnRowCommand="del_update">
    <Columns>
        <asp:BoundField DataField="title" HeaderText="Title" />
        <asp:BoundField DataField="sub" HeaderText="Subtitle" />
        <asp:BoundField DataField="link" HeaderText="Link" />
        <asp:BoundField DataField="fil" HeaderText="File" />
        <asp:BoundField DataField="descrip" HeaderText="Description" />
        <asp:TemplateField HeaderText="Image">
            <ItemTemplate>
                <img src='<%# Eval("img") %>' alt="Image" style="max-width: 100px; max-height: 100px;" />
            </ItemTemplate>
        </asp:TemplateField>
            <asp:TemplateField HeaderText="Action">

        <ItemTemplate >
    <asp:LinkButton ID="delete" CommandName="update" commandArgument='<%# Eval("id") %>' runat="server">Update</asp:LinkButton>
       <asp:LinkButton ID="LinkButton1" CommandName="delete" commandArgument='<%# Eval("id") %>' onclientclick="return confirm('Confirm Delete?');" runat="server">Delete</asp:LinkButton>
    
</ItemTemplate>
                        </asp:TemplateField>

    </Columns>
</asp:GridView>
   
            </div>

 
    </form>
    
   </main>

  
<script src="./script.js"></script>    
</body>
        </div>
</asp:Content>
