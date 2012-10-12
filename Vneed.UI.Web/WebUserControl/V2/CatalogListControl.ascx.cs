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
    public partial class CatalogListControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            renderCatalogItems();
        }
        private void renderCatalogItems() 
        {
            List<Catalog> firstLevelCatalogs = CatalogService.GetAllFirstLevelCatalogs();
            foreach (Catalog catalog in firstLevelCatalogs)
            {
                this.CatalogListContainerPanel.Controls.Add(renderCatalogItem(catalog));
            }
        }

        private Panel renderCatalogItem(Catalog catalog) 
        {
            Panel catalogListItemContainer = new Panel();
            catalogListItemContainer.CssClass = "catalogListItemContainer";

            Panel catalogItemFirstClass = new Panel();
            catalogItemFirstClass.CssClass = "catalogItemFirstClass";
            Label firstClassLabel = new Label();
            firstClassLabel.Text = catalog.Name;
            catalogItemFirstClass.Controls.Add(firstClassLabel);
            catalogListItemContainer.Controls.Add(catalogItemFirstClass);

            List<Catalog> childCatalogs = CatalogService.GetAllChildCatalogs(catalog.CatalogID);
            foreach (Catalog childCatalog in childCatalogs) 
            {
                Panel catalogItemSecondClass = new Panel();
                catalogItemSecondClass.CssClass = "catalogItemSecondClass";

                HyperLink secondClassLink = new HyperLink();
                secondClassLink.Text = childCatalog.Name;
                secondClassLink.NavigateUrl = "~/Page/Business/catalog.aspx?catalog=" + childCatalog.CatalogID.ToString();
                catalogItemSecondClass.Controls.Add(secondClassLink);

                catalogListItemContainer.Controls.Add(catalogItemSecondClass);
            }

            return catalogListItemContainer;
        }
    }
}