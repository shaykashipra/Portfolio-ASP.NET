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
    public partial class project : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] == null)
            {
                Response.Redirect("~/Admin/login.aspx");
            }
            if (!IsPostBack)
            {
                BindGrid();
            }

        }

        protected void BindGrid()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                con.Open();

                string query = "SELECT * FROM project2";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    GridView2.DataSource = dr;
                    GridView2.DataBind();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                
            }
        }
        protected void sendButton_Click(object sender, EventArgs e)
        {
            try
            {
                string title = this.title.Text.Trim();
                string sub = this.subtitle.Text.Trim();
                string link = this.link.Text.Trim();
                string file = this.file.FileName;
                string description = this.description.Text.Trim();
                string img = this.img.FileName;

                SqlConnection con = new SqlConnection(strcon);
                con.Open();

                string query = "INSERT INTO project2 (title, sub, link, fil, descrip, img) VALUES (@title, @sub, @link, @fil, @descrip, @img)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@sub", sub);
                cmd.Parameters.AddWithValue("@link", link);
                cmd.Parameters.AddWithValue("@fil", file);
                cmd.Parameters.AddWithValue("@descrip", description);
                cmd.Parameters.AddWithValue("@img", img);

                cmd.ExecuteNonQuery();

                con.Close();
                BindGrid();
            }
            catch (Exception ex)
            {
               
            }
        }
        protected void del_update(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "delete")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    con.Open();

                    string query = "DELETE FROM project2 WHERE id=@id";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();

                    con.Close();
                    BindGrid(); // Refresh the grid after deletion
                }
                catch (Exception ex)
                {
                    // Handle exceptions
                }
            }
            else if (e.CommandName == "update")
            {
                // Handle update logic here
            }
        }

    }
}