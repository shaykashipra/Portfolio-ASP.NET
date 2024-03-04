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
    public partial class upd_achieve : System.Web.UI.Page
    {

        String strcon = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Check if the "id" query parameter exists
                if (Request.QueryString["id"] != null)
                {
                    int achievementId = Convert.ToInt32(Request.QueryString["id"]);
                    LoadAchievementDetails(achievementId);
                }
                else
                {
                    // Handle case when "id" parameter is missing
                    Response.Redirect("achievements.aspx"); // Redirect to achievements page or show an error message
                }
            }
        }


        private void LoadAchievementDetails(int achievementId)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                con.Open();
                string query = "SELECT * FROM achievements2 WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", achievementId);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    // Populate form fields with achievement details
                    title.Text = reader["title"].ToString();
                    date.Text = reader["dt"].ToString();
                    link.Text = reader["link"].ToString();
                    description.Text = reader["descrip"].ToString();

                    // You can also populate other form fields as needed
                }
                else
                {
                    // Handle case when achievement with specified ID is not found
                    Response.Redirect("achievements.aspx"); // Redirect to achievements page or show an error message
                }

                con.Close();
            }
            catch (Exception ex)
            {
                // Handle exception
                Response.Write($"<script>alert('Exception: {ex.Message}')</script>");
            }
        }


        protected void sendButton_Click(object sender, EventArgs e)
        {
            try
            {
                int achievementId = Convert.ToInt32(Request.QueryString["id"]);
                string Title = title.Text;
                string Date = date.Text;
                string Link = link.Text;
                string Description = description.Text;

                SqlConnection con = new SqlConnection(strcon);
                con.Open();
                string query = "UPDATE achievements2 SET title=@Title, dt=@Date, link=@Link, descrip=@Description WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Title", Title);
                cmd.Parameters.AddWithValue("@Date", Date);
                cmd.Parameters.AddWithValue("@Link", Link);
                cmd.Parameters.AddWithValue("@Description", Description);
                cmd.Parameters.AddWithValue("@Id", achievementId);
                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();

                if (rowsAffected > 0)
                {
                    Response.Redirect("./achievements.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Failed to update achievement.')</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('Exception: {ex.Message}')</script>");
            }
        }
    }
}