using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vneed.Model;
using Vneed.DAL;

namespace Vneed.BLL
{
    public class OrderService
    {
        //调用这个函数时，newOrder里填好5个基本信息，UserID，以及Payment即可。0为线下付款，1为支付宝
        public static void SubmitOrder(Order newOrder)
        {
            newOrder.SetStatusToNotPayed();
            string orderID = OrderRepository.AddOrder(newOrder);
            List<CartRecord> cartrecords = CartService.GetCartRecodByUserID(newOrder.UserID);
            foreach (CartRecord cr in cartrecords)
            {
                Item currentItem = ItemService.GetItemByItemID(cr.ItemID);
                OrderDetail od = new OrderDetail();
                od.OrderID = orderID;
                od.ItemID = cr.ItemID;
                od.Title = currentItem.Title;
                od.Price = currentItem.Price;
                od.Quantity = cr.Count;
                od.TotalPrice = od.Price * od.Quantity;
                od.ImageUrl = currentItem.ImageUrl;
                OrderRepository.AddOrderDetail(od);
            }
            CartService.DeletaCartRecordByUserID(newOrder.UserID);
        }

        public static List<Order> FindOrdersByUserID(int UserID)
        {
            return OrderRepository.FindOrdersByUserID(UserID);
        }

        public static List<Order> FindOrdersByStatusAndDate(int status, int day)
        {
            return OrderRepository.FindOrdersByStatusAndDate(status, day);
        }

        public static Decimal GetOrderPrice(string OrderID)
        {
            return OrderRepository.GetOrderPrice(OrderID);
        }
    }
}
