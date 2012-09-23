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
    public partial class product : System.Web.UI.Page
    {
        private String productID;
        private Item productItem;
        private List<CartRecord> cartList;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.productID = this.Request.QueryString["product"];
            this.productItem = ItemService.GetItemByItemID(productID);
            this.productTitleLabel.Text = productItem.Title;
            this.productVneedPriceLabel.Text = "￥" + productItem.Price;
            this.productPriceLabel.Text = "￥" + productItem.OriginalPrice;
            this.productDescriptionLabel.Text = productItem.Description;
            this.productTitleImage.ImageUrl = productItem.ImageUrl;

            //this.CartDialogInit();
            //this.CollectDialogInit();
        }
        private void CollectDialogInit() 
        {
            this.collectDialogTitleLabel.Text = productItem.Title;
        }

        private void CartDialogInit() 
        {
            this.cartDialogTitleLabel.Text = productItem.Title;
            this.cartList = CartService.GetCartRecodByUserID(AuthenticationService.GetUser().UserID);

            Panel cartDialogImgContainer = this.CartDialogImgContainerPanel;
            Panel cartDialogProductBottomButtons = this.CartDialogProductBottomButtons;
            
            int CART_DIALOG_IMG_DIV_WIDTH = 155;
            int CART_DIALOG_BOTTOM_BUTTON_WIDTH = 18;

            cartDialogProductBottomButtons.Attributes.CssStyle["width"] = this.cartList.Count * CART_DIALOG_BOTTOM_BUTTON_WIDTH + "px";

            for (int index = 0; index < this.cartList.Count; ++index)
            {
                Panel cartDialogProductImgDiv = new Panel();
                cartDialogProductImgDiv.CssClass = "cartDialogProductImgDiv";
                cartDialogProductImgDiv.Attributes.CssStyle["left"] = (index * CART_DIALOG_IMG_DIV_WIDTH).ToString() + "px";
                Image cartDialogProductImg = new Image();
                cartDialogProductImg.CssClass = "cartDialogProductImg";
                cartDialogProductImg.ImageUrl = ItemService.GetItemByItemID(cartList[index].ItemID).ImageUrl;
                Label cartDialogProductPrice = new Label();
                cartDialogProductPrice.CssClass = "cartDialogProductPrice";
                cartDialogProductPrice.Text = "￥" + ItemService.GetItemByItemID(cartList[index].ItemID).Price;
                Label cartDialogProductTitle = new Label();
                cartDialogProductTitle.CssClass = "cartDialogProductTitle";
                cartDialogProductTitle.Text = ItemService.GetItemByItemID(cartList[index].ItemID).Title;
                ImageButton cartDialogProductDelete = new ImageButton();
                cartDialogProductDelete.CssClass = "cartDialogProductDelete";
                cartDialogProductDelete.ImageUrl = "~/Resource/Image/pop_up/cart/pop_up_cart_delete.png";
                cartDialogProductImgDiv.Controls.Add(cartDialogProductImg);
                cartDialogProductImgDiv.Controls.Add(cartDialogProductTitle);
                cartDialogProductImgDiv.Controls.Add(cartDialogProductPrice);
                cartDialogProductImgDiv.Controls.Add(cartDialogProductDelete);

                cartDialogImgContainer.Controls.Add(cartDialogProductImgDiv);

                Panel cartDialogProductButton = new Panel();
                cartDialogProductButton.CssClass = "showAreaBottomButtonUnChoose";
                cartDialogProductBottomButtons.Controls.Add(cartDialogProductButton);
            }
        }

        protected void AddCartButton_Click(object sender, EventArgs e)
        {
            if (AuthenticationService.GetUsername() == null)
            {
                Response.Redirect("/Page/index.aspx");
            }
            else
            {
                CartRecord cartRecord = new CartRecord();
                cartRecord.UserID = AuthenticationService.GetUser().UserID;
                cartRecord.ItemID = productItem.ItemID;
                cartRecord.Count = int.Parse(this.ProductNumTextBox.Text);
                CartService.AddCartRecord(cartRecord);
                Response.Redirect("/Page/Business/cart.aspx");
            }
        }

        protected void BuyButton_Click(object sender, EventArgs e)
        {

        }
    }
}