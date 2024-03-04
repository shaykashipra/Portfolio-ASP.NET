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
    public partial class upd_skill : System.Web.UI.Page
    {
        String strcon = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string id = Request.QueryString["id"];
                string SkillType = Request.QueryString["skilltype"];

                PopulateFormData(id, SkillType);
            }
        }
        private void PopulateFormData(string id, string SkillType)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = string.Empty;
                if (SkillType == "tech")
                {
                    query = "SELECT title, per FROM tech_skill WHERE id = @id";
                }
                else if (SkillType == "prof")
                {
                    query = "SELECT title, per FROM prof_skill WHERE id = @id";
                }

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    title.Text = reader["title"].ToString();
                    perc.Text = reader["per"].ToString();
                    skillType.SelectedValue = SkillType;

                }
            }
        }


        protected void sendButton_Click(object sender, EventArgs e)
        {
            try
            {
                int skillID = Convert.ToInt32(Request.QueryString["id"]);
                string titleValue = title.Text;
                int percentageValue = Convert.ToInt32(perc.Text);
                string skillTypeValue = Request.QueryString["skilltype"]; // Retrieve the skill type from the query string

                string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = string.Empty;

                    if (skillTypeValue == "tech")
                    {
                        query = "UPDATE tech_skill SET title=@Title, per=@Percentage WHERE Id=@Id";
                    }
                    else if (skillTypeValue == "prof")
                    {
                        query = "UPDATE prof_skill SET title=@Title, per=@Percentage WHERE Id=@Id";
                    }

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Title", titleValue);
                    cmd.Parameters.AddWithValue("@Percentage", percentageValue);
                    cmd.Parameters.AddWithValue("@Id", skillID);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    con.Close();

                    if (rowsAffected > 0)
                    {
                        Response.Redirect("~/Admin/skill.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('Failed to update skill information.')</script>");
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