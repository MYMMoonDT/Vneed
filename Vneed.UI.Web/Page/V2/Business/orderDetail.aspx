﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Template/OrderProcessTemplate.master" AutoEventWireup="true" CodeBehind="orderDetail.aspx.cs" Inherits="Vneed.UI.Web.Page.V2.Business.orderDetail" %>
<%@ Register src="../../../WebUserControl/V2/OrderProcessStepControl.ascx" tagname="OrderProcessStepControl" tagprefix="uc1" %>
<%@ Register src="../../../WebUserControl/V2/CartTableControl.ascx" tagname="CartTableControl" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head3" runat="server">
    <title>订单信息</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="subTitle" runat="server">
    <div class="subTitleFont">订单信息</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="OrderProcessMainContentPlaceHolder" runat="server">
    <table>
    <tr><td><uc1:OrderProcessStepControl ID="OrderProcessStepControl1" runat="server" /></td></tr>
    <tr><td>
        <div class="orderPersonalDataAndPaymentWayContainer">
            <div class="orderPersonalDataContainer">
                <div class="orderSubTitle">个人资料：</div>
                <div class="orderPersonalDataTextContainer">
                    <asp:TextBox ID="NameTextBox" runat="server" CssClass="orderPersonalDataTextBox"></asp:TextBox>
                    <asp:TextBox ID="SchoolTextBox" runat="server" CssClass="orderPersonalDataTextBox"></asp:TextBox>
                    <asp:TextBox ID="ContactTextBox" runat="server" CssClass="orderPersonalDataTextBox"></asp:TextBox>
                    <asp:TextBox ID="IDNumTextBox" runat="server" CssClass="orderPersonalDataTextBox"></asp:TextBox>
                    <asp:TextBox ID="EmailTextBox" runat="server" CssClass="orderPersonalDataTextBox"></asp:TextBox>
                    <asp:CheckBox ID="IsRegistCourseCheckBox" runat="server" Text="是否已经报名该课程" 
                        CssClass="orderPersonalDataCheckBox" AutoPostBack="True" 
                        oncheckedchanged="IsRegistCourseCheckBox_CheckedChanged"/>
                </div>
                <div id="orderPersonalDataErrorContainer">
                    
                </div>
            </div>
            <asp:Panel ID="orderPaymentWayPanel" runat="server">   
                <div class="orderPaymentWayContainer">
                    <div class="orderSubTitle">付款方式：</div>
                    <div class="orderPaymentWayRadioContainer">
                        <div>
                            <asp:RadioButton ID="OfflinePayRadioButton" runat="server" 
                                GroupName="PaymentGroup" 
                                Text="线下支付"
                                Checked="True"
                                CssClass="VneedRadio"/>
                        </div>
                    </div>
                </div>
            </asp:Panel>
            <asp:Panel ID="orderReturnWayPanel" runat="server" Visible="False">   
                <div class="orderPaymentWayContainer">
                    <div class="orderSubTitle">返款方式：</div>
                    <div class="orderPaymentWayRadioContainer">
                        <div>
                            <asp:RadioButton ID="PhonePayRadioButton" runat="server"
                                GroupName="PaymentGroup"
                                Text="话费充值"
                                CssClass="VneedRadio" AutoPostBack="True" 
                                oncheckedchanged="PhonePayRadioButton_CheckedChanged" />
                        </div>
                        <div>
                            <asp:RadioButton ID="NetworkedGameRadioButton" runat="server"
                                GroupName="PaymentGroup"
                                Text="网游充值"
                                CssClass="VneedRadio" AutoPostBack="True" 
                                oncheckedchanged="NetworkedGameRadioButton_CheckedChanged" />
                        </div>
                        <div>
                            <asp:RadioButton ID="AlipayRadioButton" runat="server" 
                                GroupName="PaymentGroup" 
                                Text="支付宝付款"
                                CssClass="VneedRadio" AutoPostBack="True" 
                                oncheckedchanged="AlipayRadioButton_CheckedChanged" />
                        </div>
                        <div>
                            <asp:RadioButton ID="BankcardRadioButton" runat="server"
                                GroupName="PaymentGroup"
                                Text="银行卡转账"
                                CssClass="VneedRadio" AutoPostBack="True" 
                                oncheckedchanged="BankcardRadioButton_CheckedChanged" />
                        </div>
                    </div>
                    <div class="orderPaymentWayTextBoxContainer">
                        <asp:Panel ID="PhonePayPanel" runat="server" Visible = "false">
                            <asp:TextBox ID="PhoneNoTextBox" runat="server" CssClass="orderPersonalDataTextBox">手机号码</asp:TextBox>
                        </asp:Panel>
                        <asp:Panel ID="NetworkedGamePayPanel" runat="server" Visible = "false">
                            <asp:TextBox ID="GameNameTextBox" runat="server" CssClass="orderPersonalDataTextBox">游戏名称</asp:TextBox>
                            <asp:TextBox ID="GameAccountTextBox" runat="server" CssClass="orderPersonalDataTextBox">游戏账户</asp:TextBox>
                            <asp:TextBox ID="GameOtherInfoTextBox" runat="server" CssClass="orderPersonalDataTextBox">其他信息</asp:TextBox>
                        </asp:Panel>
                        <asp:Panel ID="AlipayPanel" runat="server" Visible = "false">
                            <asp:TextBox ID="AlipayAccountTextBox" runat="server" CssClass="orderPersonalDataTextBox">支付宝账户</asp:TextBox>
                            <asp:TextBox ID="AlipayAccountOwnerNameTextBox" runat="server" CssClass="orderPersonalDataTextBox">户主</asp:TextBox>
                        </asp:Panel>
                        <asp:Panel ID="BankcardPayPanel" runat="server" Visible = "false">
                            <asp:TextBox ID="BankcardAccountTextBox" runat="server" CssClass="orderPersonalDataTextBox">银行卡号</asp:TextBox>
                            <asp:TextBox ID="BankcardAccountOwnerNameTextBox" runat="server" CssClass="orderPersonalDataTextBox">户主</asp:TextBox>
                        </asp:Panel>
                    </div>
                </div>
            </asp:Panel>
        </div>
    </td></tr>
    <tr>
        <td colspan="2">
            <div id="orderDetailCartTableContainer">
                <div class="orderSubTitle">商品清单：</div>
                <uc2:CartTableControl ID="CartTableControl1" runat="server" />
            </div>
        </td>
    </tr>
    <tr>
        <td>
            <div id="orderDetailOptionButtonContainer">
                <asp:Button ID="orderDetailSubmitButton" runat="server" 
                    Text="确认订单" 
                    CssClass="orderDetailSubmitButton" 
                    OnClientClick="return OrderDetailForm.Validation();" 
                    onclick="orderDetailSubmitButton_Click"/>
            </div>
        </td>
    </tr>
    </table>
<script type="text/javascript">
function OrderDetailForm() {
    this.parentID = "ContentPlaceHolder1_ContentPlaceHolder2_OrderProcessMainContentPlaceHolder";

    this.NameTextBoxID = "NameTextBox";
    this.SchoolTextBoxID = "SchoolTextBox";
    this.ContactTextBoxID = "ContactTextBox";
    this.IDNumTextBoxID = "IDNumTextBox";
    this.EmailTextBoxID = "EmailTextBox";

    this.NameTextBoxFullID = "#" + this.parentID + "_" + this.NameTextBoxID;
    this.SchoolTextBoxFullID = "#" + this.parentID + "_" + this.SchoolTextBoxID;
    this.ContactTextBoxFullID = "#" + this.parentID + "_" + this.ContactTextBoxID;
    this.IDNumTextBoxFullID = "#" + this.parentID + "_" + this.IDNumTextBoxID;
    this.EmailTextBoxFullID = "#" + this.parentID + "_" + this.EmailTextBoxID;

    this.Init();
}
OrderDetailForm.Validation = function () {
    $("#orderPersonalDataErrorContainer").html("");

    var parentID = "ContentPlaceHolder1_ContentPlaceHolder2_OrderProcessMainContentPlaceHolder";

    var NameTextBoxID = "NameTextBox";
    var SchoolTextBoxID = "SchoolTextBox";
    var ContactTextBoxID = "ContactTextBox";
    var IDNumTextBoxID = "IDNumTextBox";
    var EmailTextBoxID = "EmailTextBox";

    var NameTextBoxFullID = "#" + parentID + "_" + NameTextBoxID;
    var SchoolTextBoxFullID = "#" + parentID + "_" + SchoolTextBoxID;
    var ContactTextBoxFullID = "#" + parentID + "_" + ContactTextBoxID;
    var IDNumTextBoxFullID = "#" + parentID + "_" + IDNumTextBoxID;
    var EmailTextBoxFullID = "#" + parentID + "_" + EmailTextBoxID;

    var NameTextBoxRequiredValidation = new Validator({
        id: NameTextBoxFullID,
        type: "required",
        defaultStr: "姓名"
    });

    var SchoolTextBoxRequiredValidation = new Validator({
        id: SchoolTextBoxFullID,
        type: "required",
        defaultStr: "学校"
    });

    var ContactTextBoxRequiredValidation = new Validator({
        id: ContactTextBoxFullID,
        type: "required",
        defaultStr: "联系方式"
    });

    var ContactTextBoxRegExpValidation = new Validator({
        id: ContactTextBoxFullID,
        type: "regexp",
        regexp: /(^\d{11}$)|(^((\d{7,8})|(\d{4}|\d{3})-(\d{7,8})|(\d{4}|\d{3})-(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1})|(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1}))$)/
    });

    var IDNumTextBoxRegExpValidation = new Validator({
        id: IDNumTextBoxFullID,
        type: "regexp",
        defaultStr: "身份证号(用以报班使用，选填)",
        regexp: /(^\d{15}$)|(^\d{17}([0-9]|X|x)$)/
    });

    var EmailTextBoxRegExpValidation = new Validator({
        id: EmailTextBoxFullID,
        type: "regexp",
        regexp: /^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$/
    });

    if (!NameTextBoxRequiredValidation.Validation()) {
        $("#orderPersonalDataErrorContainer").html("<div class='error'>提交订单失败，请填写完整个人资料</div>");
        return false;
    }
    if (!SchoolTextBoxRequiredValidation.Validation()) {
        $("#orderPersonalDataErrorContainer").html("<div class='error'>提交订单失败，请填写完整个人资料</div>");
        return false;
    }
    if (!ContactTextBoxRequiredValidation.Validation()) {
        $("#orderPersonalDataErrorContainer").html("<div class='error'>提交订单失败，请填写完整个人资料</div>");
        return false;
    }

    if (!ContactTextBoxRegExpValidation.Validation()) {
        $("#orderPersonalDataErrorContainer").html("<div class='error'>提交订单失败，请填写正确的联系方式</div>");
        return false;
    }

    if (!($(IDNumTextBoxFullID).val() == "" || $(IDNumTextBoxFullID).val() == "身份证号(用以报班使用，选填)")) {
        if (!IDNumTextBoxRegExpValidation.Validation()) {
            $("#orderPersonalDataErrorContainer").html("<div class='error'>提交订单失败，请填写正确的身份证号</div>");
            return false;
        }
    }

    if (!($(EmailTextBoxFullID).val() == "" || $(EmailTextBoxFullID).val() == "邮箱(选填)")) {
        if (!EmailTextBoxRegExpValidation.Validation()) {
            $("#orderPersonalDataErrorContainer").html("<div class='error'>提交订单失败，请填写正确的邮箱</div>");
            return false;
        }
    }

    return true;
};

OrderDetailForm.prototype.Init = function () {
    this.NameTextBox = new TextBox({
        id: this.NameTextBoxFullID,
        defaultStr: "姓名",
        type: "text"
    });
    this.SchoolTextBox = new TextBox({
        id: this.SchoolTextBoxFullID,
        defaultStr: "学校",
        type: "text"
    });
    this.ContactTextBox = new TextBox({
        id: this.ContactTextBoxFullID,
        defaultStr: "联系方式",
        type: "text"
    });
    this.IDNumTextBox = new TextBox({
        id: this.IDNumTextBoxFullID,
        defaultStr: "身份证号(用以报班使用，选填)",
        type: "text"
    });
    this.EmailTextBox = new TextBox({
        id: this.EmailTextBoxFullID,
        defaultStr: "邮箱(选填)",
        type: "text"
    });
};
    
</script>
<script type="text/javascript">
    function OrderDetail() {
        this.Init();
    }
    OrderDetail.prototype.Init = function () {
        this.radioManager = new RadioManager();
        this.orderDetailFormInst = new OrderDetailForm();

        var parentID = "ContentPlaceHolder1_ContentPlaceHolder2_OrderProcessMainContentPlaceHolder";
        var paymentInputID = "OfflinePayRadioButton";
        var paymentInputFullID = parentID + "_" + paymentInputID;

        if ($("#" + paymentInputFullID).attr("checked") == "checked") {
            $("#OfflinePayMessageContainer").show();
        } else {
            $("#OfflinePayMessageContainer").hide();
        }

        $(".VneedRadio").click(function () {
            var children = $(this).children();
            var input = children[0];
            var label = children[1];

            var inputName = $(input).attr("name");
            var inputs = $(".VneedRadio input");
            var labels = $(".VneedRadio label");

            for (var i = 0; i < inputs.length; i++) {
                if ($(inputs[i]).attr("name") == inputName && inputs[i] != input) {
                    if (inputs[i].id == paymentInputFullID) {
                        $("#OfflinePayMessageContainer").hide();
                    }
                }
            }

            if (input.id == paymentInputFullID) {
                $("#OfflinePayMessageContainer").show();
            }
        });
    };
</script>
<script type="text/javascript">
    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function () {
        var OrderDetailInst = new OrderDetail();
    });
</script>
<script type="text/javascript">
    $(document).ready(function () {
        var OrderDetailInst = new OrderDetail();
    });
</script>
</asp:Content>
