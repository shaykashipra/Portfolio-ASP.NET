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

namespace Portfolio_ASP.Admin
{
    public partial class project : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["email"] == null)
                {
                    Response.Redirect("~/Admin/login.aspx");
                }

                BindGrid();
            }
            }

        

        protected void BindGrid()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                con.Open();

                string query = "SELECT * FROM project2";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    GridView2.DataSource = dr;
                    GridView2.DataBind();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                
            }
        }
        protected void sendButton_Click(object sender, EventArgs e)
        {
            try
            {
                string title = this.title.Text.Trim();
                string sub = this.subtitle.Text.Trim();
                string link = this.link.Text.Trim();
                string file = this.file.FileName;
                string description = this.description.Text.Trim();
                /*                string img = this.img.FileName;
                */
                String filePath = "";
                String filePath2 = "";
                if (this.img.HasFile)
                {
                    string fileName = Path.GetFileName(this.img.FileName);
                    filePath = "./dbimages/" + fileName;

                    this.img.SaveAs(Server.MapPath(filePath));
                }

                if (this.file.HasFile) {
                    string fileName2 = Path.GetFileName(this.file.FileName);
                    filePath2 = "./dbimages/" + fileName2;

                    this.img.SaveAs(Server.MapPath(filePath2));
                }
                

                SqlConnection con = new SqlConnection(strcon);
                con.Open();

                string query = "INSERT INTO project2 (title, sub, link, fil, descrip, img) VALUES (@title, @sub, @link, @fil, @descrip, @img)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.Add("@title", title);
                cmd.Parameters.Add("@sub", sub);
                cmd.Parameters.Add("@link", link);
                cmd.Parameters.Add("@fil", filePath2);
                cmd.Parameters.Add("@descrip", description);
                cmd.Parameters.Add("@img", filePath);

                cmd.ExecuteNonQuery();

                con.Close();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('successfull')</script>");


                Response.Redirect("./project.aspx");
            }
            catch (Exception ex)
            {
               
            }
        }
        protected void del_update(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "delete")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    con.Open();

                    string query = "DELETE FROM project2 WHERE id=@id";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();

                    con.Close();
                    Response.Redirect("./project.aspx"); 
                }
                catch (Exception ex)
                {
                 
                }
            }
            else if (e.CommandName == "update")
            {
                Response.Redirect($"upd_project.aspx?id={e.CommandArgument}");

            }
        }

    }
}