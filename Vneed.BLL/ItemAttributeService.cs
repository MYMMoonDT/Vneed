using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vneed.Model;
using Vneed.DAL.Repository;

namespace Vneed.BLL
{
    public class ItemAttributeService
    {
        public static void AddItemAttribute(ItemAttribute newItemAttribute)
        {
            ItemAttributeRepository.AddItemAttribute(newItemAttribute);
        }

        public static List<ItemAttribute> FindItemAttributesByCatalogAndLevel(int CatalogID, int Level)
        {
            return ItemAttributeRepository.FindItemAttributesByCatalogAndLevel(CatalogID, Level);
        }
    }
}
