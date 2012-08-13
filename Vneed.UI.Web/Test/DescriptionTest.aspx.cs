using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vneed.UI.Web.Test
{
    public partial class DescriptionTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ItemDescriptionBox1.LoadDescription("c16d4078-f1a3-4195-8d50-abfc3aad58e1");
        }
    }
}