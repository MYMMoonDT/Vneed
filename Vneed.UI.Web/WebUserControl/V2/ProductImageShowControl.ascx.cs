using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vneed.UI.Web.WebUserControl.V2
{
    public partial class ProductImageShow : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                renderProductImageShow();
            }
        }

        private void renderProductImageShow()
        {
            Panel productImageShowBg = new Panel();
            productImageShowBg.CssClass = "productImageShowBg";
            Panel productImageShowContainer = new Panel();
            productImageShowContainer.CssClass = "productImageShowContainer";
            Panel productImageShowWrapper = new Panel();
            productImageShowWrapper.CssClass = "productImageShowWrapper";
            Panel sliderWrapper = new Panel();
            sliderWrapper.CssClass = "slider-wrapper theme-default";
            Panel slider = new Panel();
            slider.CssClass = "nivoSlider";
            slider.ID = "slider";
            slider.ClientIDMode = System.Web.UI.ClientIDMode.Static;



            sliderWrapper.Controls.Add(slider);
            productImageShowWrapper.Controls.Add(sliderWrapper);
            productImageShowContainer.Controls.Add(productImageShowWrapper);
            productImageShowBg.Controls.Add(productImageShowContainer);
            this.productImageShowPanel.Controls.Add(productImageShowBg);
        }
    }
}