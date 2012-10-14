using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vneed.Model;
using Vneed.BLL;

namespace Vneed.UI.Web.WebUserControl.V2
{
    public partial class CatalogFilterControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int page;
            if (Request.QueryString["page"] == null)
                page = 1;
            else
                page = Int32.Parse(Request.QueryString["page"]);

            int attr1;
            if (Request.QueryString["attr1"] == null)
                attr1 = 0;
            else
                attr1 = Int32.Parse(Request.QueryString["attr1"]);

            int attr2;
            if (Request.QueryString["attr2"] == null)
                attr2 = 0;
            else
                attr2 = Int32.Parse(Request.QueryString["attr2"]);

            int attr3;
            if (Request.QueryString["attr3"] == null)
                attr3 = 0;
            else
                attr3 = Int32.Parse(Request.QueryString["attr3"]);
            int catalog;
            if (Request.QueryString["catalog"] == null)
                return;
            else
                catalog = Int32.Parse(Request.QueryString["catalog"]);
            if (!IsPostBack)
            {
                renderDropDownListAttribute(catalog, attr1, attr2, attr3);
            }
            renderCatalogFilterItems(catalog, page, attr1, attr2, attr3);

        }

        private void renderCatalogFilterItems(int catalog, int page, int attr1, int attr2, int attr3)
        {
            this.catalogFilterContentResultContainerPanel.Controls.Clear();

            List<Item> allItems = ItemService.GetItemsByCatalogAndAttributes(catalog, attr1, attr2, attr3);
            List<Item> itemList = new List<Item>();
            int count = 0;
            foreach (Item item in allItems)
            {
                if ((count >= (page - 1) * 12) && (count < page * 12))
                    itemList.Add(item);
                count++;
            }
            int totalPage = count / 12;
            if (count % 12 != 0) totalPage++;

            Table table = new Table();
            TableRow tr = new TableRow();
            count = 0;
            foreach (Item item in itemList)
            {
                TableCell tc = new TableCell();
                tc.Controls.Add(renderCatalogFilterItem(item));
                tr.Controls.Add(tc);
                count++;
                if (count % 4 == 0)
                {
                    table.Controls.Add(tr);
                    tr = new TableRow();
                }
            }
            if (count % 4 != 0)
            {
                table.Controls.Add(tr);
            }
            this.catalogFilterContentResultContainerPanel.Controls.Add(table);
            if (allItems.Count > 0)
            {
                renderCatalogFilterPageLink(page, totalPage);
            }
        }

        private Panel renderCatalogFilterItem(Item item)
        {
            Panel catalogFilterResultItemContainer = new Panel();
            catalogFilterResultItemContainer.CssClass = "catalogFilterResultItemContainer";

            Panel catalogFilterResultItemImgContainer = new Panel();
            catalogFilterResultItemImgContainer.CssClass = "catalogFilterResultItemImgContainer";
            HyperLink imgLink = new HyperLink();
            imgLink.NavigateUrl = "/Page/V2/Business/productDetail.aspx?product=" + item.ItemID;
            Image img = new Image();
            img.ImageUrl = item.ImageUrl;
            img.ToolTip = item.Title;
            imgLink.Controls.Add(img);
            catalogFilterResultItemImgContainer.Controls.Add(imgLink);

            Panel catalogFilterResultItemTextContainer = new Panel();
            catalogFilterResultItemTextContainer.CssClass = "catalogFilterResultItemTextContainer";
            Panel catalogFilterResultItemTitleContainer = new Panel();
            catalogFilterResultItemTitleContainer.CssClass = "catalogFilterResultItemTitleContainer";
            HyperLink titleLink = new HyperLink();
            titleLink.Text = item.Title;
            titleLink.NavigateUrl = "/Page/V2/Business/productDetail.aspx?product=" + item.ItemID;
            catalogFilterResultItemTitleContainer.Controls.Add(titleLink);
            catalogFilterResultItemTextContainer.Controls.Add(catalogFilterResultItemTitleContainer);

            catalogFilterResultItemContainer.Controls.Add(catalogFilterResultItemImgContainer);
            catalogFilterResultItemContainer.Controls.Add(catalogFilterResultItemTextContainer);

            return catalogFilterResultItemContainer;
        }

        private void renderCatalogFilterPageLink(int page, int totalPage)
        {
            this.catalogFilterPageLinkContainerPanel.Controls.Clear();
              
            //Table table = new Table();
            //TableRow tr = new TableRow();
            //TableCell tc = new TableCell();
            HyperLink hl = new HyperLink();

            hl.Text = "1";
            if (page == 1) 
            {
                hl.CssClass = "current";
            }
            hl.NavigateUrl = BuildUrl(null, 1, null, null, null);
            //tc.Controls.Add(hl);
            this.catalogFilterPageLinkContainerPanel.Controls.Add(hl);
            int index = page - 1;
            if (page - 1 > 2)
            {
                Label lb = new Label();
                lb.Text = "...";
                lb.CssClass = "omit";
                //tc.Controls.Add(lb);
                this.catalogFilterPageLinkContainerPanel.Controls.Add(lb);
            }
            for (index = page - 1; index < page + 2; index++)
            {
                if (index > 1 && index < totalPage)
                {
                    hl = new HyperLink();
                    hl.Text = index.ToString();
                    if (index == page)
                    {
                        hl.CssClass = "current";
                    }
                    hl.NavigateUrl = BuildUrl(null, index, null, null, null);
                    //tc.Controls.Add(hl);
                    this.catalogFilterPageLinkContainerPanel.Controls.Add(hl);
                }
            }
            if (page + 1 < totalPage - 1)
            {
                Label lb = new Label();
                lb.Text = "...";
                lb.CssClass = "omit";
                //tc.Controls.Add(lb);
                this.catalogFilterPageLinkContainerPanel.Controls.Add(lb);
            }
            if (totalPage > 1)
            {
                hl = new HyperLink();
                hl.Text = totalPage.ToString();
                if (totalPage == page)
                {
                    hl.CssClass = "current";
                }
                hl.NavigateUrl = BuildUrl(null, totalPage, null, null, null);
                //tc.Controls.Add(hl);
                this.catalogFilterPageLinkContainerPanel.Controls.Add(hl);
            }
            //tr.Cells.Add(tc);
            //table.Rows.Add(tr);

            //catalogFilterPageLinkContainerPanel.Controls.Add(table);
        }

        private void renderDropDownListAttribute(int catalog, int attr1, int attr2, int attr3)
        {
            DropDownListAttributeA.Items.Clear();
            DropDownListAttributeB.Items.Clear();
            DropDownListAttributeC.Items.Clear();

            DropDownListAttributeA.Items.Add(new ListItem("全部", "0"));
            DropDownListAttributeB.Items.Add(new ListItem("全部", "0"));
            DropDownListAttributeC.Items.Add(new ListItem("全部", "0"));

            for (int level = 1; level <= 3; level++)
            {
                List<ItemAttribute> allAttr = ItemAttributeService.FindItemAttributesByCatalogAndLevel(catalog, level);
                foreach (ItemAttribute currentAttr in allAttr)
                {
                    if (level == 1)
                    {
                        DropDownListAttributeA.Items.Add(new ListItem(currentAttr.Name, currentAttr.ItemAttributeID.ToString()));
                    }
                    if (level == 2)
                    {
                        DropDownListAttributeB.Items.Add(new ListItem(currentAttr.Name, currentAttr.ItemAttributeID.ToString()));
                    }
                    if (level == 3)
                    {
                        DropDownListAttributeC.Items.Add(new ListItem(currentAttr.Name, currentAttr.ItemAttributeID.ToString()));
                    }
                }
            }

            DropDownListAttributeA.SelectedValue = attr1.ToString();
            DropDownListAttributeB.SelectedValue = attr2.ToString();
            DropDownListAttributeC.SelectedValue = attr3.ToString();
        }

        protected void DropDownListAttributeA_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(BuildUrl(null, 1, Int32.Parse(DropDownListAttributeA.SelectedValue), Int32.Parse(DropDownListAttributeB.SelectedValue), Int32.Parse(DropDownListAttributeC.SelectedValue)));
        }

        protected void DropDownListAttributeB_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(BuildUrl(null, 1, Int32.Parse(DropDownListAttributeA.SelectedValue), Int32.Parse(DropDownListAttributeB.SelectedValue), Int32.Parse(DropDownListAttributeC.SelectedValue)));
        }

        protected void DropDownListAttributeC_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(BuildUrl(null, 1, Int32.Parse(DropDownListAttributeA.SelectedValue), Int32.Parse(DropDownListAttributeB.SelectedValue), Int32.Parse(DropDownListAttributeC.SelectedValue)));
        }

        string BuildUrl(int? catalog, int? page, int? attr1, int? attr2, int? attr3)
        {
            string querystring;
            string thisPage = "/Page/V2/Business/catalogDetail.aspx";
            string catalogString = "catalog=";
            if (catalog == null)
            {
                catalogString += Request.QueryString["catalog"];
            }
            else
            {
                catalogString += catalog.ToString();
            }
            string pageString = "page=";
            if (page == null)
            {
                pageString += "1";
            }
            else
            {
                pageString += page.ToString();
            }
            string attr1String = "attr1=";
            if (attr1 == null)
            {
                attr1String += "0";
            }
            else
            {
                attr1String += attr1.ToString();
            }
            string attr2String = "attr2=";
            if (attr2 == null)
            {
                attr2String += "0";
            }
            else
            {
                attr2String += attr2.ToString();
            }
            string attr3String = "attr3=";
            if (attr3 == null)
            {
                attr3String += "0";
            }
            else
            {
                attr3String += attr3.ToString();
            }
            querystring = thisPage + "?" + catalogString + "&" + pageString + "&" + attr1String + "&" + attr2String + "&" + attr3String;
            return querystring;
        }
    }
}