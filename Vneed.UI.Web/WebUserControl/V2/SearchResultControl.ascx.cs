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
    public partial class SearchResultControl : System.Web.UI.UserControl
    {
        private String searchContent = "";

        public String SearchContent
        {
            get { return this.searchContent; }
            set { this.searchContent = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (searchContent == "") 
            {
                Response.Redirect("/Page/V2/index.aspx");
            }
            List<Item> searchResultItems = ItemService.SearchItems(searchContent);
            renderSearchResultItems(searchResultItems);
        }

        private void renderSearchResultItems(List<Item> searchResultItems)
        {
            if (searchResultItems.Count <= 0)
                return;

            Table searchResultTable = new Table();
            
            TableRow tr = new TableRow();
            TableHeaderCell th = new TableHeaderCell();
            th.Text = "商品名称";
            tr.Controls.Add(th);

            th = new TableHeaderCell();
            th.Text = "商品简介";
            tr.Controls.Add(th);

            th = new TableHeaderCell();
            th.Text = "Vneed价";
            tr.Controls.Add(th);
            searchResultTable.Controls.Add(tr);

            foreach (Item item in searchResultItems)
            {
                searchResultTable.Controls.Add(renderSearchResultItem(item));
            }

            this.searchResultControlContainerPanel.Controls.Add(searchResultTable);
        }

        private TableRow renderSearchResultItem(Item item) 
        {
            TableRow tr = new TableRow();
            
            TableCell tc = new TableCell();
            Panel searchResultTableItemProductContainer = new Panel();
            searchResultTableItemProductContainer.CssClass = "searchResultTableItemProductContainer";
            Panel searchResultTableItemImageContainer = new Panel();
            searchResultTableItemImageContainer.CssClass = "searchResultTableItemImageContainer";
            HyperLink imgLink = new HyperLink();
            Image img = new Image();
            imgLink.NavigateUrl = "/Page/V2/Business/productDetail.aspx?product=" + item.ItemID;
            img.ImageUrl = item.ImageUrl;
            imgLink.Controls.Add(img);
            searchResultTableItemImageContainer.Controls.Add(imgLink);
            Panel searchResultTableItemTitleContainer = new Panel();
            searchResultTableItemTitleContainer.CssClass = "searchResultTableItemTitleContainer";
            HyperLink titleLink = new HyperLink();
            titleLink.NavigateUrl = "/Page/V2/Business/productDetail.aspx?product=" + item.ItemID;
            titleLink.Text = item.Title;
            searchResultTableItemTitleContainer.Controls.Add(titleLink);
            searchResultTableItemProductContainer.Controls.Add(searchResultTableItemImageContainer);
            searchResultTableItemProductContainer.Controls.Add(searchResultTableItemTitleContainer);
            tc.Controls.Add(searchResultTableItemProductContainer);
            tr.Controls.Add(tc);
            
            tc = new TableCell();
            Panel searchResultTableItemDescriptionContainer = new Panel();
            searchResultTableItemDescriptionContainer.CssClass = "searchResultTableItemDescriptionContainer";
            Label descriptionLabel = new Label();
            descriptionLabel.Text = item.Description;
            searchResultTableItemDescriptionContainer.Controls.Add(descriptionLabel);
            tc.Controls.Add(searchResultTableItemDescriptionContainer);
            tr.Controls.Add(tc);

            tc = new TableCell();
            Panel searchResultTableItemPriceContainer = new Panel();
            searchResultTableItemPriceContainer.CssClass = "searchResultTableItemPriceContainer";
            Label priceLabel = new Label();
            priceLabel.Text = "￥" + item.Price;
            searchResultTableItemPriceContainer.Controls.Add(priceLabel);
            tc.Controls.Add(searchResultTableItemPriceContainer);
            tr.Controls.Add(tc);
            
            return tr;
        }

    }
}