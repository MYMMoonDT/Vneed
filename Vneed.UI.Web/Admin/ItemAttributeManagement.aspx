﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="ItemAttributeManagement.aspx.cs" Inherits="Vneed.UI.Web.Admin.ItemAttributeManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    分类：<asp:DropDownList ID="DropDownListCatalogs" runat="server" 
    AutoPostBack="True" 
    onselectedindexchanged="DropDownListCatalogs_SelectedIndexChanged">
</asp:DropDownList>
&nbsp;<br />
<asp:Table ID="Table" runat="server">
</asp:Table>
<br />
新增属性：<br />
名称：<asp:TextBox ID="TextBoxNewAttrName" runat="server"></asp:TextBox>
&nbsp;分类：<asp:DropDownList ID="DropDownListNewAttrCatalog" runat="server">
</asp:DropDownList>
&nbsp;属性类别：<asp:DropDownList ID="DropDownListNewAttrLevel" runat="server">
</asp:DropDownList>
&nbsp;<asp:Button ID="ButtonAddAttr" runat="server" 
    onclick="ButtonAddAttr_Click" Text="新增" />
    <br />
    <br />
    编辑属性：<br />
    属性编号：<asp:TextBox ID="TextBoxEditID" runat="server"></asp:TextBox>
&nbsp;新名称：<asp:TextBox ID="TextBoxEditNewName" runat="server"></asp:TextBox>
&nbsp;<asp:Button ID="ButtonEdit" runat="server" onclick="ButtonEdit_Click" 
        Text="编辑" />
    <br />
    删除属性：<br />
    属性编号：<asp:TextBox ID="TextBoxDeleteID" runat="server"></asp:TextBox>
    <asp:Button ID="ButtonDelete" runat="server" onclick="ButtonDelete_Click" 
        Text="删除" />
</asp:Content>
