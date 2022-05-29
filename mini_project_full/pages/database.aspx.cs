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
    public partial class database : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["currentPage"] = "database";

            //הדף פתוח רק למשתמשים רשומים
            if ((bool)Session["isLogin"])
            {
                Session["isAuthorizedPage"] = true;
                if (!IsPostBack)
                    ShowAnimalTabel();
            }
            else
                Session["isAuthorizedPage"] = false;
        }

        const string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|myDb.mdf;Integrated Security=True";

        private void ShowAnimalTabel()
        {
            string command = "select * from animals";
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command, connectionString);
            int count = adapter.Fill(dt);

            string htmlTable = getHtmlTableFromDataTable(dt);
            animalsTableId.InnerHtml = htmlTable;
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

        protected void btnInsertId_ServerClick(object sender, EventArgs e)
        {
            SqlConnection conection = new SqlConnection(connectionString);
            string sqlCommand = $"insert into animals (name, type) values ('{insertAnimalNameId.Value}','{insertAnimalTypeId.Value}')";
            SqlCommand cmd = new SqlCommand(sqlCommand, conection);
            conection.Open();
            int n = cmd.ExecuteNonQuery();
            conection.Close();
            insertResultId.InnerHtml = $"Result: {n.ToString()}";
            ShowAnimalTabel();
        }

        protected void btnUpdateId_ServerClick(object sender, EventArgs e)
        {
            SqlConnection conection = new SqlConnection(connectionString);
            string sqlCommand = $"update animals set type='{updateAnimalTypeId.Value}', isEndangered='{updateAnimalEndangeredId.Checked}', updateDate='{DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day}', estimation={updateAnimalEstimationId.Value}, size='{updateAnimalSizeId.Value}' where name = '{updateAnimalNameId.Value}'";
            SqlCommand cmd = new SqlCommand(sqlCommand, conection);
            conection.Open();
            int n = cmd.ExecuteNonQuery();
            conection.Close();
            deleteResultId.InnerHtml = $"Result: {n.ToString()}";
            ShowAnimalTabel();
        }

        protected void btnDeleteId_ServerClick(object sender, EventArgs e)
        {
            SqlConnection conection = new SqlConnection(connectionString);
            string sqlCommand = $"delete from animals where name like '{deleteAnimalNameId.Value}'";
            SqlCommand cmd = new SqlCommand(sqlCommand, conection);
            conection.Open();
            int n = cmd.ExecuteNonQuery();
            conection.Close();
            deleteResultId.InnerHtml = $"Result: {n.ToString()}";
            ShowAnimalTabel();
        }

        protected void btnSelectId_ServerClick(object sender, EventArgs e)
        {
            string command = selectQueryId.Value;
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command, connectionString);
            int count = adapter.Fill(dt);

            string htmlTable = getHtmlTableFromDataTable(dt);
            selectResultId.InnerHtml = htmlTable;
        }

        protected void btnSelectCountId_ServerClick(object sender, EventArgs e)
        {
            SqlConnection conection = new SqlConnection(connectionString);
            string sqlCommand = $"select count(*) from animals where {selectCountWhereId.Value}";
            SqlCommand cmd = new SqlCommand(sqlCommand, conection);
            conection.Open();
            int n = (int)cmd.ExecuteScalar();
            conection.Close();
            selectCountResultId.InnerHtml = $"Result: {n.ToString()}";
            ShowAnimalTabel();
        }
    }
}