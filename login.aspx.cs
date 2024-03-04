using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portfolio_ASP.Admin
{
    public partial class login : System.Web.UI.Page
    {
     String strcon = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["email"] != null && Request.Cookies["password"] != null)
                {
                    email.Text = Request.Cookies["email"].Value;
                    password.Attributes["value"] = Request.Cookies["password"].Value;
                    rememberme.Checked = true;
                }
            }
        }
        protected void login_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                con.Open();

                String queryString = "select * from login where email=@email";

                SqlCommand cmd = new SqlCommand(queryString, con);

                cmd.Parameters.AddWithValue("@email", email.Text.Trim());

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    dr.Close();

                    queryString = "select * from login where email=@email";

                    SqlCommand cmd2 = new SqlCommand(queryString, con);
                    cmd2.Parameters.AddWithValue("@email", email.Text.Trim());

                    SqlDataReader dr2 = cmd2.ExecuteReader();
                    if (dr2.HasRows)
                    {
                        dr2.Read();
                        string storedPassword = dr2["password"].ToString();
                        string inputPassword = password.Text.Trim();

                        if (VerifyHashedPassword(inputPassword, storedPassword))
                        {
                            Session["email"] = email.Text.Trim();
                            Session["password"] = storedPassword;

                            if (rememberme.Checked)
                            {
                                // Store unhashed password in the cookie
                                Response.Cookies["email"].Value = email.Text;
                                Response.Cookies["password"].Value = inputPassword;
                                Response.Cookies["email"].Expires = DateTime.Now.AddDays(15);
                                Response.Cookies["password"].Expires = DateTime.Now.AddDays(15);
                            }
                            else
                            {
                                Response.Cookies["email"].Expires = DateTime.Now.AddDays(-1);
                                Response.Cookies["password"].Expires = DateTime.Now.AddDays(-1);
                            }

                            Response.Redirect("~/Admin/index.aspx");
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Log In Successful')</script>");
                        }
                        else
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Wrong Password')</script>");
                        }
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Wrong Email')</script>");
                    }
                }

                con.Close();
            }
            catch (Exception ex)
            {
                // Handle exception
            }
        }

        private bool VerifyHashedPassword(string inputPassword, string storedPassword)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] hashedBytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(inputPassword));
                string hashedPassword = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();

                return string.Equals(hashedPassword, storedPassword);
            }
        }


        /*      protected void login_Click(object sender, EventArgs e)
              {
                  try
                  {
                      SqlConnection con = new SqlConnection(strcon);
                      con.Open();

                      String queryString = "select * from login where email=@email";

                      SqlCommand cmd = new SqlCommand(queryString, con);

                      cmd.Parameters.AddWithValue("@email", email.Text.Trim());

                      SqlDataReader dr = cmd.ExecuteReader();

                      if (dr.HasRows)
                      {
                          dr.Close();

                          queryString = "select * from login where email=@email and password=@pass";

                          SqlCommand cmd2 = new SqlCommand(queryString, con);
                          cmd2.Parameters.AddWithValue("@email", email.Text.Trim());

                          string hashedPassword = HashPassword(password.Text.Trim());
                          Console.WriteLine("Hashed Password: " + hashedPassword);

                          cmd2.Parameters.AddWithValue("@pass", hashedPassword);

                          SqlDataReader dr2 = cmd2.ExecuteReader();
                          if (dr2.HasRows)
                          {
                              Session["email"] = email.Text.Trim();
                              Session["password"] = hashedPassword;


                              if (rememberme.Checked)
                              {
                                  Response.Cookies["email"].Value = email.Text;
                                  Response.Cookies["password"].Value = hashedPassword;
                                  Response.Cookies["email"].Expires = DateTime.Now.AddDays(15);
                                  Response.Cookies["password"].Expires = DateTime.Now.AddDays(15);
                              }
                              else
                              {
                                  Response.Cookies["email"].Expires = DateTime.Now.AddDays(-1);
                                  Response.Cookies["password"].Expires = DateTime.Now.AddDays(-1);
                              }

                              Response.Redirect("~/Admin/index.aspx");
                              Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Log In Successful')</script>");
                          }
                          else
                          {
                              Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Wrong Password')</script>");
                          }
                      }
                      else
                      {
                          Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Wrong Email')</script>");
                      }

                      con.Close();
                  }
                  catch (Exception ex)
                  {

                  }
              }
              private string HashPassword(string password)
              {
                  using (SHA256 sha256Hash = SHA256.Create())
                  {
                      byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                      StringBuilder builder = new StringBuilder();
                      for (int i = 0; i < bytes.Length; i++)
                      {
                          builder.Append(bytes[i].ToString("x2"));
                      }
                      return builder.ToString();
                  }
              }*/
    }
}