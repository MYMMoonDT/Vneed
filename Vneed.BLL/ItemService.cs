using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vneed.Model;
using Vneed.DAL.Repository;

namespace Vneed.BLL
{
    public class ItemService
    {
        public static bool AddNewItem(Item newItem)
        {
            ItemRepository.AddItem(newItem);
            return true;
        }

        public static Item GetItemByItemID(string itemID)
        {
            return ItemRepository.FindItemByItemID(itemID);
        }

        public static List<Item> GetRecommendedItems()
        {
            return ItemRepository.FindItemsByRecommendList();
        }

        public static List<Item> GetBestSellers()
        {
            return null;
        }

        public static List<Item> GetBestSellersByCatalog(int catalogID)
        {
            return ItemRepository.FindItemsBySalesVolumeAndCatalog(catalogID);
        }
    }
}
