using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vneed.UI.Web.WebUserControl.V2
{
    public partial class OrderProcessStepControl : System.Web.UI.UserControl
    {
        private int stepNum;
        public int StepNum
        {
            set { this.stepNum = value; }
            get { return this.stepNum; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            switch (this.stepNum)
            {
                case 1:
                    {
                        this.orderProcessStep1Panel.CssClass = "orderProcessStepDiv";
                        this.orderProcessStep1Label.CssClass = "orderProcessStepText";
                        this.orderProcessStep1Label.Text = "1";

                        this.orderProcessStep2Label.CssClass = "orderProcessNormalText";
                        this.orderProcessStep2Label.Text = "2";

                        this.orderProcessStep3Label.CssClass = "orderProcessNormalText";
                        this.orderProcessStep3Label.Text = "3";
                        break;
                    }
                case 2:
                    {
                        this.orderProcessStep1Panel.CssClass = "orderProcessStepCompletedDiv";
                        this.orderProcessStep1Label.Text = "";

                        this.orderProcessStep1to2Panel.CssClass = "orderProcessStepBackDiv";

                        this.orderProcessStep2Panel.CssClass = "orderProcessStepDiv";
                        this.orderProcessStep2Label.CssClass = "orderProcessStepText";
                        this.orderProcessStep2Label.Text = "2";

                        this.orderProcessStep3Label.CssClass = "orderProcessNormalText";
                        this.orderProcessStep3Label.Text = "3";
                        break;
                    }
                case 3:
                    {
                        this.orderProcessStep1Panel.CssClass = "orderProcessStepCompletedDiv";
                        this.orderProcessStep1Label.Text = "";

                        this.orderProcessStep1to2Panel.CssClass = "orderProcessStepBackDiv";

                        this.orderProcessStep2Panel.CssClass = "orderProcessStepCompletedDiv";
                        this.orderProcessStep2Label.Text = "";

                        this.orderProcessStep2to3Panel.CssClass = "orderProcessStepBackDiv";

                        this.orderProcessStep3Panel.CssClass = "orderProcessStepDiv";
                        this.orderProcessStep3Label.CssClass = "orderProcessStepText";
                        this.orderProcessStep3Label.Text = "3";
                        break;
                    }
            }
        }
    }
}