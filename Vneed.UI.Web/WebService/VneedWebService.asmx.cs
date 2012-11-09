using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Vneed.Model;
using Vneed.DAL.Repository;
using Vneed.BLL;

namespace Vneed.UI.Web.WebService
{
    /// <summary>
    /// Summary description for VneedWebService
    /// </summary>
    [WebService(Namespace = "http://www.vneed.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class VneedWebService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public string GetAllFirstLevelCatalogs()
        {
            List<Catalog> catalogs = CatalogRepository.FindAllFirstLevelCatalogs();
            return JSONService.JsonSerializer(catalogs);
        }

        [WebMethod]
        public string GetAllChildCatalogs(int catalogID)
        {
            List<Catalog> catalogs = CatalogRepository.FindAllChildCatalogs(catalogID);
            return JSONService.JsonSerializer(catalogs);
        }

        [WebMethod]
        public string GetItemAttributesByCatalogAndLevel(int catalogID, int level)
        {
            List<ItemAttribute> attributes = ItemAttributeRepository.FindItemAttributesByCatalogAndLevel(catalogID, level);
            return JSONService.JsonSerializer(attributes);
        }

        [WebMethod]
        public string GetItemsByCatalogAndAttributes(int catalogID, int attributeA, int attributeB, int attributeC)
        {
            List<Item> items = ItemRepository.FindItemsByCatalogAndAttributes(catalogID, attributeA, attributeB, attributeC);
            foreach (Item item in items)
            {
                item.Description = "";
            }
            return JSONService.JsonSerializer(items);
        }

        [WebMethod]
        public string GetItemByItemID(string itemID)
        {
            Item item = ItemRepository.FindItemByItemID(itemID);
            return JSONService.JsonSerializer(item);
        }
    }
}
