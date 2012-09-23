using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vneed.BLL;
using Vneed.Model;

namespace Vneed.UI.Web.Page.Business
{
    public partial class cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //设置目前流程步骤
            this.OrderProcessWebUserControl1.StepNum = 1;
            //获取显示购物车数据
            Table cartTable = this.cartTable;
            TableRow cartTableHead = new TableRow();
            cartTableHead.CssClass = "cartTitleTR";
            TableCell cartTableHeadCell = new TableCell();
            cartTableHeadCell.Text = "商品";
            cartTableHeadCell.CssClass = "carTitleProductTH";
            cartTableHead.Controls.Add(cartTableHeadCell);

            cartTableHeadCell = new TableCell();
            cartTableHeadCell.Text = "数量";
            cartTableHeadCell.CssClass = "carTitleOtherTH";
            cartTableHead.Controls.Add(cartTableHeadCell);

            cartTableHeadCell = new TableCell();
            cartTableHeadCell.Text = "Vneed价";
            cartTableHeadCell.CssClass = "carTitleOtherTH";
            cartTableHead.Controls.Add(cartTableHeadCell);

            cartTableHeadCell = new TableCell();
            cartTableHeadCell.Text = "操作";
            cartTableHeadCell.CssClass = "carTitleOtherTH";
            cartTableHead.Controls.Add(cartTableHeadCell);

            cartTable.Controls.Add(cartTableHead);

            List<CartRecord> currentCart = CartService.GetCartRecodByUserID(AuthenticationService.GetUser().UserID);
            decimal totalPrice = 0;
            foreach(CartRecord carRecord in currentCart)
            {
                TableRow cartTableRow = new TableRow();
                cartTableRow.CssClass = "cartContentTR";
                TableCell cartTableCell = new TableCell();
                cartTableCell.CssClass = "cartContentTD";
                Panel cartProductDiv = new Panel();
                cartProductDiv.CssClass = "cartProductDiv";
                Panel cartProductImage = new Panel();
                cartProductImage.CssClass = "cartProductImage";
                Image img = new Image();
                img.ImageUrl = ItemService.GetItemByItemID(carRecord.ItemID).ImageUrl;
                cartProductImage.Controls.Add(img);
                cartProductDiv.Controls.Add(cartProductImage);
                Panel cartProductTitle = new Panel();
                Label title = new Label();
                title.Text = ItemService.GetItemByItemID(carRecord.ItemID).Title;
                cartProductTitle.Controls.Add(title);
                cartProductDiv.Controls.Add(cartProductTitle);

                cartTableCell.Controls.Add(cartProductDiv);
                cartTableRow.Controls.Add(cartTableCell);

                cartTableCell = new TableCell();
                cartTableCell.CssClass = "cartContentTD";
                cartTableCell.Text = carRecord.Count.ToString();
                cartTableRow.Controls.Add(cartTableCell);

                cartTableCell = new TableCell();
                cartTableCell.CssClass = "cartContentTD";
                cartTableCell.Text = "￥" + ItemService.GetItemByItemID(carRecord.ItemID).Price.ToString();
                totalPrice += ItemService.GetItemByItemID(carRecord.ItemID).Price * carRecord.Count;
                cartTableRow.Controls.Add(cartTableCell);

                cartTableCell = new TableCell();
                cartTableCell.CssClass = "cartContentTD";
                cartTableRow.Controls.Add(cartTableCell);

                cartTable.Controls.Add(cartTableRow);
            }
            this.cartClearingPriceLabel.Text = totalPrice.ToString();
        }

        protected void PayCartButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Page/Business/orderDetail.aspx");
        }
    }
}