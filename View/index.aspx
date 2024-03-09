<%@ Page Title="" Language="C#" MasterPageFile="~/nav.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Portfolio_ASP.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link rel="stylesheet" href="./style.css">


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <body class="active">





  <!-- 
    main part starting
   -->

   <main>
    <article>
        <section class="section shipra" id="home" aria-label="home">
        <div class="container">

            <img src="./images2/dp_rounded.png" runat="server" class="firstdp" width="322" height="322" alt="Shayka ISlam Shipra" srcset="">
            <div class="Shipra_Content">
                        

            <h1 runat="server" class="h1 shipratitle" id="shipratitle"></h1>

            <div class="wrapper h2">
              <strong runat="server" class="strong strong_t1" id="strong_t1" data-letter-effect></strong>
              <strong runat="server" class="strong strong_t2" id="strong_t2" data-letter-effect></strong>
              <strong runat="server" class="strong strong_t3" id="strong_t3" data-letter-effect></strong>
            </div>

            <p runat="server" class="shipratext" id="shipratext"></p>


            <!-- Button Download Option -->

            <div class="button-box">
              <a href="#" class="btn">Download CV</a>
              <a href="./Admin/login.aspx" class="btn">Log In</a>
            </div>

            <div class="socia-icons">
                 <a href="https://github.com/shaykashiprayyy" class="social github"><i class='bx bxl-github bx-tada' style='color:#ffffff' ></i></a>
                 <a href="https://www.facebook.com/shaykashipra" class="social facebook"><i class='bx bxl-facebook-circle bx-spin' style='color:#ffffff' ></i></a>
                 <a href="https://www.instagram.com/shayka_islam/?igsh=MXd1NG14Y3hva2xzcA%3D%3D" class="social instagram"><i class='bx bxl-instagram bx-tada bx-rotate-90' style='color:#ffffff' ></i></a>
                 
            </div>

          </div>

        
            </div>

                    <img src="./images2/spiral.svg" width="211" height="189" alt="erroooooooooooor" class="shape">

        </div>

  </section>
   

     <!-- 
        - #ABOUT
      -->
 <section class="section about" id="about" aria-label="about me">
        <div class="container">

          <div class="about-content">

            <h2 class="h2 section-title" data-reveal="right">
              Hello. I’m <br>
              Shayka Islam Shipra
            </h2>

            <div class="wrapper has-before" data-reveal="right">

              <p runat="server" class="sectiontext" id="sectiontext">
              </p>

              <img src="./images2/signature2.png" width="151" height="92" loading="lazy" alt="signature"
                class="img">

            </div>

          </div>

          <figure class="about-banner" data-reveal="left">

            <div class="img-holder has-before" style="--width: 512; --height: 684;">
              <img src="./images2/profile1.jpg" width="512" height="684" loading="lazy" alt="Shayka Islam Shipra"
                class="img-cover">
            </div>

            <!-- <img src="/images2/about-shape-1.png" width="178" height="178" loading="lazy" alt=""
              class="shape shape-1"> -->

            <img src="/images2/about-shape-2.svg" width="659" height="653" loading="lazy" alt=""
              class="shape shape-2">

          </figure>

          <img src="/images2/about-shape-3.svg" width="239" height="232" loading="lazy" alt=""
            class="shape shape-3">

        </div>
      </section>

     </article>
   </main>

  <!-- 
    java script file
   -->
   <script src="./script.js"></script>
    
</body>
</asp:Content>
