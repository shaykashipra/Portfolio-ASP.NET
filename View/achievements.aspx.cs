using Portfolio_ASP.Admin;
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
    public partial class achievements : System.Web.UI.Page
    {
        protected List<Achievement> AchievementsData { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateAchievementsData();
            }
        }
        private void PopulateAchievementsData()
        {
            AchievementsData = new List<Achievement>();

            string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;

            string query = "select title,dt,link,img,descrip,fil from achievements2";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Achievement achievement = new Achievement
                    {
                        Title = reader["title"].ToString(),
                        Date = reader["dt"].ToString(),
                        Description = reader["descrip"].ToString(),
                        ImageUrl = reader["img"].ToString(),
                        FileUrl = reader["fil"].ToString(), 
                        LinkUrl = reader["link"].ToString(),
                    };
                    AchievementsData.Add(achievement);
                }
            }
        }

        public class Achievement
        {
            public string Title { get; set; }
            public string Date { get; set; }
            public string Description { get; set; }
            public string ImageUrl { get; set; }
            public string FileUrl { get; set; }
            public string LinkUrl { get; set; }
        }
    
}
}