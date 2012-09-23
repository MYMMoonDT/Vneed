using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vneed.DAL.Repository;
using Vneed.Model;

namespace Vneed.BLL
{
    public class CartService
    {
        public static bool AddCartRecord(CartRecord newCartRecord)
        {
            CartRecordRepository.AddCartRecord(newCartRecord);
            return true;
        }

        public static bool DeleteCartRecord(CartRecord newCartRecord)
        {
            CartRecordRepository.DeleteCartRecord(newCartRecord);
            return true;
        }

        public static List<CartRecord> GetCartRecodByUserID(int UserID)
        {
            return CartRecordRepository.FindCartRecordByUserID(UserID);
        }

        public static void DeletaCartRecordByUserID(int UserID)
        {
            CartRecordRepository.DeletaCartRecordByUserID(UserID);
        }
    }
}
