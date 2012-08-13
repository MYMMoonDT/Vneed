using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vneed.Model
{
    public class Comment
    {
        public List<Comment> childComments;
        public int CommentID { get; set; }
        public int ParentCommentID { get; set; }
        public string ItemID { get; set; }
        public int UserID { get; set; }
        public string Text { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
