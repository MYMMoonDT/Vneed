using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using Vneed.BLL;
using Vneed.Model;

namespace Vneed.UI.Web.Page.V2.Business
{
    public partial class productDetail : System.Web.UI.Page
    {
        private String productID;
        private Item productItem;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.productID = this.Request.QueryString["product"];
            if (this.productID == null) 
            {
                Response.Redirect("~/Page/V2/index.aspx");   
            }
            this.productItem = ItemService.GetItemByItemID(productID);
            Init_ProductDetailPage();
        }

        private void Init_ProductDetailPage() 
        {
            this.productDetailImage.ImageUrl = this.productItem.ImageUrl;
            this.productDetailTitleLabel.Text = this.productItem.Title;
            this.ProductVneedPriceLabel.Text = "￥" + this.productItem.Price;
            this.ProductOfficialPriceLabel.Text = "￥" + this.productItem.OriginalPrice;
            this.productDetailDescriptionLabel.Text = this.productItem.Description;
        }

        //protected void ProductDetailAddCartButton_Click(object sender, EventArgs e)
        //{
        //    if (AuthenticationService.GetUsername() == null)
        //    {
        //        Response.Redirect("/Page/V2/index.aspx");
        //    }
        //    else
        //    {
        //        CartRecord cartRecord = new CartRecord();
        //        cartRecord.UserID = AuthenticationService.GetUser().UserID;
        //        cartRecord.ItemID = this.productItem.ItemID;
        //        cartRecord.Count = int.Parse(this.productDetailProductNumTextBox.Text);
        //        CartService.AddCartRecord(cartRecord);
        //        Response.Redirect("/Page/V2/Business/cartDetail.aspx");
        //    }
        //}
        [WebMethod]
        public static bool ProductDetailAddCartButton_Click(string productID, string productNum)
        {
            if (AuthenticationService.GetUsername() != null)
            {
                CartRecord cartRecord = new CartRecord();
                cartRecord.UserID = AuthenticationService.GetUser().UserID;
                cartRecord.ItemID = productID;
                cartRecord.Count = int.Parse(productNum);
                CartService.AddCartRecord(cartRecord);
                //Response.Redirect("/Page/V2/Business/cartDetail.aspx");
                return true;
            }
            else
            {
                return false;
            }
        }

        [WebMethod]
        public static bool ProductDetailBuyNowButton_Click(string productID, string productNum)
        {
            if (AuthenticationService.GetUsername() != null)
            {
                CartRecord cartRecord = new CartRecord();
                cartRecord.UserID = AuthenticationService.GetUser().UserID;
                cartRecord.ItemID = productID;
                cartRecord.Count = int.Parse(productNum);
                CartService.DeletaCartRecordByUserID(AuthenticationService.GetUser().UserID);
                CartService.AddCartRecord(cartRecord);
                //Response.Redirect("/Page/V2/Business/orderDetail.aspx");
                return true;
            }
            else 
            {
                return false;
            }
        }

        //protected void ProductDetailBuyNowButton_Click(object sender, EventArgs e)
        //{
        //    if (AuthenticationService.GetUsername() == null)
        //    {
        //        Response.Redirect("/Page/V2/index.aspx");
        //    }
        //    else
        //    {
        //        CartRecord cartRecord = new CartRecord();
        //        cartRecord.UserID = AuthenticationService.GetUser().UserID;
        //        cartRecord.ItemID = this.productItem.ItemID;
        //        cartRecord.Count = int.Parse(this.productDetailProductNumTextBox.Text);
        //        CartService.DeletaCartRecordByUserID(AuthenticationService.GetUser().UserID);
        //        CartService.AddCartRecord(cartRecord);
        //        Response.Redirect("/Page/V2/Business/orderDetail.aspx");
        //    }
        //}
    }
}