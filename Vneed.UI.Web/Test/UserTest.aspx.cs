using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vneed.Model;
using Vneed.DAL.Repository;
using Vneed.BLL;

namespace Vneed.UI.Web.Test
{
    public partial class UserTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string s = (string)Page.Response.Cookies["Hello"].Value;
        }

        protected void ButtonVerifyUsername_Click(object sender, EventArgs e)
        {
            if (UserService.VerifyUsername(TextBoxVerifyUsername.Text))
                LabelVerifyUsername.Text = "用户名可用";
            else
                LabelVerifyUsername.Text = "用户名已经存在";
        }

        protected void ButtonVeryfyEmail_Click(object sender, EventArgs e)
        {
            if (UserService.VerifyEmail(TextBoxVerifyEmail.Text))
                LabelVerifyEmail.Text = "邮箱地址可用";
            else
                LabelVerifyEmail.Text = "邮箱地址已经存在";
        }
    }
}