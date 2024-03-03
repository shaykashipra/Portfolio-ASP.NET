<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/nav.Master" AutoEventWireup="true" CodeBehind="education.aspx.cs" Inherits="Portfolio_ASP.Admin.education" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <!-- 
    - custom css link
  -->
    <link href="css/education.css" rel="stylesheet" />
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
  <!-- 
    main part starting
   -->
  <main>
  
    <div class="contactUs">
    <div class="title">
        <h4>Education</h4>
    </div>
</div>


<div class="box">

    <!-- Form -->
    <div class="contact form">
        <h3>Educational Background</h3>
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
                        <asp:Button runat="server" ID="sendButton" Text="Add" CssClass="btn" OnClick="sendButton_Click"  />
                    </div>
                </div>


<!-- List of info -->

                    <div class="container-grid">
    <h1 class="text-center">Data</h1>

      <asp:Label ID="emptyInbox" runat="server" Text="Inbox is empty" Visible="false" CssClass="text-center" />

    <div class="row">
        <div class="col-md-8 mx-auto">
<asp:GridView ID="CoursesGridView" CssClass="table" runat="server" AutoGenerateColumns="false" OnRowCommand="del_update">
    <Columns>
        <asp:TemplateField Visible="false">
            <ItemTemplate>
                <asp:Label ID="id" runat="server" Text='<%# Eval("id") %>' />
            </ItemTemplate>
        </asp:TemplateField>
                    <asp:BoundField DataField="title" HeaderText="Name" />
                   <asp:BoundField DataField="dt" HeaderText="Date" />

                    <asp:BoundField DataField="descrip" HeaderText="Description" />
                    <asp:TemplateField HeaderText="Image">
                        <ItemTemplate>
                <img src='<%# Eval("img") %>' alt='<%# Eval("title") %>' width="100" height="100" />
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
    

</asp:Content>
