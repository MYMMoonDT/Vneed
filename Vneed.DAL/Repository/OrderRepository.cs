﻿using System;
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

        public static Decimal GetOrderPrice(string OrderID)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["defaultConnectionString"].ToString();
            SqlConnection sqlConn = new SqlConnection(connectionString);
            sqlConn.Open();

            string cmdString = "SELECT SUM(TotalPrice) FROM OrderDetail WHERE OrderID=@orderID";
            SqlCommand sqlCmd = new SqlCommand(cmdString, sqlConn);
            sqlCmd.Parameters.Add(new SqlParameter("orderID", OrderID));

            SqlDataReader sqlDataReader = sqlCmd.ExecuteReader();
            Decimal result = 99999999;
            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    result = (Decimal)sqlDataReader[0];
                }
                sqlDataReader.Close();
            }

            return result;
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

        public static List<Order> FindOrdersByUserID(int UserID)
        {
            List<Order> result = new List<Order>();

            string connectionString = WebConfigurationManager.ConnectionStrings["defaultConnectionString"].ToString();
            SqlConnection sqlConn = new SqlConnection(connectionString);
            sqlConn.Open();

            string cmdString = "SELECT * FROM [Order] WHERE UserID = @userID";
            SqlCommand sqlCmd = new SqlCommand(cmdString, sqlConn);
            sqlCmd.Parameters.Add(new SqlParameter("userID", UserID));

            SqlDataReader sqlDataReader = sqlCmd.ExecuteReader();
            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    Order newOrder = new Order();
                    FillOrder(sqlDataReader, newOrder);
                    result.Add(newOrder);
                }
                sqlDataReader.Close();
            }

            return result;
        }

        static void FillOrder(SqlDataReader sqlDataReader, Order newOrder)
        {
            newOrder.OrderSerialNumber = (int)sqlDataReader["OrderSerialNumber"];
            newOrder.OrderID = (string)sqlDataReader["OrderID"];
            newOrder.Status = (int)sqlDataReader["Status"];
            newOrder.Payment = (int)sqlDataReader["Payment"];
            newOrder.Delivery = (int)sqlDataReader["Delivery"];
            newOrder.UserID = (int)sqlDataReader["UserID"];
            newOrder.ModiefiedDate = (DateTime)sqlDataReader["ModiefiedDate"];
            newOrder.Name = (string)sqlDataReader["Name"];
            newOrder.School = (string)sqlDataReader["School"];
            newOrder.Contact = (string)sqlDataReader["Contact"];
            newOrder.Email = (string)sqlDataReader["Email"];
            newOrder.IdentityNo = (string)sqlDataReader["IdentityNo"];
        }
    }
}
