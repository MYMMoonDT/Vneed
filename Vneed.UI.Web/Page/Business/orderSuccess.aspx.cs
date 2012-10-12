using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vneed.UI.Web.Page.Business
{
    public partial class orderSuccess : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.OrderProcessWebUserControl1.StepNum = 3;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("\\Page\\orderList.aspx");
        }
    }
}