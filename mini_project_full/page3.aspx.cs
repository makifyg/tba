using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace mini_project_full
{
    public partial class page3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["currentPage"] = "page3";
            if(!IsPostBack)
                divClickCount.InnerHtml = Session["Page3SessionClicksCount"].ToString();
        }

        protected void btnAddClick_ServerClick(object sender, EventArgs e)
        {
            Session["Page3SessionClicksCount"] = (int)Session["Page3SessionClicksCount"] + 1;
            divClickCount.InnerHtml = Session["Page3SessionClicksCount"].ToString();
        }
    }
}