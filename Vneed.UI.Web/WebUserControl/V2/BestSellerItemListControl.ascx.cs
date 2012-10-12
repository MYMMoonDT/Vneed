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
    public partial class BestSellerItemListControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            renderBestSellerItems();
        }

        private void renderBestSellerItems()
        {
            List<Item> itemList = ItemService.GetBestsellers();
            foreach (Item item in itemList)
            {
                this.bestSellerItemListPanel.Controls.Add(renderBestSellerItem(item));
            }
        }

        private Panel renderBestSellerItem(Item item)
        {
            Panel bestSellerItemContainer = new Panel();
            bestSellerItemContainer.CssClass = "bestSellerItemContainer";

            Panel bestSellerItemImageContainer = new Panel();
            bestSellerItemImageContainer.CssClass = "bestSellerItemImageContainer";
            HyperLink imgLink = new HyperLink();
            Image img = new Image();
            imgLink.NavigateUrl = "/Page/V2/Business/productDetail.aspx?product=" + item.ItemID;
            img.ImageUrl = item.ImageUrl;
            img.ToolTip = item.Title;
            imgLink.Controls.Add(img);
            bestSellerItemImageContainer.Controls.Add(imgLink);

            Panel bestSellerItemTextContainer = new Panel();
            bestSellerItemTextContainer.CssClass = "bestSellerItemTextContainer";
            HyperLink titleLink = new HyperLink();
            Label title = new Label();
            titleLink.NavigateUrl = "/Page/V2/Business/productDetail.aspx?product=" + item.ItemID;
            title.Text = item.Title;
            titleLink.Controls.Add(title);
            bestSellerItemTextContainer.Controls.Add(titleLink);

            bestSellerItemContainer.Controls.Add(bestSellerItemImageContainer);
            bestSellerItemContainer.Controls.Add(bestSellerItemTextContainer);
            return bestSellerItemContainer;
        }
    }
}