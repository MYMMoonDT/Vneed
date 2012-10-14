using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vneed.UI.Web.WebUserControl.V2
{
    public partial class SearchBarControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SearchBarButton_Click(object sender, EventArgs e)
        {
            String url = "/Page/V2/Business/searchResult.aspx?keyword=" + this.SearchBarTextBox.Text;
            Response.Redirect(url);
        }
    }
}