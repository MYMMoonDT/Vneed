using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vneed.BLL;

namespace Vneed.UI.Web.WebUserControl
{
    public partial class ItemDescriptionBox : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void LoadDescription(string itemID)
        {
            Response.Write(ItemService.GetItemByItemID(itemID).Description);
        }
    }
}