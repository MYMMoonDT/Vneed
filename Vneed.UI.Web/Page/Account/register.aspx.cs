using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vneed.BLL;
using Vneed.Model;

namespace Vneed.UI.Web.Page.Account
{
    public partial class register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RegisterNameCustomValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = UserService.VerifyUsername((string)args.Value);
            if (!args.IsValid)
                ResetPassword();
        }

        protected void RegisterEmailCustomValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = UserService.VerifyEmail((string)args.Value);
            if (!args.IsValid)
                ResetPassword();
        }

        private void ResetPassword() 
        {
            this.RegisterPasswordTextBox.Text = "设置密码";
            this.RegisterPasswordAgainTextBox.Text = "重复一遍密码";
        }

        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            Vneed.Model.User newUser = new Vneed.Model.User();
            newUser.Username = this.RegisterNameTextBox.Text;
            newUser.Password = this.RegisterPasswordTextBox.Text;
            newUser.Email = this.RegisterEmailTextBox.Text;
            newUser.RoleID = 1;
            UserService.RegisterNewUser(newUser);
            AuthenticationService.Login(this.RegisterNameTextBox.Text);
            Response.Redirect("/Page/Account/registerSuccess.aspx");
        }
    }
}