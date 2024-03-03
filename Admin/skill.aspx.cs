using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portfolio_ASP.Admin
{
    public partial class skill : System.Web.UI.Page
    {

        string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] == null)
            {
                Response.Redirect("~/Admin/login.aspx");
            }
            if (!IsPostBack)
            {
                BindProfessionalCoursesGridView();
                BindTechnicalCoursesGridView();
            }
        }

        protected void BindProfessionalCoursesGridView()
        {
            string query = "SELECT id, title, per FROM Prof_Skill";

            using (SqlConnection connection = new SqlConnection(connectionString))

            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        ProfessionalCoursesGridView.DataSource = dataTable;
                        ProfessionalCoursesGridView.DataBind();
                    }
                }
                connection.Close();

            }
        }

        protected void BindTechnicalCoursesGridView()
        {
            string query = "SELECT id, title, per FROM Tech_Skill";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        TechnicalCoursesGridView.DataSource = dataTable;
                        TechnicalCoursesGridView.DataBind();
                    }
                }

                connection.Close();
            }

            
        }


        protected void sendButton_Click(object sender, EventArgs e)
        {
        
                string skillTypeValue = skillType.SelectedValue;
                string titleValue = title.Text;
                int percentageValue = Convert.ToInt32(perc.Text);

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        string insertQuery = "";
                        if (skillTypeValue == "prof")
                        {
                            insertQuery = "INSERT INTO Prof_Skill  VALUES (@title, @percentage)";
                        }
                        else if (skillTypeValue == "tech")
                        {
                            insertQuery = "INSERT INTO Tech_Skill  VALUES (@title, @percentage)";
                        }

                        using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
                        {
                            cmd.Parameters.AddWithValue("@title", titleValue);
                            cmd.Parameters.AddWithValue("@percentage", percentageValue);

                            int rowsAffected = cmd.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                            Response.Redirect("~/Admin/skill.aspx");

                            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert(' Successfully Added')</script>");


                        }
                        else
                            {

                            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Failed to Add')</script>");

                        }
                    }

                    connection.Close();
                }
                }
                catch (Exception ex)
                {
                Response.Write("<script>alert('Exception: " + ex.Message + "')</script>");

            }
        }


        protected void ProfessionalCoursesGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "update")
            {
                int id = Convert.ToInt32(e.CommandArgument);
            }
            else if (e.CommandName == "delete")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                
                    SqlConnection con = new SqlConnection(connectionString);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    
                        string deleteQuery = "delete from prof_skill where id = @id";
                        SqlCommand cmd = new SqlCommand(deleteQuery, con);
                        cmd.Parameters.Add("@id", e.CommandArgument);
                        cmd.ExecuteNonQuery();
                    
                    con.Close();

                    Response.Redirect("~/Admin/skill.aspx");
                
          
            }
        }

        protected void TechnicalCoursesGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "update")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                // Redirect to update page or implement update logic
            }
            else if (e.CommandName == "delete")
            {
                int id = Convert.ToInt32(e.CommandArgument);

                SqlConnection con = new SqlConnection(connectionString);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                string deleteQuery = "delete from Tech_skill where id = @id";
                SqlCommand cmd = new SqlCommand(deleteQuery, con);
                cmd.Parameters.Add("@id", e.CommandArgument);
                cmd.ExecuteNonQuery();

                con.Close();

                Response.Redirect("~/Admin/skill.aspx");
            }
        }


    }
}
    