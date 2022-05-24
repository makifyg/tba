﻿using System;
using System.Collections.Generic;
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
        }

        protected void btn1_ServerClick(object sender, EventArgs e)
        {
            const string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename= |DataDirectory|\myDb.mdf;Integrated Security=True";
            SqlConnection conection = new SqlConnection(connectionString);

            string userName = idUserName.Value;
            string password = idPassword.Value;

            string sqlCommand = $"select count(*) from users where username='{userName}'";
            SqlCommand cmd = new SqlCommand(sqlCommand, conection);
            conection.Open();
            int n = (int)cmd.ExecuteScalar();
            if (n > 0)
                idAddError.InnerHtml = $"User '{userName}' already exist. Please try another username";
            else
            {
                cmd.CommandText = $"insert into users (username, password) values('{userName}', '{password}')"; ;

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