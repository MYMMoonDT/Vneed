﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vneed.UI.Web.Page.V2.Help
{
    public partial class registerSuccess : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void VneedHomePageButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Page/V2/index.aspx");
        }
    }
}