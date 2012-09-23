using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vneed.Model;
using Vneed.BLL;

namespace Vneed.UI.Web.Test
{
    public partial class OrderTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Order newOrder = new Order();
            newOrder.UserID = 8;
            newOrder.Payment = 0;
            newOrder.School = "同济";
            newOrder.Name = "乙振斐";
            newOrder.Email = "dd@dd.com";
            newOrder.Contact = "13671722212";
            newOrder.IdentityNo = "111111";
            OrderService.SubmitOrder(newOrder);
        }
    }
}