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
    public partial class skill : System.Web.UI.Page
    {
        protected List<TechSkill> TechSkillsData { get; set; }
        protected List<ProfSkill> ProfSkillsData { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateTechSkillsData();
                PopulateProfSkillsData();
            }
        }

        private void PopulateTechSkillsData()
        {
            TechSkillsData = new List<TechSkill>();
            


            string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
            string query = "SELECT title, per FROM tech_skill";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    TechSkill skill = new TechSkill
                    {
                        Title = reader["title"].ToString(),
                        Percentage = Convert.ToInt32(reader["per"])
                    };
                    // Determine the CSS class based on percentage
                    skill.CssClass = GetCssClassForPercentage(skill.Percentage);
                    TechSkillsData.Add(skill);
                }
            }
        }



        private void PopulateProfSkillsData()
        {
            ProfSkillsData = new List<ProfSkill>();



            string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
            string query = "SELECT title, per FROM prof_skill";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ProfSkill skill2 = new ProfSkill
                    {
                        Title = reader["title"].ToString(),
                        Percentage = Convert.ToInt32(reader["per"])
                    };
                    // Determine the CSS class based on percentage
                    skill2.CssClass = GetCssClassForPercentage(skill2.Percentage);
                    ProfSkillsData.Add(skill2);
                }
            }
        }

        public class TechSkill
        {
            public string Title { get; set; }
            public int Percentage { get; set; }
            public string CssClass { get; set; }
        }

        public class ProfSkill
        {
            public string Title { get; set; }
            public int Percentage { get; set; }
            public string CssClass { get; set; }
        }

        private string GetCssClassForPercentage(int percentage)
        {
            if (percentage >= 80)
            {
                return "skill-high"; 
            }
            else if (percentage >= 50)
            {
                return "skill-medium"; 
            }
            else
            {
                return "skill-low"; 
            }
        }

    }
}


    