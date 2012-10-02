using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vneed.BLL;

namespace Vneed.UI.Web.WebUserControl
{
    public partial class NavBarWebUserControl1 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (AuthenticationService.GetUsername() == null)
            {
                this.headMyVneedDiv1.Visible = false;
                this.headMyVneedDiv2.Visible = true;
            }
            else 
            {
                this.headMyVneedDiv1.Visible = true;
                this.headMyVneedDiv2.Visible = false;
                this.ProductNumImage.ImageUrl = "~/Resource/Image/header/header_cartlogo_" + 
                    CartService.GetCartRecodByUserID(AuthenticationService.GetUser().UserID).Count.ToString() + ".png";
            }
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            
        }
        protected void CustomValidatorLogin_ServerValidate(object source, ServerValidateEventArgs args) 
        {
            args.IsValid = UserService.VerifyPassword(this.loginName.Text, this.loginPassword.Text);
            if (args.IsValid == false)
            {
                this.loginName.Text = "请输入您的用户名";
                this.loginPassword.Text = "请输入您的密码";
            }
            else
            {
                AuthenticationService.Login(this.loginName.Text);            
            }
        }

        protected void loginButton_Click(object sender, EventArgs e)
        {
            if (AuthenticationService.GetUsername() != null)
                Response.Redirect(Request.Url.ToString());
        }

        protected void MyVneedLogoutButton_Click(object sender, EventArgs e)
        {
            if (AuthenticationService.GetUsername() != null)
            {
                AuthenticationService.Logout();
                Response.Redirect("/Page/index.aspx");
            }
        }

        protected void searchButton_Click1(object sender, EventArgs e)
        {
            String url = "/Page/Business/search.aspx?search=" + this.searchContent.Text;
            Response.Redirect(url);
        }
    }
}