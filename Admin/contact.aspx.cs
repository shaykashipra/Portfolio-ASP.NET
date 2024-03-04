using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Drawing;

namespace Portfolio_ASP.Admin
{
    public partial class contact : System.Web.UI.Page
    {
        String strcon = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["email"] == null)
                {
                    Response.Redirect("~/Admin/login.aspx");
                }
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    string query = "SELECT * FROM contact";
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        address.Text = reader["address"].ToString();
                        email.Text = reader["email"].ToString();
                        phone.Text = reader["phone"].ToString();
                        map.Text = reader["map"].ToString();
                    }
                    reader.Close();

                    con.Close();

                    LoadMessages();
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('Exception" + ex.Message + "')</script>");
                }
            }
        }

        private void LoadMessages()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string strquery = "SELECT * FROM message";
                SqlDataAdapter sda = new SqlDataAdapter(strquery, con);

                DataTable dt = new DataTable();
                sda.Fill(dt);
                CoursesGridView.DataSource = dt;
                CoursesGridView.DataBind();

                if (dt.Rows.Count == 0)
                {
                    CoursesGridView.Visible = false;
                    emptyInbox.Visible = true;
                }

                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Exception" + ex.Message + "')</script>");
            }
        }


        protected void delete_com(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string deleteQuery = "DELETE FROM message WHERE id = @id";
                SqlCommand cmd = new SqlCommand(deleteQuery, con);
                cmd.Parameters.AddWithValue("@id", e.CommandArgument);
                cmd.ExecuteNonQuery();
                con.Close();

                Response.Redirect("~/Admin/contact.aspx");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Exception" + ex.Message + "')</script>");
            }

        }

        protected void send_click(object sender, EventArgs e)
        {
            try
            {
                // Retrieve values from the form controls
                string address = this.address.Text;
                string email = this.email.Text;
                string phone = this.phone.Text;
                string map = this.map.Text;

                // Update the database with the new values
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string updateQuery = "UPDATE contact SET address = @address, email = @email, phone = @phone, map = @map";
                SqlCommand cmd = new SqlCommand(updateQuery, con);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.Parameters.AddWithValue("@map", map);
                cmd.ExecuteNonQuery();
                con.Close();

                Response.Redirect("~/Admin/contact.aspx");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Exception" + ex.Message + "')</script>");
            }
        }
    }
}