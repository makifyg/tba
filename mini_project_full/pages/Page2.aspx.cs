using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace mini_project_full
{
    public partial class Page2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*השמת ערך של הדף הנוכחי ב 
             * Session
             */
            Session["currentPage"] = "page2";


            //user2 הגבלת צפיה רק עבור 
            if ((bool)Session["isLogin"])
                Session["isAuthorizedPage"] = true;
            else
                Session["isAuthorizedPage"] = false;
        }
    }
}