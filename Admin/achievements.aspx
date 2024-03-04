<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/nav.Master" AutoEventWireup="true" CodeBehind="achievements.aspx.cs" Inherits="Portfolio_ASP.Admin.achievements" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <!-- 
    - custom css link
  -->
    <link href="css/achievements.css" rel="stylesheet" />
  
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


  <!-- 
    main part starting
   -->
  <main>
  
    <div class="contactUs">
    <div class="title">
        <h4>Add Achievement</h4>
    </div>
</div>

<div class="box">

    <!-- Form -->
    <div class="contact form">
        <h3>Send a Message</h3>
        <form runat="server">
            <div class="formbox">
            
                <!-- Title -->
                <div class="row50">
                    <div class="inputBox">
                    <asp:Label runat="server" AssociatedControlID="title" Text="Title" />
                    <asp:TextBox runat="server" ID="title" TextMode="SingleLine" CssClass="form-control" placeholder="Shayka" required="" />
                </div>
                      <!-- Date -->
                <div class="inputBox">
                    <asp:Label runat="server" AssociatedControlID="date" Text="Date" />
                    <asp:TextBox runat="server" ID="date" TextMode="Date" CssClass="form-control" />
                </div>
                    
                </div>    
             <div class="row50">
                  <!-- Link  -->
                <div class="inputBox">
                    <asp:Label runat="server" AssociatedControlID="link" Text="Link" />
                    <asp:TextBox runat="server" ID="link" TextMode="SingleLine" CssClass="form-control" />
                </div>
              <!-- File  -->  
                <div class="inputBox">
                    <asp:Label runat="server" AssociatedControlID="file" Text="File" />
                    <asp:FileUpload runat="server" ID="file" CssClass="form-control" />
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
                        <asp:Button runat="server" ID="sendButton" Text="Send" CssClass="btn" OnClick="sendButton_Click"  />
                    </div>
                </div>



               
        </form>
         </div>
            </div>
   
    
<article>

   



    <hr class="hr-break">
    <div class="card-container" runat="server" id="cardContainer">

   


        <!-- Card 3 -->

        <div class="card">
            <img src="./images2/education-1.png" alt="">
            <!-- card content -->
            <div class="card-content">
                <h3>Singing</h3>
                <p>I have earned several prices in singing competitions in several categories</p>

                <div class="buttonLink">
                <a href="" class="btn">File</a>
                <a href="" class="btn">Link</a>
                 </div>

                <div class="buttonLink">
                <a href="" class="btn">Update</a>
                <a href="" class="btn">Delete</a>
                </div>

            </div>
        </div>

        
    </div>

</article>


   </main>

  <!-- 
    java script file
   -->
   <script src="./achievements.js"></script>
    


</asp:Content>
