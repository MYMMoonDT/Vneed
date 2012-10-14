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
            if (!this.IsPostBack)
            {
                this.OrderProcessStepControl1.StepNum = 1;
                //this.CartTableControl.UpdateProductNumInCart += new WebUserControl.V2.CartTableControl.UpdateProductNumInCartEventHandler(CartTableControl_UpdateProductNumInCart);
            }
            if (CartService.GetCartRecodByUserID(AuthenticationService.GetUser().UserID).Count <= 0)
            {
                this.PayForProductInCartButton.Enabled = false;
            }
        }

        //void CartTableControl_UpdateProductNumInCart()
        //{
        //    MasterPage homeTemplate = this.Master.Master.Master;
        //    TopBarControl topBarControl1 = (TopBarControl)homeTemplate.FindControl("TopBarControl1");
        //    topBarControl1.updateProductNumInCart();
        //}

        protected void PayForProductInCartButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Page/V2/Business/orderDetail.aspx");
        }
    }
}