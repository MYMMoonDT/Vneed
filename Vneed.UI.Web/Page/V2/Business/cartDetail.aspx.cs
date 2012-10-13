using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vneed.UI.Web.WebUserControl.V2;
using Vneed.BLL;
using Vneed.Model;

namespace Vneed.UI.Web.Page.V2.Business
{
    public partial class cartDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.OrderProcessStepControl1.StepNum = 1;
        }

        protected void PayForProductInCartButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Page/V2/Business/orderDetail.aspx");
        }
    }
}