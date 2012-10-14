using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vneed.Model;
using Vneed.BLL;

namespace Vneed.UI.Web.Admin
{
    public partial class OrderManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonQuery_Click(object sender, EventArgs e)
        {
            Table.Rows.Clear();
            List<Order> allOrders = OrderService.FindOrdersByStatusAndDate(Int32.Parse(DropDownListStatus.SelectedValue), Int32.Parse(DropDownListDate.SelectedValue));
            foreach (Order order in allOrders)
            {
                TableRow tr = new TableRow();
                TableCell tc = new TableCell();
                tc.Text = order.OrderSerialNumber.ToString();
                tr.Cells.Add(tc);
                tc = new TableCell();
                tc.Text = order.OrderID;
                tr.Cells.Add(tc);
                tc = new TableCell();
                tc.Text = order.UserID.ToString();
                tr.Cells.Add(tc);
                tc = new TableCell();
                tc.Text = order.ModiefiedDate.ToString();
                tr.Cells.Add(tc);
                tc = new TableCell();
                HyperLink hl = new HyperLink();
                hl.Text = "操作";
                hl.NavigateUrl = "/Admin/OrderDetail.aspx?orderID=" + order.OrderID;
                tc.Controls.Add(hl);
                tr.Cells.Add(tc);
                Table.Rows.Add(tr);
            }
        }
    }
}