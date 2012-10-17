using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vneed.BLL;

namespace Vneed.UI.Web.Admin
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*
            string username = AuthenticationService.GetUsername();
            if ((username == null) || (AuthenticationService.IsAdmin(username) == false))
            {
                Response.Redirect("/Page/V2/index.aspx");
            }
             */
        }
    }
}