using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vneed.Model;
using Vneed.DAL.Repository;
using System.Web;

namespace Vneed.BLL
{
    public class CommentService
    {
        static public void AddComment(Comment newItem)
        {
            newItem.Text = HttpUtility.HtmlEncode(newItem.Text);
            CommentRepository.AddComment(newItem);
        }

        static public List<Comment> GetCommentsByItemID(string itemID)
        {
            List<Comment> comments = CommentRepository.FindCommentsByItemID(itemID);
            foreach (Comment comment in comments)
            {
                comment.Text = HttpUtility.HtmlDecode(comment.Text);
                foreach (Comment childComment in comment.childComments)
                {
                    childComment.Text = HttpUtility.HtmlDecode(childComment.Text);
                }
            }
            return comments;
        }
    }
}
