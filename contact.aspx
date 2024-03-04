<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/nav.Master" AutoEventWireup="true" CodeBehind="contact.aspx.cs" Inherits="Portfolio_ASP.Admin.contact" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

         <!-- 
   - custom css link
 -->

   <link href="css/contact.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    

 <div class="contact form">
     <h3>Update Personal Address</h3>
     <form runat="server">
         <div class="formbox">
         <div class="row33">
   
 <div class="inputBox">
     <asp:Label runat="server" AssociatedControlID="address" Text="Address" />
     <asp:TextBox runat="server" ID="address" TextMode="SingleLine" CssClass="form-control" />
             <asp:RequiredFieldValidator ID="wrongimg0" runat="server" ControlToValidate="address" ErrorMessage="Cant't be Empty" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
 </div>
 <div class="inputBox">
     <asp:Label runat="server" AssociatedControlID="email" Text="Email" />
     <asp:TextBox runat="server" ID="email" TextMode="SingleLine" CssClass="form-control" />
             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="email" ErrorMessage="Cant't be Empty" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
 </div>
 <div class="inputBox">
     <asp:Label runat="server" AssociatedControlID="phone" Text="Phone" />
     <asp:TextBox runat="server" ID="phone" TextMode="SingleLine" CssClass="form-control" />
             <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="phone" ErrorMessage="Cant't be Empty" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
 </div>   
 </div> 

              <div class="row100">
                   <div class="inputBox">
     <asp:Label runat="server" AssociatedControlID="map" Text="Map Link" />
     <asp:TextBox runat="server" ID="map" TextMode="SingleLine" CssClass="form-control" />
             <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="map" ErrorMessage="Cant't be Empty" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
 </div>
                               <!-- Send Button -->
              <div class="row100">


         <div class="inputBox">
             <asp:Button runat="server" ID="btn" Text="Update" OnClick="send_click" />
         </div>

             </div>

                  


    <div class="container">
    <h1 class="text-center">Inbox</h1>

      <asp:Label ID="emptyInbox" runat="server" Text="Inbox is empty" Visible="false" CssClass="text-center" />

    <div class="row">
        <div class="col-md-8 mx-auto">
<asp:GridView ID="CoursesGridView" CssClass="table" runat="server" AutoGenerateColumns="false" OnRowCommand="delete_com">
    <Columns>
        <asp:TemplateField Visible="false">
            <ItemTemplate>
                <asp:Label ID="id" runat="server" Text='<%# Eval("id") %>' />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="firstname" HeaderText="First Name" />
        <asp:BoundField DataField="lastname" HeaderText="Last Name" />
        <asp:BoundField DataField="email" HeaderText="Email" />
        <asp:BoundField DataField="phone" HeaderText="Phone" />
        <asp:BoundField DataField="msg" HeaderText="Message" />
        <asp:TemplateField HeaderText="Action">
            <ItemTemplate >
                <asp:LinkButton ID="delete" CommandName="delete" commandArgument='<%# Eval("id") %>' onclientclick="return confirm('Confirm Delete?');" runat="server">Delete</asp:LinkButton>
                
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
        </div>
    </div>
</div>
    </form>
    </div>
  <!-- 
    java script file
   -->
   <script src="./script.js"></script>
</asp:Content>
