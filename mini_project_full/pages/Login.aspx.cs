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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*השמת ערך של הדף הנוכחי ב 
             * Session
             */
            Session["currentPage"] = "login";

            //הדף פתוח לכולם
            Session["isAuthorizedPage"] = true;
        }

        protected void btnLogin_ServerClick(object sender, EventArgs e)
        {
            //איפוס משתנים 
            Session["isAdmin"] = false;
            Session["isLogin"] = false;

            //בדיקת שם המשתמש והסיסמא
            string userName = inUserName.Value;
            string password = inPassword.Value;

            const string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename= |DataDirectory|\myDb.mdf;Integrated Security=True";
            string command = $"select * from users where username='{userName}' and password ='{password}'";
            SqlDataAdapter adapter = new SqlDataAdapter(command, connectionString);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            bool isValid = false;
            if (dt.Rows.Count > 0)
                isValid = true;

            //אם שם המשתמש והסיסמה תקינים
            if (isValid)
            {
                //שמירת שם המשתמש כדי שנוכל להשתמש בו לאחר מכן בדפים אחרים
                Session["user"] = inUserName.Value;

                //שמירת הנתון שהמשתמש שגולש עכשיו הוא משתמש רשום בעל הרשאות
                Session["isLogin"] = true;
                
                if (dt.Rows[0]["isAdmin"] == DBNull.Value)
                    Session["isAdmin"] = false;
                else
                    Session["isAdmin"] = (bool)dt.Rows[0]["isAdmin"];
                Response.Redirect("home.aspx");
            }
            //אם לא הוקשה סיסמא נכונה מציגים הודעת שגיאה
            else
                divError.Style["display"] = "block";
        }
    }
}