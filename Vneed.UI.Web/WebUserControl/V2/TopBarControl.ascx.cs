using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vneed.UI.Web.WebUserControl.V2
{
    public partial class TopBarControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.loginVneed();
        }
        private void loginVneed() 
        {
            this.topBarMyVneedLoginContainer.Style["display"] = "block";
            this.topBarMyVneedLogoutContainer.Style["display"] = "none";
        }
        private void logoutVneed() 
        {
            this.topBarMyVneedLoginContainer.Style["display"] = "none";
            this.topBarMyVneedLogoutContainer.Style["display"] = "block";
        }
    }
}