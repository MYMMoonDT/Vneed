using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vneed.BLL;
using Vneed.Model;

namespace Vneed.UI.Web.WebUserControl.V2
{
    public partial class MyVneedMyOrderListControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                renderMyOrderItemList();
            }
        }

        private Panel renderMyOrderItem(Order order) 
        {
            Panel myOrderItemContainer = new Panel();
            myOrderItemContainer.CssClass = "myOrderItemContainer";
            Panel myOrderItemImageContainer = new Panel();
            myOrderItemImageContainer.CssClass = "myOrderItemImageContainer";
            Panel myOrderItemDetailContainer = new Panel();
            myOrderItemDetailContainer.CssClass = "myOrderItemDetailContainer";
            Panel myOrderItemStatusContainer = new Panel();
            myOrderItemStatusContainer.CssClass = "myOrderItemStatusContainer";

            Image image = new Image();
            //使用默认图片
            image.ImageUrl = "~/Image/ItemImage/default.jpg";
            myOrderItemImageContainer.Controls.Add(image);

            Panel panel = new Panel();
            Label label = new Label();
            label.Text = "订单号：" + order.OrderSerialNumber.ToString();
            panel.Controls.Add(label);
            myOrderItemDetailContainer.Controls.Add(panel);

            panel = new Panel();
            label = new Label();
            label.Text = "下单日期：" + order.ModiefiedDate.ToShortDateString();
            panel.Controls.Add(label);
            myOrderItemDetailContainer.Controls.Add(panel);

            panel = new Panel();
            label = new Label();
            //使用默认付款方式
            label.Text = "付款方式：" + "线下支付";
            panel.Controls.Add(label);
            myOrderItemDetailContainer.Controls.Add(panel);

            panel = new Panel();
            label = new Label();
            Decimal orderPrice = OrderService.GetOrderPrice(order.OrderID);
            label.Text = "金额：" + orderPrice.ToString();
            panel.Controls.Add(label);
            myOrderItemDetailContainer.Controls.Add(panel);

            Button button = new Button();
            //使用默认订单状态
            button.Text = "已付款";
            button.CssClass = "myOrderItemStatusButton";
            button.Enabled = false;
            myOrderItemStatusContainer.Controls.Add(button);

            myOrderItemContainer.Controls.Add(myOrderItemImageContainer);
            myOrderItemContainer.Controls.Add(myOrderItemDetailContainer);
            myOrderItemContainer.Controls.Add(myOrderItemStatusContainer);
            return myOrderItemContainer;
        }

        private void renderMyOrderItemList() 
        {
            User currentUser = AuthenticationService.GetUser();
            List<Order> orders = OrderService.FindOrdersByUserID(currentUser.UserID);
            foreach (Order order in orders)
            {
                this.MyVneedMyOrderListContainerPanel.Controls.Add(renderMyOrderItem(order));
            }
        }
    }
}