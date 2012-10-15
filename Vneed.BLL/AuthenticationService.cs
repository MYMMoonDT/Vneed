using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Web;
using Vneed.Model;
using Vneed.DAL.Repository;

namespace Vneed.BLL
{
    public class AuthenticationService
    {
        public static void Login(string Username)
        {
            //对用户名进行哈希
            byte[] clearTextBytes = Encoding.UTF8.GetBytes(Username);
            //TODO:优化salt，例如使用machinekey等其他源
            byte[] saltBytes = GetSaltBytes();
            byte[] clearTextWithSaltBytes = new byte[clearTextBytes.Length + saltBytes.Length];
            for (int i = 0; i < clearTextBytes.Length; i++)
                clearTextWithSaltBytes[i] = clearTextBytes[i];
            for (int i = 0; i < saltBytes.Length; i++)
                clearTextWithSaltBytes[clearTextBytes.Length + i] = saltBytes[i];
            HashAlgorithm hash = new SHA256Managed();
            byte[] hashBytes = hash.ComputeHash(clearTextWithSaltBytes);
            //存储进cookie
            HttpContext.Current.Response.Cookies["Username"].Value = Username;
            HttpContext.Current.Response.Cookies["Ticket"].Value = Convert.ToBase64String(hashBytes);
        }

        public static void Logout()
        {
            HttpContext.Current.Response.Cookies["Username"].Expires = DateTime.Now.AddDays(-1);
            HttpContext.Current.Response.Cookies["Ticket"].Expires = DateTime.Now.AddDays(-1);
        }

        public static User GetUser()
        {
            return UserService.GetUserByUsername(GetUsername());
        }

        public static string GetUsername()
        {
            if (HttpContext.Current.Request.Cookies["Username"] == null)
                return null;
            byte[] clearTextBytes = Encoding.UTF8.GetBytes((string)HttpContext.Current.Request.Cookies["Username"].Value);
            byte[] saltBytes = GetSaltBytes();
            byte[] clearTextWithSaltBytes = new byte[clearTextBytes.Length + saltBytes.Length];
            for (int i = 0; i < clearTextBytes.Length; i++)
                clearTextWithSaltBytes[i] = clearTextBytes[i];
            for (int i = 0; i < saltBytes.Length; i++)
                clearTextWithSaltBytes[clearTextBytes.Length + i] = saltBytes[i];
            HashAlgorithm hash = new SHA256Managed();
            byte[] hashBytes = hash.ComputeHash(clearTextWithSaltBytes);
            byte[] storedHashBytes = Convert.FromBase64String((string)HttpContext.Current.Request.Cookies["Ticket"].Value);
            if (hashBytes.Length != storedHashBytes.Length)
                return null;
            for (int i = 0; i < hashBytes.Length; i++)
            {
                if (hashBytes[i] != storedHashBytes[i])
                    return null;
            }
            return (string)HttpContext.Current.Request.Cookies["Username"].Value;
        }

        public static bool IsAdmin(string username)
        {
            return UserRepository.IsAdmin(username);
        }

        static byte[] GetSaltBytes()
        {
            return Encoding.UTF8.GetBytes("vneed.org");
        }
    }
}
