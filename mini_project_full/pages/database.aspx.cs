using System;
using System.Collections.Generic;
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
                Session["isAuthorizedPage"] = true;
            else
                Session["isAuthorizedPage"] = false;

        }
    }
}