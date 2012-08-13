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
    public partial class RecommendedItemList : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Item> itemList = ItemService.GetRecommendedItems();
            int count = 0;
            //TableRow trImage = new TableRow();
            //TableRow trName = new TableRow();
            //TableRow trDesc = new TableRow();

            TableRow trProduct = new TableRow();

            foreach (Item item in itemList)
            {
                ////图片
                //TableCell tc = new TableCell();
                //Image img = new Image();
                //img.ImageUrl = item.ImageUrl;
                //tc.Controls.Add(img);
                //trImage.Controls.Add(tc);
                ////名字
                //tc = new TableCell();
                //tc.Text = item.Title;
                //trName.Controls.Add(tc);
                ////描述
                //tc = new TableCell();
                //tc.Text = "";
                //trDesc.Controls.Add(tc);

                TableCell tc = new TableCell();
                
                
                Panel productItem = new Panel();
                productItem.CssClass = "productItem2";
                Panel productPicItem = new Panel();
                productPicItem.CssClass = "productPicItem2";
                Image img = new Image();
                img.ImageUrl = item.ImageUrl;
                img.CssClass = "productPicItem2Image";
                productPicItem.Controls.Add(img);
                productItem.Controls.Add(productPicItem);
                Panel productDisItem = new Panel();
                productDisItem.CssClass = "productDisItem2";
                Panel productDisTitleItem = new Panel();
                productDisTitleItem.CssClass = "productDisTitleItem2";
                Panel productDisTypeItem = new Panel();
                productDisTypeItem.CssClass = "productDisTypeItem2";
                Label title = new Label();
                title.Text = item.Title;
                Label type = new Label();
                type.Text = "";
                productDisTitleItem.Controls.Add(title);
                productDisTypeItem.Controls.Add(type);
                productDisItem.Controls.Add(productDisTitleItem);
                productDisItem.Controls.Add(productDisTypeItem);
                productItem.Controls.Add(productDisItem);
                tc.Controls.Add(productItem);
                trProduct.Controls.Add(tc);
                count++;
                if (count % 4 == 0)
                {
                    //Table.Rows.Add(trImage);
                    //Table.Rows.Add(trName);
                    //Table.Rows.Add(trDesc);
                    //trImage = new TableRow();
                    //trName = new TableRow();
                    //trDesc = new TableRow();
                    Table.Rows.Add(trProduct);
                    trProduct = new TableRow();
                }
            }
            if (count % 4 != 0)
            {
                //Table.Rows.Add(trImage);
                //Table.Rows.Add(trName);
                //Table.Rows.Add(trDesc);
                Table.Rows.Add(trProduct);
            }
        }
    }
}