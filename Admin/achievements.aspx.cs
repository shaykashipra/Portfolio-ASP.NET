

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using System.IO; //must for Path class



namespace Portfolio_ASP.Admin
{
    public partial class achievements : System.Web.UI.Page
    {
        String strcon = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["email"] == null)
            {
                Response.Redirect("~/Admin/login.aspx");
            }
          
                LoadAchievementsFromDatabase();
            
        }

        protected void sendButton_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {

                    con.Open();
                }
                String path = Server.MapPath("~/dbimages/").ToString(); 

                String name_file = "";
                String name_img = "";
  

                if (file.HasFile)
                {
               

                    String filename = Path.GetFileName(file.FileName);
                    String extensionFile = Path.GetExtension(filename);
                    file.SaveAs(path);
                    name_file = path + filename;

                }



                if (image.HasFile)
                {
                    String imagename = Path.GetFileName(image.FileName); //Path class
                    String extension = Path.GetExtension(imagename);
                    HttpPostedFile postedfile = image.PostedFile;
                    int length = postedfile.ContentLength;

                    if (extension.ToLower() == ".jpg" || extension.ToLower() == ".png" || extension.ToLower() == ".jpeg" || extension.ToLower() == ".gif" || extension.ToLower() == ".bmp")
                    {

                      
                            image.SaveAs(path);
                            name_img = path + imagename;
                        
                    }
                    else
                    {
                    }
                }


                ///////////////////////////
                ///
                //   Queryable String
                //
                //////////////////////

                String QueryString = "insert into achievements2 (title,dt,link,img,descrip,fil) values(@title,@dt,@link,@img,@descrip,@file)";


                //String QueryString = "insert into achievements (title,dt,link,img,descrip,fil) values('hnj','12-12-2024,'http,'hbh','jnjjn','njnjn')";

                SqlCommand cmd = new SqlCommand(QueryString, con);
                cmd.Parameters.Add("@title", title.Text);
                cmd.Parameters.Add("@dt", date.Text);
                cmd.Parameters.Add("@link", link.Text);
                cmd.Parameters.Add("@img", name_img);
                cmd.Parameters.Add("@descrip", description.Text);
                cmd.Parameters.Add("@file", name_file);

                /*        cmd.Parameters.AddWithValue("@title", "s");
                        cmd.Parameters.AddWithValue("@dt", "12/03/2021");
                        cmd.Parameters.AddWithValue("@link", "jmmkmk");
                        cmd.Parameters.AddWithValue("@img", "jujnjnj");
                        cmd.Parameters.AddWithValue("@descrip", "jnjnj");
                        cmd.Parameters.AddWithValue("@file", "unhhjnj");*/

                int cnt = cmd.ExecuteNonQuery();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Successfully Added')</script>");

                if (cnt > 0)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Successfully Added')</script>");
                    Response.Redirect("./achievements.aspx");


                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Unsuccessful Insertion')</script>");

                }



                con.Close();


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Exception" + ex.Message + "')</script>");
            }
        }



        private void RefreshPage()
        {
            Response.Redirect(Request.RawUrl);
        }

        private void DeleteAchievement(int achievementId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();
                    string query = "DELETE FROM achievements2 WHERE Id=@Id";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.Add("@Id", achievementId);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            // Deletion successful
                            Response.Write("<script>alert('Deletion Successful.')</script>");
                            // Refresh the page to reflect changes
                            RefreshPage();
                        }
                        else
                        {
                            // Deletion failed
                            // Optionally, you can show an error message
                            Response.Write("<script>alert('Failed to delete the achievement.')</script>");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Exception handling
                Response.Write("<script>alert('Exception" + ex.Message + "')</script>");
            }
        }
        protected void CardButton_Command(object sender, CommandEventArgs e)
        {
            try
            {
                int achievementId = Convert.ToInt32(e.CommandArgument);

                if (e.CommandName == "Delete")
                {
                    achievementId = Convert.ToInt32(e.CommandArgument);
                    DeleteAchievement(achievementId);
                }
                else if (e.CommandName == "Update")
                {
                    Response.Redirect($"upd_achieve.aspx?id={achievementId}");

                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Exception" + ex.Message + "')</script>");
            }
        }



        private void LoadAchievementsFromDatabase()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                con.Open();
                string query = "SELECT * FROM achievements2";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string title = reader["title"].ToString();
                    string description = reader["descrip"].ToString();
                    string dt = reader["dt"].ToString();

                    string link = reader["link"].ToString();
                    string file = reader["fil"].ToString();
                    int achievementId = Convert.ToInt32(reader["Id"]);


                    string linkButton = string.IsNullOrEmpty(link) ? "" : $"<a href='{link}' class='btn'>Link</a>";
                    string fileButton = string.IsNullOrEmpty(file) ? "" : $"<a href='{file}' class='btn'>File</a>";
                    // Dynamically generate html markup for each record
                    string cardHtml = $@"
                <div class='card'>
                    <div class='card-content'>
                        <h3>{title}</h3>
                        <h5>{dt}</h5>
                        <p>{description}</p>
                   <div class='buttonLink'>
                         {fileButton}
                        {linkButton}
 </div>
                        <div class='buttonLink'>
                            <button class='btn mod' onclick='updateAchievement({achievementId})'>Update</button>
<button class='btn mod' runat='server' commandname='Delete' commandargument='{achievementId}'>Delete</button>
                        </div>
                    </div>
                </div>";

                    // Add the dynamically generated card HTML to a placeholder or panel
                    cardContainer.Controls.Add(new LiteralControl(cardHtml));
                }

                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('Exception: {ex.Message}')</script>");
            }

      

        }
    }
}
