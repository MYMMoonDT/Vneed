using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vneed.Model;
using Vneed.BLL;

namespace Vneed.UI.Web.WebUserControl
{
    public partial class FilterList : System.Web.UI.UserControl
    {
        int totalPage = 0;

        void LoadAttr(int catalog, int attr1, int attr2, int attr3)
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

        void LoadItems(int catalog, int page, int attr1, int attr2, int attr3)
        {
            Table.Rows.Clear();
            List<Item> allItems = ItemService.GetItemsByCatalogAndAttributes(catalog, attr1, attr2, attr3);
            List<Item> itemList = new List<Item>();
            int count = 0;
            foreach (Item item in allItems)
            {
                if ((count >= (page - 1) * 12) && (count < page * 12))
                    itemList.Add(item);
                count++;
            }
            totalPage = count / 12;
            if (count % 12 != 0) totalPage++;
            //TableRow trImage = new TableRow();
            //TableRow trName = new TableRow();
            //TableRow trDesc = new TableRow();

            TableRow trProduct = new TableRow();
            count = 0;
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
                HyperLink imglink = new HyperLink();
                imglink.NavigateUrl = "/Page/Business/product.aspx?product=" + item.ItemID;
                Image img = new Image();
                img.ImageUrl = item.ImageUrl;
                img.CssClass = "productPicItem2Image";
                imglink.Controls.Add(img);
                productPicItem.Controls.Add(imglink);
                productItem.Controls.Add(productPicItem);
                Panel productDisItem = new Panel();
                productDisItem.CssClass = "productDisItem2";
                Panel productDisTitleItem = new Panel();
                productDisTitleItem.CssClass = "productDisTitleItem2";
                Panel productDisTypeItem = new Panel();
                productDisTypeItem.CssClass = "productDisTypeItem2";
                //Label title = new Label();
                //title.Text = item.Title;
                //yizhenfei show the hyperlink
                HyperLink title = new HyperLink();
                title.CssClass = "";
                title.Text = item.Title;
                title.NavigateUrl = "/Page/Business/product.aspx?product=" + item.ItemID;
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

        void LoadPageButtons(int page)
        {
            TablePage.Rows.Clear();
            TableRow tr = new TableRow();
            TableCell tc = new TableCell();
            HyperLink hl = new HyperLink();
            hl.Text = "1";
            hl.NavigateUrl = BuildUrl(null, 1, null, null, null);
            tc.Controls.Add(hl);
            int index = page - 1;
            for (index = page - 1; index < page + 2; index++)
            {
                if (index > 1 && index < totalPage)
                {
                    hl = new HyperLink();
                    hl.Text = index.ToString();
                    hl.NavigateUrl = BuildUrl(null, index, null, null, null);
                    tc.Controls.Add(hl);
                }
            }
            if (totalPage > 1)
            {
                hl = new HyperLink();
                hl.Text = totalPage.ToString();
                hl.NavigateUrl = BuildUrl(null, totalPage, null, null, null);
                tc.Controls.Add(hl);
            }
            tr.Cells.Add(tc);
            TablePage.Rows.Add(tr);
        }

        

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
                LoadAttr(catalog, attr1, attr2, attr3);
            }
                LoadItems(catalog, page, attr1, attr2, attr3);
                LoadPageButtons(page);
        }

        protected void DropDownListAttributeA_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(BuildUrl(null, 1, Int32.Parse(DropDownListAttributeA.SelectedValue), null, null));
        }

        string BuildUrl(int? catalog, int? page, int? attr1, int? attr2, int? attr3)
        {
            string querystring;
            string thisPage = "/Page/Business/catalog.aspx";
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

        protected void DropDownListAttributeB_SelectedIndexChanged(object sender, EventArgs e)
        {

            Response.Redirect(BuildUrl(null, 1, null, Int32.Parse(DropDownListAttributeB.SelectedValue), null));
        }

        protected void DropDownListAttributeC_SelectedIndexChanged(object sender, EventArgs e)
        {

            Response.Redirect(BuildUrl(null, 1, null, null, Int32.Parse(DropDownListAttributeC.SelectedValue)));
        }
    }
}