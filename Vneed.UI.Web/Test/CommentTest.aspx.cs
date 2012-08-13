using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vneed.BLL;

namespace Vneed.UI.Web.Test
{
    public partial class CommentTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AuthenticationService.Login("yizhenfei2012");
            CommentBox1.ItemID = "55ddd15c-f6b7-4b2f-aa1d-ac9382510e8a";
        }
    }
}