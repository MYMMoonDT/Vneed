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
    public partial class CatalogManagement : System.Web.UI.Page
    {
        private void LoadAllCatalogs()
        {
            DropDownListFirstLevelCatalogs.Items.Clear();
            List<Catalog> allFirstLevelCatalogs = CatalogService.GetAllFirstLevelCatalogs();
            DropDownListFirstLevelCatalogs.Items.Add(new ListItem("无父分类", "0"));
            foreach(Catalog currentCatalog in allFirstLevelCatalogs)
            {
                DropDownListFirstLevelCatalogs.Items.Add(new ListItem(currentCatalog.Name, currentCatalog.CatalogID.ToString()));
                DropDownListModifyCatalog.Items.Add(new ListItem(currentCatalog.Name, currentCatalog.CatalogID.ToString()));
                DropDownListDeleteCatalog.Items.Add(new ListItem(currentCatalog.Name, currentCatalog.CatalogID.ToString()));
                List<Catalog> allChildCatalogs = CatalogService.GetAllChildCatalogs(currentCatalog.CatalogID);
                foreach (Catalog childCatalog in allChildCatalogs)
                {
                    DropDownListModifyCatalog.Items.Add(new ListItem(childCatalog.Name, childCatalog.CatalogID.ToString()));
                    DropDownListDeleteCatalog.Items.Add(new ListItem(childCatalog.Name, childCatalog.CatalogID.ToString()));
                }
            }
        }

        private void LoadCatalog()
        {
            Table.Rows.Clear();
            List<Catalog> allFirstLevelCatalogs = CatalogService.GetAllFirstLevelCatalogs();
            foreach (Catalog currentCatalog in allFirstLevelCatalogs)
            {
                TableRow tr = new TableRow();
                TableCell tc = new TableCell();
                tc.ColumnSpan = 2;
                tc.Text = currentCatalog.CatalogID.ToString();
                tr.Cells.Add(tc);
                tc = new TableCell();
                tc.Text = currentCatalog.Name;
                tr.Cells.Add(tc);
                Table.Rows.Add(tr);
                //加入子分类
                List<Catalog> allChildCatalogs = CatalogService.GetAllChildCatalogs(currentCatalog.CatalogID);
                foreach (Catalog childCatalog in allChildCatalogs)
                {
                    tr = new TableRow();
                    tc = new TableCell();
                    tc.Text = "->";
                    tr.Cells.Add(tc);
                    tc = new TableCell();
                    tc.Text = childCatalog.CatalogID.ToString();
                    tr.Cells.Add(tc);
                    tc = new TableCell();
                    tc.Text = childCatalog.Name;
                    tr.Cells.Add(tc);
                    Table.Rows.Add(tr);
                }
            }
        
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadAllCatalogs();
            }
            LoadCatalog();
        }

        protected void ButtonAddCatalog_Click(object sender, EventArgs e)
        {
            Catalog newCatalog = new Catalog();
            newCatalog.Name = TextBoxNewCatalogName.Text;
            newCatalog.ParentCatalogID = Int32.Parse(DropDownListFirstLevelCatalogs.SelectedValue);
            CatalogService.AddCatalog(newCatalog);
            Response.Redirect(Request.Url.ToString());
        }

        protected void ButtonDeleteCatalog_Click(object sender, EventArgs e)
        {
            Catalog oldCatalog = new Catalog();
            oldCatalog.CatalogID = Int32.Parse(DropDownListDeleteCatalog.SelectedValue);
            CatalogService.DeleteCatalog(oldCatalog);
            Response.Redirect(Request.Url.ToString());
        }

        protected void ButtonModifyCatalog_Click(object sender, EventArgs e)
        {
            Catalog newCatalog = new Catalog();
            newCatalog.CatalogID = Int32.Parse(DropDownListModifyCatalog.SelectedValue);
            newCatalog.Name = TextBoxModifyCatalog.Text;
            CatalogService.ModifyCatalog(newCatalog);
            Response.Redirect(Request.Url.ToString());
        }
    }
}