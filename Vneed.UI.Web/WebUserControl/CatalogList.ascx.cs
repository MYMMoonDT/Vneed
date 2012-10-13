using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vneed.BLL;
using Vneed.Model;

namespace Vneed.UI.Web.WebUserControl
{
    public partial class CatalogList : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Catalog> firstLevelCatalogs = CatalogService.GetAllFirstLevelCatalogs();
            foreach (Catalog catalog in firstLevelCatalogs)
            {
                //一级分类
                //TableRow tr = new TableRow();
                //TableCell tc = new TableCell();
                //tc.Text = catalog.Name;
                //tr.Controls.Add(tc);
                //Table.Rows.Add(tr);
                TableRow tr = new TableRow();
                TableCell tc = new TableCell();
                Panel firstPanel = new Panel();
                firstPanel.CssClass = "catalogItemFirst";
                Label firstLevel = new Label();
                firstLevel.Text = catalog.Name;
                firstPanel.Controls.Add(firstLevel);

                //该分类下二级分类
                List<Catalog> childCatalogs = CatalogService.GetAllChildCatalogs(catalog.CatalogID);
                foreach (Catalog childCatalog in childCatalogs)
                {
                    //TableRow trc = new TableRow();
                    //TableCell tcc = new TableCell();
                    //tcc.Text = childCatalog.Name;
                    //trc.Controls.Add(tcc);
                    //Table.Rows.Add(trc);
                    Panel childPanel = new Panel();
                    childPanel.CssClass = "catalogItemSecond";
                    HyperLink childLevel = new HyperLink();
                    childLevel.Text = childCatalog.Name;
                    childLevel.NavigateUrl = "/Page/Business/catalog.aspx?catalog=" + childCatalog.CatalogID.ToString();
                    childPanel.Controls.Add(childLevel);
                    firstPanel.Controls.Add(childPanel);
                }
                tc.Controls.Add(firstPanel);
                tr.Controls.Add(tc);
                Table.Rows.Add(tr);
            }
        }
    }
}