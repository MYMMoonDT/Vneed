<%@ Page Title="" Language="C#" MasterPageFile="~/Template/OrderProcessTemplate.master" AutoEventWireup="true" CodeBehind="orderDetail.aspx.cs" Inherits="Vneed.UI.Web.Page.V2.Business.orderDetail" %>
<%@ Register src="../../../WebUserControl/V2/OrderProcessStepControl.ascx" tagname="OrderProcessStepControl" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head3" runat="server">
    <title>订单信息</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="subTitle" runat="server">
    <div class="subTitleFont">订单信息</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="OrderProcessMainContentPlaceHolder" runat="server">
    <uc1:OrderProcessStepControl ID="OrderProcessStepControl1" runat="server" />
</asp:Content>
