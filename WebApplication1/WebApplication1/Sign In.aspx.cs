using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace WebApplication1
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        public string failed = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.HttpMethod == "POST")
            {
                string username = Request.Form["Username"];
                string password = Request.Form["Password"];

                SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\SiteDB.mdf;Integrated Security=True");
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.CommandText = String.Format("SELECT * FROM Users WHERE Username='{0}' AND Password='{1}'", username, password);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    Session["UserId"] = reader.GetInt32(0);
                    Session["Username"] = username;
                    Session["Name"] = reader.GetString(3);
                    Response.Redirect("Home.aspx");
                }
                else
                {
                    failed = "The username or password you entered were wrong.";
                }
                reader.Close();
                connection.Close();
            }
        }
    }
}