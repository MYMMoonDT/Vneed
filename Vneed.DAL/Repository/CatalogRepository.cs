using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vneed.Model;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace Vneed.DAL.Repository
{
    public class CatalogRepository
    {
        public static List<Catalog> FindAllFirstLevelCatalogs()
        {
            List<Catalog> result = new List<Catalog>();

            string connectionString = WebConfigurationManager.ConnectionStrings["defaultConnectionString"].ToString();
            SqlConnection sqlConn = new SqlConnection(connectionString);
            sqlConn.Open();

            string cmdString = "SELECT * FROM [Catalog] WHERE ParentCatalogID = 0";
            SqlCommand sqlCmd = new SqlCommand(cmdString, sqlConn);

            SqlDataReader sqlDataReader = sqlCmd.ExecuteReader();
            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    Catalog newCatalog = new Catalog();
                    FillCatalog(sqlDataReader, newCatalog);
                    result.Add(newCatalog);
                }
                sqlDataReader.Close();
            }

            return result;
        }

        public static List<Catalog> FindAllChildCatalogs(int catalogID)
        {
            List<Catalog> result = new List<Catalog>();

            string connectionString = WebConfigurationManager.ConnectionStrings["defaultConnectionString"].ToString();
            SqlConnection sqlConn = new SqlConnection(connectionString);
            sqlConn.Open();

            string cmdString = "SELECT * FROM [Catalog] WHERE ParentCatalogID = @parentCatalogID";
            SqlCommand sqlCmd = new SqlCommand(cmdString, sqlConn);
            sqlCmd.Parameters.Add(new SqlParameter("parentCatalogID", catalogID));

            SqlDataReader sqlDataReader = sqlCmd.ExecuteReader();
            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    Catalog newCatalog = new Catalog();
                    FillCatalog(sqlDataReader, newCatalog);
                    result.Add(newCatalog);
                }
                sqlDataReader.Close();
            }

            return result;
        }

        public static List<Catalog> FindAllSecondLevelCatalogs()
        {
            List<Catalog> result = new List<Catalog>();

            string connectionString = WebConfigurationManager.ConnectionStrings["defaultConnectionString"].ToString();
            SqlConnection sqlConn = new SqlConnection(connectionString);
            sqlConn.Open();

            string cmdString = "SELECT * FROM [Catalog] WHERE ParentCatalogID <> 0";
            SqlCommand sqlCmd = new SqlCommand(cmdString, sqlConn);

            SqlDataReader sqlDataReader = sqlCmd.ExecuteReader();
            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    Catalog newCatalog = new Catalog();
                    FillCatalog(sqlDataReader, newCatalog);
                    result.Add(newCatalog);
                }
                sqlDataReader.Close();
            }

            return result;
        }

        public static void AddNewCatalog(Catalog newCatalog)
        {            
            string connectionString = WebConfigurationManager.ConnectionStrings["defaultConnectionString"].ToString();
            SqlConnection sqlConn = new SqlConnection(connectionString);
            sqlConn.Open();

            string cmdString = "INSERT INTO Catalog (ParentCatalogID, Name) VALUES (@parentCatalogID, @name)";
            SqlCommand sqlCmd = new SqlCommand(cmdString, sqlConn);
            sqlCmd.Parameters.Add(new SqlParameter("parentCatalogID", newCatalog.ParentCatalogID));
            sqlCmd.Parameters.Add(new SqlParameter("name", newCatalog.Name));
            sqlCmd.ExecuteNonQuery();

            sqlConn.Close();
        }

        public static void ModifyCatalog(Catalog newCatalog)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["defaultConnectionString"].ToString();
            SqlConnection sqlConn = new SqlConnection(connectionString);
            sqlConn.Open();

            string cmdString = "UPDATE Catalog SET Name=@name WHERE CatalogID=@catalogID";
            SqlCommand sqlCmd = new SqlCommand(cmdString, sqlConn);
            sqlCmd.Parameters.Add(new SqlParameter("catalogID", newCatalog.CatalogID));
            sqlCmd.Parameters.Add(new SqlParameter("name", newCatalog.Name));
            sqlCmd.ExecuteNonQuery();

            sqlConn.Close();
        }

        public static void DeleteCatalog(Catalog oldCatalog)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["defaultConnectionString"].ToString();
            SqlConnection sqlConn = new SqlConnection(connectionString);
            sqlConn.Open();

            string cmdString = "DELETE FROM Catalog WHERE CatalogID=@catalogID";
            SqlCommand sqlCmd = new SqlCommand(cmdString, sqlConn);
            sqlCmd.Parameters.Add(new SqlParameter("catalogID", oldCatalog.CatalogID));
            sqlCmd.ExecuteNonQuery();

            sqlConn.Close();
        }

        static void FillCatalog(SqlDataReader sqlDataReader, Catalog newCatalog)
        {
            newCatalog.CatalogID = (int)sqlDataReader["CatalogID"];
            newCatalog.ParentCatalogID = (int)sqlDataReader["ParentCatalogID"];
            newCatalog.Name = (string)sqlDataReader["Name"];
        }
    }
}
