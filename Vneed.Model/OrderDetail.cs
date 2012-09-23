using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vneed.Model
{
    public class OrderDetail
    {
        public int OrderDetailID;
        public string OrderID;
        public string ItemID;
        public string Title;
        public decimal Price;
        public int Quantity;
        public decimal TotalPrice;
        public string ImageUrl;
    }
}
