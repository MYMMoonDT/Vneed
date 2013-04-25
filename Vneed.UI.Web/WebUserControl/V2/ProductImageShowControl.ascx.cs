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
    public partial class ProductImageShow : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                renderProductImageShow();
            }
        }

        private HyperLink renderProductImage(CoverFlowItem coverFlowItem)
        {
            HyperLink imgLink = new HyperLink();
            imgLink.NavigateUrl = coverFlowItem.NavUrl;
            imgLink.Target = "_blank";
            Image img = new Image();
            img.ImageUrl = coverFlowItem.ImageUrl;
            imgLink.Controls.Add(img);
            return imgLink;
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
            List<CoverFlowItem> coverFlowList = CoverFlowService.GetAll();
            foreach (CoverFlowItem item in coverFlowList)
            {
                slider.Controls.Add(renderProductImage(item));
            }
            sliderWrapper.Controls.Add(slider);
            productImageShowWrapper.Controls.Add(sliderWrapper);
            productImageShowContainer.Controls.Add(productImageShowWrapper);
            productImageShowBg.Controls.Add(productImageShowContainer);
            Panel productImageShowDivider = new Panel();
            productImageShowDivider.CssClass = "productImageShowDivider";
            productImageShowPanel.Controls.Add(productImageShowBg);
            productImageShowPanel.Controls.Add(productImageShowDivider);
        }
    }
}