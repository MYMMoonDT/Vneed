using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vneed.Model;

namespace Vneed.UI.Web.Admin
{
    public partial class OrderDetail : System.Web.UI.Page
    {
        void LoadOrder(string orderID)
        {

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string orderID = Request.QueryString["orderID"];
            LoadOrder(orderID);
        }
    }
}