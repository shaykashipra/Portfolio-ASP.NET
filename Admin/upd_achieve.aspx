<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="upd_achieve.aspx.cs" Inherits="Portfolio_ASP.Admin.upd_achieve" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">

  <!-- 
    - primary meta tags
  -->
  <title>Shayka Islam</title>
  <meta name="title" content="Shayka Islam">
  <meta name="description" content="This ia a personal portfolio where information about me is provided">

  <!-- 
    - favicon
  -->
  <link rel="shortcut icon" href="./images2/favicon2.png" type="image/png">

  <!-- 
    - custom css link
  -->
  <link rel="stylesheet" href="./css/achievements.css">

  <!-- 
    - custom font link
  -->
  <link href='https://unpkg.com/boxicons@2.1.4/css/boxicons.min.css' rel='stylesheet'>

  <link rel="stylesheet" href="./font/font.css">

  <!-- 
    - preload images
  -->
  <link rel="preload" as="image" href="./images2/favicon2.png">
  <link rel="preload" as="image" href="./images2/loading-circle.svg">
  
</head>
<body>
    
    <!-- 
    -#PRELOADING
  -->

  <div class="loading" data-loading>
    <img src="./images2/favicon2.png" width="55" height="55" alt="loading" class="img">
    <img src="./images2/loading-circle.svg" width="70" height="70" alt="" class="circle">
  </div>

  <main>
  
    <div class="contactUs">
    <div class="title">
        <h4>Edit Achievement</h4>
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
                            <asp:RequiredFieldValidator ID="wrongimg" runat="server" ControlToValidate="image" ErrorMessage="Wrong Formate" ForeColor="Red"></asp:RequiredFieldValidator>
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
   
    </main>

      <!-- 
    java script file
   -->
   <script src="./script.js"></script>
    

</body>
</html>
