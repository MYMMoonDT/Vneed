using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vneed.Model;
using Vneed.BLL;

namespace Vneed.UI.Web.WebUserControl.V2
{
    public partial class MyVneedUserInfoControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (AuthenticationService.GetUsername() == null)
            {
                Response.Redirect("/Page/V2/index.aspx");
            }
            this.myVneedSubTitleUserNameLabel.Text = AuthenticationService.GetUsername();
            //使用默认头像
            //this.myVneedSubTitleUserImage.ImageUrl = AuthenticationService.GetUser().AdditionalInfo.PortraitUrl;
            this.myVneedSubTitleUserImage.ImageUrl = "~/Image/Portrait/Default.jpg";
        }
    }
}