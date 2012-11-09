using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vneed.UI.Web.WebService;
using Vneed.Model;
using Vneed.BLL;

namespace Vneed.UI.Web.Test
{
    public partial class WebServiceTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            VneedWebService vbs = new VneedWebService();
            Label1.Text = vbs.HelloWorld();
            User usr = new User();
            usr.RoleID = 12;
            usr.Password = "1231";
            Label1.Text = vbs.GetAllFirstLevelCatalogs();
        }
    }
}