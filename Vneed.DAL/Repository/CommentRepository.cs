using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vneed.Model;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace Vneed.DAL.Repository
{
    public class CommentRepository
    {
        static public void AddComment(Comment newComment)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["defaultConnectionString"].ToString();
            SqlConnection sqlConn = new SqlConnection(connectionString);
            sqlConn.Open();

            string cmdString = "INSERT INTO [Comment] (ParentCommentID, ItemID, UserID, Text, ModifiedDate) VALUES (@parentCommentID, @itemID, @userID, @text, @modifiedDate)";
            SqlCommand sqlCmd = new SqlCommand(cmdString, sqlConn);
            sqlCmd.Parameters.Add(new SqlParameter("parentCommentID", newComment.ParentCommentID));
            sqlCmd.Parameters.Add(new SqlParameter("itemID", newComment.ItemID));
            sqlCmd.Parameters.Add(new SqlParameter("userID", newComment.UserID));
            sqlCmd.Parameters.Add(new SqlParameter("text", newComment.Text));
            sqlCmd.Parameters.Add(new SqlParameter("modifiedDate", newComment.ModifiedDate));

            sqlCmd.ExecuteNonQuery();

            sqlConn.Close();
        }

        static public List<Comment> FindCommentsByItemID(string itemID)
        {
            List<Comment> result = new List<Comment>();

            string connectionString = WebConfigurationManager.ConnectionStrings["defaultConnectionString"].ToString();
            SqlConnection sqlConn = new SqlConnection(connectionString);
            sqlConn.Open();

            string cmdString = "SELECT * FROM Comment WHERE ParentCommentID = 0 AND ItemID = @itemID ORDER BY ModifiedDate DESC";
            SqlCommand sqlCmd = new SqlCommand(cmdString, sqlConn);
            sqlCmd.Parameters.Add(new SqlParameter("itemID", itemID));

            SqlDataReader sqlDataReader = sqlCmd.ExecuteReader();
            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    Comment newComment = new Comment();
                    FillComment(sqlDataReader, newComment);
                    newComment.childComments = GetChildComments(newComment.CommentID);
                    result.Add(newComment);
                }
                sqlDataReader.Close();
            }

            return result;
        }

        static List<Comment> GetChildComments(int parentCommentID)
        {
            List<Comment> result = new List<Comment>();

            string connectionString = WebConfigurationManager.ConnectionStrings["defaultConnectionString"].ToString();
            SqlConnection sqlConn = new SqlConnection(connectionString);
            sqlConn.Open();

            string cmdString = "SELECT * FROM Comment WHERE ParentCommentID = @parentCommentID ORDER BY ModifiedDate DESC";
            SqlCommand sqlCmd = new SqlCommand(cmdString, sqlConn);
            sqlCmd.Parameters.Add(new SqlParameter("parentCommentID", parentCommentID));

            SqlDataReader sqlDataReader = sqlCmd.ExecuteReader();
            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    Comment newChildComment = new Comment();
                    FillComment(sqlDataReader, newChildComment);
                    result.Add(newChildComment);
                }
                sqlDataReader.Close();
            }

            return result;
        }

        static void FillComment(SqlDataReader sqlDataReader, Comment newComment)
        {
            newComment.CommentID = (int)sqlDataReader["CommentID"];
            newComment.ParentCommentID = (int)sqlDataReader["ParentCommentID"];
            newComment.ItemID = (string)sqlDataReader["ItemID"];
            newComment.UserID = (int)sqlDataReader["UserID"];
            newComment.Text = (string)sqlDataReader["Text"];
            newComment.ModifiedDate = (DateTime)sqlDataReader["ModifiedDate"];
        }
    }
}
