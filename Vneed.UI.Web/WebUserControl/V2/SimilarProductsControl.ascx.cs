using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vneed.Model;

namespace Vneed.UI.Web.WebUserControl.V2
{
    public partial class SimilarProductsControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Test
            Item testItem = new Item();
            testItem.Title = "测试商品正宗好凉茶，正宗好声音，加多宝凉茶";
            testItem.ImageUrl = "~/Image/ItemImage/default.jpg";
            List<Item> testItems = new List<Item>();
            testItems.Add(testItem);
            testItems.Add(testItem);
            testItems.Add(testItem);

            //renderSimilarProducts
            renderSimilarProducts(testItems);
        }

        private Panel renderSimilarProduct(Item item) 
        {
            Panel similarProductsItemContainer = new Panel();
            similarProductsItemContainer.CssClass = "SimilarProductsItemContainer";
            Table table = new Table();
            TableRow tableRow = new TableRow();
            
            TableCell tableCell = new TableCell();
            Panel itemImageBg = new Panel();
            itemImageBg.CssClass = "itemImageBg";
            Image image = new Image();
            image.ImageUrl = item.ImageUrl;

            itemImageBg.Controls.Add(image);
            tableCell.Controls.Add(itemImageBg);
            tableRow.Controls.Add(tableCell);

            tableCell = new TableCell();
            Panel itemImageTitle = new Panel();
            itemImageTitle.CssClass = "itemImageTitle";
            Label label = new Label();
            label.Text = item.Title;
            itemImageTitle.Controls.Add(label);
            tableCell.Controls.Add(itemImageTitle);
            tableRow.Controls.Add(tableCell);

            table.Controls.Add(tableRow);
            similarProductsItemContainer.Controls.Add(table);

            return similarProductsItemContainer;
        }

        private void renderSimilarProducts(List<Item> items)
        {
            Panel productDetailSimilarProductsTitle = new Panel();
            productDetailSimilarProductsTitle.CssClass = "productDetailSimilarProductsTitle";
            Label label = new Label();
            label.Text = "同类型受欢迎商品";
            productDetailSimilarProductsTitle.Controls.Add(label);
            this.productDetailSimilarProductsPanel.Controls.Add(productDetailSimilarProductsTitle);
            
            foreach (Item item in items) 
            {
                this.productDetailSimilarProductsPanel.Controls.Add(renderSimilarProduct(item));       
            }
        }
    }
}