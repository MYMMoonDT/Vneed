using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vneed.UI.Web.Page.V2.Business
{
    public partial class searchResult : System.Web.UI.Page
    {
        private int SEARCH_CONTENT_LENGTH = 5;

        protected void Page_Load(object sender, EventArgs e)
        {
            String searchContent = this.Request.QueryString["keyword"];
            if (searchContent == null) 
            {
                Response.Redirect("/Page/V2/index.aspx");
            }
            if (searchContent.Length < SEARCH_CONTENT_LENGTH)
            {
                this.searchResultSubTitleLabel.Text = "找到的含有" + "“" + searchContent + "”" + "的商品";
            }
            else
            {
                this.searchResultSubTitleLabel.Text = "找到的含有" + "“" + searchContent.Substring(0, SEARCH_CONTENT_LENGTH) + "..." + "”" + "的商品";
            }
            this.SearchResultControl1.SearchContent = searchContent;
        }
    }
}