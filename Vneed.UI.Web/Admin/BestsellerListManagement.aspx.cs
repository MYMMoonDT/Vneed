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
    public partial class BestsellerListManagement : System.Web.UI.Page
    {
        void LoadBestsellerList()
        {
            Table.Rows.Clear();
            TableRow tr = new TableRow();
            TableCell tc = new TableCell();
            tc.Text = "商品ID";
            tr.Cells.Add(tc);
            tc = new TableCell();
            tc.Text = "操作";
            tr.Cells.Add(tc);
            Table.Rows.Add(tr);

            List<Item> allItems = ItemService.GetBestsellers();
            foreach (Item curItem in allItems)
            {
                tr = new TableRow();
                tc = new TableCell();
                tc.Text = curItem.ItemID;
                tr.Cells.Add(tc);
                tc = new TableCell();
                Button up = new Button();
                up.Text = "上移";
                Button down = new Button();
                down.Text = "下移";
                Button del = new Button();
                del.Text = "移除";
                tc.Controls.Add(up);
                tc.Controls.Add(down);
                tc.Controls.Add(del);
                tr.Cells.Add(tc);
                Table.Rows.Add(tr);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadBestsellerList();
            }
        }
    }
}