using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vneed.UI.Web.Test
{
    public partial class CookieTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = (string)Request.Cookies["tmp"].Value;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Cookies["tmp"].Value = "patrick";
            Response.Cookies["tmp"].Expires = DateTime.Now.AddDays(1);
        }
    }
}