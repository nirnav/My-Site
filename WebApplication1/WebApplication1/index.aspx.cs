using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace WebApplication1
{
    public partial class index : System.Web.UI.Page
    {
        public string message = "Hello guest!";
        protected void Page_Load(object sender, EventArgs e)
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\SiteDB.mdf;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            if (Session["UserId"] != null)
            {
                message = "Hello " + Session["Username"];
            }
            connection.Close();
        }
    }
}