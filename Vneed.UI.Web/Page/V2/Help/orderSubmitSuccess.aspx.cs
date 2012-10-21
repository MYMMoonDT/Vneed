using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vneed.UI.Web.Page.V2.Help
{
    public partial class orderSubmitSuccess : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.OrderProcessStepControl1.StepNum = 3; 
        }

        protected void BuyButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Page/V2/index.aspx");
        }

        protected void MyVneedButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Page/V2/MyVneed/myVneedMyOrder.aspx");
        }
    }
}