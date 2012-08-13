<%@ Page Title="" Language="C#" MasterPageFile="~/Template/Template2.master" AutoEventWireup="true" CodeBehind="orderList.aspx.cs" Inherits="Vneed.UI.Web.Page.User.orderList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentRightPlaceHolder" runat="server">
    <div class="myOrderTitleDiv">
        <span class="myOrderTitleFont1">我的订单</span>
    </div>
    <!--Item-->
    <div class="myOrderContentItemDiv">
        <div class="myOrderContentItemImageDiv">
            <asp:Image ID="Image1" runat="server" CssClass="myOrderContentItemImage" ImageUrl="~/Image/ItemImage/default.jpg" />
        </div>
        <div class="myOrderContentItemDetailDiv">
            <div><span class="myOrderContentItemDetailFont1">订单号：</span></div>
            <div><span class="myOrderContentItemDetailFont1">下单日期：</span></div>
            <div><span class="myOrderContentItemDetailFont1">付款方式：</span></div>
            <div><span class="myOrderContentItemDetailFont1">金额：</span></div>
        </div>
        <div class="myOrderContentItemButtonDiv">
            <asp:Button ID="Button1" runat="server" Text="已付款" 
                CssClass="myOrderContentItemButton button"/>
        </div>
    </div>
    <!--Item-->
    <div class="myOrderContentItemDiv">
        <div class="myOrderContentItemImageDiv">
            <asp:Image ID="Image2" runat="server" CssClass="myOrderContentItemImage" ImageUrl="~/Image/ItemImage/default.jpg" />
        </div>
        <div class="myOrderContentItemDetailDiv">
            <div><span class="myOrderContentItemDetailFont1">订单号：</span></div>
            <div><span class="myOrderContentItemDetailFont1">下单日期：</span></div>
            <div><span class="myOrderContentItemDetailFont1">付款方式：</span></div>
            <div><span class="myOrderContentItemDetailFont1">金额：</span></div>
        </div>
        <div class="myOrderContentItemButtonDiv">
            <asp:Button ID="Button2" runat="server" Text="已付款" 
                CssClass="myOrderContentItemButton button"/>
        </div>
    </div>
</asp:Content>
