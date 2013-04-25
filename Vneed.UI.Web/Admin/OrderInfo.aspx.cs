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
    public partial class OrderInfo : System.Web.UI.Page
    {
        void LoadOrder(string orderID)
        {
            Order order = OrderService.FindOrderByOrderID(orderID);
            TableRow tr = new TableRow();
            TableCell tc = new TableCell();
            tc.Text = "订单号 " + order.OrderID;
            tr.Cells.Add(tc);
            tc = new TableCell();
            tc.Text = "用户ID " + order.UserID.ToString();
            tr.Cells.Add(tc);
            tc = new TableCell();
            tc.Text = "订单日期 " + order.ModiefiedDate.ToString();
            tr.Cells.Add(tc);
            Table.Rows.Add(tr);
            tr = new TableRow();
            tc = new TableCell();
            tc = new TableCell();
            tc.Text = "姓名 " + order.Name;
            tr.Cells.Add(tc);
            tc = new TableCell();
            tc.Text = "学校 " + order.School;
            tr.Cells.Add(tc);
            tc = new TableCell();
            tc.Text = "联系方式 " + order.Contact;
            tr.Cells.Add(tc);
            Table.Rows.Add(tr);
            tr = new TableRow();
            tc = new TableCell();
            tc.Text = "email " + order.Email;
            tr.Cells.Add(tc);
            tc = new TableCell();
            tc.Text = "身份证号 " + order.IdentityNo;
            tr.Cells.Add(tc);
            tc = new TableCell();
            tc.Text = "是否已经报名 " + order.AlreadySignedIn.ToString();
            tr.Cells.Add(tc);
            Table.Rows.Add(tr);
            tr = new TableRow();
            tc = new TableCell();
            tc.Text = "额外信息" + order.ExtraInfo;
            tr.Cells.Add(tc);
            Table.Rows.Add(tr);

            List<OrderDetail> details = OrderService.FindOrderDetailsByOrderID(orderID);
            foreach (OrderDetail detail in details)
            {
                tr = new TableRow();
                tc = new TableCell();
                tc.Text = "物品ID " + detail.ItemID;
                tr.Cells.Add(tc);
                tc = new TableCell();
                tc.Text = "物品名称 " + detail.Title;
                tr.Cells.Add(tc);
                tc = new TableCell();
                tc.Text = "单价 " + detail.Price;
                tr.Cells.Add(tc);
                tc = new TableCell();
                tc.Text = "个数 " + detail.Quantity;
                tr.Cells.Add(tc);
                tc = new TableCell();
                tc.Text = "总价 " + detail.TotalPrice;
                tr.Cells.Add(tc);
                Table.Rows.Add(tr);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string orderID = Request.QueryString["orderID"];
            LoadOrder(orderID);
        }

        protected void ButtonFinish_Click(object sender, EventArgs e)
        {
            OrderService.FinishOrder(Request.QueryString["orderID"]);
            Response.Redirect("/Admin/OrderManagement.aspx");
        }
    }
}