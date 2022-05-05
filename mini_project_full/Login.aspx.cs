using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace mini_project_full
{
    public partial class Login : System.Web.UI.Page
    {

        const string userName1 = "user1";
        const string password1 = "1234";
        const string user1Page = "page1.aspx";

        const string userName2 = "user2";
        const string password2 = "4321";
        const string user2Page = "page2.aspx";

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnLogin_ServerClick(object sender, EventArgs e)
        {
            Session["isAdmin"] = false;
            if (
                (inUserName.Value == userName1 && inPassword.Value == password1) ||
                (inUserName.Value == userName2 && inPassword.Value == password2))
            {
                Session["user"] = inUserName.Value;
                Session["isLogin"] = true;

                if (inUserName.Value == userName1)
                {
                    Session["isAdmin"] = true;
                    Response.Redirect(user1Page);
                }
                else if (inUserName.Value == userName2)
                    Response.Redirect(user2Page);
            }
            else
                divError.Style["display"] = "block";
        }
    }
}