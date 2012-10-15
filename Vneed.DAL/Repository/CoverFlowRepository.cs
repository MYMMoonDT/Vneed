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
        public static List<CoverFlowItem> FindAllCoverFlowItems()
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
