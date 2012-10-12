using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vneed.Model;
using Vneed.BLL;


namespace Vneed.UI.Web.Page.V2.Account
{
    public partial class register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            if (this.IsValid)
            {
                Vneed.Model.User newUser = new Vneed.Model.User();
                newUser.Username = this.RegisterNameTextBox.Text;
                newUser.Password = this.RegisterPasswordTextBoxHide.Text;
                newUser.Email = this.RegisterEmailTextBox.Text;
                newUser.RoleID = 1;

                UserService.RegisterNewUser(newUser);
                AuthenticationService.Login(newUser.Username);
                Response.Redirect("/Page/V2/Help/registerSuccess.aspx");
            }
        }

        protected void RegisterNameCustomValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = UserService.VerifyUsername((string)args.Value);
        }

        protected void RegisterEmailCustomValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = UserService.VerifyEmail((string)args.Value);
        }
    }
}