using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vneed.Model;
using Vneed.BLL;

namespace Vneed.UI.Web.WebUserControl
{
    public partial class FilterList : System.Web.UI.UserControl
    {
        void LoadAttr()
        {
            int catalog = Int32.Parse(this.Request.QueryString["catalog"]);
            DropDownListAttributeA.Items.Add(new ListItem("全部", "0"));
            DropDownListAttributeB.Items.Add(new ListItem("全部", "0"));
            DropDownListAttributeC.Items.Add(new ListItem("全部", "0"));
            for (int level = 1; level <= 3; level++)
            {
                List<ItemAttribute> allAttr = ItemAttributeService.FindItemAttributesByCatalogAndLevel(catalog, level);
                foreach (ItemAttribute currentAttr in allAttr)
                {
                    if (level == 1)
                    {
                        DropDownListAttributeA.Items.Add(new ListItem(currentAttr.Name, currentAttr.ItemAttributeID.ToString()));
                    }
                    if (level == 2)
                    {
                        DropDownListAttributeB.Items.Add(new ListItem(currentAttr.Name, currentAttr.ItemAttributeID.ToString()));
                    }
                    if (level == 3)
                    {
                        DropDownListAttributeC.Items.Add(new ListItem(currentAttr.Name, currentAttr.ItemAttributeID.ToString()));
                    }
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadAttr();
            }
        }
    }
}