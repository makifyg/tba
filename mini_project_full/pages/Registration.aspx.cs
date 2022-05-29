using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace mini_project_full.pages
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["currentPage"] = "regstaton";

            //הדף פתוח לכולם
            Session["isAuthorizedPage"] = true;
            idAddError.Visible = false;
        }

        protected void btn1_ServerClick(object sender, EventArgs e)
        {
            const string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename= |DataDirectory|\myDb.mdf;Integrated Security=True";
            SqlConnection conection = new SqlConnection(connectionString);

            string userName = idUserName.Value;
            string password = idPassword.Value;

            string birthDate = idBirthDate.Value;

            string commandStr = $"select count(*) from users where username='{userName}'";
            SqlCommand cmd = new SqlCommand(commandStr, conection);
            conection.Open();
            
            int n = (int)cmd.ExecuteScalar();
            idAddError.Visible = (n > 0);
            if (n > 0)
                idAddError.InnerHtml = $"User '{userName}' already exist. Please try another username";
            else
            {
                if(birthDate != "")
                    cmd.CommandText = $"insert into users (username, password, birthdate) values('{userName}', '{password}', '{birthDate}')";
                else
                    cmd.CommandText = $"insert into users (username, password) values('{userName}', '{password}')";

                n = cmd.ExecuteNonQuery();
                if (n > 0)
                    idAddResult.InnerHtml = $"User {userName} success added to the system";
                else
                    idAddResult.InnerHtml = $"There was a problem on adding {userName} to the system";
            }
            conection.Close();
        }

   }
}