using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portfolio_ASP.Admin
{
    public partial class upd_project : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    int projectId = Convert.ToInt32(Request.QueryString["id"]);
                    FetchProjectData(projectId);
                }
            }
        }

        protected void FetchProjectData(int projectId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();
                    string query = "SELECT * FROM project2 WHERE id = @Id";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Id", projectId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        title.Text = reader["title"].ToString();
                        subtitle.Text = reader["sub"].ToString();
                        link.Text = reader["link"].ToString();
                        // file.FileName = reader["fil"].ToString();
                        description.Text = reader["descrip"].ToString();
                        // img.ImageUrl = reader["img"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('Exception: {ex.Message}')</script>");
            }
        }

        protected void sendButton_Click(object sender, EventArgs e)
        {
            try
            {
                int projectId = Convert.ToInt32(Request.QueryString["id"]);
                string Title = title.Text;
                string Subtitle = subtitle.Text;
                string Link = link.Text;
                string File = file.FileName; 
                string Description = description.Text;

                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();
                    string query = "UPDATE project2 SET title=@Title, sub=@Subtitle, link=@Link, descrip=@Description WHERE Id=@Id";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Title", Title);
                    cmd.Parameters.AddWithValue("@Subtitle", Subtitle);
                    cmd.Parameters.AddWithValue("@Link", Link);
                    cmd.Parameters.AddWithValue("@File", File); 
                    cmd.Parameters.AddWithValue("@Description", Description);
                    cmd.Parameters.AddWithValue("@Id", projectId);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    con.Close();

                    if (rowsAffected > 0)
                    {
                        Response.Redirect("~/Admin/project.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('Failed to update project information.')</script>");
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('Exception: {ex.Message}')</script>");
            }
        }
    }
}