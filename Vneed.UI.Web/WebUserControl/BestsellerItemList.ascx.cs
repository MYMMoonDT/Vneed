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
    public partial class BestsellerItemList : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Item> itemList = ItemService.GetBestsellers();
            TableRow trProduct = new TableRow();

            foreach (Item item in itemList)
            {
                TableCell tc = new TableCell();

                Panel productItem = new Panel();
                productItem.CssClass = "productItem1";
                Panel productPicItem = new Panel();
                productPicItem.CssClass = "productPicItem1";
                Image img = new Image();
                img.ImageUrl = item.ImageUrl;
                img.CssClass = "productPicItem2Image"; //TODO: 这里是不是要改
                productPicItem.Controls.Add(img);
                productItem.Controls.Add(productPicItem);
                Panel productDisItem = new Panel();
                productDisItem.CssClass = "productDisItem1";
                HyperLink title = new HyperLink();
                title.CssClass = "";
                title.Text = item.Title;
                title.NavigateUrl = "/Page/Business/product.aspx?product=" + item.ItemID;
                productDisItem.Controls.Add(title);
                productItem.Controls.Add(productDisItem);
                Panel productDivider = new Panel();
                productDivider.CssClass = "productItemDivider1";
                productItem.Controls.Add(productDivider);
                tc.Controls.Add(productItem);
                trProduct.Controls.Add(tc);
                Table.Rows.Add(trProduct);
                trProduct = new TableRow();
            }
        }
    }
}