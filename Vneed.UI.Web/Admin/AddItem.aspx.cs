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
    public partial class AddItem : System.Web.UI.Page
    {
        void LoadAttributes()
        {
            int catalogID = Int32.Parse(DropDownListCatalog.SelectedValue);
            DropDownListAttr1.Items.Clear();
            DropDownListAttr2.Items.Clear();
            DropDownListAttr3.Items.Clear();
            DropDownListAttr1.Items.Add(new ListItem("无", "0"));
            DropDownListAttr2.Items.Add(new ListItem("无", "0"));
            DropDownListAttr3.Items.Add(new ListItem("无", "0"));
            for (int level = 1; level <= 3; level++)
            {
                List<ItemAttribute> allAttr = ItemAttributeService.FindItemAttributesByCatalogAndLevel(catalogID, level);
                foreach (ItemAttribute currentAttr in allAttr)
                {
                    if (level == 1)
                    {
                        DropDownListAttr1.Items.Add(new ListItem(currentAttr.Name, currentAttr.ItemAttributeID.ToString()));
                    }

                    if (level == 2)
                    {
                        DropDownListAttr2.Items.Add(new ListItem(currentAttr.Name, currentAttr.ItemAttributeID.ToString()));
                    }

                    if (level == 3)
                    {
                        DropDownListAttr3.Items.Add(new ListItem(currentAttr.Name, currentAttr.ItemAttributeID.ToString()));
                    }
                }
            }
        }

        void LoadCatalogs()
        {
            List<Catalog> allCatalogs = CatalogService.GetAllSecondLevelCatalogs();
            foreach (Catalog currentCatalog in allCatalogs)
            {
                DropDownListCatalog.Items.Add(new ListItem(currentCatalog.Name, currentCatalog.CatalogID.ToString()));
            }
            LoadAttributes();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCatalogs();
            }
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            string imageUrl = @"~\Image\ItemImage\";
            string realUrl = Server.MapPath(@"~\Image\ItemImage\");
            string fileName;
            if (FileUploadImage.HasFile)
            {
                fileName = System.Guid.NewGuid().ToString() + FileUploadImage.FileName.Substring(FileUploadImage.FileName.LastIndexOf("."), FileUploadImage.FileName.Length - FileUploadImage.FileName.LastIndexOf("."));
                imageUrl += fileName;
                realUrl += fileName;
                FileUploadImage.SaveAs(realUrl);
            }
            else
            {
                imageUrl += "default.jpg";
            }

            Item newItem = new Item();
            newItem.Title = TextBoxTitle.Text;
            newItem.Description = TextBoxDescription.Text;
            newItem.ImageUrl = imageUrl;
            newItem.Price = Int32.Parse(TextBoxPrice.Text);
            newItem.OriginalPrice = Int32.Parse(TextBoxOriginalPrice.Text);
            newItem.CatalogID = Int32.Parse(DropDownListCatalog.SelectedValue);
            newItem.AttributeAID = Int32.Parse(DropDownListAttr1.SelectedValue);
            newItem.AttributeBID = Int32.Parse(DropDownListAttr2.SelectedValue);
            newItem.AttributeCID = Int32.Parse(DropDownListAttr3.SelectedValue);
            ItemService.AddNewItem(newItem);
        }

        protected void DropDownListCatalog_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAttributes();
        }
    }
}