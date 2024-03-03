using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portfolio_ASP
{
    public partial class contact : System.Web.UI.Page
    {

        String strcon = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
        
        }

        protected void send_click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                con.Open();

                String queryString = "insert into message values(@fn,@ln,@email,@phn,@msg)";

                SqlCommand cmd=new SqlCommand(queryString, con);

                cmd.Parameters.Add("@fn",firstname.Text);
                cmd.Parameters.Add("@ln",lastname.Text);
                cmd.Parameters.Add("@email",email.Text);
                cmd.Parameters.Add("@phn",phone.Text);
                cmd.Parameters.Add("@msg",message.Text);

                cmd.ExecuteNonQuery();

                con.Close();

             //to solve the pb when reloading page inseted data into database
                Response.Redirect("./contact.aspx"); 


            }
            catch (Exception ex)
            {

            }
        }
    }
}