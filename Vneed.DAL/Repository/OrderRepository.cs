using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vneed.Model;
using System.Web.Configuration;
using System.Data.SqlClient;

namespace Vneed.DAL
{
    public class OrderRepository
    {
        public static string AddOrder(Order newOrder)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["defaultConnectionString"].ToString();
            SqlConnection sqlConn = new SqlConnection(connectionString);
            sqlConn.Open();

            string cmdString;
            SqlCommand sqlCmd = new SqlCommand();
            cmdString = "INSERT INTO [Order] (OrderID, Status, Payment, Delivery, UserID, ModiefiedDate, Name, School, Contact, Email, IdentityNo)" +
                "VALUES (@orderID, @status, @payment, @delivery, @userID, @modifiedDate, @name, @school, @contact, @email, @identityNo)";
            sqlCmd = new SqlCommand(cmdString, sqlConn);
            string orderID = System.Guid.NewGuid().ToString();
            sqlCmd.Parameters.Add(new SqlParameter("orderID", orderID));
            newOrder.Status = 0;
            sqlCmd.Parameters.Add(new SqlParameter("status", newOrder.Status));
            sqlCmd.Parameters.Add(new SqlParameter("payment", newOrder.Payment));
            newOrder.Delivery = 0;
            sqlCmd.Parameters.Add(new SqlParameter("delivery", newOrder.Delivery));
            sqlCmd.Parameters.Add(new SqlParameter("userID", newOrder.UserID));
            sqlCmd.Parameters.Add(new SqlParameter("modifiedDate", DateTime.Now));
            sqlCmd.Parameters.Add(new SqlParameter("name", newOrder.Name));
            sqlCmd.Parameters.Add(new SqlParameter("school", newOrder.School));
            sqlCmd.Parameters.Add(new SqlParameter("contact", newOrder.Contact));
            sqlCmd.Parameters.Add(new SqlParameter("email", newOrder.Email));
            sqlCmd.Parameters.Add(new SqlParameter("identityNo", newOrder.IdentityNo));
            sqlCmd.ExecuteNonQuery();

            sqlConn.Close();

            return orderID;
        }

        public static void AddOrderDetail(OrderDetail newOrderDetail)
        {

            string connectionString = WebConfigurationManager.ConnectionStrings["defaultConnectionString"].ToString();
            SqlConnection sqlConn = new SqlConnection(connectionString);
            sqlConn.Open();

            string cmdString;
            SqlCommand sqlCmd = new SqlCommand();
            cmdString = "INSERT INTO OrderDetail (OrderID, ItemID, Title, Price, Quantity, TotalPrice, ImageUrl)" +
                "VALUES (@orderID, @itemID, @title, @price, @quantity, @totalPrice, @imageUrl)";
            sqlCmd = new SqlCommand(cmdString, sqlConn);
            string orderID = System.Guid.NewGuid().ToString();
            sqlCmd.Parameters.Add(new SqlParameter("orderID", newOrderDetail.OrderID));
            sqlCmd.Parameters.Add(new SqlParameter("itemID", newOrderDetail.ItemID));
            sqlCmd.Parameters.Add(new SqlParameter("title", newOrderDetail.Title));
            sqlCmd.Parameters.Add(new SqlParameter("price", newOrderDetail.Price));
            sqlCmd.Parameters.Add(new SqlParameter("quantity", newOrderDetail.Quantity));
            sqlCmd.Parameters.Add(new SqlParameter("totalPrice", newOrderDetail.TotalPrice));
            sqlCmd.Parameters.Add(new SqlParameter("imageUrl", newOrderDetail.ImageUrl));
            sqlCmd.ExecuteNonQuery();

            sqlConn.Close();
        }
    }
}
