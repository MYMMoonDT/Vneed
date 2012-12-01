using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vneed.BLL;

namespace Vneed.UI.Web.WebUserControl.V2
{
    public partial class TopBarControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (AuthenticationService.GetUsername() == null)
            {
                this.logoutVneed();
            }
            else
            {
                this.loginVneed();
            }
        }
        private void loginVneed() 
        {
            this.topBarMyVneedLoginContainer.Style["display"] = "block";
            this.topBarMyVneedLogoutContainer.Style["display"] = "none";
            this.ProductInCartNumImage.ImageUrl = "~/Resource/Image/header/header_cartlogo_" +
                    CartService.GetCartRecodByUserID(AuthenticationService.GetUser().UserID).Count.ToString() + ".png";
        }

        public void updateProductNumInCart()
        {
            this.ProductInCartNumImage.ImageUrl = "~/Resource/Image/header/header_cartlogo_" +
                    CartService.GetCartRecodByUserID(AuthenticationService.GetUser().UserID).Count.ToString() + ".png";
        }

        private void logoutVneed() 
        {
            this.topBarMyVneedLoginContainer.Style["display"] = "none";
            this.topBarMyVneedLogoutContainer.Style["display"] = "block";
        }

        protected void loginVneedButton_Click(object sender, EventArgs e)
        {
            if (AuthenticationService.GetUsername() != null)
                Response.Redirect(Request.Url.ToString());
        }

        protected void CustomValidatorLogin_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //似乎这里的Login调用会失灵，所以在loginVneedButton_Click重做了一次。
            args.IsValid = UserService.VerifyPassword(this.loginNameTextBox.Text, this.loginPasswordTextBoxHide.Text);
            if (args.IsValid == false)
            {
            }
            else
            {
                AuthenticationService.Login(this.loginNameTextBox.Text);
            }
        }

        protected void LogoutVneedButton_Click(object sender, EventArgs e)
        {
            if (AuthenticationService.GetUsername() != null)
            {
                AuthenticationService.Logout();
                Response.Redirect("/Page/V2/index.aspx");
            }
        }
    }
}