<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="OrderManagement.aspx.cs" Inherits="Vneed.UI.Web.Admin.OrderManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <p>
        通用订单查询：</p>
    <p>
        订单状态：<asp:DropDownList ID="DropDownListStatus" runat="server">
            <asp:ListItem Value="0">未付款</asp:ListItem>
            <asp:ListItem Value="1">已付款</asp:ListItem>
            <asp:ListItem Value="2">已完成</asp:ListItem>
            <asp:ListItem Value="3">已作废</asp:ListItem>
        </asp:DropDownList>
&nbsp;下单时间：<asp:DropDownList ID="DropDownListDate" runat="server">
            <asp:ListItem Value="1">一天以内</asp:ListItem>
            <asp:ListItem Value="7">一周以内</asp:ListItem>
            <asp:ListItem Value="30">一月以内</asp:ListItem>
            <asp:ListItem Value="36500">所有</asp:ListItem>
        </asp:DropDownList>
&nbsp;<asp:Button ID="ButtonQuery" runat="server" onclick="ButtonQuery_Click" 
            style="width: 40px" Text="查询" />
    </p>
    <p>
        <asp:Table ID="Table" runat="server">
        </asp:Table>
    </p>
</asp:Content>
