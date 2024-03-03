using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Portfolio_ASP
{
    public partial class education : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Fetch data from the database
                List<EducationItem> educationData = GetEducationDataFromDatabase();

                PopulateTimeline(educationData);
            }
        }

        private List<EducationItem> GetEducationDataFromDatabase()
        {
            List<EducationItem> educationData = new List<EducationItem>();

            string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;

            string query = "SELECT title, dt, img, descrip FROM education2";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    EducationItem item = new EducationItem
                    {
                        Title = reader["title"].ToString(),
                        Date = reader["dt"].ToString(),
                        ImageUrl = reader["img"].ToString(),
                        Description = reader["descrip"].ToString()
                    };
                    educationData.Add(item);
                }

                reader.Close();
            }

            return educationData;
        }

        private void PopulateTimeline(List<EducationItem> educationData)
        {
            foreach (EducationItem item in educationData)
            {
                HtmlGenericControl container = new HtmlGenericControl("div");
                container.Attributes["class"] = "container";

                if (educationData.IndexOf(item) % 2 == 0)
                {
                    container.Attributes["class"] += " left-container";
                }
                else
                {
                    container.Attributes["class"] += " right-container";
                }

                HtmlGenericControl logo = new HtmlGenericControl("img");
                logo.Attributes["src"] = item.ImageUrl; // Use the URL from the database
                logo.Attributes["alt"] = "";
                logo.Attributes["class"] = "logo";


                HtmlGenericControl textContainer = new HtmlGenericControl("div");
                textContainer.Attributes["class"] = "text-box";

                HtmlGenericControl title = new HtmlGenericControl("h2");
                title.InnerText = item.Title;

                HtmlGenericControl date = new HtmlGenericControl("small");
                date.InnerText = item.Date;

                HtmlGenericControl description = new HtmlGenericControl("p");
                description.InnerText = item.Description;

                HtmlGenericControl arrow = new HtmlGenericControl("span");
                arrow.Attributes["class"] = educationData.IndexOf(item) % 2 == 0 ? "left-container-arrow" : "right-container-arrow";

                textContainer.Controls.Add(title);
                textContainer.Controls.Add(date);
                textContainer.Controls.Add(description);
                textContainer.Controls.Add(arrow);

                container.Controls.Add(logo);
                container.Controls.Add(textContainer);

                timeline.Controls.Add(container);
            }
        }


/*        private void PopulateTimeline(List<EducationItem> educationData)
        {
            foreach (EducationItem item in educationData)
            {
                HtmlGenericControl container = new HtmlGenericControl("div");
                container.Attributes["class"] = "container";

                if (educationData.IndexOf(item) % 2 == 0)
                {
                    container.Attributes["class"] += " left-container";
                }
                else
                {
                    container.Attributes["class"] += " right-container";
                }

                HtmlGenericControl logo = new HtmlGenericControl("img");
                logo.Attributes["src"] = "./images2/education-" + (educationData.IndexOf(item) % 2 + 1) + ".png";
                logo.Attributes["alt"] = "";
                logo.Attributes["class"] = "logo";

                HtmlGenericControl textContainer = new HtmlGenericControl("div");
                textContainer.Attributes["class"] = "text-box";

                HtmlGenericControl title = new HtmlGenericControl("h2");
                title.InnerText = item.Title;

                HtmlGenericControl date = new HtmlGenericControl("small");
                date.InnerText = item.Date;

                HtmlGenericControl description = new HtmlGenericControl("p");
                description.InnerText = item.Description;

                HtmlGenericControl arrow = new HtmlGenericControl("span");
                arrow.Attributes["class"] = educationData.IndexOf(item) % 2 == 0 ? "left-container-arrow" : "right-container-arrow";

                textContainer.Controls.Add(title);
                textContainer.Controls.Add(date);
                textContainer.Controls.Add(description);
                textContainer.Controls.Add(arrow);

                container.Controls.Add(logo);
                container.Controls.Add(textContainer);

                timeline.Controls.Add(container);
            }
        }*/

        public class EducationItem
        {
            public string Title { get; set; }
            public string Date { get; set; }
            public string Description { get; set; }

            public string ImageUrl { get; set; }
        }

    }
}