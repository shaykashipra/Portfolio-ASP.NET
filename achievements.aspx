<%@ Page Title="" Language="C#" MasterPageFile="~/nav.Master" AutoEventWireup="true" CodeBehind="achievements.aspx.cs" Inherits="Portfolio_ASP.achievements" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <!-- 
    - custom css link
  -->
  <link rel="stylesheet" href="./achievements.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <body class="active">

 
  <!-- 
    main part starting
   -->

   <main>
    
<article>
    <hr class="hr-break">
    <div class="card-container">
        <!-- card 1 -->
        <div class="card">
            <img src="" alt="">
            <!-- card content -->
            <div class="card-content">
                <h3 runat="server" id="title">Singing</h3>
                <h5 runat="server" id="date">12-05-2021</h5>
                <p runat="server" id="description" >I have earned several prices in singing competitions in several categories</p>
            <div class="buttonLink">
            <a href="" class="btn">File</a>
            <a href="" class="btn">Link</a>
             </div>
            </div>
        </div>

        <!-- Card 2 -->
        <div class="card">
            <img src="" alt="">
            <!-- card content -->
            <div class="card-content">
                <h3>Singing</h3>
                <p>I have earned several prices in singing competitions in several categories</p>
             <div class="buttonLink">
            <a href="" class="btn">File</a>
            <a href="" class="btn">Link</a>
             </div>
            </div>
        </div>

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
            </div>
        </div>

           <div class="card-container">
                    <%-- Fetch data from database and generate cards dynamically --%>
                    <% foreach (var achievement in AchievementsData) { %>
                        <div class="card">
                            <img src="<%= achievement.ImageUrl %>" alt="">
                            <div class="card-content">
                                <h3><%= achievement.Title %></h3>
                                <h5><%= achievement.Date %></h5>
                                <p><%= achievement.Description %></p>
                                <div class="buttonLink">
                  <% if (!string.IsNullOrEmpty(achievement.FileUrl)) { %>
                        <a href="<%= achievement.FileUrl %>" class="btn">File</a>
                    <% } %>

                    <% if (!string.IsNullOrEmpty(achievement.LinkUrl)) { %>
                        <a href="<%= achievement.LinkUrl %>" class="btn">Link</a>
                    <% } %>

                                </div>
                            </div>
                        </div>
                    <% } %>
                </div>

        
    </div>

</article>


   </main>

  <!-- 
    java script file
   -->
   <script src="./script.js"></script>
    
</body>
</html>
</asp:Content>
