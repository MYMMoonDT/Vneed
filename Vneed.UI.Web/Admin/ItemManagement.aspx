<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="ItemManagement.aspx.cs" Inherits="Vneed.UI.Web.Admin.ItemManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <p>
        物品管理：</p>
    <p>
        <asp:ListBox ID="ListBoxCatalog" runat="server" AutoPostBack="True" 
            Height="508px" onselectedindexchanged="ListBoxCatalog_SelectedIndexChanged" 
            Width="244px"></asp:ListBox>
&nbsp;<asp:ListBox ID="ListBoxItem" runat="server" Height="507px" 
            style="margin-top: 0px" Width="304px"></asp:ListBox>
        <asp:Button ID="ButtonEdit" runat="server" Text="编辑" 
            onclick="ButtonEdit_Click" />
        <asp:Button ID="ButtonDelete" runat="server" Text="删除" 
            onclick="ButtonDelete_Click" />
        <asp:Button ID="ButtonAdd" runat="server" Text="新增" onclick="ButtonAdd_Click" />
    </p>
</asp:Content>
