using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vneed.BLL;
using Vneed.Model;

namespace Vneed.UI.Web.Page.V2.Business
{
    public partial class orderDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.OrderProcessStepControl1.StepNum = 2;
            this.CartTableControl1.IsReadyOnly = true;
        }

        protected void orderDetailSubmitButton_Click(object sender, EventArgs e)
        {
            Order newOrder = new Order();
            newOrder.UserID = AuthenticationService.GetUser().UserID;
            if (this.OfflinePayRadioButton.Checked)
            {
                newOrder.Payment = 0;
            }
            else if (this.AlipayRadioButton.Checked)
            {
                newOrder.Payment = 1;
            }
            newOrder.Name = this.NameTextBox.Text;
            newOrder.School = this.SchoolTextBox.Text;
            newOrder.Contact = this.ContactTextBox.Text;
            newOrder.IdentityNo = this.IDNumTextBox.Text;
            newOrder.Email = this.EmailTextBox.Text == "邮箱(选填)" ? "" : this.EmailTextBox.Text;
            newOrder.AlreadySignedIn = this.IsRegistCourseCheckBox.Checked ? 1 : 0;
            OrderService.SubmitOrder(newOrder);
            Response.Redirect("/Page/V2/Help/orderSubmitSuccess.aspx");
        }
    }
}