<%@ Page Title="" Language="C#" MasterPageFile="~/nav.Master" AutoEventWireup="true" CodeBehind="education.aspx.cs" Inherits="Portfolio_ASP.education" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <!-- 
    - custom css link
  -->
  <link rel="stylesheet" href="./education.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <body class="active">

  <!-- 
    main part starting
   -->

   <main>
    
<article>
    <hr class="hr-break">

    <!-- Timeline  -->

          <div class="timeline" id="timeline" runat="server">
        
    <!-- 1 -->
        <div class="container left-container">
            <img src="./images2/education-1.png" alt="" class="logo">
            <div class="text-box">
                <h2>New Holy Child Public School</h2>
                <small>2006-2010</small>
                <p>Embarkment of Life's Initial Ethereal Education</p>
                <span class="left-container-arrow"></span>
            </div>
        </div>

<!-- 2 -->
        <div class="container right-container">
            <img src="./images2/education-2.png" alt="" class="logo">

            <div class="text-box">
                
                <h2>Shamsul Haque Khan School & College</h2>
                <small>2006-2010</small>
                <p>Embarkment of Life's Initial Ethereal Education</p>
                <span class="right-container-arrow"></span>

            </div>
        </div>

      <!-- 3 -->
      
        <div class="container left-container">
            <img src="./images2/education-2.png" alt="" class="logo">

            <div class="text-box">
                <h2>Shamsul Haque Khan School & College</h2>
                <small>2006-2010</small>
                <p>Embarkment of Life's Initial Ethereal Education</p>
                <span class="left-container-arrow"></span>

            </div>
        </div>
     

      <!-- 4 -->
     
        <div class="container right-container">
            <img src="./images2/education-3.png" alt="" class="logo">

            <div class="text-box">
                <h2>Khulna University of Engineering & Technology</h2>
                <small>2006-2010</small>
                <p>Embarkment of Life's Initial Ethereal Education</p>
                <span class="right-container-arrow"></span>

            </div>
        </div>

        <!-- End of Timeline -->
      </div>


</article>


   </main>

  <!-- 
    java script file
   -->
   <script src="./education.js"></script>
    
</body>
</asp:Content>
