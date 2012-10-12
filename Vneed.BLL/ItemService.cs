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

        public static void ModifyItem(Item newItem)
        {
            ItemRepository.ModifyItem(newItem, 1);
        }

        public static void DeleteItem(string ItemID)
        {
            Item item = ItemService.GetItemByItemID(ItemID);
            ItemRepository.ModifyItem(item, 0);
        }

        public static Item GetItemByItemID(string itemID)
        {
            return ItemRepository.FindItemByItemID(itemID);
        }

        public static List<Item> SearchItems(string keyword)
        {
            return ItemRepository.SearchItems(keyword);
        }

        public static List<Item> GetRecommendedItems()
        {
            return ItemRepository.FindItemsByRecommendList();
        }

        public static List<Item> GetBestsellers()
        {
            return ItemRepository.FindItemsByBestsellerList();
        }

        public static List<Item> GetBestSellersByCatalog(int catalogID)
        {
            return ItemRepository.FindItemsBySalesVolumeAndCatalog(catalogID);
        }

        public static List<Item> GetItemsByCatalogAndAttributes(int catalogID, int attributeA, int attributeB, int attributeC)
        {
            return ItemRepository.FindItemsByCatalogAndAttributes(catalogID, attributeA, attributeB, attributeC);
        }

        public static void AddItemToBestsellerList(string itemID, int pos)
        {
            ItemRepository.AddItemToBestsellerList(itemID, pos);
        }

        public static void MoveItemInBestsellerList(string itemID, int newPos)
        {
            ItemRepository.MoveItemInBestsellerList(itemID, newPos);
        }

        public static void DeleteItemFromBestsellerList(string itemID)
        {
            ItemRepository.DeleteItemFromBestsellerList(itemID);
        }
    }
}
