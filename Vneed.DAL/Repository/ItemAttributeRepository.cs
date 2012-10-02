using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Vneed.Model;
using System.Web.Configuration;

namespace Vneed.DAL.Repository
{
    public class ItemAttributeRepository
    {
        public static void AddItemAttribute(ItemAttribute newItemAttribute)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["defaultConnectionString"].ToString();
            SqlConnection sqlConn = new SqlConnection(connectionString);
            sqlConn.Open();

            string cmdString = "INSERT INTO [ItemAttribute] (CatalogID, ItemAttributeLevel, Name) VALUES (@catalogID, @itemAttributeLevel, @name)";
            SqlCommand sqlCmd = new SqlCommand(cmdString, sqlConn);
            sqlCmd.Parameters.Add(new SqlParameter("catalogID", newItemAttribute.CatalogID));
            sqlCmd.Parameters.Add(new SqlParameter("itemAttributeLevel", newItemAttribute.ItemAttributeLevel));
            sqlCmd.Parameters.Add(new SqlParameter("name", newItemAttribute.Name));

            sqlCmd.ExecuteNonQuery();

            sqlConn.Close();
        }

        public static List<ItemAttribute> FindItemAttributesByCatalogAndLevel(int CatalogID, int Level)
        {
            List<ItemAttribute> result = new List<ItemAttribute>();

            string connectionString = WebConfigurationManager.ConnectionStrings["defaultConnectionString"].ToString();
            SqlConnection sqlConn = new SqlConnection(connectionString);
            sqlConn.Open();

            string cmdString = "SELECT * FROM [ItemAttribute] WHERE CatalogID=@catalogID AND ItemAttributeLevel = @itemAttributeLevel";
            SqlCommand sqlCmd = new SqlCommand(cmdString, sqlConn);
            sqlCmd.Parameters.Add(new SqlParameter("catalogID", CatalogID));
            sqlCmd.Parameters.Add(new SqlParameter("itemAttributeLevel", Level));

            SqlDataReader sqlDataReader = sqlCmd.ExecuteReader();
            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    ItemAttribute newItemAttribute = new ItemAttribute();
                    FillItemAttribute(sqlDataReader, newItemAttribute);
                    result.Add(newItemAttribute);
                }
                sqlDataReader.Close();
            }

            return result;
        }

        static void FillItemAttribute(SqlDataReader sqlDataReader, ItemAttribute newItemAttribute)
        {
            newItemAttribute.CatalogID = (int)sqlDataReader["CatalogID"];
            newItemAttribute.ItemAttributeLevel = (int)sqlDataReader["ItemAttributeLevel"];
            newItemAttribute.ItemAttributeID = (int)sqlDataReader["ItemAttributeID"];
            newItemAttribute.Name = (string)sqlDataReader["Name"];
        }
    }
}
