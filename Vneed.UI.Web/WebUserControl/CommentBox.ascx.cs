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
    public partial class CommentBox : System.Web.UI.UserControl
    {
        private string itemID;
        public string ItemID
        {
            set
            {
                itemID = value;
                LoadComments(itemID);
            }
            get { return itemID; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public void LoadComments(string itemID)
        {
            //获得所有留言
            List<Comment> comments = CommentService.GetCommentsByItemID(itemID);
            //显示所有第一级留言
            int no = 1;
            foreach (Comment comment in comments)
            {
                User owner = UserService.GetUserByUserID(comment.UserID);
                TableRow newCommentRow = new TableRow();
                TableCell portraitCell = new TableCell();
                portraitCell.RowSpan = 3;
                Image portraitImage = new Image();
                portraitImage.ImageUrl = owner.AdditionalInfo.PortraitUrl;
                portraitCell.Controls.Add(portraitImage);
                TableCell nameCell = new TableCell();
                nameCell.Text = owner.Username;
                TableCell dateCell = new TableCell();
                dateCell.Text = comment.ModifiedDate.ToString();
                TableCell noCell = new TableCell();
                noCell.Text = no.ToString() + "楼";
                no++;
                newCommentRow.Cells.Add(portraitCell);
                newCommentRow.Cells.Add(nameCell);
                newCommentRow.Cells.Add(dateCell);
                newCommentRow.Cells.Add(noCell);
                TableComment.Rows.Add(newCommentRow);

                newCommentRow = new TableRow();
                TableCell textCell = new TableCell();
                textCell.ColumnSpan = 3;
                Label LabelText = new Label();
                LabelText.Text = comment.Text;
                textCell.Controls.Add(LabelText);
                //显示子留言
                if (comment.childComments.Count != 0)
                {
                    Table childTable = new Table();
                    foreach (Comment childComment in comment.childComments)
                    {
                        TableRow childCommentRow = new TableRow();
                        TableCell childNameCell = new TableCell();
                        childNameCell.Text = UserService.GetUserByUserID(childComment.UserID).Username;
                        TableCell childDateCell = new TableCell();
                        childDateCell.Text = childComment.ModifiedDate.ToString();
                        childCommentRow.Cells.Add(childNameCell);
                        childCommentRow.Cells.Add(childDateCell);
                        childTable.Rows.Add(childCommentRow);

                        childCommentRow = new TableRow();
                        TableCell childTextCell = new TableCell();
                        childTextCell.Text = childComment.Text;
                        childCommentRow.Cells.Add(childTextCell);
                        childTable.Rows.Add(childCommentRow);
                    }
                    textCell.Controls.Add(childTable);
                }
                newCommentRow.Cells.Add(textCell);
                TableComment.Rows.Add(newCommentRow);

                newCommentRow = new TableRow();
                TableCell toolCell = new TableCell();
                toolCell.ColumnSpan = 3;
                toolCell.Text = "回复";
                newCommentRow.Cells.Add(toolCell);
                TableComment.Rows.Add(newCommentRow);
            }
        }

        protected void ButtonCommitComment_Click(object sender, EventArgs e)
        {
            if (AuthenticationService.GetUsername() == null)
            {
                Response.Redirect(@"~\Account\Login.aspx");
                return;
            }
            Comment newComment = new Comment();
            newComment.ParentCommentID = 0;
            newComment.UserID = AuthenticationService.GetUser().UserID;
            newComment.ItemID = itemID;
            newComment.ModifiedDate = DateTime.Now;
            newComment.Text = TextBoxComment.Text;
            CommentService.AddComment(newComment);
            Response.Redirect(Request.Url.ToString()); 
        }
    }
}