<%@ Page Title="" Language="C#" MasterPageFile="~/Template/OrderProcessTemplate.master" AutoEventWireup="true" CodeBehind="orderSubmitSuccess.aspx.cs" Inherits="Vneed.UI.Web.Page.V2.Help.orderSubmitSuccess" %>
<%@ Register src="../../../WebUserControl/V2/OrderProcessStepControl.ascx" tagname="OrderProcessStepControl" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head3" runat="server">
    <title>提交订单</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="subTitle" runat="server">
    <div class="subTitleFont">提交订单</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="OrderProcessMainContentPlaceHolder" runat="server">
    <uc1:OrderProcessStepControl ID="OrderProcessStepControl1" runat="server" />
    <div class="orderSubmitSuccessContentContainer">
        <div class="orderSubmitSuccessMainContentContainer">
            <table>
                <tr>
                    <td>
                        <div class="orderSubmitSuccessSubTitle">恭喜您，提交订单成功！</div>
                    </td>
                    <td>
                        <img src="../../../Resource/Image/register/success_register.png" alt=""/>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                       您可以点击“继续购物”按钮继续购物，也可以点击“我的Vneed”按钮查看订单情况。
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <div class="orderSubmitSuccessButtonContainer">
                            <asp:Button ID="BuyButton" runat="server" Text="继续购物" 
                                CssClass="orderSubmitSuccessButton" onclick="BuyButton_Click"/>
                            <asp:Button ID="MyVneedButton" runat="server" Text="我的Vneed" 
                                CssClass="orderSubmitSuccessButton" onclick="MyVneedButton_Click"/>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
