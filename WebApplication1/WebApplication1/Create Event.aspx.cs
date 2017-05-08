using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        public string message = "";
     
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null)
                Response.Redirect("Front.aspx");
            if (Request.HttpMethod == "POST")
            {
                string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\SiteDB.mdf;Integrated Security=True";
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                string name = Request.Form["name"];
                string edate = Request.Form["edate"];
                string location = Request.Form["location"];
                string description = Request.Form["description"];
                string sclass = Request.Form["Sclass"];


                //try
                //{
                    command.CommandText = string.Format("INSERT INTO SEvents (Name, EDate, Location, Class, Description, OrginizerId) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');", name, edate, location, sclass, description, Session["UserId"]);
                    command.ExecuteNonQuery();
                    
                try
                {
                    command.CommandText = "SELECT TOP 1 * FROM SEvents ORDER BY ID DESC";
                    SqlDataReader reader = command.ExecuteReader();
                    int Tname = reader.GetInt32(0);
                    reader.Close();
                    command.CommandText = string.Format(@"CREATE TABLE {0} (
                                                          ID int IDENTITY(1, 1) PRIMARY KEY,
                                                          SailNumber int NOT NULL UNIQUE,
                                                          Name varchar(255));", Tname);
                    command.ExecuteNonQuery();
                    message = "Event announced! <a href = \"Home.aspx\"><u>Return home</u></a>, or to your <a href = \"Personal Zone.aspx\"><u>personal zone.</u></a>";
                }
                catch
                {
                    message = "Failed to create a participetns list. Please try again.";
                }
                /*}
                  catch
                  {
                      message = "An error occurred while updating the database, please try again.<br/>";
                  }*/
                
                connection.Close();
            }
        }
    }
}