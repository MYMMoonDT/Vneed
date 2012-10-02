using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vneed.UI.Web.Page.Business
{
    public partial class search : System.Web.UI.Page
    {
        private string searchContent;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.searchContent = this.Request.QueryString["search"];
            this.SearchContentLabel.Text = "找到的含有" + "“" + this.searchContent + "”" + "的商品";
        }
    }
}