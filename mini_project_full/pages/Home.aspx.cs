﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace mini_project_full
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*השמת ערך של הדף הנוכחי ב 
               * Session
               */
            Session["currentPage"] = "home";


            //הדף פתוח לכולם
            Session["isAuthorized"] = true;
        }
    }
}