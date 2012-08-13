using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vneed.Model;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace Vneed.DAL.Repository
{
    public class UserAdditionalInfoRepository
    {
        public static UserAdditionalInfo FindUserAdditionalInfoByUserID(int userID)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["defaultConnectionString"].ToString();
            SqlConnection sqlConn = new SqlConnection(connectionString);
            sqlConn.Open();

            string cmdString = "SELECT * FROM [UserAdditionalInfo] WHERE UserID = @userID";
            SqlCommand sqlCmd = new SqlCommand(cmdString, sqlConn);
            sqlCmd.Parameters.Add(new SqlParameter("userID", userID));

            SqlDataReader sqlDataReader = sqlCmd.ExecuteReader();
            if (sqlDataReader.HasRows)
            {
                sqlDataReader.Read();
                UserAdditionalInfo result = new UserAdditionalInfo();
                FillUserAddtionalInfo(sqlDataReader, result);
                sqlDataReader.Close();
                return result;
            }
            else
                return null;
        }

        static void FillUserAddtionalInfo(SqlDataReader sqlDataReader, UserAdditionalInfo newUserAdditionalInfo)
        {
            newUserAdditionalInfo.UserID = (int)sqlDataReader["UserID"];
            newUserAdditionalInfo.PortraitUrl = (string)sqlDataReader["PortraitUrl"];
        }
    }
}
