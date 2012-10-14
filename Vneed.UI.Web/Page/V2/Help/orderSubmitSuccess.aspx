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
    <div>
        恭喜您，提交订单成功！
    </div>
</asp:Content>
