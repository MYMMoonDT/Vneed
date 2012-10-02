using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vneed.BLL;
using Vneed.Model;

namespace Vneed.UI.Web.WebUserControl
{
    public partial class OrderList : System.Web.UI.UserControl
    {
        void LoadOrders()
        {
            User currentUser = AuthenticationService.GetUser();
            List<Order> orders = OrderService.FindOrdersByUserID(currentUser.UserID);
            foreach (Order currentOrder in orders)
            {
                TableRow tr = new TableRow();
                TableCell tc = new TableCell();
                Panel orderPanel = new Panel();
                orderPanel.CssClass = "myOrderContentItemDiv";
                Panel picPanel = new Panel();
                picPanel.CssClass = "myOrderContentItemImageDiv";
                Image img = new Image();
                img.ImageUrl = "~/Image/ItemImage/default.jpg";
                img.CssClass = "myOrderContentItemImage";
                picPanel.Controls.Add(img);
                orderPanel.Controls.Add(picPanel);
                Panel detailPanel = new Panel();
                detailPanel.CssClass = "myOrderContentItemDetailDiv";
                Label detailLabel = new Label();
                Decimal orderPrice = OrderService.GetOrderPrice(currentOrder.OrderID);
                detailLabel.Text = "订单号：" + currentOrder.OrderSerialNumber.ToString() + "</br>下单日期：" + currentOrder.ModiefiedDate.ToShortDateString() + "</br>付款方式：线下支付</br>金额：" + orderPrice.ToString();
                detailLabel.CssClass = "myOrderContentItemDetailFont1";
                detailPanel.Controls.Add(detailLabel);
                orderPanel.Controls.Add(detailPanel);
                Panel statusPanel = new Panel();
                statusPanel.CssClass = "myOrderContentItemButtonDiv";
                Button statusButton = new Button();
                statusButton.CssClass = "myOrderContentItemButton button";
                statusButton.Text = "已付款";
                statusPanel.Controls.Add(statusButton);
                orderPanel.Controls.Add(statusPanel);
                tc.Controls.Add(orderPanel);
                tr.Cells.Add(tc);
                Table.Rows.Add(tr);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadOrders();
            }
        }
    }
}