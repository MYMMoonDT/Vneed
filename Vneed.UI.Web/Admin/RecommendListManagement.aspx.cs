using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Vneed.BLL;

namespace Vneed.UI.Web.Admin
{
    public partial class RecommendListManagement : System.Web.UI.Page
    {
        private List<TextBox> tbItemIDs = new List<TextBox>();

        private void CreateHeadRow()
        {
            TableRow tr = new TableRow();

            TableCell tc = new TableCell();
            tc.Text = "位置";
            tr.Cells.Add(tc);

            tc = new TableCell();
            tc.Text = "物品ID";
            tr.Cells.Add(tc);

            table.Rows.Add(tr);
        }
        private void CreateItemRow(int pos)
        {
            TableRow tr = new TableRow();

            TableCell tc = new TableCell();
            tc.Text = pos.ToString();
            tr.Cells.Add(tc);

            tc = new TableCell();
            TextBox tb = new TextBox();
            tb.ID = pos.ToString();
            tb.Text = "";
            tbItemIDs.Add(tb);
            tc.Controls.Add(tb);
            tr.Cells.Add(tc);

            table.Rows.Add(tr);
        }

        private void CreateCommandRow()
        {
            TableRow tr = new TableRow();

            TableCell tc = new TableCell();
            Button btn = new Button();
            btn.Text = "更新";
            btn.Click += new EventHandler(UpdateClick);
            tc.Controls.Add(btn);
            tr.Cells.Add(tc);

            table.Rows.Add(tr);
        }

        private void CreateControls()
        {
            CreateHeadRow();
            for (int i = 0; i < 12; i++)
            {
                CreateItemRow(i);
            }
            CreateCommandRow();
        }

        private void RefreshControls()
        {
            foreach (TextBox tb in tbItemIDs)
            {
                int pos = Int32.Parse(tb.ID);
                tb.Text = ItemService.GetRecommendItemIDByPos(pos);
            }
        }

        protected void UpdateClick(object sender, EventArgs e)
        {
            foreach (TextBox tb in tbItemIDs)
            {
                int pos = Int32.Parse(tb.ID);
                ItemService.UpdateRecommendItem(tb.Text, pos);
            }

            Response.Write("<script>alert('更新成功');document.location.reload();</script>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            CreateControls();

            if (!IsPostBack)
            {
                RefreshControls();
            }
        }
    }
}