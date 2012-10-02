using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vneed.Model
{
    public class Item
    {
        public int ItemSerialNumber { get; set; }
        public string ItemID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public decimal OriginalPrice { get; set; }
        public int CatalogID { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int AttributeAID { get; set; }
        public int AttributeBID { get; set; }
        public int AttributeCID { get; set; }
    }
}
