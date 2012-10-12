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
        void LoadAttr()
        {
            int catalog = Int32.Parse(this.Request.QueryString["catalog"]);
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
        }

        void LoadItems()
        {
            int page;
            if (Request.QueryString["page"] == null)
                page = 0;
            else
                page = Int32.Parse(Request.QueryString["page"]);
            Table.Rows.Clear();
            int catalog = Int32.Parse(this.Request.QueryString["catalog"]);
            List<Item> allItems = ItemService.GetItemsByCatalogAndAttributes(catalog, Int32.Parse(DropDownListAttributeA.SelectedValue), Int32.Parse(DropDownListAttributeB.SelectedValue), Int32.Parse(DropDownListAttributeC.SelectedValue));
            List<Item> itemList = new List<Item>();
            int count = 0;
            foreach (Item item in allItems)
            {
                if ((count >= page * 12) && (count < (page + 1) * 12))
                    itemList.Add(item);
            }
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

        void LoadPageButtons()
        {

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadAttr();
                LoadItems();
                LoadPageButtons();
            }
        }

        protected void DropDownListAttributeA_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadItems();
        }
    }
}