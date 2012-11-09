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

        //private int DESCRIPTION_MAX_LENGTH = 100;

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
            {
                Panel searchResultEmptyContainer = new Panel();
                searchResultEmptyContainer.CssClass = "searchResultEmptyContainer";
                Image img = new Image();
                img.ImageUrl = "/Resource/Image/icon/search_empty_notic.png";
                Panel searchResultEmptyContent = new Panel();
                searchResultEmptyContent.CssClass = "searchResultEmptyContent";
                Label label = new Label();
                label.Text = "对不起，找不到您所输入的课程，可能因为：<br/>您的课程已经开课or您输入有误。<br/>请将您所需要的课程号与您的联系方式发送至kf@vneed.org。<br/>我们的工作人员会在12小时内与您联系。<br/>感谢您的支持。";
                searchResultEmptyContent.Controls.Add(label);
                searchResultEmptyContainer.Controls.Add(img);
                searchResultEmptyContainer.Controls.Add(searchResultEmptyContent);
                searchResultControlContainerPanel.Controls.Add(searchResultEmptyContainer);
                return;
            }

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
            //if (item.Description.Length >= DESCRIPTION_MAX_LENGTH)
            //{
            //    descriptionLabel.Text = item.Description.Substring(0, DESCRIPTION_MAX_LENGTH) + "...";
            //}
            //else
            //{
            //    descriptionLabel.Text = item.Description;
            //}
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