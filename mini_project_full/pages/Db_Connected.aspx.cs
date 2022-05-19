using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace mini_project_full
{
    public partial class Db3 : System.Web.UI.Page
    {
        const string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|myDb.mdf;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["currentPage"] = "dbConnected";

            //הדף פתוח לכולם
            Session["isAuthorized"] = true;


            ShowAnimalTabel();
        }

        protected void btnSelectCount_ServerClick(object sender, EventArgs e)
        {
            SqlConnection conection = new SqlConnection(connectionString);
            string sqlCommand = idSelectCount.Value;
            SqlCommand cmd = new SqlCommand(sqlCommand, conection);
            conection.Open();
            int n = (int)cmd.ExecuteScalar();
            conection.Close();
            idSelectCountResult.InnerHtml = $"Count Result: {n.ToString()}";
            ShowAnimalTabel();
        }

        protected void btnAdd_ServerClick(object sender, EventArgs e)
        {
            SqlConnection conection = new SqlConnection(connectionString);
            string name = inAnimalNameToAdd.Value;
            string type = inAnimalTypeToAdd.Value;

            string sqlCommand = $"insert into animals (name, type) values('{name}', '{type}')";
            SqlCommand cmd = new SqlCommand(sqlCommand, conection);
            conection.Open();
            int n = (int)cmd.ExecuteNonQuery();
            conection.Close();
            idAddResult.InnerHtml = $"Success add {n.ToString()} animals";
            ShowAnimalTabel();
        }

        protected void btnUpdate_ServerClick(object sender, EventArgs e)
        {
            SqlConnection conection = new SqlConnection(connectionString);
            string name = idNameToUpdate.Value;
            string type = idTypeToUpdate.Value;
            bool isEndangered = bool.Parse(idUpdateEndangered.Value);
            string size = idUpdateSize.Value;
            int estimation = int.Parse(idUpdateEstimation.Value);

            string sqlCommand = $"update animals set type='{type}', isEndangered='{isEndangered}', size='{size}', estimation='{estimation}' where name='{name}'";
            SqlCommand cmd = new SqlCommand(sqlCommand, conection);
            conection.Open();
            int n = (int)cmd.ExecuteNonQuery();
            conection.Close();
            idUpdateResult.InnerHtml = $"Success update {n.ToString()} animals";
            ShowAnimalTabel();
        }

        protected void btnDelete_ServerClick(object sender, EventArgs e)
        {
            SqlConnection conection = new SqlConnection(connectionString);
            string name = idNameToDelete.Value;

            string sqlCommand = $"delete from animals where name='{name}'";
            SqlCommand cmd = new SqlCommand(sqlCommand, conection);
            conection.Open();
            int n = (int)cmd.ExecuteNonQuery();
            conection.Close();
            idUpdateResult.InnerHtml = $"Success delete {n.ToString()} animals";
            ShowAnimalTabel();
        }

        private void ShowAnimalTabel()
        {
            string command = "select * from animals";
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command, connectionString);
            int count = adapter.Fill(dt);

            string htmlTable = getHtmlTableFromDataTable(dt);
            idAnimalsTable.InnerHtml = htmlTable;
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