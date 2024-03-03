<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/nav.Master" AutoEventWireup="true" CodeBehind="contact.aspx.cs" Inherits="Portfolio_ASP.Admin.contact" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server"> 

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
</form>
        </div>
    </div>
</div>
</asp:Content>
