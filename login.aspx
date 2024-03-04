<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Portfolio_ASP.Admin.login" %>

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
  <link rel="shortcut icon" href="~/images2/favicon2.png" type="image/png">

      <!-- 
    - preload images
  -->
  <link rel="preload" as="image" href="~/images2/favicon2.png">
  <link rel="preload" as="image" href="~/images2/loading-circle.svg">

  <!-- 
    - custom css link
  -->

  <link rel="stylesheet" href="./css/login.css">

  <!-- 
    - custom font link
  -->
  <link href='https://unpkg.com/boxicons@2.1.4/css/boxicons.min.css' rel='stylesheet'>

  <link rel="stylesheet" href="./font/font.css">

</head>
<body>
  <!-- 
    -#PRELOADING
  -->

  <div class="loading" data-loading>
    <img src="./images2/favicon2.png" width="55" height="55" alt="loading" class="img">
    <img src="./images2/loading-circle.svg" width="70" height="70" alt="" class="circle">
  </div>

    <!-----

         Main 

     ----->
     <main>
        <div class="wrapper">
            <div class="form-wrapper sign-in">
                <form runat="server">
                    <h2>Log In</h2>

                    <!-- Email -->
                    <div class="input-group">
                        <asp:TextBox runat="server" ID="email" TextMode="Email" CssClass="form-control" Required="true" />
                        <asp:Label runat="server" AssociatedControlID="email" Text="Email" />
                    </div>

                    <!-- Password -->
                    <div class="input-group">

                    <asp:TextBox runat="server" ID="password" TextMode="Password" CssClass="form-control" Required="true" />
                    <asp:Label runat="server" AssociatedControlID="password" Text="Password" />

                    </div>

                    <!-- Remember pass -->
                    <div class="remember">
                    <asp:Label runat="server" ID="lblRemember" AssociatedControlID="rememberme">
                        <asp:CheckBox runat="server" ID="rememberme" Text="Remember me" />
                    </asp:Label>                   

                    </div>

                    <!-- Submit Button -->
                <asp:Button runat="server"  Text="Sign In"  CssClass="btn" OnClick="login_Click" />

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
