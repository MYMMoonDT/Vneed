using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vneed.Model;
using System.Web.Configuration;
using System.Data.SqlClient;

namespace Vneed.DAL.Repository
{
    public class ItemRepository
    {
        public static void AddItem(Item newItem)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["defaultConnectionString"].ToString();
            SqlConnection sqlConn = new SqlConnection(connectionString);
            sqlConn.Open();

            string cmdString = "INSERT INTO [Item] (ItemID, Title, Description, ImageUrl, Price, OriginalPrice, CatalogID, ModifiedDate, AttributeAID, AttributeBID, AttributeCID, Active) VALUES (@itemID, @title, @description, @imageUrl, @price, @originalPrice, @catalogID, @modifiedDate, @attributeAID, @attributeBID, @attributeCID, 1)";
            SqlCommand sqlCmd = new SqlCommand(cmdString, sqlConn);
            sqlCmd.Parameters.Add(new SqlParameter("itemID", System.Guid.NewGuid().ToString()));
            sqlCmd.Parameters.Add(new SqlParameter("title", newItem.Title));
            sqlCmd.Parameters.Add(new SqlParameter("description", newItem.Description));
            sqlCmd.Parameters.Add(new SqlParameter("imageUrl", newItem.ImageUrl));
            sqlCmd.Parameters.Add(new SqlParameter("price", newItem.Price));
            sqlCmd.Parameters.Add(new SqlParameter("originalPrice", newItem.OriginalPrice));
            sqlCmd.Parameters.Add(new SqlParameter("catalogID", newItem.CatalogID));
            sqlCmd.Parameters.Add(new SqlParameter("modifiedDate", DateTime.Now));
            sqlCmd.Parameters.Add(new SqlParameter("attributeAID", newItem.AttributeAID));
            sqlCmd.Parameters.Add(new SqlParameter("attributeBID", newItem.AttributeBID));
            sqlCmd.Parameters.Add(new SqlParameter("attributeCID", newItem.AttributeCID));

            sqlCmd.ExecuteNonQuery();

            sqlConn.Close();
        }

        public static void DeleteItem(string itemID)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["defaultConnectionString"].ToString();
            SqlConnection sqlConn = new SqlConnection(connectionString);
            sqlConn.Open();

            string cmdString = "DELETE FROM [Item] WHERE ItemID=@itemID";
            SqlCommand sqlCmd = new SqlCommand(cmdString, sqlConn);
            sqlCmd.Parameters.Add(new SqlParameter("itemID", itemID));

            sqlCmd.ExecuteNonQuery();

            sqlConn.Close();
        }

        public static void ModifyItem(Item newItem, int active)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["defaultConnectionString"].ToString();
            SqlConnection sqlConn = new SqlConnection(connectionString);
            sqlConn.Open();

            string cmdString = "UPDATE [Item] SET Title = @title, Description = @description, ImageUrl = @imageUrl, Price = @price, OriginalPrice = @originalPrice, CatalogID=@catalogID, ModifiedDate=@modifiedDate, AttributeAID = @attributeAID, AttributeBID = @attributeBID, AttributeCID = @attributeCID, Active=@active WHERE ItemID = @itemID";
            SqlCommand sqlCmd = new SqlCommand(cmdString, sqlConn);
            sqlCmd.Parameters.Add(new SqlParameter("itemID", newItem.ItemID));
            sqlCmd.Parameters.Add(new SqlParameter("title", newItem.Title));
            sqlCmd.Parameters.Add(new SqlParameter("description", newItem.Description));
            sqlCmd.Parameters.Add(new SqlParameter("imageUrl", newItem.ImageUrl));
            sqlCmd.Parameters.Add(new SqlParameter("price", newItem.Price));
            sqlCmd.Parameters.Add(new SqlParameter("originalPrice", newItem.OriginalPrice));
            sqlCmd.Parameters.Add(new SqlParameter("catalogID", newItem.CatalogID));
            sqlCmd.Parameters.Add(new SqlParameter("modifiedDate", DateTime.Now));
            sqlCmd.Parameters.Add(new SqlParameter("attributeAID", newItem.AttributeAID));
            sqlCmd.Parameters.Add(new SqlParameter("attributeBID", newItem.AttributeBID));
            sqlCmd.Parameters.Add(new SqlParameter("attributeCID", newItem.AttributeCID));
            sqlCmd.Parameters.Add(new SqlParameter("active", active));

            sqlCmd.ExecuteNonQuery();

            sqlConn.Close();

        }

        public static List<Item> FindItemsByCatalog(int catalogID)
        {
            List<Item> result = new List<Item>();

            string connectionString = WebConfigurationManager.ConnectionStrings["defaultConnectionString"].ToString();
            SqlConnection sqlConn = new SqlConnection(connectionString);
            sqlConn.Open();

            string cmdString = "SELECT * FROM [Item] WHERE CatalogID = @catalogID";
            SqlCommand sqlCmd = new SqlCommand(cmdString, sqlConn);
            sqlCmd.Parameters.Add(new SqlParameter("catalogID", catalogID));

            SqlDataReader sqlDataReader = sqlCmd.ExecuteReader();
            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    Item newItem = new Item();
                    FillItem(sqlDataReader, newItem);
                    result.Add(newItem);
                }
                sqlDataReader.Close();
            }

            return result;
        }

        public static List<Item> FindItemsByCatalogAndAttributes(int catalogID, int attributeA, int attributeB, int attributeC)
        {
            List<Item> result = new List<Item>();

            string connectionString = WebConfigurationManager.ConnectionStrings["defaultConnectionString"].ToString();
            SqlConnection sqlConn = new SqlConnection(connectionString);
            sqlConn.Open();

            string cmdString = "SELECT * FROM [Item] WHERE CatalogID = @catalogID "; 
            if (attributeA != 0)
            {
                cmdString += "AND AttributeAID = @attributeAID ";
            }
            if (attributeB != 0)
            {
                cmdString += "AND AttributeBID = @attributeBID ";
            }
            if (attributeC != 0)
            {
                cmdString += "AND AttributeCID = @attributeCID ";
            }
            SqlCommand sqlCmd = new SqlCommand(cmdString, sqlConn);
            sqlCmd.Parameters.Add(new SqlParameter("catalogID", catalogID));
            if (attributeA != 0)
            {
                sqlCmd.Parameters.Add(new SqlParameter("attributeAID", attributeA));
            }
            if (attributeB != 0)
            {
                sqlCmd.Parameters.Add(new SqlParameter("attributeBID", attributeB));
            }
            if (attributeC != 0)
            {
                sqlCmd.Parameters.Add(new SqlParameter("attributeCID", attributeC));
            }


            SqlDataReader sqlDataReader = sqlCmd.ExecuteReader();
            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    Item newItem = new Item();
                    FillItem(sqlDataReader, newItem);
                    result.Add(newItem);
                }
                sqlDataReader.Close();
            }

            return result;
        }

        public static Item FindItemByItemID(string itemID)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["defaultConnectionString"].ToString();
            SqlConnection sqlConn = new SqlConnection(connectionString);
            sqlConn.Open();

            string cmdString = "SELECT * FROM [Item] WHERE ItemID = @itemID";
            SqlCommand sqlCmd = new SqlCommand(cmdString, sqlConn);
            sqlCmd.Parameters.Add(new SqlParameter("itemID", itemID));

            SqlDataReader sqlDataReader = sqlCmd.ExecuteReader();
            if (sqlDataReader.HasRows)
            {
                sqlDataReader.Read();
                Item result = new Item();
                FillItem(sqlDataReader, result);
                sqlDataReader.Close();
                return result;
            }
            else
                return null;
        }

        public static List<Item> FindItemsByRecommendList()
        {
            List<Item> result = new List<Item>();

            string connectionString = WebConfigurationManager.ConnectionStrings["defaultConnectionString"].ToString();
            SqlConnection sqlConn = new SqlConnection(connectionString);
            sqlConn.Open();

            string cmdString = "SELECT [Item].[ItemSerialNumber],[Item].[ItemID],[Item].[Title],[Item].[Description],[Item].[ImageUrl],[Item].[Price],[Item].[OriginalPrice],[Item].[CatalogID],[Item].[ModifiedDate],[Item].[AttributeAID],[Item].[AttributeBID],[Item].[AttributeCID]" +
                               "FROM Item INNER JOIN RecommendList ON Item.ItemID = RecommendList.ItemID";
                               //"ORDER BY RecommendList.Oder";
            SqlCommand sqlCmd = new SqlCommand(cmdString, sqlConn);

            SqlDataReader sqlDataReader = sqlCmd.ExecuteReader();
            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    Item newItem = new Item();
                    FillItem(sqlDataReader, newItem);
                    result.Add(newItem);
                }
                sqlDataReader.Close();
            }

            return result;
        }

        public static List<Item> FindItemsByBestsellerList()
        {
            List<Item> result = new List<Item>();

            string connectionString = WebConfigurationManager.ConnectionStrings["defaultConnectionString"].ToString();
            SqlConnection sqlConn = new SqlConnection(connectionString);
            sqlConn.Open();

            string cmdString = "SELECT * FROM [Item] JOIN BestsellerList ON Item.ItemID = BestsellerList.ItemID ORDER BY BestsellerList.Pos";
            SqlCommand sqlCmd = new SqlCommand(cmdString, sqlConn);

            SqlDataReader sqlDataReader = sqlCmd.ExecuteReader();
            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    Item newItem = new Item();
                    FillItem(sqlDataReader, newItem);
                    result.Add(newItem);
                }
                sqlDataReader.Close();
            }

            return result;
        }

        public static void AddItemToBestsellerList(string itemID, int pos)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["defaultConnectionString"].ToString();
            SqlConnection sqlConn = new SqlConnection(connectionString);
            sqlConn.Open();

            string cmdString = "INSERT INTO BestsellerList (ItemID, Pos) VALUES (@itemID, @pos)";
            SqlCommand sqlCmd = new SqlCommand(cmdString, sqlConn);
            sqlCmd.Parameters.Add(new SqlParameter("itemID", itemID));
            sqlCmd.Parameters.Add(new SqlParameter("pos", pos));

            sqlCmd.ExecuteNonQuery();

            sqlConn.Close();
        }

        public static void MoveItemInBestsellerList(string itemID, int newPos)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["defaultConnectionString"].ToString();
            SqlConnection sqlConn = new SqlConnection(connectionString);
            sqlConn.Open();

            string cmdString = "UPDATE BestsellerList SET Pos=@newPos WHERE ItemID=@itemID";
            SqlCommand sqlCmd = new SqlCommand(cmdString, sqlConn);
            sqlCmd.Parameters.Add(new SqlParameter("itemID", itemID));
            sqlCmd.Parameters.Add(new SqlParameter("newPos", newPos));

            sqlCmd.ExecuteNonQuery();

            sqlConn.Close();
        }

        public static void DeleteItemFromBestsellerList(string itemID)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["defaultConnectionString"].ToString();
            SqlConnection sqlConn = new SqlConnection(connectionString);
            sqlConn.Open();

            string cmdString = "DELETE FROM BestsellerList WHERE ItemID=@itemID";
            SqlCommand sqlCmd = new SqlCommand(cmdString, sqlConn);
            sqlCmd.Parameters.Add(new SqlParameter("itemID", itemID));

            sqlCmd.ExecuteNonQuery();

            sqlConn.Close();
        }

        public static List<Item> FindItemsBySalesVolume()
        {
            List<Item> result = new List<Item>();

            string connectionString = WebConfigurationManager.ConnectionStrings["defaultConnectionString"].ToString();
            SqlConnection sqlConn = new SqlConnection(connectionString);
            sqlConn.Open();

            string cmdString = "SELECT * FROM Item, (SELECT OderDetail.ItemID, SUM(Quantity) AS Expr1 FROM OderDetail GROUP BY OderDetail.ItemID) AS T WHERE Item.ItemID = T.ItemId ORDER BY Expr1 DESC";
            SqlCommand sqlCmd = new SqlCommand(cmdString, sqlConn);

            SqlDataReader sqlDataReader = sqlCmd.ExecuteReader();
            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    Item newItem = new Item();
                    FillItem(sqlDataReader, newItem);
                    result.Add(newItem);
                }
                sqlDataReader.Close();
            }

            return result;
        }

        public static List<Item> FindItemsBySalesVolumeAndCatalog(int catalogID)
        {
            List<Item> result = new List<Item>();

            string connectionString = WebConfigurationManager.ConnectionStrings["defaultConnectionString"].ToString();
            SqlConnection sqlConn = new SqlConnection(connectionString);
            sqlConn.Open();

            string cmdString = "SELECT * FROM Item, (SELECT OderDetail.ItemID, SUM(Quantity) AS Expr1 FROM OderDetail GROUP BY OderDetail.ItemID) AS T WHERE Item.ItemID = T.ItemId AND Item.CatalogID = @catalogID ORDER BY Expr1 DESC";
            SqlCommand sqlCmd = new SqlCommand(cmdString, sqlConn);
            sqlCmd.Parameters.AddWithValue("catalogID", catalogID);

            SqlDataReader sqlDataReader = sqlCmd.ExecuteReader();
            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    Item newItem = new Item();
                    FillItem(sqlDataReader, newItem);
                    result.Add(newItem);
                }
                sqlDataReader.Close();
            }

            return result;
        }

        public static List<Item> SearchItems(string keyword)
        {
            List<Item> result = new List<Item>();

            string connectionString = WebConfigurationManager.ConnectionStrings["defaultConnectionString"].ToString();
            SqlConnection sqlConn = new SqlConnection(connectionString);
            sqlConn.Open();

            string cmdString = "SELECT * FROM Item WHERE Title LIKE @keyword";
            SqlCommand sqlCmd = new SqlCommand(cmdString, sqlConn);
            string keywordStr = "%" + keyword + "%";
            sqlCmd.Parameters.AddWithValue("keyword", keywordStr);

            SqlDataReader sqlDataReader = sqlCmd.ExecuteReader();
            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    Item newItem = new Item();
                    FillItem(sqlDataReader, newItem);
                    result.Add(newItem);
                }
                sqlDataReader.Close();
            }

            return result;
        }

        static void FillItem(SqlDataReader sqlDataReader, Item newItem)
        {
            newItem.ItemSerialNumber = (int)sqlDataReader["ItemSerialNumber"];
            newItem.ItemID = (string)sqlDataReader["ItemID"];
            newItem.Title = (string)sqlDataReader["Title"];
            newItem.Description = (string)sqlDataReader["Description"];
            newItem.ImageUrl = (string)sqlDataReader["ImageUrl"];
            newItem.Price = (decimal)sqlDataReader["Price"];
            newItem.OriginalPrice = (decimal)sqlDataReader["OriginalPrice"];
            newItem.CatalogID = (int)sqlDataReader["CatalogID"];
            newItem.ModifiedDate = (DateTime)sqlDataReader["ModifiedDate"];
            newItem.AttributeAID = (int)sqlDataReader["AttributeAID"];
            newItem.AttributeBID = (int)sqlDataReader["AttributeBID"];
            newItem.AttributeCID = (int)sqlDataReader["AttributeCID"];
        }
    }
}
