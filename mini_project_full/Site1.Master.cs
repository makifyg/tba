using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace mini_project_full
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bool authorize = true;
            if ((bool)Session["isLogin"] == false && ((string)Session["currentPage"] != "home"))
                authorize = false;

            if ((bool)Session["isAdmin"] == false && ((string)Session["currentPage"] == "admin1"))
                authorize = false;

            if (authorize==false)
                ContentPlaceHolder1.Visible = false;
            else
                divNotAuthorized.Visible = false;

            string currentPage = (string)Session["currentPage"];
            if (currentPage == "home")
                pgHome.Attributes["class"] = "active";
            else if (currentPage == "page1")
                pgPage1.Attributes["class"] = "active";
            else if (currentPage == "page2")
                pgPage2.Attributes["class"] = "active";
            else if (currentPage == "page3")
                pgPage3.Attributes["class"] = "active";
            else if (currentPage == "admin1")
                pgAdmin1.Attributes["class"] = "active";

            aUser.InnerHtml = (string)Session["user"];

            if ((string)Session["user"] != "user1")
                liPage1.Visible = false;

            if ((string)Session["user"] != "user2")
                liPage2.Visible = false;

            if ((bool)Session["isLogin"] == false)
            {
                liPage3.Visible = false;
                liLogout.Visible = false;
            }

            if (!IsPostBack)
            {
                if (Application[currentPage + "Count"] == null)
                    Application[currentPage + "Count"] = 0;
                Application[currentPage + "Count"] = (int)Application[currentPage + "Count"] + 1;
            }
            divPageVisitCount.InnerHtml = Application[currentPage + "Count"].ToString();
            

            if ((bool)Session["isAdmin"] == false)
            {
                liAdmin.Visible = false;
                divCountersForAdmin.Visible = false;
            }
        }

        protected void aLogout_ServerClick(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("home.aspx");           
        }
    }
}