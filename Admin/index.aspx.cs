
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

        String strcon = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {   if (!IsPostBack)
            {
                if (Session["email"] == null)
                {
                    Response.Redirect("~/Admin/login.aspx");
                }


                try
                {




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
                        Name.Text = nameValue;
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
        }

        protected void sendButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();
                    String querystring = "UPDATE index2 SET name=@name, t1=@t1, t2=@t2, t3 = @t3, bio =@bio,descrip=@des where id=@id";
                    String nm = Name.Text;
                    String t1 = Title1.Text;
                    String t2 = Title2.Text;
                    String t3 = Title3.Text;
                    String Bio = bio.Text;
                    String des = description.Text;
                    using (SqlCommand cmd = new SqlCommand(querystring, con))
                    { 
                    //telling the parameters to take value from
                    cmd.Parameters.Add("@name", nm);
                    cmd.Parameters.AddWithValue("@t1", t1);
                    cmd.Parameters.AddWithValue("@t2", t2);
                    cmd.Parameters.AddWithValue("@t3", t3);
                    cmd.Parameters.AddWithValue("@bio", Bio);
                    cmd.Parameters.AddWithValue("@des", des);
                    cmd.Parameters.AddWithValue("@id",1);

                        /*                cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = name.Text.Trim();
                                        cmd.Parameters.Add("@t1", SqlDbType.VarChar).Value = Title1.Text.Trim();
                                        cmd.Parameters.Add("@t2", SqlDbType.VarChar).Value = Title2.Text.Trim();
                                        cmd.Parameters.Add("@t3", SqlDbType.VarChar).Value = Title3.Text.Trim();
                                        cmd.Parameters.Add("@bio", SqlDbType.VarChar).Value = bio.Text.Trim();
                                        cmd.Parameters.Add("@des", SqlDbType.VarChar).Value = description.Text.Trim();*/


                        int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                            con.Close();

                            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Successfully Updated')</script>");
                        Response.Redirect("~/Admin/index.aspx");
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Error')</script>");

                    }
                }
            }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Exception" + ex.Message + "')</script>");
            }
        }
    }
}