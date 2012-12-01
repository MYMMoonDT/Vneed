using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace Vneed.UI.Web.Test
{
    public partial class Cookie : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Request.Cookies["Username"] != null)
                Label1.Text = (string)HttpUtility.UrlDecode(HttpContext.Current.Request.Cookies["Username"].Value, Encoding.UTF8);
            else
                Label1.Text = "无用户名";
        }
    }
}