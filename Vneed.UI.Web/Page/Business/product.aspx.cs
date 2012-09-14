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

        protected void Page_Load(object sender, EventArgs e)
        {
            this.productID = this.Request.QueryString["product"];
            this.productItem = ItemService.GetItemByItemID(productID);
            this.productTitleLabel.Text = productItem.Title;
            this.productVneedPriceLabel.Text = "￥" + productItem.Price;
            this.productPriceLabel.Text = "￥" + productItem.OriginalPrice;
            this.productDescriptionLabel.Text = productItem.Description;
            this.productTitleImage.ImageUrl = productItem.ImageUrl;
            this.CartDialogInit();
        }
        private void CartDialogInit() {
            int TestNum = 5;

            Panel cartDialogImgContainer = this.CartDialogImgContainerPanel;
            Panel cartDialogProductBottomButtons = this.CartDialogProductBottomButtons;
            
            int CART_DIALOG_IMG_DIV_WIDTH = 155;
            int CART_DIALOG_BOTTOM_BUTTON_WIDTH = 18;

            cartDialogProductBottomButtons.Attributes.CssStyle["width"] = TestNum * CART_DIALOG_BOTTOM_BUTTON_WIDTH + "px";

            for (int index = 0; index < TestNum; ++index)
            {
                Panel cartDialogProductImgDiv = new Panel();
                cartDialogProductImgDiv.CssClass = "cartDialogProductImgDiv";
                cartDialogProductImgDiv.Attributes.CssStyle["left"] = (index * CART_DIALOG_IMG_DIV_WIDTH).ToString() + "px";
                Image cartDialogProductImg = new Image();
                cartDialogProductImg.CssClass = "cartDialogProductImg";
                cartDialogProductImg.ImageUrl = "~/Image/ItemImage/default.jpg";
                Label cartDialogProductPrice = new Label();
                cartDialogProductPrice.CssClass = "cartDialogProductPrice";
                cartDialogProductPrice.Text = "$" + index;
                ImageButton cartDialogProductDelete = new ImageButton();
                cartDialogProductDelete.CssClass = "cartDialogProductDelete";
                cartDialogProductDelete.ImageUrl = "~/Resource/Image/pop_up/cart/pop_up_cart_delete.png";
                cartDialogProductImgDiv.Controls.Add(cartDialogProductImg);
                cartDialogProductImgDiv.Controls.Add(cartDialogProductPrice);
                cartDialogProductImgDiv.Controls.Add(cartDialogProductDelete);

                cartDialogImgContainer.Controls.Add(cartDialogProductImgDiv);

                Panel cartDialogProductButton = new Panel();
                cartDialogProductButton.CssClass = "showAreaBottomButtonUnChoose";
                cartDialogProductBottomButtons.Controls.Add(cartDialogProductButton);
            }
        }
    }
}