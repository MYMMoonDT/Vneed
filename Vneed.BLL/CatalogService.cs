using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vneed.Model;
using Vneed.DAL.Repository;

namespace Vneed.BLL
{
    public class CatalogService
    {
        public static List<Catalog> GetAllFirstLevelCatalogs()
        {
            return CatalogRepository.FindAllFirstLevelCatalogs();
        }

        public static List<Catalog> GetAllChildCatalogs(int catalogID)
        {
            return CatalogRepository.FindAllChildCatalogs(catalogID);
        }

        public static List<Catalog> GetAllSecondLevelCatalogs()
        {
            return CatalogRepository.FindAllSecondLevelCatalogs();
        }
    }
}
