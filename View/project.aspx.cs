using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portfolio_ASP
{
    public partial class project : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindProjects();
            }
        }

        private void BindProjects()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
            string query = "SELECT * FROM project2";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    rptProjects.DataSource = dataTable;
                    rptProjects.DataBind();

                    connection.Close();


                }
            }
        }

        protected void btnDetails_Click(object sender, EventArgs e)
        {

        }

        protected void btnFile_Click(object sender, EventArgs e)
        {

        }
    }
}