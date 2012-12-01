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
        public string GetItemsByCatalogAndAttributes(int catalogID, int attributeA, int attributeB, int attributeC, int pageNo)
        {
            List<Item> items = ItemRepository.FindItemsByCatalogAndAttributes(catalogID, attributeA, attributeB, attributeC);
            List<Item> pagedItems = new List<Item>();
            int count = 0;
            foreach (Item item in items)
            {
                item.Description = "";
                if (count >= (pageNo - 1) * 12 && count < pageNo * 12)
                    pagedItems.Add(item);
                count++;
            }
            return JSONService.JsonSerializer(pagedItems);
        }

        [WebMethod]
        public string GetPageNumberByCatalogAndAttributes(int catalogID, int attributeA, int attributeB, int attributeC)
        {
            List<Item> items = ItemRepository.FindItemsByCatalogAndAttributes(catalogID, attributeA, attributeB, attributeC);
            int count = 0;
            foreach (Item item in items)
            {
                count++;
            }
            int page = count / 12;
            if (count % 12 != 0)
                page++;
            return JSONService.JsonSerializer(page);
        }

        [WebMethod]
        public string GetItemByItemID(string itemID)
        {
            Item item = ItemRepository.FindItemByItemID(itemID);
            return JSONService.JsonSerializer(item);
        }

        [WebMethod]
        public string RegisterNewUser(string name, string password, string email)
        {
            bool success = UserService.VerifyUsername(name);
            if (!success) return JSONService.JsonSerializer(success);
            Model.User newUser = new Model.User();
            newUser.Email = email;
            newUser.Username = name;
            newUser.Password = password;
            newUser.RoleID = 1;
            UserService.RegisterNewUser(newUser);
            return JSONService.JsonSerializer(success);
        }

        [WebMethod]
        public string Login(string name, string password)
        {
            bool success = UserService.VerifyPassword(name, password);
            return JSONService.JsonSerializer(success);
        }

        [WebMethod]
        public string AddItemToCart(string name, string password, string itemID, int itemCount)
        {
            bool success = UserService.VerifyPassword(name, password);
            if (!success) return JSONService.JsonSerializer(success);

            CartRecord newRecord = new CartRecord();
            newRecord.ItemID = itemID;
            newRecord.Count = itemCount;
            newRecord.UserID = UserService.GetUserByUsername(name).UserID;
            CartService.AddCartRecord(newRecord);
            return JSONService.JsonSerializer(success);
        }

        [WebMethod]
        public string RemoveItemFromCart(string name, string password, string itemID)
        {
            bool success = UserService.VerifyPassword(name, password);
            if (!success) return JSONService.JsonSerializer(success);

            CartRecord newRecord = new CartRecord();
            newRecord.ItemID = itemID;
            newRecord.UserID = UserService.GetUserByUsername(name).UserID;
            CartService.DeleteCartRecord(newRecord);
            return JSONService.JsonSerializer(success);
        }

        [WebMethod]
        public string GetItemsFromCart(string name, string password)
        {
            bool success = UserService.VerifyPassword(name, password);
            if (!success) return JSONService.JsonSerializer(success);

            List<CartRecord> records = CartService.GetCartRecodByUserID(UserService.GetUserByUsername(name).UserID);
            return JSONService.JsonSerializer(records);
        }

        [WebMethod]
        public string SubmitOrder(string username, string password, string school, string name, string email, string contact, string identityNo, int alreadySignedIn)
        {
            bool success = UserService.VerifyPassword(username, password);
            if (!success) return JSONService.JsonSerializer(success);

            Order newOrder = new Order();
            newOrder.UserID = UserService.GetUserByUsername(username).UserID;
            newOrder.Payment = 0;
            newOrder.Delivery = 0;
            newOrder.Name = name;
            newOrder.Email = email;
            newOrder.Contact = contact;
            newOrder.IdentityNo = identityNo;
            newOrder.AlreadySignedIn = alreadySignedIn;
            OrderService.SubmitOrder(newOrder);
            CartService.DeletaCartRecordByUserID(newOrder.UserID);
            return JSONService.JsonSerializer(success);
        }

        [WebMethod]
        public string SearchItems(string keyword)
        {
            List<Item> items = ItemService.SearchItems(keyword);
            List<Item> limitedItems = new List<Item>();

            int count = 0;
            foreach(Item item in items)
            {
                limitedItems.Add(item);
                count++;
                if(count >= 20) break;
            }

            return JSONService.JsonSerializer(limitedItems);
        }

        [WebMethod]
        public string FindOrdersByUser(string name, string password)
        {
            bool success = UserService.VerifyPassword(name, password);
            if (!success) return JSONService.JsonSerializer(success);

            int userID = UserService.GetUserByUsername(name).UserID;
            List<Order> orders = OrderService.FindOrdersByUserID(userID);

            return JSONService.JsonSerializer(orders);
        }

        [WebMethod]
        public string GetOrderPrice(string orderID)
        {
            return JSONService.JsonSerializer(OrderService.GetOrderPrice(orderID));
        }
    }
}