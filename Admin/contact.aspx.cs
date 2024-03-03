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
                String strquery = "select * from message";
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
    }
}