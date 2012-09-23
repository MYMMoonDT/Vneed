using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vneed.BLL;

namespace Vneed.UI.Web.Template
{
    public partial class Template2 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (AuthenticationService.GetUsername() == null) 
            {
                Response.Redirect("/Page/index.aspx");
            }
            this.myVneedTitleLabel.Text = AuthenticationService.GetUsername();
        }
    }
}