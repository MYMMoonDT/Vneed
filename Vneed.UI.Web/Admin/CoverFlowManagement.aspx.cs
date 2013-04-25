using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Vneed.BLL;
using Vneed.Model;

namespace Vneed.UI.Web.Admin
{
    public partial class CoverFlowManagement : System.Web.UI.Page
    {
        private void RefreshCoverFlow()
        {
            List<CoverFlowItem> coverFlows = CoverFlowService.GetAll();
            //int lastPos = 0;
            foreach (CoverFlowItem coverFlow in coverFlows)
            {
                TableRow tr = new TableRow();

                TableCell tc = new TableCell();
                tc.Text = coverFlow.Pos.ToString();
                tr.Cells.Add(tc);

                tc = new TableCell();
                Image img = new Image();
                img.ImageUrl = coverFlow.ImageUrl;
                img.Width = 200;
                img.Height = 100;
                tc.Controls.Add(img);
                tr.Cells.Add(tc);

                tc = new TableCell();
                tc.Text = coverFlow.NavUrl;
                tr.Cells.Add(tc);

                tc = new TableCell();
                Button upBtn = new Button();
                upBtn.Text = "上移";
                upBtn.CommandArgument = coverFlow.Pos.ToString();
                upBtn.Click += new EventHandler(MoveUp);
                tc.Controls.Add(upBtn);
                tr.Cells.Add(tc);

                tc = new TableCell();
                Button downBtn = new Button();
                downBtn.Text = "下移";
                downBtn.CommandArgument = coverFlow.Pos.ToString();
                downBtn.Click += new EventHandler(MoveDown);
                tc.Controls.Add(downBtn);
                tr.Cells.Add(tc);

                tc = new TableCell();
                Button delBtn = new Button();
                delBtn.Text = "删除";
                delBtn.CommandArgument = coverFlow.Pos.ToString();
                delBtn.Click += new EventHandler(Delete);
                tc.Controls.Add(delBtn);
                tr.Cells.Add(tc);

                table.Rows.Add(tr);
            }

        }

        private void MoveUp(object sender, EventArgs e)
        {
            int pos = Int32.Parse(((Button)sender).CommandArgument);
            CoverFlowService.MoveUp(pos);
            Response.Redirect(Request.Url.ToString());
        }

        private void MoveDown(object sender, EventArgs e)
        {
            int pos = Int32.Parse(((Button)sender).CommandArgument);
            CoverFlowService.MoveDown(pos);
            Response.Redirect(Request.Url.ToString());
        }

        private void Delete(object sender, EventArgs e)
        {
            int pos = Int32.Parse(((Button)sender).CommandArgument);
            CoverFlowService.Delete(pos);
            Response.Redirect(Request.Url.ToString());
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            RefreshCoverFlow();
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            if(FileUploadImg.HasFile == false) return;
            if (TextBoxUrl.Text == "") return;

            string fileName = System.Guid.NewGuid().ToString() + FileUploadImg.FileName.Substring(FileUploadImg.FileName.LastIndexOf("."), FileUploadImg.FileName.Length - FileUploadImg.FileName.LastIndexOf("."));
            string imageUrl = @"~\Image\Gallery\";
            string realUrl = Server.MapPath(@"~\Image\Gallery\");
            imageUrl += fileName;
            realUrl += fileName;
            FileUploadImg.SaveAs(realUrl);

            CoverFlowItem newItem = new CoverFlowItem();
            newItem.ImageUrl = imageUrl;
            newItem.NavUrl = TextBoxUrl.Text;

            CoverFlowService.Add(newItem);

            Response.Redirect(Request.Url.ToString());
        }
    }
}