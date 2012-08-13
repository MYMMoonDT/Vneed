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

        static void FillCatalog(SqlDataReader sqlDataReader, Catalog newCatalog)
        {
            newCatalog.CatalogID = (int)sqlDataReader["CatalogID"];
            newCatalog.ParentCatalogID = (int)sqlDataReader["ParentCatalogID"];
            newCatalog.Name = (string)sqlDataReader["Name"];
        }
    }
}
