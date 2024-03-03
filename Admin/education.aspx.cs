

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Xml.Linq;

namespace Portfolio_ASP.Admin
{
    public partial class education : System.Web.UI.Page
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
                String strquery = "select id,title,dt,descrip,img from education2";
                SqlDataAdapter sda = new SqlDataAdapter(strquery, con);

                DataTable dt = new DataTable();

                sda.Fill(dt);
                CoursesGridView.DataSource = dt;
                CoursesGridView.DataBind();

                if (dt.Rows.Count == 0)
                {

                    CoursesGridView.Visible = false;
                }

                con.Close();


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Exception" + ex.Message + "')</script>");
            }
        }


        protected void del_update(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                if (e.CommandName == "delete")
                {
                    string deleteQuery = "delete from education2 where id = @id";
                    SqlCommand cmd = new SqlCommand(deleteQuery, con);
                    cmd.Parameters.Add("@id", e.CommandArgument);
                    cmd.ExecuteNonQuery();
                }
                con.Close();

                Response.Redirect("~/Admin/education.aspx");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Exception" + ex.Message + "')</script>");
            }

        }

 


        protected void sendButton_Click(object sender, EventArgs e)
        {
            try {

                string name = title.Text;
                string desc = description.Text;
                string dt = dateRange.Text;

                if (image.HasFile)
                {
                    string fileName = Path.GetFileName(image.FileName);
                    string filePath = "~/dbimages/" + fileName;

                    image.SaveAs(Server.MapPath(filePath));

                    using (SqlConnection con = new SqlConnection(strcon))
                    {
                        con.Open();

                        SqlCommand cmd = new SqlCommand("InsertEducation2", con);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Name", name);
                        cmd.Parameters.AddWithValue("@Date", dt);
                        cmd.Parameters.AddWithValue("@Image", filePath);
                        cmd.Parameters.AddWithValue("@Description", desc);

                        cmd.ExecuteNonQuery();

                        Response.Write("<script>alert('Data inserted successfully')</script>");

                        con.Close();
                    }
                }
                else
                {
                    Response.Write("<script>alert('Please upload an image')</script>");
                }
            }
            catch (Exception ex)
            {
              
                Response.Write("<script>alert('Exception: " + ex.Message + "')</script>");
            }
       
        }


       
                
            



        }


}
