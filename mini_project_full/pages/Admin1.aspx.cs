using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace mini_project_full
{
    public partial class Admin1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*השמת ערך של הדף הנוכחי ב 
               * Session
               */
            Session["currentPage"] = "admin1";

            if((bool)Session["isAdmin"])
                Session["isAuthorizedPage"] = true;
            else
                Session["isAuthorizedPage"] = false;

            const string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|myDb.mdf;Integrated Security=True";
            string command = "select * from animals";
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command, connectionString);
            int count = adapter.Fill(dt);

            string htmlTable = getHtmlTableFromDataTable(dt);
            div1.InnerHtml = htmlTable;
        }

        string getHtmlTableFromDataTable(DataTable dt)
        {
            string htmlTable = "<table border=1>";

            //הוספת שורה עליונה עם שמות השדות
            htmlTable += "<tr>";
            for (int colIndex = 0; colIndex < dt.Columns.Count; colIndex++)
            {
                htmlTable += "<th>";
                htmlTable += dt.Columns[colIndex].ColumnName;
                htmlTable += "</th>";
            }
            htmlTable += "</tr>";

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                htmlTable += "<tr>";
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    htmlTable += "<td>";
                    if (dt.Columns[j].ColumnName == "isEndangered")
                    {
                        if (dt.Rows[i][j] == DBNull.Value)
                            htmlTable += "False";
                        else
                            htmlTable += dt.Rows[i][j];
                    }
                    else
                        htmlTable += dt.Rows[i][j];
                    
                    htmlTable += "</td>";
                }
                htmlTable += "</tr>";
            }
            htmlTable += "</table>";

            return htmlTable;
        }

    }
}