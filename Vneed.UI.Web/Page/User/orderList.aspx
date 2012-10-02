<%@ Page Title="" Language="C#" MasterPageFile="~/Template/Template2.master" AutoEventWireup="true" CodeBehind="orderList.aspx.cs" Inherits="Vneed.UI.Web.Page.User.orderList" %>
<%@ Register src="../../WebUserControl/OrderList.ascx" tagname="OrderList" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentRightPlaceHolder" runat="server">
    <div class="myOrderTitleDiv">
        <span class="myOrderTitleFont1">我的订单</span>

    </div>
    <uc1:OrderList ID="OrderList" runat="server" />
</asp:Content>
