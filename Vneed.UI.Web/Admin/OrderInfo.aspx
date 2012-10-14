<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="OrderInfo.aspx.cs" Inherits="Vneed.UI.Web.Admin.OrderInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <asp:Table ID="Table" runat="server">
    </asp:Table>
    <br />
    <asp:Button ID="ButtonFinish" runat="server" onclick="ButtonFinish_Click" 
        Text="完成该订单" />
</asp:Content>
