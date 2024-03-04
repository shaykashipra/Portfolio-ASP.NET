<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/nav.Master" AutoEventWireup="true" CodeBehind="skill.aspx.cs" Inherits="Portfolio_ASP.Admin.skill" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
       
 <!-- 
   - custom css link
 -->

 <link rel="stylesheet" href="./css/skill.css">


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- 
    main part starting
   -->
  <main>
  
    <div class="contactUs">
    <div class="title">
        <h4>My Skills</h4>
    </div>
</div>


<div class="box">

    <!-- Form -->
    <div class="contact form">
        <h3>Skills Add</h3>
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
                        <asp:Button runat="server" ID="sendButton" Text="Add" CssClass="btn" OnClick="sendButton_Click"  />
                    </div>
                </div>


<!-- List of info -->

  <div class="container-grid">
    <h1 class="text-center">Professional Courses</h1>

    <asp:Label ID="emptyProfInbox" runat="server" Text="Inbox is empty" Visible="false" CssClass="text-center" />

    <div class="row">
        <div class="col-md-8 mx-auto">
            <asp:GridView ID="ProfessionalCoursesGridView" CssClass="table" runat="server" AutoGenerateColumns="false" OnRowCommand="ProfessionalCoursesGridView_RowCommand">
                <Columns>
                    <asp:TemplateField Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="id" runat="server" Text='<%# Eval("id") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="title" HeaderText="Skill Name" />
                    <asp:BoundField DataField="per" HeaderText="Percentage" />

               
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
<asp:LinkButton ID="LinkButton1" CommandName="update" commandArgument='<%# $"{Eval("id")}|prof"%>'  runat="server">Update</asp:LinkButton>
      <asp:LinkButton ID="delete" CommandName="delete" commandArgument='<%# Eval("id") %>' runat="server">Delete</asp:LinkButton>

                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>

    <h1 class="text-center">Technical Courses</h1>

    <asp:Label ID="emptyTechInbox" runat="server" Text="Inbox is empty" Visible="false" CssClass="text-center" />

    <div class="row">
        <div class="col-md-8 mx-auto">
            <asp:GridView ID="TechnicalCoursesGridView" CssClass="table" runat="server" AutoGenerateColumns="false" OnRowCommand="TechnicalCoursesGridView_RowCommand">
                <Columns>
                
     <asp:TemplateField Visible="false">
         <ItemTemplate>
             <asp:Label ID="Label1" runat="server" Text='<%# Eval("id") %>' />
         </ItemTemplate>
     </asp:TemplateField>
     <asp:BoundField DataField="title" HeaderText="Skill Name" />
     <asp:BoundField DataField="per" HeaderText="Percentage" />


     <asp:TemplateField HeaderText="Action">
         <ItemTemplate>
<asp:LinkButton ID="LinkButton2" CommandName="update" commandArgument='<%# $"{Eval("id")}|tech" %>'  runat="server">Update</asp:LinkButton>
             <asp:LinkButton ID="LinkButton3" CommandName="delete" commandArgument='<%# Eval("id") %>' onclientclick="return confirm('Confirm Delete?');" runat="server">Delete</asp:LinkButton>
         </ItemTemplate>
     </asp:TemplateField>
 
                </Columns>
            </asp:GridView>
        </div>
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
    


</asp:Content>

