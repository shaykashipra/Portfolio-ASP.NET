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
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FetchDataFromDatabase();
            }
        } 

        private void FetchDataFromDatabase()
        {
            try
            {
                string strcon = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;

                using (SqlConnection con = new SqlConnection(strcon))
                {
                    string query = "SELECT name, t1, t2, t3, bio, descrip FROM index2 WHERE id = 1";
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        // Fetch the data from the database
                        string nameValue = dr["name"].ToString();
                        string t1Value = dr["t1"].ToString();
                        string t2Value = dr["t2"].ToString();
                        string t3Value = dr["t3"].ToString();
                        string bioValue = dr["bio"].ToString();
                        string descripValue = dr["descrip"].ToString();

                        // Populate the HTML elements with fetched data
                        shipratitle.InnerText = nameValue;
                        shipratext.InnerText = bioValue;
                        sectiontext.InnerText = descripValue;
                        strong_t1.InnerText = t1Value;
                        strong_t2.InnerText = t2Value;
                        strong_t3.InnerText = t3Value;
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exception
                Response.Write($"<script>alert('Exception: {ex.Message}')</script>");
            }
        }
    }
}