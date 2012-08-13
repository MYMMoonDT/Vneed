using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vneed.DAL.Repository;
using Vneed.Model;
using System.Security.Cryptography;

namespace Vneed.BLL
{
    public class UserService
    {
        public static User GetUserByUsername(string username)
        {
            return UserRepository.FindUserByUsername(username);
        }

        public static User GetUserByUserID(int userID)
        {
            return UserRepository.FindUserByUserID(userID);
        }

        public static bool VerifyUsername(string Username)
        {
            if (UserRepository.FindUserByUsername(Username) == null)
                return true;
            else
                return false;
        }

        public static bool VerifyEmail(string email)
        {
            if (UserRepository.FindUserByEmail(email) == null)
                return true;
            else
                return false;
        }

        public static void RegisterNewUser(User newUser)
        {
            //对密码进行加密
            byte[] saltBytes = new byte[32];
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetNonZeroBytes(saltBytes);
            byte[] clearTextBytes = Encoding.UTF8.GetBytes(newUser.Password);
            byte[] clearTextWithSaltBytes = new byte[clearTextBytes.Length + saltBytes.Length];
            for (int i = 0; i < clearTextBytes.Length; i++)
                clearTextWithSaltBytes[i] = clearTextBytes[i];
            for (int i = 0; i < saltBytes.Length; i++)
                clearTextWithSaltBytes[clearTextBytes.Length + i] = saltBytes[i];
            HashAlgorithm hash = new SHA256Managed();
            byte[] hashBytes = hash.ComputeHash(clearTextWithSaltBytes);
            newUser.Password = Convert.ToBase64String(hashBytes);
            newUser.Salt = Convert.ToBase64String(saltBytes);

            UserRepository.AddUser(newUser);
        }

        public static bool VerifyPassword(string Username, string password)
        {
            User user = UserRepository.FindUserByUsername(Username);
            if (user == null)
                return false;
            byte[] saltBytes = Convert.FromBase64String(user.Salt);
            byte[] clearTextBytes = Encoding.UTF8.GetBytes(password);
            byte[] clearTextWithSaltBytes = new byte[clearTextBytes.Length + saltBytes.Length];
            for (int i = 0; i < clearTextBytes.Length; i++)
                clearTextWithSaltBytes[i] = clearTextBytes[i];
            for (int i = 0; i < saltBytes.Length; i++)
                clearTextWithSaltBytes[clearTextBytes.Length + i] = saltBytes[i];
            HashAlgorithm hash = new SHA256Managed();
            byte[] hashBytes = hash.ComputeHash(clearTextWithSaltBytes);
            byte[] storedHashBytes = Convert.FromBase64String(user.Password);
            if (hashBytes.Length != storedHashBytes.Length)
                return false;
            for (int i = 0; i < hashBytes.Length; i++)
            {
                if (hashBytes[i] != storedHashBytes[i])
                    return false;
            }
            return true;
        }
    }
}
