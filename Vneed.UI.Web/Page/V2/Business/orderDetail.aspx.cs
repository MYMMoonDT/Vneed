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
                newOrder.ExtraInfo = "";
            }
            else if (this.AlipayRadioButton.Checked)
            {
                newOrder.Payment = 1;
                newOrder.ExtraInfo = "支付宝帐号=" + AlipayAccountTextBox.Text + ",户主名称=" + AlipayAccountOwnerNameTextBox.Text;
            }
            else if (this.PhonePayRadioButton.Checked)
            {
                newOrder.Payment = 2;
                newOrder.ExtraInfo = "手机号码=" + PhoneNoTextBox.Text;
            }
            else if (this.NetworkedGameRadioButton.Checked)
            {
                newOrder.Payment = 3;
                newOrder.ExtraInfo = "网游名称=" + GameNameTextBox.Text + ",网游帐号=" + GameAccountTextBox.Text + ",其他信息=" + GameOtherInfoTextBox.Text;
            }
            else if (this.BankcardRadioButton.Checked)
            {
                newOrder.Payment = 4;
                newOrder.ExtraInfo = "银行卡帐号=" + BankcardAccountTextBox.Text + ",户主名称=" + BankcardAccountOwnerNameTextBox.Text;
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

        protected void IsRegistCourseCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (IsRegistCourseCheckBox.Checked)
            {
                orderPaymentWayPanel.Visible = false;
                OfflinePayRadioButton.Checked = false;
                orderReturnWayPanel.Visible = true;
            }
            else
            {
                orderPaymentWayPanel.Visible = true;
                OfflinePayRadioButton.Checked = true;
                orderReturnWayPanel.Visible = false;
                PhonePayRadioButton.Checked = false;
            }
        }

        protected void PhonePayRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            PhonePayPanel.Visible = true;
            NetworkedGamePayPanel.Visible = false;
            AlipayPanel.Visible = false;
            BankcardPayPanel.Visible = false;
        }

        protected void NetworkedGameRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            PhonePayPanel.Visible = false;
            NetworkedGamePayPanel.Visible = true;
            AlipayPanel.Visible = false;
            BankcardPayPanel.Visible = false;
        }

        protected void AlipayRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            PhonePayPanel.Visible = false;
            NetworkedGamePayPanel.Visible = false;
            AlipayPanel.Visible = true;
            BankcardPayPanel.Visible = false;
        }

        protected void BankcardRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            PhonePayPanel.Visible = false;
            NetworkedGamePayPanel.Visible = false;
            AlipayPanel.Visible = false;
            BankcardPayPanel.Visible = true;
        }
    }
}