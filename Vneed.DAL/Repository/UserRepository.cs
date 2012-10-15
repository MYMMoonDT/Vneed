using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vneed.Model;
using System.Web.Configuration;
using System.Data.SqlClient;

namespace Vneed.DAL.Repository
{
    public class UserRepository
    {
        public static void AddUser(User newUser)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["defaultConnectionString"].ToString();
            SqlConnection sqlConn = new SqlConnection(connectionString);
            sqlConn.Open();

            string cmdString = "INSERT INTO [User] (Username, Password, Salt, Email, RoleID) VALUES (@username, @password, @salt, @email, @roleID)";
            SqlCommand sqlCmd = new SqlCommand(cmdString, sqlConn);
            sqlCmd.Parameters.Add(new SqlParameter("username", newUser.Username));
            sqlCmd.Parameters.Add(new SqlParameter("password", newUser.Password));
            sqlCmd.Parameters.Add(new SqlParameter("salt", newUser.Salt));
            sqlCmd.Parameters.Add(new SqlParameter("email", newUser.Email));
            sqlCmd.Parameters.Add(new SqlParameter("roleID", newUser.RoleID));

            sqlCmd.ExecuteNonQuery();

            sqlConn.Close();
        }

        public static User FindUserByUserID(int id)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["defaultConnectionString"].ToString();
            SqlConnection sqlConn = new SqlConnection(connectionString);
            sqlConn.Open();

            string cmdString = "SELECT * FROM [User] WHERE UserID = @userID";
            SqlCommand sqlCmd = new SqlCommand(cmdString, sqlConn);
            sqlCmd.Parameters.Add(new SqlParameter("userID", id));

            SqlDataReader sqlDataReader = sqlCmd.ExecuteReader();
            if (sqlDataReader.HasRows)
            {
                sqlDataReader.Read();
                User result = new User();
                FillUser(sqlDataReader, result);
                sqlDataReader.Close();
                return result;
            }
            else
                return null;
        }

        public static User FindUserByUsername(string username)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["defaultConnectionString"].ToString();
            SqlConnection sqlConn = new SqlConnection(connectionString);
            sqlConn.Open();

            string cmdString = "SELECT * FROM [User] WHERE Username = @username";
            SqlCommand sqlCmd = new SqlCommand(cmdString, sqlConn);
            sqlCmd.Parameters.Add(new SqlParameter("username", username));

            SqlDataReader sqlDataReader = sqlCmd.ExecuteReader();
            if (sqlDataReader.HasRows)
            {
                sqlDataReader.Read();
                User result = new User();
                FillUser(sqlDataReader, result);
                sqlDataReader.Close();
                return result;
            }
            else
                return null;
        }

        public static User FindUserByEmail(string email)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["defaultConnectionString"].ToString();
            SqlConnection sqlConn = new SqlConnection(connectionString);
            sqlConn.Open();

            string cmdString = "SELECT * FROM [User] WHERE Email = @email";
            SqlCommand sqlCmd = new SqlCommand(cmdString, sqlConn);
            sqlCmd.Parameters.Add(new SqlParameter("email", email));

            SqlDataReader sqlDataReader = sqlCmd.ExecuteReader();
            if (sqlDataReader.HasRows)
            {
                sqlDataReader.Read();
                User result = new User();
                FillUser(sqlDataReader, result);
                sqlDataReader.Close();
                return result;
            }
            else
                return null;
        }

        public static bool IsAdmin(string username)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["defaultConnectionString"].ToString();
            SqlConnection sqlConn = new SqlConnection(connectionString);
            sqlConn.Open();

            string cmdString = "SELECT * FROM [Admin] WHERE Username = @username";
            SqlCommand sqlCmd = new SqlCommand(cmdString, sqlConn);
            sqlCmd.Parameters.Add(new SqlParameter("username", username));

            SqlDataReader sqlDataReader = sqlCmd.ExecuteReader();
            if (sqlDataReader.HasRows)
            {
                sqlDataReader.Close();
                return true;
            }
            else
            {
                sqlDataReader.Close();
                return false;
            }
        }

        static void FillUser(SqlDataReader sqlDataReader, User newUser)
        {
            newUser.UserID = (int)sqlDataReader["UserID"];
            newUser.Username = (string)sqlDataReader["Username"];
            newUser.Password = (string)sqlDataReader["Password"];
            newUser.Salt = (string)sqlDataReader["Salt"];
            newUser.Email = (string)sqlDataReader["Email"];
            newUser.RoleID = (int)sqlDataReader["RoleID"];
            newUser.AdditionalInfo = UserAdditionalInfoRepository.FindUserAdditionalInfoByUserID(newUser.UserID);
        }
    }
}
