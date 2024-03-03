
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portfolio_ASP.Admin
{
    public partial class index : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] == null)
            {
                Response.Redirect("~/Admin/login.aspx");
            }
            try
            {
                String strcon = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString; 
                



                 


                    SqlConnection con = new SqlConnection(strcon);
                    con.Open();

                    String queryString = "select * from index2";



                    SqlCommand cmd = new SqlCommand(queryString, con);

                    // cmd.Parameters.AddWithValue("@email", email.Text.Trim());
                    /*                cmd.Parameters.AddWithValue("@pass", password.Text);*/


                    SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    string nameValue = dr["name"].ToString();
                    string t1Value = dr["t1"].ToString();
                    string t2Value = dr["t2"].ToString();
                    string t3Value = dr["t3"].ToString();
                    string bioValue = dr["bio"].ToString();
                    string descValue = dr["descrip"].ToString();
                    name.Text = nameValue;
                    Title1.Text = t1Value;
                    Title2.Text = t2Value;
                    Title3.Text = t3Value;
                    bio.Text = bioValue;
                    description.Text = descValue;

                }
                    con.Close();

                

                   
                  

                  
                
            }
            catch (Exception ex)
            {

            }
        }

        protected void sendButton_Click(object sender, EventArgs e)
        {
            String strcon = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                con.Open();
/*                String querystring = "UPDATE index2 SET name = @name, t1 = @t1, t2 = @t2, t3 = @t3, bio = @bio, descrip = @des where id=1";
*/                SqlCommand cmd = new SqlCommand("UpdateIndex2", con);
                cmd.CommandType = CommandType.StoredProcedure;

                //telling the parameters to take value from
                cmd.Parameters.AddWithValue("@name", name.Text);
                cmd.Parameters.AddWithValue("@t1", Title1.Text);
                cmd.Parameters.AddWithValue("@t2", Title2.Text);
                cmd.Parameters.AddWithValue("@t3", Title3.Text);
                cmd.Parameters.AddWithValue("@bio", bio.Text);
                cmd.Parameters.AddWithValue("@des", description.Text);
/*                cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = name.Text.Trim();
                cmd.Parameters.Add("@t1", SqlDbType.VarChar).Value = Title1.Text.Trim();
                cmd.Parameters.Add("@t2", SqlDbType.VarChar).Value = Title2.Text.Trim();
                cmd.Parameters.Add("@t3", SqlDbType.VarChar).Value = Title3.Text.Trim();
                cmd.Parameters.Add("@bio", SqlDbType.VarChar).Value = bio.Text.Trim();
                cmd.Parameters.Add("@des", SqlDbType.VarChar).Value = description.Text.Trim();*/


                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected>0) {

                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Successfully Updated')</script>");

                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Error')</script>");

                }
                con.Close();

                Response.Redirect("~/Admin/index.aspx");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Exception" + ex.Message + "')</script>");
            }
        }
    }
}