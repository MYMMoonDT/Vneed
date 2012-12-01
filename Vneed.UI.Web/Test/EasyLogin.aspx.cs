using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vneed.BLL;

namespace Vneed.UI.Web.Test
{
    public partial class EasyLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
                if (UserService.VerifyPassword(this.TextBox1.Text, this.TextBox2.Text))
                {
                    AuthenticationService.Login(this.TextBox1.Text);
                    Response.Redirect("/Admin/index.aspx");
                }
        }
    }
}