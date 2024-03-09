<%@ Page Title="" Language="C#" MasterPageFile="~/nav.Master" AutoEventWireup="true" CodeBehind="project.aspx.cs" Inherits="Portfolio_ASP.project" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- custom css link -->
  <link rel="stylesheet" href="./project.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <body class="active">
        <main>
            <article>
                <hr class="hr-break">
                <section id="projects">
                    <div id="projectContent">
                      <asp:Repeater ID="rptProjects" runat="server">
    <ItemTemplate>
        <ul id="prImg" style="display: block;" class="projectContent-list-container">
            <li class="project-lists">
                <div class="project-details-container">
                    <div class="project-image-container">
                        <img src="<%# Eval("img") %>" alt="<%# Eval("title") %>" class="project-pic">
                    </div>
                    <div class="project-text-container">
                        <h3 class="pr-title"><%# Eval("title") %></h3>
                        <p class="pr-subtitle"><%# Eval("sub") %></p>
                        <p class="pr-paragraph"><%# Eval("descrip") %></p>
                        <div class="btn-container-load">
                <%# Eval("link") != DBNull.Value && !string.IsNullOrEmpty(Eval("link").ToString()) ? 
                                                        string.Format("<button ID=\"btnDetails\" runat=\"server\" class=\"btn btn-color-2 button-projects-load\" onclick=\"window.open('{0}')\">Details</button>", Eval("link")) :
                                                        ""
                                                    %>
                                                    <%# Eval("fil") != DBNull.Value && !string.IsNullOrEmpty(Eval("fil").ToString()) ? 
                                                        string.Format("<button ID=\"btnFile\" runat=\"server\" class=\"btn btn-color-2 button-projects-load\" onclick=\"window.open('{0}')\">File</button>", Server.UrlEncode(Eval("fil").ToString())) :
                                                        ""
                                                    %>
                        </div>
                    </div>
                </div>
                <hr class="hr-break">
            </li>
        </ul>
    </ItemTemplate>
</asp:Repeater>


                    </div>
                    </div>
                </section>
            </article>
        </main>
        <!-- java script file -->
        <script src="./project.js"></script>
    </body>
</asp:Content>
