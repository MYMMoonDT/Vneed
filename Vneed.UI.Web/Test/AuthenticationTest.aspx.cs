using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vneed.BLL;

namespace Vneed.UI.Web.Test
{
    public partial class AuthenticationTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string username = AuthenticationService.GetUsername();
            if (username == null)
                Label1.Text = "目前尚未登录";
            else
                Label1.Text = "欢迎你，" + username;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            AuthenticationService.Login(TextBox1.Text);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            AuthenticationService.Logout();
        }
    }
}