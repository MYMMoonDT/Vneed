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
    public partial class ItemAttributeManagement : System.Web.UI.Page
    {
        void LoadCatalogs()
        {
            DropDownListCatalogs.Items.Add(new ListItem("无", "0"));
            List<Catalog> allSecondLevelCataglogs= CatalogService.GetAllSecondLevelCatalogs();
            foreach (Catalog currentCatalog in allSecondLevelCataglogs)
            {
                DropDownListCatalogs.Items.Add(new ListItem(currentCatalog.Name, currentCatalog.CatalogID.ToString()));
                DropDownListNewAttrCatalog.Items.Add(new ListItem(currentCatalog.Name, currentCatalog.CatalogID.ToString()));
            }
            for(int level = 1; level <= 3; level++)
            {
                DropDownListNewAttrLevel.Items.Add(new ListItem(level.ToString(), level.ToString()));
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCatalogs();
            }
        }

        protected void DropDownListCatalogs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownListCatalogs.SelectedValue == "0")
            {
                Table.Rows.Clear();
                return;
            }
            for (int level = 1; level <= 3; level++)
            {
                TableRow tr = new TableRow();
                TableCell tc = new TableCell();
                tc.Text = "第" + level.ToString() + "类属性";
                tr.Cells.Add(tc);
                Table.Rows.Add(tr);
                List<ItemAttribute> attributes = ItemAttributeService.FindItemAttributesByCatalogAndLevel(Int32.Parse(DropDownListCatalogs.SelectedValue), level);
                foreach (ItemAttribute currentAttribute in attributes)
                {
                    tr = new TableRow();
                    tc = new TableCell();
                    tc.Text = currentAttribute.ItemAttributeID.ToString();
                    tr.Cells.Add(tc);
                    tc = new TableCell();
                    tc.Text = currentAttribute.Name;
                    tr.Cells.Add(tc);
                    Table.Rows.Add(tr);
                }
            }
        }

        protected void ButtonAddAttr_Click(object sender, EventArgs e)
        {
            ItemAttribute newItemAttribute = new ItemAttribute();
            newItemAttribute.CatalogID = Int32.Parse(DropDownListNewAttrCatalog.SelectedValue);
            newItemAttribute.ItemAttributeLevel = Int32.Parse(DropDownListNewAttrLevel.SelectedValue);
            newItemAttribute.Name = TextBoxNewAttrName.Text;
            ItemAttributeService.AddItemAttribute(newItemAttribute);
            Response.Redirect(Request.Url.ToString());
        }

        protected void ButtonEdit_Click(object sender, EventArgs e)
        {
            ItemAttribute newItemAttribute = new ItemAttribute();
            newItemAttribute.ItemAttributeID = Int32.Parse(TextBoxEditID.Text);
            newItemAttribute.Name = TextBoxEditNewName.Text;
            ItemAttributeService.UpdateItemAttribute(newItemAttribute);
            Response.Redirect(Request.Url.ToString());
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            ItemAttribute newItemAttribute = new ItemAttribute();
            newItemAttribute.ItemAttributeID = Int32.Parse(TextBoxDeleteID.Text);
            ItemAttributeService.DeleteItemAttribute(newItemAttribute);
            Response.Redirect(Request.Url.ToString());
        }
    }
}