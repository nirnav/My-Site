using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public string messege = "";
        public string fullname;
        public string username;
        public string email;
        public string sclass;
        string password;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.HttpMethod == "POST")
            {
                string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\SiteDB.mdf;Integrated Security=True";
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                fullname = Request.Form["FullName"];
                username = Request.Form["Username"];
                email = Request.Form["Email"];
                password = Request.Form["Password"];
                sclass = Request.Form["Sclass"];

                bool check = true;
                command.CommandText = String.Format("SELECT Email FROM Users WHERE Email='{0}' ", email);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    messege = "A member with this E-mail already exists</br>";
                    check = false;
                }
                reader.Close();
                command.CommandText = String.Format("SELECT Username FROM Users WHERE Username='{0}' ", username);
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    messege = "A member with this username already exists";
                    check = false;
                }
                reader.Close();
                if (check)
                {
                    try
                    {
                        command.CommandText = string.Format("INSERT INTO Users (FullName, Username, Email, Password, Class) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');", fullname, username, email, password, sclass);
                        command.ExecuteNonQuery();
                        messege = "SignUp Succeful! <a href = \"index.aspx\"><u>return home<u/><a/>";


                    }
                    catch
                    {
                        messege = "An error occurred during signup, please try again .<br/>";
                    }
                }


                connection.Close();
            }
        }

    }
}