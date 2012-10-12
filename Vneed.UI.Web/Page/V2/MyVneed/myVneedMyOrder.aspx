<%@ Page Title="" Language="C#" MasterPageFile="~/Template/MyVneedTemplate.master" AutoEventWireup="true" CodeBehind="myVneedMyOrder.aspx.cs" Inherits="Vneed.UI.Web.Page.V2.MyVneed.myVneedMyOrder" %>
<%@ Register src="../../../WebUserControl/V2/MyVneedMyOrderListControl.ascx" tagname="MyVneedMyOrderListControl" tagprefix="uc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="head3" runat="server">
    <title>我的订单</title>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="myVneedTemplateMainContent" runat="server">
<div class="myVneedMyOrderContainer">    
    <div class="myVneedMyOrderTitle">&nbsp;&nbsp;我的订单</div>
    <uc1:MyVneedMyOrderListControl ID="MyVneedMyOrderListControl1" runat="server" />
</div>
</asp:Content>
