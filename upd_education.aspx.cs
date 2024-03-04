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
    public partial class upd_education : System.Web.UI.Page
    {

        String strcon = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    int educationId = Convert.ToInt32(Request.QueryString["id"]);
                    FetchEducationData(educationId);
                }
            }

        }
            protected void FetchEducationData(int educationId)
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(strcon))
                    {
                        con.Open();
                        string query = "SELECT * FROM education2 WHERE id = @Id";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@Id", educationId);
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            title.Text = reader["title"].ToString();
                            dateRange.Text = reader["dt"].ToString();
                            description.Text = reader["descrip"].ToString();
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
                int educationId = Convert.ToInt32(Request.QueryString["id"]);
                string Title = title.Text;
                string Date = dateRange.Text;
                string Description = description.Text;

                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();
                    string query = "UPDATE education2 SET title=@Title, dt=@Date, descrip=@Description WHERE Id=@Id";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Title", Title);
                    cmd.Parameters.AddWithValue("@Date", Date);
                    cmd.Parameters.AddWithValue("@Description", Description);
                    cmd.Parameters.AddWithValue("@Id", educationId);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    con.Close();

                    if (rowsAffected > 0)
                    {
                        Response.Redirect("~/Admin/education.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('Failed to update educational information.')</script>");
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