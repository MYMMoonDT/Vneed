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
    public partial class RecommendedItemListControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            renderRecommendedItems();
        }

        private void renderRecommendedItems()
        {
            List<Item> itemList = ItemService.GetRecommendedItems();
            int count = 0;
            TableRow tr = new TableRow();
            foreach (Item item in itemList)
            {
                TableCell tc = new TableCell();
                tc.Controls.Add(renderRecommendedItem(item));
                tr.Controls.Add(tc);
                count++;
                if (count % 4 == 0) 
                {
                    this.recommendedItemTable.Controls.Add(tr);
                    tr = new TableRow();
                }
            }
            if (count % 4 != 0)
            {
                this.recommendedItemTable.Controls.Add(tr);
            }
        }

        private Panel renderRecommendedItem(Item item)
        {
            Panel recommendedItemContainer = new Panel();
            recommendedItemContainer.CssClass = "recommendedItemContainer";

            Panel recommendedItemImgContainer = new Panel();
            recommendedItemImgContainer.CssClass = "recommendedItemImgContainer";
            HyperLink imgLink = new HyperLink();
            Image img = new Image();
            imgLink.NavigateUrl = "/Page/V2/Business/productDetail.aspx?product=" + item.ItemID;
            img.ImageUrl = item.ImageUrl;
            img.ToolTip = item.Title;
            imgLink.Controls.Add(img);
            recommendedItemImgContainer.Controls.Add(imgLink);

            Panel recommendedItemTextContainer = new Panel();
            recommendedItemTextContainer.CssClass = "recommendedItemTextContainer";
            Panel recommendedItemTitleContainer = new Panel();
            recommendedItemTitleContainer.CssClass = "recommendedItemTitleContainer";
            HyperLink title = new HyperLink();
            title.Text = item.Title;
            title.NavigateUrl = "/Page/V2/Business/productDetail.aspx?product=" + item.ItemID;
            recommendedItemTitleContainer.Controls.Add(title);
            recommendedItemTextContainer.Controls.Add(recommendedItemTitleContainer);

            recommendedItemContainer.Controls.Add(recommendedItemImgContainer);
            recommendedItemContainer.Controls.Add(recommendedItemTextContainer);
            return recommendedItemContainer;
        }
    }
}