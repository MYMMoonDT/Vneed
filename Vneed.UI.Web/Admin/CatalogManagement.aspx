<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="CatalogManagement.aspx.cs" Inherits="Vneed.UI.Web.Admin.CatalogManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
总览：<br />
    <asp:Table ID="Table" runat="server">
    </asp:Table>
    <br />
    新增：<br />
    分类名：<asp:TextBox ID="TextBoxNewCatalogName" runat="server"></asp:TextBox>
&nbsp;父分类：<asp:DropDownList ID="DropDownListFirstLevelCatalogs" runat="server">
    </asp:DropDownList>
&nbsp;<asp:Button ID="ButtonAddCatalog" runat="server" 
        onclick="ButtonAddCatalog_Click" Text="新增" />
    <br />
    修改：<br />
    目标分类：<asp:DropDownList ID="DropDownListModifyCatalog" runat="server">
    </asp:DropDownList>
&nbsp;新名称：<asp:TextBox ID="TextBoxModifyCatalog" runat="server"></asp:TextBox>
&nbsp;<asp:Button ID="ButtonModifyCatalog" runat="server" 
        onclick="ButtonModifyCatalog_Click" Text="修改" />
    <br />
    删除：<br />
    目标分类：<asp:DropDownList ID="DropDownListDeleteCatalog" runat="server">
    </asp:DropDownList>
    <asp:Button ID="ButtonDeleteCatalog" runat="server" 
        onclick="ButtonDeleteCatalog_Click" Text="删除" />
</asp:Content>
