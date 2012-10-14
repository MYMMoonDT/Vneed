using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vneed.Model;
using Vneed.BLL;

namespace Vneed.UI.Web.WebUserControl.V2
{
    public partial class CatalogFilterControl : System.Web.UI.UserControl
    {
        private int catalogID;

        public int CatalogID
        {
            get { return this.catalogID; }
            set { this.catalogID = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            renderDropDownListAttribute();
        }

        private void renderDropDownListAttribute()
        {
            DropDownListAttributeA.Items.Add(new ListItem("全部", "0"));
            DropDownListAttributeB.Items.Add(new ListItem("全部", "0"));
            DropDownListAttributeC.Items.Add(new ListItem("全部", "0"));
            for (int level = 1; level <= 3; level++)
            {
                List<ItemAttribute> allAttr = ItemAttributeService.FindItemAttributesByCatalogAndLevel(catalogID, level);
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
    }
}