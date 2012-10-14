using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vneed.Model;
using Vneed.BLL;

namespace Vneed.UI.Web.Page.V2.Business
{
    public partial class catalogDetail : System.Web.UI.Page
    {
        private int catalogNum;
        private Catalog currentCatalog;

        protected void Page_Load(object sender, EventArgs e)
        {
            String catalogNumStr = this.Request.QueryString["catalog"];
            if (catalogNumStr == null)
            {
                Response.Redirect("~/Page/V2/index.aspx");
            }
            else
            {
                this.catalogNum = Int32.Parse(catalogNumStr);
            }
            renderCatalogSubTitle();
            this.CatalogFilterControl1.CatalogID = this.catalogNum;
        }
        private void renderCatalogSubTitle()
        {
            List<Catalog> secondLevelCatalogs = CatalogService.GetAllSecondLevelCatalogs();
            foreach (Catalog catalog in secondLevelCatalogs) 
            {
                if (catalog.CatalogID == this.catalogNum)
                {
                    this.currentCatalog = catalog;
                    break;
                }
            }
            this.catalogDetailSubTitleLabel.Text = this.currentCatalog.Name;
        }
    }
}