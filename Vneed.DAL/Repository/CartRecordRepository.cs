using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Vneed.Model;
using System.Web.Configuration;

namespace Vneed.DAL.Repository
{
    public class CartRecordRepository
    {
        public static void AddCartRecord(CartRecord newCartRecord)
        {
            //判断购物车中是否已经有该物品
            string connectionString = WebConfigurationManager.ConnectionStrings["defaultConnectionString"].ToString();
            SqlConnection sqlConn = new SqlConnection(connectionString);
            sqlConn.Open();

            string cmdString; 
            SqlCommand sqlCmd = new SqlCommand();
            //删除旧值
            cmdString = "DELETE FROM CartRecord WHERE UserID=@userID AND ItemID=@itemID";
            sqlCmd = new SqlCommand(cmdString, sqlConn);
            sqlCmd.Parameters.Add(new SqlParameter("userID", newCartRecord.UserID));
            sqlCmd.Parameters.Add(new SqlParameter("itemID", newCartRecord.ItemID));
//             else if (newCartRecord.Ip != null)
//             {
//                 cmdString = "DELETE FROM CartRecord WHERE Ip=@ip AND ItemID=@itemID";
//                 sqlCmd = new SqlCommand(cmdString, sqlConn);
//                 sqlCmd.Parameters.Add(new SqlParameter("ip", newCartRecord.Ip));
//                 sqlCmd.Parameters.Add(new SqlParameter("itemID", newCartRecord.ItemID));
//             }
            sqlCmd.ExecuteNonQuery();
            //添加新值
            cmdString = "INSERT INTO CartRecord (UserID, ItemID, Count, ModifiedDate) VALUES (@userID, @itemID, @count, @modifiedDate)";
            sqlCmd = new SqlCommand(cmdString, sqlConn);
            sqlCmd.Parameters.Add(new SqlParameter("userID", newCartRecord.UserID));
            sqlCmd.Parameters.Add(new SqlParameter("itemID", newCartRecord.ItemID));
            sqlCmd.Parameters.Add(new SqlParameter("count", newCartRecord.Count));
            sqlCmd.Parameters.Add(new SqlParameter("modifiedDate", DateTime.Now));
            //sqlCmd.Parameters.Add(new SqlParameter("ip", newCartRecord.Ip));
            sqlCmd.ExecuteNonQuery();

            sqlConn.Close();
        }

        public static void DeleteCartRecord(CartRecord newCartRecord)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["defaultConnectionString"].ToString();
            SqlConnection sqlConn = new SqlConnection(connectionString);
            sqlConn.Open();

            string cmdString;
            SqlCommand sqlCmd = new SqlCommand();

//             if (newCartRecord.UserID != null)
//             {
                cmdString = "DELETE FROM CartRecord WHERE UserID=@userID AND ItemID=@itemID";
                sqlCmd = new SqlCommand(cmdString, sqlConn);
                sqlCmd.Parameters.Add(new SqlParameter("userID", newCartRecord.UserID));
                sqlCmd.Parameters.Add(new SqlParameter("itemID", newCartRecord.ItemID));
//             }
//             else if (newCartRecord.Ip != null)
//             {
//                 cmdString = "DELETE FROM CartRecord WHERE Ip=@ip AND ItemID=@itemID";
//                 sqlCmd = new SqlCommand(cmdString, sqlConn);
//                 sqlCmd.Parameters.Add(new SqlParameter("ip", newCartRecord.Ip));
//                 sqlCmd.Parameters.Add(new SqlParameter("itemID", newCartRecord.ItemID));
//             }
            sqlCmd.ExecuteNonQuery();
        }

        public static List<CartRecord> FindCartRecordByUserID(int UserID)
        {
            List<CartRecord> result = new List<CartRecord>();

            string connectionString = WebConfigurationManager.ConnectionStrings["defaultConnectionString"].ToString();
            SqlConnection sqlConn = new SqlConnection(connectionString);
            sqlConn.Open();

            string cmdString = "SELECT * FROM [CartRecord] WHERE UserID = @userID";
            SqlCommand sqlCmd = new SqlCommand(cmdString, sqlConn);
            sqlCmd.Parameters.Add(new SqlParameter("userID", UserID));

            SqlDataReader sqlDataReader = sqlCmd.ExecuteReader();
            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    CartRecord newCartRecord = new CartRecord();
                    FillCartRecord(sqlDataReader, newCartRecord);
                    result.Add(newCartRecord);
                }
                sqlDataReader.Close();
            }

            return result;
        }

        static void FillCartRecord(SqlDataReader sqlDataReader, CartRecord newCardRecord)
        {
            newCardRecord.UserID = (int)sqlDataReader["UserID"];
            newCardRecord.ItemID = (string)sqlDataReader["ItemID"];
            newCardRecord.Count = (int)sqlDataReader["Count"];
            newCardRecord.ModifiedDate = (DateTime)sqlDataReader["ModifiedDate"];
            //newCardRecord.Ip = (string)sqlDataReader["Ip"];
        }
    }
}
