using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Vneed.Model;
using System.Web.Configuration;

namespace Vneed.DAL.Repository
{
    public class CoverFlowRepository
    {
        public static void Add(CoverFlowItem newCoverFlowItem)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["defaultConnectionString"].ToString();
            SqlConnection sqlConn = new SqlConnection(connectionString);
            sqlConn.Open();

            string cmdString = "INSERT INTO [CoverFlow] (ImageUrl, NavUrl, Pos) VALUES (@imageUrl, @navUrl, @pos)";
            SqlCommand sqlCmd = new SqlCommand(cmdString, sqlConn);
            sqlCmd.Parameters.Add(new SqlParameter("imageUrl", newCoverFlowItem.ImageUrl));
            sqlCmd.Parameters.Add(new SqlParameter("navUrl", newCoverFlowItem.NavUrl));
            sqlCmd.Parameters.Add(new SqlParameter("pos", newCoverFlowItem.Pos));

            sqlCmd.ExecuteNonQuery();

            sqlConn.Close();
        }

        public static void Delete(int pos)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["defaultConnectionString"].ToString();
            SqlConnection sqlConn = new SqlConnection(connectionString);
            sqlConn.Open();

            string cmdString = "DELETE FROM [CoverFlow] WHERE Pos = @pos";
            SqlCommand sqlCmd = new SqlCommand(cmdString, sqlConn);
            sqlCmd.Parameters.Add(new SqlParameter("pos", pos));

            sqlCmd.ExecuteNonQuery();

            sqlConn.Close();
        }

        public static int UpsideNeighbour(int pos)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["defaultConnectionString"].ToString();
            SqlConnection sqlConn = new SqlConnection(connectionString);
            sqlConn.Open();

            string cmdString = "SELECT Pos FROM [CoverFlow] WHERE Pos < @pos ORDER BY Pos DESC";
            SqlCommand sqlCmd = new SqlCommand(cmdString, sqlConn);
            sqlCmd.Parameters.Add(new SqlParameter("pos", pos));

            int neighbour = -1;
            SqlDataReader sqlDataReader = sqlCmd.ExecuteReader();
            if (sqlDataReader.HasRows)
            {
                sqlDataReader.Read();
                neighbour = (int)sqlDataReader["Pos"];
            }
            sqlDataReader.Close();

            return neighbour;
        }

        public static int DownsideNeighbour(int pos)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["defaultConnectionString"].ToString();
            SqlConnection sqlConn = new SqlConnection(connectionString);
            sqlConn.Open();

            string cmdString = "SELECT Pos FROM [CoverFlow] WHERE Pos > @pos ORDER BY Pos ASC";
            SqlCommand sqlCmd = new SqlCommand(cmdString, sqlConn);
            sqlCmd.Parameters.Add(new SqlParameter("pos", pos));

            int neighbour = -1;
            SqlDataReader sqlDataReader = sqlCmd.ExecuteReader();
            if (sqlDataReader.HasRows)
            {
                sqlDataReader.Read();
                neighbour = (int)sqlDataReader["Pos"];
            }
            sqlDataReader.Close();

            return neighbour;
        }

        public static void SwapPos(int posA, int posB)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["defaultConnectionString"].ToString();
            SqlConnection sqlConn = new SqlConnection(connectionString);
            sqlConn.Open();

            string cmdString = "UPDATE [CoverFlow] SET Pos = @newPos WHERE Pos = @pos";
            SqlCommand sqlCmd = new SqlCommand(cmdString, sqlConn);
            sqlCmd.Parameters.Add(new SqlParameter("newPos", -1));
            sqlCmd.Parameters.Add(new SqlParameter("pos", posA));
            sqlCmd.ExecuteNonQuery();

            cmdString = "UPDATE [CoverFlow] SET Pos = @newPos WHERE Pos = @pos";
            sqlCmd = new SqlCommand(cmdString, sqlConn);
            sqlCmd.Parameters.Add(new SqlParameter("newPos", posA));
            sqlCmd.Parameters.Add(new SqlParameter("pos", posB));
            sqlCmd.ExecuteNonQuery();

            cmdString = "UPDATE [CoverFlow] SET Pos = @newPos WHERE Pos = @pos";
            sqlCmd = new SqlCommand(cmdString, sqlConn);
            sqlCmd.Parameters.Add(new SqlParameter("newPos", posB));
            sqlCmd.Parameters.Add(new SqlParameter("pos", -1));
            sqlCmd.ExecuteNonQuery();

            sqlConn.Close();
        }

        public static int AllocateNewPos()
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["defaultConnectionString"].ToString();
            SqlConnection sqlConn = new SqlConnection(connectionString);
            sqlConn.Open();

            string cmdString = "SELECT Pos FROM [CoverFlow] ORDER BY Pos DESC";
            SqlCommand sqlCmd = new SqlCommand(cmdString, sqlConn);

            int max = 0;
            SqlDataReader sqlDataReader = sqlCmd.ExecuteReader();
            if (sqlDataReader.HasRows)
            {
                sqlDataReader.Read();
                max = (int)sqlDataReader["Pos"];
            }
            sqlDataReader.Close();

            return max == Int32.MaxValue ? max : ++max;
        }

        public static List<CoverFlowItem> GetAll()
        {
            List<CoverFlowItem> result = new List<CoverFlowItem>();

            string connectionString = WebConfigurationManager.ConnectionStrings["defaultConnectionString"].ToString();
            SqlConnection sqlConn = new SqlConnection(connectionString);
            sqlConn.Open();

            string cmdString = "SELECT * FROM [CoverFlow] ORDER BY Pos";
            SqlCommand sqlCmd = new SqlCommand(cmdString, sqlConn);

            SqlDataReader sqlDataReader = sqlCmd.ExecuteReader();
            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    CoverFlowItem newCoverFlowItem = new CoverFlowItem();
                    FillCoverFlowItem(sqlDataReader, newCoverFlowItem);
                    result.Add(newCoverFlowItem);
                }
                sqlDataReader.Close();
            }

            return result;
        }

        static void FillCoverFlowItem(SqlDataReader sqlDataReader, CoverFlowItem newCoverFlowItem)
        {
            newCoverFlowItem.ImageUrl = (string)sqlDataReader["ImageUrl"];
            newCoverFlowItem.NavUrl = (string)sqlDataReader["NavUrl"];
            newCoverFlowItem.Pos = (int)sqlDataReader["Pos"];
        }
    }
}
