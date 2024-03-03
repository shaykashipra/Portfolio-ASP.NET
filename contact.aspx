<%@ Page Title="" Language="C#" MasterPageFile="~/nav.Master" AutoEventWireup="true" CodeBehind="contact.aspx.cs" Inherits="Portfolio_ASP.contact" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="./contact.css">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    


    

  <!-- 
    main part starting
   -->

   <main>
    
<!-- <article>
    <hr class="hr-break">
     
   
    


</article> -->

<div class="contactUs">
    <div class="title">
        <h2>Get in Touch</h2>
    </div>
</div>

<div class="box">

    <!-- Form -->
    <div class="contact form">
        <h3>Send a Message</h3>
        <form runat="server">
            <div class="formbox">
            
                <!-- First name and Last Name -->
                <div class="row50">

                      <!-- Last Name -->
                    <div class="inputBox">
                        <asp:Label runat="server" AssociatedControlID="firstname" Text="First Name" />
                        <asp:TextBox runat="server" ID="firstname" CssClass="form-control" TextMode="SingleLine" placeholder="Shayka" required=""/>
                    </div>


                    <!-- Last Name -->
                    <div class="inputBox">
                        <asp:Label runat="server" AssociatedControlID="lastname" Text="First Name" />
                        <asp:TextBox runat="server" ID="lastname" CssClass="form-control" TextMode="SingleLine" placeholder="Islam" required=""/>
                    </div>

           </div>
                 <!-- Email and Phone -->
                <div class="row50">
                    <!-- Email -->
                <div class="inputBox">
                    <asp:Label runat="server" AssociatedControlID="email" Text="Email" />
                    <asp:TextBox runat="server" ID="email" CssClass="form-control" TextMode="Email" placeholder="abc@gmail.com" required="Email is required"/>
                </div>
                    <!-- Email and Phone -->
                    <div class="inputBox">
                        <asp:Label runat="server" AssociatedControlID="phone" Text="Phone" />
                        <asp:TextBox runat="server" ID="phone" CssClass="form-control" TextMode="SingleLine" placeholder="0162567634" />
                    </div>

           </div>


                    <!-- Write Message Button -->
                    <div class="row100">


                    <div class="inputBox">
                        <asp:Label runat="server" AssociatedControlID="message" Text="Write Message" />
                        <asp:TextBox runat="server" ID="message" CssClass="form-control" TextMode="MultiLine" Rows="10" placeholder="Write your message here" required="Message Box can't be empty"/>
                    </div>


                    </div>
                   
                    <!-- Send Button -->
                     <div class="row100">


                <div class="inputBox">
                    <asp:Button runat="server" ID="btn" Text="Send" OnClick="send_click" />
                </div>

                    </div>


               
        </form>
         </div>
            </div>
   

    <!-- Info Box -->
    <div class="contact info">
        <h3>Contact Info</h3>
        <div class="infoBox">
            <div>
                <span><ion-icon name="location"></ion-icon></span>
                <p>Rokeya Hall,KUET,Teligati <br>
                    Khulna,Bangladesh</p>
            </div>
            <div>
                <span><ion-icon name="mail"></ion-icon></span>
                <a class="link" href="mailto:triviatruism@gmail.com">triviatruism@gmail.com</a>
            </div>

            <div>
                <span><ion-icon name="call"></ion-icon></span>
                <a class="link" href="tel:+8801626052742">+880 16260 52742</a>
            </div>

            <!-- Social Media -->
            <ul class="sci">
                <li><a href=""><ion-icon name="logo-facebook"></ion-icon></ion-icon></a></li>
                <li><a href=""><ion-icon name="logo-instagram"></ion-icon></a></li></li>
                <li><a href=""><ion-icon name="logo-github"></ion-icon></a></li>
               
            </ul>
        </div>
    </div>

    <!-- Map -->
    <div class="contact map">
        <iframe src="https://www.google.com/maps/embed?pb=!1m14!1m12!1m3!1d58808.75530026249!2d89.50255489999998!3d22.893179099999998!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!5e0!3m2!1sen!2sbd!4v1709167170229!5m2!1sen!2sbd"
          style="border:0;" allowfullscreen="" loading="lazy" referrerpolicy="no-referrer-when-downgrade"></iframe>
    </div>
</div>


   </main>

  <!-- 
    java script file
   -->
   <script src="./script.js"></script>
   
   <!-- For icons like facebook,insta  -->
<script type="module" src="https://unpkg.com/ionicons@7.1.0/dist/ionicons/ionicons.esm.js"></script>
<script nomodule src="https://unpkg.com/ionicons@7.1.0/dist/ionicons/ionicons.js"></script>
</asp:Content>
