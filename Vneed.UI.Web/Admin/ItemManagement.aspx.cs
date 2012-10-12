using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vneed.Model;
using Vneed.BLL;

namespace Vneed.UI.Web.Admin
{
    public partial class ItemManagement : System.Web.UI.Page
    {
        void LoadCatalogs()
        {
            List<Catalog> allCatalogs = CatalogService.GetAllSecondLevelCatalogs();
            foreach (Catalog curCatalog in allCatalogs)
            {
                ListBoxCatalog.Items.Add(new ListItem(curCatalog.Name, curCatalog.CatalogID.ToString()));
            }
        }

        void LoadItems()
        {
            ListBoxItem.Items.Clear();
            int CatalogID = Int32.Parse(ListBoxCatalog.SelectedValue);
            List<Item> allItems = ItemService.GetItemsByCatalogAndAttributes(CatalogID, 0, 0, 0);
            foreach (Item curItem in allItems)
            {
                ListBoxItem.Items.Add(new ListItem(curItem.Title, curItem.ItemID));
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCatalogs();
            }
        }

        protected void ListBoxCatalog_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadItems();
        }

        protected void ButtonEdit_Click(object sender, EventArgs e)
        {
            string ItemID = ListBoxItem.SelectedValue;
            Response.Redirect("\\Admin\\ModifyItem.aspx?itemID=" + ItemID);
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("\\Admin\\AddItem.aspx");
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {

        }
    }
}